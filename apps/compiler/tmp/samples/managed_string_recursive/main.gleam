import gleam/bit_array
import gleam/string
import gleam/int
@external(erlang, "erlang", "halt")
pub fn spiral_halt(code: Int) -> a

pub fn spiral_string_length(text: String) -> Int {
  bit_array.byte_size(bit_array.from_string(text))
}

pub fn spiral_string_index(text: String, index: Int) -> String {
  case bit_array.slice(bit_array.from_string(text), index, 1) {
    Ok(<<byte>>) ->
      case string.utf_codepoint(byte) {
        Ok(codepoint) -> string.from_utf_codepoints([codepoint])
        Error(_) -> spiral_halt(3)
      }
    _ -> spiral_halt(3)
  }
}

pub fn spiral_string_slice(text: String, from: Int, to: Int) -> String {
  let bytes = bit_array.from_string(text)
  let length = bit_array.byte_size(bytes)
  case from < 0 || from > length || to < from - 1 || to >= length {
    True -> spiral_halt(3)
    False ->
      case to < from {
        True -> ""
        False ->
          case bit_array.slice(bytes, from, to - from + 1) {
            Ok(part) ->
              case bit_array.to_string(part) {
                Ok(slice) -> slice
                Error(_) -> spiral_halt(3)
              }
            Error(_) -> spiral_halt(3)
          }
      }
  }
}

pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn spiral_int_power(base: Int, exponent: Int) -> Int {
  case exponent <= 0 {
    True -> 1
    False -> base * spiral_int_power(base, exponent - 1)
  }
}

@external(erlang, "math", "pow")
pub fn spiral_math_pow(base: Float, exponent: Float) -> Float

pub type Uh0 {
    Uh0i0
    Uh0i1(String, Uh0, Uh0)
}
pub fn method0(v0: Uh0) -> Int {
    case v0  {
        Uh0i0 -> {
            0
        }
        Uh0i1(v1, v2, v3) -> {
            let v4 = spiral_string_length(v1)
            let v5 = method0(v2)
            let v6 = spiral_wrap_signed(v4 + v5, 32)
            let v7 = method0(v3)
            let v8 = spiral_wrap_signed(v6 + v7, 32)
            v8
        }
    }
}
pub fn main() {
let v0 = "ab"
let v1 = "qwe"
let v2 = Uh0i0
let v3 = Uh0i1(v1, v2, v2)
let v4 = Uh0i1(v0, v3, v3)
let v5 = method0(v4)
let v6 = Uh0i0
let v7 = Uh0i1(v1, v6, v6)
let v8 = Uh0i1(v0, v7, v7)
let v9 = method0(v8)
let v10 = spiral_wrap_signed(v5 + v9, 32)
let v11 = spiral_wrap_signed(v10 - 16, 32)
v11
}
