defmodule Spiral.Cells.TargetsHostParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.{Domain, Targets}

  @languages ["fsharp", "FSharp", "fs", "FS", "python", "Py", "py", "lua", "LUA", "javascript", "JS", "js", "powershell", "PowerShell", "pwsh", "", "rust", "spiral", "c", "f#", " fs", "fs ", "caf\u00e9", "\u0130", "PYTHON", "Lua\u0301"]
  @paths ["cl", "cl.exe", "CL.EXE", "cl.exe.exe", "/usr/bin/cl", "C:\\VS\\bin\\cl.exe", "gcc", "clang", "cl.ex", "xcl.exe", "cl.exe ", "Cl.Exe", "", "dir/cl.EXE.exe"]

  defp old_host_key(%{kind: :fsharp}), do: {:fsharp, "fsharp"}

  defp old_host_key(%{kind: :code, language: language}) when is_binary(language) do
    case String.downcase(language) do
      "fsharp" -> {:fsharp, "fsharp"}
      "fs" -> {:fsharp, "fsharp"}
      "python" -> {:python, "python"}
      "py" -> {:python, "python"}
      "lua" -> {:lua, "lua"}
      "javascript" -> {:javascript, "javascript"}
      "js" -> {:javascript, "javascript"}
      "powershell" -> {:powershell, "powershell"}
      "pwsh" -> {:powershell, "powershell"}
      _ -> nil
    end
  end

  defp old_host_key(_), do: nil

  defp old_extension("fsharp"), do: ".fsx"
  defp old_extension("python"), do: ".py"
  defp old_extension("lua"), do: ".lua"
  defp old_extension("javascript"), do: ".js"
  defp old_extension("powershell"), do: ".ps1"

  defp old_cl?(path), do: path |> Path.basename() |> String.downcase() |> String.trim_trailing(".exe") == "cl"

  test "host languages, their extensions and the cl check match the old Elixir tables" do
    cells = [%{kind: :fsharp}, %{kind: :markdown}, %{kind: :code, language: nil}] ++ Enum.map(@languages, &%{kind: :code, language: &1})
    keys = Enum.reject(cells, &(Targets.host_key(&1) == old_host_key(&1)))
    names = for c <- cells, {_, name} <- [old_host_key(c)], do: name
    extensions = Enum.reject(Enum.uniq(names), &(Domain.host_extension(&1) == old_extension(&1)))
    cl = Enum.reject(@paths, &((Domain.is_cl_compiler(Path.basename(&1)) == "true") == old_cl?(&1)))
    IO.puts("targets host parity: #{length(cells)} cells, #{length(Enum.uniq(names))} hosts, #{length(@paths)} paths, #{length(keys) + length(extensions) + length(cl)} differ")
    assert length(Enum.uniq(names)) == 5
    assert {keys, extensions, cl} == {[], [], []}
  end
end