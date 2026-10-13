defmodule Xsim.XCompat do
  alias Xsim.Frames

  @tlds_path Path.join([__DIR__, "..", "..", "priv", "tlds.txt"])
  @external_resource @tlds_path
  @tlds @tlds_path |> File.read!() |> String.split("\n", trim: true) |> MapSet.new()
  @shortened_url_weight 23
  @short_domains_x_links MapSet.new(["t.co"])

  @hashtag ~r/(?<![\p{L}\p{N}_&#＃])[#＃](?=[\p{L}\p{N}_]*\p{L})[\p{L}\p{N}_]+/u
  @mention ~r/(?<![\p{L}\p{N}_!#$%&*@＠])[@＠][A-Za-z0-9_]{1,15}(?![A-Za-z0-9_@＠])/u
  @cashtag ~r/(?<![\p{L}\p{N}_$])\$[A-Za-z]{1,6}(?:[._][A-Za-z]{1,2})?(?![\p{L}\p{N}_])/u
  @domain ~r/(?<![\p{L}\p{N}@\-_.\/])(?:[A-Za-z0-9](?:[A-Za-z0-9\-_]*[A-Za-z0-9])?\.)+([A-Za-z]{2,63})(?![\p{L}\p{N}_\-])/u

  def check(source, opts \\ []) do
    id = Keyword.get(opts, :id, "x")
    rewrites = source |> String.split("\n") |> Enum.with_index(1) |> Enum.flat_map(fn {line, row} -> line_rewrites(line, row) end)
    rewrites ++ over_limit(id, source)
  end

  def x_weight(text) do
    links = autolinks(text)
    plain = Enum.reduce(links, Frames.weight(text), fn {_, link}, total -> total - Frames.weight(link) end)
    plain + @shortened_url_weight * length(links)
  end

  def segments(text) do
    {pieces, rest_at} =
      text
      |> autolinks()
      |> Enum.reduce({[], 0}, fn {start, link}, {pieces, at} ->
        {[{:link, link}, {:text, binary_part(text, at, start - at)} | pieces], start + byte_size(link)}
      end)

    [{:text, binary_part(text, rest_at, byte_size(text) - rest_at)} | pieces]
    |> Enum.reverse()
    |> Enum.reject(&match?({:text, ""}, &1))
  end

  def shortened_url_weight, do: @shortened_url_weight

  def autolinks(text) do
    @domain
    |> Regex.scan(text, return: :index)
    |> Enum.flat_map(fn [{start, length}, {tld_start, tld_length}] ->
      link = binary_part(text, start, length)
      tld = text |> binary_part(tld_start, tld_length) |> String.downcase()
      if x_links?(link, tld), do: [{start, link}], else: []
    end)
  end

  defp x_links?(link, tld) do
    cond do
      not MapSet.member?(@tlds, tld) -> false
      MapSet.member?(@short_domains_x_links, String.downcase(link)) -> true
      String.length(tld) == 2 -> link |> String.split(".") |> Enum.at(-2) |> String.length() > 2
      true -> true
    end
  end

  defp line_rewrites(line, row) do
    marks =
      [hashtag: @hashtag, mention: @mention, cashtag: @cashtag]
      |> Enum.flat_map(fn {kind, regex} ->
        regex |> Regex.scan(line, return: :index) |> Enum.map(fn [{start, length}] -> {kind, start, binary_part(line, start, length)} end)
      end)

    links = line |> autolinks() |> Enum.map(fn {start, link} -> {:autolink, start, link} end)

    (marks ++ links)
    |> Enum.sort_by(&elem(&1, 1))
    |> Enum.map(fn {kind, start, text} ->
      %{kind: kind, line: row, column: column(line, start), text: text, hint: hint(kind)}
    end)
  end

  defp over_limit(id, source) do
    for {k, n, _} = frame <- Frames.split(id, source),
        weight = x_weight(Frames.frame_text(id, frame)),
        weight > 280 do
      %{kind: :over_limit, line: nil, column: nil, text: "post #{k}/#{n} weighs #{weight}", hint: "autolinks count #{@shortened_url_weight} each once posted"}
    end
  end

  defp column(line, byte_offset), do: (line |> binary_part(0, byte_offset) |> String.length()) + 1

  defp hint(:hashtag), do: "X turns '#' before a letter into a hashtag link"
  defp hint(:mention), do: "X turns '@' before a name into a mention"
  defp hint(:cashtag), do: "X turns '$' before letters into a cashtag link"
  defp hint(:autolink), do: "X shortens what looks like a domain to a #{@shortened_url_weight}-character t.co link"

  def format(path, finding) do
    location = if finding.line, do: "#{path}:#{finding.line}:#{finding.column}", else: path
    "#{location}: #{finding.kind}: #{finding.text} (#{finding.hint})"
  end
end
