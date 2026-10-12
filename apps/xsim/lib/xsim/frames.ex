defmodule Xsim.Frames do
  @limit 280
  @light [{0, 4351}, {8192, 8205}, {8208, 8223}, {8242, 8247}]

  def weight(text), do: text |> String.to_charlist() |> Enum.reduce(0, &(&2 + code_point_weight(&1)))

  defp code_point_weight(cp), do: if(Enum.any?(@light, fn {lo, hi} -> cp >= lo and cp <= hi end), do: 1, else: 2)

  def header(id, k, n), do: "#{id} #{k}/#{n}\n"

  def split(id, source, limit \\ @limit) do
    text = :unicode.characters_to_nfc_binary(source)
    budget = limit - weight(header(id, 99, 99))
    chunks = chunk(String.graphemes(text), budget, [], 0, [])
    n = length(chunks)
    chunks |> Enum.with_index(1) |> Enum.map(fn {body, k} -> {k, n, body} end)
  end

  defp chunk([], _budget, current, _used, acc), do: Enum.reverse(flush(current, acc))

  defp chunk([g | rest], budget, current, used, acc) do
    w = weight(g)

    if used + w > budget and current != [] do
      chunk([g | rest], budget, [], 0, flush(current, acc))
    else
      chunk(rest, budget, [g | current], used + w, acc)
    end
  end

  defp flush([], acc), do: acc
  defp flush(current, acc), do: [current |> Enum.reverse() |> Enum.join() | acc]

  def frame_text(id, {k, n, body}), do: header(id, k, n) <> body

  def rebuild(frames), do: frames |> Enum.sort_by(&elem(&1, 0)) |> Enum.map_join(&elem(&1, 2))

  def explode_posts(events, limit \\ @limit) do
    Enum.flat_map(events, fn
      {:post, id, parent, source} -> for {k, n, body} <- split(id, source, limit), do: {:frame, id, parent, k, n, body}
      other -> [other]
    end)
  end
end
