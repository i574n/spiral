defmodule Spiral.Cells.Accept do
  alias Spiral.Cells.FileLock

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
         {:ok, shape} <- plain(actual),
         {:ok, index, at, length, suffix} <- failing_site(lines, first, last, expected, passed_before, shape) do
      line = Enum.at(lines, index)
      replaced = binary_part(line, 0, at) <> "_assert_eq " <> pinned(shape, actual, suffix) <> binary_part(line, at + length, byte_size(line) - at - length)
      {:ok, lines |> List.replace_at(index, replaced) |> Enum.join("\n")}
    end
  end

  defp pinned(:scalar, actual, suffix), do: actual <> suffix

  defp pinned({:tuple, values}, _actual, suffixes) do
    "(" <> (values |> Enum.zip(suffixes) |> Enum.map_join(", ", fn {value, suffix} -> value <> suffix end)) <> ")"
  end

  @tuple_text ~r/\A\((.*)\)\z/s
  @tuple_item ~r/"(?:[^"\\]|\\.)*"|[^,\s][^,]*/
  @suffixed_item ~r/\A(-?\d+(?:\.\d+)?(?:e-?\d+)?|"(?:[^"\\]|\\.)*"|true|false)((?:[iuf](?:8|16|32|64))?)\z/

  defp tuple_items(text) do
    with [_, inner] <- Regex.run(@tuple_text, text),
         items = @tuple_item |> Regex.scan(inner) |> Enum.map(fn [item] -> String.trim(item) end),
         true <- length(items) >= 2,
         parsed = Enum.map(items, &Regex.run(@suffixed_item, &1)),
         false <- Enum.any?(parsed, &is_nil/1) do
      {:ok, Enum.map(parsed, fn [_, value, suffix] -> {value, suffix} end)}
    else
      _ -> :none
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

  defp block(lines, name) do
    header = ~r/^(?:test|:#) #{Regex.escape(name)}[ =]/

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
    with false <- Regex.match?(@plain_value, actual),
         {:ok, items} <- tuple_items(actual),
         true <- Enum.all?(items, fn {_, suffix} -> suffix == "" end) do
      {:ok, {:tuple, Enum.map(items, &elem(&1, 0))}}
    else
      true -> {:ok, :scalar}
      _ -> not_plain(actual)
    end
  end

  defp not_plain("(" <> _ = actual), do: {:error, "the actual value #{actual} is not a flat tuple of plain literals (nested tuples print flattened, so they are pinned by hand)"}
  defp not_plain(actual), do: {:error, "the actual value #{actual} is not a plain literal"}

  @site_tuple ~r/\A_assert_eq\s+(\((?:[^()"]|"(?:[^"\\]|\\.)*")*\))/

  defp failing_site(lines, first, last, expected, passed_before, shape) do
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
        site_value(shape, rest, expected, passed_before, index, at)
    end
  end

  defp site_value(:scalar, rest, expected, passed_before, index, at) do
    case Regex.run(@site_literal, rest) do
      [whole, ^expected, suffix] -> {:ok, index, at, byte_size(whole), suffix}
      _ -> {:error, "the failing _assert_eq (number #{passed_before + 1} in the test body) is not the literal #{expected}"}
    end
  end

  defp site_value({:tuple, values}, rest, expected, passed_before, index, at) do
    with [whole, written] <- Regex.run(@site_tuple, rest),
         {:ok, site_items} <- tuple_items(written),
         {:ok, expected_items} <- tuple_items(expected),
         true <- length(site_items) == length(values) and Enum.map(site_items, &elem(&1, 0)) == Enum.map(expected_items, &elem(&1, 0)) do
      {:ok, index, at, byte_size(whole), Enum.map(site_items, &elem(&1, 1))}
    else
      _ -> {:error, "the failing _assert_eq (number #{passed_before + 1} in the test body) is not the tuple #{expected}"}
    end
  end
end
