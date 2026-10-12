import main as program

@external(erlang, "spiral_exit", "halt")
fn halt(result: a) -> Nil

pub fn main() {
  halt(program.main())
}
