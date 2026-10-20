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

pub fn first_codepoint_0(v0: String) -> String {
    let v1 = spiral_string_slice(v0, 0, 1)
    v1
}
pub fn second_codepoint_1(v0: String) -> String {
    let v1 = spiral_string_slice(v0, 2, 3)
    v1
}
pub fn main() {
let v0 = "éλ"
let v1 = first_codepoint_0(v0)
let v2 = second_codepoint_1(v0)
let v3 = { v1 } <> { v2 }
let v4 = spiral_string_length(v1)
let v5 = v4 == 2
case v5 {
    True -> {
        let v6 = spiral_string_length(v2)
        let v7 = v6 == 2
        case v7 {
            True -> {
                let v8 = spiral_string_length(v3)
                let v9 = v8 == 4
                case v9 {
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
