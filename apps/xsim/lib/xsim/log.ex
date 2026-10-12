defmodule Xsim.Log do
  def write(path, deliveries) do
    lines = Enum.map(deliveries, fn {index, event} -> JSON.encode!([index | event |> Tuple.to_list() |> encode_kind()]) end)
    File.write!(path, Enum.join(lines, "\n") <> "\n")
  end

  def read(path) do
    path
    |> File.stream!()
    |> Stream.map(&String.trim/1)
    |> Stream.reject(&(&1 == ""))
    |> Enum.map(fn line ->
      [index, kind | fields] = JSON.decode!(line)
      {index, List.to_tuple([String.to_existing_atom(kind) | fields])}
    end)
  end

  defp encode_kind([kind | fields]), do: [Atom.to_string(kind) | fields]
end
