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

  test "dice notebooks round-trip through livemd" do
    unless File.regular?(Path.join(@dice, "lib/dice.dib")) do
      flunk("dice checkout is not next to spiral")
    end

    for rel <- ["lib/dice.dib", "contract/dice_contract.dib", "lib/fsharp/dice_fsharp.dib"] do
      doc = Document.parse_dib(File.read!(Path.join(@dice, rel)))
      again = doc |> Document.to_livemd() |> Document.parse_livemd()

      assert spiral_sources(doc) == spiral_sources(again)
      assert fsharp_sources(doc) == fsharp_sources(again)

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
