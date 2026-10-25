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
let v0 = 16
let v1 = "x\ny"
let v2 = "say \"hi\""
let v3 = "a \"\"\" b"
let v4 = "first\n    second\n\nthird"
let v5 = "ab\ncd"
let v6 = "a \"b\" c"
let v7 = ""
let v8 = "a\\nb"
let v9 = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
let v10 = "\ntop\n\nlevel"
let v11 = spiral_string_length(v6)
let v12 = v11 != 7
case v12 {
    True -> {
        1
    }
    False -> {
        let v13 = spiral_string_index(v6, 2)
        let v14 = v13 != "\""
        case v14 {
            True -> {
                2
            }
            False -> {
                let v15 = spiral_string_length(v7)
                let v16 = v15 != 0
                case v16 {
                    True -> {
                        3
                    }
                    False -> {
                        let v17 = spiral_string_length(v8)
                        let v18 = v17 != 4
                        case v18 {
                            True -> {
                                4
                            }
                            False -> {
                                let v19 = spiral_string_index(v8, 1)
                                let v20 = v19 != "\\"
                                case v20 {
                                    True -> {
                                        5
                                    }
                                    False -> {
                                        let v21 = spiral_string_length(v9)
                                        let v22 = v21 != 83
                                        case v22 {
                                            True -> {
                                                6
                                            }
                                            False -> {
                                                let v23 = spiral_string_index(v9, 5)
                                                let v24 = v23 != "\n"
                                                case v24 {
                                                    True -> {
                                                        7
                                                    }
                                                    False -> {
                                                        let v25 = spiral_string_index(v9, 37)
                                                        let v26 = v25 != "\n"
                                                        case v26 {
                                                            True -> {
                                                                8
                                                            }
                                                            False -> {
                                                                let v27 = spiral_string_index(v9, 38)
                                                                let v28 = v27 != "\n"
                                                                case v28 {
                                                                    True -> {
                                                                        9
                                                                    }
                                                                    False -> {
                                                                        let v29 = spiral_string_index(v9, 39)
                                                                        let v30 = v29 != "$"
                                                                        case v30 {
                                                                            True -> {
                                                                                10
                                                                            }
                                                                            False -> {
                                                                                let v31 = spiral_string_index(v9, 57)
                                                                                let v32 = v31 != "i"
                                                                                case v32 {
                                                                                    True -> {
                                                                                        11
                                                                                    }
                                                                                    False -> {
                                                                                        let v33 = spiral_string_index(v9, 82)
                                                                                        let v34 = v33 != "d"
                                                                                        case v34 {
                                                                                            True -> {
                                                                                                12
                                                                                            }
                                                                                            False -> {
                                                                                                let v35 = spiral_string_length(v10)
                                                                                                let v36 = v35 != 11
                                                                                                case v36 {
                                                                                                    True -> {
                                                                                                        13
                                                                                                    }
                                                                                                    False -> {
                                                                                                        let v37 = spiral_string_index(v10, 0)
                                                                                                        let v38 = v37 != "\n"
                                                                                                        case v38 {
                                                                                                            True -> {
                                                                                                                14
                                                                                                            }
                                                                                                            False -> {
                                                                                                                let v39 = spiral_string_index(v10, 5)
                                                                                                                let v40 = v39 != "\n"
                                                                                                                case v40 {
                                                                                                                    True -> {
                                                                                                                        15
                                                                                                                    }
                                                                                                                    False -> {
                                                                                                                        let v41 = v0 != 16
                                                                                                                        case v41 {
                                                                                                                            True -> {
                                                                                                                                16
                                                                                                                            }
                                                                                                                            False -> {
                                                                                                                                let v42 = spiral_string_length(v1)
                                                                                                                                let v43 = v42 != 3
                                                                                                                                case v43 {
                                                                                                                                    True -> {
                                                                                                                                        17
                                                                                                                                    }
                                                                                                                                    False -> {
                                                                                                                                        let v44 = spiral_string_length(v2)
                                                                                                                                        let v45 = v44 != 8
                                                                                                                                        case v45 {
                                                                                                                                            True -> {
                                                                                                                                                18
                                                                                                                                            }
                                                                                                                                            False -> {
                                                                                                                                                let v46 = spiral_string_index(v2, 7)
                                                                                                                                                let v47 = v46 != "\""
                                                                                                                                                case v47 {
                                                                                                                                                    True -> {
                                                                                                                                                        19
                                                                                                                                                    }
                                                                                                                                                    False -> {
                                                                                                                                                        let v48 = spiral_string_length(v3)
                                                                                                                                                        let v49 = v48 != 7
                                                                                                                                                        case v49 {
                                                                                                                                                            True -> {
                                                                                                                                                                20
                                                                                                                                                            }
                                                                                                                                                            False -> {
                                                                                                                                                                let v50 = spiral_string_index(v3, 4)
                                                                                                                                                                let v51 = v50 != "\""
                                                                                                                                                                case v51 {
                                                                                                                                                                    True -> {
                                                                                                                                                                        21
                                                                                                                                                                    }
                                                                                                                                                                    False -> {
                                                                                                                                                                        let v52 = spiral_string_length(v4)
                                                                                                                                                                        let v53 = v52 != 23
                                                                                                                                                                        case v53 {
                                                                                                                                                                            True -> {
                                                                                                                                                                                22
                                                                                                                                                                            }
                                                                                                                                                                            False -> {
                                                                                                                                                                                let v54 = spiral_string_index(v4, 6)
                                                                                                                                                                                let v55 = v54 != " "
                                                                                                                                                                                case v55 {
                                                                                                                                                                                    True -> {
                                                                                                                                                                                        23
                                                                                                                                                                                    }
                                                                                                                                                                                    False -> {
                                                                                                                                                                                        let v56 = spiral_string_index(v4, 10)
                                                                                                                                                                                        let v57 = v56 != "s"
                                                                                                                                                                                        case v57 {
                                                                                                                                                                                            True -> {
                                                                                                                                                                                                24
                                                                                                                                                                                            }
                                                                                                                                                                                            False -> {
                                                                                                                                                                                                let v58 = spiral_string_index(v4, 17)
                                                                                                                                                                                                let v59 = v58 != "\n"
                                                                                                                                                                                                case v59 {
                                                                                                                                                                                                    True -> {
                                                                                                                                                                                                        25
                                                                                                                                                                                                    }
                                                                                                                                                                                                    False -> {
                                                                                                                                                                                                        let v60 = spiral_string_index(v4, 22)
                                                                                                                                                                                                        let v61 = v60 != "d"
                                                                                                                                                                                                        case v61 {
                                                                                                                                                                                                            True -> {
                                                                                                                                                                                                                26
                                                                                                                                                                                                            }
                                                                                                                                                                                                            False -> {
                                                                                                                                                                                                                let v62 = spiral_string_length(v5)
                                                                                                                                                                                                                let v63 = v62 != 5
                                                                                                                                                                                                                case v63 {
                                                                                                                                                                                                                    True -> {
                                                                                                                                                                                                                        27
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                    False -> {
                                                                                                                                                                                                                        let v64 = spiral_string_index(v5, 3)
                                                                                                                                                                                                                        let v65 = v64 != "c"
                                                                                                                                                                                                                        case v65 {
                                                                                                                                                                                                                            True -> {
                                                                                                                                                                                                                                28
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
