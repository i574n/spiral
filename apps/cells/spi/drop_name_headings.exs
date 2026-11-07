alias Spiral.Cells.Document

{root, out, names} =
  case System.argv() do
    [root, out | names] -> {String.replace(root, "\\", "/"), out, names}
    _ -> raise "usage: mix run --no-start spi/drop_name_headings.exs <spiral dir> <out dir> [file.spi ...]"
  end

File.mkdir_p!(out)
through = fn spi, spir -> spi |> Document.parse_spi(spir) |> Document.to_livemd() |> Document.parse_livemd() end
nested_package? = fn name ->
  name |> Path.dirname() |> Path.split() |> Enum.scan(&Path.join(&2, &1)) |> Enum.reject(&(&1 == "."))
  |> Enum.any?(fn dir -> Enum.any?(["spiral.toml", "package.spiproj"], &File.regular?(Path.join([root, dir, &1]))) end)
end
names =
  if names == [],
    do: root |> Path.join("**/*.spi") |> Path.wildcard() |> Enum.map(&Path.relative_to(&1, root)) |> Enum.reject(nested_package?),
    else: names
blank? = fn line -> String.trim(line) == "" end

defined_name = fn line ->
  tokens = line |> String.trim() |> String.split(~r/\s+/)
  tokens = if match?([":" <> _ | _], tokens) or match?(["test" | _], tokens), do: tl(tokens), else: tokens
  tokens = if match?(["^" | _], tokens), do: tl(tokens), else: tokens
  List.first(tokens)
end

stale? = fn heading, next ->
  name = String.trim(heading)
  names = [name, String.replace(name, "\\\\", "\\")]
  defined = next && defined_name.(next)

  next == nil or
    (not String.starts_with?(next, "///") and defined != nil and
       (defined in names or (not String.contains?(name, " ") and Enum.any?(names, &String.starts_with?(defined, &1 <> "_")))))
end

file_title? = fn line, name ->
  title = line |> String.replace_prefix("/// # ", "") |> String.trim()
  String.starts_with?(line, "/// # ") and title in [Path.rootname(Path.basename(name)), Path.rootname(name)]
end

drop = fn lines, name, keep ->
  indexed = Enum.with_index(lines)
  next_code = fn i -> indexed |> Enum.drop(i + 1) |> Enum.find(fn {l, _} -> not blank?.(l) end) |> then(&(&1 && elem(&1, 0))) end
  dropped =
    for {line, i} <- indexed,
        not MapSet.member?(keep, String.trim_trailing(line)),
        file_title?.(line, name) or (String.starts_with?(line, "/// ### ") and stale?.(String.replace_prefix(line, "/// ### ", ""), next_code.(i))),
        into: MapSet.new(),
        do: i
  orphans =
    for i <- dropped, i == 0 or blank?.(Enum.at(lines, i - 1)), i + 1 < length(lines), blank?.(Enum.at(lines, i + 1)), into: MapSet.new(), do: i + 1
  kept = for {line, i} <- indexed, not MapSet.member?(dropped, i), not MapSet.member?(orphans, i), do: line
  {kept, MapSet.size(dropped)}
end

results =
  for name <- names do
    path = Path.join(root, name)
    spir_path = String.replace_suffix(path, ".spi", "_real.spir")
    spir = if File.regular?(spir_path), do: File.read!(spir_path), else: ""
    keep = spir |> String.split("\n") |> Enum.map(&String.trim_trailing/1) |> Enum.filter(&String.starts_with?(&1, "/// #")) |> MapSet.new()
    spi = File.read!(path)
    {lines, removed} = spi |> String.split("\n") |> drop.(String.replace(name, "\\", "/"), keep)
    edited = Enum.join(lines, "\n")
    back = through.(edited, spir)
    canon = Document.to_spi_tested(back)
    nonblank = fn text -> text |> String.split("\n") |> Enum.map(&String.trim_trailing/1) |> Enum.reject(blank?) end
    kept_content = nonblank.(canon) == nonblank.(edited)
    again = through.(canon, spir)
    fixpoint = Document.to_spi_tested(again) == canon
    spir_kept = spir == "" or Document.to_spir_tested(back) == spir
    test_names = fn text -> text |> Document.parse_spi(spir) |> Document.tests() |> Enum.map(& &1.name) end
    names_kept = test_names.(canon) == test_names.(spi)
    left = edited |> String.split("\n") |> Enum.count(&String.starts_with?(&1, "/// ### "))
    target = Path.join(out, name)
    File.mkdir_p!(Path.dirname(target))
    File.write!(target, canon)
    paired = if spir != "", do: " (paired: #{MapSet.size(keep)} .spir headings kept, .spir unchanged #{spir_kept})", else: ""
    IO.puts("HEADINGS #{name}: removed #{removed}, left #{left}; canonical #{canon == edited} content kept #{kept_content} fixpoint #{fixpoint} test names kept #{names_kept}#{paired}")
    if kept_content and fixpoint and names_kept and spir_kept, do: removed, else: :failed
  end

removed = results |> Enum.filter(&is_integer/1) |> Enum.sum()
IO.puts("HEADINGS total #{length(results)} files, removed #{removed}, failed #{Enum.count(results, &(&1 == :failed))}")
