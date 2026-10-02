defmodule Spiral.KinoTest do
  use ExUnit.Case, async: false

  import ExUnit.CaptureIO

  alias Spiral.Kino.{ProcessError, Result, SpiralError, TimeoutError}

  @rust """
  fn spiral_main() -> i32 {
      let mut v0: Rc<str> = "{ let mut out = std::io::stdout(); let _ = <std::io::Stdout as std::io::Write>::write_all(&mut out, $0.as_ref().as_bytes()); let _ = <std::io::Stdout as std::io::Write>::write_all(&mut out, &[10u8]); let _ = <std::io::Stdout as std::io::Write>::flush(&mut out); }";
      let mut v1: Rc<str> = Rc::<str>::from("Hello from Spiral!");
      Fable.Core.RustInterop.emitRustExpr v1.clone() v0 ;
      49i32
  }
  fn main() {
      let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
      std::process::exit(main.join().unwrap());
  }
  """

  defp compile_ok(_ctx), do: {:ok, @rust}
  defp rustc_ok(_ctx), do: :ok

  defp run_value(output) do
    fn _ctx -> {:ok, %{exit_status: 0, output: output, duration_ms: 4}} end
  end

  test "value and stdout come from the patched binary" do
    assert {:ok, %Result{} = result} =
             Spiral.Kino.run(
               """
               inl square x = x * x
               console.write_line "Hello from Spiral!"
               square 7i32
               """,
               compile: &compile_ok/1,
               rustc: &rustc_ok/1,
               execute: run_value("Hello from Spiral!\nSPIRAL_KINO_VALUE:49\n"),
               timeout: 30_000
             )

    assert result.value == "49"
    assert result.stdout == "Hello from Spiral!"
    assert result.source =~ "inl main () : i32 ="
    assert result.source =~ "square 7i32"
    assert result.exit_status == 0
  end

  test "print_code puts the patched Rust in front of stdout" do
    assert {:ok, %Result{stdout: stdout, value: "3"}} =
             Spiral.Kino.run("1i32 + 2i32",
               print_code: true,
               compile: &compile_ok/1,
               rustc: &rustc_ok/1,
               execute: run_value("SPIRAL_KINO_VALUE:3\n")
             )

    assert stdout =~ "v1.as_ref().as_bytes()"
    refute stdout =~ "emitRustExpr"
  end

  test "a unit body is compiled again as 0i32 and has no value" do
    compile = fn %{source: source} ->
      if String.contains?(source, "0i32") do
        {:ok, "fn main() {\n    std::process::exit(main.join().unwrap());\n}\n"}
      else
        {:error, "Unification failure.\nGot:      ()\nExpected: i32"}
      end
    end

    assert {:ok, %Result{value: nil, stdout: "Hello", source: source}} =
             Spiral.Kino.run("console.write_line \"Hello\"",
               compile: compile,
               rustc: &rustc_ok/1,
               execute: run_value("Hello\n")
             )

    assert source =~ "0i32"
  end

  test "a compiler rejection is a SpiralError" do
    compile = fn _ ->
      {:error, "main.spi:1:1: Unification failure.\nGot: string\nExpected: i32"}
    end

    assert {:error, %SpiralError{message: message, details: details}} =
             Spiral.Kino.run("1i32 + \"a\"", compile: compile, timeout: 30_000)

    assert message =~ "Got: string"
    assert details =~ "inl main () : i32 ="
  end

  test "timeout" do
    execute = fn _ -> {:error, {:timeout, %{timeout: 3_000, output: "partial"}}} end

    assert {:error, %TimeoutError{timeout: 3_000, message: message}} =
             Spiral.Kino.run("1i32",
               compile: &compile_ok/1,
               rustc: &rustc_ok/1,
               execute: execute,
               timeout: 3_000
             )

    assert message =~ "timed out after 3s"
  end

  test "a missing compiler is a ProcessError" do
    assert {:error, %ProcessError{message: message}} =
             Spiral.Kino.run("1i32",
               compiler_dll: "C:/missing/SpiralCompiler.dll",
               timeout: 30_000
             )

    assert message =~ "was not found"
  end

  test "a package import is linked into the cell and the package stays in place" do
    fixture = Path.expand("../fixtures/shared/offset.spi", __DIR__)
    root = Path.expand("../fixtures", __DIR__)

    compile = fn %{spi_path: spi} ->
      dir = Path.dirname(spi)
      assert File.read!(Path.join(dir, "package.spiproj")) =~ "shared-"
      assert File.regular?(Path.join(dir, "shared/offset.spi"))

      {:ok,
       """
       fn main() {
           std::process::exit(main.join().unwrap());
       }
       """}
    end

    assert {:ok, %Result{value: "42"}} =
             Spiral.Kino.run("///- --package shared\noffset.add_one 41i32",
               compile: compile,
               rustc: &rustc_ok/1,
               execute: run_value("SPIRAL_KINO_VALUE:42\n"),
               root: root,
               timeout: 30_000
             )

    assert File.regular?(fixture)
  end

  test "a missing package is a ProcessError" do
    assert {:error, %ProcessError{message: message}} =
             Spiral.Kino.run("///- --package missing\n1i32",
               root: Path.expand("../fixtures", __DIR__),
               timeout: 30_000
             )

    assert message =~ "was not found"
  end

  test "invalid options" do
    assert_raise ArgumentError, ~r/:timeout/, fn -> Spiral.Kino.run("1", timeout: 0) end

    assert_raise ArgumentError, ~r/unknown Spiral backend/, fn ->
      Spiral.Kino.run("///> gleam\n1")
    end
  end

  describe "eval!/2" do
    test "prints stdout and returns the result" do
      output =
        capture_io(fn ->
          assert %Result{value: "49"} =
                   Spiral.Kino.eval!("square 7i32",
                     compile: &compile_ok/1,
                     rustc: &rustc_ok/1,
                     execute: run_value("Hello from Spiral!\nSPIRAL_KINO_VALUE:49\n")
                   )
        end)

      assert output == "Hello from Spiral!\n"
    end

    test "returns Kino.nothing() for empty code and for a unit cell" do
      assert Spiral.Kino.eval!("   \n") == Kino.nothing()

      compile = fn %{source: source} ->
        if String.contains?(source, "0i32"),
          do: {:ok, "fn main() {\n    std::process::exit(main.join().unwrap());\n}\n"},
          else: {:error, "Got:      ()\nExpected: i32"}
      end

      capture_io(fn ->
        assert Spiral.Kino.eval!("console.write_line \"hi\"",
                 compile: compile,
                 rustc: &rustc_ok/1,
                 execute: run_value("hi\n")
               ) == Kino.nothing()
      end)
    end

    test "raises on Spiral errors" do
      assert_raise SpiralError, ~r/Unification failure/, fn ->
        Spiral.Kino.eval!("x", compile: fn _ -> {:error, "Unification failure."} end)
      end
    end
  end

  test "Kino.Render shows the value" do
    assert %{type: :terminal_text, text: "49"} = Kino.Render.to_livebook(%Result{value: "49"})
    assert %{type: :plain_text, text: "(no value)"} = Kino.Render.to_livebook(%Result{})
  end
end
