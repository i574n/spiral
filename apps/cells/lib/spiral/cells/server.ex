defmodule Spiral.Cells.Server do
  @moduledoc false

  @connect_timeout_ms 500

  def info_path do
    base = System.get_env("SPIRAL_BIN_CACHE_DIR") || Path.join(System.get_env("LOCALAPPDATA") || System.tmp_dir!(), "spiral-bin")
    Path.join([base, "cells-server", "#{System.get_env("USERNAME") || System.get_env("USER") || "user"}.term"])
  end

  def source_stamp do
    root = Path.expand("../../..", __DIR__)

    Path.wildcard(Path.join(root, "lib/**/*.ex"))
    |> Enum.sort()
    |> Enum.map(fn file ->
      stat = File.stat!(file)
      {file, stat.size, stat.mtime}
    end)
    |> :erlang.term_to_binary()
    |> then(&:crypto.hash(:sha256, &1))
    |> Base.encode16(case: :lower)
  end

  def serve do
    {:ok, listener} = :gen_tcp.listen(0, [:binary, packet: 4, active: false, reuseaddr: true, ip: {127, 0, 0, 1}])
    {:ok, port} = :inet.port(listener)
    File.mkdir_p!(Path.dirname(info_path()))
    File.write!(info_path(), :erlang.term_to_binary(%{port: port, os_pid: System.pid(), stamp: source_stamp()}))
    IO.puts("cells server on 127.0.0.1:#{port}")
    accept(listener)
  end

  defp accept(listener) do
    {:ok, socket} = :gen_tcp.accept(listener)

    reply =
      case :gen_tcp.recv(socket, 0) do
        {:ok, request} -> request |> :erlang.binary_to_term() |> run_request()
        {:error, reason} -> {{:error, "cells server receive failed: #{inspect(reason)}"}, []}
      end

    :gen_tcp.send(socket, :erlang.term_to_binary(reply))
    :gen_tcp.close(socket)
    accept(listener)
  end

  defp run_request(%{args: args, cwd: cwd, env: env}) do
    previous_cwd = File.cwd!()
    previous_env = for {name, _} <- System.get_env(), String.starts_with?(name, "SPIRAL_"), into: %{}, do: {name, System.get_env(name)}

    try do
      Enum.each(Map.keys(previous_env), &System.delete_env/1)
      Enum.each(env, fn {name, value} -> System.put_env(name, value) end)
      File.cd!(cwd)
      Spiral.Cells.NotebookCli.execute(args)
    rescue
      e -> {{:error, "cells server: " <> Exception.message(e)}, []}
    after
      File.cd!(previous_cwd)
      Enum.each(env, fn {name, _} -> System.delete_env(name) end)
      Enum.each(previous_env, fn {name, value} -> System.put_env(name, value) end)
    end
  end

  def try_execute(args) do
    with true <- System.get_env("SPIRAL_CELLS_SERVER") != "0",
         {:ok, binary} <- File.read(info_path()),
         %{port: port, stamp: stamp} <- :erlang.binary_to_term(binary),
         true <- stamp == source_stamp(),
         {:ok, socket} <- :gen_tcp.connect({127, 0, 0, 1}, port, [:binary, packet: 4, active: false], @connect_timeout_ms) do
      env = for {name, value} <- System.get_env(), String.starts_with?(name, "SPIRAL_"), into: %{}, do: {name, value}
      :ok = :gen_tcp.send(socket, :erlang.term_to_binary(%{args: args, cwd: File.cwd!(), env: env}))

      result =
        case :gen_tcp.recv(socket, 0, :infinity) do
          {:ok, reply} -> {:served, :erlang.binary_to_term(reply)}
          {:error, _} -> :unavailable
        end

      :gen_tcp.close(socket)
      result
    else
      _ -> :unavailable
    end
  end
end
