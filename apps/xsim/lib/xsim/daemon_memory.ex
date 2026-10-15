defmodule Xsim.DaemonMemory do
  use GenServer

  @tree_sampler ~S"""
  param([int]$Root, [int]$IntervalMs, [string]$Out)
  $ErrorActionPreference = 'Stop'
  while ($true) {
      $all = @(Get-CimInstance Win32_Process -Property ProcessId, ParentProcessId, WorkingSetSize)
      if (-not ($all | Where-Object ProcessId -eq $Root)) { break }
      $tree = [Collections.Generic.List[int]]::new()
      $tree.Add($Root)
      for ($i = 0; $i -lt $tree.Count; $i++) { foreach ($p in $all) { if ($p.ParentProcessId -eq $tree[$i] -and $p.ProcessId -ne $tree[$i]) { $tree.Add([int]$p.ProcessId) } } }
      $bytes = ($all | Where-Object { $tree.Contains([int]$_.ProcessId) } | Measure-Object WorkingSetSize -Sum).Sum
      [IO.File]::AppendAllText($Out, "$($tree.Count) $([int64]($bytes / 1MB))`n")
      Start-Sleep -Milliseconds $IntervalMs
  }
  """

  def start(kino_port, interval_ms \\ 1_000), do: GenServer.start(__MODULE__, {kino_port, interval_ms})

  def start_tree(os_pid, interval_ms \\ 1_000), do: GenServer.start(__MODULE__, {:tree, os_pid, interval_ms})

  def peak(server), do: GenServer.call(server, :peak)

  def stop(server) do
    reading = peak(server)
    GenServer.stop(server)
    reading
  end

  def daemon_pid(kino_port) do
    with {:ok, sock} <- :gen_tcp.connect(~c"127.0.0.1", kino_port, [:binary, packet: :line, active: false], 1_000),
         :ok <- :gen_tcp.send(sock, "hello\n"),
         {:ok, line} <- :gen_tcp.recv(sock, 0, 2_000) do
      :gen_tcp.close(sock)

      case String.split(String.trim(line), "\t") do
        ["spiral-kino", _version, pid | _] -> parse_pid(pid)
        _ -> nil
      end
    else
      _ -> nil
    end
  end

  def parse_sample(line) do
    with [procs, mb] <- String.split(String.trim(line), " "),
         {procs, ""} <- Integer.parse(procs),
         {mb, ""} <- Integer.parse(mb) do
      {procs, mb}
    else
      _ -> nil
    end
  end

  @impl true
  def init({:tree, os_pid, interval_ms}), do: {:ok, sampling(empty(nil, interval_ms), os_pid)}

  def init({kino_port, interval_ms}) do
    send(self(), :find_daemon)
    {:ok, empty(kino_port, interval_ms)}
  end

  @impl true
  def handle_info(:find_daemon, %{port: nil} = state) do
    case daemon_pid(state.kino_port) do
      nil ->
        Process.send_after(self(), :find_daemon, state.interval_ms)
        {:noreply, state}

      os_pid ->
        {:noreply, sampling(state, os_pid)}
    end
  end

  def handle_info(:find_daemon, state), do: {:noreply, state}

  def handle_info(:read_samples, %{samples_file: file} = state) when is_binary(file) do
    if state.port, do: Process.send_after(self(), :read_samples, state.interval_ms)

    lines =
      case File.read(file) do
        {:ok, text} -> text |> binary_part(min(state.read_bytes, byte_size(text)), byte_size(text) - min(state.read_bytes, byte_size(text))) |> String.split("\n", trim: true)
        _ -> []
      end

    read_bytes = case File.stat(file) do
      {:ok, %{size: size}} -> size
      _ -> state.read_bytes
    end

    state =
      lines
      |> Enum.map(&parse_sample/1)
      |> Enum.reject(&is_nil/1)
      |> Enum.reduce(state, fn {procs, mb}, acc ->
        %{acc | samples: acc.samples + 1, last_mb: mb, procs: max(acc.procs, procs), peak_mb: max(acc.peak_mb, mb)}
      end)

    {:noreply, %{state | read_bytes: read_bytes}}
  end

  def handle_info({port, {:exit_status, _}}, %{port: port} = state) do
    if state.kino_port, do: Process.send_after(self(), :find_daemon, state.interval_ms)
    {:noreply, %{state | port: nil}}
  end

  def handle_info(_message, state), do: {:noreply, state}

  @impl true
  def handle_call(:peak, _from, state) do
    {:noreply, read} = if state.samples_file, do: handle_info(:read_samples, %{state | port: nil}), else: {:noreply, state}
    state = %{read | port: state.port}
    {:reply, Map.take(state, [:daemon, :peak_mb, :last_mb, :procs, :samples]), state}
  end

  @impl true
  def terminate(_reason, %{port: port} = state) when is_port(port) do
    if state.samples_file, do: File.rm(state.samples_file)
    with {:os_pid, os_pid} <- Port.info(port, :os_pid) do
      System.cmd("taskkill", ["/F", "/PID", Integer.to_string(os_pid)], stderr_to_stdout: true)
    end

    :ok
  end

  def terminate(_reason, state) do
    if state.samples_file, do: File.rm(state.samples_file)
    :ok
  end

  defp empty(kino_port, interval_ms) do
    %{kino_port: kino_port, interval_ms: interval_ms, port: nil, daemon: nil, peak_mb: 0, last_mb: 0, procs: 0, samples: 0, samples_file: nil, read_bytes: 0}
  end

  defp sampling(state, os_pid) do
    script = Path.join(System.tmp_dir!(), "xsim-tree-sampler-#{System.pid()}.ps1")
    samples_file = Path.join(System.tmp_dir!(), "xsim-tree-samples-#{System.pid()}-#{System.unique_integer([:positive])}.txt")
    File.write!(script, @tree_sampler)
    File.write!(samples_file, "")
    pwsh = System.find_executable("pwsh") || System.find_executable("powershell")

    port =
      Port.open({:spawn_executable, pwsh}, [
        :binary,
        :exit_status,
        :hide,
        args: ["-NoProfile", "-NonInteractive", "-File", script, "-Root", Integer.to_string(os_pid), "-IntervalMs", Integer.to_string(state.interval_ms), "-Out", samples_file]
      ])

    Process.send_after(self(), :read_samples, state.interval_ms)
    %{state | port: port, daemon: os_pid, samples_file: samples_file, read_bytes: 0}
  end

  defp parse_pid(text) do
    case Integer.parse(text) do
      {pid, ""} -> pid
      _ -> nil
    end
  end
end
