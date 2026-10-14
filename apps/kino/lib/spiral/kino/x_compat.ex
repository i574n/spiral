defmodule Spiral.Kino.XCompat do
  @tlds_path Path.join([__DIR__, "..", "..", "..", "priv", "tlds.txt"])
  @external_resource @tlds_path
  @tlds @tlds_path |> File.read!() |> String.split("\n", trim: true) |> MapSet.new()
  @shortened_url_weight 23
  @short_domains_x_links MapSet.new(["t.co"])
  @light_code_points [{0, 4351}, {8192, 8205}, {8208, 8223}, {8242, 8247}]

  @hashtag ~r/(?<![\p{L}\p{N}_&#＃])[#＃](?=[\p{L}\p{N}_]*\p{L})[\p{L}\p{N}_]+/u
  @mention ~r/(?<![\p{L}\p{N}_!#$%&*@＠])[@＠][A-Za-z0-9_]{1,15}(?![A-Za-z0-9_@＠])/u
  @cashtag ~r/(?<![\p{L}\p{N}_$])\$[A-Za-z]{1,6}(?:[._][A-Za-z]{1,2})?(?![\p{L}\p{N}_])/u
  @domain ~r/(?<![\p{L}\p{N}@\-_.\/])(?:[A-Za-z0-9](?:[A-Za-z0-9\-_]*[A-Za-z0-9])?\.)+([A-Za-z]{2,63})(?![\p{L}\p{N}_\-])/u

  @type finding :: %{kind: atom(), line: pos_integer() | nil, column: pos_integer() | nil, text: String.t(), hint: String.t()}

  @spec rewrites(String.t()) :: [finding()]
  def rewrites(source) do
    source
    |> String.replace("\r\n", "\n")
    |> String.split("\n")
    |> Enum.with_index(1)
    |> Enum.flat_map(fn {line, row} -> line_rewrites(line, row) end)
  end

  @spec weight(String.t()) :: non_neg_integer()
  def weight(text), do: text |> String.to_charlist() |> Enum.reduce(0, &(&2 + code_point_weight(&1)))

  defp code_point_weight(cp), do: if(Enum.any?(@light_code_points, fn {lo, hi} -> cp >= lo and cp <= hi end), do: 1, else: 2)

  @spec x_weight(String.t()) :: non_neg_integer()
  def x_weight(text) do
    links = autolinks(text)
    plain = Enum.reduce(links, weight(text), fn {_, link}, total -> total - weight(link) end)
    plain + @shortened_url_weight * length(links)
  end

  @spec segments(String.t()) :: [{:text | :link, String.t()}]
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

  @spec shortened_url_weight() :: pos_integer()
  def shortened_url_weight, do: @shortened_url_weight

  @spec autolinks(String.t()) :: [{non_neg_integer(), String.t()}]
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

  defp column(line, byte_offset), do: (line |> binary_part(0, byte_offset) |> String.length()) + 1

  @spec hint(atom()) :: String.t()
  def hint(:hashtag), do: "X turns '#' before a letter into a hashtag link"
  def hint(:mention), do: "X turns '@' before a name into a mention"
  def hint(:cashtag), do: "X turns '$' before letters into a cashtag link"
  def hint(:autolink), do: "X shortens what looks like a domain to a #{@shortened_url_weight}-character t.co link"

  @spec format(String.t(), finding()) :: String.t()
  def format(path, finding) do
    location = if finding.line, do: "#{path}:#{finding.line}:#{finding.column}", else: path
    "#{location}: #{finding.kind}: #{finding.text} (#{finding.hint})"
  end

  @spec edition3?(String.t()) :: boolean()
  def edition3?(path) do
    case nearest_project(path |> Path.expand() |> Path.dirname()) do
      nil -> false
      project -> project |> File.read!() |> String.split(~r/\r?\n/) |> Enum.any?(&(String.trim(&1) == "edition: 3"))
    end
  end

  defp nearest_project(dir) do
    project = Path.join(dir, "package.spiproj")

    cond do
      File.regular?(project) -> project
      Path.dirname(dir) == dir -> nil
      true -> nearest_project(Path.dirname(dir))
    end
  end
end
