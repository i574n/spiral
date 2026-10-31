defmodule Spiral.Cells.PostabilityProfileTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.XCompat

  @x_profile Path.expand("../../fixtures/postability/x.json", __DIR__)
  @sample "inl a = 1\ninl b = x.io + #tag @someone $abc cell.ai posts.post 가나 t.co map.to\n"

  defp seen(profile), do: {Enum.map(XCompat.rewrites(@sample, profile), &{&1.kind, &1.line, &1.column, &1.text}), XCompat.x_weight(@sample, profile)}

  defp profile_dir(edit) do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("postability_profile")
    profiles = Path.join(dir, "postability")
    File.mkdir_p!(profiles)
    File.cp!(Path.join(Path.dirname(@x_profile), "tlds.txt"), Path.join(profiles, "tlds.txt"))
    json = @x_profile |> File.read!() |> JSON.decode!() |> edit.()
    File.write!(Path.join(profiles, "x.json"), JSON.encode!(json))
    nested = Path.join(dir, "deep/er")
    File.mkdir_p!(nested)
    Path.join(nested, "post.spi")
  end

  defp without_poster(json), do: Map.delete(json, "posting")

  test "x's own profile without its poster's dot defusing behaves exactly like the built-in default" do
    assert seen(XCompat.profile_for(profile_dir(&without_poster/1))) == seen(XCompat.default_profile())
  end

  test "x's own profile drops exactly the autolinks its poster defuses" do
    {findings, _} = x = seen(XCompat.load_profile(@x_profile))
    {default_findings, _} = seen(XCompat.default_profile())
    assert findings == Enum.reject(default_findings, fn {kind, _, _, _} -> kind == :autolink end)
    assert seen(XCompat.profile_for(Path.join(Path.dirname(Path.dirname(@x_profile)), "apps/client/posts.spi"))) == x
  end

  test "the nearest postability profile above a file decides its findings and weights" do
    path = profile_dir(fn json -> json |> without_poster() |> put_in(["post", "link_weight"], 50) end)
    {findings, weight} = seen(XCompat.profile_for(path))
    {default_findings, default_weight} = seen(XCompat.default_profile())
    assert findings == default_findings
    links = Enum.count(default_findings, fn {kind, _, _, _} -> kind == :autolink end)
    assert links > 0
    assert weight == default_weight + links * (50 - 23)
  end

  test "a file with no postability folder above it gets the default profile" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("postability_none")
    assert seen(XCompat.profile_for(Path.join(dir, "post.spi"))) == seen(XCompat.default_profile())
  end
end
