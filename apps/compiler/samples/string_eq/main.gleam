import gleam/bit_array
import gleam/string



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
    let v2 = { v0 } <> { "x" }
    let v3 = "éx"
    let v5 = ""
    let v6 = spiral_string_slice(v3, 1, 0)
    let v7 = v2 == v3
    let v9 =
        case v7 {
            True -> {
                v2 != "éy"
            }
            False -> False
        }
    let v11 =
        case v9 {
            True -> {
                v0 != v3
            }
            False -> False
        }
    let v13 =
        case v11 {
            True -> {
                v5 == v6
            }
            False -> False
        }
    let v15 =
        case v13 {
            True -> {
                v5 != v0
            }
            False -> False
        }
    case v15 {
        True -> 0
        False -> 1
    }
}
