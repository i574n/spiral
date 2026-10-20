import gleam/bit_array
import gleam/string
pub fn spiral_string_length(text: String) -> Int {
  bit_array.byte_size(bit_array.from_string(text))
}

@external(erlang, "erlang", "halt")
@external(javascript, "node:process", "exit")
pub fn spiral_halt(code: Int) -> a

pub fn spiral_string_index(text: String, index: Int) -> String {
  case bit_array.slice(bit_array.from_string(text), index, 1) {
    Ok(<<byte>>) ->
      case string.utf_codepoint(byte) {
        Ok(codepoint) -> string.from_utf_codepoints([codepoint])
        Error(_) -> panic as "spiral string index: not a single-byte character"
      }
    _ -> panic as "spiral string index: out of range"
  }
}

pub fn spiral_string_slice(text: String, from: Int, to: Int) -> String {
  let bytes = bit_array.from_string(text)
  let length = bit_array.byte_size(bytes)
  case from < 0 || from > length || to < from - 1 || to >= length {
    True -> panic as "spiral string slice: out of range"
    False ->
      case to < from {
        True -> ""
        False ->
          case bit_array.slice(bytes, from, to - from + 1) {
            Ok(part) ->
              case bit_array.to_string(part) {
                Ok(slice) -> slice
                Error(_) -> panic as "spiral string slice: splits a character"
              }
            Error(_) -> panic as "spiral string slice: out of range"
          }
      }
  }
}

pub fn choose_left_0(v0: Bool) -> String {
    case v0 {
        True -> {
            let v1 = "spi"
            v1
        }
        False -> {
            let v2 = "bad"
            v2
        }
    }
}
pub fn choose_right_1(v0: Bool) -> String {
    case v0 {
        True -> {
            let v1 = "bad"
            v1
        }
        False -> {
            let v2 = "ral"
            v2
        }
    }
}
pub fn main() {
let v0 = True
let v1 = choose_left_0(v0)
let v2 = False
let v3 = choose_right_1(v2)
let v4 = { v1 } <> { v3 }
let v5 = spiral_string_length(v4)
let v6 = v5 == 6
case v6 {
    True -> {
        let v7 = spiral_string_index(v4, 0)
        let v8 = v7 == "s"
        case v8 {
            True -> {
                let v9 = spiral_string_index(v4, 5)
                let v10 = v9 == "l"
                case v10 {
                    True -> {
                        0
                    }
                    False -> {
                        1
                    }
                }
            }
            False -> {
                2
            }
        }
    }
    False -> {
        3
    }
}
}
