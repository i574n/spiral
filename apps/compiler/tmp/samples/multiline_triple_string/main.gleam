import gleam/bit_array
import gleam/string
pub fn spiral_string_length(text: String) -> Int {
  bit_array.byte_size(bit_array.from_string(text))
}

@external(erlang, "erlang", "halt")
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
let v12 = v11 == 7
let v13 = v12 != True
case v13 {
    True -> {
        1
    }
    False -> {
        let v14 = spiral_string_index(v6, 2)
        let v15 = v14 == "\""
        let v16 = v15 != True
        case v16 {
            True -> {
                2
            }
            False -> {
                let v17 = spiral_string_length(v7)
                let v18 = v17 == 0
                let v19 = v18 != True
                case v19 {
                    True -> {
                        3
                    }
                    False -> {
                        let v20 = spiral_string_length(v8)
                        let v21 = v20 == 4
                        let v22 = v21 != True
                        case v22 {
                            True -> {
                                4
                            }
                            False -> {
                                let v23 = spiral_string_index(v8, 1)
                                let v24 = v23 == "\\"
                                let v25 = v24 != True
                                case v25 {
                                    True -> {
                                        5
                                    }
                                    False -> {
                                        let v26 = spiral_string_length(v9)
                                        let v27 = v26 == 83
                                        let v28 = v27 != True
                                        case v28 {
                                            True -> {
                                                6
                                            }
                                            False -> {
                                                let v29 = spiral_string_index(v9, 5)
                                                let v30 = v29 == "\n"
                                                let v31 = v30 != True
                                                case v31 {
                                                    True -> {
                                                        7
                                                    }
                                                    False -> {
                                                        let v32 = spiral_string_index(v9, 37)
                                                        let v33 = v32 == "\n"
                                                        let v34 = v33 != True
                                                        case v34 {
                                                            True -> {
                                                                8
                                                            }
                                                            False -> {
                                                                let v35 = spiral_string_index(v9, 38)
                                                                let v36 = v35 == "\n"
                                                                let v37 = v36 != True
                                                                case v37 {
                                                                    True -> {
                                                                        9
                                                                    }
                                                                    False -> {
                                                                        let v38 = spiral_string_index(v9, 39)
                                                                        let v39 = v38 == "$"
                                                                        let v40 = v39 != True
                                                                        case v40 {
                                                                            True -> {
                                                                                10
                                                                            }
                                                                            False -> {
                                                                                let v41 = spiral_string_index(v9, 57)
                                                                                let v42 = v41 == "i"
                                                                                let v43 = v42 != True
                                                                                case v43 {
                                                                                    True -> {
                                                                                        11
                                                                                    }
                                                                                    False -> {
                                                                                        let v44 = spiral_string_index(v9, 82)
                                                                                        let v45 = v44 == "d"
                                                                                        let v46 = v45 != True
                                                                                        case v46 {
                                                                                            True -> {
                                                                                                12
                                                                                            }
                                                                                            False -> {
                                                                                                let v47 = spiral_string_length(v10)
                                                                                                let v48 = v47 == 11
                                                                                                let v49 = v48 != True
                                                                                                case v49 {
                                                                                                    True -> {
                                                                                                        13
                                                                                                    }
                                                                                                    False -> {
                                                                                                        let v50 = spiral_string_index(v10, 0)
                                                                                                        let v51 = v50 == "\n"
                                                                                                        let v52 = v51 != True
                                                                                                        case v52 {
                                                                                                            True -> {
                                                                                                                14
                                                                                                            }
                                                                                                            False -> {
                                                                                                                let v53 = spiral_string_index(v10, 5)
                                                                                                                let v54 = v53 == "\n"
                                                                                                                let v55 = v54 != True
                                                                                                                case v55 {
                                                                                                                    True -> {
                                                                                                                        15
                                                                                                                    }
                                                                                                                    False -> {
                                                                                                                        let v56 = v0 == 16
                                                                                                                        let v57 = v56 != True
                                                                                                                        case v57 {
                                                                                                                            True -> {
                                                                                                                                16
                                                                                                                            }
                                                                                                                            False -> {
                                                                                                                                let v58 = spiral_string_length(v1)
                                                                                                                                let v59 = v58 == 3
                                                                                                                                let v60 = v59 != True
                                                                                                                                case v60 {
                                                                                                                                    True -> {
                                                                                                                                        17
                                                                                                                                    }
                                                                                                                                    False -> {
                                                                                                                                        let v61 = spiral_string_length(v2)
                                                                                                                                        let v62 = v61 == 8
                                                                                                                                        let v63 = v62 != True
                                                                                                                                        case v63 {
                                                                                                                                            True -> {
                                                                                                                                                18
                                                                                                                                            }
                                                                                                                                            False -> {
                                                                                                                                                let v64 = spiral_string_index(v2, 7)
                                                                                                                                                let v65 = v64 == "\""
                                                                                                                                                let v66 = v65 != True
                                                                                                                                                case v66 {
                                                                                                                                                    True -> {
                                                                                                                                                        19
                                                                                                                                                    }
                                                                                                                                                    False -> {
                                                                                                                                                        let v67 = spiral_string_length(v3)
                                                                                                                                                        let v68 = v67 == 7
                                                                                                                                                        let v69 = v68 != True
                                                                                                                                                        case v69 {
                                                                                                                                                            True -> {
                                                                                                                                                                20
                                                                                                                                                            }
                                                                                                                                                            False -> {
                                                                                                                                                                let v70 = spiral_string_index(v3, 4)
                                                                                                                                                                let v71 = v70 == "\""
                                                                                                                                                                let v72 = v71 != True
                                                                                                                                                                case v72 {
                                                                                                                                                                    True -> {
                                                                                                                                                                        21
                                                                                                                                                                    }
                                                                                                                                                                    False -> {
                                                                                                                                                                        let v73 = spiral_string_length(v4)
                                                                                                                                                                        let v74 = v73 == 23
                                                                                                                                                                        let v75 = v74 != True
                                                                                                                                                                        case v75 {
                                                                                                                                                                            True -> {
                                                                                                                                                                                22
                                                                                                                                                                            }
                                                                                                                                                                            False -> {
                                                                                                                                                                                let v76 = spiral_string_index(v4, 6)
                                                                                                                                                                                let v77 = v76 == " "
                                                                                                                                                                                let v78 = v77 != True
                                                                                                                                                                                case v78 {
                                                                                                                                                                                    True -> {
                                                                                                                                                                                        23
                                                                                                                                                                                    }
                                                                                                                                                                                    False -> {
                                                                                                                                                                                        let v79 = spiral_string_index(v4, 10)
                                                                                                                                                                                        let v80 = v79 == "s"
                                                                                                                                                                                        let v81 = v80 != True
                                                                                                                                                                                        case v81 {
                                                                                                                                                                                            True -> {
                                                                                                                                                                                                24
                                                                                                                                                                                            }
                                                                                                                                                                                            False -> {
                                                                                                                                                                                                let v82 = spiral_string_index(v4, 17)
                                                                                                                                                                                                let v83 = v82 == "\n"
                                                                                                                                                                                                let v84 = v83 != True
                                                                                                                                                                                                case v84 {
                                                                                                                                                                                                    True -> {
                                                                                                                                                                                                        25
                                                                                                                                                                                                    }
                                                                                                                                                                                                    False -> {
                                                                                                                                                                                                        let v85 = spiral_string_index(v4, 22)
                                                                                                                                                                                                        let v86 = v85 == "d"
                                                                                                                                                                                                        let v87 = v86 != True
                                                                                                                                                                                                        case v87 {
                                                                                                                                                                                                            True -> {
                                                                                                                                                                                                                26
                                                                                                                                                                                                            }
                                                                                                                                                                                                            False -> {
                                                                                                                                                                                                                let v88 = spiral_string_length(v5)
                                                                                                                                                                                                                let v89 = v88 == 5
                                                                                                                                                                                                                let v90 = v89 != True
                                                                                                                                                                                                                case v90 {
                                                                                                                                                                                                                    True -> {
                                                                                                                                                                                                                        27
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                    False -> {
                                                                                                                                                                                                                        let v91 = spiral_string_index(v5, 3)
                                                                                                                                                                                                                        let v92 = v91 == "c"
                                                                                                                                                                                                                        let v93 = v92 != True
                                                                                                                                                                                                                        case v93 {
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
