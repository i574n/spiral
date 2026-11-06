import gleam/io
import gleam/int
pub fn main() {
    let v3 = "cube"
    io.print(v3 <> ": " <> int.to_string(60) <> " frames, checksum " <> int.to_string(970392) <> "\n")
    io.print("big " <> int.to_string(-9000000000) <> ", small " <> int.to_string(-5) <> ", byte " <> int.to_string(200) <> "\n")
    io.print("100% {braces} \"quoted\" \\ tab\tend\n")
    io.print("literal" <> "\n")
    io.print(v3)
    io.print("\n")
    0
}
