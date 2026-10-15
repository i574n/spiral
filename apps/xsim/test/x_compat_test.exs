defmodule Xsim.XCompatTest do
  use ExUnit.Case, async: true
  alias Xsim.XCompat

  defp kinds(source), do: source |> XCompat.check() |> Enum.map(&{&1.kind, &1.text})

  test "spiral macros and operators pass" do
    assert kinds("inl f x = $\"{x}\" + $'##(!items)' : i32\ninl g = a.b.c |> h") == []
  end

  test "hashtags need a letter and no word before them" do
    assert kinds("inl x = #tag") == [hashtag: "#tag"]
    assert kinds("inl x = a#tag") == []
    assert kinds("inl x = #123") == []
    assert kinds("inl x = ##(1)") == []
  end

  test "mentions and cashtags" do
    assert kinds("send @alice now") == [mention: "@alice"]
    assert kinds("mail a@b.io") == []
    assert kinds("price $USD here") == [cashtag: "$USD"]
    assert kinds("price $USDollars") == []
  end

  test "autolinks follow x's domain rules" do
    assert kinds("inl r = cell.ai") == [autolink: "cell.ai"]
    assert kinds("inl r = x.io") == []
    assert kinds("see t.co") == [autolink: "t.co"]
    assert kinds("inl r = state.size") == []
    assert kinds("inl r = model.app") == [autolink: "model.app"]
    assert kinds("inl r = a/model.app") == []
  end

  test "findings carry line and column" do
    [finding] = XCompat.check("inl a = 1\ninl b = #tag")
    assert {finding.line, finding.column} == {2, 9}
  end

  test "autolinks weigh 23 once posted" do
    assert XCompat.x_weight("go cell.ai") == 3 + 23
    assert XCompat.x_weight("go x.io") == 7
  end

  test "threads are split by x weight, so autolinks never push a post over the limit" do
    source = String.duplicate("cell.app ", 40)
    refute Enum.any?(XCompat.check(source), &(&1.kind == :over_limit))
    frames = Xsim.Frames.split("x", source)
    assert Xsim.Frames.rebuild(frames) == source
    assert Enum.all?(frames, &(XCompat.x_weight(Xsim.Frames.frame_text("x", &1)) <= 280))
  end

  test "threads of 100 or more posts stay within the limit and cut between words" do
    source = String.duplicate("inl state_mapping = listm.mapping value\n", 900)
    frames = Xsim.Frames.split("main.spi", source)
    assert length(frames) >= 100
    assert Xsim.Frames.rebuild(frames) == source
    refute Enum.any?(XCompat.check(source, id: "main.spi"), &(&1.kind == :over_limit))
    assert Enum.all?(frames, fn {_, _, body} -> body |> String.last() |> String.trim() == "" end)
  end

  test "segments keep autolinks whole" do
    assert XCompat.segments("a cell.ai b") == [text: "a ", link: "cell.ai", text: " b"]
  end
end
