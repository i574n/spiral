defmodule Spiral.Kino.FileLock do
  @spec with_lock(String.t(), (-> term()), non_neg_integer()) :: term()
  def with_lock(path, fun, timeout \\ 30_000) when is_function(fun, 0) do
    File.mkdir_p!(Path.dirname(path))
    claim(path, fun, System.monotonic_time(:millisecond) + timeout)
  end

  defp claim(path, fun, deadline) do
    case File.open(path, [:write, :exclusive]) do
      {:ok, io} ->
        try do
          IO.write(io, System.pid())
          fun.()
        after
          File.close(io)
          File.rm(path)
        end

      {:error, reason} when reason in [:eexist, :eacces] ->
        cond do
          holder_dead?(path) ->
            File.rm(path)
            claim(path, fun, deadline)

          System.monotonic_time(:millisecond) > deadline ->
            {:error, :lock_timeout}

          true ->
            Process.sleep(50)
            claim(path, fun, deadline)
        end

      {:error, reason} ->
        {:error, reason}
    end
  end

  # A holder creates the file and then writes its pid: an empty (or unparsable) file is a holder caught between the
  # two, so it counts as held until it is older than this grace period (then its writer died before writing).
  @grace_s 5

  defp holder_dead?(path) do
    case File.read(path) do
      {:ok, text} ->
        case Integer.parse(String.trim(text)) do
          {pid, ""} -> not Spiral.Kino.Runner.os_pid_alive?(pid)
          _ -> older_than_grace?(path)
        end

      _ ->
        false
    end
  end

  defp older_than_grace?(path) do
    case File.stat(path, time: :posix) do
      {:ok, %{mtime: mtime}} -> System.os_time(:second) - mtime > @grace_s
      _ -> false
    end
  end
end
