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

pub fn main() {
let v0 = "a \"b\" c"
let v1 = ""
let v2 = "a\\nb"
let v3 = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
let v4 = "\ntop\n\nlevel"
let v5 = spiral_string_length(v0)
let v6 = v5 == 7
let v7 = v6 != True
case v7 {
    True -> {
        1
    }
    False -> {
        let v8 = spiral_string_index(v0, 2)
        let v9 = v8 == "\""
        let v10 = v9 != True
        case v10 {
            True -> {
                2
            }
            False -> {
                let v11 = spiral_string_length(v1)
                let v12 = v11 == 0
                let v13 = v12 != True
                case v13 {
                    True -> {
                        3
                    }
                    False -> {
                        let v14 = spiral_string_length(v2)
                        let v15 = v14 == 4
                        let v16 = v15 != True
                        case v16 {
                            True -> {
                                4
                            }
                            False -> {
                                let v17 = spiral_string_index(v2, 1)
                                let v18 = v17 == "\\"
                                let v19 = v18 != True
                                case v19 {
                                    True -> {
                                        5
                                    }
                                    False -> {
                                        let v20 = spiral_string_length(v3)
                                        let v21 = v20 == 83
                                        let v22 = v21 != True
                                        case v22 {
                                            True -> {
                                                6
                                            }
                                            False -> {
                                                let v23 = spiral_string_index(v3, 5)
                                                let v24 = v23 == "\n"
                                                let v25 = v24 != True
                                                case v25 {
                                                    True -> {
                                                        7
                                                    }
                                                    False -> {
                                                        let v26 = spiral_string_index(v3, 37)
                                                        let v27 = v26 == "\n"
                                                        let v28 = v27 != True
                                                        case v28 {
                                                            True -> {
                                                                8
                                                            }
                                                            False -> {
                                                                let v29 = spiral_string_index(v3, 38)
                                                                let v30 = v29 == "\n"
                                                                let v31 = v30 != True
                                                                case v31 {
                                                                    True -> {
                                                                        9
                                                                    }
                                                                    False -> {
                                                                        let v32 = spiral_string_index(v3, 39)
                                                                        let v33 = v32 == "$"
                                                                        let v34 = v33 != True
                                                                        case v34 {
                                                                            True -> {
                                                                                10
                                                                            }
                                                                            False -> {
                                                                                let v35 = spiral_string_index(v3, 57)
                                                                                let v36 = v35 == "i"
                                                                                let v37 = v36 != True
                                                                                case v37 {
                                                                                    True -> {
                                                                                        11
                                                                                    }
                                                                                    False -> {
                                                                                        let v38 = spiral_string_index(v3, 82)
                                                                                        let v39 = v38 == "d"
                                                                                        let v40 = v39 != True
                                                                                        case v40 {
                                                                                            True -> {
                                                                                                12
                                                                                            }
                                                                                            False -> {
                                                                                                let v41 = spiral_string_length(v4)
                                                                                                let v42 = v41 == 11
                                                                                                let v43 = v42 != True
                                                                                                case v43 {
                                                                                                    True -> {
                                                                                                        13
                                                                                                    }
                                                                                                    False -> {
                                                                                                        let v44 = spiral_string_index(v4, 0)
                                                                                                        let v45 = v44 == "\n"
                                                                                                        let v46 = v45 != True
                                                                                                        case v46 {
                                                                                                            True -> {
                                                                                                                14
                                                                                                            }
                                                                                                            False -> {
                                                                                                                let v47 = spiral_string_index(v4, 5)
                                                                                                                let v48 = v47 == "\n"
                                                                                                                let v49 = v48 != True
                                                                                                                case v49 {
                                                                                                                    True -> {
                                                                                                                        15
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
