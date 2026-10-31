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
                        True -> 0
                        False -> 1
                    }
                }
                False -> 2
            }
        }
        False -> 3
    }
}
