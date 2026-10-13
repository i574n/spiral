defmodule Spiral.Kino.Accept do
  alias Spiral.Kino.FileLock

  @mismatch ~r/__assert_eq \{ actual = (.*?); expected = (.*?) \}/
  @literal ~r/_assert_eq\s+(-?\d+(?:\.\d+)?(?:e-?\d+)?|"(?:[^"\\]|\\.)*"|true|false)((?:[iuf](?:8|16|32|64))?)\b/
  @plain_value ~r/\A(-?\d+(?:\.\d+)?(?:e-?\d+)?|"(?:[^"\\]|\\.)*"|true|false)\z/

  @spec mismatch(String.t()) :: {:ok, String.t(), String.t()} | :none
  def mismatch(message) do
    case Regex.run(@mismatch, message) do
      [_, actual, expected] -> {:ok, String.trim(actual), String.trim(expected)}
      _ -> :none
    end
  end

  @spec rewrite(String.t(), String.t(), String.t(), String.t()) :: {:ok, String.t()} | {:error, String.t()}
  def rewrite(text, name, expected, actual) do
    lines = String.split(text, "\n")

    with {:ok, first, last} <- block(lines, name),
         :ok <- plain(actual),
         {:ok, index, line} <- only_match(lines, first, last, expected) do
      replaced = Regex.replace(@literal, line, &swap(&1, &2, &3, expected, actual))
      {:ok, lines |> List.replace_at(index, replaced) |> Enum.join("\n")}
    end
  end

  @spec accept(String.t(), [{String.t(), String.t()}]) :: [{String.t(), :ok | {:error, String.t()}}]
  def accept(path, failures) do
    FileLock.with_lock(path <> ".accept.lock", fn ->
      {text, results} =
        Enum.reduce(failures, {File.read!(path), []}, fn {name, message}, {text, results} ->
          with {:ok, actual, expected} <- mismatch(message),
               {:ok, rewritten} <- rewrite(text, name, expected, actual) do
            {rewritten, results ++ [{name, :ok}]}
          else
            :none -> {text, results ++ [{name, {:error, "no __assert_eq mismatch in its output"}}]}
            {:error, reason} -> {text, results ++ [{name, {:error, reason}}]}
          end
        end)

      if Enum.any?(results, &(elem(&1, 1) == :ok)), do: File.write!(path, text)
      results
    end)
  end

  defp block(lines, name) do
    header = ~r/^test #{Regex.escape(name)}[ =]/

    case Enum.find_index(lines, &Regex.match?(header, &1)) do
      nil ->
        {:error, "no test block named #{name}"}

      first ->
        last =
          lines
          |> Enum.drop(first + 1)
          |> Enum.take_while(&(&1 == "" or String.starts_with?(&1, [" ", "\t"])))
          |> length()

        {:ok, first + 1, first + last}
    end
  end

  defp plain(actual) do
    if Regex.match?(@plain_value, actual), do: :ok, else: {:error, "the actual value #{actual} is not a plain literal"}
  end

  defp only_match(lines, first, last, expected) do
    hits =
      for index <- first..last//1,
          line = Enum.at(lines, index),
          Enum.any?(Regex.scan(@literal, line), fn [_, value, _suffix] -> value == expected end),
          do: {index, line}

    case hits do
      [{index, line}] -> {:ok, index, line}
      [] -> {:error, "no _assert_eq #{expected} literal in the test body"}
      _ -> {:error, "several _assert_eq #{expected} literals in the test body"}
    end
  end

  defp swap(whole, value, suffix, expected, actual) do
    if value == expected, do: String.replace(whole, value <> suffix, actual <> suffix), else: whole
  end
end
