import gleam/bit_array
import gleam/string
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

pub fn method0(v0: String) -> String {
    let v1 = spiral_string_slice(v0, 2, 1)
    v1
}
pub fn method1(v0: String) -> String {
    let v1 = spiral_string_slice(v0, 5, 4)
    v1
}
pub fn method2(v0: String) -> String {
    let v1 = spiral_string_slice(v0, 0, -1)
    v1
}
pub fn main() {
let v0 = "alpha"
let v1 = method0(v0)
let v2 = method1(v0)
let v3 = ""
let v4 = method2(v3)
let v5 = { v1 } <> { v2 }
let v6 = { v4 } <> { "ok" }
let v7 = { v5 } <> { v6 }
let v8 = spiral_string_length(v1)
let v9 = v8 == 0
case v9 {
    True -> {
        let v10 = spiral_string_length(v2)
        let v11 = v10 == 0
        case v11 {
            True -> {
                let v12 = spiral_string_length(v4)
                let v13 = v12 == 0
                case v13 {
                    True -> {
                        let v14 = spiral_string_length(v7)
                        let v15 = v14 == 2
                        case v15 {
                            True -> {
                                let v16 = spiral_string_index(v7, 0)
                                let v17 = v16 == "o"
                                case v17 {
                                    True -> {
                                        let v18 = spiral_string_index(v7, 1)
                                        let v19 = v18 == "k"
                                        case v19 {
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
                    False -> {
                        4
                    }
                }
            }
            False -> {
                5
            }
        }
    }
    False -> {
        6
    }
}
}
