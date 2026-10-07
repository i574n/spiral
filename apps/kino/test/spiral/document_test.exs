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

    # Like `spiral export`: the dropped test cell leaves the heading directly on the next code cell.
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

    # A missing exe must not pass vacuously: the comparison is this test's whole point.
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

    # The CLI reads the cell text Document.to_cell_text renders from the .livemd (the same route Kino's F# export takes).
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

  # A notebook's .livemd is the source of truth: it must read back to the same text, keep its cells through the cell text
  # the CLI's export reads, and export the committed .spi.
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

  test "the spiral library notebooks round-trip through livemd and export their committed .spi" do
    lib = Path.expand("../../../../lib/spiral", __DIR__)
    notebooks = Path.wildcard(Path.join(lib, "**/*.livemd"))
    assert length(notebooks) >= 39, "#{lib} has #{length(notebooks)} notebooks"

    for path <- notebooks do
      doc = assert_livemd_round_trip(path, false)
      assert File.regular?(Path.rootname(path) <> ".spi"), path

      if Path.basename(path) == "sm'.livemd" do
        assert Document.to_spir(doc) == File.read!(Path.join(lib, "sm'_real.spir"))
      end
    end

    # every pair whose committed .spi is not the .livemd's export (an edit synced to one side only), named at once
    stale =
      for path <- notebooks,
          spi = Path.rootname(path) <> ".spi",
          Document.to_spi(Document.parse_livemd(File.read!(path))) != File.read!(spi),
          do: Path.relative_to(spi, lib)

    assert stale == [], "these .spi differ from their .livemd's export: #{Enum.join(stale, ", ")}"
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

    # The `///> _` (skip) directive survives the export; the main cell's body is the contract's own business.
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
