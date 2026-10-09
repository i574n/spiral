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

pub type Us0 {
    Us0Text(f0i0 : String)
    Us0Number(f1i0 : Int)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Number(v3) -> {
            v3
        }
        Us0Text(v1) -> {
            let v2 = spiral_string_length(v1)
            v2
        }
    }
}
pub fn main() {
let v0 = False
let v4 =
    case v0 {
        True -> {
            Us0Number(7)
        }
        False -> {
            let v2 = "qwe"
            Us0Text(v2)
        }
    }
let v5 = score_0(v4)
let v6 = score_0(v4)
let v7 = spiral_wrap_signed(v5 + v6, 32)
let v8 = spiral_wrap_signed(v7 - 6, 32)
v8
}
