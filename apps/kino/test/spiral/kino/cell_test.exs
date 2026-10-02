defmodule Spiral.Kino.CellTest do
  use ExUnit.Case, async: true

  alias Spiral.Kino.Cell

  test "inlines emitRustExpr and prints the i32 value" do
    rust = """
    fn spiral_main() -> i32 {
        let mut v0: Rc<str> = "{ let mut out = std::io::stdout(); let _ = <std::io::Stdout as std::io::Write>::write_all(&mut out, $0.as_ref().as_bytes()); let _ = <std::io::Stdout as std::io::Write>::write_all(&mut out, &[10u8]); let _ = <std::io::Stdout as std::io::Write>::flush(&mut out); }";
        let mut v1: Rc<str> = Rc::<str>::from("Hello from Spiral!");
        Fable.Core.RustInterop.emitRustExpr v1 v0 ;
        49i32
    }
    fn main() {
        let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
        std::process::exit(main.join().unwrap());
    }
    """

    patched = Cell.patch_rust(rust, true)
    refute patched =~ "emitRustExpr"
    assert patched =~ "v1.as_ref().as_bytes()"
    assert patched =~ "SPIRAL_KINO_VALUE:{}"
    assert patched =~ "std::process::exit(0);"
  end

  test "a unit cell does not print a value" do
    rust = """
    fn main() {
        let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
        std::process::exit(main.join().unwrap());
    }
    """

    patched = Cell.patch_rust(rust, false)
    refute patched =~ "SPIRAL_KINO_VALUE"
    assert patched =~ "let _ = main.join().unwrap();"
  end

  test "splits the value marker out of stdout" do
    assert {"49", "Hello from Spiral!"} =
             Cell.split_output("Hello from Spiral!\nSPIRAL_KINO_VALUE:49\n")

    assert {nil, "Hello"} = Cell.split_output("Hello\n")
  end

  test "recognises a unit unification failure" do
    assert Cell.unit_result?("Unification failure.\nGot:      ()\nExpected: i32")
    refute Cell.unit_result?("Got:      string\nExpected: i32")
  end
end
