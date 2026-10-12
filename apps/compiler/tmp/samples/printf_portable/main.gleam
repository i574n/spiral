import gleam/io
import gleam/int
pub fn main() {
let v0 = 60
let v1 = -9000000000
let v2 = 200
let v3 = "cube"
io.print(v3 <> ": " <> int.to_string(v0) <> " frames, checksum " <> int.to_string(970392) <> "\n")
io.print("big " <> int.to_string(v1) <> ", small " <> int.to_string(-5) <> ", byte " <> int.to_string(v2) <> "\n")
io.print("100% {braces} \"quoted\" \\ tab\tend\n")
io.print("literal" <> "\n")
io.print(v3)
io.print("\n")
0
}
