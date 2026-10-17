import gleam/int
import gleam/io
import gleam/float
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn lcg_0(v0: Int, v1: Int, v2: Int, v3: Int) -> Int {
    let v4 = v2 == 0
    case v4 {
        True -> {
            v3
        }
        False -> {
            let v5 = spiral_wrap_signed(v2 - 1, 32)
            let v6 = spiral_wrap_unsigned(v3 * v0, 64)
            let v7 = spiral_wrap_unsigned(v6 + v1, 64)
            lcg_0(v0, v1, v5, v7)
        }
    }
}
pub fn main() {
let v0 = 42
let v1 = 6364136223846793005
let v2 = 1442695040888963407
let v3 = 1000
let v4 = lcg_0(v1, v2, v3, v0)
io.print("lcg " <> int.to_string(v4) <> "\n")
let v5 = 9223372036854775807
let v6 = -9223372036854775807
let v7 = 18446744073709551615
let v8 = spiral_wrap_signed(v6 - 1, 64)
let v9 = spiral_wrap_unsigned(v7 + 2, 64)
io.print("max " <> int.to_string(v5) <> " min " <> int.to_string(v8) <> " wrap " <> int.to_string(v9) <> "\n")
let v10 = -9007199254740993
let v11 = 7
let v12 = v10 / v11
let v13 = v10 % v11
io.print("div " <> int.to_string(v12) <> " mod " <> int.to_string(v13) <> "\n")
let v14 = int.bitwise_shift_right(v10, 3)
let v15 = int.bitwise_shift_right(v4, 60)
io.print("shl " <> int.to_string(4611686018427387904) <> " shr " <> int.to_string(v14) <> " ushr " <> int.to_string(v15) <> "\n")
let v16 = int.bitwise_and(v4, 18446744069414584320)
let v17 = int.bitwise_or(v10, 255)
let v18 = int.bitwise_exclusive_or(v4, v1)
io.print("and " <> int.to_string(v16) <> " or " <> int.to_string(v17) <> " xor " <> int.to_string(v18) <> "\n")
let v19 = 1.0e18
let v20 = float.truncate(v19)
let v21 = spiral_wrap_unsigned(v4, 32)
let v22 = int.to_float(v10)
let v23 = v22 <. 0.0
let v24 =
    case v23 {
        True -> {
            1
        }
        False -> {
            0
        }
    }
io.print("conv " <> int.to_string(v20) <> " " <> int.to_string(v21) <> " " <> int.to_string(v24) <> "\n")
let v25 = v4 > v1
case v25 {
    True -> {
        1
    }
    False -> {
        0
    }
}
}
