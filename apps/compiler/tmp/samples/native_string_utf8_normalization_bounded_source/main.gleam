import gleam/bit_array
import gleam/string
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


pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn runtime_byte_1(v0: String, v1: Int) -> String {
    let v2 = spiral_string_index(v0, v1)
    v2
}
pub fn utf8_scalar_at_byte_offset_0(v0: String, v1: Int) -> Int {
    let v2 = spiral_string_length(v0)
    let v3 = v1 < 0
    case v3 {
        True -> panic as "UTF-8 byte offset is negative."
        False -> {
            let v5 = v1 >= v2
            case v5 {
                True -> panic as "UTF-8 byte offset is outside the string."
                False -> {
                    let v7 = runtime_byte_1(v0, v1)
                    let v8 = case string.to_utf_codepoints(v7) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                    let v9 = v8 < 128
                    case v9 {
                        True -> v8
                        False -> {
                            let v10 = v8 < 194
                            case v10 {
                                True -> panic as "UTF-8 scalar starts with an invalid lead byte."
                                False -> {
                                    let v12 = v8 < 224
                                    case v12 {
                                        True -> {
                                            let v13 = spiral_wrap_signed(v1 + 1, 32)
                                            let v14 = v13 >= v2
                                            case v14 {
                                                True -> panic as "UTF-8 sequence is truncated."
                                                False -> {
                                                    let v16 = runtime_byte_1(v0, v13)
                                                    let v17 = case string.to_utf_codepoints(v16) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                                                    let v18 = v17 < 128
                                                    let v20 =
                                                        case v18 {
                                                            True -> False
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
                                                        False -> panic as "UTF-8 sequence has an invalid continuation byte."
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
                                                        True -> panic as "UTF-8 sequence is truncated."
                                                        False -> {
                                                            let v32 = spiral_wrap_signed(v1 + 1, 32)
                                                            let v33 = runtime_byte_1(v0, v32)
                                                            let v34 = case string.to_utf_codepoints(v33) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                                                            let v35 = runtime_byte_1(v0, v29)
                                                            let v36 = case string.to_utf_codepoints(v35) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                                                            let v37 = v34 < 128
                                                            let v39 =
                                                                case v37 {
                                                                    True -> False
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
                                                                            True -> False
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
                                                                                True -> panic as "UTF-8 sequence is overlong."
                                                                                False -> {
                                                                                    let v52 = v49 >= 55296
                                                                                    case v52 {
                                                                                        True -> {
                                                                                            let v53 = v49 <= 57343
                                                                                            case v53 {
                                                                                                True -> panic as "UTF-8 sequence encodes a surrogate."
                                                                                                False -> v49
                                                                                            }
                                                                                        }
                                                                                        False -> v49
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        False -> panic as "UTF-8 sequence has an invalid continuation byte."
                                                                    }
                                                                }
                                                                False -> panic as "UTF-8 sequence has an invalid continuation byte."
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
                                                                True -> panic as "UTF-8 sequence is truncated."
                                                                False -> {
                                                                    let v67 = spiral_wrap_signed(v1 + 1, 32)
                                                                    let v68 = runtime_byte_1(v0, v67)
                                                                    let v69 = case string.to_utf_codepoints(v68) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                                                                    let v70 = spiral_wrap_signed(v1 + 2, 32)
                                                                    let v71 = runtime_byte_1(v0, v70)
                                                                    let v72 = case string.to_utf_codepoints(v71) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                                                                    let v73 = runtime_byte_1(v0, v64)
                                                                    let v74 = case string.to_utf_codepoints(v73) { [spiral_byte_codepoint] -> string.utf_codepoint_to_int(spiral_byte_codepoint) _ -> 0 }
                                                                    let v75 = v69 < 128
                                                                    let v77 =
                                                                        case v75 {
                                                                            True -> False
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
                                                                                    True -> False
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
                                                                                            True -> False
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
                                                                                                True -> panic as "UTF-8 sequence is overlong."
                                                                                                False -> {
                                                                                                    let v96 = v93 > 1114111
                                                                                                    case v96 {
                                                                                                        True -> panic as "UTF-8 scalar is above U+10FFFF."
                                                                                                        False -> v93
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        False -> panic as "UTF-8 sequence has an invalid continuation byte."
                                                                                    }
                                                                                }
                                                                                False -> panic as "UTF-8 sequence has an invalid continuation byte."
                                                                            }
                                                                        }
                                                                        False -> panic as "UTF-8 sequence has an invalid continuation byte."
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        False -> panic as "UTF-8 scalar starts with an invalid lead byte."
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
pub fn main() {
    let v0 = "é"
    let v1 = 0
    let v2 = utf8_scalar_at_byte_offset_0(v0, v1)
    let v3 = "õ"
    let v4 = 0
    let v5 = utf8_scalar_at_byte_offset_0(v3, v4)
    let v6 = "ç"
    let v7 = 0
    let v8 = utf8_scalar_at_byte_offset_0(v6, v7)
    let v9 = "́"
    let v10 = 0
    let v11 = utf8_scalar_at_byte_offset_0(v9, v10)
    let v12 = "̃"
    let v13 = 0
    let v14 = utf8_scalar_at_byte_offset_0(v12, v13)
    let v15 = "̧"
    let v16 = 0
    let v17 = utf8_scalar_at_byte_offset_0(v15, v16)
    let v18 = v2 == 192
    let #(v64, v65) =
        case v18 {
            True -> #(65, 768)
            False -> {
                let v19 = v2 == 193
                case v19 {
                    True -> #(65, 769)
                    False -> {
                        let v20 = v2 == 195
                        case v20 {
                            True -> #(65, 771)
                            False -> {
                                let v21 = v2 == 196
                                case v21 {
                                    True -> #(65, 776)
                                    False -> {
                                        let v22 = v2 == 199
                                        case v22 {
                                            True -> #(67, 807)
                                            False -> {
                                                let v23 = v2 == 201
                                                case v23 {
                                                    True -> #(69, 769)
                                                    False -> {
                                                        let v24 = v2 == 211
                                                        case v24 {
                                                            True -> #(79, 769)
                                                            False -> {
                                                                let v25 = v2 == 213
                                                                case v25 {
                                                                    True -> #(79, 771)
                                                                    False -> {
                                                                        let v26 = v2 == 224
                                                                        case v26 {
                                                                            True -> #(97, 768)
                                                                            False -> {
                                                                                let v27 = v2 == 225
                                                                                case v27 {
                                                                                    True -> #(97, 769)
                                                                                    False -> {
                                                                                        let v28 = v2 == 227
                                                                                        case v28 {
                                                                                            True -> #(97, 771)
                                                                                            False -> {
                                                                                                let v29 = v2 == 228
                                                                                                case v29 {
                                                                                                    True -> #(97, 776)
                                                                                                    False -> {
                                                                                                        let v30 = v2 == 231
                                                                                                        case v30 {
                                                                                                            True -> #(99, 807)
                                                                                                            False -> {
                                                                                                                let v31 = v2 == 233
                                                                                                                case v31 {
                                                                                                                    True -> #(101, 769)
                                                                                                                    False -> {
                                                                                                                        let v32 = v2 == 243
                                                                                                                        case v32 {
                                                                                                                            True -> #(111, 769)
                                                                                                                            False -> {
                                                                                                                                let v33 = v2 == 245
                                                                                                                                case v33 {
                                                                                                                                    True -> #(111, 771)
                                                                                                                                    False -> #(v2, -1)
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
    let v66 = v5 == 192
    let #(v112, v113) =
        case v66 {
            True -> #(65, 768)
            False -> {
                let v67 = v5 == 193
                case v67 {
                    True -> #(65, 769)
                    False -> {
                        let v68 = v5 == 195
                        case v68 {
                            True -> #(65, 771)
                            False -> {
                                let v69 = v5 == 196
                                case v69 {
                                    True -> #(65, 776)
                                    False -> {
                                        let v70 = v5 == 199
                                        case v70 {
                                            True -> #(67, 807)
                                            False -> {
                                                let v71 = v5 == 201
                                                case v71 {
                                                    True -> #(69, 769)
                                                    False -> {
                                                        let v72 = v5 == 211
                                                        case v72 {
                                                            True -> #(79, 769)
                                                            False -> {
                                                                let v73 = v5 == 213
                                                                case v73 {
                                                                    True -> #(79, 771)
                                                                    False -> {
                                                                        let v74 = v5 == 224
                                                                        case v74 {
                                                                            True -> #(97, 768)
                                                                            False -> {
                                                                                let v75 = v5 == 225
                                                                                case v75 {
                                                                                    True -> #(97, 769)
                                                                                    False -> {
                                                                                        let v76 = v5 == 227
                                                                                        case v76 {
                                                                                            True -> #(97, 771)
                                                                                            False -> {
                                                                                                let v77 = v5 == 228
                                                                                                case v77 {
                                                                                                    True -> #(97, 776)
                                                                                                    False -> {
                                                                                                        let v78 = v5 == 231
                                                                                                        case v78 {
                                                                                                            True -> #(99, 807)
                                                                                                            False -> {
                                                                                                                let v79 = v5 == 233
                                                                                                                case v79 {
                                                                                                                    True -> #(101, 769)
                                                                                                                    False -> {
                                                                                                                        let v80 = v5 == 243
                                                                                                                        case v80 {
                                                                                                                            True -> #(111, 769)
                                                                                                                            False -> {
                                                                                                                                let v81 = v5 == 245
                                                                                                                                case v81 {
                                                                                                                                    True -> #(111, 771)
                                                                                                                                    False -> #(v5, -1)
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
    let v114 = v8 == 192
    let #(v160, v161) =
        case v114 {
            True -> #(65, 768)
            False -> {
                let v115 = v8 == 193
                case v115 {
                    True -> #(65, 769)
                    False -> {
                        let v116 = v8 == 195
                        case v116 {
                            True -> #(65, 771)
                            False -> {
                                let v117 = v8 == 196
                                case v117 {
                                    True -> #(65, 776)
                                    False -> {
                                        let v118 = v8 == 199
                                        case v118 {
                                            True -> #(67, 807)
                                            False -> {
                                                let v119 = v8 == 201
                                                case v119 {
                                                    True -> #(69, 769)
                                                    False -> {
                                                        let v120 = v8 == 211
                                                        case v120 {
                                                            True -> #(79, 769)
                                                            False -> {
                                                                let v121 = v8 == 213
                                                                case v121 {
                                                                    True -> #(79, 771)
                                                                    False -> {
                                                                        let v122 = v8 == 224
                                                                        case v122 {
                                                                            True -> #(97, 768)
                                                                            False -> {
                                                                                let v123 = v8 == 225
                                                                                case v123 {
                                                                                    True -> #(97, 769)
                                                                                    False -> {
                                                                                        let v124 = v8 == 227
                                                                                        case v124 {
                                                                                            True -> #(97, 771)
                                                                                            False -> {
                                                                                                let v125 = v8 == 228
                                                                                                case v125 {
                                                                                                    True -> #(97, 776)
                                                                                                    False -> {
                                                                                                        let v126 = v8 == 231
                                                                                                        case v126 {
                                                                                                            True -> #(99, 807)
                                                                                                            False -> {
                                                                                                                let v127 = v8 == 233
                                                                                                                case v127 {
                                                                                                                    True -> #(101, 769)
                                                                                                                    False -> {
                                                                                                                        let v128 = v8 == 243
                                                                                                                        case v128 {
                                                                                                                            True -> #(111, 769)
                                                                                                                            False -> {
                                                                                                                                let v129 = v8 == 245
                                                                                                                                case v129 {
                                                                                                                                    True -> #(111, 771)
                                                                                                                                    False -> #(v8, -1)
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
    let v162 = v11 == 769
    let v163 =
        case v162 {
            True -> 233
            False -> -1
        }
    let v164 = v163 < 0
    let #(v165, v166) =
        case v164 {
            True -> #(101, v11)
            False -> #(v163, -1)
        }
    let v167 = v14 == 769
    let v170 =
        case v167 {
            True -> 243
            False -> {
                let v168 = v14 == 771
                case v168 {
                    True -> 245
                    False -> -1
                }
            }
        }
    let v171 = v170 < 0
    let #(v172, v173) =
        case v171 {
            True -> #(111, v14)
            False -> #(v170, -1)
        }
    let v174 = v17 == 807
    let v175 =
        case v174 {
            True -> 231
            False -> -1
        }
    let v176 = v175 < 0
    let #(v177, v178) =
        case v176 {
            True -> #(99, v17)
            False -> #(v175, -1)
        }
    let v179 = v64 == 101
    let v181 =
        case v179 {
            True -> {
                let v180 = v65 == v11
                v180
            }
            False -> False
        }
    case v181 {
        True -> {
            let v182 = v112 == 111
            let v184 =
                case v182 {
                    True -> {
                        let v183 = v113 == v14
                        v183
                    }
                    False -> False
                }
            case v184 {
                True -> {
                    let v185 = v160 == 99
                    let v187 =
                        case v185 {
                            True -> {
                                let v186 = v161 == v17
                                v186
                            }
                            False -> False
                        }
                    case v187 {
                        True -> {
                            let v188 = v165 == v2
                            let v190 =
                                case v188 {
                                    True -> {
                                        let v189 = v166 == -1
                                        v189
                                    }
                                    False -> False
                                }
                            case v190 {
                                True -> {
                                    let v191 = v172 == v5
                                    let v193 =
                                        case v191 {
                                            True -> {
                                                let v192 = v173 == -1
                                                v192
                                            }
                                            False -> False
                                        }
                                    case v193 {
                                        True -> {
                                            let v194 = v177 == v8
                                            let v196 =
                                                case v194 {
                                                    True -> {
                                                        let v195 = v178 == -1
                                                        v195
                                                    }
                                                    False -> False
                                                }
                                            case v196 {
                                                True -> 0
                                                False -> 6
                                            }
                                        }
                                        False -> 5
                                    }
                                }
                                False -> 4
                            }
                        }
                        False -> 3
                    }
                }
                False -> 2
            }
        }
        False -> 1
    }
}
