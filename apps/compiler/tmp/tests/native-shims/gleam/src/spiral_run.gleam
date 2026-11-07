import main as program

@external(erlang, "spiral_exit", "halt")
@external(javascript, "./spiral_exit.mjs", "halt")
fn halt(result: a) -> Nil

pub fn main() {
  halt(program.main())
}
