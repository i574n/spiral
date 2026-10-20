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

pub fn main() {
let v0 = "é"
let v1 = "x"
let v2 = { v0 } <> { v1 }
let v3 = "éx"
let v4 = "éy"
let v5 = ""
let v6 = spiral_string_slice(v3, 1, 0)
let v7 = v2 == v3
let v9 =
    case v7 {
        True -> {
            let v8 = v2 != v4
            v8
        }
        False -> {
            False
        }
    }
let v11 =
    case v9 {
        True -> {
            let v10 = v0 != v3
            v10
        }
        False -> {
            False
        }
    }
let v13 =
    case v11 {
        True -> {
            let v12 = v5 == v6
            v12
        }
        False -> {
            False
        }
    }
let v15 =
    case v13 {
        True -> {
            let v14 = v5 != v0
            v14
        }
        False -> {
            False
        }
    }
case v15 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
