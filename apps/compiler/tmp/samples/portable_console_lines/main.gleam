import gleam/io
import gleam/int
pub fn main() {
let v0 = "hello"
io.println(v0)
let v1 = 42
io.println(int.to_string(v1))
let v2 = "a"
io.print(v2)
let v3 = "b"
io.print(v3)
let v4 = ""
io.println(v4)
let v5 = -7
io.println(int.to_string(v5))
0
}
