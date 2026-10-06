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

  test "inlines an emit bound to a tuple" do
    rust = """
    fn spiral_main() -> i32 {
        let mut v0: Rc<str> = "{ spiral_trace_hold(&$0) }";
        let mut v1: Rc<dyn Fn() -> (i32, i32)> = closure0();
        let (mut v2, mut v3): (i32, i32) = Fable.Core.RustInterop.emitRustExpr v1 v0 ;
        0i32
    }
    fn main() {
        let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
        std::process::exit(main.join().unwrap());
    }
    """

    patched = Cell.patch_rust(rust, false)
    refute patched =~ "emitRustExpr"
    assert patched =~ "let (mut v2, mut v3): (i32, i32) = { spiral_trace_hold(&v1) };"
  end

  # The patch used to be about O(n^2.3) (grapheme-walking string ops in the Gleam domain): 400 lines took 40 s.
  # Load-tolerant: a 4x longer input must cost about 4x (linear), not 16-25x. The absolute bound is generous because a
  # loaded machine slows both sizes alike (a fixed 1 s failed at 1.37 s next to a notebook run).
  test "patching a 2000-line main.rs is linear" do
    {small_us, _} = :timer.tc(fn -> Cell.patch_rust(big_rust(12), true) end)
    rust = big_rust(50)
    assert length(String.split(rust, "\n")) >= 2_000
    {us, patched} = :timer.tc(fn -> Cell.patch_rust(rust, true) end)
    assert us < 10_000_000, "patch_rust took #{div(us, 1000)} ms"

    assert us < 12 * max(small_us, 20_000),
           "patch_rust: 2000 lines #{div(us, 1000)} ms vs 500 lines #{div(small_us, 1000)} ms"

    refute patched =~ "emitRustExpr"
    assert patched =~ ~s|{ spiral_trace_hold(&v20050, "ü 50") };|
    assert patched =~ "let mut v5036: i32 = v5035 + 36i32; // ü"
    refute patched =~ "v10050"
    refute patched =~ "\n\n\n"
    assert patched =~ "SPIRAL_KINO_VALUE:{}"
  end

  defp big_rust(blocks) do
    body =
      for i <- 1..blocks, into: "" do
        filler =
          for j <- 1..36,
              into: "",
              do: "    let mut v#{i * 100 + j}: i32 = v#{i * 100 + j - 1} + #{j}i32; // ü\n"

        filler <>
          "    let mut v#{10_000 + i}: Rc<str> = \"{ spiral_trace_hold(&$0, \\\"ü #{i}\\\") }\";\n" <>
          "    let mut v#{20_000 + i}: Rc<str> = Rc::<str>::from(\"ü\");\n" <>
          "    Fable.Core.RustInterop.emitRustExpr v#{20_000 + i} v#{10_000 + i} ;\n\n\n\n"
      end

    "fn spiral_main() -> i32 {\n" <>
      body <>
      "    0i32\n}\nfn main() {\n    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();\n" <>
      "    std::process::exit(main.join().unwrap());\n}\n"
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

  test "the panic-mapping join of the D1 compiler gets the value print, and a panic still exits 101" do
    rust = """
    fn main() {
        let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
        std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
    }
    """

    shown = Cell.patch_rust(rust, true)

    assert shown =~
             ~s|Ok(spiral_kino_value) => { println!("SPIRAL_KINO_VALUE:{}", spiral_kino_value); std::process::exit(0) }|

    assert shown =~ "Err(_) => std::process::exit(101)"
    refute shown =~ "Ok(code) => code"

    unit = Cell.patch_rust(rust, false)
    refute unit =~ "SPIRAL_KINO_VALUE"
    assert unit =~ "Ok(_) => std::process::exit(0)"
    assert unit =~ "Err(_) => std::process::exit(101)"
  end

  test "splits the value marker out of stdout" do
    assert {"49", "Hello from Spiral!"} =
             Cell.split_output("Hello from Spiral!\nSPIRAL_KINO_VALUE:49\n")

    assert {nil, "Hello"} = Cell.split_output("Hello\n")
  end

  test "recognises a unit unification failure" do
    assert Cell.unit_result?("Unification failure.\nGot:      ()\nExpected: i32")

    assert Cell.unit_result?(
             "Unification failure.\nGot:      list u64 -> ()\nExpected: list u64 -> i32"
           )

    assert Cell.unit_result?("""
           TypeErrors: [(({| character = 7
                 line = 9 |}, {| character = 17
                                 line = 9 |}),
             "Unification failure.
           Got:      list u64 -> ()
           Expected: list u64 -> i32")]
           """)

    assert Cell.unit_result?("Got:      ()\nExpected: i32\")]")
    assert Cell.unit_result?("Unification failure.\nGot:      i32 -> i32\nExpected: i32 -> ()")
    refute Cell.unit_result?("Got:      string\nExpected: i32")
    refute Cell.unit_result?("Got:      () -> string\nExpected: () -> i32")
  end
end
