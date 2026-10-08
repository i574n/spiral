defmodule Spiral.Kino.FileLock do
  @spec with_lock(String.t(), (-> term()), non_neg_integer()) :: term()
  def with_lock(path, fun, timeout \\ 30_000) when is_function(fun, 0) do
    File.mkdir_p!(Path.dirname(path))
    now = System.monotonic_time(:millisecond)
    claim(path, fun, now + timeout, now)
  end

  @liveness_every_ms 2_000

  defp claim(path, fun, deadline, next_check) do
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
        now = System.monotonic_time(:millisecond)
        check? = now >= next_check

        cond do
          check? and holder_dead?(path) ->
            File.rm(path)
            claim(path, fun, deadline, now)

          now > deadline ->
            {:error, :lock_timeout}

          true ->
            Process.sleep(50)
            claim(path, fun, deadline, if(check?, do: now + @liveness_every_ms, else: next_check))
        end

      {:error, reason} ->
        {:error, reason}
    end
  end

  @grace_s 5

  defp holder_dead?(path) do
    case File.read(path) do
      {:ok, text} ->
        case Integer.parse(String.trim(text)) do
          {pid, ""} -> Integer.to_string(pid) != System.pid() and not Spiral.Kino.Runner.os_pid_alive?(pid)
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
