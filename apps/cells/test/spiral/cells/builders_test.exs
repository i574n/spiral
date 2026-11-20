defmodule Spiral.Cells.BuildersTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Domain

  test "short clusters and dependency lists" do
    assert [%{tool: :rust, contract: "", wasm: nil, deps: []}] = Domain.builders_commands("///> rust -c")

    assert [
             %{
               tool: :rust,
               contract: "",
               deps: [%{name: "near-token", version: "*", raw: "near-token"}]
             }
           ] =
             Domain.builders_commands("///> rust -cd near-token")

    assert [%{deps: [%{name: "regex", version: "*"}, %{name: "sha2", version: "*"}]}] =
             Domain.builders_commands("///> rust -d regex sha2")

    assert [%{tool: :gleam, target: "javascript", deps: [%{name: "lustre", version: ">=4.6.0"}]}] =
             Domain.builders_commands("///> gleam -t javascript -d lustre=\\\">=4.6.0\\\"")

    assert [%{tool: :rust, cleanup: false}] = Domain.builders_commands("///> rust -l")

    assert [%{tool: :cuda, env: "poetry", deps: [%{name: "numpy"}]}] =
             Domain.builders_commands("///> cuda -e poetry -d numpy")
  end

  test "a quoted rust dep version reaches the CLI as a TOML string" do
    [rust] = Domain.builders_commands("///> rust -d num-complex pyo3='=0.26.0'")

    assert Domain.builders_argv(rust, "main.rs") == [
             "rust",
             "--rs-path",
             "main.rs",
             "--deps",
             "num-complex",
             "--deps",
             "pyo3='=0.26.0'"
           ]
  end

  test "argv keeps contract, wasm, and deps for spiral" do
    [rust] = Domain.builders_commands("///> rust -cd near-token")

    assert Domain.builders_argv(rust, "main.rs") == [
             "rust",
             "--rs-path",
             "main.rs",
             "--contract=",
             "--deps",
             "near-token"
           ]

    [gleam] = Domain.builders_commands("///> gleam -t javascript -d lustre=\\\">=4.6.0\\\"")

    assert Domain.builders_argv(gleam, "main.gleam") == [
             "gleam",
             "--gleam-path",
             "main.gleam",
             "--target",
             "javascript",
             "--deps",
             "lustre=\">=4.6.0\""
           ]

    [ts] = Domain.builders_commands("///> ts")

    assert Domain.builders_dispatch(ts, "main.ts") == {:bun, "main.ts"}
    assert Domain.builders_backend(ts) == "TypeScript"
    assert Domain.builders_ext(ts) == ".ts"
    assert Domain.builders_dispatch(rust, "main.rs") == {:spiral, Domain.builders_argv(rust, "main.rs")}
    assert Domain.builders_host_rust(hd(Domain.builders_commands("///> rust")))
    refute Domain.builders_host_rust(rust)
  end

  test "unknown tools and flags raise" do
    assert_raise ArgumentError, ~r/unknown Spiral backend "haskell"/, fn ->
      Domain.builders_commands("///> haskell")
    end

    assert_raise ArgumentError, ~r/unknown builder flag "--trace"/, fn ->
      Domain.builders_commands("///> rust --trace")
    end

    assert_raise ArgumentError, ~r/must be the last flag/, fn ->
      Domain.builders_commands("///> rust -dc near-token")
    end

    assert_raise ArgumentError, ~r/unexpected builder argument/, fn ->
      Domain.builders_commands("///> rust leftover")
    end

    assert_raise ArgumentError, ~r/retired/, fn ->
      Domain.builders_commands("///> _ -c")
    end
  end

  test "the retired skip line names the inference rules" do
    error = assert_raise ArgumentError, fn -> Domain.builders_split("///> rust -c\n///> _\n1i32") end
    message = Exception.message(error)
    assert message =~ "///> _ is retired"
    assert message =~ "any test cell"
    assert message =~ "only registers exports"
    assert message =~ "backend_switch"
  end

  test "a pascal line builds with the pascal tool" do
    {[command], body} = Domain.builders_split("///> pascal\n1i32")
    assert command.tool == :pascal
    assert body == "1i32"
  end

  test "a delphi line is an alias of the pascal tool, so old notebooks still build" do
    {[command], body} = Domain.builders_split("///> delphi\n1i32")
    assert command.tool == :pascal
    assert body == "1i32"
  end

  test "every target names its compiler backend and file extension from the Spiral domain table" do
    table = %{
      rust: {"Rust", ".rs"},
      fsharp: {"Fsharp", ".fsx"},
      typescript: {"TypeScript", ".ts"},
      python: {"Python + Cuda", ".py"},
      cuda: {"Python + Cuda", ".py"},
      cpp: {"Cpp + Cuda", ".cpp"},
      gleam: {"Gleam", ".gleam"},
      lua: {"Lua", ".lua"},
      c: {"C", ".c"},
      pascal: {"Pascal", ".pas"},
      zig: {"Zig", ".zig"},
      lean: {"Lean", ".lean"},
      wgsl: {"Wgsl", ".wgsl"}
    }

    for {tool, expected} <- table, do: assert({Domain.builders_backend(%{tool: tool}), Domain.builders_ext(%{tool: tool})} == expected)
    assert_raise ArgumentError, fn -> Domain.builders_backend(%{tool: :fortran}) end
  end
end