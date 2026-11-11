defmodule Spiral.Cells.MemoShapeParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Memo

  @home Path.expand("../../../../../..", __DIR__)

  defp oracle(header, code) do
    cond do
      match = Regex.run(~r/^(?:(?:and|:&)\s+)?(?:inl|let|inm|inb|:=|:~)(?:\s+(?:rec|\^))?\s+\(([^)\s]+)\)/, header) ->
        {:definition, ["(" <> Enum.at(match, 1) <> ")"], [Enum.at(match, 1)]}

      match = Regex.run(~r/^(?:(?:and|:&)\s+)?(?:inl|let|inm|inb|:=|:~)(?:\s+(?:rec|\^))?\s+([^\s(:=]+)/u, header) ->
        if Enum.at(match, 1) in ["_", "()"], do: {:other, [], []}, else: {:definition, [Enum.at(match, 1)], []}

      match = Regex.run(~r/^(?:(?:and|:&)\s+)?(?:type|union|nominal|prototype|:==|:\||:!|:\?)(?:\s+(?:rec|\^))?\s+([^\s=]+)/u, header) ->
        cases = ~r/\|\s*([A-Z][\w']*)/u |> Regex.scan(code, capture: :all_but_first) |> List.flatten()
        {:definition, [Enum.at(match, 1) | cases], []}

      match = Regex.run(~r/^(?:instance|:\+)\s+(\S+)/u, header) ->
        {:definition, [Enum.at(match, 1)], []}

      true ->
        {:other, [], []}
    end
  end

  @identifier ~r/[A-Za-z_][\w']*/u

  defp facts_oracle(header, code, names) do
    tokens = @identifier |> Regex.scan(code) |> List.flatten() |> Enum.uniq() |> Enum.reject(&(&1 in names))
    {tokens, Regex.match?(~r/^(?:instance|:\+)\s/, header)}
  end

  @qualified_name ~r/[A-Za-z_][\w']*(?:(?:\.|::)[A-Za-z_][\w']*)+/u

  defp references_oracle(code, names) do
    qualified =
      @qualified_name
      |> Regex.scan(code)
      |> List.flatten()
      |> Enum.uniq()
      |> Enum.map(fn token ->
        parts = String.split(token, [".", "::"])
        {Enum.join(Enum.drop(parts, -1), "."), List.last(parts)}
      end)

    heads = Regex.replace(@qualified_name, code, fn token -> token |> String.split([".", "::"]) |> hd() end)
    unqualified = @identifier |> Regex.scan(heads) |> List.flatten() |> Enum.uniq() |> Enum.reject(&(&1 in names))
    {unqualified, qualified}
  end

  @open_statement ~r/(?:\bopen|:<)\s+([A-Za-z_][\w']*(?:(?:\.|::)[A-Za-z_][\w']*)*)/u

  defp opens_oracle(code), do: @open_statement |> Regex.scan(code, capture: :all_but_first) |> List.flatten() |> Enum.map(&String.replace(&1, "::", ".")) |> Enum.uniq()

  defp strip_oracle(code), do: code |> String.split("\n") |> Enum.map_join("\n", &(&1 |> String.to_charlist() |> strip_chars(false, [])))

  defp strip_chars([], _in_string, acc), do: acc |> Enum.reverse() |> List.to_string()
  defp strip_chars([?\\, char | rest], true, acc), do: strip_chars(rest, true, [char, ?\\ | acc])
  defp strip_chars([?" | rest], in_string, acc), do: strip_chars(rest, not in_string, [?" | acc])
  defp strip_chars([?/, ?/ | _rest], false, acc), do: strip_chars([], false, acc)
  defp strip_chars([char | rest], in_string, acc), do: strip_chars(rest, in_string, [char | acc])

  defp package_oracle(program) do
    ~r/^\/\/\/- (.*)$/m
    |> Regex.scan(program)
    |> Enum.flat_map(fn [_, flags] -> ~r/--package\s+(\S+)/ |> Regex.scan(flags) |> Enum.map(fn [_, path] -> path end) end)
  end

  defp tracked_spi do
    for repo <- File.ls!(@home), dir = Path.join(@home, repo), File.exists?(Path.join(dir, ".git")),
        {out, 0} = System.cmd("git", ["-C", dir, "ls-files", "-z", "--", "*.spi"]),
        rel <- String.split(out, <<0>>, trim: true),
        file = Path.join(dir, rel),
        File.regular?(file),
        do: file
  end

  defp blocks(text) do
    text
    |> String.replace("\r\n", "\n")
    |> String.split("\n")
    |> Enum.chunk_while(nil, &chunk/2, &finish/1)
  end

  defp chunk(line, nil), do: if(top_level?(line), do: {:cont, {line, []}}, else: {:cont, nil})
  defp chunk(line, {header, body}), do: if(top_level?(line), do: {:cont, {header, Enum.reverse(body)}, {line, []}}, else: {:cont, {header, [line | body]}})

  defp finish(nil), do: {:cont, nil}
  defp finish({header, body}), do: {:cont, {header, Enum.reverse(body)}, nil}

  defp top_level?(line), do: line != "" and not String.starts_with?(line, [" ", "\t", "//"])

  defp cases do
    case System.get_env("SPIRAL_MEMO_PARITY_CASES") do
      nil ->
        for file <- tracked_spi(), {header, body} <- file |> File.read!() |> blocks() do
          {file, header, Enum.join([header | body], "\n")}
        end

      path ->
        for [file, header, code] <- path |> File.read!() |> JSON.decode!(), do: {file, header, code}
    end
  end

  @tag timeout: 900_000
  test "the Spiral block shape matches the old Elixir regexes on every block of every tracked .spi" do
    cases = cases()

    differ =
      for {file, header, code} <- cases, (old = oracle(header, code)) != (new = Memo.block_shape(header, code)),
          do: {file, header, old, new}

    IO.puts("memo shape parity: #{length(cases)} blocks, #{length(differ)} differ")
    assert length(cases) > 1000
    assert differ == [], "first difference: #{differ |> List.first() |> inspect(printable_limit: 400)}"
  end

  @tag timeout: 900_000
  test "the Spiral block facts match the old Elixir token scan and instance regex on every block of every tracked .spi" do
    cases = cases()

    differ =
      for {file, header, code} <- cases,
          {kind, names, ops, tokens, instance, _, _} = Memo.block_facts(header, code),
          {kind, names, ops} == Memo.block_shape(header, code),
          (old = facts_oracle(header, code, names)) != (new = {tokens, instance}),
          do: {file, header, old, new}

    IO.puts("memo facts parity: #{length(cases)} blocks, #{length(differ)} differ")
    assert length(cases) > 1000
    assert differ == [], "first difference: #{differ |> List.first() |> inspect(printable_limit: 400)}"
  end

  @tag timeout: 900_000
  test "the Spiral block references match the old qualified-name and identifier regexes on every block of every tracked .spi" do
    cases = cases()

    differ =
      for {file, header, code} <- cases,
          {_, names, _, _, _, unqualified, qualified} = Memo.block_facts(header, code),
          (old = references_oracle(code, names)) != (new = {unqualified, qualified}),
          do: {file, header, old, new}

    IO.puts("memo references parity: #{length(cases)} blocks, #{length(differ)} differ")

    for {file, header, {old_unq, old_q}, {new_unq, new_q}} <- Enum.take(differ, 5) do
      IO.puts("differ #{file} | #{String.slice(header, 0, 60)} | unq old-only #{inspect(old_unq -- new_unq, limit: 10)} new-only #{inspect(new_unq -- old_unq, limit: 10)} order #{old_unq == new_unq} | qual old-only #{inspect(old_q -- new_q, limit: 6)} new-only #{inspect(new_q -- old_q, limit: 6)} order #{old_q == new_q}")
    end

    assert length(cases) > 1000
    assert differ == [], "first difference: #{differ |> List.first() |> inspect(printable_limit: 400)}"
  end

  @tag timeout: 900_000
  test "the Spiral opened names match the old open-statement regex on every block of every tracked .spi" do
    cases = cases()

    differ =
      for {file, header, code} <- cases, (old = opens_oracle(code)) != (new = Memo.opened_names(code)), do: {file, header, old, new}

    IO.puts("memo opens parity: #{length(cases)} blocks, #{length(differ)} differ")
    for {file, header, old, new} <- Enum.take(differ, 5), do: IO.puts("differ #{file} | #{String.slice(header, 0, 60)} | old-only #{inspect(old -- new)} new-only #{inspect(new -- old)} order #{old == new}")
    assert length(cases) > 1000
    assert differ == [], "first difference: #{differ |> List.first() |> inspect(printable_limit: 400)}"
  end

  @tag timeout: 900_000
  test "the Spiral comment stripping matches the old per-line strip on every block of every tracked .spi" do
    cases = cases()
    differ = for {file, header, code} <- cases, (old = strip_oracle(code)) != Spiral.Cells.Domain.strip_comments(code), do: {file, header, old}
    IO.puts("memo strip parity: #{length(cases)} blocks, #{length(differ)} differ")
    assert length(cases) > 1000
    assert differ == [], "first difference: #{differ |> List.first() |> inspect(printable_limit: 400)}"
  end

  test "the Spiral package flags match the old ///- and --package regexes on the Cells notebooks and crafted programs" do
    files = Path.wildcard(Path.expand("../../../spi/*.spi", __DIR__)) |> Enum.map(&File.read!/1)
    crafted = ["///- --package .. --package\t../lib\n:# x =", "///- --package\r\n///-  --package a\r\n", "///- x--package b c", "//- --package no\n///---package no", "///- --package"]
    programs = files ++ crafted
    differ = for program <- programs, (old = package_oracle(program)) != Memo.package_paths(program), do: {String.slice(program, 0, 80), old}
    IO.puts("memo package parity: #{length(programs)} programs, #{length(differ)} differ")
    assert length(files) > 10
    assert differ == []
  end
end
