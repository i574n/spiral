defmodule Spiral.Cells.DocumentTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Domain

  test "exports definitions, keeps opens, and drops tests" do
    doc =
      Domain.parse_dib_doc("""
      #!meta

      {"kernelInfo":{"defaultKernelName":"spiral"}}

      #!markdown

      # demo

      #!spiral

      ///- --test static

      open testing

      #!spiral

      open sm'_operators

      #!markdown

      ## add

      #!spiral

      inl add x = x + 1

      #!spiral

      ///- --test

      add 1 |> _assert_eq 2
      """)

    spi = Domain.to_spi_doc(doc)

    assert spi ==
             """
             /// # demo
             open sm'_operators

             /// ## add
             inl add x = x + 1
             """

    livemd = Domain.to_livemd_doc(doc)
    assert Domain.to_spi_doc(Domain.parse_livemd_doc(livemd)) == spi

    assert spiral_sources(doc) == spiral_sources(Domain.parse_livemd_doc(livemd))
  end

  test "non-ASCII text survives the byte-counted wire" do
    doc =
      Domain.parse_dib_doc("""
      #!markdown

      # dé — ü 🎲

      #!spiral

      inl naïve () = "ü 🎲 é"

      #!spiral

      inl after () = 1
      """)

    assert spiral_sources(doc) == [~s|inl naïve () = "ü 🎲 é"|, "inl after () = 1"]

    assert Domain.to_spi_doc(doc) ==
             """
             /// # dé — ü 🎲
             inl naïve () = "ü 🎲 é"

             inl after () = 1
             """

    assert spiral_sources(Domain.parse_livemd_doc(Domain.to_livemd_doc(doc))) == spiral_sources(doc)
  end

  test "the export equals spiral export on a mixed F# and Spiral notebook" do
    exe = Path.expand("../../../../workspace/target/release/spiral" <> exe_suffix(), __DIR__)

    mixed =
      Domain.parse_dib_doc("""
      #!markdown

      # mixed (Mixed)

      #!markdown

      ## run (test)
      a line of prose

      #!fsharp

      let increment x = x + 1

      #!spiral

      inl main () =
          0i32
      """)

    cond do
      File.regular?(exe) ->
        compare_with_cli_export(exe, [{"mixed", mixed}])

      (System.get_env("SPIRAL_CELLS_SKIP_CLI_EXPORT") || System.get_env("SPIRAL_CELLS_SKIP_DIB_EXPORT")) in ["1", "true"] ->
        skipped("#{exe} is missing (SPIRAL_CELLS_SKIP_CLI_EXPORT is set)")

      true ->
        flunk(
          "#{exe} is missing: build it (cargo build --release in spiral/workspace) " <>
            "or set SPIRAL_CELLS_SKIP_CLI_EXPORT=1 to skip this comparison"
        )
    end
  end

  defp compare_with_cli_export(exe, docs) do
    tmp =
      Path.join(
        System.tmp_dir!(),
        "spiral_cells_test/cli_export_#{System.unique_integer([:positive])}"
      )

    File.mkdir_p!(tmp)

    try do
      for {label, doc} <- docs do
        copy = Path.join(tmp, label <> ".cells")
        File.write!(copy, Domain.to_cell_text_doc(doc))
        {out, status} = System.cmd(exe, ["export", copy, "spi"], stderr_to_stdout: true)
        assert status == 0, out
        expected = File.read!(Path.rootname(copy) <> ".spi")
        assert Domain.to_spi_doc(doc) == expected, label
      end
    after
      File.rm_rf!(tmp)
    end
  end

  defp exe_suffix, do: if(match?({:win32, _}, :os.type()), do: ".exe", else: "")

  defp skipped(what), do: IO.puts(:stderr, "document_test: skipped check, #{what}")

  test "adjacent markdown and import cells round-trip through livemd" do
    doc =
      Domain.parse_dib_doc("""
      #!markdown

      # title

      #!markdown

      ## section

      #!import ../lib/a.fs

      #!fsharp

      let x = 1

      #!import ../lib/b.dib

      #!markdown

      text
      """)

    kinds = Enum.map(doc.cells, & &1.kind)
    assert kinds == [:markdown, :markdown, :import, :fsharp, :import, :markdown]

    again = doc |> Domain.to_livemd_doc() |> Domain.parse_livemd_doc()

    assert Enum.map(again.cells, &Map.take(&1, [:kind, :source])) ==
             Enum.map(doc.cells, &Map.take(&1, [:kind, :source]))
  end

  test "a cell source with trailing newlines renders like the one without (the .livemd round-trips)" do
    doc = %{
      cells: [
        %{kind: :markdown, source: "# t\n\n"},
        %{kind: :spiral, source: "inl x () = 1i32\n\n"}
      ]
    }

    text = Domain.to_livemd_doc(doc)

    assert text ==
             Domain.to_livemd_doc(%{
               cells: [
                 %{kind: :markdown, source: "# t"},
                 %{kind: :spiral, source: "inl x () = 1i32"}
               ]
             })

    assert Domain.to_livemd_doc(Domain.parse_livemd_doc(text)) == text
  end

  @tag :alphabet_corpus
  test "alphabet: documents is a .spi source that writes back byte for byte" do
    alphabet = Path.join(Spiral.Cells.TestHelpers.alphabet_root(), "apps")
    documents_source = File.read!(Path.join(alphabet, "documents/documents.spi"))
    documents = Domain.parse_spi_doc(documents_source, "")

    assert Domain.to_spi_tested_doc(documents) == documents_source
    assert length(Domain.tests_doc(documents)) >= 2
  end

  test "test cells export as test blocks that load back as the same test cells" do
    doc = %{
      cells: [
        %{kind: :markdown, source: "## add"},
        %{kind: :spiral, source: "inl add a b = a + b"},
        %{kind: :markdown, source: "### add (test)"},
        %{kind: :spiral, source: "///- --test\n///> c\n\nadd 1 2 |> _assert_eq 3"},
        %{kind: :spiral, source: "///- --test static --print-code\n\nadd 2 2 |> _assert_eq 4"}
      ]
    }

    spi = Domain.to_spi_tested_doc(doc)

    assert spi ==
             "/// ## add\ninl add a b = a + b\n\n///> c\ntest add =\n    add 1 2 |> _assert_eq 3\n\n" <>
               "test add_2 static print_code =\n    add 2 2 |> _assert_eq 4\n"

    assert Domain.to_spi_doc(doc) == "/// ## add\ninl add a b = a + b\n"

    assert Enum.map(Domain.parse_spi_doc(spi, "").cells, &{&1.kind, &1.source}) == [
             markdown: "## add",
             spiral: "inl add a b = a + b",
             spiral: "///- --test\n///> c\n\nadd 1 2 |> _assert_eq 3",
             spiral: "///- --test static --print-code\n\nadd 2 2 |> _assert_eq 4"
           ]

    custom = "/// ## add\ninl add a b = a + b\n\ntest one_plus_one =\n    add 1 1 |> _assert_eq 2\n"
    doc = Domain.parse_spi_doc(custom, "")

    assert Enum.map(doc.cells, &{&1.kind, &1.source}) == [
             markdown: "## add",
             spiral: "inl add a b = a + b",
             markdown: "#### one_plus_one (test)",
             spiral: "///- --test\n\nadd 1 1 |> _assert_eq 2"
           ]

    assert doc |> Domain.to_livemd_doc() |> Domain.parse_livemd_doc() |> Domain.to_spi_tested_doc() == custom
  end

  test "non-ASCII headings name tests apart: identity, localized title, ASCII symbol" do
    doc = %{
      cells: [
        %{kind: :markdown, source: "## Сложение"},
        %{kind: :spiral, source: "inl add a b = a + b"},
        %{kind: :spiral, source: "///- --test\n\nadd 1 2 |> _assert_eq 3"},
        %{kind: :markdown, source: "### 加法 (test)"},
        %{kind: :spiral, source: "///- --test\n\nadd 2 2 |> _assert_eq 4"},
        %{kind: :markdown, source: "### Ünïcode — mix 2 (test)"},
        %{kind: :spiral, source: "///- --test\n\nadd 0 0 |> _assert_eq 0"},
        %{kind: :markdown, source: "### plain add (test)"},
        %{kind: :spiral, source: "///- --test\n\nadd 0 1 |> _assert_eq 1"}
      ]
    }

    spi = Domain.to_spi_tested_doc(doc)
    assert spi =~ "\ntest сложение =\n"
    assert spi =~ "\ntest 加法 =\n"
    assert spi =~ "\ntest ünïcode_mix_2 =\n"
    assert spi =~ "\ntest plain_add =\n"

    tests = Domain.tests_doc(doc)

    assert Enum.map(tests, &{&1.name, &1.title}) == [
             {"сложение", "Сложение"},
             {"加法", "加法"},
             {"ünïcode_mix_2", "Ünïcode — mix 2"},
             {"plain_add", "plain add"}
           ]

    assert Enum.map(tests, & &1.symbol) == [
             "test_u441_u43b_u43e_u436_u435_u43d_u438_u435_",
             "test_u52a0_u6cd5_",
             "test_ufc_nuef_code_mix_2",
             "plain_add"
           ]

    again = Domain.parse_spi_doc(spi, "")
    assert Domain.to_spi_tested_doc(again) == spi
    assert Enum.map(Domain.tests_doc(again), & &1.name) == Enum.map(tests, & &1.name)
  end

  test "a _real.spir interleaves with its .spi by heading, keeps only the headings over its own code, and both round-trip through livemd" do
    spi = "/// # demo\n\n/// ## twice_real\n\n/// ## twice\ninl twice (x : i32) : i32 = real twice_real x\n"
    spir = "/// ## twice_real\n///- --real\n\ninl twice_real (x : i32) : i32 = x + x\n"
    doc = Domain.parse_spi_doc(spi, spir)

    assert Enum.map(doc.cells, &{&1.kind, &1.source}) == [
             markdown: "# demo",
             markdown: "## twice_real",
             spiral: "///- --real\n\ninl twice_real (x : i32) : i32 = x + x",
             markdown: "## twice",
             spiral: "inl twice (x : i32) : i32 = real twice_real x"
           ]

    back = doc |> Domain.to_livemd_doc() |> Domain.parse_livemd_doc()
    assert Domain.to_spi_tested_doc(back) == spi
    assert Domain.to_spir_tested_doc(back) == spir

    lib = Path.expand("../../../../lib/spiral", __DIR__)
    pairs = Path.wildcard(Path.join(lib, "*_real.spir"))
    assert pairs != []

    for spir_path <- pairs do
      spi_path = String.replace_suffix(spir_path, "_real.spir", ".spi")
      {spi, spir} = {File.read!(spi_path), File.read!(spir_path)}
      back = spi |> Domain.parse_spi_doc(spir) |> Domain.to_livemd_doc() |> Domain.parse_livemd_doc()
      assert Domain.to_spi_tested_doc(back) == spi, spi_path
      assert Domain.to_spir_tested_doc(back) == spir, spir_path
    end
  end

  test "an edition-3 :# test header round-trips as :#" do
    spi = "///- --package .\n:= add (a : i32) (b : i32) : i32 = a + b\n\n///> rust\n:# adds static =\n    add 1i32 2i32 |> ignore\n"
    doc = Domain.parse_spi_doc(spi, "")
    assert Enum.any?(doc.cells, &(&1.kind == :spiral and &1.source =~ ~r/\A\/\/\/- --test static --symbol/))
    assert spi |> Domain.parse_spi_doc("") |> Domain.to_livemd_doc() |> Domain.parse_livemd_doc() |> Domain.to_spi_tested_doc() == spi
  end
  for {order, header} <- [
        {"target first", "///> rust\n///- --timeout 900000\n"},
        {"flag first", "///- --timeout 900000\n///> rust\n"}
      ] do
    test "a :# test keeps its target and its own ///- --timeout row, #{order}" do
      spi = "///- --package .\n:= add (a : i32) (b : i32) : i32 = a + b\n\n" <> unquote(header) <> ":# adds static =\n    add 1i32 2i32 |> ignore\n"
      doc = Domain.parse_spi_doc(spi, "")
      [source] = for c <- doc.cells, c.kind == :spiral and String.starts_with?(c.source, "///- --test"), do: c.source
      assert source =~ "///> rust"
      assert source =~ "///- --timeout 900000"
      refute Enum.any?(doc.cells, &(String.trim(&1.source) == String.trim(unquote(header))))
      assert spi |> Domain.parse_spi_doc("") |> Domain.to_livemd_doc() |> Domain.parse_livemd_doc() |> Domain.to_spi_tested_doc() == spi
    end
  end

  test "a package directive directly above a module :# header stays its own cell and round-trips" do
    spi = "///- --package . --timeout 600000\n:# prelude static =\n    :< testing\n\n:= one () : i32 = 1i32\n"
    doc = Domain.parse_spi_doc(spi, "")
    assert Enum.any?(doc.cells, &(String.trim(&1.source) == "///- --package . --timeout 600000"))
    assert spi |> Domain.parse_spi_doc("") |> Domain.to_livemd_doc() |> Domain.parse_livemd_doc() |> Domain.to_spi_tested_doc() == spi
  end
  test "a package directive followed by a blank line stays its own cell before a :# test" do
    spi = "///- --package .\n\n///> rust\n:# adds static =\n    1i32 |> ignore\n"
    doc = Domain.parse_spi_doc(spi, "")
    assert Enum.any?(doc.cells, &(String.trim(&1.source) == "///- --package ."))
  end
  test "a test name a heading cannot carry (trailing underscore) round-trips through an explicit --name" do
    spi = "///- --package .\n/// ### map4\n:= map4 (a : i32) : i32 = a\n\n:= map4_ (a : i32) : i32 = a\n\n///> rust\ntest map4_ =\n    map4_ 1i32 |> ignore\n"
    livemd = spi |> Domain.parse_spi_doc("") |> Domain.to_livemd_doc()
    assert livemd =~ "--name map4_"
    once = livemd |> Domain.parse_livemd_doc() |> Domain.to_spi_tested_doc()
    assert once =~ "\ntest map4_ =\n"
    refute once =~ "--name"
    assert once |> Domain.parse_spi_doc("") |> Domain.to_livemd_doc() |> Domain.parse_livemd_doc() |> Domain.to_spi_tested_doc() == once
  end
  test "a test named by its heading with the trailing underscore stripped keeps the heading name, no --name" do
    spi = "///- --package .\n/// ### take_\n:= take (a : i32) : i32 = a\n\n///> rust\ntest take =\n    take 1i32 |> ignore\n"
    livemd = spi |> Domain.parse_spi_doc("") |> Domain.to_livemd_doc()
    refute livemd =~ "--name"
    once = livemd |> Domain.parse_livemd_doc() |> Domain.to_spi_tested_doc()
    assert once =~ "\ntest take =\n"
  end
  test "a cell source holding --> stays inside its livebook comment through livemd" do
    spi = "///- --package .\n:= arrow (s : string) : bool = s = \"-->\"\n"
    livemd = spi |> Domain.parse_spi_doc("") |> Domain.to_livemd_doc()
    refute livemd =~ ~r/livebook:\{[^\n]*-->[^\n]*-->/
    once = livemd |> Domain.parse_livemd_doc() |> Domain.to_spi_tested_doc()
    assert once =~ ~s|:= arrow (s : string) : bool = s = "-->"|
    refute once =~ "chunks"
    assert once |> Domain.parse_spi_doc("") |> Domain.to_livemd_doc() |> Domain.parse_livemd_doc() |> Domain.to_spi_tested_doc() == once
  end
  @tag timeout: 900_000
  test "the spiral library .spi files load as notebooks, one test cell per test block" do
    lib = Path.expand("../../../../lib/spiral", __DIR__)
    sources = Enum.reject(Path.wildcard(Path.join(lib, "**/*.spi")), &String.contains?(&1, "/target/"))
    assert length(sources) >= 39, "#{lib} has #{length(sources)} .spi files"
    assert Path.wildcard(Path.join(lib, "**/*.livemd")) == []

    blocks =
      for path <- sources, reduce: 0 do
        total ->
          spir = Path.rootname(path) <> "_real.spir"
          spi_text = File.read!(path)
          spir_text = if File.regular?(spir), do: File.read!(spir), else: ""
          doc = Domain.parse_spi_doc(spi_text, spir_text)
          expected = length(Regex.scan(~r/^(?:test|:#) \w+/m, spi_text <> spir_text))
          found = Enum.count(doc.cells, &(&1.kind == :spiral and &1.source =~ ~r/\A\/\/\/- (--real )?--(test|ignore)/))
          assert found == expected, path
          through_livemd = &(&1 |> Domain.parse_spi_doc("") |> Domain.to_livemd_doc() |> Domain.parse_livemd_doc() |> Domain.to_spi_tested_doc())
          once = through_livemd.(spi_text)
          assert through_livemd.(once) == once, path
          if expected > 0, do: assert(once == spi_text, path)
          total + expected
      end

    assert blocks >= 370
  end

  @tag :dice_corpus
  test "dice's Spiral sources are .spi files whose test blocks load as notebook cells and write back byte for byte" do
    dice_source = File.read!(Path.join(Spiral.Cells.TestHelpers.dice_root(), "lib/dice.spi"))
    contract_source = File.read!(Path.join(Spiral.Cells.TestHelpers.dice_root(), "contract/dice_contract.spi"))
    dice = Domain.parse_spi_doc(dice_source, "")
    contract = Domain.parse_spi_doc(contract_source, "")

    assert Domain.to_spi_tested_doc(dice) == dice_source
    assert Domain.to_spi_tested_doc(contract) == contract_source
    assert length(Domain.tests_doc(dice)) >= 24
    assert length(Domain.tests_doc(contract)) >= 8

    spi = Domain.to_spi_doc(dice)
    assert spi =~ "/// # dice (Dice)"
    assert spi =~ ~r/^(?:inl|:=) face_of_pips \(p : u8\) : option face =/m
    assert spi =~ ~r/^(?:inl|:=) main \(_args : array_base string\) =/m
    refute spi =~ "_assert_eq"
    refute spi =~ ~r/^\s*(?:open|:<) testing$/m

    spi = Domain.to_spi_doc(contract)
    assert spi =~ "///- --package ../dice"
    assert spi =~ "lib.dice.roll_within_bounds max"
    refute spi =~ "_assert_eq"
    refute spi =~ "///> rust"

    assert spi =~ "/// ### main\n"
    refute spi =~ "///> _"
    assert spi =~ ~r/^(?:inl|:=) main \(\) =/m
  end

  defp spiral_sources(doc) do
    Enum.flat_map(doc.cells, fn
      %{kind: :spiral, source: source} -> [source]
      _ -> []
    end)
  end
end
