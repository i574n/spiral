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

Spiral.Kino.Domain.ensure!()
ExUnit.start()
