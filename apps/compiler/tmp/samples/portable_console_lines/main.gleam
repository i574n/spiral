import gleam/io
import gleam/int
pub fn main() {
    io.println("hello")
    io.println(int.to_string(42))
    io.print("a")
    io.print("b")
    io.println("")
    io.println(int.to_string(-7))
    0
}
