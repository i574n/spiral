defmodule Spiral.Cells.NewProject do
  @templates Path.expand(Path.join([__DIR__, "..", "..", "..", "priv", "new_project"]))
  @placeholder "PROJECT_NAME"
  @dotfiles %{"gitignore" => ".gitignore", "gitattributes" => ".gitattributes", "editorconfig" => ".editorconfig"}

  @type refusal :: {:invalid_name, String.t()} | {:not_empty, Path.t()} | {:is_file, Path.t()}

  @spec create(Path.t(), String.t()) :: {:ok, [Path.t()]} | {:error, refusal()}
  def create(path, name) do
    cond do
      not Regex.match?(~r/\A[a-z][a-z0-9_]*\z/, name) -> {:error, {:invalid_name, name}}
      File.exists?(path) and not File.dir?(path) -> {:error, {:is_file, path}}
      File.dir?(path) and File.ls!(path) != [] -> {:error, {:not_empty, path}}
      true -> {:ok, write_templates(path, name)}
    end
  end

  @spec refusal_text(refusal()) :: String.t()
  def refusal_text({:invalid_name, name}), do: "the project name #{inspect(name)} must be a lowercase Spiral module name (a-z, digits, _)"
  def refusal_text({:not_empty, path}), do: "#{path} is not empty; spiral.new only writes into a new or empty directory"
  def refusal_text({:is_file, path}), do: "#{path} is a file; spiral.new only writes into a new or empty directory"

  @spec epic_command(String.t()) :: String.t()
  def epic_command(name) do
    id = name |> String.upcase() |> String.replace("_", "-")
    "eoie agile add <backlog root> #{id} Epic P2 D5 \"#{name}: starter plan (units module, c/wgsl/lua targets, scripts/gate.ps1 green)\" #{name}"
  end

  defp write_templates(path, name) do
    for template <- Path.wildcard(Path.join(@templates, "**/*"), match_dot: true), File.regular?(template) do
      relative = template |> Path.relative_to(@templates) |> placed_name() |> String.replace(@placeholder, name)
      target = Path.join(path, relative)
      File.mkdir_p!(Path.dirname(target))
      File.write!(target, template |> File.read!() |> String.replace(@placeholder, name))
      relative
    end
    |> Enum.sort()
  end

  defp placed_name(relative), do: Map.get(@dotfiles, relative, relative)
end
