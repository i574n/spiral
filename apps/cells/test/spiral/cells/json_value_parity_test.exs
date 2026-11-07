defmodule Spiral.Cells.JsonValueParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Domain

  @home Path.expand("../../../../../..", __DIR__)

  @edges [
    ~S({"a":1,"a":2}),
    ~S("\ud800"),
    ~S("\udc00x"),
    ~S("𐀀"),
    ~S("\ud800A"),
    ~S("é\/\b\f\n\r\t\"\\"),
    ~S("\u0000"),
    ~S("\x"),
    ~S("\u12zz"),
    "\"a\x7fb\"",
    "\"a\tb\"",
    <<34, 0xED, 0xA0, 0x80, 34>>,
    <<34, 0xF4, 0x90, 0x80, 0x80, 34>>,
    <<34, 0xC0, 0x80, 34>>,
    <<34, 0xE2, 0x82, 34>>,
    <<34, 0xFF, 34>>,
    "\"café \u{1F600}\"",
    ~S([1,]),
    ~S({"a":1,}),
    ~S({"a"}),
    ~S({a:1}),
    ~S({"a":1 "b":2}),
    ~S([1 2]),
    ~S(01),
    ~S(-01),
    ~S(1.),
    ~S(.5),
    ~S(-),
    ~S(+1),
    ~S(1e),
    ~S(1e+),
    ~S(1e5),
    ~S(1E-3),
    ~S(-0),
    ~S(-0.0),
    ~S(1.5E+3),
    ~S([] x),
    ~S([]]),
    ~S(nul),
    ~S(truex),
    ~S(True),
    "",
    "   ",
    "  \r\n\t[]\r\n",
    "\f[]",
    "[ ]",
    ~S({"a" : [ true , false , null ] }),
    ~S({"output":"hi","command_result":"{\"output\":\"inner\"}"}),
    ~S([[[[[[[[[[[]]]]]]]]]]]),
    ~S([[[[[[[[[[[]]]]]]]]]]),
    ~S({"":{"":""}})
  ]

  defp tracked(pattern) do
    for repo <- File.ls!(@home), dir = Path.join(@home, repo), File.exists?(Path.join(dir, ".git")),
        {out, 0} = System.cmd("git", ["-C", dir, "ls-files", "-z", "--", pattern]),
        rel <- String.split(out, <<0>>, trim: true),
        file = Path.join(dir, rel),
        File.regular?(file),
        do: file
  end

  defp json_files do
    tracked("*.json") |> Enum.filter(&(File.stat!(&1).size <= 262_144))
  end

  defp hex4(n), do: n |> Integer.to_string(16) |> String.pad_leading(4, "0")

  defp ascii_escaped(json) do
    for <<c::utf8 <- json>>, into: "" do
      cond do
        c < 128 -> <<c>>
        c < 0x10000 -> "\\u" <> hex4(c)
        true -> "\\u" <> hex4(0xD800 + div(c - 0x10000, 0x400)) <> "\\u" <> hex4(0xDC00 + rem(c - 0x10000, 0x400))
      end
    end
  end

  defp encoded_docs do
    tracked("*.spi")
    |> Enum.take(300)
    |> Enum.map(&{&1, File.read!(&1)})
    |> Enum.filter(fn {_, text} -> String.valid?(text) end)
    |> Enum.flat_map(fn {file, text} ->
      value = %{"path" => file, "bytes" => byte_size(text), "ratio" => byte_size(text) / 7, "lines" => String.split(text, "\n"), "empty" => [], "nested" => [%{"a" => nil, "b" => true}, -0.5, 1.0e-7]}
      compact = JSON.encode!(value)
      [compact, IO.iodata_to_binary(:json.format(value)), ascii_escaped(compact)]
    end)
  end
  defp variants(text) do
    half = binary_part(text, 0, div(byte_size(text), 2))
    [text, half, text <> "x", text <> " ,", String.replace(text, ":", "=", global: false), String.replace(text, "\"", "\"\t", global: false), Regex.replace(~r/([}\]])\s*$/, text, ",\\1")]
  end

  defp oracle(text) do
    case JSON.decode(text) do
      {:ok, value} -> {:ok, value}
      {:error, _} -> :error
    end
  end

  defp spiral(text) do
    case Domain.json_canonical(text) do
      "" -> :error
      canonical -> JSON.decode(canonical)
    end
  end

  test "the Spiral JSON parser accepts exactly what JSON.decode accepts and reads the same values" do
    files = json_files()
    docs = Enum.map(files, &File.read!/1) ++ encoded_docs()
    texts = Enum.flat_map(docs, &variants/1) ++ @edges
    results = Enum.map(texts, &{&1, oracle(&1), spiral(&1)})
    accepted = Enum.count(results, fn {_, o, _} -> o != :error end)
    differing = Enum.reject(results, fn {_, o, s} -> o == s end)
    IO.puts("json value parity: #{length(files)} files + #{length(docs) - length(files)} encoded docs, #{length(texts)} texts compared (#{accepted} accepted), #{length(differing)} differ")
    assert length(files) > 10 and length(docs) > 300, "corpus too small (#{length(files)} files, #{length(docs)} docs)"
    assert accepted > 20 and accepted < length(texts)
    assert differing == [], "first differing: #{differing |> List.first() |> inspect(limit: 12, printable_limit: 160)}"
  end
end
