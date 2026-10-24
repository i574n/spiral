import gleam/bit_array
import gleam/string
pub fn spiral_string_length(text: String) -> Int {
  bit_array.byte_size(bit_array.from_string(text))
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
