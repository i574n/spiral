defmodule Spiral.Kino.TestHelpers do
  @fixtures Path.expand("fixtures", __DIR__)

  def fixture(name), do: Path.join(@fixtures, name)

  def escript do
    exe = if match?({:win32, _}, :os.type()), do: "escript.exe", else: "escript"
    path = Path.join([:code.root_dir(), "bin", exe])
    if File.regular?(path), do: path, else: System.find_executable("escript")
  end

  def script!(dir, name, main_body) do
    File.mkdir_p!(dir)
    path = Path.join(dir, name <> ".escript")
    File.write!(path, "#!/usr/bin/env escript\n%%! -noinput\n" <> main_body <> "\n")
    path
  end

  def tmp_dir!(tag) do
    dir =
      Path.join([
        System.tmp_dir!(),
        "spiral_kino_test",
        "#{tag}-#{System.unique_integer([:positive])}"
      ])

    File.rm_rf!(dir)
    File.mkdir_p!(dir)
    ExUnit.Callbacks.on_exit(fn -> File.rm_rf(dir) end)
    dir
  end

  def wait_until(fun, timeout \\ 15_000, interval \\ 100) do
    deadline = System.monotonic_time(:millisecond) + timeout
    do_wait(fun, deadline, interval)
  end

  defp do_wait(fun, deadline, interval) do
    if value = fun.() do
      value
    else
      if System.monotonic_time(:millisecond) > deadline do
        nil
      else
        receive do
        after
          interval -> do_wait(fun, deadline, interval)
        end
      end
    end
  end

  def read_pid(path) do
    with {:ok, text} <- File.read(path),
         {pid, _} <- Integer.parse(String.trim(text)) do
      pid
    else
      _ -> nil
    end
  end
end

test_port? = System.get_env("SPIRAL_KINO_COMPILER_PORT") in [nil, ""]

# A free port per run, so two concurrent `mix test` runs never share (and retire) one test daemon.
if test_port? do
  {:ok, socket} = :gen_tcp.listen(0, ip: {127, 0, 0, 1})
  {:ok, port} = :inet.port(socket)
  :gen_tcp.close(socket)
  System.put_env("SPIRAL_KINO_COMPILER_PORT", Integer.to_string(port))
end

Spiral.Kino.Domain.ensure!()
ExUnit.start()

# Live tests start a compiler daemon on the test port; retire it when the suite ends so it does not linger.
# A port given through SPIRAL_KINO_COMPILER_PORT belongs to the caller and is left alone.
if test_port? do
  ExUnit.after_suite(fn _ ->
    Spiral.Kino.CompilerClient.shutdown()

    # The per-run port names the daemon's logs and lock (kino-<port>.*): drop them so runs do not pile them up.
    port = System.get_env("SPIRAL_KINO_COMPILER_PORT")

    base =
      String.replace(
        System.get_env("LOCALAPPDATA") || Path.join(System.user_home!(), ".cache"),
        "\\",
        "/"
      )

    pattern = Path.join([base, "spiral-bin", "kino-#{port}.*"])

    # The daemon's OS process can hold its logs open for a moment after its port closes.
    Enum.reduce_while(1..20, :ok, fn _, :ok ->
      Enum.each(Path.wildcard(pattern), &File.rm/1)

      if Path.wildcard(pattern) == [] do
        {:halt, :ok}
      else
        Process.sleep(250)
        {:cont, :ok}
      end
    end)
  end)
end
