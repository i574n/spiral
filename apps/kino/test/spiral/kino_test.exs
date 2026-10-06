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

  defp package_dir!(proj) do
    [_, dir] = Regex.run(~r/^packageDir:\s*(.+)$/m, proj)
    String.trim(dir)
  end

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

  test "a rust contract cell with a unit body is compiled again as 0i32" do
    compile = fn %{source: source, backend: backend} ->
      assert backend == "Rust"

      if String.contains?(source, "0i32") do
        {:ok, "fn main() {}\n"}
      else
        {:error, "Got:      ()\nExpected: i32"}
      end
    end

    assert {:ok, %Result{value: nil}} =
             Spiral.Kino.run("trace Verbose (fun () => \"\") id",
               compile: compile,
               builders: [
                 %{
                   tool: :rust,
                   raw: "rust -c",
                   contract: "",
                   wasm: nil,
                   deps: [],
                   cleanup: nil,
                   target: nil,
                   env: nil
                 }
               ],
               target: fn %{builder: builder} ->
                 assert builder.tool == :rust
                 assert builder.contract == ""
                 {:ok, %{exit_status: 0, output: "", duration_ms: 1}}
               end
             )
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

  test "a ///- --timeout directive wins over the caller's :timeout (smart cells always pass one)" do
    home = self()

    execute = fn _ ->
      send(home, {:deadline, Process.get(:spiral_kino_deadline)})
      {:error, {:timeout, %{timeout: 0, output: ""}}}
    end

    started = System.monotonic_time(:millisecond)

    assert {:error, %TimeoutError{timeout: 900_000, message: message}} =
             Spiral.Kino.run("///- --test --timeout 900000\n1i32",
               compile: &compile_ok/1,
               rustc: &rustc_ok/1,
               execute: execute,
               timeout: 300_000
             )

    assert message =~ "timed out after 900s"
    assert_received {:deadline, deadline}
    assert deadline - started > 300_000
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
      proj = File.read!(Path.join(dir, "package.spiproj"))
      assert proj =~ "shared-"
      package_dir = package_dir!(proj)
      assert package_dir =~ "kino-mounts"
      refute String.starts_with?(package_dir, dir)
      assert File.regular?(Path.join(package_dir, "shared/offset.spi"))
      refute File.dir?(Path.join(dir, "shared"))

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

  test "an absolute packageDir shares the sibling mount" do
    shares_sibling_mount(fn parent -> "#{String.replace(parent, "\\", "/")}/somewhere" end)
  end

  # dice's own package.spiproj: packageDir: deps/polyglot/deps/spiral/lib (relative) seen through the junction is a
  # second path to the spiral lib the cell already mounts -> the lib is loaded twice ("Got: stream u8 Expected: stream u8").
  test "a relative packageDir shares the sibling mount too" do
    shares_sibling_mount(fn _parent -> "deps/somewhere/lib" end)
  end

  defp shares_sibling_mount(package_dir_of) do
    parent =
      Path.join(System.tmp_dir!(), "spiral_kino_share_#{System.unique_integer([:positive])}")

    spiral = Path.join(parent, "spiral")
    dice = Path.join(parent, "dice_lib")
    File.mkdir_p!(Path.join(spiral, "rust"))
    File.mkdir_p!(Path.join(dice, "lib"))

    File.write!(
      Path.join(spiral, "package.spiproj"),
      "packages:\n    |core-\nmodules:\n    rust/\n        rust\n"
    )

    File.write!(Path.join(spiral, "rust/rust.spi"), "inl add_one (x : i32) : i32 = x + 1i32\n")

    original =
      "packageDir: #{package_dir_of.(parent)}\npackages:\n    |core-\n    spiral-\nmodules:\n    lib/\n        dice\n"

    File.write!(Path.join(dice, "package.spiproj"), original)
    File.write!(Path.join(dice, "lib/dice.spi"), "inl roll (x : i32) : i32 = x\n")

    home = self()

    compile = fn %{spi_path: spi} ->
      dir = Path.dirname(spi)
      package_dir = package_dir!(File.read!(Path.join(dir, "package.spiproj")))
      proj = File.read!(Path.join(package_dir, "dice_lib/package.spiproj"))
      assert proj =~ "packageDir: ..\n"
      refute proj =~ "somewhere"
      assert File.regular?(Path.join(package_dir, "dice_lib/lib/dice.spi"))
      assert File.regular?(Path.join(package_dir, "spiral/rust/rust.spi"))
      assert File.read!(Path.join(dice, "package.spiproj")) == original
      send(home, {:kino_mount, package_dir})

      {:ok,
       """
       fn main() {
           std::process::exit(main.join().unwrap());
       }
       """}
    end

    assert {:ok, %Result{value: "1"}} =
             Spiral.Kino.run(
               "///- --package #{String.replace(spiral, "\\", "/")} --package #{String.replace(dice, "\\", "/")}\n1i32",
               compile: compile,
               rustc: &rustc_ok/1,
               execute: run_value("SPIRAL_KINO_VALUE:1\n"),
               timeout: 30_000
             )

    assert File.regular?(Path.join(dice, "lib/dice.spi"))
    assert_received {:kino_mount, mount}
    Spiral.Kino.Mounts.remove!(mount)
    File.rm_rf!(parent)
  end

  test "two cells share one package directory" do
    root = Path.expand("../fixtures", __DIR__)
    parent = self()

    compile = fn %{spi_path: spi} ->
      send(
        parent,
        {:package_dir, package_dir!(File.read!(Path.join(Path.dirname(spi), "package.spiproj")))}
      )

      {:ok,
       """
       fn main() {
           std::process::exit(main.join().unwrap());
       }
       """}
    end

    assert {:ok, %Result{}} =
             Spiral.Kino.run("///- --package shared\n1i32",
               compile: compile,
               rustc: &rustc_ok/1,
               execute: run_value("SPIRAL_KINO_VALUE:1\n"),
               root: root,
               timeout: 30_000
             )

    assert {:ok, %Result{}} =
             Spiral.Kino.run("///- --package shared\n2i32",
               compile: compile,
               rustc: &rustc_ok/1,
               execute: run_value("SPIRAL_KINO_VALUE:2\n"),
               root: root,
               timeout: 30_000
             )

    assert_received {:package_dir, first}
    assert_received {:package_dir, second}
    assert first == second
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
      Spiral.Kino.run("///> fortran\n1")
    end

    assert {:ok, %Result{exit_status: 0, value: nil}} = Spiral.Kino.run("///> _\nnot spiral")
  end

  test "a bare rust builder stays on rustc" do
    assert {:ok, %Result{value: "1", stdout: ""}} =
             Spiral.Kino.run("///> rust\n1i32",
               compile: fn %{backend: "Rust", source: source} ->
                 refute source =~ "///>"
                 {:ok, "fn main() {}\n"}
               end,
               rustc: &rustc_ok/1,
               execute: run_value("SPIRAL_KINO_VALUE:1\n"),
               target: fn _ -> raise "target" end
             )
  end

  test "rust contract flags call the target and skip the value patch" do
    assert {:ok, %Result{value: nil, stdout: "contract"}} =
             Spiral.Kino.run("///> rust -cd near-token\n1i32",
               compile: fn %{backend: "Rust", source: source} ->
                 refute source =~ "///>"
                 {:ok, "fn spiral_main() { emitRustExpr }\n"}
               end,
               rustc: fn _ -> raise "rustc" end,
               execute: fn _ -> raise "execute" end,
               target: fn %{builder: builder, output_path: path} ->
                 assert builder.contract == ""
                 assert [%{name: "near-token", version: "*"}] = builder.deps
                 assert File.read!(path) =~ "emitRustExpr"
                 {:ok, %{exit_status: 0, output: "contract\n", duration_ms: 1}}
               end
             )
  end

  test "each builder compiles once and the outputs are labeled" do
    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert {:ok, %Result{value: "9", stdout: stdout}} =
             Spiral.Kino.run("///> fsharp\n///> rust\n1i32",
               compile: fn %{backend: backend} ->
                 Agent.update(agent, &(&1 ++ [backend]))
                 {:ok, "fn main() {}\n"}
               end,
               rustc: &rustc_ok/1,
               execute: run_value("SPIRAL_KINO_VALUE:9\n"),
               target: fn %{builder: %{tool: :fsharp}} ->
                 {:ok, %{exit_status: 0, output: "fsharp out", duration_ms: 1}}
               end
             )

    assert Agent.get(agent, & &1) == ["Fsharp", "Rust"]
    assert stdout =~ ".fsx (fsharp)"
    assert stdout =~ "fsharp out"
    assert stdout =~ ".rs (rust)"
  end

  test "a missing spiral executable names the command" do
    assert {:error, %ProcessError{message: message}} =
             Spiral.Kino.run("///> lua\n1i32",
               compile: fn %{backend: "Lua", output_path: path} ->
                 File.write!(path, "print(1)\n")
                 {:ok, "print(1)\n"}
               end,
               spiral: "C:/missing/spiral.exe"
             )

    assert message =~ "spiral lua"
    assert message =~ "was not found"
  end

  test "a builder value is the cell value" do
    assert {:ok, %Result{value: "7", stdout: "", exit_status: 0}} =
             Spiral.Kino.run("///> c\n1i32",
               compile: fn %{backend: "C", source: source} ->
                 refute source =~ "///>"
                 {:ok, "int main(void) { return 7; }\n"}
               end,
               target: fn %{builder: %{tool: :c}} ->
                 {:ok, %{exit_status: 0, output: "", value: "7", duration_ms: 1}}
               end
             )
  end

  test "spiral json output is the cell stdout" do
    inner = JSON.encode!(%{"code" => "return 1", "extension" => "lua", "output" => "printed"})
    outer = JSON.encode!(%{"command_result" => inner})

    assert {:ok, %Result{stdout: "printed", value: nil}} =
             Spiral.Kino.run("///> lua\n1i32",
               compile: fn %{backend: "Lua"} -> {:ok, "return 1\n"} end,
               target: fn %{builder: %{tool: :lua}} ->
                 {:ok, %{exit_status: 0, output: "trace line\n" <> outer <> "\n", duration_ms: 1}}
               end
             )
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
