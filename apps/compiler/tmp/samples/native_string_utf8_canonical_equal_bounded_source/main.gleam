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
pub fn utf8_canonical_equal_bounded_loop_0(v0: String, v1: String, v2: Int, v3: Int, v4: Int, v5: Int, v6: Int, v7: Int) -> Bool {
    let v8 = v4 >= 0
    let #(v76, v77, v78) =
        case v8 {
            True -> {
                #(v4, v2, -1)
            }
            False -> {
                let v9 = v2 == v6
                case v9 {
                    True -> {
                        #(-1, v2, -1)
                    }
                    False -> {
                        let v10 = v2 > v6
                        case v10 {
                            True -> {
                                panic as "UTF-8 canonical stream offset exceeds the string."
                            }
                            False -> {
                                let v14 = utf8_scalar_at_byte_offset_1(v0, v2)
                                let v15 = v14 < 128
                                let v20 =
                                    case v15 {
                                        True -> {
                                            1
                                        }
                                        False -> {
                                            let v16 = v14 < 2048
                                            case v16 {
                                                True -> {
                                                    2
                                                }
                                                False -> {
                                                    let v17 = v14 < 65536
                                                    case v17 {
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
                                let v21 = v14 == 192
                                let #(v67, v68) =
                                    case v21 {
                                        True -> {
                                            #(65, 768)
                                        }
                                        False -> {
                                            let v22 = v14 == 193
                                            case v22 {
                                                True -> {
                                                    #(65, 769)
                                                }
                                                False -> {
                                                    let v23 = v14 == 195
                                                    case v23 {
                                                        True -> {
                                                            #(65, 771)
                                                        }
                                                        False -> {
                                                            let v24 = v14 == 196
                                                            case v24 {
                                                                True -> {
                                                                    #(65, 776)
                                                                }
                                                                False -> {
                                                                    let v25 = v14 == 199
                                                                    case v25 {
                                                                        True -> {
                                                                            #(67, 807)
                                                                        }
                                                                        False -> {
                                                                            let v26 = v14 == 201
                                                                            case v26 {
                                                                                True -> {
                                                                                    #(69, 769)
                                                                                }
                                                                                False -> {
                                                                                    let v27 = v14 == 211
                                                                                    case v27 {
                                                                                        True -> {
                                                                                            #(79, 769)
                                                                                        }
                                                                                        False -> {
                                                                                            let v28 = v14 == 213
                                                                                            case v28 {
                                                                                                True -> {
                                                                                                    #(79, 771)
                                                                                                }
                                                                                                False -> {
                                                                                                    let v29 = v14 == 224
                                                                                                    case v29 {
                                                                                                        True -> {
                                                                                                            #(97, 768)
                                                                                                        }
                                                                                                        False -> {
                                                                                                            let v30 = v14 == 225
                                                                                                            case v30 {
                                                                                                                True -> {
                                                                                                                    #(97, 769)
                                                                                                                }
                                                                                                                False -> {
                                                                                                                    let v31 = v14 == 227
                                                                                                                    case v31 {
                                                                                                                        True -> {
                                                                                                                            #(97, 771)
                                                                                                                        }
                                                                                                                        False -> {
                                                                                                                            let v32 = v14 == 228
                                                                                                                            case v32 {
                                                                                                                                True -> {
                                                                                                                                    #(97, 776)
                                                                                                                                }
                                                                                                                                False -> {
                                                                                                                                    let v33 = v14 == 231
                                                                                                                                    case v33 {
                                                                                                                                        True -> {
                                                                                                                                            #(99, 807)
                                                                                                                                        }
                                                                                                                                        False -> {
                                                                                                                                            let v34 = v14 == 233
                                                                                                                                            case v34 {
                                                                                                                                                True -> {
                                                                                                                                                    #(101, 769)
                                                                                                                                                }
                                                                                                                                                False -> {
                                                                                                                                                    let v35 = v14 == 243
                                                                                                                                                    case v35 {
                                                                                                                                                        True -> {
                                                                                                                                                            #(111, 769)
                                                                                                                                                        }
                                                                                                                                                        False -> {
                                                                                                                                                            let v36 = v14 == 245
                                                                                                                                                            case v36 {
                                                                                                                                                                True -> {
                                                                                                                                                                    #(111, 771)
                                                                                                                                                                }
                                                                                                                                                                False -> {
                                                                                                                                                                    #(v14, -1)
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
                                        }
                                    }
                                let v69 = spiral_wrap_signed(v2 + v20, 32)
                                #(v67, v69, v68)
                            }
                        }
                    }
                }
            }
        }
    let v79 = v5 >= 0
    let #(v147, v148, v149) =
        case v79 {
            True -> {
                #(v5, v3, -1)
            }
            False -> {
                let v80 = v3 == v7
                case v80 {
                    True -> {
                        #(-1, v3, -1)
                    }
                    False -> {
                        let v81 = v3 > v7
                        case v81 {
                            True -> {
                                panic as "UTF-8 canonical stream offset exceeds the string."
                            }
                            False -> {
                                let v85 = utf8_scalar_at_byte_offset_1(v1, v3)
                                let v86 = v85 < 128
                                let v91 =
                                    case v86 {
                                        True -> {
                                            1
                                        }
                                        False -> {
                                            let v87 = v85 < 2048
                                            case v87 {
                                                True -> {
                                                    2
                                                }
                                                False -> {
                                                    let v88 = v85 < 65536
                                                    case v88 {
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
                                let v92 = v85 == 192
                                let #(v138, v139) =
                                    case v92 {
                                        True -> {
                                            #(65, 768)
                                        }
                                        False -> {
                                            let v93 = v85 == 193
                                            case v93 {
                                                True -> {
                                                    #(65, 769)
                                                }
                                                False -> {
                                                    let v94 = v85 == 195
                                                    case v94 {
                                                        True -> {
                                                            #(65, 771)
                                                        }
                                                        False -> {
                                                            let v95 = v85 == 196
                                                            case v95 {
                                                                True -> {
                                                                    #(65, 776)
                                                                }
                                                                False -> {
                                                                    let v96 = v85 == 199
                                                                    case v96 {
                                                                        True -> {
                                                                            #(67, 807)
                                                                        }
                                                                        False -> {
                                                                            let v97 = v85 == 201
                                                                            case v97 {
                                                                                True -> {
                                                                                    #(69, 769)
                                                                                }
                                                                                False -> {
                                                                                    let v98 = v85 == 211
                                                                                    case v98 {
                                                                                        True -> {
                                                                                            #(79, 769)
                                                                                        }
                                                                                        False -> {
                                                                                            let v99 = v85 == 213
                                                                                            case v99 {
                                                                                                True -> {
                                                                                                    #(79, 771)
                                                                                                }
                                                                                                False -> {
                                                                                                    let v100 = v85 == 224
                                                                                                    case v100 {
                                                                                                        True -> {
                                                                                                            #(97, 768)
                                                                                                        }
                                                                                                        False -> {
                                                                                                            let v101 = v85 == 225
                                                                                                            case v101 {
                                                                                                                True -> {
                                                                                                                    #(97, 769)
                                                                                                                }
                                                                                                                False -> {
                                                                                                                    let v102 = v85 == 227
                                                                                                                    case v102 {
                                                                                                                        True -> {
                                                                                                                            #(97, 771)
                                                                                                                        }
                                                                                                                        False -> {
                                                                                                                            let v103 = v85 == 228
                                                                                                                            case v103 {
                                                                                                                                True -> {
                                                                                                                                    #(97, 776)
                                                                                                                                }
                                                                                                                                False -> {
                                                                                                                                    let v104 = v85 == 231
                                                                                                                                    case v104 {
                                                                                                                                        True -> {
                                                                                                                                            #(99, 807)
                                                                                                                                        }
                                                                                                                                        False -> {
                                                                                                                                            let v105 = v85 == 233
                                                                                                                                            case v105 {
                                                                                                                                                True -> {
                                                                                                                                                    #(101, 769)
                                                                                                                                                }
                                                                                                                                                False -> {
                                                                                                                                                    let v106 = v85 == 243
                                                                                                                                                    case v106 {
                                                                                                                                                        True -> {
                                                                                                                                                            #(111, 769)
                                                                                                                                                        }
                                                                                                                                                        False -> {
                                                                                                                                                            let v107 = v85 == 245
                                                                                                                                                            case v107 {
                                                                                                                                                                True -> {
                                                                                                                                                                    #(111, 771)
                                                                                                                                                                }
                                                                                                                                                                False -> {
                                                                                                                                                                    #(v85, -1)
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
                                        }
                                    }
                                let v140 = spiral_wrap_signed(v3 + v91, 32)
                                #(v138, v140, v139)
                            }
                        }
                    }
                }
            }
        }
    let v150 = v76 < 0
    case v150 {
        True -> {
            let v151 = v147 == -1
            v151
        }
        False -> {
            let v152 = v147 < 0
            case v152 {
                True -> {
                    False
                }
                False -> {
                    let v153 = v76 == v147
                    case v153 {
                        True -> {
                            utf8_canonical_equal_bounded_loop_0(v0, v1, v77, v148, v78, v149, v6, v7)
                        }
                        False -> {
                            False
                        }
                    }
                }
            }
        }
    }
}
pub fn main() {
let v0 = "plain"
let v1 = 0
let v2 = 0
let v3 = -1
let v4 = -1
let v5 = 5
let v6 = 5
let v7 = utf8_canonical_equal_bounded_loop_0(v0, v0, v1, v2, v3, v4, v5, v6)
let v8 = ""
let v9 = 0
let v10 = 0
let v11 = -1
let v12 = -1
let v13 = 0
let v14 = 0
let v15 = utf8_canonical_equal_bounded_loop_0(v8, v8, v9, v10, v11, v12, v13, v14)
let v16 = "éõç"
let v17 = "éõç"
let v18 = 0
let v19 = 0
let v20 = -1
let v21 = -1
let v22 = 6
let v23 = 9
let v24 = utf8_canonical_equal_bounded_loop_0(v16, v17, v18, v19, v20, v21, v22, v23)
let v25 = "é̃"
let v26 = "é̃"
let v27 = 0
let v28 = 0
let v29 = -1
let v30 = -1
let v31 = 4
let v32 = 5
let v33 = utf8_canonical_equal_bounded_loop_0(v25, v26, v27, v28, v29, v30, v31, v32)
let v34 = "À"
let v35 = "À"
let v36 = 0
let v37 = 0
let v38 = -1
let v39 = -1
let v40 = 2
let v41 = 3
let v42 = utf8_canonical_equal_bounded_loop_0(v34, v35, v36, v37, v38, v39, v40, v41)
let v43 = "Ω"
let v44 = 0
let v45 = 0
let v46 = -1
let v47 = -1
let v48 = 2
let v49 = 2
let v50 = utf8_canonical_equal_bounded_loop_0(v43, v43, v44, v45, v46, v47, v48, v49)
let v51 = "ẽ́"
let v52 = 0
let v53 = 0
let v54 = -1
let v55 = -1
let v56 = 5
let v57 = 5
let v58 = utf8_canonical_equal_bounded_loop_0(v26, v51, v52, v53, v54, v55, v56, v57)
let v59 = "é"
let v60 = "á"
let v61 = 0
let v62 = 0
let v63 = -1
let v64 = -1
let v65 = 2
let v66 = 2
let v67 = utf8_canonical_equal_bounded_loop_0(v59, v60, v61, v62, v63, v64, v65, v66)
let v68 = "ω"
let v69 = 0
let v70 = 0
let v71 = -1
let v72 = -1
let v73 = 2
let v74 = 2
let v75 = utf8_canonical_equal_bounded_loop_0(v43, v68, v69, v70, v71, v72, v73, v74)
let v76 = "e"
let v77 = 0
let v78 = 0
let v79 = -1
let v80 = -1
let v81 = 2
let v82 = 1
let v83 = utf8_canonical_equal_bounded_loop_0(v59, v76, v77, v78, v79, v80, v81, v82)
case v7 {
    True -> {
        case v15 {
            True -> {
                case v24 {
                    True -> {
                        case v33 {
                            True -> {
                                case v42 {
                                    True -> {
                                        case v50 {
                                            True -> {
                                                case v58 {
                                                    True -> {
                                                        7
                                                    }
                                                    False -> {
                                                        case v67 {
                                                            True -> {
                                                                8
                                                            }
                                                            False -> {
                                                                case v75 {
                                                                    True -> {
                                                                        9
                                                                    }
                                                                    False -> {
                                                                        case v83 {
                                                                            True -> {
                                                                                10
                                                                            }
                                                                            False -> {
                                                                                0
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            False -> {
                                                6
                                            }
                                        }
                                    }
                                    False -> {
                                        5
                                    }
                                }
                            }
                            False -> {
                                4
                            }
                        }
                    }
                    False -> {
                        3
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
