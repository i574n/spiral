defmodule Spiral.Cells.NewProjectTest do
  use ExUnit.Case, async: true
  alias Spiral.Cells.NewProject

  test "a new project gets the dotfiles, the package and a starter module named after it" do
    dir = Path.join(Spiral.Cells.TestHelpers.tmp_dir!("new_project"), "ledger")

    assert {:ok, files} = NewProject.create(dir, "ledger")
    assert files == [".editorconfig", ".gitattributes", ".gitignore", "scripts/gate.ps1", "scripts/probe.ps1", "src/ledger.spi", "src/package.spiproj"]
    assert File.read!(Path.join(dir, "scripts/gate.ps1")) =~ "spiral.notebook"
    assert File.read!(Path.join(dir, "scripts/probe.ps1")) =~ "--probe"
    assert File.read!(Path.join(dir, "src/package.spiproj")) == "packages: |core-\nmodules:\n    ledger\n"
    assert File.read!(Path.join(dir, "src/ledger.spi")) =~ "test ledger static ="
    refute File.read!(Path.join(dir, "src/ledger.spi")) =~ "PROJECT_NAME"
    assert NewProject.epic_command("ledger_v2") =~ "eoie agile add <backlog root> LEDGER-V2 Epic P2 D5"
  end

  test "a directory that already holds files is refused, and so is a name that is not a module name" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("new_project_busy")
    File.write!(Path.join(dir, "keep.txt"), "x")

    assert {:error, {:not_empty, ^dir}} = NewProject.create(dir, "busy")
    assert {:error, {:invalid_name, "Ledger"}} = NewProject.create(Path.join(dir, "fresh"), "Ledger")
    file = Path.join(dir, "keep.txt")
    assert {:error, {:is_file, ^file}} = NewProject.create(file, "busy")
    assert File.ls!(dir) == ["keep.txt"]
  end
end
