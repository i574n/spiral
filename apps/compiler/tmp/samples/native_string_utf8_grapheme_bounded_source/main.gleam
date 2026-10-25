import gleam/bit_array
import gleam/string
import gleam/int
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

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn runtime_byte_2(v0: String, v1: Int) -> String {
    let v2 = spiral_string_index(v0, v1)
    v2
}
pub fn utf8_scalar_at_byte_offset_1(v0: String, v1: Int) -> Int {
    let v2 = spiral_string_length(v0)
    let v3 = v1 < 0
    case v3 {
        True -> {
            panic as "UTF-8 byte offset is negative."
        }
        False -> {
            let v5 = v1 >= v2
            case v5 {
                True -> {
                    panic as "UTF-8 byte offset is outside the string."
                }
                False -> {
                    let v7 = runtime_byte_2(v0, v1)
                    let v8 = case string.to_utf_codepoints(v7) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                    let v9 = v8 < 128
                    case v9 {
                        True -> {
                            v8
                        }
                        False -> {
                            let v10 = v8 < 194
                            case v10 {
                                True -> {
                                    panic as "UTF-8 scalar starts with an invalid lead byte."
                                }
                                False -> {
                                    let v12 = v8 < 224
                                    case v12 {
                                        True -> {
                                            let v13 = spiral_wrap_signed(v1 + 1, 32)
                                            let v14 = v13 >= v2
                                            case v14 {
                                                True -> {
                                                    panic as "UTF-8 sequence is truncated."
                                                }
                                                False -> {
                                                    let v16 = runtime_byte_2(v0, v13)
                                                    let v17 = case string.to_utf_codepoints(v16) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                                                    let v18 = v17 < 128
                                                    let v20 =
                                                        case v18 {
                                                            True -> {
                                                                False
                                                            }
                                                            False -> {
                                                                let v19 = v17 < 192
                                                                v19
                                                            }
                                                        }
                                                    case v20 {
                                                        True -> {
                                                            let v21 = spiral_wrap_signed(v8 - 192, 32)
                                                            let v22 = spiral_wrap_signed(v21 * 64, 32)
                                                            let v23 = spiral_wrap_signed(v17 - 128, 32)
                                                            let v24 = spiral_wrap_signed(v22 + v23, 32)
                                                            v24
                                                        }
                                                        False -> {
                                                            panic as "UTF-8 sequence has an invalid continuation byte."
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        False -> {
                                            let v28 = v8 < 240
                                            case v28 {
                                                True -> {
                                                    let v29 = spiral_wrap_signed(v1 + 2, 32)
                                                    let v30 = v29 >= v2
                                                    case v30 {
                                                        True -> {
                                                            panic as "UTF-8 sequence is truncated."
                                                        }
                                                        False -> {
                                                            let v32 = spiral_wrap_signed(v1 + 1, 32)
                                                            let v33 = runtime_byte_2(v0, v32)
                                                            let v34 = case string.to_utf_codepoints(v33) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                                                            let v35 = runtime_byte_2(v0, v29)
                                                            let v36 = case string.to_utf_codepoints(v35) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                                                            let v37 = v34 < 128
                                                            let v39 =
                                                                case v37 {
                                                                    True -> {
                                                                        False
                                                                    }
                                                                    False -> {
                                                                        let v38 = v34 < 192
                                                                        v38
                                                                    }
                                                                }
                                                            case v39 {
                                                                True -> {
                                                                    let v40 = v36 < 128
                                                                    let v42 =
                                                                        case v40 {
                                                                            True -> {
                                                                                False
                                                                            }
                                                                            False -> {
                                                                                let v41 = v36 < 192
                                                                                v41
                                                                            }
                                                                        }
                                                                    case v42 {
                                                                        True -> {
                                                                            let v43 = spiral_wrap_signed(v8 - 224, 32)
                                                                            let v44 = spiral_wrap_signed(v43 * 4096, 32)
                                                                            let v45 = spiral_wrap_signed(v34 - 128, 32)
                                                                            let v46 = spiral_wrap_signed(v45 * 64, 32)
                                                                            let v47 = spiral_wrap_signed(v44 + v46, 32)
                                                                            let v48 = spiral_wrap_signed(v36 - 128, 32)
                                                                            let v49 = spiral_wrap_signed(v47 + v48, 32)
                                                                            let v50 = v49 < 2048
                                                                            case v50 {
                                                                                True -> {
                                                                                    panic as "UTF-8 sequence is overlong."
                                                                                }
                                                                                False -> {
                                                                                    let v52 = v49 >= 55296
                                                                                    case v52 {
                                                                                        True -> {
                                                                                            let v53 = v49 <= 57343
                                                                                            case v53 {
                                                                                                True -> {
                                                                                                    panic as "UTF-8 sequence encodes a surrogate."
                                                                                                }
                                                                                                False -> {
                                                                                                    v49
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        False -> {
                                                                                            v49
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        False -> {
                                                                            panic as "UTF-8 sequence has an invalid continuation byte."
                                                                        }
                                                                    }
                                                                }
                                                                False -> {
                                                                    panic as "UTF-8 sequence has an invalid continuation byte."
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                False -> {
                                                    let v63 = v8 < 245
                                                    case v63 {
                                                        True -> {
                                                            let v64 = spiral_wrap_signed(v1 + 3, 32)
                                                            let v65 = v64 >= v2
                                                            case v65 {
                                                                True -> {
                                                                    panic as "UTF-8 sequence is truncated."
                                                                }
                                                                False -> {
                                                                    let v67 = spiral_wrap_signed(v1 + 1, 32)
                                                                    let v68 = runtime_byte_2(v0, v67)
                                                                    let v69 = case string.to_utf_codepoints(v68) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                                                                    let v70 = spiral_wrap_signed(v1 + 2, 32)
                                                                    let v71 = runtime_byte_2(v0, v70)
                                                                    let v72 = case string.to_utf_codepoints(v71) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                                                                    let v73 = runtime_byte_2(v0, v64)
                                                                    let v74 = case string.to_utf_codepoints(v73) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                                                                    let v75 = v69 < 128
                                                                    let v77 =
                                                                        case v75 {
                                                                            True -> {
                                                                                False
                                                                            }
                                                                            False -> {
                                                                                let v76 = v69 < 192
                                                                                v76
                                                                            }
                                                                        }
                                                                    case v77 {
                                                                        True -> {
                                                                            let v78 = v72 < 128
                                                                            let v80 =
                                                                                case v78 {
                                                                                    True -> {
                                                                                        False
                                                                                    }
                                                                                    False -> {
                                                                                        let v79 = v72 < 192
                                                                                        v79
                                                                                    }
                                                                                }
                                                                            case v80 {
                                                                                True -> {
                                                                                    let v81 = v74 < 128
                                                                                    let v83 =
                                                                                        case v81 {
                                                                                            True -> {
                                                                                                False
                                                                                            }
                                                                                            False -> {
                                                                                                let v82 = v74 < 192
                                                                                                v82
                                                                                            }
                                                                                        }
                                                                                    case v83 {
                                                                                        True -> {
                                                                                            let v84 = spiral_wrap_signed(v8 - 240, 32)
                                                                                            let v85 = spiral_wrap_signed(v84 * 262144, 32)
                                                                                            let v86 = spiral_wrap_signed(v69 - 128, 32)
                                                                                            let v87 = spiral_wrap_signed(v86 * 4096, 32)
                                                                                            let v88 = spiral_wrap_signed(v85 + v87, 32)
                                                                                            let v89 = spiral_wrap_signed(v72 - 128, 32)
                                                                                            let v90 = spiral_wrap_signed(v89 * 64, 32)
                                                                                            let v91 = spiral_wrap_signed(v88 + v90, 32)
                                                                                            let v92 = spiral_wrap_signed(v74 - 128, 32)
                                                                                            let v93 = spiral_wrap_signed(v91 + v92, 32)
                                                                                            let v94 = v93 < 65536
                                                                                            case v94 {
                                                                                                True -> {
                                                                                                    panic as "UTF-8 sequence is overlong."
                                                                                                }
                                                                                                False -> {
                                                                                                    let v96 = v93 > 1114111
                                                                                                    case v96 {
                                                                                                        True -> {
                                                                                                            panic as "UTF-8 scalar is above U+10FFFF."
                                                                                                        }
                                                                                                        False -> {
                                                                                                            v93
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        False -> {
                                                                                            panic as "UTF-8 sequence has an invalid continuation byte."
                                                                                        }
                                                                                    }
                                                                                }
                                                                                False -> {
                                                                                    panic as "UTF-8 sequence has an invalid continuation byte."
                                                                                }
                                                                            }
                                                                        }
                                                                        False -> {
                                                                            panic as "UTF-8 sequence has an invalid continuation byte."
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        False -> {
                                                            panic as "UTF-8 scalar starts with an invalid lead byte."
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
pub fn utf8_grapheme_count_bounded_loop_0(v0: String, v1: Int, v2: Int, v3: Int) -> Int {
    let v4 = v1 == v3
    case v4 {
        True -> {
            v2
        }
        False -> {
            let v5 = v1 > v3
            case v5 {
                True -> {
                    panic as "UTF-8 scalar width exceeds the string."
                }
                False -> {
                    let v7 = utf8_scalar_at_byte_offset_1(v0, v1)
                    let v8 = v7 < 128
                    let v13 =
                        case v8 {
                            True -> {
                                1
                            }
                            False -> {
                                let v9 = v7 < 2048
                                case v9 {
                                    True -> {
                                        2
                                    }
                                    False -> {
                                        let v10 = v7 < 65536
                                        case v10 {
                                            True -> {
                                                3
                                            }
                                            False -> {
                                                4
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v14 = v7 >= 768
                    let v44 =
                        case v14 {
                            True -> {
                                let v15 = v7 <= 879
                                case v15 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v16 = v7 >= 6832
                                        case v16 {
                                            True -> {
                                                let v17 = v7 <= 6911
                                                case v17 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v18 = v7 >= 7616
                                                        case v18 {
                                                            True -> {
                                                                let v19 = v7 <= 7679
                                                                case v19 {
                                                                    True -> {
                                                                        True
                                                                    }
                                                                    False -> {
                                                                        let v20 = v7 >= 8400
                                                                        case v20 {
                                                                            True -> {
                                                                                let v21 = v7 <= 8447
                                                                                case v21 {
                                                                                    True -> {
                                                                                        True
                                                                                    }
                                                                                    False -> {
                                                                                        let v22 = v7 >= 65024
                                                                                        case v22 {
                                                                                            True -> {
                                                                                                let v23 = v7 <= 65039
                                                                                                case v23 {
                                                                                                    True -> {
                                                                                                        True
                                                                                                    }
                                                                                                    False -> {
                                                                                                        let v24 = v7 >= 65056
                                                                                                        case v24 {
                                                                                                            True -> {
                                                                                                                let v25 = v7 <= 65071
                                                                                                                case v25 {
                                                                                                                    True -> {
                                                                                                                        True
                                                                                                                    }
                                                                                                                    False -> {
                                                                                                                        let v26 = v7 >= 127995
                                                                                                                        case v26 {
                                                                                                                            True -> {
                                                                                                                                let v27 = v7 <= 127999
                                                                                                                                case v27 {
                                                                                                                                    True -> {
                                                                                                                                        True
                                                                                                                                    }
                                                                                                                                    False -> {
                                                                                                                                        let v28 = v7 >= 917760
                                                                                                                                        case v28 {
                                                                                                                                            True -> {
                                                                                                                                                let v29 = v7 <= 917999
                                                                                                                                                v29
                                                                                                                                            }
                                                                                                                                            False -> {
                                                                                                                                                False
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                            False -> {
                                                                                                                                False
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                            False -> {
                                                                                                                False
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            False -> {
                                                                                                False
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            False -> {
                                                                                False
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            False -> {
                                                                False
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    }
                                }
                            }
                            False -> {
                                False
                            }
                        }
                    let v48 =
                        case v44 {
                            True -> {
                                let v45 = v2 == 0
                                case v45 {
                                    True -> {
                                        1
                                    }
                                    False -> {
                                        v2
                                    }
                                }
                            }
                            False -> {
                                let v47 = spiral_wrap_signed(v2 + 1, 32)
                                v47
                            }
                        }
                    let v49 = spiral_wrap_signed(v1 + v13, 32)
                    utf8_grapheme_count_bounded_loop_0(v0, v49, v48, v3)
                }
            }
        }
    }
}
pub fn main() {
let v0 = "Aéé☕️👍🏽Z"
let v1 = 0
let v2 = 0
let v3 = 21
let v4 = utf8_grapheme_count_bounded_loop_0(v0, v1, v2, v3)
let v5 = "́̈A"
let v6 = 0
let v7 = 0
let v8 = 5
let v9 = utf8_grapheme_count_bounded_loop_0(v5, v6, v7, v8)
let v10 = "Aé🙂Z"
let v11 = 4
let v12 = utf8_scalar_at_byte_offset_1(v10, v11)
let v13 = v12 >= 768
let v43 =
    case v13 {
        True -> {
            let v14 = v12 <= 879
            case v14 {
                True -> {
                    True
                }
                False -> {
                    let v15 = v12 >= 6832
                    case v15 {
                        True -> {
                            let v16 = v12 <= 6911
                            case v16 {
                                True -> {
                                    True
                                }
                                False -> {
                                    let v17 = v12 >= 7616
                                    case v17 {
                                        True -> {
                                            let v18 = v12 <= 7679
                                            case v18 {
                                                True -> {
                                                    True
                                                }
                                                False -> {
                                                    let v19 = v12 >= 8400
                                                    case v19 {
                                                        True -> {
                                                            let v20 = v12 <= 8447
                                                            case v20 {
                                                                True -> {
                                                                    True
                                                                }
                                                                False -> {
                                                                    let v21 = v12 >= 65024
                                                                    case v21 {
                                                                        True -> {
                                                                            let v22 = v12 <= 65039
                                                                            case v22 {
                                                                                True -> {
                                                                                    True
                                                                                }
                                                                                False -> {
                                                                                    let v23 = v12 >= 65056
                                                                                    case v23 {
                                                                                        True -> {
                                                                                            let v24 = v12 <= 65071
                                                                                            case v24 {
                                                                                                True -> {
                                                                                                    True
                                                                                                }
                                                                                                False -> {
                                                                                                    let v25 = v12 >= 127995
                                                                                                    case v25 {
                                                                                                        True -> {
                                                                                                            let v26 = v12 <= 127999
                                                                                                            case v26 {
                                                                                                                True -> {
                                                                                                                    True
                                                                                                                }
                                                                                                                False -> {
                                                                                                                    let v27 = v12 >= 917760
                                                                                                                    case v27 {
                                                                                                                        True -> {
                                                                                                                            let v28 = v12 <= 917999
                                                                                                                            v28
                                                                                                                        }
                                                                                                                        False -> {
                                                                                                                            False
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                        False -> {
                                                                                                            False
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        False -> {
                                                                                            False
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        False -> {
                                                                            False
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        False -> {
                                                            False
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                }
                            }
                        }
                        False -> {
                            False
                        }
                    }
                }
            }
        }
        False -> {
            False
        }
    }
let v49 =
    case v43 {
        True -> {
            panic as "UTF-8 grapheme byte offset is inside a bounded grapheme cluster."
        }
        False -> {
            let v45 = 4
            let v46 = 0
            let v47 = 9
            utf8_grapheme_count_bounded_loop_0(v10, v45, v46, v47)
        }
    }
let v50 = v4 == 6
case v50 {
    True -> {
        let v51 = v9 == 2
        case v51 {
            True -> {
                let v52 = v49 == 2
                case v52 {
                    True -> {
                        0
                    }
                    False -> {
                        4
                    }
                }
            }
            False -> {
                2
            }
        }
    }
    False -> {
        1
    }
}
}
