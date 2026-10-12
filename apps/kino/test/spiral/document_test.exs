defmodule Spiral.Kino.DocumentTest do
  use ExUnit.Case, async: true

  alias Spiral.Kino.Document

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
        ["lib/dice.livemd", "contract/dice_contract.livemd", "lib/fsharp/dice_fsharp.livemd"],
        &Path.join(@dice, &1)
      ) ++
        Enum.map(["documents/documents.livemd", "hangul/hangul.livemd"], &Path.join(alphabet, &1))

    cond do
      File.regular?(exe) ->
        compare_with_cli_export(exe, notebooks)

      (System.get_env("SPIRAL_KINO_SKIP_CLI_EXPORT") || System.get_env("SPIRAL_KINO_SKIP_DIB_EXPORT")) in ["1", "true"] ->
        skipped("#{exe} is missing (SPIRAL_KINO_SKIP_CLI_EXPORT is set)")

      true ->
        flunk(
          "#{exe} is missing: build it (cargo build --release in spiral/workspace) " <>
            "or set SPIRAL_KINO_SKIP_CLI_EXPORT=1 to skip this comparison"
        )
    end
  end

  defp compare_with_cli_export(exe, notebooks) do
    tmp =
      Path.join(
        System.tmp_dir!(),
        "spiral_kino_test/cli_export_#{System.unique_integer([:positive])}"
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

  test "alphabet notebooks round-trip through livemd" do
    alphabet = Path.expand("../../../../../alphabet/apps", __DIR__)

    for rel <- ["documents/documents.livemd", "hangul/hangul.livemd"] do
      assert_livemd_round_trip(Path.join(alphabet, rel))
    end
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

  test "dice notebooks round-trip through livemd" do
    dice = assert_livemd_round_trip(Path.join(@dice, "lib/dice.livemd"))
    contract = assert_livemd_round_trip(Path.join(@dice, "contract/dice_contract.livemd"))
    fsharp = assert_livemd_round_trip(Path.join(@dice, "lib/fsharp/dice_fsharp.livemd"))

    assert File.regular?(Path.join(@dice, "lib/dice.spi"))
    assert File.regular?(Path.join(@dice, "contract/dice_contract.spi"))
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
end
