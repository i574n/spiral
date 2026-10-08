defmodule Spiral.KinoLiveTest do
  use ExUnit.Case, async: false

  @moduletag timeout: 900_000
  @budget 600_000

  alias Spiral.Kino.{Result, SpiralError, Toolchain}

  setup do
    dll = Toolchain.compiler_dll([])
    rustc = Toolchain.rustc([])
    dotnet = Toolchain.dotnet([])
    core = Path.join(Toolchain.package_dir([]), "core/package.spiproj")

    if File.regular?(dll) and File.regular?(core) and is_binary(dotnet) and is_binary(rustc) do
      :ok
    else
      {:skip, "Spiral compiler, core package, or rustc is not installed"}
    end
  end

  test "compiles and runs a cell" do
    assert {:ok, %Result{value: "49", stdout: stdout, exit_status: 0}} =
             Spiral.Kino.run(
               """
               inl square x = x * x

               console.write_line "Hello from Spiral!"
               square 7i32
               """,
               timeout: @budget
             )

    assert stdout =~ "Hello from Spiral!"
  end

  test "a print with no value still runs" do
    assert {:ok, %Result{value: nil, stdout: stdout, exit_status: 0}} =
             Spiral.Kino.run("console.write_line \"Hello from Spiral!\"\n", timeout: @budget)

    assert stdout =~ "Hello from Spiral!"
  end

  test "imports a package and runs it" do
    root = Path.expand("../fixtures", __DIR__)

    assert {:ok, %Result{value: "42", exit_status: 0}} =
             Spiral.Kino.run("///- --package shared\noffset.add_one 41i32",
               root: root,
               timeout: @budget
             )
  end

  test "a type error is a SpiralError" do
    assert {:error, %SpiralError{message: message}} =
             Spiral.Kino.run("1i32 + \"a\"", timeout: @budget)

    assert message =~ "i32"
    assert message =~ "string"
  end
end
