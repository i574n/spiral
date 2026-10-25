import gleam/bit_array
import gleam/string
pub fn spiral_string_length(text: String) -> Int {
  bit_array.byte_size(bit_array.from_string(text))
}


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

@external(erlang, "gleam_stdlib", "identity")
fn spiral_string_of_checked_bytes(bytes: BitArray) -> String {
  case bit_array.to_string(bytes) {
    Ok(text) -> text
    Error(_) -> panic as "spiral string slice: splits a character"
  }
}

fn spiral_string_starts_character(bytes: BitArray, at: Int) -> Bool {
  case bit_array.slice(bytes, at, 1) {
    Ok(<<lead>>) -> lead < 128 || lead >= 192
    _ -> True
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
          case spiral_string_starts_character(bytes, from) && spiral_string_starts_character(bytes, to + 1) {
            False -> panic as "spiral string slice: splits a character"
            True ->
              case bit_array.slice(bytes, from, to - from + 1) {
                Ok(part) -> spiral_string_of_checked_bytes(part)
                Error(_) -> panic as "spiral string slice: out of range"
              }
          }
      }
  }
}

pub fn main() {
    let v0 = "é"
    let v1 = spiral_string_length(v0)
    let v2 = spiral_string_index(v0, 0)
    let v3 = spiral_string_index(v0, 1)
    let v4 = "x"
    let v5 = { v0 } <> { v4 }
    let v6 = spiral_string_length(v5)
    let v7 = "ab"
    let v8 = spiral_string_index(v7, 0)
    let v9 = spiral_string_slice(v7, 0, 0)
    let v10 = spiral_string_length(v9)
    let v11 = spiral_string_slice(v7, 1, 0)
    let v12 = spiral_string_length(v11)
    let v13 = spiral_string_slice(v0, 0, 1)
    let v14 = spiral_string_length(v13)
    let v15 = v2 == v3
    case v15 {
        True -> {
            1
        }
        False -> {
            let v16 = v1 == 2
            let v18 =
                case v16 {
                    True -> {
                        let v17 = v8 == "a"
                        v17
                    }
                    False -> {
                        False
                    }
                }
            let v20 =
                case v18 {
                    True -> {
                        let v19 = v6 == 3
                        v19
                    }
                    False -> {
                        False
                    }
                }
            let v22 =
                case v20 {
                    True -> {
                        let v21 = v10 == 1
                        v21
                    }
                    False -> {
                        False
                    }
                }
            let v24 =
                case v22 {
                    True -> {
                        let v23 = v12 == 0
                        v23
                    }
                    False -> {
                        False
                    }
                }
            let v26 =
                case v24 {
                    True -> {
                        let v25 = v14 == 2
                        v25
                    }
                    False -> {
                        False
                    }
                }
            case v26 {
                True -> {
                    0
                }
                False -> {
                    1
                }
            }
        }
    }
}
