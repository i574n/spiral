defmodule Spiral.Kino.Targets do
  alias Spiral.Kino.{Builders, ProcessError, Runner, TimeoutError, Toolchain}

  @spec host_key(map()) :: {atom(), String.t()} | nil
  def host_key(%{kind: :fsharp}), do: {:fsharp, "fsharp"}

  def host_key(%{kind: :code, language: language}) when is_binary(language) do
    case String.downcase(language) do
      "fsharp" -> {:fsharp, "fsharp"}
      "fs" -> {:fsharp, "fsharp"}
      "python" -> {:python, "python"}
      "py" -> {:python, "python"}
      "lua" -> {:lua, "lua"}
      "javascript" -> {:javascript, "javascript"}
      "js" -> {:javascript, "javascript"}
      "powershell" -> {:powershell, "powershell"}
      "pwsh" -> {:powershell, "powershell"}
      _ -> nil
    end
  end

  def host_key(_), do: nil

  @spec run(map(), String.t(), keyword(), timeout(), integer() | :infinity) ::
          {:ok, %{stdout: String.t()}} | {:error, Exception.t()}
  def run(builder, output_path, opts, timeout, deadline) do
    invoke(
      opts[:target],
      %{builder: builder, source: read_if(output_path), output_path: output_path, flags: builder},
      fn ->
        run_default(builder, output_path, opts, timeout, deadline)
      end
    )
    |> normalize(true)
  end

  @spec host(String.t(), String.t(), keyword(), timeout(), integer() | :infinity) ::
          {:ok, %{stdout: String.t()}} | {:error, Exception.t()}
  def host(language, source, opts, timeout, deadline) do
    invoke(opts[:host], %{language: language, source: source}, fn ->
      dir = tmp_dir()

      try do
        path = Path.join(dir, "main" <> host_extension(language))
        File.write!(path, source)
        run_host(language, path, opts, timeout, deadline)
      after
        File.rm_rf(dir)
      end
    end)
    |> normalize(false)
  end

  defp run_default(builder, output_path, opts, timeout, deadline) do
    case Builders.dispatch(builder, output_path) do
      {:spiral, args} ->
        run_spiral(args, opts, timeout, deadline)
        |> promote_spiral(builder, output_path, opts, timeout, deadline)

      {:fsi, path} ->
        run_fsi(path, opts, timeout, deadline)

      {:python, path} ->
        run_program(Toolchain.python(opts), "python", [path], opts, timeout, deadline, false)

      {:cc, path} ->
        run_cc(path, opts, timeout, deadline)

      {:dcc, path} ->
        run_dcc(path, opts, timeout, deadline)
    end
  end

  defp run_host("fsharp", path, opts, timeout, deadline),
    do: run_fsi(path, opts, timeout, deadline)

  defp run_host("python", path, opts, timeout, deadline) do
    run_program(Toolchain.python(opts), "python", [path], opts, timeout, deadline, false)
  end

  defp run_host("lua", path, opts, timeout, deadline) do
    run_program(Toolchain.lua(opts), "lua", [path], opts, timeout, deadline, false)
  end

  defp run_host("javascript", path, opts, timeout, deadline) do
    run_program(Toolchain.node(opts), "node", [path], opts, timeout, deadline, false)
  end

  defp run_host("powershell", path, opts, timeout, deadline) do
    run_program(
      Toolchain.pwsh(opts),
      "pwsh",
      ["-NoProfile", "-File", path],
      opts,
      timeout,
      deadline,
      false
    )
  end

  defp run_spiral(args, opts, timeout, deadline) do
    shown = "spiral " <> Enum.join(args, " ")
    exe = Toolchain.spiral(opts)

    if is_binary(exe) and File.regular?(exe) do
      run_program(exe, shown, args, opts, timeout, deadline, true)
    else
      {:error, %ProcessError{message: "`#{shown}` was not found"}}
    end
  end

  defp promote_spiral(
         {:ok, %{output: _output}} = ran,
         %{tool: :cpp},
         output_path,
         opts,
         timeout,
         deadline
       ) do
    exe = cpp_exe(output_path)

    if File.regular?(exe) do
      case run_status(exe, Path.basename(exe), [], opts, timeout, deadline, false) do
        {:ok, built} -> {:ok, cell_exit(%{output: ""}, built)}
        error -> error
      end
    else
      promote_trace(ran)
    end
  end

  defp promote_spiral(result, _builder, _output_path, _opts, _timeout, _deadline) do
    promote_trace(result)
  end

  defp promote_trace({:ok, %{output: output}} = ran) do
    case failure_trace(output) do
      nil -> ran
      message -> {:error, %ProcessError{message: message, output: output}}
    end
  end

  defp promote_trace(other), do: other

  defp failure_trace(output) do
    field = output_field(output)
    trace = trace_text(output)

    cond do
      is_binary(field) and String.trim(field) != "" -> nil
      trace == "" -> nil
      failure?(trace) -> trace
      true -> nil
    end
  end

  defp failure?(trace) do
    down = String.downcase(trace)
    String.contains?(down, "error") or String.contains?(down, "failed")
  end

  defp cpp_exe(path) do
    path <> ".out" <> if(match?({:win32, _}, :os.type()), do: ".exe", else: "")
  end

  defp run_fsi(path, opts, timeout, deadline) do
    dotnet = Toolchain.dotnet(opts)

    cond do
      not (is_binary(dotnet) and File.regular?(dotnet)) ->
        {:error, %ProcessError{message: "`dotnet fsi` was not found"}}

      true ->
        run_program(
          dotnet,
          "dotnet fsi",
          ["fsi", "--nologo", "--exec", path],
          opts,
          timeout,
          deadline,
          false
        )
    end
  end

  defp run_cc(path, opts, timeout, deadline) do
    cc = Toolchain.cc(opts)

    if is_binary(cc) and File.regular?(cc) do
      exe = Path.join(Path.dirname(path), exe_name())
      args = if cl?(cc), do: ["/nologo", "/Fe:#{exe}", path], else: ["-o", exe, path]
      shown = Path.basename(cc)

      with {:ok, compiled} <- run_program(cc, shown, args, opts, timeout, deadline, false),
           {:ok, ran} <- run_status(exe, exe_name(), [], opts, timeout, deadline, false) do
        {:ok, cell_exit(compiled, ran)}
      end
    else
      {:error, %ProcessError{message: "`gcc` was not found"}}
    end
  end

  defp run_dcc(path, opts, timeout, deadline) do
    dcc = Toolchain.dcc(opts)

    if is_binary(dcc) and File.regular?(dcc) do
      with {:ok, compiled} <- run_program(dcc, "dcc32", [path], opts, timeout, deadline, false) do
        exe = Path.join(Path.dirname(path), Path.basename(path, Path.extname(path)) <> ".exe")

        if File.regular?(exe) do
          case run_status(exe, Path.basename(exe), [], opts, timeout, deadline, false) do
            {:ok, ran} -> {:ok, cell_exit(compiled, ran)}
            error -> error
          end
        else
          {:ok, compiled}
        end
      end
    else
      {:error, %ProcessError{message: "`dcc32` was not found"}}
    end
  end

  defp run_program(exe, shown, args, opts, timeout, deadline, spiral?) do
    case run_status(exe, shown, args, opts, timeout, deadline, spiral?) do
      {:ok, %{exit_status: 0, output: output}} ->
        {:ok, %{exit_status: 0, output: output}}

      {:ok, %{exit_status: status, output: output}} ->
        {:error,
         %ProcessError{
           message: "`#{shown}` failed (exit #{status})\n\n#{output}",
           exit_status: status,
           output: output
         }}

      other ->
        other
    end
  end

  defp run_status(exe, shown, args, opts, timeout, deadline, spiral?) do
    cond do
      not is_binary(exe) ->
        {:error, %ProcessError{message: "`#{shown}` was not found"}}

      not File.regular?(exe) and is_nil(System.find_executable(exe)) ->
        {:error, %ProcessError{message: "`#{shown}` was not found at #{exe}"}}

      true ->
        case Runner.run(exe, args,
               timeout: budget(deadline),
               cd: if(spiral?, do: nil, else: work_dir(args, exe)),
               env: tool_env(opts, spiral?)
             ) do
          {:ok, %{exit_status: status, output: output}} ->
            {:ok, %{exit_status: status, output: output}}

          {:error, {:timeout, info}} ->
            {:error, timeout_error(info, timeout)}

          {:error, reason} ->
            {:error, %ProcessError{message: "could not start `#{shown}`: #{inspect(reason)}"}}
        end
    end
  end

  defp cell_exit(compiled, ran) do
    %{
      exit_status: 0,
      output: join_output(compiled, %{output: ran.output}),
      value: Integer.to_string(ran.exit_status)
    }
  end

  defp normalize({:ok, %{exit_status: 0, output: output} = ran}, present?) do
    text = if present?, do: present(output), else: output
    shown = %{stdout: String.trim(text)}
    shown = if is_binary(ran[:value]), do: Map.put(shown, :value, ran.value), else: shown
    {:ok, shown}
  end

  defp normalize({:ok, %{stdout: stdout}}, _present?) when is_binary(stdout) do
    {:ok, %{stdout: stdout}}
  end

  defp normalize({:ok, %{exit_status: status, output: output}}, _present?) do
    {:error,
     %ProcessError{
       message: "builder failed (exit #{status})\n\n#{output}",
       exit_status: status,
       output: output
     }}
  end

  defp normalize({:error, {:timeout, info}}, _present?),
    do: {:error, timeout_error(info, info.timeout)}

  defp normalize({:error, %TimeoutError{} = error}, _present?), do: {:error, error}
  defp normalize({:error, %ProcessError{} = error}, _present?), do: {:error, error}

  defp normalize({:error, reason}, _present?) do
    {:error, %ProcessError{message: "could not run the builder: #{inspect(reason)}"}}
  end

  defp present(output) do
    trimmed = String.trim(output)
    field = output_field(trimmed)
    trace = trace_text(trimmed)

    cond do
      is_binary(field) and String.trim(field) != "" -> String.trim(field)
      trace != "" -> trace
      is_binary(field) -> ""
      true -> trimmed
    end
  end

  defp output_field(text) do
    case result_map(text) || result_map_line(text) do
      nil -> nil
      map -> shown_output(map)
    end
  end

  defp trace_text(text) do
    text
    |> String.replace(~r/\e\[[0-9;]*m/, "")
    |> String.split(~r/\r?\n/)
    |> Enum.reject(fn line ->
      trimmed = String.trim(line)
      trimmed == "" or result_map(trimmed) != nil
    end)
    |> Enum.join("\n")
    |> String.trim()
  end

  defp result_map(text) when is_binary(text) do
    case decode_result(text) do
      nil ->
        case Regex.run(~r/(\{.*\})\s*$/, text) do
          [_, candidate] -> decode_result(candidate)
          _ -> nil
        end

      map ->
        map
    end
  end

  defp result_map(_), do: nil

  defp result_map_line(text) do
    text
    |> String.split(~r/\r?\n/)
    |> Enum.reverse()
    |> Enum.find_value(&result_map/1)
  end

  defp decode_result(text) do
    case json_map(text) do
      nil -> nil
      map -> if result?(map), do: map
    end
  end

  defp result?(map) do
    Map.has_key?(map, "output") or Map.has_key?(map, "command_result")
  end

  defp shown_output(map) do
    inner = command_result(map)

    cond do
      is_binary(inner["output"]) -> inner["output"]
      is_binary(map["output"]) -> map["output"]
      true -> nil
    end
  end

  defp command_result(%{"command_result" => text}) when is_binary(text) do
    json_map(text) || %{}
  end

  defp command_result(%{"command_result" => map}) when is_map(map), do: map
  defp command_result(_), do: %{}

  defp json_map(text) when is_binary(text) and text != "" do
    case JSON.decode(text) do
      {:ok, map} when is_map(map) -> map
      _ -> nil
    end
  end

  defp json_map(_), do: nil

  defp tool_env(_opts, false), do: System.get_env() |> Enum.to_list()

  defp tool_env(_opts, true) do
    System.get_env()
    |> Enum.to_list()
    |> List.keystore("SPIRAL_JSON", 0, {"SPIRAL_JSON", "1"})
    |> List.keystore("TRACE_LEVEL", 0, {"TRACE_LEVEL", "Info"})
  end

  defp work_dir([], exe), do: Path.dirname(exe)

  defp work_dir(args, exe) do
    case List.last(args) do
      path when is_binary(path) ->
        if File.regular?(path), do: Path.dirname(path), else: Path.dirname(exe)

      _ ->
        Path.dirname(exe)
    end
  end

  defp join_output(%{output: left}, %{output: right}) do
    [left, right] |> Enum.reject(&(&1 in [nil, ""])) |> Enum.join("\n")
  end

  defp read_if(path) do
    case File.read(path) do
      {:ok, text} -> text
      _ -> ""
    end
  end

  defp invoke(nil, _ctx, default), do: default.()
  defp invoke(fun, ctx, _default) when is_function(fun, 1), do: fun.(ctx)

  defp cl?(path) do
    path |> Path.basename() |> String.downcase() |> String.trim_trailing(".exe") == "cl"
  end

  defp host_extension("fsharp"), do: ".fsx"
  defp host_extension("python"), do: ".py"
  defp host_extension("lua"), do: ".lua"
  defp host_extension("javascript"), do: ".js"
  defp host_extension("powershell"), do: ".ps1"

  defp exe_name, do: if(match?({:win32, _}, :os.type()), do: "cell.exe", else: "cell")

  defp tmp_dir do
    dir =
      Path.join([
        System.tmp_dir!(),
        "spiral_kino",
        "#{System.os_time(:millisecond)}-#{System.unique_integer([:positive])}"
      ])

    File.mkdir_p!(dir)
    dir
  end

  defp budget(:infinity), do: :infinity

  defp budget(deadline) do
    deadline =
      case Process.get(:spiral_kino_deadline) do
        ms when is_integer(ms) -> ms
        :infinity -> :infinity
        _ -> deadline
      end

    case deadline do
      :infinity -> :infinity
      ms -> max(ms - System.monotonic_time(:millisecond), 0)
    end
  end

  defp timeout_error(%{output: output}, timeout) do
    %TimeoutError{
      message: "Spiral cell timed out after #{format_ms(timeout)}; the process tree was killed.",
      timeout: timeout,
      output: output
    }
  end

  defp format_ms(:infinity), do: "infinity"
  defp format_ms(ms) when is_integer(ms) and rem(ms, 1000) == 0, do: "#{div(ms, 1000)}s"
  defp format_ms(ms), do: "#{ms}ms"
end
