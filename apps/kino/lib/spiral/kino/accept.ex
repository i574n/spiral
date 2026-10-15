defmodule Spiral.Kino.Accept do
  alias Spiral.Kino.FileLock

  @mismatch ~r/__assert_eq \{ actual = (.*?); expected = (.*?) \}/
  @plain_value ~r/\A(-?\d+(?:\.\d+)?(?:e-?\d+)?|"(?:[^"\\]|\\.)*"|true|false)\z/

  @spec mismatch(String.t()) :: {:ok, String.t(), String.t()} | :none
  def mismatch(message) do
    case Regex.run(@mismatch, message) do
      [_, actual, expected] -> {:ok, String.trim(actual), String.trim(expected)}
      _ -> :none
    end
  end

  @passed ~r/\A__assert_eq \{ expected = .* \}\z/
  @site ~r/(?<![\w'])_assert_eq(?![\w'])/
  @site_literal ~r/\A_assert_eq\s+(-?\d+(?:\.\d+)?(?:e-?\d+)?|"(?:[^"\\]|\\.)*"|true|false)((?:[iuf](?:8|16|32|64))?)\b/

  @spec passed_before(String.t()) :: non_neg_integer()
  def passed_before(message) do
    message |> String.split("\n") |> Enum.count(&Regex.match?(@passed, String.trim(&1)))
  end

  @spec rewrite(String.t(), String.t(), String.t(), String.t(), non_neg_integer()) :: {:ok, String.t()} | {:error, String.t()}
  def rewrite(text, name, expected, actual, passed_before \\ 0) do
    lines = String.split(text, "\n")

    with {:ok, first, last} <- block(lines, name),
         :ok <- plain(actual),
         {:ok, index, at, length, suffix} <- failing_site(lines, first, last, expected, passed_before) do
      line = Enum.at(lines, index)
      replaced = binary_part(line, 0, at) <> "_assert_eq " <> actual <> suffix <> binary_part(line, at + length, byte_size(line) - at - length)
      {:ok, lines |> List.replace_at(index, replaced) |> Enum.join("\n")}
    end
  end

  @spec accept(String.t(), [{String.t(), String.t()}]) :: [{String.t(), :ok | {:error, String.t()}}]
  def accept(path, failures) do
    FileLock.with_lock(path <> ".accept.lock", fn ->
      {text, results} =
        Enum.reduce(failures, {File.read!(path), []}, fn {name, message}, {text, results} ->
          with {:ok, actual, expected} <- mismatch(message),
               {:ok, rewritten} <- rewrite(text, name, expected, actual, passed_before(message)) do
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

  defp failing_site(lines, first, last, expected, passed_before) do
    sites =
      for index <- first..last//1,
          line = Enum.at(lines, index),
          [{at, _}] <- Regex.scan(@site, line, return: :index),
          do: {index, at}

    case Enum.at(sites, passed_before) do
      nil ->
        {:error, "the failing _assert_eq is number #{passed_before + 1} but the test body writes #{length(sites)}; it ran more often than it is written (a loop or helper), so its literal is ambiguous"}

      {index, at} ->
        line = Enum.at(lines, index)
        rest = binary_part(line, at, byte_size(line) - at)

        case Regex.run(@site_literal, rest) do
          [whole, ^expected, suffix] -> {:ok, index, at, byte_size(whole), suffix}
          _ -> {:error, "the failing _assert_eq (number #{passed_before + 1} in the test body) is not the literal #{expected}"}
        end
    end
  end
end
