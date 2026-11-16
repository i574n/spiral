defmodule Spiral.Cells.Accept do
  alias Spiral.Cells.FileLock

  @spec mismatch(String.t()) :: {:ok, String.t(), String.t()} | :none
  def mismatch(message) do
    case String.split(Spiral.Cells.Domain.accept_mismatch(message), "\n") do
      [actual, expected] -> {:ok, actual, expected}
      _ -> :none
    end
  end

  @spec passed_before(String.t()) :: non_neg_integer()
  def passed_before(message), do: Spiral.Cells.Domain.accept_passed_before(message)

  @spec rewrite(String.t(), String.t(), String.t(), String.t(), non_neg_integer()) :: {:ok, String.t()} | {:error, String.t()}
  def rewrite(text, name, expected, actual, passed_before \\ 0) do
    case Spiral.Cells.Domain.accept_rewrite(text, name, expected, actual, passed_before) do
      "K" <> rewritten -> {:ok, rewritten}
      "E" <> reason -> {:error, reason}
    end
  end

  @spec accept(String.t(), [{String.t(), String.t()}]) :: [{String.t(), :ok | {:error, String.t()}}]
  def accept(path, failures) do
    for {name, result} <- accept_sites(path, failures), do: {name, if(match?({:ok, _, _}, result), do: :ok, else: result)}
  end

  @spec accept_sites(String.t(), [{String.t(), String.t()}]) :: [{String.t(), {:ok, String.t(), String.t()} | {:error, String.t()}}]
  def accept_sites(path, failures) do
    FileLock.with_lock(path <> ".accept.lock", fn ->
      {text, results} =
        Enum.reduce(failures, {File.read!(path), []}, fn {name, message}, {text, results} ->
          with {:ok, actual, expected} <- mismatch(message),
               {:ok, rewritten} <- rewrite(text, name, expected, actual, passed_before(message)) do
            {before_line, after_line} = changed_line(text, rewritten)
            {rewritten, results ++ [{name, {:ok, before_line, after_line}}]}
          else
            :none -> {text, results ++ [{name, {:error, "no __assert_eq mismatch in its output"}}]}
            {:error, reason} -> {text, results ++ [{name, {:error, reason}}]}
          end
        end)

      if Enum.any?(results, &match?({_, {:ok, _, _}}, &1)), do: File.write!(path, text)
      results
    end)
  end

  defp changed_line(text, rewritten) do
    text
    |> String.split("\n")
    |> Enum.zip(String.split(rewritten, "\n"))
    |> Enum.find({"", ""}, fn {before_line, after_line} -> before_line != after_line end)
    |> then(fn {before_line, after_line} -> {String.trim(before_line), String.trim(after_line)} end)
  end
end
