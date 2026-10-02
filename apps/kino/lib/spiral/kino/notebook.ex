defmodule Spiral.Kino.Notebook do
  @meta ~s({"kernelInfo":{"defaultKernelName":"spiral","items":[{"name":"spiral"}]}})

  @type output ::
          {:stdout, String.t()}
          | {:stderr, String.t()}
          | {:value, String.t()}
          | {:html, String.t()}
          | {:data, map()}
          | {:error, %{name: String.t(), message: String.t(), details: String.t()}}

  @spec dib(String.t()) :: String.t()
  def dib(cell_source) do
    cell_source = String.replace(cell_source, "\r\n", "\n")

    if Enum.any?(String.split(cell_source, "\n"), &String.starts_with?(&1, "#!")) do
      raise ArgumentError,
            "Spiral cell code must not contain lines starting with \"#!\" " <>
              "(they would be read as a .dib cell separator)"
    end

    "#!meta\n\n" <> @meta <> "\n\n#!spiral\n\n" <> String.trim_trailing(cell_source) <> "\n"
  end

  @spec parse_ipynb(String.t()) :: {:ok, [output()]} | {:error, term()}
  def parse_ipynb(json) do
    with {:ok, %{"cells" => cells}} when is_list(cells) <- JSON.decode(json) do
      outputs =
        cells
        |> Enum.filter(&(&1["cell_type"] == "code"))
        |> List.last(%{})
        |> Map.get("outputs", [])
        |> Enum.flat_map(&parse_output/1)

      {:ok, drop_kernel_error_trace(outputs)}
    else
      {:ok, _other} -> {:error, :invalid_notebook}
      {:error, reason} -> {:error, {:invalid_json, reason}}
    end
  end

  defp parse_output(%{"output_type" => "stream"} = output) do
    name = if output["name"] == "stderr", do: :stderr, else: :stdout
    [{name, text(output["text"])}]
  end

  defp parse_output(%{"output_type" => "error"} = output) do
    details = to_string(output["evalue"])

    [
      {:error,
       %{
         name: to_string(output["ename"] || "Error"),
         message: clean_error(details),
         details: normalize_newlines(details)
       }}
    ]
  end

  defp parse_output(%{"output_type" => type, "data" => data})
       when type in ["display_data", "execute_result"] and is_map(data) do
    html = data["text/html"] && text(data["text/html"])
    plain = data["text/plain"] && text(data["text/plain"])

    cond do
      html && plaintext_value(html) -> [{:value, plaintext_value(html)}]
      plain -> [{:value, plain}]
      html -> [{:html, html}]
      true -> [{:data, data}]
    end
  end

  defp parse_output(_), do: []

  defp text(list) when is_list(list), do: list |> Enum.join() |> normalize_newlines()
  defp text(bin) when is_binary(bin), do: normalize_newlines(bin)
  defp text(_), do: ""

  defp normalize_newlines(text), do: String.replace(text, "\r\n", "\n")

  defp plaintext_value(html) do
    case Regex.run(~r{<div class="dni-plaintext"><pre>(.*?)</pre></div>}s, html) do
      [_, value] -> html_unescape(value)
      _ -> nil
    end
  end

  defp html_unescape(text) do
    text
    |> String.replace("&lt;", "<")
    |> String.replace("&gt;", ">")
    |> String.replace("&quot;", "\"")
    |> String.replace("&#39;", "'")
    |> String.replace("&#x27;", "'")
    |> String.replace("&amp;", "&")
  end

  @spec clean_error(String.t()) :: String.t()
  def clean_error(evalue) do
    evalue = normalize_newlines(evalue)

    concise =
      case Regex.run(~r/aggregateError:\s*(.*?)\s\/ ex:/s, evalue) do
        [_, message] -> message
        _ -> evalue
      end

    concise
    |> String.replace(
      ~r{[A-Za-z]:[/\\][^\s"']*?spiral_Eval[/\\]+packages[/\\]+[0-9a-f]+[/\\]+},
      ""
    )
    |> String.replace(~r{/[^\s"']*?spiral_Eval/+packages/+[0-9a-f]+/+}, "")
    |> String.replace(~r/^[ \t]*\(\d+,\d+\)-\(\d+,\d+\)[ \t]+/m, "")
    |> String.trim()
  end

  defp drop_kernel_error_trace(outputs) do
    if Enum.any?(outputs, &match?({:error, _}, &1)) do
      Enum.reject(outputs, fn
        {:stdout, text} -> kernel_error_trace?(text)
        _ -> false
      end)
    else
      outputs
    end
  end

  defp kernel_error_trace?(text) do
    text
    |> strip_ansi()
    |> String.match?(~r/\A\s*\d\d:\d\d:\d\d \S+ #\d+ Eval\.eval \/ error/)
  end

  def strip_ansi(text), do: String.replace(text, ~r/\e\[[0-9;]*[A-Za-z]/, "")
end
