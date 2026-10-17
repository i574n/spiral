defmodule Spiral.Cells.DocumentTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Document

  @dice Path.expand("../../../../../dice", __DIR__)

  test "exports definitions, keeps opens, and drops tests" do
    doc =
      Document.parse_dib("""
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

    spi = Document.to_spi(doc)

    assert spi ==
             """
             /// # demo
             open sm'_operators

             /// ## add
             inl add x = x + 1
             """

    livemd = Document.to_livemd(doc)
    assert Document.to_spi(Document.parse_livemd(livemd)) == spi

    assert spiral_sources(doc) == spiral_sources(Document.parse_livemd(livemd))
  end

  test "non-ASCII text survives the byte-counted wire" do
    doc =
      Document.parse_dib("""
      #!markdown

      # dé — ü 🎲

      #!spiral

      inl naïve () = "ü 🎲 é"

      #!spiral

      inl after () = 1
      """)

    assert spiral_sources(doc) == [~s|inl naïve () = "ü 🎲 é"|, "inl after () = 1"]

    assert Document.to_spi(doc) ==
             """
             /// # dé — ü 🎲
             inl naïve () = "ü 🎲 é"

             inl after () = 1
             """

    assert spiral_sources(Document.parse_livemd(Document.to_livemd(doc))) == spiral_sources(doc)
  end

  test "a package directive stays on the module" do
    doc =
      Document.parse_dib("""
      #!markdown

      # demo

      #!spiral

      ///- --package ../dice

      open rust
      open sm'_operators

      #!markdown

      ## item

      #!markdown

      ### value

      #!spiral

      inl value () = 1

      #!spiral

      ///- --test
      ///> rust -c

      value () |> _assert_eq 1
      """)

    spi = Document.to_spi(doc)

    assert spi ==
             """
             /// # demo
             ///- --package ../dice

             open rust
             open sm'_operators

             /// ## item

             /// ### value
             inl value () = 1
             """

    refute spi =~ "_assert_eq"
    refute spi =~ "///>"
  end

  test "the export keeps directive lines of code cells and follows the CLI export's markdown rules" do
    doc =
      Document.parse_dib("""
      #!markdown

      # demo (Demo)

      #!spiral

      ///- --test static

      open testing

      #!spiral

      open rust

      #!markdown

      ## run (test)
      indented:
        two spaces

      last line

      #!fsharp

      let f = 1

      #!spiral

      ///> _

      inl main () =
          0i32

      #!spiral

      ///- --real

      inl r () = 1

      #!markdown

      ### dropped: nothing follows
      """)

    assert Document.to_spi(doc) ==
             """
             /// # demo (Demo)
             open rust

             /// indented:
               /// two spaces
             ///\s
             /// last line
             ///> _

             inl main () =
                 0i32
             """
  end

  test "the export equals spiral export on the dice and alphabet notebooks" do
    exe = Path.expand("../../../../workspace/target/release/spiral" <> exe_suffix(), __DIR__)
    alphabet = Path.expand("../../../../../alphabet/apps", __DIR__)

    notebooks =
      Enum.map(
        ["lib/fsharp/dice_fsharp.livemd"],
        &Path.join(@dice, &1)
      ) ++
        Enum.map(["hangul/hangul.livemd"], &Path.join(alphabet, &1))

    cond do
      File.regular?(exe) ->
        compare_with_cli_export(exe, notebooks)

      (System.get_env("SPIRAL_CELLS_SKIP_CLI_EXPORT") || System.get_env("SPIRAL_CELLS_SKIP_DIB_EXPORT")) in ["1", "true"] ->
        skipped("#{exe} is missing (SPIRAL_CELLS_SKIP_CLI_EXPORT is set)")

      true ->
        flunk(
          "#{exe} is missing: build it (cargo build --release in spiral/workspace) " <>
            "or set SPIRAL_CELLS_SKIP_CLI_EXPORT=1 to skip this comparison"
        )
    end
  end

  defp compare_with_cli_export(exe, notebooks) do
    tmp =
      Path.join(
        System.tmp_dir!(),
        "spiral_cells_test/cli_export_#{System.unique_integer([:positive])}"
      )

    File.mkdir_p!(tmp)

    try do
      for path <- notebooks do
        assert File.regular?(path), "#{path} is missing"
        doc = Document.parse_livemd(File.read!(path))
        copy = Path.join(tmp, Path.basename(path, ".livemd") <> ".cells")
        File.write!(copy, Document.to_cell_text(doc))
        {out, status} = System.cmd(exe, ["export", copy, "spi"], stderr_to_stdout: true)
        assert status == 0, out
        expected = File.read!(Path.rootname(copy) <> ".spi")
        assert Document.to_spi(doc) == expected, path
      end
    after
      File.rm_rf!(tmp)
    end
  end

  defp exe_suffix, do: if(match?({:win32, _}, :os.type()), do: ".exe", else: "")

  defp skipped(what), do: IO.puts(:stderr, "document_test: skipped check, #{what}")

  defp assert_livemd_round_trip(path, check_spi \\ true) do
    assert File.regular?(path),
           "#{path} is missing (dice and alphabet are checked out next to spiral)"

    text = File.read!(path)
    doc = Document.parse_livemd(text)

    assert Document.to_livemd(doc) == text, path

    again = doc |> Document.to_livemd() |> Document.parse_livemd()
    assert cells(again) == cells(doc), path

    via_text = doc |> Document.to_cell_text() |> Document.parse_dib()
    assert spiral_sources(via_text) == spiral_sources(doc), path
    assert fsharp_sources(via_text) == fsharp_sources(doc), path
    assert Document.to_spi(via_text) == Document.to_spi(doc), path

    spi = Path.rootname(path) <> ".spi"
    if check_spi and File.regular?(spi), do: assert(Document.to_spi(doc) == File.read!(spi), spi)

    doc
  end

  defp cells(doc), do: Enum.map(doc.cells, &Map.take(&1, [:kind, :source]))

  test "adjacent markdown and import cells round-trip through livemd" do
    doc =
      Document.parse_dib("""
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

    again = doc |> Document.to_livemd() |> Document.parse_livemd()

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

    text = Document.to_livemd(doc)

    assert text ==
             Document.to_livemd(%{
               cells: [
                 %{kind: :markdown, source: "# t"},
                 %{kind: :spiral, source: "inl x () = 1i32"}
               ]
             })

    assert Document.to_livemd(Document.parse_livemd(text)) == text
  end

  test "alphabet: documents is a .spi source that writes back byte for byte, hangul an F# notebook that round-trips through livemd" do
    alphabet = Path.expand("../../../../../alphabet/apps", __DIR__)
    documents_source = File.read!(Path.join(alphabet, "documents/documents.spi"))
    documents = Document.parse_spi(documents_source, "")

    assert Document.to_spi_tested(documents) == documents_source
    assert length(Document.tests(documents)) >= 2
    assert_livemd_round_trip(Path.join(alphabet, "hangul/hangul.livemd"))
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

    spi = Document.to_spi_tested(doc)

    assert spi ==
             "/// ## add\ninl add a b = a + b\n\n///> c\ntest add =\n    add 1 2 |> _assert_eq 3\n\n" <>
               "test add_2 static print_code =\n    add 2 2 |> _assert_eq 4\n"

    assert Document.to_spi(doc) == "/// ## add\ninl add a b = a + b\n"

    assert Enum.map(Document.parse_spi(spi, "").cells, &{&1.kind, &1.source}) == [
             markdown: "## add",
             spiral: "inl add a b = a + b",
             spiral: "///- --test\n///> c\n\nadd 1 2 |> _assert_eq 3",
             spiral: "///- --test static --print-code\n\nadd 2 2 |> _assert_eq 4"
           ]

    custom = "/// ## add\ninl add a b = a + b\n\ntest one_plus_one =\n    add 1 1 |> _assert_eq 2\n"
    doc = Document.parse_spi(custom, "")

    assert Enum.map(doc.cells, &{&1.kind, &1.source}) == [
             markdown: "## add",
             spiral: "inl add a b = a + b",
             markdown: "#### one_plus_one (test)",
             spiral: "///- --test\n\nadd 1 1 |> _assert_eq 2"
           ]

    assert doc |> Document.to_livemd() |> Document.parse_livemd() |> Document.to_spi_tested() == custom
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

    spi = Document.to_spi_tested(doc)
    assert spi =~ "\ntest сложение =\n"
    assert spi =~ "\ntest 加法 =\n"
    assert spi =~ "\ntest ünïcode_mix_2 =\n"
    assert spi =~ "\ntest plain_add =\n"

    tests = Document.tests(doc)

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

    again = Document.parse_spi(spi, "")
    assert Document.to_spi_tested(again) == spi
    assert Enum.map(Document.tests(again), & &1.name) == Enum.map(tests, & &1.name)
  end

  test "a _real.spir interleaves with its .spi by heading and both round-trip through livemd" do
    spi = "/// # demo\n\n/// ## twice_real\n\n/// ## twice\ninl twice (x : i32) : i32 = real twice_real x\n"
    spir = "/// # demo\n\n/// ## twice_real\n///- --real\n\ninl twice_real (x : i32) : i32 = x + x\n"
    doc = Document.parse_spi(spi, spir)

    assert Enum.map(doc.cells, &{&1.kind, &1.source}) == [
             markdown: "# demo",
             markdown: "## twice_real",
             spiral: "///- --real\n\ninl twice_real (x : i32) : i32 = x + x",
             markdown: "## twice",
             spiral: "inl twice (x : i32) : i32 = real twice_real x"
           ]

    back = doc |> Document.to_livemd() |> Document.parse_livemd()
    assert Document.to_spi_tested(back) == spi
    assert Document.to_spir_tested(back) == spir

    lib = Path.expand("../../../../lib/spiral", __DIR__)
    pairs = Path.wildcard(Path.join(lib, "*_real.spir"))
    assert pairs != []

    for spir_path <- pairs do
      spi_path = String.replace_suffix(spir_path, "_real.spir", ".spi")
      {spi, spir} = {File.read!(spi_path), File.read!(spir_path)}
      back = spi |> Document.parse_spi(spir) |> Document.to_livemd() |> Document.parse_livemd()
      assert Document.to_spi_tested(back) == spi, spi_path
      assert Document.to_spir_tested(back) == spir, spir_path
    end
  end

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
          doc = Document.parse_spi(spi_text, spir_text)
          expected = length(Regex.scan(~r/^test \w+/m, spi_text <> spir_text))
          found = Enum.count(doc.cells, &(&1.kind == :spiral and &1.source =~ ~r/\A\/\/\/- (--real )?--(test|ignore)/))
          assert found == expected, path
          through_livemd = &(&1 |> Document.parse_spi("") |> Document.to_livemd() |> Document.parse_livemd() |> Document.to_spi_tested())
          once = through_livemd.(spi_text)
          assert through_livemd.(once) == once, path
          if expected > 0, do: assert(once == spi_text, path)
          total + expected
      end

    assert blocks >= 370
  end

  test "dice's Spiral sources are .spi files whose test blocks load as notebook cells and write back byte for byte" do
    dice_source = File.read!(Path.join(@dice, "lib/dice.spi"))
    contract_source = File.read!(Path.join(@dice, "contract/dice_contract.spi"))
    dice = Document.parse_spi(dice_source, "")
    contract = Document.parse_spi(contract_source, "")
    fsharp = assert_livemd_round_trip(Path.join(@dice, "lib/fsharp/dice_fsharp.livemd"))

    assert Document.to_spi_tested(dice) == dice_source
    assert Document.to_spi_tested(contract) == contract_source
    assert length(Document.tests(dice)) >= 24
    assert length(Document.tests(contract)) >= 8
    assert fsharp_sources(fsharp) != []

    spi = Document.to_spi(dice)
    assert spi =~ "/// # dice (Dice)"
    assert spi =~ "inl sixth_power_sequence () ="
    assert spi =~ "inl main (_args : array_base string) ="
    refute spi =~ "_assert_eq"
    refute spi =~ "open testing"

    spi = Document.to_spi(contract)
    assert spi =~ "///- --package ../dice"
    assert spi =~ "lib.dice.rotate_numbers 6"
    refute spi =~ "_assert_eq"
    refute spi =~ "///> rust"

    assert spi =~ "/// ### main\n///> _\n"
    assert spi =~ ~r/^inl main \(\) =/m
  end

  defp spiral_sources(doc) do
    Enum.flat_map(doc.cells, fn
      %{kind: :spiral, source: source} -> [source]
      _ -> []
    end)
  end

  defp fsharp_sources(doc) do
    Enum.flat_map(doc.cells, fn
      %{kind: :fsharp, source: source} -> [source]
      _ -> []
    end)
  end
  test "a column-0 comment inside a test body keeps the lines after it in the test, as the compiler's block does" do
    spi = "test a =\n    1 |> ignore\n/// note\n    2 |> ignore\n\ninl x () = 1\n"

    assert Enum.map(Document.parse_spi(spi, "").cells, &{&1.kind, &1.source}) == [
             markdown: "#### a (test)",
             spiral: "///- --test\n\n1 |> ignore\n/// note\n2 |> ignore",
             spiral: "inl x () = 1"
           ]
  end

  test "a column-0 comment after a test body still ends the test when no indented line follows" do
    spi = "test a =\n    1 |> ignore\n\n/// ## next\ninl x () = 1\n"

    assert Enum.map(Document.parse_spi(spi, "").cells, &{&1.kind, &1.source}) == [
             markdown: "#### a (test)",
             spiral: "///- --test\n\n1 |> ignore",
             markdown: "## next",
             spiral: "inl x () = 1"
           ]
  end

  test "a block the compiler skips as a test but whose header is malformed becomes a failing test, never silent code" do
    for {spi, name} <- [{"test b = 1\n", "b"}, {"test c\n    1 |> ignore\n", "c"}, {"test e unknown_flag =\n    1\n", "e"}, {"test\td =\n    1\n", "d"}] do
      doc = Document.parse_spi(spi, "")
      [%{name: ^name}] = Document.tests(doc)
      [header | _] = String.split(spi, "\n")
      escaped = header |> String.replace("\\", "\\\\") |> String.replace("\"", "\\\"")
      assert Enum.any?(doc.cells, &(&1.source == "///- --test\n\nfailwith \"malformed test header: " <> escaped <> "\" : ()"))
    end
  end

  test "compiler test-block bounds keep a column-0 string continuation inside its test" do
    spi = "inl x () = 1i32\n\ntest multi =\n    inl s = \"\"\"a\nb\"\"\"\n    s |> _assert_eq \"a\\nb\"\n\ninl y () = 2i32\n"
    test_source = fn doc -> doc.cells |> Enum.filter(&String.starts_with?(&1.source, "///- --test")) |> Enum.map(& &1.source) end
    assert [heuristic] = test_source.(Document.parse_spi(spi, ""))
    refute heuristic =~ "_assert_eq"
    assert [bounded] = test_source.(Document.parse_spi(spi, "", {"multi\t3\t4\t6\ttest multi =\n", ""}))
    assert bounded =~ "inl s = \"\"\"a\nb\"\"\"\ns |> _assert_eq"
    assert Enum.any?(Document.parse_spi(spi, "", {"multi\t3\t4\t6\ttest multi =\n", ""}).cells, &(&1.source =~ "inl y () = 2i32"))
  end
end