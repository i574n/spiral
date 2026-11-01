defmodule Spiral.Cells.CellBudgetProfileTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.CellBudget

  @sample "inl a = 1\ninl b = x.io + #tag @someone $abc cell.ai posts.post 가나 t.co map.to\n"
  @tlds Path.expand("../../../data/tlds.txt", __DIR__)

  defp seen(profile), do: {Enum.map(CellBudget.rewrites(@sample, profile), &{&1.kind, &1.line, &1.column, &1.text}), CellBudget.cell_weight(@sample, profile)}

  defp default_json(edit) do
    d = CellBudget.default_profile()

    %{
      "profile" => d.name,
      "post" => %{"link_weight" => d.link_weight},
      "code_point_weight" => %{"default" => d.default_weight, "ranges" => Enum.map(d.ranges, &Tuple.to_list/1)},
      "links" => %{
        "top_level_domains_file" => "tlds.txt",
        "short_domains_always_linked" => MapSet.to_list(d.short_domains),
        "two_letter_tld_needs_second_label_longer_than" => d.two_letter_second_label_over,
        "domain_pattern" => Regex.source(d.domain)
      },
      "entities" => %{"hashtag" => Regex.source(d.hashtag), "mention" => Regex.source(d.mention), "cashtag" => Regex.source(d.cashtag)},
      "posting" => %{"defused_dot" => %{"before" => "[A-Za-z0-9_-]", "after" => "[A-Za-z]"}}
    }
    |> edit.()
  end

  defp profile_dir(edit) do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("postability_profile")
    profiles = Path.join(dir, "postability")
    File.mkdir_p!(profiles)
    File.cp!(@tlds, Path.join(profiles, "tlds.txt"))
    File.write!(Path.join(profiles, "x.json"), JSON.encode!(default_json(edit)))
    nested = Path.join(dir, "deep/er")
    File.mkdir_p!(nested)
    Path.join(nested, "post.spi")
  end

  test "x's poster profile without its dot defusing behaves exactly like the built-in default" do
    assert seen(CellBudget.profile_for(profile_dir(&Map.delete(&1, "posting")))) == seen(CellBudget.default_profile())
  end

  test "x's poster profile drops exactly the autolinks its poster defuses" do
    {findings, _} = seen(CellBudget.profile_for(profile_dir(& &1)))
    {default_findings, _} = seen(CellBudget.default_profile())
    assert findings == Enum.reject(default_findings, fn {kind, _, _, _} -> kind == :autolink end)
  end

  test "the nearest postability profile above a file decides its findings and weights" do
    path = profile_dir(fn json -> json |> Map.delete("posting") |> put_in(["post", "link_weight"], 50) end)
    {findings, weight} = seen(CellBudget.profile_for(path))
    {default_findings, default_weight} = seen(CellBudget.default_profile())
    assert findings == default_findings
    links = Enum.count(default_findings, fn {kind, _, _, _} -> kind == :autolink end)
    assert links > 0
    assert weight == default_weight + links * (50 - 23)
  end

  test "a file with no postability folder above it gets the default profile" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("postability_none")
    assert seen(CellBudget.profile_for(Path.join(dir, "post.spi"))) == seen(CellBudget.default_profile())
  end
end