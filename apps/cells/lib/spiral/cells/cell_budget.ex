defmodule Spiral.Cells.CellBudget do
  @tlds_path Path.join([__DIR__, "..", "..", "..", "data", "tlds.txt"])
  @external_resource @tlds_path
  @tlds @tlds_path |> File.read!() |> String.split("\n", trim: true) |> MapSet.new()

  defmodule Profile do
    @weight_limit 280
    defstruct name: "default",
              weight_limit: @weight_limit,
              header: "c{block} 1/1",
              header_separator: "\n",
              defused_extra_weight: 1,
              link_weight: 23,
              default_weight: 2,
              ranges: [{0, 4351, 1}, {8192, 8205, 1}, {8208, 8223, 1}, {8242, 8247, 1}],
              tlds: MapSet.new(),
              short_domains: MapSet.new(["t.co"]),
              two_letter_second_label_over: 2,
              hashtag: nil,
              mention: nil,
              cashtag: nil,
              domain: nil,
              defused_before: nil,
              defused_after: nil
  end

  @hashtag_source "(?<![\\p{L}\\p{N}_&#＃])[#＃](?=[\\p{L}\\p{N}_]*\\p{L})[\\p{L}\\p{N}_]+"
  @mention_source "(?<![\\p{L}\\p{N}_!#$%&*@＠])[@＠][A-Za-z0-9_]{1,15}(?![A-Za-z0-9_@＠])"
  @cashtag_source "(?<![\\p{L}\\p{N}_$])\\$[A-Za-z]{1,6}(?:[._][A-Za-z]{1,2})?(?![\\p{L}\\p{N}_])"
  @domain_source "(?<![\\p{L}\\p{N}@\\-_./])(?:[A-Za-z0-9](?:[A-Za-z0-9\\-_]*[A-Za-z0-9])?\\.)+([A-Za-z]{2,63})(?![\\p{L}\\p{N}_\\-])"

  @type finding :: %{kind: atom(), line: pos_integer() | nil, column: pos_integer() | nil, text: String.t(), hint: String.t()}

  @spec default_profile() :: %Profile{}
  def default_profile do
    case :persistent_term.get({__MODULE__, :default_profile}, nil) do
      nil ->
        profile = %Profile{
          tlds: @tlds,
          hashtag: Regex.compile!(@hashtag_source, "u"),
          mention: Regex.compile!(@mention_source, "u"),
          cashtag: Regex.compile!(@cashtag_source, "u"),
          domain: Regex.compile!(@domain_source, "u")
        }

        :persistent_term.put({__MODULE__, :default_profile}, profile)
        profile

      profile ->
        profile
    end
  end

  @spec profile_for(String.t()) :: %Profile{}
  def profile_for(path) do
    case System.get_env("SPIRAL_POSTABILITY_PROFILE") || nearest_profile(path |> Path.expand() |> Path.dirname()) do
      nil -> default_profile()
      file -> cached_profile(Path.expand(file))
    end
  end

  defp nearest_profile(dir) do
    found = dir |> Path.join("postability/*.json") |> Path.wildcard() |> Enum.sort() |> List.first()

    cond do
      found -> found
      Path.dirname(dir) == dir -> nil
      true -> nearest_profile(Path.dirname(dir))
    end
  end

  defp cached_profile(file) do
    stamp = File.stat!(file).mtime
    key = {__MODULE__, :profile, file}

    case :persistent_term.get(key, nil) do
      {^stamp, profile} ->
        profile

      _ ->
        profile = load_profile(file)
        :persistent_term.put(key, {stamp, profile})
        profile
    end
  end

  @spec load_profile(String.t()) :: %Profile{}
  def load_profile(file) do
    json = file |> File.read!() |> JSON.decode!()
    links = json["links"]
    entities = json["entities"]
    weights = json["code_point_weight"]
    tlds = file |> Path.dirname() |> Path.join(links["top_level_domains_file"]) |> File.read!() |> String.split(~r/\r?\n/, trim: true) |> MapSet.new()

    %Profile{
      name: json["profile"],
      link_weight: json["post"]["link_weight"],
      weight_limit: get_in(json, ["post", "weight_limit"]) || %Profile{}.weight_limit,
      header: get_in(json, ["posting", "budget_header_for_one_post"]) || "c{block} 1/1",
      header_separator: get_in(json, ["posting", "header_separator"]) || "\n",
      defused_extra_weight: get_in(json, ["posting", "defused_dot", "extra_weight"]) || 1,
      default_weight: weights["default"],
      ranges: Enum.map(weights["ranges"], fn [lo, hi, weight] -> {lo, hi, weight} end),
      tlds: tlds,
      short_domains: links["short_domains_always_linked"] |> Enum.map(&String.downcase/1) |> MapSet.new(),
      two_letter_second_label_over: links["two_letter_tld_needs_second_label_longer_than"],
      hashtag: Regex.compile!(entities["hashtag"], "u"),
      mention: Regex.compile!(entities["mention"], "u"),
      cashtag: Regex.compile!(entities["cashtag"], "u"),
      domain: Regex.compile!(links["domain_pattern"], "u"),
      defused_before: defused_regex(json, "before"),
      defused_after: defused_regex(json, "after")
    }
  end

  defp defused_regex(json, side) do
    case get_in(json, ["posting", "defused_dot", side]) do
      nil -> nil
      source -> Regex.compile!("^" <> source <> "$", "u")
    end
  end

  @spec rewrites(String.t(), %Profile{}) :: [finding()]
  def rewrites(source, profile \\ default_profile()) do
    source
    |> String.replace("\r\n", "\n")
    |> String.split("\n")
    |> Enum.with_index(1)
    |> Enum.flat_map(fn {line, row} -> line_rewrites(line, row, profile) end)
  end

  @spec weight(String.t(), %Profile{}) :: non_neg_integer()
  def weight(text, profile \\ default_profile()), do: text |> String.to_charlist() |> Enum.reduce(0, &(&2 + code_point_weight(&1, profile)))

  defp code_point_weight(cp, profile) do
    Enum.find_value(profile.ranges, profile.default_weight, fn {lo, hi, weight} -> if cp >= lo and cp <= hi, do: weight end)
  end

  @spec cell_weight(String.t(), %Profile{}) :: non_neg_integer()
  def cell_weight(text, profile \\ default_profile()) do
    links = autolinks(text, profile)
    plain = Enum.reduce(links, weight(text, profile), fn {_, link}, total -> total - weight(link, profile) end)
    plain + profile.link_weight * length(links)
  end

  @spec over_budget(String.t(), %Profile{}) :: [finding()]
  def over_budget(source, profile \\ default_profile()) do
    source
    |> top_level_blocks()
    |> Enum.with_index(1)
    |> Enum.flat_map(fn {{row, block}, cell} ->
      weight = cell_weight(block, profile)
      limit = postable_limit(block, cell, profile)
      if weight > limit, do: [%{kind: :over_budget, line: row, column: 1, text: "weight #{weight} > #{limit}", hint: hint(:over_budget, profile)}], else: []
    end)
  end

  defp postable_limit(block, cell, profile) do
    header = String.replace(profile.header, "{block}", Integer.to_string(cell)) <> profile.header_separator
    profile.weight_limit - cell_weight(header, profile) - profile.defused_extra_weight * defused_dots(block, profile)
  end

  defp defused_dots(_block, %Profile{defused_before: nil}), do: 0
  defp defused_dots(block, profile), do: block |> :binary.matches(".") |> Enum.count(fn {at, 1} -> defused_dot?(block, at, profile) end)

  @spec top_level_blocks(String.t()) :: [{pos_integer(), String.t()}]
  def top_level_blocks(source) do
    lines = source |> String.replace("\r\n", "\n") |> String.split("\n")
    lines = if List.last(lines) == "", do: Enum.drop(lines, -1), else: lines

    {blocks, current, start, _blanks, _seen} =
      lines
      |> Enum.with_index(1)
      |> Enum.reduce({[], [], 1, 0, false}, fn {line, row}, {blocks, current, start, blanks, seen} ->
        cond do
          line == "" -> {blocks, current, start, blanks + 1, seen}
          blanks > 0 and seen and not String.starts_with?(line, [" ", "\t"]) -> {finish_block(blocks, current, start), [line | List.duplicate("", blanks - 1)], row, 0, true}
          true -> {blocks, [line | List.duplicate("", blanks) ++ current], if(seen, do: start, else: row), 0, true}
        end
      end)

    blocks |> finish_block(current, start) |> Enum.reverse()
  end

  defp finish_block(blocks, [], _start), do: blocks
  defp finish_block(blocks, current, start), do: [{start, current |> Enum.reverse() |> Enum.join("\n") |> String.trim_trailing()} | blocks]

  @spec segments(String.t(), %Profile{}) :: [{:text | :link, String.t()}]
  def segments(text, profile \\ default_profile()) do
    {pieces, rest_at} =
      text
      |> autolinks(profile)
      |> Enum.reduce({[], 0}, fn {start, link}, {pieces, at} ->
        {[{:link, link}, {:text, binary_part(text, at, start - at)} | pieces], start + byte_size(link)}
      end)

    [{:text, binary_part(text, rest_at, byte_size(text) - rest_at)} | pieces]
    |> Enum.reverse()
    |> Enum.reject(&match?({:text, ""}, &1))
  end

  @spec link_weight(%Profile{}) :: pos_integer()
  def link_weight(profile \\ default_profile()), do: profile.link_weight

  @spec autolinks(String.t(), %Profile{}) :: [{non_neg_integer(), String.t()}]
  def autolinks(text, profile \\ default_profile()) do
    profile.domain
    |> Regex.scan(text, return: :index)
    |> Enum.flat_map(fn [{start, length}, {tld_start, tld_length}] ->
      link = binary_part(text, start, length)
      tld = text |> binary_part(tld_start, tld_length) |> String.downcase()
      if links?(link, tld, profile) and not defused_link?(text, start, length, profile), do: [{start, link}], else: []
    end)
  end

  defp defused_link?(_text, _start, _length, %Profile{defused_before: nil}), do: false

  defp defused_link?(text, start, length, profile) do
    text
    |> binary_part(start, length)
    |> :binary.matches(".")
    |> Enum.all?(fn {dot, 1} -> defused_dot?(text, start + dot, profile) end)
  end

  defp defused_dot?(text, at, profile) do
    at > 0 and at + 1 < byte_size(text) and Regex.match?(profile.defused_before, text |> binary_part(0, at) |> String.last()) and
      Regex.match?(profile.defused_after, text |> binary_part(at + 1, byte_size(text) - at - 1) |> String.first())
  end

  defp links?(link, tld, profile) do
    cond do
      not MapSet.member?(profile.tlds, tld) -> false
      MapSet.member?(profile.short_domains, String.downcase(link)) -> true
      String.length(tld) == 2 -> link |> String.split(".") |> Enum.at(-2) |> String.length() > profile.two_letter_second_label_over
      true -> true
    end
  end

  defp line_rewrites(line, row, profile) do
    marks =
      [hashtag: profile.hashtag, mention: profile.mention, cashtag: profile.cashtag]
      |> Enum.flat_map(fn {kind, regex} ->
        regex |> Regex.scan(line, return: :index) |> Enum.map(fn [{start, length}] -> {kind, start, binary_part(line, start, length)} end)
      end)

    links = line |> autolinks(profile) |> Enum.map(fn {start, link} -> {:autolink, start, link} end)

    (marks ++ links)
    |> Enum.sort_by(&elem(&1, 1))
    |> Enum.map(fn {kind, start, text} ->
      %{kind: kind, line: row, column: column(line, start), text: text, hint: hint(kind, profile)}
    end)
  end

  defp column(line, byte_offset), do: (line |> binary_part(0, byte_offset) |> String.length()) + 1

  @spec hint(atom(), %Profile{}) :: String.t()
  def hint(kind, profile \\ default_profile())
  def hint(:hashtag, _profile), do: "a renderer turns '#' before a letter into a hashtag link"
  def hint(:mention, _profile), do: "a renderer turns '@' before a name into a mention"
  def hint(:cashtag, _profile), do: "a renderer turns '$' before letters into a cashtag link"
  def hint(:autolink, profile), do: "a renderer shortens what looks like a domain to a #{profile.link_weight}-character link"

  def hint(:over_budget, profile),
    do: "a cell holds #{profile.weight_limit} weighted characters (CJK and emoji weigh 2, links #{profile.link_weight}), less the cell header; split this definition"

  @spec format(String.t(), finding()) :: String.t()
  def format(path, finding) do
    location = if finding.line, do: "#{path}:#{finding.line}:#{finding.column}", else: path
    "#{location}: #{finding.kind}: #{finding.text} (#{finding.hint})"
  end

  @spec edition3?(String.t()) :: boolean()
  def edition3?(path) do
    case nearest_project(path |> Path.expand() |> Path.dirname()) do
      nil -> false
      dir -> dir |> Spiral.Cells.Manifest.read!() |> String.split(~r/\r?\n/) |> Enum.any?(&(String.trim(&1) == "edition: 3"))
    end
  end

  defp nearest_project(dir) do
    cond do
      Spiral.Cells.Manifest.exists?(dir) -> dir
      Path.dirname(dir) == dir -> nil
      true -> nearest_project(Path.dirname(dir))
    end
  end
end
