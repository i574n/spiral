defmodule Spiral.Cells.BuildersDepsParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Builders

  @home Path.expand("../../../../../..", __DIR__)

  @tokens ["serde", "serde=\"1.0\"", "serde='1.0'", "rand=0.8", "x=", "=y", "a=b=c", "tokio[full]", "t=\"{ version = \\\"1\\\" }\"", "", "q=\"", "q=\"\"", "café=1", "é=\"́\"", "dup", "dup=2"]

  defp tracked(pattern) do
    for repo <- File.ls!(@home), dir = Path.join(@home, repo), File.exists?(Path.join(dir, ".git")),
        {out, 0} = System.cmd("git", ["-C", dir, "ls-files", "-z", "--", pattern]),
        rel <- String.split(out, <<0>>, trim: true),
        file = Path.join(dir, rel),
        File.regular?(file),
        do: file
  end

  defp oracle_dep(token) do
    cond do
      String.contains?(token, "=") ->
        [name, version] = String.split(token, "=", parts: 2)
        %{name: name, version: oracle_unquote(version), raw: token}

      String.ends_with?(token, "]") ->
        %{name: token, version: nil, raw: token}

      true ->
        %{name: token, version: "*", raw: token}
    end
  end

  defp oracle_unquote(value) do
    cond do
      oracle_quoted?(value, "\"") -> String.slice(value, 1..-2//1)
      oracle_quoted?(value, "'") -> String.slice(value, 1..-2//1)
      true -> value
    end
  end

  defp oracle_quoted?(value, mark), do: String.starts_with?(value, mark) and String.ends_with?(value, mark) and byte_size(value) >= 2

  defp safe_split(text) do
    text |> Builders.split() |> elem(0)
  rescue
    ArgumentError -> []
  end

  defp oracle_with_crates(builders, []), do: builders

  defp oracle_with_crates(builders, crates) do
    declared = Enum.map(crates, &oracle_dep/1)

    Enum.map(builders, fn
      %{tool: :rust} = builder ->
        named = MapSet.new(builder.deps, & &1.name)
        %{builder | deps: builder.deps ++ Enum.reject(declared, &MapSet.member?(named, &1.name))}

      builder ->
        builder
    end)
  end

  test "with_crates declares crates through the Spiral dep parser exactly like the old Elixir one" do
    split = &safe_split/1
    builder_sets = tracked("*.spi") |> Enum.map(&File.read!/1) |> Enum.filter(&String.valid?/1) |> Enum.map(split) |> Enum.reject(&(&1 == [])) |> Enum.uniq()
    real = builder_sets |> List.flatten() |> Enum.flat_map(&Map.get(&1, :deps, [])) |> Enum.map(& &1.raw) |> Enum.uniq()
    crate_sets = [[] | Enum.map(@tokens ++ real, &[&1])] ++ [@tokens, real]
    synthetic = [[], split.("///> rust -d dup serde=2"), split.("///> rust\n///> gleam -d x"), split.("///> c")]
    cases = for b <- builder_sets ++ synthetic, c <- crate_sets, do: {b, c}
    differing = Enum.reject(cases, fn {b, c} -> Builders.with_crates(b, c) == oracle_with_crates(b, c) end)
    IO.puts("builders deps parity: #{length(builder_sets)} builder sets, #{length(real)} real dep tokens, #{length(cases)} cases compared, #{length(differing)} differ")
    assert length(builder_sets) > 20 and length(cases) > 1000
    assert differing == [], "first differing: #{differing |> List.first() |> inspect(printable_limit: 300)}"
  end
end
