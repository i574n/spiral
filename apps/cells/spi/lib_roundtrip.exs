alias Spiral.Cells.Document

{lib, out, names} =
  case System.argv() do
    [lib, out | names] -> {String.replace(lib, "\\", "/"), out, names}
    _ -> raise "usage: mix run --no-start spi/lib_roundtrip.exs <lib dir> <out dir> [file.spi ...]"
  end

File.mkdir_p!(out)
through = fn spi, spir -> spi |> Document.parse_spi(spir) |> Document.to_livemd() |> Document.parse_livemd() end
names = if names == [], do: lib |> Path.join("**/*.spi") |> Path.wildcard() |> Enum.map(&Path.relative_to(&1, lib)), else: names

results =
  for name <- names do
    spi_path = Path.join(lib, name)
    spir_path = String.replace_suffix(spi_path, ".spi", "_real.spir")
    spi = File.read!(spi_path)
    spir = if File.regular?(spir_path), do: File.read!(spir_path), else: ""
    back = through.(spi, spir)
    {spi2, spir2} = {Document.to_spi_tested(back), Document.to_spir_tested(back)}
    again = through.(spi2, spir2)
    fixpoint = Document.to_spi_tested(again) == spi2 and (spir == "" or Document.to_spir_tested(again) == spir2)
    canonical = spi2 == spi and (spir == "" or spir2 == spir)
    target = Path.join(out, name)
    File.mkdir_p!(Path.dirname(target))
    File.write!(target, spi2)
    if spir != "", do: File.write!(String.replace_suffix(target, ".spi", "_real.spir"), spir2)
    IO.puts("ROUNDTRIP #{name}: canonical #{canonical} fixpoint #{fixpoint}#{if spir != "", do: " (with _real.spir)", else: ""}")
    canonical
  end

IO.puts("ROUNDTRIP total #{length(results)}, canonical #{Enum.count(results, & &1)}")
