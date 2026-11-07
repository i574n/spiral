import gleam/bit_array
import gleam/string
import gleam/order
import gleam/int
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

pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn runtime_byte_0(v0: String, v1: Int) -> String {
    spiral_string_index(v0, v1)
}
pub fn codepoint_length_loop_1(v0: String, v1: String, v2: String, v3: Int, v4: Int, v5: Int) -> Int {
    let v6 = v3 == v5
    case v6 {
        True -> v4
        False -> {
            let v7 = spiral_string_index(v0, v3)
            let v8 = string.compare(v7, v1) == order.Lt
            let v10 =
                case v8 {
                    True -> False
                    False -> {
                        string.compare(v7, v2) == order.Lt
                    }
                }
            let v12 =
                case v10 {
                    True -> v4
                    False -> {
                        spiral_wrap_signed(v4 + 1, 32)
                    }
                }
            let v13 = spiral_wrap_signed(v3 + 1, 32)
            codepoint_length_loop_1(v0, v1, v2, v13, v12, v5)
        }
    }
}
pub fn codepoint_byte_offset_loop_2(v0: String, v1: String, v2: String, v3: Int, v4: Int, v5: Int, v6: Int) -> Int {
    let v7 = v4 == v6
    case v7 {
        True -> v6
        False -> {
            let v8 = spiral_string_index(v0, v4)
            let v9 = string.compare(v8, v1) == order.Lt
            let v11 =
                case v9 {
                    True -> False
                    False -> {
                        string.compare(v8, v2) == order.Lt
                    }
                }
            case v11 {
                True -> {
                    let v12 = spiral_wrap_signed(v4 + 1, 32)
                    codepoint_byte_offset_loop_2(v0, v1, v2, v3, v12, v5, v6)
                }
                False -> {
                    let v14 = v5 == v3
                    case v14 {
                        True -> v4
                        False -> {
                            let v15 = spiral_wrap_signed(v4 + 1, 32)
                            let v16 = spiral_wrap_signed(v5 + 1, 32)
                            codepoint_byte_offset_loop_2(v0, v1, v2, v3, v15, v16, v6)
                        }
                    }
                }
            }
        }
    }
}
pub fn main() {
    let v0 = "À"
    let v2 = runtime_byte_0(v0, 1)
    let v3 = "©"
    let v5 = runtime_byte_0(v3, 0)
    let v6 = "Aéλ🙂Z"
    let v10 = codepoint_length_loop_1(v6, v2, v5, 0, 0, 10)
    let v12 = runtime_byte_0(v0, 1)
    let v14 = runtime_byte_0(v3, 0)
    let v19 = codepoint_byte_offset_loop_2(v6, v12, v14, 1, 0, 0, 10)
    let v21 = runtime_byte_0(v0, 1)
    let v23 = runtime_byte_0(v3, 0)
    let v28 = codepoint_byte_offset_loop_2(v6, v21, v23, 2, 0, 0, 10)
    let v29 = spiral_wrap_signed(v28 - 1, 32)
    let v30 = spiral_string_slice("Aéλ🙂Z", v19, v29)
    let v32 = runtime_byte_0(v0, 1)
    let v34 = runtime_byte_0(v3, 0)
    let v39 = codepoint_byte_offset_loop_2(v6, v32, v34, 3, 0, 0, 10)
    let v41 = runtime_byte_0(v0, 1)
    let v43 = runtime_byte_0(v3, 0)
    let v48 = codepoint_byte_offset_loop_2(v6, v41, v43, 4, 0, 0, 10)
    let v49 = spiral_wrap_signed(v48 - 1, 32)
    let v50 = spiral_string_slice("Aéλ🙂Z", v39, v49)
    let v52 = runtime_byte_0(v0, 1)
    let v54 = runtime_byte_0(v3, 0)
    let v59 = codepoint_byte_offset_loop_2(v6, v52, v54, 1, 0, 0, 10)
    let v61 = runtime_byte_0(v0, 1)
    let v63 = runtime_byte_0(v3, 0)
    let v68 = codepoint_byte_offset_loop_2(v6, v61, v63, 4, 0, 0, 10)
    let v69 = spiral_wrap_signed(v68 - 1, 32)
    let v70 = spiral_string_slice("Aéλ🙂Z", v59, v69)
    let v72 = runtime_byte_0(v0, 1)
    let v74 = runtime_byte_0(v3, 0)
    let v79 = codepoint_byte_offset_loop_2(v6, v72, v74, 3, 0, 0, 10)
    let v81 = runtime_byte_0(v30, 0)
    let v84 = runtime_byte_0("é", 0)
    let v86 = runtime_byte_0(v50, 3)
    let v89 = runtime_byte_0("🙂", 3)
    let v90 = v10 == 5
    case v90 {
        True -> {
            let v91 = spiral_string_length(v30)
            let v92 = v91 == 2
            case v92 {
                True -> {
                    let v93 = v81 == v84
                    case v93 {
                        True -> {
                            let v94 = spiral_string_length(v50)
                            let v95 = v94 == 4
                            case v95 {
                                True -> {
                                    let v96 = v86 == v89
                                    case v96 {
                                        True -> {
                                            let v97 = spiral_string_length(v70)
                                            let v98 = v97 == 8
                                            case v98 {
                                                True -> {
                                                    let v99 = v79 == 5
                                                    case v99 {
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
                                False -> 4
                            }
                        }
                        False -> 5
                    }
                }
                False -> 6
            }
        }
        False -> 7
    }
}
