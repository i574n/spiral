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

    # Like `spiral dib-export`: the dropped test cell leaves the heading directly on the next code cell.
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

  test "the export keeps directive lines of code cells and follows dib-export's markdown rules" do
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

  test "the export equals spiral dib-export on the dice and alphabet notebooks" do
    exe = Path.expand("../../../../workspace/target/release/spiral" <> exe_suffix(), __DIR__)
    alphabet = Path.expand("../../../../../alphabet/apps", __DIR__)

    notebooks =
      Enum.map(
        ["lib/dice.dib", "contract/dice_contract.dib", "lib/fsharp/dice_fsharp.dib"],
        &Path.join(@dice, &1)
      ) ++
        Enum.map(["documents/documents.dib", "hangul/hangul.dib"], &Path.join(alphabet, &1))

    # A missing exe must not pass vacuously: the comparison is this test's whole point.
    cond do
      File.regular?(exe) ->
        compare_with_dib_export(exe, notebooks)

      System.get_env("SPIRAL_KINO_SKIP_DIB_EXPORT") in ["1", "true"] ->
        skipped("#{exe} is missing (SPIRAL_KINO_SKIP_DIB_EXPORT is set)")

      true ->
        flunk(
          "#{exe} is missing: build it (cargo build --release in spiral/workspace) " <>
            "or set SPIRAL_KINO_SKIP_DIB_EXPORT=1 to skip this comparison"
        )
    end
  end

  defp compare_with_dib_export(exe, notebooks) do
    tmp =
      Path.join(
        System.tmp_dir!(),
        "spiral_kino_test/dib_export_#{System.unique_integer([:positive])}"
      )

    File.mkdir_p!(tmp)

    try do
      for path <- notebooks do
        if File.regular?(path) do
          copy = Path.join(tmp, Path.basename(path))
          File.cp!(path, copy)
          {out, status} = System.cmd(exe, ["dib-export", copy, "spi"], stderr_to_stdout: true)
          assert status == 0, out
          expected = File.read!(Path.rootname(copy) <> ".spi")
          assert Document.to_spi(Document.parse_dib(File.read!(path))) == expected, path

          livemd = Path.rootname(path) <> ".livemd"

          if File.regular?(livemd) do
            assert Document.to_spi(Document.parse_livemd(File.read!(livemd))) == expected, livemd
          else
            skipped("#{livemd} is missing")
          end
        else
          skipped("#{path} is missing")
        end
      end
    after
      File.rm_rf!(tmp)
    end
  end

  defp exe_suffix, do: if(match?({:win32, _}, :os.type()), do: ".exe", else: "")

  # The dice and alphabet notebooks live in sibling repos; their .livemd files may not be committed yet. A missing file
  # skips that check with a note on stderr instead of crashing the suite.
  defp skipped(what), do: IO.puts(:stderr, "document_test: skipped check, #{what}")

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

  test "alphabet notebooks round-trip through livemd" do
    alphabet = Path.expand("../../../../../alphabet/apps", __DIR__)

    for rel <- ["documents/documents.dib", "hangul/hangul.dib"] do
      path = Path.join(alphabet, rel)
      livemd_path = Path.rootname(path) <> ".livemd"

      cond do
        not File.regular?(path) ->
          skipped("#{path} is missing")

        not File.regular?(livemd_path) ->
          skipped("#{livemd_path} is missing")

        true ->
          doc = Document.parse_dib(File.read!(path))
          livemd = Document.parse_livemd(File.read!(livemd_path))

          assert Enum.map(livemd.cells, &Map.take(&1, [:kind, :source])) ==
                   Enum.map(doc.cells, &Map.take(&1, [:kind, :source]))

          assert Document.to_spi(doc) == Document.to_spi(livemd)
      end
    end
  end

  test "dice notebooks round-trip through livemd" do
    unless File.regular?(Path.join(@dice, "lib/dice.dib")) do
      flunk("dice checkout is not next to spiral")
    end

    for rel <- ["lib/dice.dib", "contract/dice_contract.dib", "lib/fsharp/dice_fsharp.dib"] do
      path = Path.join(@dice, rel)
      doc = Document.parse_dib(File.read!(path))
      again = doc |> Document.to_livemd() |> Document.parse_livemd()

      assert spiral_sources(doc) == spiral_sources(again)
      assert fsharp_sources(doc) == fsharp_sources(again)

      livemd_path = Path.rootname(path) <> ".livemd"

      livemd =
        if File.regular?(livemd_path) do
          livemd = Document.parse_livemd(File.read!(livemd_path))
          assert spiral_sources(doc) == spiral_sources(livemd)
          assert fsharp_sources(doc) == fsharp_sources(livemd)
          livemd
        else
          skipped("#{livemd_path} is missing")
          nil
        end

      if String.ends_with?(rel, "dice.dib") or String.ends_with?(rel, "dice_contract.dib") do
        spi = Document.to_spi(doc)
        if livemd, do: assert(spi == Document.to_spi(livemd))
        assert spi == File.read!(Path.rootname(path) <> ".spi")
      end

      if String.ends_with?(rel, "dice.dib") do
        spi = Document.to_spi(doc)
        assert spi =~ "/// # dice (Dice)"
        assert spi =~ "inl sixth_power_sequence () ="
        assert spi =~ "inl main (_args : array_base string) ="
        refute spi =~ "_assert_eq"
        refute spi =~ "open testing"
      end

      if String.ends_with?(rel, "dice_contract.dib") do
        spi = Document.to_spi(doc)
        assert spi =~ "///- --package ../dice"
        assert spi =~ "lib.dice.rotate_numbers 6"
        refute spi =~ "_assert_eq"
        refute spi =~ "///> rust"

        # The `///> _` (skip) directive survives the export; the main cell's body is the contract's own business.
        assert spi =~ "/// ### main\n///> _\n"
        assert spi =~ ~r/^inl main \(\) =/m
      end
    end
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
