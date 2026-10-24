defmodule Spiral.Cells.XCompat do
  @tlds_path Path.join([__DIR__, "..", "..", "..", "priv", "tlds.txt"])
  @external_resource @tlds_path
  @tlds @tlds_path |> File.read!() |> String.split("\n", trim: true) |> MapSet.new()

  defmodule Profile do
    defstruct name: "x",
              link_weight: 23,
              default_weight: 2,
              ranges: [{0, 4351, 1}, {8192, 8205, 1}, {8208, 8223, 1}, {8242, 8247, 1}],
              tlds: MapSet.new(),
              short_domains: MapSet.new(["t.co"]),
              two_letter_second_label_over: 2,
              hashtag: nil,
              mention: nil,
              cashtag: nil,
              domain: nil
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
      default_weight: weights["default"],
      ranges: Enum.map(weights["ranges"], fn [lo, hi, weight] -> {lo, hi, weight} end),
      tlds: tlds,
      short_domains: links["short_domains_always_linked"] |> Enum.map(&String.downcase/1) |> MapSet.new(),
      two_letter_second_label_over: links["two_letter_tld_needs_second_label_longer_than"],
      hashtag: Regex.compile!(entities["hashtag"], "u"),
      mention: Regex.compile!(entities["mention"], "u"),
      cashtag: Regex.compile!(entities["cashtag"], "u"),
      domain: Regex.compile!(links["domain_pattern"], "u")
    }
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

  @spec x_weight(String.t(), %Profile{}) :: non_neg_integer()
  def x_weight(text, profile \\ default_profile()) do
    links = autolinks(text, profile)
    plain = Enum.reduce(links, weight(text, profile), fn {_, link}, total -> total - weight(link, profile) end)
    plain + profile.link_weight * length(links)
  end

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

  @spec shortened_url_weight(%Profile{}) :: pos_integer()
  def shortened_url_weight(profile \\ default_profile()), do: profile.link_weight

  @spec autolinks(String.t(), %Profile{}) :: [{non_neg_integer(), String.t()}]
  def autolinks(text, profile \\ default_profile()) do
    profile.domain
    |> Regex.scan(text, return: :index)
    |> Enum.flat_map(fn [{start, length}, {tld_start, tld_length}] ->
      link = binary_part(text, start, length)
      tld = text |> binary_part(tld_start, tld_length) |> String.downcase()
      if x_links?(link, tld, profile), do: [{start, link}], else: []
    end)
  end

  defp x_links?(link, tld, profile) do
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
  def hint(:hashtag, _profile), do: "X turns '#' before a letter into a hashtag link"
  def hint(:mention, _profile), do: "X turns '@' before a name into a mention"
  def hint(:cashtag, _profile), do: "X turns '$' before letters into a cashtag link"
  def hint(:autolink, profile), do: "X shortens what looks like a domain to a #{profile.link_weight}-character t.co link"

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
