defmodule Spiral.Kino.BuildersTest do
  use ExUnit.Case, async: true

  alias Spiral.Kino.Builders

  test "short clusters and dependency lists" do
    assert [%{tool: :rust, contract: "", wasm: nil, deps: []}] = Builders.commands("///> rust -c")

    assert [
             %{
               tool: :rust,
               contract: "",
               deps: [%{name: "near-token", version: "*", raw: "near-token"}]
             }
           ] =
             Builders.commands("///> rust -cd near-token")

    assert [%{deps: [%{name: "regex", version: "*"}, %{name: "sha2", version: "*"}]}] =
             Builders.commands("///> rust -d regex sha2")

    assert [%{tool: :gleam, target: "javascript", deps: [%{name: "lustre", version: ">=4.6.0"}]}] =
             Builders.commands("///> gleam -t javascript -d lustre=\\\">=4.6.0\\\"")

    assert [%{tool: :rust, cleanup: false}] = Builders.commands("///> rust -l")

    assert [%{tool: :cuda, env: "poetry", deps: [%{name: "numpy"}]}] =
             Builders.commands("///> cuda -e poetry -d numpy")
  end

  test "argv keeps contract, wasm, and deps for spiral" do
    [rust] = Builders.commands("///> rust -cd near-token")

    assert Builders.argv(rust, "main.rs") == [
             "rust",
             "--rs-path",
             "main.rs",
             "--contract=",
             "--deps",
             "near-token"
           ]

    [gleam] = Builders.commands("///> gleam -t javascript -d lustre=\\\">=4.6.0\\\"")

    assert Builders.argv(gleam, "main.gleam") == [
             "gleam",
             "--gleam-path",
             "main.gleam",
             "--target",
             "javascript",
             "--deps",
             "lustre=\">=4.6.0\""
           ]

    [ts] = Builders.commands("///> ts")

    assert Builders.argv(ts, "main.fsx") == [
             "fable",
             "--fs-path",
             "main.fsx",
             "--command",
             "typescript"
           ]

    assert Builders.backend(ts) == "Fsharp"
    assert Builders.dispatch(rust, "main.rs") == {:spiral, Builders.argv(rust, "main.rs")}
    assert Builders.host_rust?(hd(Builders.commands("///> rust")))
    refute Builders.host_rust?(rust)
  end

  test "unknown tools and flags raise" do
    assert_raise ArgumentError, ~r/unknown Spiral backend "haskell"/, fn ->
      Builders.commands("///> haskell")
    end

    assert_raise ArgumentError, ~r/unknown builder flag "--trace"/, fn ->
      Builders.commands("///> rust --trace")
    end

    assert_raise ArgumentError, ~r/must be the last flag/, fn ->
      Builders.commands("///> rust -dc near-token")
    end

    assert_raise ArgumentError, ~r/unexpected builder argument/, fn ->
      Builders.commands("///> rust leftover")
    end

    assert_raise ArgumentError, ~r/takes no arguments/, fn ->
      Builders.commands("///> _ -c")
    end
  end

  test "a skip line drops the whole cell's builders from the kept body" do
    {commands, body} = Builders.split("///> rust -c\n///> _\n1i32")
    assert Enum.any?(commands, &(&1.tool == :skip))
    assert body == "1i32"
  end
end
