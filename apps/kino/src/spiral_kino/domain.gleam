@external(erlang, "erlang", "byte_size")
fn kino_text_size(text: String) -> Int
@external(erlang, "binary", "part")
fn kino_text_part(text: String, at: Int, len: Int) -> String
fn kino_text_at(text: String, at: Int, len: Int) -> String {
  let size = kino_text_size(text)
  case at >= 0 && len > 0 && at < size {
    True -> case at + len > size {
      True -> kino_text_part(text, at, size - at)
      False -> kino_text_part(text, at, len)
    }
    False -> ""
  }
}
@external(erlang, "binary", "at")
fn kino_text_byte(text: String, at: Int) -> Int
@external(erlang, "string", "lowercase")
fn kino_text_lower(text: String) -> String
import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Us0 {
    Us0LineDone
    Us0LineGot(f1i0 : String, f1i1 : Int)
}
pub type Uh0 {
    Uh0NoLine
    Uh0Line(String, Uh0)
}
pub type Uh1 {
    Uh1NoToken
    Uh1Token(String, Uh1)
}
pub type Us1 {
    Us1Parsed(f0i0 : Int, f0i1 : Int, f0i2 : String)
    Us1ParseBad(f1i0 : String)
}
pub type Uh2 {
    Uh2NoPair
    Uh2Pair(String, String, Uh2)
}
pub type Uh3 {
    Uh3NoCell
    Uh3Cell(String, String, Uh3)
}
pub type Us2 {
    Us2NoMark
    Us2Mark(f1i0 : String, f1i1 : String)
}
pub type Us3 {
    Us3SpiExport
    Us3SpirExport
}
pub type Uh4 {
    Uh4NoRow
    Uh4Row(String, Uh4)
}
pub type Us4 {
    Us4Between
    Us4InDoc(f1i0 : Uh4)
    Us4InCode(f2i0 : Uh4)
    Us4InTest(f3i0 : String, f3i1 : String, f3i2 : Uh4, f3i3 : Uh4)
}
pub type Us5 {
    Us5NoHeader
    Us5Header(f1i0 : String, f1i1 : String)
}
pub type Us6 {
    Us6SpiRealm
    Us6RealRealm
}
pub type Uh5 {
    Uh5NoNb
    Uh5Nb(String, Uh5)
}
pub type Us7 {
    Us7EveryCell
    Us7TestsAndWholeFile
}
pub type Uh6 {
    Uh6NoSource
    Uh6Source(String, String, Uh6)
}
pub type Uh7 {
    Uh7NoStep
    Uh7Step(Int, String, String, String, Uh7)
}
pub type Uh8 {
    Uh8NoFlag
    Uh8Flag(String, Uh8)
}
pub fn find_from_1(v0: String, v1: String, v2: Int) -> Int {
    let v3 = kino_text_size(v1)
    let v4 = kino_text_size(v0)
    let v5 = v3 == 0
    case v5 {
        True -> {
            v2
        }
        False -> {
            let v6 = spiral_wrap_signed(v2 + v3, 32)
            let v7 = v6 > v4
            case v7 {
                True -> {
                    -1
                }
                False -> {
                    let v8 = kino_text_size(v1)
                    let v9 = v2 < 0
                    let v21 =
                        case v9 {
                            True -> {
                                False
                            }
                            False -> {
                                let v10 = spiral_wrap_signed(v2 + v8, 32)
                                let v11 = kino_text_size(v0)
                                let v12 = v10 > v11
                                case v12 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v13 = v8 == 0
                                        case v13 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v14 = spiral_wrap_signed(v10 - 1, 32)
                                                let v15 = spiral_wrap_signed(v14 - v2, 32)
                                                let v16 = spiral_wrap_signed(v15 + 1, 32)
                                                let v17 = kino_text_at(v0, v2, v16)
                                                let v18 = v17 == v1
                                                v18
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    case v21 {
                        True -> {
                            v2
                        }
                        False -> {
                            let v22 = spiral_wrap_signed(v2 + 1, 32)
                            find_from_1(v0, v1, v22)
                        }
                    }
                }
            }
        }
    }
}
pub fn replace_from_0(v0: String, v1: String, v2: String, v3: Int, v4: String) -> String {
    let v5 = find_from_1(v0, v1, v3)
    let v6 = v5 < 0
    case v6 {
        True -> {
            let v7 = v3 == 0
            case v7 {
                True -> {
                    v0
                }
                False -> {
                    let v8 = kino_text_size(v0)
                    let v9 = v3 >= v8
                    let v17 =
                        case v9 {
                            True -> {
                                let v10 = ""
                                v10
                            }
                            False -> {
                                let v11 = v3 <= 0
                                case v11 {
                                    True -> {
                                        v0
                                    }
                                    False -> {
                                        let v12 = spiral_wrap_signed(v8 - 1, 32)
                                        let v13 = spiral_wrap_signed(v12 - v3, 32)
                                        let v14 = spiral_wrap_signed(v13 + 1, 32)
                                        let v15 = kino_text_at(v0, v3, v14)
                                        v15
                                    }
                                }
                            }
                        }
                    let v18 = { v4 } <> { v17 }
                    v18
                }
            }
        }
        False -> {
            let v20 = kino_text_size(v1)
            let v21 = spiral_wrap_signed(v5 + v20, 32)
            let v22 = spiral_wrap_signed(v5 - v3, 32)
            let v23 = v22 <= 0
            let v42 =
                case v23 {
                    True -> {
                        let v24 = ""
                        v24
                    }
                    False -> {
                        let v25 = kino_text_size(v0)
                        let v26 = v3 >= v25
                        case v26 {
                            True -> {
                                let v27 = ""
                                v27
                            }
                            False -> {
                                let v28 = spiral_wrap_signed(v3 + v22, 32)
                                let v29 = spiral_wrap_signed(v28 - 1, 32)
                                let v30 = kino_text_size(v0)
                                let v31 = v29 >= v30
                                let v34 =
                                    case v31 {
                                        True -> {
                                            let v32 = kino_text_size(v0)
                                            let v33 = spiral_wrap_signed(v32 - 1, 32)
                                            v33
                                        }
                                        False -> {
                                            v29
                                        }
                                    }
                                let v35 = v34 < v3
                                case v35 {
                                    True -> {
                                        let v36 = ""
                                        v36
                                    }
                                    False -> {
                                        let v37 = spiral_wrap_signed(v34 - v3, 32)
                                        let v38 = spiral_wrap_signed(v37 + 1, 32)
                                        let v39 = kino_text_at(v0, v3, v38)
                                        v39
                                    }
                                }
                            }
                        }
                    }
                }
            let v43 = { v4 } <> { v42 }
            let v44 = { v43 } <> { v2 }
            replace_from_0(v0, v1, v2, v21, v44)
        }
    }
}
pub fn find_char_3(v0: String, v1: Int, v2: String) -> Int {
    let v3 = kino_text_size(v0)
    let v4 = v1 >= v3
    case v4 {
        True -> {
            -1
        }
        False -> {
            let v5 = kino_text_at(v0, v1, 1)
            let v6 = v5 == v2
            case v6 {
                True -> {
                    v1
                }
                False -> {
                    let v7 = spiral_wrap_signed(v1 + 1, 32)
                    find_char_3(v0, v7, v2)
                }
            }
        }
    }
}
pub fn rev_lines_5(v0: Uh0, v1: Uh0) -> Uh0 {
    case v0  {
        Uh0Line(v2, v3) -> {
            let v4 = Uh0Line(v2, v1)
            rev_lines_5(v3, v4)
        }
        Uh0NoLine -> {
            v1
        }
    }
}
pub fn collect_4(v0: String, v1: Int, v2: Uh0) -> Uh0 {
    let v3 = kino_text_size(v0)
    let v4 = v1 > v3
    let v44 =
        case v4 {
            True -> {
                Us0LineDone
            }
            False -> {
                let v6 = v3 == 0
                let v8 =
                    case v6 {
                        True -> {
                            let v7 = v1 == 0
                            v7
                        }
                        False -> {
                            False
                        }
                    }
                case v8 {
                    True -> {
                        let v9 = ""
                        Us0LineGot(v9, 1)
                    }
                    False -> {
                        let v11 = v1 == v3
                        case v11 {
                            True -> {
                                let v12 = v3 > 0
                                let v16 =
                                    case v12 {
                                        True -> {
                                            let v13 = spiral_wrap_signed(v3 - 1, 32)
                                            let v14 = kino_text_at(v0, v13, 1)
                                            let v15 = v14 == "\n"
                                            v15
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v16 {
                                    True -> {
                                        let v17 = spiral_wrap_signed(v3 + 1, 32)
                                        let v18 = ""
                                        Us0LineGot(v18, v17)
                                    }
                                    False -> {
                                        Us0LineDone
                                    }
                                }
                            }
                            False -> {
                                let v22 = "\n"
                                let v23 = find_char_3(v0, v1, v22)
                                let v24 = v23 < 0
                                case v24 {
                                    True -> {
                                        let v25 = spiral_wrap_signed(v3 - 1, 32)
                                        let v26 = spiral_wrap_signed(v25 - v1, 32)
                                        let v27 = spiral_wrap_signed(v26 + 1, 32)
                                        let v28 = kino_text_at(v0, v1, v27)
                                        Us0LineGot(v28, v3)
                                    }
                                    False -> {
                                        let v30 = v23 == v1
                                        case v30 {
                                            True -> {
                                                let v31 = spiral_wrap_signed(v23 + 1, 32)
                                                let v32 = ""
                                                Us0LineGot(v32, v31)
                                            }
                                            False -> {
                                                let v34 = spiral_wrap_signed(v23 - 1, 32)
                                                let v35 = spiral_wrap_signed(v34 - v1, 32)
                                                let v36 = spiral_wrap_signed(v35 + 1, 32)
                                                let v37 = kino_text_at(v0, v1, v36)
                                                let v38 = spiral_wrap_signed(v23 + 1, 32)
                                                Us0LineGot(v37, v38)
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
    case v44  {
        Us0LineDone -> {
            let v45 = Uh0NoLine
            rev_lines_5(v2, v45)
        }
        Us0LineGot(v47, v48) -> {
            let v49 = Uh0Line(v47, v2)
            collect_4(v0, v48, v49)
        }
    }
}
pub fn count_lines_6(v0: Uh0) -> Int {
    case v0  {
        Uh0Line(v1, v2) -> {
            let v3 = count_lines_6(v2)
            let v4 = spiral_wrap_signed(1 + v3, 32)
            v4
        }
        Uh0NoLine -> {
            0
        }
    }
}
pub fn nth_line_8(v0: Uh0, v1: Int) -> String {
    case v0  {
        Uh0Line(v3, v4) -> {
            let v5 = v1 == 0
            case v5 {
                True -> {
                    v3
                }
                False -> {
                    let v6 = spiral_wrap_signed(v1 - 1, 32)
                    nth_line_8(v4, v6)
                }
            }
        }
        Uh0NoLine -> {
            let v2 = ""
            v2
        }
    }
}
pub fn last_block_7(v0: Uh0, v1: Int) -> Int {
    let v2 = v1 < 0
    case v2 {
        True -> {
            -1
        }
        False -> {
            let v3 = nth_line_8(v0, v1)
            let v4 = v3 == ""
            let v5 = v4 != True
            let v18 =
                case v5 {
                    True -> {
                        let v6 = " "
                        let v7 = kino_text_size(v6)
                        let v8 = kino_text_size(v3)
                        let v9 = v7 > v8
                        let v16 =
                            case v9 {
                                True -> {
                                    False
                                }
                                False -> {
                                    let v10 = v7 == 0
                                    case v10 {
                                        True -> {
                                            True
                                        }
                                        False -> {
                                            let v11 = spiral_wrap_signed(v7 - 1, 32)
                                            let v12 = spiral_wrap_signed(v11 + 1, 32)
                                            let v13 = kino_text_at(v3, 0, v12)
                                            let v14 = v13 == " "
                                            v14
                                        }
                                    }
                                }
                            }
                        let v17 = v16 == False
                        v17
                    }
                    False -> {
                        False
                    }
                }
            case v18 {
                True -> {
                    v1
                }
                False -> {
                    let v19 = spiral_wrap_signed(v1 - 1, 32)
                    last_block_7(v0, v19)
                }
            }
        }
    }
}
pub fn skip_spaces_10(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 < v2
    let v6 =
        case v3 {
            True -> {
                let v4 = kino_text_at(v0, v1, 1)
                let v5 = v4 == " "
                v5
            }
            False -> {
                False
            }
        }
    case v6 {
        True -> {
            let v7 = spiral_wrap_signed(v1 + 1, 32)
            skip_spaces_10(v0, v7)
        }
        False -> {
            v1
        }
    }
}
pub fn has_char_12(v0: String, v1: Int, v2: String) -> Bool {
    let v3 = kino_text_size(v0)
    let v4 = v1 >= v3
    case v4 {
        True -> {
            False
        }
        False -> {
            let v5 = kino_text_at(v0, v1, 1)
            let v6 = v5 == v2
            case v6 {
                True -> {
                    True
                }
                False -> {
                    let v7 = spiral_wrap_signed(v1 + 1, 32)
                    has_char_12(v0, v7, v2)
                }
            }
        }
    }
}
pub fn take_name_11(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 < v2
    let v12 =
        case v3 {
            True -> {
                let v4 = kino_text_at(v0, v1, 1)
                let v5 = v4 == "~"
                case v5 {
                    True -> {
                        True
                    }
                    False -> {
                        let v6 = v4 == "("
                        case v6 {
                            True -> {
                                True
                            }
                            False -> {
                                let v7 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_'"
                                let v8 = 0
                                has_char_12(v7, v8, v4)
                            }
                        }
                    }
                }
            }
            False -> {
                False
            }
        }
    case v12 {
        True -> {
            let v13 = spiral_wrap_signed(v1 + 1, 32)
            take_name_11(v0, v13)
        }
        False -> {
            v1
        }
    }
}
pub fn take_ident_13(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 < v2
    let v8 =
        case v3 {
            True -> {
                let v4 = kino_text_at(v0, v1, 1)
                let v5 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_'"
                let v6 = 0
                has_char_12(v5, v6, v4)
            }
            False -> {
                False
            }
        }
    case v8 {
        True -> {
            let v9 = spiral_wrap_signed(v1 + 1, 32)
            take_ident_13(v0, v9)
        }
        False -> {
            v1
        }
    }
}
pub fn take_spaces_or_brace_14(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = v4 == " "
            let v7 =
                case v5 {
                    True -> {
                        True
                    }
                    False -> {
                        let v6 = v4 == "}"
                        v6
                    }
                }
            case v7 {
                True -> {
                    let v8 = spiral_wrap_signed(v1 + 1, 32)
                    take_spaces_or_brace_14(v0, v8)
                }
                False -> {
                    v1
                }
            }
        }
    }
}
pub fn take_tilde_word_15(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            -1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = v4 == "~"
            let v9 =
                case v5 {
                    True -> {
                        True
                    }
                    False -> {
                        let v6 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_'"
                        let v7 = 0
                        has_char_12(v6, v7, v4)
                    }
                }
            case v9 {
                True -> {
                    let v10 = spiral_wrap_signed(v1 + 1, 32)
                    take_ident_13(v0, v10)
                }
                False -> {
                    -1
                }
            }
        }
    }
}
pub fn search_top_9(v0: Uh0, v1: Int, v2: Int) -> Int {
    let v3 = v1 < 0
    case v3 {
        True -> {
            v2
        }
        False -> {
            let v4 = nth_line_8(v0, v1)
            let v5 = v4 == ""
            case v5 {
                True -> {
                    let v6 = spiral_wrap_signed(v1 - 1, 32)
                    search_top_9(v0, v6, v2)
                }
                False -> {
                    let v8 = " "
                    let v9 = kino_text_size(v8)
                    let v10 = kino_text_size(v4)
                    let v11 = v9 > v10
                    let v18 =
                        case v11 {
                            True -> {
                                False
                            }
                            False -> {
                                let v12 = v9 == 0
                                case v12 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v13 = spiral_wrap_signed(v9 - 1, 32)
                                        let v14 = spiral_wrap_signed(v13 + 1, 32)
                                        let v15 = kino_text_at(v4, 0, v14)
                                        let v16 = v15 == " "
                                        v16
                                    }
                                }
                            }
                        }
                    case v18 {
                        True -> {
                            let v19 = spiral_wrap_signed(v1 - 1, 32)
                            search_top_9(v0, v19, v2)
                        }
                        False -> {
                            let v21 = "// "
                            let v22 = kino_text_size(v21)
                            let v23 = kino_text_size(v4)
                            let v24 = v22 > v23
                            let v31 =
                                case v24 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v25 = v22 == 0
                                        case v25 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v26 = spiral_wrap_signed(v22 - 1, 32)
                                                let v27 = spiral_wrap_signed(v26 + 1, 32)
                                                let v28 = kino_text_at(v4, 0, v27)
                                                let v29 = v28 == "// "
                                                v29
                                            }
                                        }
                                    }
                                }
                            case v31 {
                                True -> {
                                    let v32 = spiral_wrap_signed(v1 - 1, 32)
                                    search_top_9(v0, v32, v2)
                                }
                                False -> {
                                    let v34 = "open "
                                    let v35 = kino_text_size(v34)
                                    let v36 = kino_text_size(v4)
                                    let v37 = v35 > v36
                                    let v44 =
                                        case v37 {
                                            True -> {
                                                False
                                            }
                                            False -> {
                                                let v38 = v35 == 0
                                                case v38 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v39 = spiral_wrap_signed(v35 - 1, 32)
                                                        let v40 = spiral_wrap_signed(v39 + 1, 32)
                                                        let v41 = kino_text_at(v4, 0, v40)
                                                        let v42 = v41 == "open "
                                                        v42
                                                    }
                                                }
                                            }
                                        }
                                    let v104 =
                                        case v44 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v45 = "prototype "
                                                let v46 = kino_text_size(v45)
                                                let v47 = kino_text_size(v4)
                                                let v48 = v46 > v47
                                                let v55 =
                                                    case v48 {
                                                        True -> {
                                                            False
                                                        }
                                                        False -> {
                                                            let v49 = v46 == 0
                                                            case v49 {
                                                                True -> {
                                                                    True
                                                                }
                                                                False -> {
                                                                    let v50 = spiral_wrap_signed(v46 - 1, 32)
                                                                    let v51 = spiral_wrap_signed(v50 + 1, 32)
                                                                    let v52 = kino_text_at(v4, 0, v51)
                                                                    let v53 = v52 == "prototype "
                                                                    v53
                                                                }
                                                            }
                                                        }
                                                    }
                                                case v55 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v56 = "instance "
                                                        let v57 = kino_text_size(v56)
                                                        let v58 = kino_text_size(v4)
                                                        let v59 = v57 > v58
                                                        let v66 =
                                                            case v59 {
                                                                True -> {
                                                                    False
                                                                }
                                                                False -> {
                                                                    let v60 = v57 == 0
                                                                    case v60 {
                                                                        True -> {
                                                                            True
                                                                        }
                                                                        False -> {
                                                                            let v61 = spiral_wrap_signed(v57 - 1, 32)
                                                                            let v62 = spiral_wrap_signed(v61 + 1, 32)
                                                                            let v63 = kino_text_at(v4, 0, v62)
                                                                            let v64 = v63 == "instance "
                                                                            v64
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        case v66 {
                                                            True -> {
                                                                True
                                                            }
                                                            False -> {
                                                                let v67 = "type "
                                                                let v68 = kino_text_size(v67)
                                                                let v69 = kino_text_size(v4)
                                                                let v70 = v68 > v69
                                                                let v77 =
                                                                    case v70 {
                                                                        True -> {
                                                                            False
                                                                        }
                                                                        False -> {
                                                                            let v71 = v68 == 0
                                                                            case v71 {
                                                                                True -> {
                                                                                    True
                                                                                }
                                                                                False -> {
                                                                                    let v72 = spiral_wrap_signed(v68 - 1, 32)
                                                                                    let v73 = spiral_wrap_signed(v72 + 1, 32)
                                                                                    let v74 = kino_text_at(v4, 0, v73)
                                                                                    let v75 = v74 == "type "
                                                                                    v75
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                case v77 {
                                                                    True -> {
                                                                        True
                                                                    }
                                                                    False -> {
                                                                        let v78 = "union "
                                                                        let v79 = kino_text_size(v78)
                                                                        let v80 = kino_text_size(v4)
                                                                        let v81 = v79 > v80
                                                                        let v88 =
                                                                            case v81 {
                                                                                True -> {
                                                                                    False
                                                                                }
                                                                                False -> {
                                                                                    let v82 = v79 == 0
                                                                                    case v82 {
                                                                                        True -> {
                                                                                            True
                                                                                        }
                                                                                        False -> {
                                                                                            let v83 = spiral_wrap_signed(v79 - 1, 32)
                                                                                            let v84 = spiral_wrap_signed(v83 + 1, 32)
                                                                                            let v85 = kino_text_at(v4, 0, v84)
                                                                                            let v86 = v85 == "union "
                                                                                            v86
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        case v88 {
                                                                            True -> {
                                                                                True
                                                                            }
                                                                            False -> {
                                                                                let v89 = "nominal "
                                                                                let v90 = kino_text_size(v89)
                                                                                let v91 = kino_text_size(v4)
                                                                                let v92 = v90 > v91
                                                                                case v92 {
                                                                                    True -> {
                                                                                        False
                                                                                    }
                                                                                    False -> {
                                                                                        let v93 = v90 == 0
                                                                                        case v93 {
                                                                                            True -> {
                                                                                                True
                                                                                            }
                                                                                            False -> {
                                                                                                let v94 = spiral_wrap_signed(v90 - 1, 32)
                                                                                                let v95 = spiral_wrap_signed(v94 + 1, 32)
                                                                                                let v96 = kino_text_at(v4, 0, v95)
                                                                                                let v97 = v96 == "nominal "
                                                                                                v97
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
                                    case v104 {
                                        True -> {
                                            v2
                                        }
                                        False -> {
                                            let v105 = "inl "
                                            let v106 = kino_text_size(v105)
                                            let v107 = kino_text_size(v4)
                                            let v108 = v106 > v107
                                            let v115 =
                                                case v108 {
                                                    True -> {
                                                        False
                                                    }
                                                    False -> {
                                                        let v109 = v106 == 0
                                                        case v109 {
                                                            True -> {
                                                                True
                                                            }
                                                            False -> {
                                                                let v110 = spiral_wrap_signed(v106 - 1, 32)
                                                                let v111 = spiral_wrap_signed(v110 + 1, 32)
                                                                let v112 = kino_text_at(v4, 0, v111)
                                                                let v113 = v112 == "inl "
                                                                v113
                                                            }
                                                        }
                                                    }
                                                }
                                            let v139 =
                                                case v115 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v116 = "and "
                                                        let v117 = kino_text_size(v116)
                                                        let v118 = kino_text_size(v4)
                                                        let v119 = v117 > v118
                                                        let v126 =
                                                            case v119 {
                                                                True -> {
                                                                    False
                                                                }
                                                                False -> {
                                                                    let v120 = v117 == 0
                                                                    case v120 {
                                                                        True -> {
                                                                            True
                                                                        }
                                                                        False -> {
                                                                            let v121 = spiral_wrap_signed(v117 - 1, 32)
                                                                            let v122 = spiral_wrap_signed(v121 + 1, 32)
                                                                            let v123 = kino_text_at(v4, 0, v122)
                                                                            let v124 = v123 == "and "
                                                                            v124
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        case v126 {
                                                            True -> {
                                                                True
                                                            }
                                                            False -> {
                                                                let v127 = "let "
                                                                let v128 = kino_text_size(v127)
                                                                let v129 = kino_text_size(v4)
                                                                let v130 = v128 > v129
                                                                case v130 {
                                                                    True -> {
                                                                        False
                                                                    }
                                                                    False -> {
                                                                        let v131 = v128 == 0
                                                                        case v131 {
                                                                            True -> {
                                                                                True
                                                                            }
                                                                            False -> {
                                                                                let v132 = spiral_wrap_signed(v128 - 1, 32)
                                                                                let v133 = spiral_wrap_signed(v132 + 1, 32)
                                                                                let v134 = kino_text_at(v4, 0, v133)
                                                                                let v135 = v134 == "let "
                                                                                v135
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            case v139 {
                                                True -> {
                                                    let v140 = "and "
                                                    let v141 = kino_text_size(v140)
                                                    let v142 = kino_text_size(v4)
                                                    let v143 = v141 > v142
                                                    let v150 =
                                                        case v143 {
                                                            True -> {
                                                                False
                                                            }
                                                            False -> {
                                                                let v144 = v141 == 0
                                                                case v144 {
                                                                    True -> {
                                                                        True
                                                                    }
                                                                    False -> {
                                                                        let v145 = spiral_wrap_signed(v141 - 1, 32)
                                                                        let v146 = spiral_wrap_signed(v145 + 1, 32)
                                                                        let v147 = kino_text_at(v4, 0, v146)
                                                                        let v148 = v147 == "and "
                                                                        v148
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    let v153 =
                                                        case v150 {
                                                            True -> {
                                                                let v151 = 3
                                                                skip_spaces_10(v4, v151)
                                                            }
                                                            False -> {
                                                                0
                                                            }
                                                        }
                                                    let v154 = "inl"
                                                    let v155 = kino_text_size(v154)
                                                    let v156 = v153 < 0
                                                    let v168 =
                                                        case v156 {
                                                            True -> {
                                                                False
                                                            }
                                                            False -> {
                                                                let v157 = spiral_wrap_signed(v153 + v155, 32)
                                                                let v158 = kino_text_size(v4)
                                                                let v159 = v157 > v158
                                                                case v159 {
                                                                    True -> {
                                                                        False
                                                                    }
                                                                    False -> {
                                                                        let v160 = v155 == 0
                                                                        case v160 {
                                                                            True -> {
                                                                                True
                                                                            }
                                                                            False -> {
                                                                                let v161 = spiral_wrap_signed(v157 - 1, 32)
                                                                                let v162 = spiral_wrap_signed(v161 - v153, 32)
                                                                                let v163 = spiral_wrap_signed(v162 + 1, 32)
                                                                                let v164 = kino_text_at(v4, v153, v163)
                                                                                let v165 = v164 == "inl"
                                                                                v165
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    let v183 =
                                                        case v168 {
                                                            True -> {
                                                                True
                                                            }
                                                            False -> {
                                                                let v169 = "let"
                                                                let v170 = kino_text_size(v169)
                                                                case v156 {
                                                                    True -> {
                                                                        False
                                                                    }
                                                                    False -> {
                                                                        let v171 = spiral_wrap_signed(v153 + v170, 32)
                                                                        let v172 = kino_text_size(v4)
                                                                        let v173 = v171 > v172
                                                                        case v173 {
                                                                            True -> {
                                                                                False
                                                                            }
                                                                            False -> {
                                                                                let v174 = v170 == 0
                                                                                case v174 {
                                                                                    True -> {
                                                                                        True
                                                                                    }
                                                                                    False -> {
                                                                                        let v175 = spiral_wrap_signed(v171 - 1, 32)
                                                                                        let v176 = spiral_wrap_signed(v175 - v153, 32)
                                                                                        let v177 = spiral_wrap_signed(v176 + 1, 32)
                                                                                        let v178 = kino_text_at(v4, v153, v177)
                                                                                        let v179 = v178 == "let"
                                                                                        v179
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    let v192 =
                                                        case v183 {
                                                            True -> {
                                                                let v184 = spiral_wrap_signed(v153 + 3, 32)
                                                                let v185 = kino_text_size(v4)
                                                                let v186 = v184 < v185
                                                                let v189 =
                                                                    case v186 {
                                                                        True -> {
                                                                            let v187 = kino_text_at(v4, v184, 1)
                                                                            let v188 = v187 == " "
                                                                            v188
                                                                        }
                                                                        False -> {
                                                                            False
                                                                        }
                                                                    }
                                                                case v189 {
                                                                    True -> {
                                                                        skip_spaces_10(v4, v184)
                                                                    }
                                                                    False -> {
                                                                        -1
                                                                    }
                                                                }
                                                            }
                                                            False -> {
                                                                -1
                                                            }
                                                        }
                                                    let v193 = v192 < 0
                                                    let v381 =
                                                        case v193 {
                                                            True -> {
                                                                False
                                                            }
                                                            False -> {
                                                                let v194 = take_name_11(v4, v192)
                                                                let v195 = v194 == v192
                                                                case v195 {
                                                                    True -> {
                                                                        False
                                                                    }
                                                                    False -> {
                                                                        let v196 = skip_spaces_10(v4, v194)
                                                                        let v197 = v196 > v194
                                                                        let v200 =
                                                                            case v197 {
                                                                                True -> {
                                                                                    let v198 = kino_text_size(v4)
                                                                                    let v199 = v196 < v198
                                                                                    v199
                                                                                }
                                                                                False -> {
                                                                                    False
                                                                                }
                                                                            }
                                                                        let v226 =
                                                                            case v200 {
                                                                                True -> {
                                                                                    let v201 = kino_text_at(v4, v196, 1)
                                                                                    let v202 = v201 == ":"
                                                                                    let v204 =
                                                                                        case v202 {
                                                                                            True -> {
                                                                                                True
                                                                                            }
                                                                                            False -> {
                                                                                                let v203 = v201 == "="
                                                                                                v203
                                                                                            }
                                                                                        }
                                                                                    case v204 {
                                                                                        True -> {
                                                                                            let v205 = spiral_wrap_signed(v196 + 1, 32)
                                                                                            let v206 = skip_spaces_10(v4, v205)
                                                                                            let v207 = v206 > v205
                                                                                            let v223 =
                                                                                                case v207 {
                                                                                                    True -> {
                                                                                                        let v208 = "function"
                                                                                                        let v209 = kino_text_size(v208)
                                                                                                        let v210 = v206 < 0
                                                                                                        case v210 {
                                                                                                            True -> {
                                                                                                                False
                                                                                                            }
                                                                                                            False -> {
                                                                                                                let v211 = spiral_wrap_signed(v206 + v209, 32)
                                                                                                                let v212 = kino_text_size(v4)
                                                                                                                let v213 = v211 > v212
                                                                                                                case v213 {
                                                                                                                    True -> {
                                                                                                                        False
                                                                                                                    }
                                                                                                                    False -> {
                                                                                                                        let v214 = v209 == 0
                                                                                                                        case v214 {
                                                                                                                            True -> {
                                                                                                                                True
                                                                                                                            }
                                                                                                                            False -> {
                                                                                                                                let v215 = spiral_wrap_signed(v211 - 1, 32)
                                                                                                                                let v216 = spiral_wrap_signed(v215 - v206, 32)
                                                                                                                                let v217 = spiral_wrap_signed(v216 + 1, 32)
                                                                                                                                let v218 = kino_text_at(v4, v206, v217)
                                                                                                                                let v219 = v218 == "function"
                                                                                                                                v219
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                    False -> {
                                                                                                        False
                                                                                                    }
                                                                                                }
                                                                                            let v224 = v223 == False
                                                                                            v224
                                                                                        }
                                                                                        False -> {
                                                                                            False
                                                                                        }
                                                                                    }
                                                                                }
                                                                                False -> {
                                                                                    False
                                                                                }
                                                                            }
                                                                        case v226 {
                                                                            True -> {
                                                                                True
                                                                            }
                                                                            False -> {
                                                                                let v227 = kino_text_size(v4)
                                                                                let v228 = v194 >= v227
                                                                                let v234 =
                                                                                    case v228 {
                                                                                        True -> {
                                                                                            True
                                                                                        }
                                                                                        False -> {
                                                                                            let v229 = kino_text_at(v4, v194, 1)
                                                                                            let v230 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_'"
                                                                                            let v231 = 0
                                                                                            let v232 = has_char_12(v230, v231, v229)
                                                                                            let v233 = v232 == False
                                                                                            v233
                                                                                        }
                                                                                    }
                                                                                let v256 =
                                                                                    case v234 {
                                                                                        True -> {
                                                                                            -1
                                                                                        }
                                                                                        False -> {
                                                                                            let v235 = spiral_wrap_signed(v194 + 1, 32)
                                                                                            let v236 = take_ident_13(v4, v235)
                                                                                            let v237 = take_spaces_or_brace_14(v4, v236)
                                                                                            let v238 = kino_text_size(v4)
                                                                                            let v239 = v237 < v238
                                                                                            let v242 =
                                                                                                case v239 {
                                                                                                    True -> {
                                                                                                        let v240 = kino_text_at(v4, v237, 1)
                                                                                                        let v241 = v240 == "&"
                                                                                                        v241
                                                                                                    }
                                                                                                    False -> {
                                                                                                        False
                                                                                                    }
                                                                                                }
                                                                                            case v242 {
                                                                                                True -> {
                                                                                                    let v243 = spiral_wrap_signed(v237 + 1, 32)
                                                                                                    let v244 = skip_spaces_10(v4, v243)
                                                                                                    let v245 = kino_text_size(v4)
                                                                                                    let v246 = v244 < v245
                                                                                                    let v251 =
                                                                                                        case v246 {
                                                                                                            True -> {
                                                                                                                let v247 = kino_text_at(v4, v244, 1)
                                                                                                                let v248 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_'"
                                                                                                                let v249 = 0
                                                                                                                has_char_12(v248, v249, v247)
                                                                                                            }
                                                                                                            False -> {
                                                                                                                False
                                                                                                            }
                                                                                                        }
                                                                                                    case v251 {
                                                                                                        True -> {
                                                                                                            let v252 = spiral_wrap_signed(v244 + 1, 32)
                                                                                                            take_ident_13(v4, v252)
                                                                                                        }
                                                                                                        False -> {
                                                                                                            v237
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                False -> {
                                                                                                    v237
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                let v257 = v256 >= 0
                                                                                let v289 =
                                                                                    case v257 {
                                                                                        True -> {
                                                                                            let v258 = skip_spaces_10(v4, v256)
                                                                                            let v259 = v258 > v256
                                                                                            let v262 =
                                                                                                case v259 {
                                                                                                    True -> {
                                                                                                        let v260 = kino_text_size(v4)
                                                                                                        let v261 = v258 < v260
                                                                                                        v261
                                                                                                    }
                                                                                                    False -> {
                                                                                                        False
                                                                                                    }
                                                                                                }
                                                                                            case v262 {
                                                                                                True -> {
                                                                                                    let v263 = kino_text_at(v4, v258, 1)
                                                                                                    let v264 = v263 == ":"
                                                                                                    let v266 =
                                                                                                        case v264 {
                                                                                                            True -> {
                                                                                                                True
                                                                                                            }
                                                                                                            False -> {
                                                                                                                let v265 = v263 == "="
                                                                                                                v265
                                                                                                            }
                                                                                                        }
                                                                                                    case v266 {
                                                                                                        True -> {
                                                                                                            let v267 = spiral_wrap_signed(v258 + 1, 32)
                                                                                                            let v268 = skip_spaces_10(v4, v267)
                                                                                                            let v269 = v268 > v267
                                                                                                            let v285 =
                                                                                                                case v269 {
                                                                                                                    True -> {
                                                                                                                        let v270 = "function"
                                                                                                                        let v271 = kino_text_size(v270)
                                                                                                                        let v272 = v268 < 0
                                                                                                                        case v272 {
                                                                                                                            True -> {
                                                                                                                                False
                                                                                                                            }
                                                                                                                            False -> {
                                                                                                                                let v273 = spiral_wrap_signed(v268 + v271, 32)
                                                                                                                                let v274 = kino_text_size(v4)
                                                                                                                                let v275 = v273 > v274
                                                                                                                                case v275 {
                                                                                                                                    True -> {
                                                                                                                                        False
                                                                                                                                    }
                                                                                                                                    False -> {
                                                                                                                                        let v276 = v271 == 0
                                                                                                                                        case v276 {
                                                                                                                                            True -> {
                                                                                                                                                True
                                                                                                                                            }
                                                                                                                                            False -> {
                                                                                                                                                let v277 = spiral_wrap_signed(v273 - 1, 32)
                                                                                                                                                let v278 = spiral_wrap_signed(v277 - v268, 32)
                                                                                                                                                let v279 = spiral_wrap_signed(v278 + 1, 32)
                                                                                                                                                let v280 = kino_text_at(v4, v268, v279)
                                                                                                                                                let v281 = v280 == "function"
                                                                                                                                                v281
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                    False -> {
                                                                                                                        False
                                                                                                                    }
                                                                                                                }
                                                                                                            let v286 = v285 == False
                                                                                                            v286
                                                                                                        }
                                                                                                        False -> {
                                                                                                            False
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                False -> {
                                                                                                    False
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        False -> {
                                                                                            False
                                                                                        }
                                                                                    }
                                                                                case v289 {
                                                                                    True -> {
                                                                                        True
                                                                                    }
                                                                                    False -> {
                                                                                        let v290 = skip_spaces_10(v4, v194)
                                                                                        let v291 = take_tilde_word_15(v4, v290)
                                                                                        let v292 = v291 >= 0
                                                                                        let v295 =
                                                                                            case v292 {
                                                                                                True -> {
                                                                                                    let v293 = kino_text_size(v4)
                                                                                                    let v294 = v291 < v293
                                                                                                    v294
                                                                                                }
                                                                                                False -> {
                                                                                                    False
                                                                                                }
                                                                                            }
                                                                                        let v298 =
                                                                                            case v295 {
                                                                                                True -> {
                                                                                                    let v296 = kino_text_at(v4, v291, 1)
                                                                                                    let v297 = v296 == ")"
                                                                                                    v297
                                                                                                }
                                                                                                False -> {
                                                                                                    False
                                                                                                }
                                                                                            }
                                                                                        let v300 =
                                                                                            case v298 {
                                                                                                True -> {
                                                                                                    let v299 = spiral_wrap_signed(v291 + 1, 32)
                                                                                                    v299
                                                                                                }
                                                                                                False -> {
                                                                                                    -1
                                                                                                }
                                                                                            }
                                                                                        let v301 = v300 >= 0
                                                                                        let v333 =
                                                                                            case v301 {
                                                                                                True -> {
                                                                                                    let v302 = skip_spaces_10(v4, v300)
                                                                                                    let v303 = v302 > v300
                                                                                                    let v306 =
                                                                                                        case v303 {
                                                                                                            True -> {
                                                                                                                let v304 = kino_text_size(v4)
                                                                                                                let v305 = v302 < v304
                                                                                                                v305
                                                                                                            }
                                                                                                            False -> {
                                                                                                                False
                                                                                                            }
                                                                                                        }
                                                                                                    case v306 {
                                                                                                        True -> {
                                                                                                            let v307 = kino_text_at(v4, v302, 1)
                                                                                                            let v308 = v307 == ":"
                                                                                                            let v310 =
                                                                                                                case v308 {
                                                                                                                    True -> {
                                                                                                                        True
                                                                                                                    }
                                                                                                                    False -> {
                                                                                                                        let v309 = v307 == "="
                                                                                                                        v309
                                                                                                                    }
                                                                                                                }
                                                                                                            case v310 {
                                                                                                                True -> {
                                                                                                                    let v311 = spiral_wrap_signed(v302 + 1, 32)
                                                                                                                    let v312 = skip_spaces_10(v4, v311)
                                                                                                                    let v313 = v312 > v311
                                                                                                                    let v329 =
                                                                                                                        case v313 {
                                                                                                                            True -> {
                                                                                                                                let v314 = "function"
                                                                                                                                let v315 = kino_text_size(v314)
                                                                                                                                let v316 = v312 < 0
                                                                                                                                case v316 {
                                                                                                                                    True -> {
                                                                                                                                        False
                                                                                                                                    }
                                                                                                                                    False -> {
                                                                                                                                        let v317 = spiral_wrap_signed(v312 + v315, 32)
                                                                                                                                        let v318 = kino_text_size(v4)
                                                                                                                                        let v319 = v317 > v318
                                                                                                                                        case v319 {
                                                                                                                                            True -> {
                                                                                                                                                False
                                                                                                                                            }
                                                                                                                                            False -> {
                                                                                                                                                let v320 = v315 == 0
                                                                                                                                                case v320 {
                                                                                                                                                    True -> {
                                                                                                                                                        True
                                                                                                                                                    }
                                                                                                                                                    False -> {
                                                                                                                                                        let v321 = spiral_wrap_signed(v317 - 1, 32)
                                                                                                                                                        let v322 = spiral_wrap_signed(v321 - v312, 32)
                                                                                                                                                        let v323 = spiral_wrap_signed(v322 + 1, 32)
                                                                                                                                                        let v324 = kino_text_at(v4, v312, v323)
                                                                                                                                                        let v325 = v324 == "function"
                                                                                                                                                        v325
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                            False -> {
                                                                                                                                False
                                                                                                                            }
                                                                                                                        }
                                                                                                                    let v330 = v329 == False
                                                                                                                    v330
                                                                                                                }
                                                                                                                False -> {
                                                                                                                    False
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                        False -> {
                                                                                                            False
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                False -> {
                                                                                                    False
                                                                                                }
                                                                                            }
                                                                                        case v333 {
                                                                                            True -> {
                                                                                                True
                                                                                            }
                                                                                            False -> {
                                                                                                let v334 = kino_text_size(v4)
                                                                                                let v335 = v194 >= v334
                                                                                                let v339 =
                                                                                                    case v335 {
                                                                                                        True -> {
                                                                                                            True
                                                                                                        }
                                                                                                        False -> {
                                                                                                            let v336 = kino_text_at(v4, v194, 1)
                                                                                                            let v337 = v336 == ","
                                                                                                            let v338 = v337 != True
                                                                                                            v338
                                                                                                        }
                                                                                                    }
                                                                                                let v343 =
                                                                                                    case v339 {
                                                                                                        True -> {
                                                                                                            -1
                                                                                                        }
                                                                                                        False -> {
                                                                                                            let v340 = spiral_wrap_signed(v194 + 1, 32)
                                                                                                            let v341 = skip_spaces_10(v4, v340)
                                                                                                            take_tilde_word_15(v4, v341)
                                                                                                        }
                                                                                                    }
                                                                                                let v344 = v343 >= 0
                                                                                                case v344 {
                                                                                                    True -> {
                                                                                                        let v345 = skip_spaces_10(v4, v343)
                                                                                                        let v346 = v345 > v343
                                                                                                        let v349 =
                                                                                                            case v346 {
                                                                                                                True -> {
                                                                                                                    let v347 = kino_text_size(v4)
                                                                                                                    let v348 = v345 < v347
                                                                                                                    v348
                                                                                                                }
                                                                                                                False -> {
                                                                                                                    False
                                                                                                                }
                                                                                                            }
                                                                                                        case v349 {
                                                                                                            True -> {
                                                                                                                let v350 = kino_text_at(v4, v345, 1)
                                                                                                                let v351 = v350 == ":"
                                                                                                                let v353 =
                                                                                                                    case v351 {
                                                                                                                        True -> {
                                                                                                                            True
                                                                                                                        }
                                                                                                                        False -> {
                                                                                                                            let v352 = v350 == "="
                                                                                                                            v352
                                                                                                                        }
                                                                                                                    }
                                                                                                                case v353 {
                                                                                                                    True -> {
                                                                                                                        let v354 = spiral_wrap_signed(v345 + 1, 32)
                                                                                                                        let v355 = skip_spaces_10(v4, v354)
                                                                                                                        let v356 = v355 > v354
                                                                                                                        let v372 =
                                                                                                                            case v356 {
                                                                                                                                True -> {
                                                                                                                                    let v357 = "function"
                                                                                                                                    let v358 = kino_text_size(v357)
                                                                                                                                    let v359 = v355 < 0
                                                                                                                                    case v359 {
                                                                                                                                        True -> {
                                                                                                                                            False
                                                                                                                                        }
                                                                                                                                        False -> {
                                                                                                                                            let v360 = spiral_wrap_signed(v355 + v358, 32)
                                                                                                                                            let v361 = kino_text_size(v4)
                                                                                                                                            let v362 = v360 > v361
                                                                                                                                            case v362 {
                                                                                                                                                True -> {
                                                                                                                                                    False
                                                                                                                                                }
                                                                                                                                                False -> {
                                                                                                                                                    let v363 = v358 == 0
                                                                                                                                                    case v363 {
                                                                                                                                                        True -> {
                                                                                                                                                            True
                                                                                                                                                        }
                                                                                                                                                        False -> {
                                                                                                                                                            let v364 = spiral_wrap_signed(v360 - 1, 32)
                                                                                                                                                            let v365 = spiral_wrap_signed(v364 - v355, 32)
                                                                                                                                                            let v366 = spiral_wrap_signed(v365 + 1, 32)
                                                                                                                                                            let v367 = kino_text_at(v4, v355, v366)
                                                                                                                                                            let v368 = v367 == "function"
                                                                                                                                                            v368
                                                                                                                                                        }
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                                False -> {
                                                                                                                                    False
                                                                                                                                }
                                                                                                                            }
                                                                                                                        let v373 = v372 == False
                                                                                                                        v373
                                                                                                                    }
                                                                                                                    False -> {
                                                                                                                        False
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                            False -> {
                                                                                                                False
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
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    case v381 {
                                                        True -> {
                                                            let v382 = spiral_wrap_signed(v1 - 1, 32)
                                                            search_top_9(v0, v382, v1)
                                                        }
                                                        False -> {
                                                            v2
                                                        }
                                                    }
                                                }
                                                False -> {
                                                    let v385 = spiral_wrap_signed(v1 - 1, 32)
                                                    search_top_9(v0, v385, v1)
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
pub fn trim_start_17(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = v4 == " "
            let v11 =
                case v5 {
                    True -> {
                        True
                    }
                    False -> {
                        let v6 = v4 == "\t"
                        case v6 {
                            True -> {
                                True
                            }
                            False -> {
                                let v7 = v4 == "\n"
                                case v7 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v8 = v4 == "\r"
                                        v8
                                    }
                                }
                            }
                        }
                    }
                }
            case v11 {
                True -> {
                    let v12 = spiral_wrap_signed(v1 + 1, 32)
                    trim_start_17(v0, v12)
                }
                False -> {
                    v1
                }
            }
        }
    }
}
pub fn trim_end_18(v0: String, v1: Int) -> Int {
    let v2 = v1 <= 0
    case v2 {
        True -> {
            0
        }
        False -> {
            let v3 = spiral_wrap_signed(v1 - 1, 32)
            let v4 = kino_text_at(v0, v3, 1)
            let v5 = v4 == " "
            let v11 =
                case v5 {
                    True -> {
                        True
                    }
                    False -> {
                        let v6 = v4 == "\t"
                        case v6 {
                            True -> {
                                True
                            }
                            False -> {
                                let v7 = v4 == "\n"
                                case v7 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v8 = v4 == "\r"
                                        v8
                                    }
                                }
                            }
                        }
                    }
                }
            case v11 {
                True -> {
                    trim_end_18(v0, v3)
                }
                False -> {
                    v1
                }
            }
        }
    }
}
pub fn map_main_16(v0: Uh0, v1: Int, v2: Int) -> Uh0 {
    case v0  {
        Uh0Line(v4, v5) -> {
            let v6 = v1 < v2
            let v39 =
                case v6 {
                    True -> {
                        v4
                    }
                    False -> {
                        let v7 = v1 == v2
                        case v7 {
                            True -> {
                                let v8 = 0
                                let v9 = trim_start_17(v4, v8)
                                let v10 = kino_text_size(v4)
                                let v11 = trim_end_18(v4, v10)
                                let v12 = v11 <= v9
                                let v18 =
                                    case v12 {
                                        True -> {
                                            let v13 = ""
                                            v13
                                        }
                                        False -> {
                                            let v14 = spiral_wrap_signed(v11 - 1, 32)
                                            let v15 = spiral_wrap_signed(v14 - v9, 32)
                                            let v16 = spiral_wrap_signed(v15 + 1, 32)
                                            let v17 = kino_text_at(v4, v9, v16)
                                            v17
                                        }
                                    }
                                let v19 = v18 == "()"
                                let v21 =
                                    case v19 {
                                        True -> {
                                            let v20 = "0i32"
                                            v20
                                        }
                                        False -> {
                                            v4
                                        }
                                    }
                                let v22 = { "inl main () : i32 =\n    " } <> { v21 }
                                v22
                            }
                            False -> {
                                let v23 = 0
                                let v24 = trim_start_17(v4, v23)
                                let v25 = kino_text_size(v4)
                                let v26 = trim_end_18(v4, v25)
                                let v27 = v26 <= v24
                                let v33 =
                                    case v27 {
                                        True -> {
                                            let v28 = ""
                                            v28
                                        }
                                        False -> {
                                            let v29 = spiral_wrap_signed(v26 - 1, 32)
                                            let v30 = spiral_wrap_signed(v29 - v24, 32)
                                            let v31 = spiral_wrap_signed(v30 + 1, 32)
                                            let v32 = kino_text_at(v4, v24, v31)
                                            v32
                                        }
                                    }
                                let v34 = v33 == ""
                                case v34 {
                                    True -> {
                                        let v35 = ""
                                        v35
                                    }
                                    False -> {
                                        let v36 = { "    " } <> { v4 }
                                        v36
                                    }
                                }
                            }
                        }
                    }
                }
            let v40 = spiral_wrap_signed(v1 + 1, 32)
            let v41 = map_main_16(v5, v40, v2)
            Uh0Line(v39, v41)
        }
        Uh0NoLine -> {
            Uh0NoLine
        }
    }
}
pub fn join_from_19(v0: Uh0, v1: String) -> String {
    case v0  {
        Uh0Line(v2, v3) -> {
            let v4 = { v1 } <> { "\n" }
            let v5 = { v4 } <> { v2 }
            join_from_19(v3, v5)
        }
        Uh0NoLine -> {
            v1
        }
    }
}
pub fn show_i32_20(v0: Int) -> String {
    let v1 = v0 < 0
    case v1 {
        True -> {
            let v2 = spiral_wrap_signed(0 - v0, 32)
            let v3 = show_i32_20(v2)
            let v4 = { "-" } <> { v3 }
            v4
        }
        False -> {
            let v5 = v0 < 10
            case v5 {
                True -> {
                    let v6 = v0 == 0
                    case v6 {
                        True -> {
                            let v7 = "0"
                            v7
                        }
                        False -> {
                            let v8 = v0 == 1
                            case v8 {
                                True -> {
                                    let v9 = "1"
                                    v9
                                }
                                False -> {
                                    let v10 = v0 == 2
                                    case v10 {
                                        True -> {
                                            let v11 = "2"
                                            v11
                                        }
                                        False -> {
                                            let v12 = v0 == 3
                                            case v12 {
                                                True -> {
                                                    let v13 = "3"
                                                    v13
                                                }
                                                False -> {
                                                    let v14 = v0 == 4
                                                    case v14 {
                                                        True -> {
                                                            let v15 = "4"
                                                            v15
                                                        }
                                                        False -> {
                                                            let v16 = v0 == 5
                                                            case v16 {
                                                                True -> {
                                                                    let v17 = "5"
                                                                    v17
                                                                }
                                                                False -> {
                                                                    let v18 = v0 == 6
                                                                    case v18 {
                                                                        True -> {
                                                                            let v19 = "6"
                                                                            v19
                                                                        }
                                                                        False -> {
                                                                            let v20 = v0 == 7
                                                                            case v20 {
                                                                                True -> {
                                                                                    let v21 = "7"
                                                                                    v21
                                                                                }
                                                                                False -> {
                                                                                    let v22 = v0 == 8
                                                                                    case v22 {
                                                                                        True -> {
                                                                                            let v23 = "8"
                                                                                            v23
                                                                                        }
                                                                                        False -> {
                                                                                            let v24 = v0 == 9
                                                                                            case v24 {
                                                                                                True -> {
                                                                                                    let v25 = "9"
                                                                                                    v25
                                                                                                }
                                                                                                False -> {
                                                                                                    let v26 = "0"
                                                                                                    v26
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
                False -> {
                    let v37 = v0 / 10
                    let v38 = show_i32_20(v37)
                    let v39 = v0 % 10
                    let v40 = v39 == 0
                    let v70 =
                        case v40 {
                            True -> {
                                let v41 = "0"
                                v41
                            }
                            False -> {
                                let v42 = v39 == 1
                                case v42 {
                                    True -> {
                                        let v43 = "1"
                                        v43
                                    }
                                    False -> {
                                        let v44 = v39 == 2
                                        case v44 {
                                            True -> {
                                                let v45 = "2"
                                                v45
                                            }
                                            False -> {
                                                let v46 = v39 == 3
                                                case v46 {
                                                    True -> {
                                                        let v47 = "3"
                                                        v47
                                                    }
                                                    False -> {
                                                        let v48 = v39 == 4
                                                        case v48 {
                                                            True -> {
                                                                let v49 = "4"
                                                                v49
                                                            }
                                                            False -> {
                                                                let v50 = v39 == 5
                                                                case v50 {
                                                                    True -> {
                                                                        let v51 = "5"
                                                                        v51
                                                                    }
                                                                    False -> {
                                                                        let v52 = v39 == 6
                                                                        case v52 {
                                                                            True -> {
                                                                                let v53 = "6"
                                                                                v53
                                                                            }
                                                                            False -> {
                                                                                let v54 = v39 == 7
                                                                                case v54 {
                                                                                    True -> {
                                                                                        let v55 = "7"
                                                                                        v55
                                                                                    }
                                                                                    False -> {
                                                                                        let v56 = v39 == 8
                                                                                        case v56 {
                                                                                            True -> {
                                                                                                let v57 = "8"
                                                                                                v57
                                                                                            }
                                                                                            False -> {
                                                                                                let v58 = v39 == 9
                                                                                                case v58 {
                                                                                                    True -> {
                                                                                                        let v59 = "9"
                                                                                                        v59
                                                                                                    }
                                                                                                    False -> {
                                                                                                        let v60 = "0"
                                                                                                        v60
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
                    let v71 = { v38 } <> { v70 }
                    v71
                }
            }
        }
    }
}
pub fn skip_ws_22(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = v4 == " "
            case v5 {
                True -> {
                    let v6 = spiral_wrap_signed(v1 + 1, 32)
                    skip_ws_22(v0, v6)
                }
                False -> {
                    let v8 = v4 == "\t"
                    case v8 {
                        True -> {
                            let v9 = spiral_wrap_signed(v1 + 1, 32)
                            skip_ws_22(v0, v9)
                        }
                        False -> {
                            v1
                        }
                    }
                }
            }
        }
    }
}
pub fn rev_tokens_23(v0: Uh1, v1: Uh1) -> Uh1 {
    case v0  {
        Uh1NoToken -> {
            v1
        }
        Uh1Token(v2, v3) -> {
            let v4 = Uh1Token(v2, v1)
            rev_tokens_23(v3, v4)
        }
    }
}
pub fn take_token_24(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = v4 == " "
            case v5 {
                True -> {
                    v1
                }
                False -> {
                    let v6 = v4 == "\t"
                    case v6 {
                        True -> {
                            v1
                        }
                        False -> {
                            let v7 = spiral_wrap_signed(v1 + 1, 32)
                            take_token_24(v0, v7)
                        }
                    }
                }
            }
        }
    }
}
pub fn tokens_from_21(v0: String, v1: Int, v2: Uh1) -> Uh1 {
    let v3 = skip_ws_22(v0, v1)
    let v4 = kino_text_size(v0)
    let v5 = v3 >= v4
    case v5 {
        True -> {
            let v6 = Uh1NoToken
            rev_tokens_23(v2, v6)
        }
        False -> {
            let v8 = take_token_24(v0, v3)
            let v9 = spiral_wrap_signed(v8 - v3, 32)
            let v10 = v9 <= 0
            let v29 =
                case v10 {
                    True -> {
                        let v11 = ""
                        v11
                    }
                    False -> {
                        let v12 = kino_text_size(v0)
                        let v13 = v3 >= v12
                        case v13 {
                            True -> {
                                let v14 = ""
                                v14
                            }
                            False -> {
                                let v15 = spiral_wrap_signed(v3 + v9, 32)
                                let v16 = spiral_wrap_signed(v15 - 1, 32)
                                let v17 = kino_text_size(v0)
                                let v18 = v16 >= v17
                                let v21 =
                                    case v18 {
                                        True -> {
                                            let v19 = kino_text_size(v0)
                                            let v20 = spiral_wrap_signed(v19 - 1, 32)
                                            v20
                                        }
                                        False -> {
                                            v16
                                        }
                                    }
                                let v22 = v21 < v3
                                case v22 {
                                    True -> {
                                        let v23 = ""
                                        v23
                                    }
                                    False -> {
                                        let v24 = spiral_wrap_signed(v21 - v3, 32)
                                        let v25 = spiral_wrap_signed(v24 + 1, 32)
                                        let v26 = kino_text_at(v0, v3, v25)
                                        v26
                                    }
                                }
                            }
                        }
                    }
                }
            let v30 = Uh1Token(v29, v2)
            tokens_from_21(v0, v8, v30)
        }
    }
}
pub fn parse_acc_26(v0: String, v1: Int, v2: Int, v3: Int) -> Int {
    let v4 = kino_text_size(v0)
    let v5 = v1 >= v4
    case v5 {
        True -> {
            let v6 = v3 == 1
            case v6 {
                True -> {
                    v2
                }
                False -> {
                    -1
                }
            }
        }
        False -> {
            let v8 = kino_text_at(v0, v1, 1)
            let v9 = v8 == "0"
            let v28 =
                case v9 {
                    True -> {
                        0
                    }
                    False -> {
                        let v10 = v8 == "1"
                        case v10 {
                            True -> {
                                1
                            }
                            False -> {
                                let v11 = v8 == "2"
                                case v11 {
                                    True -> {
                                        2
                                    }
                                    False -> {
                                        let v12 = v8 == "3"
                                        case v12 {
                                            True -> {
                                                3
                                            }
                                            False -> {
                                                let v13 = v8 == "4"
                                                case v13 {
                                                    True -> {
                                                        4
                                                    }
                                                    False -> {
                                                        let v14 = v8 == "5"
                                                        case v14 {
                                                            True -> {
                                                                5
                                                            }
                                                            False -> {
                                                                let v15 = v8 == "6"
                                                                case v15 {
                                                                    True -> {
                                                                        6
                                                                    }
                                                                    False -> {
                                                                        let v16 = v8 == "7"
                                                                        case v16 {
                                                                            True -> {
                                                                                7
                                                                            }
                                                                            False -> {
                                                                                let v17 = v8 == "8"
                                                                                case v17 {
                                                                                    True -> {
                                                                                        8
                                                                                    }
                                                                                    False -> {
                                                                                        let v18 = v8 == "9"
                                                                                        case v18 {
                                                                                            True -> {
                                                                                                9
                                                                                            }
                                                                                            False -> {
                                                                                                -1
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
            let v29 = v28 < 0
            case v29 {
                True -> {
                    -1
                }
                False -> {
                    let v30 = spiral_wrap_signed(v1 + 1, 32)
                    let v31 = spiral_wrap_signed(v2 * 10, 32)
                    let v32 = spiral_wrap_signed(v31 + v28, 32)
                    let v33 = 1
                    parse_acc_26(v0, v30, v32, v33)
                }
            }
        }
    }
}
pub fn pair_25(v0: Uh1, v1: Int, v2: Int, v3: String) -> Us1 {
    case v0  {
        Uh1NoToken -> {
            Us1Parsed(v1, v2, v3)
        }
        Uh1Token(v5, v6) -> {
            let v7 = "--print-code" == v5
            case v7 {
                True -> {
                    let v8 = 1
                    pair_25(v6, v8, v2, v3)
                }
                False -> {
                    let v10 = "--timeout" == v5
                    case v10 {
                        True -> {
                            case v6  {
                                Uh1Token(v11, v12) -> {
                                    let v13 = 0
                                    let v14 = 0
                                    let v15 = 0
                                    let v16 = parse_acc_26(v11, v13, v14, v15)
                                    let v17 = v16 > 0
                                    case v17 {
                                        True -> {
                                            pair_25(v12, v1, v16, v3)
                                        }
                                        False -> {
                                            let v19 = { "error\ntimeout\n" } <> { v11 }
                                            Us1ParseBad(v19)
                                        }
                                    }
                                }
                                _ -> {
                                    let v22 = "--package" == v5
                                    case v22 {
                                        True -> {
                                            let v23 = "--test" == v5
                                            case v23 {
                                                True -> {
                                                    pair_25(v6, v1, v2, v3)
                                                }
                                                False -> {
                                                    let v25 = { "error\nflag\n" } <> { v5 }
                                                    Us1ParseBad(v25)
                                                }
                                            }
                                        }
                                        False -> {
                                            let v28 = "--test" == v5
                                            case v28 {
                                                True -> {
                                                    pair_25(v6, v1, v2, v3)
                                                }
                                                False -> {
                                                    let v30 = { "error\nflag\n" } <> { v5 }
                                                    Us1ParseBad(v30)
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        False -> {
                            let v35 = "--package" == v5
                            case v35 {
                                True -> {
                                    case v6  {
                                        Uh1Token(v36, v37) -> {
                                            let v38 = v3 == ""
                                            let v41 =
                                                case v38 {
                                                    True -> {
                                                        v36
                                                    }
                                                    False -> {
                                                        let v39 = { v3 } <> { "\t" }
                                                        let v40 = { v39 } <> { v36 }
                                                        v40
                                                    }
                                                }
                                            pair_25(v37, v1, v2, v41)
                                        }
                                        _ -> {
                                            let v43 = "--test" == v5
                                            case v43 {
                                                True -> {
                                                    pair_25(v6, v1, v2, v3)
                                                }
                                                False -> {
                                                    let v45 = { "error\nflag\n" } <> { v5 }
                                                    Us1ParseBad(v45)
                                                }
                                            }
                                        }
                                    }
                                }
                                False -> {
                                    let v49 = "--test" == v5
                                    case v49 {
                                        True -> {
                                            case v6  {
                                                Uh1Token(v50, v51) -> {
                                                    let v52 = "static" == v50
                                                    case v52 {
                                                        True -> {
                                                            pair_25(v51, v1, v2, v3)
                                                        }
                                                        False -> {
                                                            pair_25(v6, v1, v2, v3)
                                                        }
                                                    }
                                                }
                                                _ -> {
                                                    pair_25(v6, v1, v2, v3)
                                                }
                                            }
                                        }
                                        False -> {
                                            let v58 = { "error\nflag\n" } <> { v5 }
                                            Us1ParseBad(v58)
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
pub fn scan_27(v0: String, v1: Int, v2: String, v3: Int, v4: Int, v5: String, v6: Int, v7: Int, v8: Int) -> String {
    let v9 = kino_text_size(v0)
    let v10 = v1 > v9
    let v50 =
        case v10 {
            True -> {
                Us0LineDone
            }
            False -> {
                let v12 = v9 == 0
                let v14 =
                    case v12 {
                        True -> {
                            let v13 = v1 == 0
                            v13
                        }
                        False -> {
                            False
                        }
                    }
                case v14 {
                    True -> {
                        let v15 = ""
                        Us0LineGot(v15, 1)
                    }
                    False -> {
                        let v17 = v1 == v9
                        case v17 {
                            True -> {
                                let v18 = v9 > 0
                                let v22 =
                                    case v18 {
                                        True -> {
                                            let v19 = spiral_wrap_signed(v9 - 1, 32)
                                            let v20 = kino_text_at(v0, v19, 1)
                                            let v21 = v20 == "\n"
                                            v21
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v22 {
                                    True -> {
                                        let v23 = spiral_wrap_signed(v9 + 1, 32)
                                        let v24 = ""
                                        Us0LineGot(v24, v23)
                                    }
                                    False -> {
                                        Us0LineDone
                                    }
                                }
                            }
                            False -> {
                                let v28 = "\n"
                                let v29 = find_char_3(v0, v1, v28)
                                let v30 = v29 < 0
                                case v30 {
                                    True -> {
                                        let v31 = spiral_wrap_signed(v9 - 1, 32)
                                        let v32 = spiral_wrap_signed(v31 - v1, 32)
                                        let v33 = spiral_wrap_signed(v32 + 1, 32)
                                        let v34 = kino_text_at(v0, v1, v33)
                                        Us0LineGot(v34, v9)
                                    }
                                    False -> {
                                        let v36 = v29 == v1
                                        case v36 {
                                            True -> {
                                                let v37 = spiral_wrap_signed(v29 + 1, 32)
                                                let v38 = ""
                                                Us0LineGot(v38, v37)
                                            }
                                            False -> {
                                                let v40 = spiral_wrap_signed(v29 - 1, 32)
                                                let v41 = spiral_wrap_signed(v40 - v1, 32)
                                                let v42 = spiral_wrap_signed(v41 + 1, 32)
                                                let v43 = kino_text_at(v0, v1, v42)
                                                let v44 = spiral_wrap_signed(v29 + 1, 32)
                                                Us0LineGot(v43, v44)
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
    case v50  {
        Us0LineDone -> {
            let v51 = "\n#!"
            let v52 = 0
            let v53 = find_from_1(v2, v51, v52)
            let v54 = v53 >= 0
            case v54 {
                True -> {
                    let v55 = "error\ndib\n"
                    v55
                }
                False -> {
                    let v56 = "#!"
                    let v57 = kino_text_size(v56)
                    let v58 = kino_text_size(v2)
                    let v59 = v57 > v58
                    let v66 =
                        case v59 {
                            True -> {
                                False
                            }
                            False -> {
                                let v60 = v57 == 0
                                case v60 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v61 = spiral_wrap_signed(v57 - 1, 32)
                                        let v62 = spiral_wrap_signed(v61 + 1, 32)
                                        let v63 = kino_text_at(v2, 0, v62)
                                        let v64 = v63 == "#!"
                                        v64
                                    }
                                }
                            }
                        }
                    case v66 {
                        True -> {
                            let v67 = "error\ndib\n"
                            v67
                        }
                        False -> {
                            let v68 = 0
                            let v69 = Uh0NoLine
                            let v70 = collect_4(v2, v68, v69)
                            let v71 = count_lines_6(v70)
                            let v72 = spiral_wrap_signed(v71 - 1, 32)
                            let v73 = last_block_7(v70, v72)
                            let v74 = v73 >= 0
                            let v123 =
                                case v74 {
                                    True -> {
                                        let v75 = nth_line_8(v70, v73)
                                        let v76 = "inl main "
                                        let v77 = kino_text_size(v76)
                                        let v78 = kino_text_size(v75)
                                        let v79 = v77 > v78
                                        let v86 =
                                            case v79 {
                                                True -> {
                                                    False
                                                }
                                                False -> {
                                                    let v80 = v77 == 0
                                                    case v80 {
                                                        True -> {
                                                            True
                                                        }
                                                        False -> {
                                                            let v81 = spiral_wrap_signed(v77 - 1, 32)
                                                            let v82 = spiral_wrap_signed(v81 + 1, 32)
                                                            let v83 = kino_text_at(v75, 0, v82)
                                                            let v84 = v83 == "inl main "
                                                            v84
                                                        }
                                                    }
                                                }
                                            }
                                        case v86 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v87 = "let main "
                                                let v88 = kino_text_size(v87)
                                                let v89 = kino_text_size(v75)
                                                let v90 = v88 > v89
                                                let v97 =
                                                    case v90 {
                                                        True -> {
                                                            False
                                                        }
                                                        False -> {
                                                            let v91 = v88 == 0
                                                            case v91 {
                                                                True -> {
                                                                    True
                                                                }
                                                                False -> {
                                                                    let v92 = spiral_wrap_signed(v88 - 1, 32)
                                                                    let v93 = spiral_wrap_signed(v92 + 1, 32)
                                                                    let v94 = kino_text_at(v75, 0, v93)
                                                                    let v95 = v94 == "let main "
                                                                    v95
                                                                }
                                                            }
                                                        }
                                                    }
                                                case v97 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v98 = "inl main("
                                                        let v99 = kino_text_size(v98)
                                                        let v100 = kino_text_size(v75)
                                                        let v101 = v99 > v100
                                                        let v108 =
                                                            case v101 {
                                                                True -> {
                                                                    False
                                                                }
                                                                False -> {
                                                                    let v102 = v99 == 0
                                                                    case v102 {
                                                                        True -> {
                                                                            True
                                                                        }
                                                                        False -> {
                                                                            let v103 = spiral_wrap_signed(v99 - 1, 32)
                                                                            let v104 = spiral_wrap_signed(v103 + 1, 32)
                                                                            let v105 = kino_text_at(v75, 0, v104)
                                                                            let v106 = v105 == "inl main("
                                                                            v106
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        case v108 {
                                                            True -> {
                                                                True
                                                            }
                                                            False -> {
                                                                let v109 = "let main("
                                                                let v110 = kino_text_size(v109)
                                                                let v111 = kino_text_size(v75)
                                                                let v112 = v110 > v111
                                                                case v112 {
                                                                    True -> {
                                                                        False
                                                                    }
                                                                    False -> {
                                                                        let v113 = v110 == 0
                                                                        case v113 {
                                                                            True -> {
                                                                                True
                                                                            }
                                                                            False -> {
                                                                                let v114 = spiral_wrap_signed(v110 - 1, 32)
                                                                                let v115 = spiral_wrap_signed(v114 + 1, 32)
                                                                                let v116 = kino_text_at(v75, 0, v115)
                                                                                let v117 = v116 == "let main("
                                                                                v117
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
                                    False -> {
                                        False
                                    }
                                }
                            let #(v168, v169) =
                                case v123 {
                                    True -> {
                                        let v124 = kino_text_size(v2)
                                        let v125 = v124 == 0
                                        let v133 =
                                            case v125 {
                                                True -> {
                                                    let v126 = "\n"
                                                    v126
                                                }
                                                False -> {
                                                    let v127 = kino_text_size(v2)
                                                    let v128 = spiral_wrap_signed(v127 - 1, 32)
                                                    let v129 = kino_text_at(v2, v128, 1)
                                                    let v130 = v129 == "\n"
                                                    case v130 {
                                                        True -> {
                                                            v2
                                                        }
                                                        False -> {
                                                            let v131 = { v2 } <> { "\n" }
                                                            v131
                                                        }
                                                    }
                                                }
                                            }
                                        #(v133, 0)
                                    }
                                    False -> {
                                        let v134 = -1
                                        let v135 = search_top_9(v70, v72, v134)
                                        let v136 = v135 < 0
                                        case v136 {
                                            True -> {
                                                let v137 = kino_text_size(v2)
                                                let v138 = v137 == 0
                                                let v146 =
                                                    case v138 {
                                                        True -> {
                                                            let v139 = "\n"
                                                            v139
                                                        }
                                                        False -> {
                                                            let v140 = kino_text_size(v2)
                                                            let v141 = spiral_wrap_signed(v140 - 1, 32)
                                                            let v142 = kino_text_at(v2, v141, 1)
                                                            let v143 = v142 == "\n"
                                                            case v143 {
                                                                True -> {
                                                                    v2
                                                                }
                                                                False -> {
                                                                    let v144 = { v2 } <> { "\n" }
                                                                    v144
                                                                }
                                                            }
                                                        }
                                                    }
                                                let v147 = { v146 } <> { "inl main () : i32 = 0i32\n" }
                                                #(v147, 2)
                                            }
                                            False -> {
                                                let v148 = 0
                                                let v149 = map_main_16(v70, v148, v135)
                                                let v155 =
                                                    case v149  {
                                                        Uh0Line(v151, v152) -> {
                                                            join_from_19(v152, v151)
                                                        }
                                                        Uh0NoLine -> {
                                                            let v150 = ""
                                                            v150
                                                        }
                                                    }
                                                let v156 = kino_text_size(v155)
                                                let v157 = v156 == 0
                                                let v165 =
                                                    case v157 {
                                                        True -> {
                                                            let v158 = "\n"
                                                            v158
                                                        }
                                                        False -> {
                                                            let v159 = kino_text_size(v155)
                                                            let v160 = spiral_wrap_signed(v159 - 1, 32)
                                                            let v161 = kino_text_at(v155, v160, 1)
                                                            let v162 = v161 == "\n"
                                                            case v162 {
                                                                True -> {
                                                                    v155
                                                                }
                                                                False -> {
                                                                    let v163 = { v155 } <> { "\n" }
                                                                    v163
                                                                }
                                                            }
                                                        }
                                                    }
                                                #(v165, 1)
                                            }
                                        }
                                    }
                                }
                            let v170 = v4 < 0
                            let v173 =
                                case v170 {
                                    True -> {
                                        let v171 = "-"
                                        v171
                                    }
                                    False -> {
                                        show_i32_20(v4)
                                    }
                                }
                            let v174 = show_i32_20(v3)
                            let v175 = { "ok\n" } <> { v174 }
                            let v176 = { v175 } <> { "\n" }
                            let v177 = { v176 } <> { v173 }
                            let v178 = { v177 } <> { "\n" }
                            let v179 = show_i32_20(v169)
                            let v180 = { v178 } <> { v179 }
                            let v181 = { v180 } <> { "\n" }
                            let v182 = { v181 } <> { v5 }
                            let v183 = { v182 } <> { "\n" }
                            let v184 = show_i32_20(v8)
                            let v185 = { v183 } <> { v184 }
                            let v186 = { v185 } <> { "\n" }
                            let v187 = { v186 } <> { v168 }
                            v187
                        }
                    }
                }
            }
        }
        Us0LineGot(v190, v191) -> {
            let v192 = "////"
            let v193 = kino_text_size(v192)
            let v194 = kino_text_size(v190)
            let v195 = v193 > v194
            let v202 =
                case v195 {
                    True -> {
                        False
                    }
                    False -> {
                        let v196 = v193 == 0
                        case v196 {
                            True -> {
                                True
                            }
                            False -> {
                                let v197 = spiral_wrap_signed(v193 - 1, 32)
                                let v198 = spiral_wrap_signed(v197 + 1, 32)
                                let v199 = kino_text_at(v190, 0, v198)
                                let v200 = v199 == "////"
                                v200
                            }
                        }
                    }
                }
            case v202 {
                True -> {
                    scan_27(v0, v191, v2, v3, v4, v5, v6, v7, v8)
                }
                False -> {
                    let v204 = "///- "
                    let v205 = kino_text_size(v204)
                    let v206 = kino_text_size(v190)
                    let v207 = v205 > v206
                    let v214 =
                        case v207 {
                            True -> {
                                False
                            }
                            False -> {
                                let v208 = v205 == 0
                                case v208 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v209 = spiral_wrap_signed(v205 - 1, 32)
                                        let v210 = spiral_wrap_signed(v209 + 1, 32)
                                        let v211 = kino_text_at(v190, 0, v210)
                                        let v212 = v211 == "///- "
                                        v212
                                    }
                                }
                            }
                        }
                    case v214 {
                        True -> {
                            let v215 = v6 == 1
                            case v215 {
                                True -> {
                                    let v216 = 1
                                    scan_27(v0, v191, v2, v3, v4, v5, v216, v7, v8)
                                }
                                False -> {
                                    let v218 = kino_text_size(v204)
                                    let v219 = kino_text_size(v190)
                                    let v220 = v218 >= v219
                                    let v228 =
                                        case v220 {
                                            True -> {
                                                let v221 = ""
                                                v221
                                            }
                                            False -> {
                                                let v222 = v218 <= 0
                                                case v222 {
                                                    True -> {
                                                        v190
                                                    }
                                                    False -> {
                                                        let v223 = spiral_wrap_signed(v219 - 1, 32)
                                                        let v224 = spiral_wrap_signed(v223 - v218, 32)
                                                        let v225 = spiral_wrap_signed(v224 + 1, 32)
                                                        let v226 = kino_text_at(v190, v218, v225)
                                                        v226
                                                    }
                                                }
                                            }
                                        }
                                    let v229 = 0
                                    let v230 = Uh1NoToken
                                    let v231 = tokens_from_21(v228, v229, v230)
                                    let v232 = pair_25(v231, v3, v4, v5)
                                    case v232  {
                                        Us1ParseBad(v233) -> {
                                            v233
                                        }
                                        Us1Parsed(v234, v235, v236) -> {
                                            let v237 = 1
                                            scan_27(v0, v191, v2, v234, v235, v236, v237, v7, v8)
                                        }
                                    }
                                }
                            }
                        }
                        False -> {
                            let v242 = "///> "
                            let v243 = kino_text_size(v242)
                            let v244 = kino_text_size(v190)
                            let v245 = v243 > v244
                            let v252 =
                                case v245 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v246 = v243 == 0
                                        case v246 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v247 = spiral_wrap_signed(v243 - 1, 32)
                                                let v248 = spiral_wrap_signed(v247 + 1, 32)
                                                let v249 = kino_text_at(v190, 0, v248)
                                                let v250 = v249 == "///> "
                                                v250
                                            }
                                        }
                                    }
                                }
                            case v252 {
                                True -> {
                                    let v253 = kino_text_size(v242)
                                    let v254 = kino_text_size(v190)
                                    let v255 = v253 >= v254
                                    let v263 =
                                        case v255 {
                                            True -> {
                                                let v256 = ""
                                                v256
                                            }
                                            False -> {
                                                let v257 = v253 <= 0
                                                case v257 {
                                                    True -> {
                                                        v190
                                                    }
                                                    False -> {
                                                        let v258 = spiral_wrap_signed(v254 - 1, 32)
                                                        let v259 = spiral_wrap_signed(v258 - v253, 32)
                                                        let v260 = spiral_wrap_signed(v259 + 1, 32)
                                                        let v261 = kino_text_at(v190, v253, v260)
                                                        v261
                                                    }
                                                }
                                            }
                                        }
                                    let v264 = 0
                                    let v265 = trim_start_17(v263, v264)
                                    let v266 = kino_text_size(v263)
                                    let v267 = trim_end_18(v263, v266)
                                    let v268 = v267 <= v265
                                    let v274 =
                                        case v268 {
                                            True -> {
                                                let v269 = ""
                                                v269
                                            }
                                            False -> {
                                                let v270 = spiral_wrap_signed(v267 - 1, 32)
                                                let v271 = spiral_wrap_signed(v270 - v265, 32)
                                                let v272 = spiral_wrap_signed(v271 + 1, 32)
                                                let v273 = kino_text_at(v263, v265, v272)
                                                v273
                                            }
                                        }
                                    let v275 = v274 == "_"
                                    let v294 =
                                        case v275 {
                                            True -> {
                                                let v276 = "skip"
                                                v276
                                            }
                                            False -> {
                                                let v277 = v274 == "rust"
                                                case v277 {
                                                    True -> {
                                                        let v278 = ""
                                                        v278
                                                    }
                                                    False -> {
                                                        let v279 = "rust "
                                                        let v280 = kino_text_size(v279)
                                                        let v281 = kino_text_size(v274)
                                                        let v282 = v280 > v281
                                                        let v289 =
                                                            case v282 {
                                                                True -> {
                                                                    False
                                                                }
                                                                False -> {
                                                                    let v283 = v280 == 0
                                                                    case v283 {
                                                                        True -> {
                                                                            True
                                                                        }
                                                                        False -> {
                                                                            let v284 = spiral_wrap_signed(v280 - 1, 32)
                                                                            let v285 = spiral_wrap_signed(v284 + 1, 32)
                                                                            let v286 = kino_text_at(v274, 0, v285)
                                                                            let v287 = v286 == "rust "
                                                                            v287
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        case v289 {
                                                            True -> {
                                                                let v290 = ""
                                                                v290
                                                            }
                                                            False -> {
                                                                let v291 = { "error\nbackend\n" } <> { v274 }
                                                                v291
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    let v295 = "error\n"
                                    let v296 = kino_text_size(v295)
                                    let v297 = kino_text_size(v294)
                                    let v298 = v296 > v297
                                    let v305 =
                                        case v298 {
                                            True -> {
                                                False
                                            }
                                            False -> {
                                                let v299 = v296 == 0
                                                case v299 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v300 = spiral_wrap_signed(v296 - 1, 32)
                                                        let v301 = spiral_wrap_signed(v300 + 1, 32)
                                                        let v302 = kino_text_at(v294, 0, v301)
                                                        let v303 = v302 == "error\n"
                                                        v303
                                                    }
                                                }
                                            }
                                        }
                                    case v305 {
                                        True -> {
                                            v294
                                        }
                                        False -> {
                                            let v306 = v294 == "skip"
                                            case v306 {
                                                True -> {
                                                    let v307 = 1
                                                    scan_27(v0, v191, v2, v3, v4, v5, v6, v7, v307)
                                                }
                                                False -> {
                                                    scan_27(v0, v191, v2, v3, v4, v5, v6, v7, v8)
                                                }
                                            }
                                        }
                                    }
                                }
                                False -> {
                                    let v312 = "///"
                                    let v313 = kino_text_size(v312)
                                    let v314 = kino_text_size(v190)
                                    let v315 = v313 > v314
                                    let v322 =
                                        case v315 {
                                            True -> {
                                                False
                                            }
                                            False -> {
                                                let v316 = v313 == 0
                                                case v316 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v317 = spiral_wrap_signed(v313 - 1, 32)
                                                        let v318 = spiral_wrap_signed(v317 + 1, 32)
                                                        let v319 = kino_text_at(v190, 0, v318)
                                                        let v320 = v319 == "///"
                                                        v320
                                                    }
                                                }
                                            }
                                        }
                                    case v322 {
                                        True -> {
                                            let v323 = { "error\ndirective\n" } <> { v190 }
                                            v323
                                        }
                                        False -> {
                                            let v324 = v7 == 0
                                            let v327 =
                                                case v324 {
                                                    True -> {
                                                        v190
                                                    }
                                                    False -> {
                                                        let v325 = { v2 } <> { "\n" }
                                                        let v326 = { v325 } <> { v190 }
                                                        v326
                                                    }
                                                }
                                            let v328 = 1
                                            scan_27(v0, v191, v327, v3, v4, v5, v6, v328, v8)
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
pub fn scan_2(v0: String, v1: Int, v2: String, v3: Int, v4: Int, v5: Int, v6: Int, v7: Int) -> String {
    let v8 = kino_text_size(v0)
    let v9 = v1 > v8
    let v49 =
        case v9 {
            True -> {
                Us0LineDone
            }
            False -> {
                let v11 = v8 == 0
                let v13 =
                    case v11 {
                        True -> {
                            let v12 = v1 == 0
                            v12
                        }
                        False -> {
                            False
                        }
                    }
                case v13 {
                    True -> {
                        let v14 = ""
                        Us0LineGot(v14, 1)
                    }
                    False -> {
                        let v16 = v1 == v8
                        case v16 {
                            True -> {
                                let v17 = v8 > 0
                                let v21 =
                                    case v17 {
                                        True -> {
                                            let v18 = spiral_wrap_signed(v8 - 1, 32)
                                            let v19 = kino_text_at(v0, v18, 1)
                                            let v20 = v19 == "\n"
                                            v20
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v21 {
                                    True -> {
                                        let v22 = spiral_wrap_signed(v8 + 1, 32)
                                        let v23 = ""
                                        Us0LineGot(v23, v22)
                                    }
                                    False -> {
                                        Us0LineDone
                                    }
                                }
                            }
                            False -> {
                                let v27 = "\n"
                                let v28 = find_char_3(v0, v1, v27)
                                let v29 = v28 < 0
                                case v29 {
                                    True -> {
                                        let v30 = spiral_wrap_signed(v8 - 1, 32)
                                        let v31 = spiral_wrap_signed(v30 - v1, 32)
                                        let v32 = spiral_wrap_signed(v31 + 1, 32)
                                        let v33 = kino_text_at(v0, v1, v32)
                                        Us0LineGot(v33, v8)
                                    }
                                    False -> {
                                        let v35 = v28 == v1
                                        case v35 {
                                            True -> {
                                                let v36 = spiral_wrap_signed(v28 + 1, 32)
                                                let v37 = ""
                                                Us0LineGot(v37, v36)
                                            }
                                            False -> {
                                                let v39 = spiral_wrap_signed(v28 - 1, 32)
                                                let v40 = spiral_wrap_signed(v39 - v1, 32)
                                                let v41 = spiral_wrap_signed(v40 + 1, 32)
                                                let v42 = kino_text_at(v0, v1, v41)
                                                let v43 = spiral_wrap_signed(v28 + 1, 32)
                                                Us0LineGot(v42, v43)
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
    case v49  {
        Us0LineDone -> {
            let v50 = "\n#!"
            let v51 = 0
            let v52 = find_from_1(v2, v50, v51)
            let v53 = v52 >= 0
            case v53 {
                True -> {
                    let v54 = "error\ndib\n"
                    v54
                }
                False -> {
                    let v55 = "#!"
                    let v56 = kino_text_size(v55)
                    let v57 = kino_text_size(v2)
                    let v58 = v56 > v57
                    let v65 =
                        case v58 {
                            True -> {
                                False
                            }
                            False -> {
                                let v59 = v56 == 0
                                case v59 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v60 = spiral_wrap_signed(v56 - 1, 32)
                                        let v61 = spiral_wrap_signed(v60 + 1, 32)
                                        let v62 = kino_text_at(v2, 0, v61)
                                        let v63 = v62 == "#!"
                                        v63
                                    }
                                }
                            }
                        }
                    case v65 {
                        True -> {
                            let v66 = "error\ndib\n"
                            v66
                        }
                        False -> {
                            let v67 = 0
                            let v68 = Uh0NoLine
                            let v69 = collect_4(v2, v67, v68)
                            let v70 = count_lines_6(v69)
                            let v71 = spiral_wrap_signed(v70 - 1, 32)
                            let v72 = last_block_7(v69, v71)
                            let v73 = v72 >= 0
                            let v122 =
                                case v73 {
                                    True -> {
                                        let v74 = nth_line_8(v69, v72)
                                        let v75 = "inl main "
                                        let v76 = kino_text_size(v75)
                                        let v77 = kino_text_size(v74)
                                        let v78 = v76 > v77
                                        let v85 =
                                            case v78 {
                                                True -> {
                                                    False
                                                }
                                                False -> {
                                                    let v79 = v76 == 0
                                                    case v79 {
                                                        True -> {
                                                            True
                                                        }
                                                        False -> {
                                                            let v80 = spiral_wrap_signed(v76 - 1, 32)
                                                            let v81 = spiral_wrap_signed(v80 + 1, 32)
                                                            let v82 = kino_text_at(v74, 0, v81)
                                                            let v83 = v82 == "inl main "
                                                            v83
                                                        }
                                                    }
                                                }
                                            }
                                        case v85 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v86 = "let main "
                                                let v87 = kino_text_size(v86)
                                                let v88 = kino_text_size(v74)
                                                let v89 = v87 > v88
                                                let v96 =
                                                    case v89 {
                                                        True -> {
                                                            False
                                                        }
                                                        False -> {
                                                            let v90 = v87 == 0
                                                            case v90 {
                                                                True -> {
                                                                    True
                                                                }
                                                                False -> {
                                                                    let v91 = spiral_wrap_signed(v87 - 1, 32)
                                                                    let v92 = spiral_wrap_signed(v91 + 1, 32)
                                                                    let v93 = kino_text_at(v74, 0, v92)
                                                                    let v94 = v93 == "let main "
                                                                    v94
                                                                }
                                                            }
                                                        }
                                                    }
                                                case v96 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v97 = "inl main("
                                                        let v98 = kino_text_size(v97)
                                                        let v99 = kino_text_size(v74)
                                                        let v100 = v98 > v99
                                                        let v107 =
                                                            case v100 {
                                                                True -> {
                                                                    False
                                                                }
                                                                False -> {
                                                                    let v101 = v98 == 0
                                                                    case v101 {
                                                                        True -> {
                                                                            True
                                                                        }
                                                                        False -> {
                                                                            let v102 = spiral_wrap_signed(v98 - 1, 32)
                                                                            let v103 = spiral_wrap_signed(v102 + 1, 32)
                                                                            let v104 = kino_text_at(v74, 0, v103)
                                                                            let v105 = v104 == "inl main("
                                                                            v105
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        case v107 {
                                                            True -> {
                                                                True
                                                            }
                                                            False -> {
                                                                let v108 = "let main("
                                                                let v109 = kino_text_size(v108)
                                                                let v110 = kino_text_size(v74)
                                                                let v111 = v109 > v110
                                                                case v111 {
                                                                    True -> {
                                                                        False
                                                                    }
                                                                    False -> {
                                                                        let v112 = v109 == 0
                                                                        case v112 {
                                                                            True -> {
                                                                                True
                                                                            }
                                                                            False -> {
                                                                                let v113 = spiral_wrap_signed(v109 - 1, 32)
                                                                                let v114 = spiral_wrap_signed(v113 + 1, 32)
                                                                                let v115 = kino_text_at(v74, 0, v114)
                                                                                let v116 = v115 == "let main("
                                                                                v116
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
                                    False -> {
                                        False
                                    }
                                }
                            let #(v167, v168) =
                                case v122 {
                                    True -> {
                                        let v123 = kino_text_size(v2)
                                        let v124 = v123 == 0
                                        let v132 =
                                            case v124 {
                                                True -> {
                                                    let v125 = "\n"
                                                    v125
                                                }
                                                False -> {
                                                    let v126 = kino_text_size(v2)
                                                    let v127 = spiral_wrap_signed(v126 - 1, 32)
                                                    let v128 = kino_text_at(v2, v127, 1)
                                                    let v129 = v128 == "\n"
                                                    case v129 {
                                                        True -> {
                                                            v2
                                                        }
                                                        False -> {
                                                            let v130 = { v2 } <> { "\n" }
                                                            v130
                                                        }
                                                    }
                                                }
                                            }
                                        #(v132, 0)
                                    }
                                    False -> {
                                        let v133 = -1
                                        let v134 = search_top_9(v69, v71, v133)
                                        let v135 = v134 < 0
                                        case v135 {
                                            True -> {
                                                let v136 = kino_text_size(v2)
                                                let v137 = v136 == 0
                                                let v145 =
                                                    case v137 {
                                                        True -> {
                                                            let v138 = "\n"
                                                            v138
                                                        }
                                                        False -> {
                                                            let v139 = kino_text_size(v2)
                                                            let v140 = spiral_wrap_signed(v139 - 1, 32)
                                                            let v141 = kino_text_at(v2, v140, 1)
                                                            let v142 = v141 == "\n"
                                                            case v142 {
                                                                True -> {
                                                                    v2
                                                                }
                                                                False -> {
                                                                    let v143 = { v2 } <> { "\n" }
                                                                    v143
                                                                }
                                                            }
                                                        }
                                                    }
                                                let v146 = { v145 } <> { "inl main () : i32 = 0i32\n" }
                                                #(v146, 2)
                                            }
                                            False -> {
                                                let v147 = 0
                                                let v148 = map_main_16(v69, v147, v134)
                                                let v154 =
                                                    case v148  {
                                                        Uh0Line(v150, v151) -> {
                                                            join_from_19(v151, v150)
                                                        }
                                                        Uh0NoLine -> {
                                                            let v149 = ""
                                                            v149
                                                        }
                                                    }
                                                let v155 = kino_text_size(v154)
                                                let v156 = v155 == 0
                                                let v164 =
                                                    case v156 {
                                                        True -> {
                                                            let v157 = "\n"
                                                            v157
                                                        }
                                                        False -> {
                                                            let v158 = kino_text_size(v154)
                                                            let v159 = spiral_wrap_signed(v158 - 1, 32)
                                                            let v160 = kino_text_at(v154, v159, 1)
                                                            let v161 = v160 == "\n"
                                                            case v161 {
                                                                True -> {
                                                                    v154
                                                                }
                                                                False -> {
                                                                    let v162 = { v154 } <> { "\n" }
                                                                    v162
                                                                }
                                                            }
                                                        }
                                                    }
                                                #(v164, 1)
                                            }
                                        }
                                    }
                                }
                            let v169 = v4 < 0
                            let v172 =
                                case v169 {
                                    True -> {
                                        let v170 = "-"
                                        v170
                                    }
                                    False -> {
                                        show_i32_20(v4)
                                    }
                                }
                            let v173 = show_i32_20(v3)
                            let v174 = { "ok\n" } <> { v173 }
                            let v175 = { v174 } <> { "\n" }
                            let v176 = { v175 } <> { v172 }
                            let v177 = { v176 } <> { "\n" }
                            let v178 = show_i32_20(v168)
                            let v179 = { v177 } <> { v178 }
                            let v180 = { v179 } <> { "\n" }
                            let v181 = { v180 } <> { v2 }
                            let v182 = { v181 } <> { "\n" }
                            let v183 = show_i32_20(v7)
                            let v184 = { v182 } <> { v183 }
                            let v185 = { v184 } <> { "\n" }
                            let v186 = { v185 } <> { v167 }
                            v186
                        }
                    }
                }
            }
        }
        Us0LineGot(v189, v190) -> {
            let v191 = "////"
            let v192 = kino_text_size(v191)
            let v193 = kino_text_size(v189)
            let v194 = v192 > v193
            let v201 =
                case v194 {
                    True -> {
                        False
                    }
                    False -> {
                        let v195 = v192 == 0
                        case v195 {
                            True -> {
                                True
                            }
                            False -> {
                                let v196 = spiral_wrap_signed(v192 - 1, 32)
                                let v197 = spiral_wrap_signed(v196 + 1, 32)
                                let v198 = kino_text_at(v189, 0, v197)
                                let v199 = v198 == "////"
                                v199
                            }
                        }
                    }
                }
            case v201 {
                True -> {
                    scan_2(v0, v190, v2, v3, v4, v5, v6, v7)
                }
                False -> {
                    let v203 = "///- "
                    let v204 = kino_text_size(v203)
                    let v205 = kino_text_size(v189)
                    let v206 = v204 > v205
                    let v213 =
                        case v206 {
                            True -> {
                                False
                            }
                            False -> {
                                let v207 = v204 == 0
                                case v207 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v208 = spiral_wrap_signed(v204 - 1, 32)
                                        let v209 = spiral_wrap_signed(v208 + 1, 32)
                                        let v210 = kino_text_at(v189, 0, v209)
                                        let v211 = v210 == "///- "
                                        v211
                                    }
                                }
                            }
                        }
                    case v213 {
                        True -> {
                            let v214 = v5 == 1
                            case v214 {
                                True -> {
                                    let v215 = 1
                                    scan_2(v0, v190, v2, v3, v4, v215, v6, v7)
                                }
                                False -> {
                                    let v217 = kino_text_size(v203)
                                    let v218 = kino_text_size(v189)
                                    let v219 = v217 >= v218
                                    let v227 =
                                        case v219 {
                                            True -> {
                                                let v220 = ""
                                                v220
                                            }
                                            False -> {
                                                let v221 = v217 <= 0
                                                case v221 {
                                                    True -> {
                                                        v189
                                                    }
                                                    False -> {
                                                        let v222 = spiral_wrap_signed(v218 - 1, 32)
                                                        let v223 = spiral_wrap_signed(v222 - v217, 32)
                                                        let v224 = spiral_wrap_signed(v223 + 1, 32)
                                                        let v225 = kino_text_at(v189, v217, v224)
                                                        v225
                                                    }
                                                }
                                            }
                                        }
                                    let v228 = 0
                                    let v229 = Uh1NoToken
                                    let v230 = tokens_from_21(v227, v228, v229)
                                    let v231 = pair_25(v230, v3, v4, v2)
                                    case v231  {
                                        Us1ParseBad(v232) -> {
                                            v232
                                        }
                                        Us1Parsed(v233, v234, v235) -> {
                                            let v236 = 1
                                            scan_27(v0, v190, v2, v233, v234, v235, v236, v6, v7)
                                        }
                                    }
                                }
                            }
                        }
                        False -> {
                            let v241 = "///> "
                            let v242 = kino_text_size(v241)
                            let v243 = kino_text_size(v189)
                            let v244 = v242 > v243
                            let v251 =
                                case v244 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v245 = v242 == 0
                                        case v245 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v246 = spiral_wrap_signed(v242 - 1, 32)
                                                let v247 = spiral_wrap_signed(v246 + 1, 32)
                                                let v248 = kino_text_at(v189, 0, v247)
                                                let v249 = v248 == "///> "
                                                v249
                                            }
                                        }
                                    }
                                }
                            case v251 {
                                True -> {
                                    let v252 = kino_text_size(v241)
                                    let v253 = kino_text_size(v189)
                                    let v254 = v252 >= v253
                                    let v262 =
                                        case v254 {
                                            True -> {
                                                let v255 = ""
                                                v255
                                            }
                                            False -> {
                                                let v256 = v252 <= 0
                                                case v256 {
                                                    True -> {
                                                        v189
                                                    }
                                                    False -> {
                                                        let v257 = spiral_wrap_signed(v253 - 1, 32)
                                                        let v258 = spiral_wrap_signed(v257 - v252, 32)
                                                        let v259 = spiral_wrap_signed(v258 + 1, 32)
                                                        let v260 = kino_text_at(v189, v252, v259)
                                                        v260
                                                    }
                                                }
                                            }
                                        }
                                    let v263 = 0
                                    let v264 = trim_start_17(v262, v263)
                                    let v265 = kino_text_size(v262)
                                    let v266 = trim_end_18(v262, v265)
                                    let v267 = v266 <= v264
                                    let v273 =
                                        case v267 {
                                            True -> {
                                                let v268 = ""
                                                v268
                                            }
                                            False -> {
                                                let v269 = spiral_wrap_signed(v266 - 1, 32)
                                                let v270 = spiral_wrap_signed(v269 - v264, 32)
                                                let v271 = spiral_wrap_signed(v270 + 1, 32)
                                                let v272 = kino_text_at(v262, v264, v271)
                                                v272
                                            }
                                        }
                                    let v274 = v273 == "_"
                                    let v293 =
                                        case v274 {
                                            True -> {
                                                let v275 = "skip"
                                                v275
                                            }
                                            False -> {
                                                let v276 = v273 == "rust"
                                                case v276 {
                                                    True -> {
                                                        let v277 = ""
                                                        v277
                                                    }
                                                    False -> {
                                                        let v278 = "rust "
                                                        let v279 = kino_text_size(v278)
                                                        let v280 = kino_text_size(v273)
                                                        let v281 = v279 > v280
                                                        let v288 =
                                                            case v281 {
                                                                True -> {
                                                                    False
                                                                }
                                                                False -> {
                                                                    let v282 = v279 == 0
                                                                    case v282 {
                                                                        True -> {
                                                                            True
                                                                        }
                                                                        False -> {
                                                                            let v283 = spiral_wrap_signed(v279 - 1, 32)
                                                                            let v284 = spiral_wrap_signed(v283 + 1, 32)
                                                                            let v285 = kino_text_at(v273, 0, v284)
                                                                            let v286 = v285 == "rust "
                                                                            v286
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        case v288 {
                                                            True -> {
                                                                let v289 = ""
                                                                v289
                                                            }
                                                            False -> {
                                                                let v290 = { "error\nbackend\n" } <> { v273 }
                                                                v290
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    let v294 = "error\n"
                                    let v295 = kino_text_size(v294)
                                    let v296 = kino_text_size(v293)
                                    let v297 = v295 > v296
                                    let v304 =
                                        case v297 {
                                            True -> {
                                                False
                                            }
                                            False -> {
                                                let v298 = v295 == 0
                                                case v298 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v299 = spiral_wrap_signed(v295 - 1, 32)
                                                        let v300 = spiral_wrap_signed(v299 + 1, 32)
                                                        let v301 = kino_text_at(v293, 0, v300)
                                                        let v302 = v301 == "error\n"
                                                        v302
                                                    }
                                                }
                                            }
                                        }
                                    case v304 {
                                        True -> {
                                            v293
                                        }
                                        False -> {
                                            let v305 = v293 == "skip"
                                            case v305 {
                                                True -> {
                                                    let v306 = 1
                                                    scan_2(v0, v190, v2, v3, v4, v5, v6, v306)
                                                }
                                                False -> {
                                                    scan_2(v0, v190, v2, v3, v4, v5, v6, v7)
                                                }
                                            }
                                        }
                                    }
                                }
                                False -> {
                                    let v311 = "///"
                                    let v312 = kino_text_size(v311)
                                    let v313 = kino_text_size(v189)
                                    let v314 = v312 > v313
                                    let v321 =
                                        case v314 {
                                            True -> {
                                                False
                                            }
                                            False -> {
                                                let v315 = v312 == 0
                                                case v315 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v316 = spiral_wrap_signed(v312 - 1, 32)
                                                        let v317 = spiral_wrap_signed(v316 + 1, 32)
                                                        let v318 = kino_text_at(v189, 0, v317)
                                                        let v319 = v318 == "///"
                                                        v319
                                                    }
                                                }
                                            }
                                        }
                                    case v321 {
                                        True -> {
                                            let v322 = { "error\ndirective\n" } <> { v189 }
                                            v322
                                        }
                                        False -> {
                                            let v323 = v6 == 0
                                            let v326 =
                                                case v323 {
                                                    True -> {
                                                        v189
                                                    }
                                                    False -> {
                                                        let v324 = { v2 } <> { "\n" }
                                                        let v325 = { v324 } <> { v189 }
                                                        v325
                                                    }
                                                }
                                            let v327 = 1
                                            scan_27(v0, v190, v326, v3, v4, v2, v5, v327, v7)
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
pub fn closure0(capt: Nil) -> fn(String) -> String {
    fn (v0) {
        let v1 = "\r\n"
        let v2 = "\n"
        let v3 = 0
        let v4 = ""
        let v5 = replace_from_0(v0, v1, v2, v3, v4)
        let v6 = 0
        let v7 = 0
        let v8 = -1
        let v9 = 0
        let v10 = 0
        let v11 = 0
        scan_2(v5, v6, v4, v7, v8, v9, v10, v11)
    }
}
pub fn trim_nl_start_29(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = v4 == "\n"
            case v5 {
                True -> {
                    let v6 = spiral_wrap_signed(v1 + 1, 32)
                    trim_nl_start_29(v0, v6)
                }
                False -> {
                    v1
                }
            }
        }
    }
}
pub fn trim_nl_end_30(v0: String, v1: Int) -> Int {
    let v2 = v1 <= 0
    case v2 {
        True -> {
            0
        }
        False -> {
            let v3 = spiral_wrap_signed(v1 - 1, 32)
            let v4 = kino_text_at(v0, v3, 1)
            let v5 = v4 == "\n"
            case v5 {
                True -> {
                    trim_nl_end_30(v0, v3)
                }
                False -> {
                    v1
                }
            }
        }
    }
}
pub fn skip_spaces_31(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 < v2
    let v6 =
        case v3 {
            True -> {
                let v4 = kino_text_at(v0, v1, 1)
                let v5 = v4 == " "
                v5
            }
            False -> {
                False
            }
        }
    case v6 {
        True -> {
            let v7 = spiral_wrap_signed(v1 + 1, 32)
            skip_spaces_31(v0, v7)
        }
        False -> {
            v1
        }
    }
}
pub fn digits_end_32(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 < v2
    let v26 =
        case v3 {
            True -> {
                let v4 = kino_text_at(v0, v1, 1)
                let v5 = v4 == "0"
                let v24 =
                    case v5 {
                        True -> {
                            0
                        }
                        False -> {
                            let v6 = v4 == "1"
                            case v6 {
                                True -> {
                                    1
                                }
                                False -> {
                                    let v7 = v4 == "2"
                                    case v7 {
                                        True -> {
                                            2
                                        }
                                        False -> {
                                            let v8 = v4 == "3"
                                            case v8 {
                                                True -> {
                                                    3
                                                }
                                                False -> {
                                                    let v9 = v4 == "4"
                                                    case v9 {
                                                        True -> {
                                                            4
                                                        }
                                                        False -> {
                                                            let v10 = v4 == "5"
                                                            case v10 {
                                                                True -> {
                                                                    5
                                                                }
                                                                False -> {
                                                                    let v11 = v4 == "6"
                                                                    case v11 {
                                                                        True -> {
                                                                            6
                                                                        }
                                                                        False -> {
                                                                            let v12 = v4 == "7"
                                                                            case v12 {
                                                                                True -> {
                                                                                    7
                                                                                }
                                                                                False -> {
                                                                                    let v13 = v4 == "8"
                                                                                    case v13 {
                                                                                        True -> {
                                                                                            8
                                                                                        }
                                                                                        False -> {
                                                                                            let v14 = v4 == "9"
                                                                                            case v14 {
                                                                                                True -> {
                                                                                                    9
                                                                                                }
                                                                                                False -> {
                                                                                                    -1
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
                let v25 = v24 >= 0
                v25
            }
            False -> {
                False
            }
        }
    case v26 {
        True -> {
            let v27 = spiral_wrap_signed(v1 + 1, 32)
            digits_end_32(v0, v27)
        }
        False -> {
            v1
        }
    }
}
pub fn scan_33(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            -1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = v4 == "\\"
            case v5 {
                True -> {
                    let v6 = spiral_wrap_signed(v1 + 2, 32)
                    scan_33(v0, v6)
                }
                False -> {
                    let v8 = kino_text_at(v0, v1, 1)
                    let v9 = v8 == "\""
                    case v9 {
                        True -> {
                            v1
                        }
                        False -> {
                            let v10 = spiral_wrap_signed(v1 + 1, 32)
                            scan_33(v0, v10)
                        }
                    }
                }
            }
        }
    }
}
pub fn go_34(v0: String, v1: Int, v2: String) -> String {
    let v3 = kino_text_size(v0)
    let v4 = v1 >= v3
    case v4 {
        True -> {
            v2
        }
        False -> {
            let v5 = "\\\\"
            let v6 = kino_text_size(v5)
            let v7 = v1 < 0
            let v19 =
                case v7 {
                    True -> {
                        False
                    }
                    False -> {
                        let v8 = spiral_wrap_signed(v1 + v6, 32)
                        let v9 = kino_text_size(v0)
                        let v10 = v8 > v9
                        case v10 {
                            True -> {
                                False
                            }
                            False -> {
                                let v11 = v6 == 0
                                case v11 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v12 = spiral_wrap_signed(v8 - 1, 32)
                                        let v13 = spiral_wrap_signed(v12 - v1, 32)
                                        let v14 = spiral_wrap_signed(v13 + 1, 32)
                                        let v15 = kino_text_at(v0, v1, v14)
                                        let v16 = v15 == "\\\\"
                                        v16
                                    }
                                }
                            }
                        }
                    }
                }
            case v19 {
                True -> {
                    let v20 = spiral_wrap_signed(v1 + 2, 32)
                    let v21 = { v2 } <> { "\\" }
                    go_34(v0, v20, v21)
                }
                False -> {
                    let v23 = "\\\""
                    let v24 = kino_text_size(v23)
                    let v36 =
                        case v7 {
                            True -> {
                                False
                            }
                            False -> {
                                let v25 = spiral_wrap_signed(v1 + v24, 32)
                                let v26 = kino_text_size(v0)
                                let v27 = v25 > v26
                                case v27 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v28 = v24 == 0
                                        case v28 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v29 = spiral_wrap_signed(v25 - 1, 32)
                                                let v30 = spiral_wrap_signed(v29 - v1, 32)
                                                let v31 = spiral_wrap_signed(v30 + 1, 32)
                                                let v32 = kino_text_at(v0, v1, v31)
                                                let v33 = v32 == "\\\""
                                                v33
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    case v36 {
                        True -> {
                            let v37 = spiral_wrap_signed(v1 + 2, 32)
                            let v38 = { v2 } <> { "\"" }
                            go_34(v0, v37, v38)
                        }
                        False -> {
                            let v40 = "\\n"
                            let v41 = kino_text_size(v40)
                            let v53 =
                                case v7 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v42 = spiral_wrap_signed(v1 + v41, 32)
                                        let v43 = kino_text_size(v0)
                                        let v44 = v42 > v43
                                        case v44 {
                                            True -> {
                                                False
                                            }
                                            False -> {
                                                let v45 = v41 == 0
                                                case v45 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v46 = spiral_wrap_signed(v42 - 1, 32)
                                                        let v47 = spiral_wrap_signed(v46 - v1, 32)
                                                        let v48 = spiral_wrap_signed(v47 + 1, 32)
                                                        let v49 = kino_text_at(v0, v1, v48)
                                                        let v50 = v49 == "\\n"
                                                        v50
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            case v53 {
                                True -> {
                                    let v54 = spiral_wrap_signed(v1 + 2, 32)
                                    let v55 = { v2 } <> { "\n" }
                                    go_34(v0, v54, v55)
                                }
                                False -> {
                                    let v57 = "\\r"
                                    let v58 = kino_text_size(v57)
                                    let v70 =
                                        case v7 {
                                            True -> {
                                                False
                                            }
                                            False -> {
                                                let v59 = spiral_wrap_signed(v1 + v58, 32)
                                                let v60 = kino_text_size(v0)
                                                let v61 = v59 > v60
                                                case v61 {
                                                    True -> {
                                                        False
                                                    }
                                                    False -> {
                                                        let v62 = v58 == 0
                                                        case v62 {
                                                            True -> {
                                                                True
                                                            }
                                                            False -> {
                                                                let v63 = spiral_wrap_signed(v59 - 1, 32)
                                                                let v64 = spiral_wrap_signed(v63 - v1, 32)
                                                                let v65 = spiral_wrap_signed(v64 + 1, 32)
                                                                let v66 = kino_text_at(v0, v1, v65)
                                                                let v67 = v66 == "\\r"
                                                                v67
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    case v70 {
                                        True -> {
                                            let v71 = spiral_wrap_signed(v1 + 2, 32)
                                            let v72 = { v2 } <> { "\r" }
                                            go_34(v0, v71, v72)
                                        }
                                        False -> {
                                            let v74 = "\\t"
                                            let v75 = kino_text_size(v74)
                                            let v87 =
                                                case v7 {
                                                    True -> {
                                                        False
                                                    }
                                                    False -> {
                                                        let v76 = spiral_wrap_signed(v1 + v75, 32)
                                                        let v77 = kino_text_size(v0)
                                                        let v78 = v76 > v77
                                                        case v78 {
                                                            True -> {
                                                                False
                                                            }
                                                            False -> {
                                                                let v79 = v75 == 0
                                                                case v79 {
                                                                    True -> {
                                                                        True
                                                                    }
                                                                    False -> {
                                                                        let v80 = spiral_wrap_signed(v76 - 1, 32)
                                                                        let v81 = spiral_wrap_signed(v80 - v1, 32)
                                                                        let v82 = spiral_wrap_signed(v81 + 1, 32)
                                                                        let v83 = kino_text_at(v0, v1, v82)
                                                                        let v84 = v83 == "\\t"
                                                                        v84
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            case v87 {
                                                True -> {
                                                    let v88 = spiral_wrap_signed(v1 + 2, 32)
                                                    let v89 = { v2 } <> { "\t" }
                                                    go_34(v0, v88, v89)
                                                }
                                                False -> {
                                                    let v91 = spiral_wrap_signed(v1 + 1, 32)
                                                    let v92 = kino_text_at(v0, v1, 1)
                                                    let v93 = { v2 } <> { v92 }
                                                    go_34(v0, v91, v93)
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
pub fn snippets_28(v0: Uh0, v1: Uh2) -> Uh2 {
    case v0  {
        Uh0Line(v2, v3) -> {
            let v4 = 0
            let v5 = trim_nl_start_29(v2, v4)
            let v6 = kino_text_size(v2)
            let v7 = trim_nl_end_30(v2, v6)
            let v8 = v7 <= v5
            let v14 =
                case v8 {
                    True -> {
                        let v9 = ""
                        v9
                    }
                    False -> {
                        let v10 = spiral_wrap_signed(v7 - 1, 32)
                        let v11 = spiral_wrap_signed(v10 - v5, 32)
                        let v12 = spiral_wrap_signed(v11 + 1, 32)
                        let v13 = kino_text_at(v2, v5, v12)
                        v13
                    }
                }
            let v15 = 0
            let v16 = skip_spaces_31(v14, v15)
            let v17 = "let mut v"
            let v18 = kino_text_size(v17)
            let v19 = v16 < 0
            let v31 =
                case v19 {
                    True -> {
                        False
                    }
                    False -> {
                        let v20 = spiral_wrap_signed(v16 + v18, 32)
                        let v21 = kino_text_size(v14)
                        let v22 = v20 > v21
                        case v22 {
                            True -> {
                                False
                            }
                            False -> {
                                let v23 = v18 == 0
                                case v23 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v24 = spiral_wrap_signed(v20 - 1, 32)
                                        let v25 = spiral_wrap_signed(v24 - v16, 32)
                                        let v26 = spiral_wrap_signed(v25 + 1, 32)
                                        let v27 = kino_text_at(v14, v16, v26)
                                        let v28 = v27 == "let mut v"
                                        v28
                                    }
                                }
                            }
                        }
                    }
                }
            let v32 = v31 == False
            let #(v165, v166) =
                case v32 {
                    True -> {
                        let v33 = ""
                        #(v33, v33)
                    }
                    False -> {
                        let v34 = "let mut "
                        let v35 = kino_text_size(v34)
                        let v36 = spiral_wrap_signed(v16 + v35, 32)
                        let v37 = "v"
                        let v38 = kino_text_size(v37)
                        let v39 = v36 < 0
                        let v51 =
                            case v39 {
                                True -> {
                                    False
                                }
                                False -> {
                                    let v40 = spiral_wrap_signed(v36 + v38, 32)
                                    let v41 = kino_text_size(v14)
                                    let v42 = v40 > v41
                                    case v42 {
                                        True -> {
                                            False
                                        }
                                        False -> {
                                            let v43 = v38 == 0
                                            case v43 {
                                                True -> {
                                                    True
                                                }
                                                False -> {
                                                    let v44 = spiral_wrap_signed(v40 - 1, 32)
                                                    let v45 = spiral_wrap_signed(v44 - v36, 32)
                                                    let v46 = spiral_wrap_signed(v45 + 1, 32)
                                                    let v47 = kino_text_at(v14, v36, v46)
                                                    let v48 = v47 == "v"
                                                    v48
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        let v56 =
                            case v51 {
                                True -> {
                                    let v52 = spiral_wrap_signed(v36 + 1, 32)
                                    let v53 = digits_end_32(v14, v52)
                                    let v54 = v53 > v52
                                    case v54 {
                                        True -> {
                                            v53
                                        }
                                        False -> {
                                            -1
                                        }
                                    }
                                }
                                False -> {
                                    -1
                                }
                            }
                        let v57 = v56 < 0
                        case v57 {
                            True -> {
                                let v58 = ""
                                #(v58, v58)
                            }
                            False -> {
                                let v59 = ": Rc<str> = "
                                let v60 = kino_text_size(v59)
                                let v61 = spiral_wrap_signed(v56 + v60, 32)
                                let v62 = kino_text_size(v14)
                                let v63 = v61 > v62
                                let v71 =
                                    case v63 {
                                        True -> {
                                            False
                                        }
                                        False -> {
                                            let v64 = v60 == 0
                                            case v64 {
                                                True -> {
                                                    True
                                                }
                                                False -> {
                                                    let v65 = spiral_wrap_signed(v61 - 1, 32)
                                                    let v66 = spiral_wrap_signed(v65 - v56, 32)
                                                    let v67 = spiral_wrap_signed(v66 + 1, 32)
                                                    let v68 = kino_text_at(v14, v56, v67)
                                                    let v69 = v68 == ": Rc<str> = "
                                                    v69
                                                }
                                            }
                                        }
                                    }
                                let v72 = v71 == False
                                case v72 {
                                    True -> {
                                        let v73 = ""
                                        #(v73, v73)
                                    }
                                    False -> {
                                        let v74 = kino_text_size(v59)
                                        let v75 = spiral_wrap_signed(v56 + v74, 32)
                                        let v76 = kino_text_size(v14)
                                        let v77 = v75 >= v76
                                        let v81 =
                                            case v77 {
                                                True -> {
                                                    True
                                                }
                                                False -> {
                                                    let v78 = kino_text_at(v14, v75, 1)
                                                    let v79 = v78 == "\""
                                                    let v80 = v79 != True
                                                    v80
                                                }
                                            }
                                        case v81 {
                                            True -> {
                                                let v82 = ""
                                                #(v82, v82)
                                            }
                                            False -> {
                                                let v83 = spiral_wrap_signed(v75 + 1, 32)
                                                let v84 = scan_33(v14, v83)
                                                let v85 = v84 < 0
                                                case v85 {
                                                    True -> {
                                                        let v86 = ""
                                                        #(v86, v86)
                                                    }
                                                    False -> {
                                                        let v87 = spiral_wrap_signed(v84 + 1, 32)
                                                        let v88 = ";"
                                                        let v89 = kino_text_size(v88)
                                                        let v90 = v87 < 0
                                                        let v102 =
                                                            case v90 {
                                                                True -> {
                                                                    False
                                                                }
                                                                False -> {
                                                                    let v91 = spiral_wrap_signed(v87 + v89, 32)
                                                                    let v92 = kino_text_size(v14)
                                                                    let v93 = v91 > v92
                                                                    case v93 {
                                                                        True -> {
                                                                            False
                                                                        }
                                                                        False -> {
                                                                            let v94 = v89 == 0
                                                                            case v94 {
                                                                                True -> {
                                                                                    True
                                                                                }
                                                                                False -> {
                                                                                    let v95 = spiral_wrap_signed(v91 - 1, 32)
                                                                                    let v96 = spiral_wrap_signed(v95 - v87, 32)
                                                                                    let v97 = spiral_wrap_signed(v96 + 1, 32)
                                                                                    let v98 = kino_text_at(v14, v87, v97)
                                                                                    let v99 = v98 == ";"
                                                                                    v99
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        let v103 = v102 == False
                                                        case v103 {
                                                            True -> {
                                                                let v104 = ""
                                                                #(v104, v104)
                                                            }
                                                            False -> {
                                                                let v105 = spiral_wrap_signed(v84 + 2, 32)
                                                                let v106 = skip_spaces_31(v14, v105)
                                                                let v107 = kino_text_size(v14)
                                                                let v108 = v106 == v107
                                                                case v108 {
                                                                    True -> {
                                                                        let v109 = spiral_wrap_signed(v56 - v36, 32)
                                                                        let v110 = v109 <= 0
                                                                        let v129 =
                                                                            case v110 {
                                                                                True -> {
                                                                                    let v111 = ""
                                                                                    v111
                                                                                }
                                                                                False -> {
                                                                                    let v112 = kino_text_size(v14)
                                                                                    let v113 = v36 >= v112
                                                                                    case v113 {
                                                                                        True -> {
                                                                                            let v114 = ""
                                                                                            v114
                                                                                        }
                                                                                        False -> {
                                                                                            let v115 = spiral_wrap_signed(v36 + v109, 32)
                                                                                            let v116 = spiral_wrap_signed(v115 - 1, 32)
                                                                                            let v117 = kino_text_size(v14)
                                                                                            let v118 = v116 >= v117
                                                                                            let v121 =
                                                                                                case v118 {
                                                                                                    True -> {
                                                                                                        let v119 = kino_text_size(v14)
                                                                                                        let v120 = spiral_wrap_signed(v119 - 1, 32)
                                                                                                        v120
                                                                                                    }
                                                                                                    False -> {
                                                                                                        v116
                                                                                                    }
                                                                                                }
                                                                                            let v122 = v121 < v36
                                                                                            case v122 {
                                                                                                True -> {
                                                                                                    let v123 = ""
                                                                                                    v123
                                                                                                }
                                                                                                False -> {
                                                                                                    let v124 = spiral_wrap_signed(v121 - v36, 32)
                                                                                                    let v125 = spiral_wrap_signed(v124 + 1, 32)
                                                                                                    let v126 = kino_text_at(v14, v36, v125)
                                                                                                    v126
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        let v130 = spiral_wrap_signed(v84 - v75, 32)
                                                                        let v131 = spiral_wrap_signed(v130 + 1, 32)
                                                                        let v132 = v131 <= 0
                                                                        let v151 =
                                                                            case v132 {
                                                                                True -> {
                                                                                    let v133 = ""
                                                                                    v133
                                                                                }
                                                                                False -> {
                                                                                    let v134 = kino_text_size(v14)
                                                                                    let v135 = v75 >= v134
                                                                                    case v135 {
                                                                                        True -> {
                                                                                            let v136 = ""
                                                                                            v136
                                                                                        }
                                                                                        False -> {
                                                                                            let v137 = spiral_wrap_signed(v75 + v131, 32)
                                                                                            let v138 = spiral_wrap_signed(v137 - 1, 32)
                                                                                            let v139 = kino_text_size(v14)
                                                                                            let v140 = v138 >= v139
                                                                                            let v143 =
                                                                                                case v140 {
                                                                                                    True -> {
                                                                                                        let v141 = kino_text_size(v14)
                                                                                                        let v142 = spiral_wrap_signed(v141 - 1, 32)
                                                                                                        v142
                                                                                                    }
                                                                                                    False -> {
                                                                                                        v138
                                                                                                    }
                                                                                                }
                                                                                            let v144 = v143 < v75
                                                                                            case v144 {
                                                                                                True -> {
                                                                                                    let v145 = ""
                                                                                                    v145
                                                                                                }
                                                                                                False -> {
                                                                                                    let v146 = spiral_wrap_signed(v143 - v75, 32)
                                                                                                    let v147 = spiral_wrap_signed(v146 + 1, 32)
                                                                                                    let v148 = kino_text_at(v14, v75, v147)
                                                                                                    v148
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        #(v129, v151)
                                                                    }
                                                                    False -> {
                                                                        let v152 = ""
                                                                        #(v152, v152)
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
            let v167 = v165 == ""
            case v167 {
                True -> {
                    snippets_28(v3, v1)
                }
                False -> {
                    let v169 = kino_text_size(v166)
                    let v170 = spiral_wrap_signed(v169 - 1, 32)
                    let v171 = kino_text_size(v166)
                    let v172 = v170 < v171
                    let v173 =
                        case v172 {
                            True -> {
                                v170
                            }
                            False -> {
                                v171
                            }
                        }
                    let v174 = v173 <= 0
                    let v179 =
                        case v174 {
                            True -> {
                                let v175 = ""
                                v175
                            }
                            False -> {
                                let v176 = spiral_wrap_signed(v173 - 1, 32)
                                let v177 = spiral_wrap_signed(v176 + 1, 32)
                                let v178 = kino_text_at(v166, 0, v177)
                                v178
                            }
                        }
                    let v180 = kino_text_size(v179)
                    let v181 = 1 >= v180
                    let v187 =
                        case v181 {
                            True -> {
                                let v182 = ""
                                v182
                            }
                            False -> {
                                let v183 = spiral_wrap_signed(v180 - 1, 32)
                                let v184 = spiral_wrap_signed(v183 - 1, 32)
                                let v185 = spiral_wrap_signed(v184 + 1, 32)
                                let v186 = kino_text_at(v179, 1, v185)
                                v186
                            }
                        }
                    let v188 = 0
                    let v189 = ""
                    let v190 = go_34(v187, v188, v189)
                    let v191 = Uh2Pair(v165, v190, v1)
                    snippets_28(v3, v191)
                }
            }
        }
        Uh0NoLine -> {
            v1
        }
    }
}
pub fn last_var_36(v0: String, v1: Int, v2: Int) -> Int {
    let v3 = kino_text_size(v0)
    let v4 = v1 >= v3
    case v4 {
        True -> {
            v2
        }
        False -> {
            let v5 = "v"
            let v6 = kino_text_size(v5)
            let v7 = v1 < 0
            let v19 =
                case v7 {
                    True -> {
                        False
                    }
                    False -> {
                        let v8 = spiral_wrap_signed(v1 + v6, 32)
                        let v9 = kino_text_size(v0)
                        let v10 = v8 > v9
                        case v10 {
                            True -> {
                                False
                            }
                            False -> {
                                let v11 = v6 == 0
                                case v11 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v12 = spiral_wrap_signed(v8 - 1, 32)
                                        let v13 = spiral_wrap_signed(v12 - v1, 32)
                                        let v14 = spiral_wrap_signed(v13 + 1, 32)
                                        let v15 = kino_text_at(v0, v1, v14)
                                        let v16 = v15 == "v"
                                        v16
                                    }
                                }
                            }
                        }
                    }
                }
            let v24 =
                case v19 {
                    True -> {
                        let v20 = spiral_wrap_signed(v1 + 1, 32)
                        let v21 = digits_end_32(v0, v20)
                        let v22 = v21 > v20
                        case v22 {
                            True -> {
                                v21
                            }
                            False -> {
                                -1
                            }
                        }
                    }
                    False -> {
                        -1
                    }
                }
            let v25 = v24 > v1
            let v35 =
                case v25 {
                    True -> {
                        let v26 = v1 == 0
                        let v30 =
                            case v26 {
                                True -> {
                                    True
                                }
                                False -> {
                                    let v27 = spiral_wrap_signed(v1 - 1, 32)
                                    let v28 = kino_text_at(v0, v27, 1)
                                    let v29 = v28 == " "
                                    v29
                                }
                            }
                        case v30 {
                            True -> {
                                True
                            }
                            False -> {
                                let v31 = spiral_wrap_signed(v1 - 1, 32)
                                let v32 = kino_text_at(v0, v31, 1)
                                let v33 = v32 == "\t"
                                v33
                            }
                        }
                    }
                    False -> {
                        False
                    }
                }
            case v35 {
                True -> {
                    last_var_36(v0, v24, v1)
                }
                False -> {
                    let v37 = spiral_wrap_signed(v1 + 1, 32)
                    last_var_36(v0, v37, v2)
                }
            }
        }
    }
}
pub fn find_pair_37(v0: Uh2, v1: String) -> String {
    case v0  {
        Uh2NoPair -> {
            let v2 = ""
            v2
        }
        Uh2Pair(v3, v4, v5) -> {
            let v6 = v3 == v1
            case v6 {
                True -> {
                    v4
                }
                False -> {
                    find_pair_37(v5, v1)
                }
            }
        }
    }
}
pub fn split_depth_38(v0: String, v1: Int, v2: Int, v3: String, v4: Uh0) -> Uh0 {
    let v5 = kino_text_size(v0)
    let v6 = v1 >= v5
    case v6 {
        True -> {
            let v7 = 0
            let v8 = trim_start_17(v3, v7)
            let v9 = kino_text_size(v3)
            let v10 = trim_end_18(v3, v9)
            let v11 = v10 <= v8
            let v17 =
                case v11 {
                    True -> {
                        let v12 = ""
                        v12
                    }
                    False -> {
                        let v13 = spiral_wrap_signed(v10 - 1, 32)
                        let v14 = spiral_wrap_signed(v13 - v8, 32)
                        let v15 = spiral_wrap_signed(v14 + 1, 32)
                        let v16 = kino_text_at(v3, v8, v15)
                        v16
                    }
                }
            let v18 = Uh0Line(v17, v4)
            let v19 = Uh0NoLine
            rev_lines_5(v18, v19)
        }
        False -> {
            let v21 = kino_text_at(v0, v1, 1)
            let v22 = v21 == "("
            case v22 {
                True -> {
                    let v23 = spiral_wrap_signed(v1 + 1, 32)
                    let v24 = spiral_wrap_signed(v2 + 1, 32)
                    let v25 = { v3 } <> { "(" }
                    split_depth_38(v0, v23, v24, v25, v4)
                }
                False -> {
                    let v27 = v21 == ")"
                    case v27 {
                        True -> {
                            let v28 = spiral_wrap_signed(v1 + 1, 32)
                            let v29 = spiral_wrap_signed(v2 - 1, 32)
                            let v30 = { v3 } <> { ")" }
                            split_depth_38(v0, v28, v29, v30, v4)
                        }
                        False -> {
                            let v32 = v21 == ","
                            let v34 =
                                case v32 {
                                    True -> {
                                        let v33 = v2 == 0
                                        v33
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            case v34 {
                                True -> {
                                    let v35 = spiral_wrap_signed(v1 + 1, 32)
                                    let v36 = 0
                                    let v37 = ""
                                    let v38 = 0
                                    let v39 = trim_start_17(v3, v38)
                                    let v40 = kino_text_size(v3)
                                    let v41 = trim_end_18(v3, v40)
                                    let v42 = v41 <= v39
                                    let v47 =
                                        case v42 {
                                            True -> {
                                                v37
                                            }
                                            False -> {
                                                let v43 = spiral_wrap_signed(v41 - 1, 32)
                                                let v44 = spiral_wrap_signed(v43 - v39, 32)
                                                let v45 = spiral_wrap_signed(v44 + 1, 32)
                                                let v46 = kino_text_at(v3, v39, v45)
                                                v46
                                            }
                                        }
                                    let v48 = Uh0Line(v47, v4)
                                    split_depth_38(v0, v35, v36, v37, v48)
                                }
                                False -> {
                                    let v50 = spiral_wrap_signed(v1 + 1, 32)
                                    let v51 = kino_text_at(v0, v1, 1)
                                    let v52 = { v3 } <> { v51 }
                                    split_depth_38(v0, v50, v2, v52, v4)
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
pub fn subst_39(v0: String, v1: Uh0, v2: Int) -> String {
    case v1  {
        Uh0Line(v3, v4) -> {
            let v5 = show_i32_20(v2)
            let v6 = { "$" } <> { v5 }
            let v7 = 0
            let v8 = trim_start_17(v3, v7)
            let v9 = kino_text_size(v3)
            let v10 = trim_end_18(v3, v9)
            let v11 = v10 <= v8
            let v17 =
                case v11 {
                    True -> {
                        let v12 = ""
                        v12
                    }
                    False -> {
                        let v13 = spiral_wrap_signed(v10 - 1, 32)
                        let v14 = spiral_wrap_signed(v13 - v8, 32)
                        let v15 = spiral_wrap_signed(v14 + 1, 32)
                        let v16 = kino_text_at(v3, v8, v15)
                        v16
                    }
                }
            let v18 = "v"
            let v19 = kino_text_size(v18)
            let v20 = kino_text_size(v17)
            let v21 = v19 > v20
            let v28 =
                case v21 {
                    True -> {
                        False
                    }
                    False -> {
                        let v22 = v19 == 0
                        case v22 {
                            True -> {
                                True
                            }
                            False -> {
                                let v23 = spiral_wrap_signed(v19 - 1, 32)
                                let v24 = spiral_wrap_signed(v23 + 1, 32)
                                let v25 = kino_text_at(v17, 0, v24)
                                let v26 = v25 == "v"
                                v26
                            }
                        }
                    }
                }
            let v33 =
                case v28 {
                    True -> {
                        let v29 = ".clone()"
                        let v30 = 0
                        let v31 = find_from_1(v17, v29, v30)
                        let v32 = v31 >= 0
                        v32
                    }
                    False -> {
                        False
                    }
                }
            let v72 =
                case v33 {
                    True -> {
                        let v34 = kino_text_size(v18)
                        let v35 = kino_text_size(v17)
                        let v36 = v34 > v35
                        let v43 =
                            case v36 {
                                True -> {
                                    False
                                }
                                False -> {
                                    let v37 = v34 == 0
                                    case v37 {
                                        True -> {
                                            True
                                        }
                                        False -> {
                                            let v38 = spiral_wrap_signed(v34 - 1, 32)
                                            let v39 = spiral_wrap_signed(v38 + 1, 32)
                                            let v40 = kino_text_at(v17, 0, v39)
                                            let v41 = v40 == "v"
                                            v41
                                        }
                                    }
                                }
                            }
                        let v48 =
                            case v43 {
                                True -> {
                                    let v44 = 1
                                    let v45 = digits_end_32(v17, v44)
                                    let v46 = v45 > 1
                                    case v46 {
                                        True -> {
                                            v45
                                        }
                                        False -> {
                                            -1
                                        }
                                    }
                                }
                                False -> {
                                    -1
                                }
                            }
                        let v49 = v48 > 0
                        let v61 =
                            case v49 {
                                True -> {
                                    let v50 = kino_text_size(v17)
                                    let v51 = v48 >= v50
                                    let v59 =
                                        case v51 {
                                            True -> {
                                                let v52 = ""
                                                v52
                                            }
                                            False -> {
                                                let v53 = v48 <= 0
                                                case v53 {
                                                    True -> {
                                                        v17
                                                    }
                                                    False -> {
                                                        let v54 = spiral_wrap_signed(v50 - 1, 32)
                                                        let v55 = spiral_wrap_signed(v54 - v48, 32)
                                                        let v56 = spiral_wrap_signed(v55 + 1, 32)
                                                        let v57 = kino_text_at(v17, v48, v56)
                                                        v57
                                                    }
                                                }
                                            }
                                        }
                                    let v60 = v59 == ".clone()"
                                    v60
                                }
                                False -> {
                                    False
                                }
                            }
                        case v61 {
                            True -> {
                                let v62 = kino_text_size(v17)
                                let v63 = v48 < v62
                                let v64 =
                                    case v63 {
                                        True -> {
                                            v48
                                        }
                                        False -> {
                                            v62
                                        }
                                    }
                                let v65 = v64 <= 0
                                case v65 {
                                    True -> {
                                        let v66 = ""
                                        v66
                                    }
                                    False -> {
                                        let v67 = spiral_wrap_signed(v64 - 1, 32)
                                        let v68 = spiral_wrap_signed(v67 + 1, 32)
                                        let v69 = kino_text_at(v17, 0, v68)
                                        v69
                                    }
                                }
                            }
                            False -> {
                                v17
                            }
                        }
                    }
                    False -> {
                        v17
                    }
                }
            let v73 = v6 == ""
            let v77 =
                case v73 {
                    True -> {
                        v0
                    }
                    False -> {
                        let v74 = 0
                        let v75 = ""
                        replace_from_0(v0, v6, v72, v74, v75)
                    }
                }
            let v78 = spiral_wrap_signed(v2 + 1, 32)
            subst_39(v77, v4, v78)
        }
        Uh0NoLine -> {
            v0
        }
    }
}
pub fn rewrite_lines_35(v0: Uh0, v1: Uh2) -> Uh0 {
    case v0  {
        Uh0Line(v3, v4) -> {
            let v5 = 0
            let v6 = trim_nl_start_29(v3, v5)
            let v7 = kino_text_size(v3)
            let v8 = trim_nl_end_30(v3, v7)
            let v9 = v8 <= v6
            let v15 =
                case v9 {
                    True -> {
                        let v10 = ""
                        v10
                    }
                    False -> {
                        let v11 = spiral_wrap_signed(v8 - 1, 32)
                        let v12 = spiral_wrap_signed(v11 - v6, 32)
                        let v13 = spiral_wrap_signed(v12 + 1, 32)
                        let v14 = kino_text_at(v3, v6, v13)
                        v14
                    }
                }
            let v16 = 0
            let v17 = skip_spaces_31(v15, v16)
            let v18 = "let mut v"
            let v19 = kino_text_size(v18)
            let v20 = v17 < 0
            let v32 =
                case v20 {
                    True -> {
                        False
                    }
                    False -> {
                        let v21 = spiral_wrap_signed(v17 + v19, 32)
                        let v22 = kino_text_size(v15)
                        let v23 = v21 > v22
                        case v23 {
                            True -> {
                                False
                            }
                            False -> {
                                let v24 = v19 == 0
                                case v24 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v25 = spiral_wrap_signed(v21 - 1, 32)
                                        let v26 = spiral_wrap_signed(v25 - v17, 32)
                                        let v27 = spiral_wrap_signed(v26 + 1, 32)
                                        let v28 = kino_text_at(v15, v17, v27)
                                        let v29 = v28 == "let mut v"
                                        v29
                                    }
                                }
                            }
                        }
                    }
                }
            let v33 = v32 == False
            let #(v166, _v167) =
                case v33 {
                    True -> {
                        let v34 = ""
                        #(v34, v34)
                    }
                    False -> {
                        let v35 = "let mut "
                        let v36 = kino_text_size(v35)
                        let v37 = spiral_wrap_signed(v17 + v36, 32)
                        let v38 = "v"
                        let v39 = kino_text_size(v38)
                        let v40 = v37 < 0
                        let v52 =
                            case v40 {
                                True -> {
                                    False
                                }
                                False -> {
                                    let v41 = spiral_wrap_signed(v37 + v39, 32)
                                    let v42 = kino_text_size(v15)
                                    let v43 = v41 > v42
                                    case v43 {
                                        True -> {
                                            False
                                        }
                                        False -> {
                                            let v44 = v39 == 0
                                            case v44 {
                                                True -> {
                                                    True
                                                }
                                                False -> {
                                                    let v45 = spiral_wrap_signed(v41 - 1, 32)
                                                    let v46 = spiral_wrap_signed(v45 - v37, 32)
                                                    let v47 = spiral_wrap_signed(v46 + 1, 32)
                                                    let v48 = kino_text_at(v15, v37, v47)
                                                    let v49 = v48 == "v"
                                                    v49
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        let v57 =
                            case v52 {
                                True -> {
                                    let v53 = spiral_wrap_signed(v37 + 1, 32)
                                    let v54 = digits_end_32(v15, v53)
                                    let v55 = v54 > v53
                                    case v55 {
                                        True -> {
                                            v54
                                        }
                                        False -> {
                                            -1
                                        }
                                    }
                                }
                                False -> {
                                    -1
                                }
                            }
                        let v58 = v57 < 0
                        case v58 {
                            True -> {
                                let v59 = ""
                                #(v59, v59)
                            }
                            False -> {
                                let v60 = ": Rc<str> = "
                                let v61 = kino_text_size(v60)
                                let v62 = spiral_wrap_signed(v57 + v61, 32)
                                let v63 = kino_text_size(v15)
                                let v64 = v62 > v63
                                let v72 =
                                    case v64 {
                                        True -> {
                                            False
                                        }
                                        False -> {
                                            let v65 = v61 == 0
                                            case v65 {
                                                True -> {
                                                    True
                                                }
                                                False -> {
                                                    let v66 = spiral_wrap_signed(v62 - 1, 32)
                                                    let v67 = spiral_wrap_signed(v66 - v57, 32)
                                                    let v68 = spiral_wrap_signed(v67 + 1, 32)
                                                    let v69 = kino_text_at(v15, v57, v68)
                                                    let v70 = v69 == ": Rc<str> = "
                                                    v70
                                                }
                                            }
                                        }
                                    }
                                let v73 = v72 == False
                                case v73 {
                                    True -> {
                                        let v74 = ""
                                        #(v74, v74)
                                    }
                                    False -> {
                                        let v75 = kino_text_size(v60)
                                        let v76 = spiral_wrap_signed(v57 + v75, 32)
                                        let v77 = kino_text_size(v15)
                                        let v78 = v76 >= v77
                                        let v82 =
                                            case v78 {
                                                True -> {
                                                    True
                                                }
                                                False -> {
                                                    let v79 = kino_text_at(v15, v76, 1)
                                                    let v80 = v79 == "\""
                                                    let v81 = v80 != True
                                                    v81
                                                }
                                            }
                                        case v82 {
                                            True -> {
                                                let v83 = ""
                                                #(v83, v83)
                                            }
                                            False -> {
                                                let v84 = spiral_wrap_signed(v76 + 1, 32)
                                                let v85 = scan_33(v15, v84)
                                                let v86 = v85 < 0
                                                case v86 {
                                                    True -> {
                                                        let v87 = ""
                                                        #(v87, v87)
                                                    }
                                                    False -> {
                                                        let v88 = spiral_wrap_signed(v85 + 1, 32)
                                                        let v89 = ";"
                                                        let v90 = kino_text_size(v89)
                                                        let v91 = v88 < 0
                                                        let v103 =
                                                            case v91 {
                                                                True -> {
                                                                    False
                                                                }
                                                                False -> {
                                                                    let v92 = spiral_wrap_signed(v88 + v90, 32)
                                                                    let v93 = kino_text_size(v15)
                                                                    let v94 = v92 > v93
                                                                    case v94 {
                                                                        True -> {
                                                                            False
                                                                        }
                                                                        False -> {
                                                                            let v95 = v90 == 0
                                                                            case v95 {
                                                                                True -> {
                                                                                    True
                                                                                }
                                                                                False -> {
                                                                                    let v96 = spiral_wrap_signed(v92 - 1, 32)
                                                                                    let v97 = spiral_wrap_signed(v96 - v88, 32)
                                                                                    let v98 = spiral_wrap_signed(v97 + 1, 32)
                                                                                    let v99 = kino_text_at(v15, v88, v98)
                                                                                    let v100 = v99 == ";"
                                                                                    v100
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        let v104 = v103 == False
                                                        case v104 {
                                                            True -> {
                                                                let v105 = ""
                                                                #(v105, v105)
                                                            }
                                                            False -> {
                                                                let v106 = spiral_wrap_signed(v85 + 2, 32)
                                                                let v107 = skip_spaces_31(v15, v106)
                                                                let v108 = kino_text_size(v15)
                                                                let v109 = v107 == v108
                                                                case v109 {
                                                                    True -> {
                                                                        let v110 = spiral_wrap_signed(v57 - v37, 32)
                                                                        let v111 = v110 <= 0
                                                                        let v130 =
                                                                            case v111 {
                                                                                True -> {
                                                                                    let v112 = ""
                                                                                    v112
                                                                                }
                                                                                False -> {
                                                                                    let v113 = kino_text_size(v15)
                                                                                    let v114 = v37 >= v113
                                                                                    case v114 {
                                                                                        True -> {
                                                                                            let v115 = ""
                                                                                            v115
                                                                                        }
                                                                                        False -> {
                                                                                            let v116 = spiral_wrap_signed(v37 + v110, 32)
                                                                                            let v117 = spiral_wrap_signed(v116 - 1, 32)
                                                                                            let v118 = kino_text_size(v15)
                                                                                            let v119 = v117 >= v118
                                                                                            let v122 =
                                                                                                case v119 {
                                                                                                    True -> {
                                                                                                        let v120 = kino_text_size(v15)
                                                                                                        let v121 = spiral_wrap_signed(v120 - 1, 32)
                                                                                                        v121
                                                                                                    }
                                                                                                    False -> {
                                                                                                        v117
                                                                                                    }
                                                                                                }
                                                                                            let v123 = v122 < v37
                                                                                            case v123 {
                                                                                                True -> {
                                                                                                    let v124 = ""
                                                                                                    v124
                                                                                                }
                                                                                                False -> {
                                                                                                    let v125 = spiral_wrap_signed(v122 - v37, 32)
                                                                                                    let v126 = spiral_wrap_signed(v125 + 1, 32)
                                                                                                    let v127 = kino_text_at(v15, v37, v126)
                                                                                                    v127
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        let v131 = spiral_wrap_signed(v85 - v76, 32)
                                                                        let v132 = spiral_wrap_signed(v131 + 1, 32)
                                                                        let v133 = v132 <= 0
                                                                        let v152 =
                                                                            case v133 {
                                                                                True -> {
                                                                                    let v134 = ""
                                                                                    v134
                                                                                }
                                                                                False -> {
                                                                                    let v135 = kino_text_size(v15)
                                                                                    let v136 = v76 >= v135
                                                                                    case v136 {
                                                                                        True -> {
                                                                                            let v137 = ""
                                                                                            v137
                                                                                        }
                                                                                        False -> {
                                                                                            let v138 = spiral_wrap_signed(v76 + v132, 32)
                                                                                            let v139 = spiral_wrap_signed(v138 - 1, 32)
                                                                                            let v140 = kino_text_size(v15)
                                                                                            let v141 = v139 >= v140
                                                                                            let v144 =
                                                                                                case v141 {
                                                                                                    True -> {
                                                                                                        let v142 = kino_text_size(v15)
                                                                                                        let v143 = spiral_wrap_signed(v142 - 1, 32)
                                                                                                        v143
                                                                                                    }
                                                                                                    False -> {
                                                                                                        v139
                                                                                                    }
                                                                                                }
                                                                                            let v145 = v144 < v76
                                                                                            case v145 {
                                                                                                True -> {
                                                                                                    let v146 = ""
                                                                                                    v146
                                                                                                }
                                                                                                False -> {
                                                                                                    let v147 = spiral_wrap_signed(v144 - v76, 32)
                                                                                                    let v148 = spiral_wrap_signed(v147 + 1, 32)
                                                                                                    let v149 = kino_text_at(v15, v76, v148)
                                                                                                    v149
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        #(v130, v152)
                                                                    }
                                                                    False -> {
                                                                        let v153 = ""
                                                                        #(v153, v153)
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
            let v168 = "__spiral_emit_rust"
            let v169 = 0
            let v170 = find_from_1(v3, v168, v169)
            let v171 = v170 >= 0
            let v173 =
                case v171 {
                    True -> {
                        v168
                    }
                    False -> {
                        let v172 = "Fable.Core.RustInterop.emitRustExpr"
                        v172
                    }
                }
            let v176 =
                case v171 {
                    True -> {
                        v170
                    }
                    False -> {
                        let v174 = 0
                        find_from_1(v3, v173, v174)
                    }
                }
            let v177 = v176 < 0
            let #(v360, v361, v362) =
                case v177 {
                    True -> {
                        let v178 = ""
                        #(v178, v178, v178)
                    }
                    False -> {
                        let v179 = kino_text_size(v3)
                        let v180 = v176 < v179
                        let v181 =
                            case v180 {
                                True -> {
                                    v176
                                }
                                False -> {
                                    v179
                                }
                            }
                        let v182 = v181 <= 0
                        let v187 =
                            case v182 {
                                True -> {
                                    let v183 = ""
                                    v183
                                }
                                False -> {
                                    let v184 = spiral_wrap_signed(v181 - 1, 32)
                                    let v185 = spiral_wrap_signed(v184 + 1, 32)
                                    let v186 = kino_text_at(v3, 0, v185)
                                    v186
                                }
                            }
                        let v188 = kino_text_size(v173)
                        let v189 = spiral_wrap_signed(v176 + v188, 32)
                        let v190 = kino_text_size(v3)
                        let v191 = v189 >= v190
                        let v199 =
                            case v191 {
                                True -> {
                                    let v192 = ""
                                    v192
                                }
                                False -> {
                                    let v193 = v189 <= 0
                                    case v193 {
                                        True -> {
                                            v3
                                        }
                                        False -> {
                                            let v194 = spiral_wrap_signed(v190 - 1, 32)
                                            let v195 = spiral_wrap_signed(v194 - v189, 32)
                                            let v196 = spiral_wrap_signed(v195 + 1, 32)
                                            let v197 = kino_text_at(v3, v189, v196)
                                            v197
                                        }
                                    }
                                }
                            }
                        let v200 = 0
                        let v201 = trim_start_17(v199, v200)
                        let v202 = kino_text_size(v199)
                        let v203 = trim_end_18(v199, v202)
                        let v204 = v203 <= v201
                        let v210 =
                            case v204 {
                                True -> {
                                    let v205 = ""
                                    v205
                                }
                                False -> {
                                    let v206 = spiral_wrap_signed(v203 - 1, 32)
                                    let v207 = spiral_wrap_signed(v206 - v201, 32)
                                    let v208 = spiral_wrap_signed(v207 + 1, 32)
                                    let v209 = kino_text_at(v199, v201, v208)
                                    v209
                                }
                            }
                        let v211 = ";"
                        let v212 = 0
                        let v213 = find_from_1(v210, v211, v212)
                        let v214 = v213 < 0
                        case v214 {
                            True -> {
                                let v215 = ""
                                #(v215, v215, v215)
                            }
                            False -> {
                                let v216 = kino_text_size(v210)
                                let v217 = v213 < v216
                                let v218 =
                                    case v217 {
                                        True -> {
                                            v213
                                        }
                                        False -> {
                                            v216
                                        }
                                    }
                                let v219 = v218 <= 0
                                let v224 =
                                    case v219 {
                                        True -> {
                                            let v220 = ""
                                            v220
                                        }
                                        False -> {
                                            let v221 = spiral_wrap_signed(v218 - 1, 32)
                                            let v222 = spiral_wrap_signed(v221 + 1, 32)
                                            let v223 = kino_text_at(v210, 0, v222)
                                            v223
                                        }
                                    }
                                let v225 = 0
                                let v226 = trim_start_17(v224, v225)
                                let v227 = kino_text_size(v224)
                                let v228 = trim_end_18(v224, v227)
                                let v229 = v228 <= v226
                                let v235 =
                                    case v229 {
                                        True -> {
                                            let v230 = ""
                                            v230
                                        }
                                        False -> {
                                            let v231 = spiral_wrap_signed(v228 - 1, 32)
                                            let v232 = spiral_wrap_signed(v231 - v226, 32)
                                            let v233 = spiral_wrap_signed(v232 + 1, 32)
                                            let v234 = kino_text_at(v224, v226, v233)
                                            v234
                                        }
                                    }
                                let v236 = 0
                                let v237 = -1
                                let v238 = last_var_36(v235, v236, v237)
                                let v239 = v238 < 0
                                case v239 {
                                    True -> {
                                        let v240 = ""
                                        #(v240, v240, v240)
                                    }
                                    False -> {
                                        let v241 = kino_text_size(v235)
                                        let v242 = spiral_wrap_signed(v241 - v238, 32)
                                        let v243 = v242 <= 0
                                        let v262 =
                                            case v243 {
                                                True -> {
                                                    let v244 = ""
                                                    v244
                                                }
                                                False -> {
                                                    let v245 = kino_text_size(v235)
                                                    let v246 = v238 >= v245
                                                    case v246 {
                                                        True -> {
                                                            let v247 = ""
                                                            v247
                                                        }
                                                        False -> {
                                                            let v248 = spiral_wrap_signed(v238 + v242, 32)
                                                            let v249 = spiral_wrap_signed(v248 - 1, 32)
                                                            let v250 = kino_text_size(v235)
                                                            let v251 = v249 >= v250
                                                            let v254 =
                                                                case v251 {
                                                                    True -> {
                                                                        let v252 = kino_text_size(v235)
                                                                        let v253 = spiral_wrap_signed(v252 - 1, 32)
                                                                        v253
                                                                    }
                                                                    False -> {
                                                                        v249
                                                                    }
                                                                }
                                                            let v255 = v254 < v238
                                                            case v255 {
                                                                True -> {
                                                                    let v256 = ""
                                                                    v256
                                                                }
                                                                False -> {
                                                                    let v257 = spiral_wrap_signed(v254 - v238, 32)
                                                                    let v258 = spiral_wrap_signed(v257 + 1, 32)
                                                                    let v259 = kino_text_at(v235, v238, v258)
                                                                    v259
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        let v263 = kino_text_size(v235)
                                        let v264 = v238 < v263
                                        let v265 =
                                            case v264 {
                                                True -> {
                                                    v238
                                                }
                                                False -> {
                                                    v263
                                                }
                                            }
                                        let v266 = v265 <= 0
                                        let v271 =
                                            case v266 {
                                                True -> {
                                                    let v267 = ""
                                                    v267
                                                }
                                                False -> {
                                                    let v268 = spiral_wrap_signed(v265 - 1, 32)
                                                    let v269 = spiral_wrap_signed(v268 + 1, 32)
                                                    let v270 = kino_text_at(v235, 0, v269)
                                                    v270
                                                }
                                            }
                                        let v272 = 0
                                        let v273 = trim_start_17(v271, v272)
                                        let v274 = kino_text_size(v271)
                                        let v275 = trim_end_18(v271, v274)
                                        let v276 = v275 <= v273
                                        let v282 =
                                            case v276 {
                                                True -> {
                                                    let v277 = ""
                                                    v277
                                                }
                                                False -> {
                                                    let v278 = spiral_wrap_signed(v275 - 1, 32)
                                                    let v279 = spiral_wrap_signed(v278 - v273, 32)
                                                    let v280 = spiral_wrap_signed(v279 + 1, 32)
                                                    let v281 = kino_text_at(v271, v273, v280)
                                                    v281
                                                }
                                            }
                                        let v283 = 0
                                        let v284 = trim_start_17(v187, v283)
                                        let v285 = kino_text_size(v187)
                                        let v286 = trim_end_18(v187, v285)
                                        let v287 = v286 <= v284
                                        let v293 =
                                            case v287 {
                                                True -> {
                                                    let v288 = ""
                                                    v288
                                                }
                                                False -> {
                                                    let v289 = spiral_wrap_signed(v286 - 1, 32)
                                                    let v290 = spiral_wrap_signed(v289 - v284, 32)
                                                    let v291 = spiral_wrap_signed(v290 + 1, 32)
                                                    let v292 = kino_text_at(v187, v284, v291)
                                                    v292
                                                }
                                            }
                                        let v294 = v293 == ""
                                        case v294 {
                                            True -> {
                                                let v295 = 0
                                                let v296 = skip_spaces_31(v3, v295)
                                                let v297 = kino_text_size(v3)
                                                let v298 = v296 < v297
                                                let v299 =
                                                    case v298 {
                                                        True -> {
                                                            v296
                                                        }
                                                        False -> {
                                                            v297
                                                        }
                                                    }
                                                let v300 = v299 <= 0
                                                let v305 =
                                                    case v300 {
                                                        True -> {
                                                            let v301 = ""
                                                            v301
                                                        }
                                                        False -> {
                                                            let v302 = spiral_wrap_signed(v299 - 1, 32)
                                                            let v303 = spiral_wrap_signed(v302 + 1, 32)
                                                            let v304 = kino_text_at(v3, 0, v303)
                                                            v304
                                                        }
                                                    }
                                                #(v305, v282, v262)
                                            }
                                            False -> {
                                                let v306 = 0
                                                let v307 = trim_start_17(v187, v306)
                                                let v308 = kino_text_size(v187)
                                                let v309 = trim_end_18(v187, v308)
                                                let v310 = v309 <= v307
                                                let v316 =
                                                    case v310 {
                                                        True -> {
                                                            let v311 = ""
                                                            v311
                                                        }
                                                        False -> {
                                                            let v312 = spiral_wrap_signed(v309 - 1, 32)
                                                            let v313 = spiral_wrap_signed(v312 - v307, 32)
                                                            let v314 = spiral_wrap_signed(v313 + 1, 32)
                                                            let v315 = kino_text_at(v187, v307, v314)
                                                            v315
                                                        }
                                                    }
                                                let v317 = kino_text_size(v316)
                                                let v318 = v317 == 0
                                                let v323 =
                                                    case v318 {
                                                        True -> {
                                                            False
                                                        }
                                                        False -> {
                                                            let v319 = kino_text_size(v316)
                                                            let v320 = spiral_wrap_signed(v319 - 1, 32)
                                                            let v321 = kino_text_at(v316, v320, 1)
                                                            let v322 = v321 == "="
                                                            v322
                                                        }
                                                    }
                                                let v346 =
                                                    case v323 {
                                                        True -> {
                                                            let v324 = 0
                                                            let v325 = trim_start_17(v187, v324)
                                                            let v326 = kino_text_size(v187)
                                                            let v327 = trim_end_18(v187, v326)
                                                            let v328 = v327 <= v325
                                                            let v334 =
                                                                case v328 {
                                                                    True -> {
                                                                        let v329 = ""
                                                                        v329
                                                                    }
                                                                    False -> {
                                                                        let v330 = spiral_wrap_signed(v327 - 1, 32)
                                                                        let v331 = spiral_wrap_signed(v330 - v325, 32)
                                                                        let v332 = spiral_wrap_signed(v331 + 1, 32)
                                                                        let v333 = kino_text_at(v187, v325, v332)
                                                                        v333
                                                                    }
                                                                }
                                                            let v335 = "let "
                                                            let v336 = kino_text_size(v335)
                                                            let v337 = kino_text_size(v334)
                                                            let v338 = v336 > v337
                                                            case v338 {
                                                                True -> {
                                                                    False
                                                                }
                                                                False -> {
                                                                    let v339 = v336 == 0
                                                                    case v339 {
                                                                        True -> {
                                                                            True
                                                                        }
                                                                        False -> {
                                                                            let v340 = spiral_wrap_signed(v336 - 1, 32)
                                                                            let v341 = spiral_wrap_signed(v340 + 1, 32)
                                                                            let v342 = kino_text_at(v334, 0, v341)
                                                                            let v343 = v342 == "let "
                                                                            v343
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        False -> {
                                                            False
                                                        }
                                                    }
                                                case v346 {
                                                    True -> {
                                                        #(v187, v282, v262)
                                                    }
                                                    False -> {
                                                        let v347 = ""
                                                        #(v347, v347, v347)
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
            let v363 = v166 == ""
            let v364 = v363 != True
            let v447 =
                case v364 {
                    True -> {
                        let v365 = ""
                        v365
                    }
                    False -> {
                        let v366 = v360 == ""
                        let v367 = v366 != True
                        let v370 =
                            case v367 {
                                True -> {
                                    True
                                }
                                False -> {
                                    let v368 = v362 == ""
                                    let v369 = v368 != True
                                    v369
                                }
                            }
                        case v370 {
                            True -> {
                                let v371 = find_pair_37(v1, v362)
                                let v372 = v371 == ""
                                case v372 {
                                    True -> {
                                        let v373 = { v360 } <> { "__spiral_emit_rust " }
                                        let v374 = { v373 } <> { v361 }
                                        let v375 = { v374 } <> { " " }
                                        let v376 = { v375 } <> { v362 }
                                        let v377 = { v376 } <> { " ;" }
                                        v377
                                    }
                                    False -> {
                                        let v378 = 0
                                        let v379 = trim_start_17(v361, v378)
                                        let v380 = kino_text_size(v361)
                                        let v381 = trim_end_18(v361, v380)
                                        let v382 = v381 <= v379
                                        let v388 =
                                            case v382 {
                                                True -> {
                                                    let v383 = ""
                                                    v383
                                                }
                                                False -> {
                                                    let v384 = spiral_wrap_signed(v381 - 1, 32)
                                                    let v385 = spiral_wrap_signed(v384 - v379, 32)
                                                    let v386 = spiral_wrap_signed(v385 + 1, 32)
                                                    let v387 = kino_text_at(v361, v379, v386)
                                                    v387
                                                }
                                            }
                                        let v389 = v388 == "()"
                                        let v440 =
                                            case v389 {
                                                True -> {
                                                    Uh0NoLine
                                                }
                                                False -> {
                                                    let v391 = "("
                                                    let v392 = kino_text_size(v391)
                                                    let v393 = kino_text_size(v388)
                                                    let v394 = v392 > v393
                                                    let v401 =
                                                        case v394 {
                                                            True -> {
                                                                False
                                                            }
                                                            False -> {
                                                                let v395 = v392 == 0
                                                                case v395 {
                                                                    True -> {
                                                                        True
                                                                    }
                                                                    False -> {
                                                                        let v396 = spiral_wrap_signed(v392 - 1, 32)
                                                                        let v397 = spiral_wrap_signed(v396 + 1, 32)
                                                                        let v398 = kino_text_at(v388, 0, v397)
                                                                        let v399 = v398 == "("
                                                                        v399
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    let v406 =
                                                        case v401 {
                                                            True -> {
                                                                let v402 = kino_text_size(v388)
                                                                let v403 = spiral_wrap_signed(v402 - 1, 32)
                                                                let v404 = kino_text_at(v388, v403, 1)
                                                                let v405 = v404 == ")"
                                                                v405
                                                            }
                                                            False -> {
                                                                False
                                                            }
                                                        }
                                                    case v406 {
                                                        True -> {
                                                            let v407 = kino_text_size(v388)
                                                            let v408 = spiral_wrap_signed(v407 - 2, 32)
                                                            let v409 = v408 <= 0
                                                            let v428 =
                                                                case v409 {
                                                                    True -> {
                                                                        let v410 = ""
                                                                        v410
                                                                    }
                                                                    False -> {
                                                                        let v411 = kino_text_size(v388)
                                                                        let v412 = 1 >= v411
                                                                        case v412 {
                                                                            True -> {
                                                                                let v413 = ""
                                                                                v413
                                                                            }
                                                                            False -> {
                                                                                let v414 = spiral_wrap_signed(1 + v408, 32)
                                                                                let v415 = spiral_wrap_signed(v414 - 1, 32)
                                                                                let v416 = kino_text_size(v388)
                                                                                let v417 = v415 >= v416
                                                                                let v420 =
                                                                                    case v417 {
                                                                                        True -> {
                                                                                            let v418 = kino_text_size(v388)
                                                                                            let v419 = spiral_wrap_signed(v418 - 1, 32)
                                                                                            v419
                                                                                        }
                                                                                        False -> {
                                                                                            v415
                                                                                        }
                                                                                    }
                                                                                let v421 = v420 < 1
                                                                                case v421 {
                                                                                    True -> {
                                                                                        let v422 = ""
                                                                                        v422
                                                                                    }
                                                                                    False -> {
                                                                                        let v423 = spiral_wrap_signed(v420 - 1, 32)
                                                                                        let v424 = spiral_wrap_signed(v423 + 1, 32)
                                                                                        let v425 = kino_text_at(v388, 1, v424)
                                                                                        v425
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            let v429 = 0
                                                            let v430 = 0
                                                            let v431 = ""
                                                            let v432 = Uh0NoLine
                                                            split_depth_38(v428, v429, v430, v431, v432)
                                                        }
                                                        False -> {
                                                            let v434 = 0
                                                            let v435 = 0
                                                            let v436 = ""
                                                            let v437 = Uh0NoLine
                                                            split_depth_38(v388, v434, v435, v436, v437)
                                                        }
                                                    }
                                                }
                                            }
                                        let v441 = 0
                                        let v442 = subst_39(v371, v440, v441)
                                        let v443 = { v360 } <> { v442 }
                                        let v444 = { v443 } <> { ";" }
                                        v444
                                    }
                                }
                            }
                            False -> {
                                v3
                            }
                        }
                    }
                }
            let v448 = rewrite_lines_35(v4, v1)
            Uh0Line(v447, v448)
        }
        Uh0NoLine -> {
            Uh0NoLine
        }
    }
}
pub fn newlines_41(v0: Int) -> String {
    let v1 = v0 <= 0
    case v1 {
        True -> {
            let v2 = ""
            v2
        }
        False -> {
            let v3 = spiral_wrap_signed(v0 - 1, 32)
            let v4 = newlines_41(v3)
            let v5 = { "\n" } <> { v4 }
            v5
        }
    }
}
pub fn collapse_at_40(v0: String, v1: Int, v2: Int, v3: String) -> String {
    let v4 = kino_text_size(v0)
    let v5 = v1 >= v4
    case v5 {
        True -> {
            let v6 = v2 >= 3
            case v6 {
                True -> {
                    let v7 = { v3 } <> { "\n\n" }
                    v7
                }
                False -> {
                    let v8 = newlines_41(v2)
                    let v9 = { v3 } <> { v8 }
                    v9
                }
            }
        }
        False -> {
            let v11 = kino_text_at(v0, v1, 1)
            let v12 = v11 == "\n"
            case v12 {
                True -> {
                    let v13 = spiral_wrap_signed(v1 + 1, 32)
                    let v14 = spiral_wrap_signed(v2 + 1, 32)
                    collapse_at_40(v0, v13, v14, v3)
                }
                False -> {
                    let v16 = v2 >= 3
                    let v20 =
                        case v16 {
                            True -> {
                                let v17 = { v3 } <> { "\n\n" }
                                v17
                            }
                            False -> {
                                let v18 = newlines_41(v2)
                                let v19 = { v3 } <> { v18 }
                                v19
                            }
                        }
                    let v21 = "\n"
                    let v22 = find_char_3(v0, v1, v21)
                    let v23 = v22 < 0
                    let v25 =
                        case v23 {
                            True -> {
                                let v24 = kino_text_size(v0)
                                v24
                            }
                            False -> {
                                v22
                            }
                        }
                    let v26 = 0
                    let v27 = spiral_wrap_signed(v25 - 1, 32)
                    let v28 = spiral_wrap_signed(v27 - v1, 32)
                    let v29 = spiral_wrap_signed(v28 + 1, 32)
                    let v30 = kino_text_at(v0, v1, v29)
                    let v31 = { v20 } <> { v30 }
                    collapse_at_40(v0, v25, v26, v31)
                }
            }
        }
    }
}
pub fn closure1(capt: Nil) -> fn(#(String, String)) -> String {
    fn (dom) {
        let #(v0, v1) = dom
        let v2 = "\r\n"
        let v3 = "\n"
        let v4 = 0
        let v5 = ""
        let v6 = replace_from_0(v0, v2, v3, v4, v5)
        let v7 = 0
        let v8 = Uh0NoLine
        let v9 = collect_4(v6, v7, v8)
        let v10 = Uh2NoPair
        let v11 = snippets_28(v9, v10)
        let v12 = rewrite_lines_35(v9, v11)
        let v17 =
            case v12  {
                Uh0Line(v13, v14) -> {
                    join_from_19(v14, v13)
                }
                Uh0NoLine -> {
                    v5
                }
            }
        let v18 = 0
        let v19 = 0
        let v20 = collapse_at_40(v17, v18, v19, v5)
        let v21 = v1 == "1"
        case v21 {
            True -> {
                let v22 = "std::process::exit(main.join().unwrap());"
                let v23 = "let spiral_kino_value = main.join().unwrap();\n    println!(\"SPIRAL_KINO_VALUE:{}\", spiral_kino_value);\n    std::process::exit(0);"
                let v24 = 0
                let v25 = replace_from_0(v20, v22, v23, v24, v5)
                let v26 = "std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });"
                let v27 = "match main.join() {\n        Ok(spiral_kino_value) => { println!(\"SPIRAL_KINO_VALUE:{}\", spiral_kino_value); std::process::exit(0) }\n        Err(_) => std::process::exit(101),\n    }"
                let v28 = 0
                replace_from_0(v25, v26, v27, v28, v5)
            }
            False -> {
                let v30 = "std::process::exit(main.join().unwrap());"
                let v31 = "let _ = main.join().unwrap();\n    std::process::exit(0);"
                let v32 = 0
                let v33 = replace_from_0(v20, v30, v31, v32, v5)
                let v34 = "std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });"
                let v35 = "match main.join() {\n        Ok(_) => std::process::exit(0),\n        Err(_) => std::process::exit(101),\n    }"
                let v36 = 0
                replace_from_0(v33, v34, v35, v36, v5)
            }
        }
    }
}
pub fn find_42(v0: Uh0, v1: Uh0) -> String {
    case v0  {
        Uh0Line(v22, v23) -> {
            let v24 = "SPIRAL_KINO_VALUE:"
            let v25 = kino_text_size(v24)
            let v26 = kino_text_size(v22)
            let v27 = v25 > v26
            let v34 =
                case v27 {
                    True -> {
                        False
                    }
                    False -> {
                        let v28 = v25 == 0
                        case v28 {
                            True -> {
                                True
                            }
                            False -> {
                                let v29 = spiral_wrap_signed(v25 - 1, 32)
                                let v30 = spiral_wrap_signed(v29 + 1, 32)
                                let v31 = kino_text_at(v22, 0, v30)
                                let v32 = v31 == "SPIRAL_KINO_VALUE:"
                                v32
                            }
                        }
                    }
                }
            case v34 {
                True -> {
                    let v35 = kino_text_size(v24)
                    let v36 = kino_text_size(v22)
                    let v37 = v35 >= v36
                    let v45 =
                        case v37 {
                            True -> {
                                let v38 = ""
                                v38
                            }
                            False -> {
                                let v39 = v35 <= 0
                                case v39 {
                                    True -> {
                                        v22
                                    }
                                    False -> {
                                        let v40 = spiral_wrap_signed(v36 - 1, 32)
                                        let v41 = spiral_wrap_signed(v40 - v35, 32)
                                        let v42 = spiral_wrap_signed(v41 + 1, 32)
                                        let v43 = kino_text_at(v22, v35, v42)
                                        v43
                                    }
                                }
                            }
                        }
                    let v46 = kino_text_size(v45)
                    let v47 = v46 == 0
                    let v65 =
                        case v47 {
                            True -> {
                                let v48 = ""
                                v48
                            }
                            False -> {
                                let v49 = kino_text_size(v45)
                                let v50 = spiral_wrap_signed(v49 - 1, 32)
                                let v51 = kino_text_at(v45, v50, 1)
                                let v52 = v51 == "\r"
                                case v52 {
                                    True -> {
                                        let v53 = kino_text_size(v45)
                                        let v54 = spiral_wrap_signed(v53 - 1, 32)
                                        let v55 = kino_text_size(v45)
                                        let v56 = v54 < v55
                                        let v57 =
                                            case v56 {
                                                True -> {
                                                    v54
                                                }
                                                False -> {
                                                    v55
                                                }
                                            }
                                        let v58 = v57 <= 0
                                        case v58 {
                                            True -> {
                                                let v59 = ""
                                                v59
                                            }
                                            False -> {
                                                let v60 = spiral_wrap_signed(v57 - 1, 32)
                                                let v61 = spiral_wrap_signed(v60 + 1, 32)
                                                let v62 = kino_text_at(v45, 0, v61)
                                                v62
                                            }
                                        }
                                    }
                                    False -> {
                                        v45
                                    }
                                }
                            }
                        }
                    let v66 = Uh0NoLine
                    let v67 = rev_lines_5(v1, v66)
                    let v73 =
                        case v67  {
                            Uh0Line(v69, v70) -> {
                                join_from_19(v70, v69)
                            }
                            Uh0NoLine -> {
                                let v68 = ""
                                v68
                            }
                        }
                    let v79 =
                        case v23  {
                            Uh0Line(v75, v76) -> {
                                join_from_19(v76, v75)
                            }
                            Uh0NoLine -> {
                                let v74 = ""
                                v74
                            }
                        }
                    let v80 = v73 == ""
                    let v85 =
                        case v80 {
                            True -> {
                                v79
                            }
                            False -> {
                                let v81 = v79 == ""
                                case v81 {
                                    True -> {
                                        v73
                                    }
                                    False -> {
                                        let v82 = { v73 } <> { "\n" }
                                        let v83 = { v82 } <> { v79 }
                                        v83
                                    }
                                }
                            }
                        }
                    let v86 = kino_text_size(v85)
                    let v87 = trim_nl_end_30(v85, v86)
                    let v88 = v87 <= 0
                    let v96 =
                        case v88 {
                            True -> {
                                let v89 = ""
                                v89
                            }
                            False -> {
                                let v90 = kino_text_size(v85)
                                let v91 = v87 == v90
                                case v91 {
                                    True -> {
                                        v85
                                    }
                                    False -> {
                                        let v92 = spiral_wrap_signed(v87 - 1, 32)
                                        let v93 = spiral_wrap_signed(v92 + 1, 32)
                                        let v94 = kino_text_at(v85, 0, v93)
                                        v94
                                    }
                                }
                            }
                        }
                    let v97 = { "1\n" } <> { v65 }
                    let v98 = { v97 } <> { "\n" }
                    let v99 = { v98 } <> { v96 }
                    v99
                }
                False -> {
                    let v100 = Uh0Line(v22, v1)
                    find_42(v23, v100)
                }
            }
        }
        Uh0NoLine -> {
            let v2 = Uh0NoLine
            let v3 = rev_lines_5(v1, v2)
            let v9 =
                case v3  {
                    Uh0Line(v5, v6) -> {
                        join_from_19(v6, v5)
                    }
                    Uh0NoLine -> {
                        let v4 = ""
                        v4
                    }
                }
            let v10 = kino_text_size(v9)
            let v11 = trim_nl_end_30(v9, v10)
            let v12 = v11 <= 0
            let v20 =
                case v12 {
                    True -> {
                        let v13 = ""
                        v13
                    }
                    False -> {
                        let v14 = kino_text_size(v9)
                        let v15 = v11 == v14
                        case v15 {
                            True -> {
                                v9
                            }
                            False -> {
                                let v16 = spiral_wrap_signed(v11 - 1, 32)
                                let v17 = spiral_wrap_signed(v16 + 1, 32)
                                let v18 = kino_text_at(v9, 0, v17)
                                v18
                            }
                        }
                    }
                }
            let v21 = { "0\n" } <> { v20 }
            v21
        }
    }
}
pub fn closure2(capt: Nil) -> fn(String) -> String {
    fn (v0) {
        let v1 = "\r\n"
        let v2 = "\n"
        let v3 = 0
        let v4 = ""
        let v5 = replace_from_0(v0, v1, v2, v3, v4)
        let v6 = 0
        let v7 = Uh0NoLine
        let v8 = collect_4(v5, v6, v7)
        let v9 = Uh0NoLine
        find_42(v8, v9)
    }
}
pub fn skip_ws_44(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = v4 == " "
            case v5 {
                True -> {
                    let v6 = spiral_wrap_signed(v1 + 1, 32)
                    skip_ws_44(v0, v6)
                }
                False -> {
                    let v8 = v4 == "\t"
                    case v8 {
                        True -> {
                            let v9 = spiral_wrap_signed(v1 + 1, 32)
                            skip_ws_44(v0, v9)
                        }
                        False -> {
                            let v11 = v4 == "\n"
                            case v11 {
                                True -> {
                                    let v12 = spiral_wrap_signed(v1 + 1, 32)
                                    skip_ws_44(v0, v12)
                                }
                                False -> {
                                    let v14 = v4 == "\r"
                                    case v14 {
                                        True -> {
                                            let v15 = spiral_wrap_signed(v1 + 1, 32)
                                            skip_ws_44(v0, v15)
                                        }
                                        False -> {
                                            v1
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
pub fn line_end_45(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = v4 == "\n"
            case v5 {
                True -> {
                    v1
                }
                False -> {
                    let v6 = v4 == "\r"
                    case v6 {
                        True -> {
                            v1
                        }
                        False -> {
                            let v7 = spiral_wrap_signed(v1 + 1, 32)
                            line_end_45(v0, v7)
                        }
                    }
                }
            }
        }
    }
}
pub fn unit_from_43(v0: String, v1: Int) -> String {
    let v2 = "Got:"
    let v3 = find_from_1(v0, v2, v1)
    let v4 = v3 < 0
    case v4 {
        True -> {
            let v5 = "0"
            v5
        }
        False -> {
            let v6 = "Expected:"
            let v7 = spiral_wrap_signed(v3 + 4, 32)
            let v8 = find_from_1(v0, v6, v7)
            let v9 = v8 < 0
            case v9 {
                True -> {
                    let v10 = "0"
                    v10
                }
                False -> {
                    let v11 = kino_text_size(v2)
                    let v12 = spiral_wrap_signed(v3 + v11, 32)
                    let v13 = skip_ws_44(v0, v12)
                    let v14 = line_end_45(v0, v13)
                    let v15 = spiral_wrap_signed(v14 - v13, 32)
                    let v16 = v15 <= 0
                    let v35 =
                        case v16 {
                            True -> {
                                let v17 = ""
                                v17
                            }
                            False -> {
                                let v18 = kino_text_size(v0)
                                let v19 = v13 >= v18
                                case v19 {
                                    True -> {
                                        let v20 = ""
                                        v20
                                    }
                                    False -> {
                                        let v21 = spiral_wrap_signed(v13 + v15, 32)
                                        let v22 = spiral_wrap_signed(v21 - 1, 32)
                                        let v23 = kino_text_size(v0)
                                        let v24 = v22 >= v23
                                        let v27 =
                                            case v24 {
                                                True -> {
                                                    let v25 = kino_text_size(v0)
                                                    let v26 = spiral_wrap_signed(v25 - 1, 32)
                                                    v26
                                                }
                                                False -> {
                                                    v22
                                                }
                                            }
                                        let v28 = v27 < v13
                                        case v28 {
                                            True -> {
                                                let v29 = ""
                                                v29
                                            }
                                            False -> {
                                                let v30 = spiral_wrap_signed(v27 - v13, 32)
                                                let v31 = spiral_wrap_signed(v30 + 1, 32)
                                                let v32 = kino_text_at(v0, v13, v31)
                                                v32
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v36 = 0
                    let v37 = trim_start_17(v35, v36)
                    let v38 = kino_text_size(v35)
                    let v39 = trim_end_18(v35, v38)
                    let v40 = v39 <= v37
                    let v46 =
                        case v40 {
                            True -> {
                                let v41 = ""
                                v41
                            }
                            False -> {
                                let v42 = spiral_wrap_signed(v39 - 1, 32)
                                let v43 = spiral_wrap_signed(v42 - v37, 32)
                                let v44 = spiral_wrap_signed(v43 + 1, 32)
                                let v45 = kino_text_at(v35, v37, v44)
                                v45
                            }
                        }
                    let v47 = 0
                    let v48 = "\""
                    let v49 = find_char_3(v46, v47, v48)
                    let v50 = v49 < 0
                    let v71 =
                        case v50 {
                            True -> {
                                v46
                            }
                            False -> {
                                let v51 = kino_text_size(v46)
                                let v52 = v49 < v51
                                let v53 =
                                    case v52 {
                                        True -> {
                                            v49
                                        }
                                        False -> {
                                            v51
                                        }
                                    }
                                let v54 = v53 <= 0
                                let v59 =
                                    case v54 {
                                        True -> {
                                            let v55 = ""
                                            v55
                                        }
                                        False -> {
                                            let v56 = spiral_wrap_signed(v53 - 1, 32)
                                            let v57 = spiral_wrap_signed(v56 + 1, 32)
                                            let v58 = kino_text_at(v46, 0, v57)
                                            v58
                                        }
                                    }
                                let v60 = 0
                                let v61 = trim_start_17(v59, v60)
                                let v62 = kino_text_size(v59)
                                let v63 = trim_end_18(v59, v62)
                                let v64 = v63 <= v61
                                case v64 {
                                    True -> {
                                        let v65 = ""
                                        v65
                                    }
                                    False -> {
                                        let v66 = spiral_wrap_signed(v63 - 1, 32)
                                        let v67 = spiral_wrap_signed(v66 - v61, 32)
                                        let v68 = spiral_wrap_signed(v67 + 1, 32)
                                        let v69 = kino_text_at(v59, v61, v68)
                                        v69
                                    }
                                }
                            }
                        }
                    let v72 = kino_text_size(v6)
                    let v73 = spiral_wrap_signed(v8 + v72, 32)
                    let v74 = skip_ws_44(v0, v73)
                    let v75 = line_end_45(v0, v74)
                    let v76 = spiral_wrap_signed(v75 - v74, 32)
                    let v77 = v76 <= 0
                    let v96 =
                        case v77 {
                            True -> {
                                let v78 = ""
                                v78
                            }
                            False -> {
                                let v79 = kino_text_size(v0)
                                let v80 = v74 >= v79
                                case v80 {
                                    True -> {
                                        let v81 = ""
                                        v81
                                    }
                                    False -> {
                                        let v82 = spiral_wrap_signed(v74 + v76, 32)
                                        let v83 = spiral_wrap_signed(v82 - 1, 32)
                                        let v84 = kino_text_size(v0)
                                        let v85 = v83 >= v84
                                        let v88 =
                                            case v85 {
                                                True -> {
                                                    let v86 = kino_text_size(v0)
                                                    let v87 = spiral_wrap_signed(v86 - 1, 32)
                                                    v87
                                                }
                                                False -> {
                                                    v83
                                                }
                                            }
                                        let v89 = v88 < v74
                                        case v89 {
                                            True -> {
                                                let v90 = ""
                                                v90
                                            }
                                            False -> {
                                                let v91 = spiral_wrap_signed(v88 - v74, 32)
                                                let v92 = spiral_wrap_signed(v91 + 1, 32)
                                                let v93 = kino_text_at(v0, v74, v92)
                                                v93
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v97 = 0
                    let v98 = trim_start_17(v96, v97)
                    let v99 = kino_text_size(v96)
                    let v100 = trim_end_18(v96, v99)
                    let v101 = v100 <= v98
                    let v107 =
                        case v101 {
                            True -> {
                                let v102 = ""
                                v102
                            }
                            False -> {
                                let v103 = spiral_wrap_signed(v100 - 1, 32)
                                let v104 = spiral_wrap_signed(v103 - v98, 32)
                                let v105 = spiral_wrap_signed(v104 + 1, 32)
                                let v106 = kino_text_at(v96, v98, v105)
                                v106
                            }
                        }
                    let v108 = 0
                    let v109 = "\""
                    let v110 = find_char_3(v107, v108, v109)
                    let v111 = v110 < 0
                    let v132 =
                        case v111 {
                            True -> {
                                v107
                            }
                            False -> {
                                let v112 = kino_text_size(v107)
                                let v113 = v110 < v112
                                let v114 =
                                    case v113 {
                                        True -> {
                                            v110
                                        }
                                        False -> {
                                            v112
                                        }
                                    }
                                let v115 = v114 <= 0
                                let v120 =
                                    case v115 {
                                        True -> {
                                            let v116 = ""
                                            v116
                                        }
                                        False -> {
                                            let v117 = spiral_wrap_signed(v114 - 1, 32)
                                            let v118 = spiral_wrap_signed(v117 + 1, 32)
                                            let v119 = kino_text_at(v107, 0, v118)
                                            v119
                                        }
                                    }
                                let v121 = 0
                                let v122 = trim_start_17(v120, v121)
                                let v123 = kino_text_size(v120)
                                let v124 = trim_end_18(v120, v123)
                                let v125 = v124 <= v122
                                case v125 {
                                    True -> {
                                        let v126 = ""
                                        v126
                                    }
                                    False -> {
                                        let v127 = spiral_wrap_signed(v124 - 1, 32)
                                        let v128 = spiral_wrap_signed(v127 - v122, 32)
                                        let v129 = spiral_wrap_signed(v128 + 1, 32)
                                        let v130 = kino_text_at(v120, v122, v129)
                                        v130
                                    }
                                }
                            }
                        }
                    let v133 = v71 == "()"
                    let v135 =
                        case v133 {
                            True -> {
                                let v134 = v132 == "i32"
                                v134
                            }
                            False -> {
                                False
                            }
                        }
                    let v305 =
                        case v135 {
                            True -> {
                                True
                            }
                            False -> {
                                let v136 = v71 == "i32"
                                let v138 =
                                    case v136 {
                                        True -> {
                                            let v137 = v132 == "()"
                                            v137
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v138 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v139 = "-> ()"
                                        let v140 = kino_text_size(v139)
                                        let v141 = kino_text_size(v71)
                                        let v142 = spiral_wrap_signed(v141 - v140, 32)
                                        let v143 = kino_text_size(v139)
                                        let v144 = v142 < 0
                                        let v156 =
                                            case v144 {
                                                True -> {
                                                    False
                                                }
                                                False -> {
                                                    let v145 = spiral_wrap_signed(v142 + v143, 32)
                                                    let v146 = kino_text_size(v71)
                                                    let v147 = v145 > v146
                                                    case v147 {
                                                        True -> {
                                                            False
                                                        }
                                                        False -> {
                                                            let v148 = v143 == 0
                                                            case v148 {
                                                                True -> {
                                                                    True
                                                                }
                                                                False -> {
                                                                    let v149 = spiral_wrap_signed(v145 - 1, 32)
                                                                    let v150 = spiral_wrap_signed(v149 - v142, 32)
                                                                    let v151 = spiral_wrap_signed(v150 + 1, 32)
                                                                    let v152 = kino_text_at(v71, v142, v151)
                                                                    let v153 = v152 == "-> ()"
                                                                    v153
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        let #(v176, v177) =
                                            case v156 {
                                                True -> {
                                                    let v157 = v142 <= 0
                                                    let v174 =
                                                        case v157 {
                                                            True -> {
                                                                let v158 = ""
                                                                v158
                                                            }
                                                            False -> {
                                                                let v159 = kino_text_size(v71)
                                                                let v160 = 0 >= v159
                                                                case v160 {
                                                                    True -> {
                                                                        let v161 = ""
                                                                        v161
                                                                    }
                                                                    False -> {
                                                                        let v162 = spiral_wrap_signed(v142 - 1, 32)
                                                                        let v163 = kino_text_size(v71)
                                                                        let v164 = v162 >= v163
                                                                        let v167 =
                                                                            case v164 {
                                                                                True -> {
                                                                                    let v165 = kino_text_size(v71)
                                                                                    let v166 = spiral_wrap_signed(v165 - 1, 32)
                                                                                    v166
                                                                                }
                                                                                False -> {
                                                                                    v162
                                                                                }
                                                                            }
                                                                        let v168 = v167 < 0
                                                                        case v168 {
                                                                            True -> {
                                                                                let v169 = ""
                                                                                v169
                                                                            }
                                                                            False -> {
                                                                                let v170 = spiral_wrap_signed(v167 + 1, 32)
                                                                                let v171 = kino_text_at(v71, 0, v170)
                                                                                v171
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    #(1, v174)
                                                }
                                                False -> {
                                                    let v175 = ""
                                                    #(0, v175)
                                                }
                                            }
                                        let v178 = "-> i32"
                                        let v179 = kino_text_size(v178)
                                        let v180 = kino_text_size(v132)
                                        let v181 = spiral_wrap_signed(v180 - v179, 32)
                                        let v182 = kino_text_size(v178)
                                        let v183 = v181 < 0
                                        let v195 =
                                            case v183 {
                                                True -> {
                                                    False
                                                }
                                                False -> {
                                                    let v184 = spiral_wrap_signed(v181 + v182, 32)
                                                    let v185 = kino_text_size(v132)
                                                    let v186 = v184 > v185
                                                    case v186 {
                                                        True -> {
                                                            False
                                                        }
                                                        False -> {
                                                            let v187 = v182 == 0
                                                            case v187 {
                                                                True -> {
                                                                    True
                                                                }
                                                                False -> {
                                                                    let v188 = spiral_wrap_signed(v184 - 1, 32)
                                                                    let v189 = spiral_wrap_signed(v188 - v181, 32)
                                                                    let v190 = spiral_wrap_signed(v189 + 1, 32)
                                                                    let v191 = kino_text_at(v132, v181, v190)
                                                                    let v192 = v191 == "-> i32"
                                                                    v192
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        let #(v215, v216) =
                                            case v195 {
                                                True -> {
                                                    let v196 = v181 <= 0
                                                    let v213 =
                                                        case v196 {
                                                            True -> {
                                                                let v197 = ""
                                                                v197
                                                            }
                                                            False -> {
                                                                let v198 = kino_text_size(v132)
                                                                let v199 = 0 >= v198
                                                                case v199 {
                                                                    True -> {
                                                                        let v200 = ""
                                                                        v200
                                                                    }
                                                                    False -> {
                                                                        let v201 = spiral_wrap_signed(v181 - 1, 32)
                                                                        let v202 = kino_text_size(v132)
                                                                        let v203 = v201 >= v202
                                                                        let v206 =
                                                                            case v203 {
                                                                                True -> {
                                                                                    let v204 = kino_text_size(v132)
                                                                                    let v205 = spiral_wrap_signed(v204 - 1, 32)
                                                                                    v205
                                                                                }
                                                                                False -> {
                                                                                    v201
                                                                                }
                                                                            }
                                                                        let v207 = v206 < 0
                                                                        case v207 {
                                                                            True -> {
                                                                                let v208 = ""
                                                                                v208
                                                                            }
                                                                            False -> {
                                                                                let v209 = spiral_wrap_signed(v206 + 1, 32)
                                                                                let v210 = kino_text_at(v132, 0, v209)
                                                                                v210
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    #(1, v213)
                                                }
                                                False -> {
                                                    let v214 = ""
                                                    #(0, v214)
                                                }
                                            }
                                        let v217 = v176 == 1
                                        let v219 =
                                            case v217 {
                                                True -> {
                                                    let v218 = v215 == 1
                                                    v218
                                                }
                                                False -> {
                                                    False
                                                }
                                            }
                                        let v221 =
                                            case v219 {
                                                True -> {
                                                    let v220 = v177 == v216
                                                    v220
                                                }
                                                False -> {
                                                    False
                                                }
                                            }
                                        case v221 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v222 = kino_text_size(v178)
                                                let v223 = kino_text_size(v71)
                                                let v224 = spiral_wrap_signed(v223 - v222, 32)
                                                let v225 = kino_text_size(v178)
                                                let v226 = v224 < 0
                                                let v238 =
                                                    case v226 {
                                                        True -> {
                                                            False
                                                        }
                                                        False -> {
                                                            let v227 = spiral_wrap_signed(v224 + v225, 32)
                                                            let v228 = kino_text_size(v71)
                                                            let v229 = v227 > v228
                                                            case v229 {
                                                                True -> {
                                                                    False
                                                                }
                                                                False -> {
                                                                    let v230 = v225 == 0
                                                                    case v230 {
                                                                        True -> {
                                                                            True
                                                                        }
                                                                        False -> {
                                                                            let v231 = spiral_wrap_signed(v227 - 1, 32)
                                                                            let v232 = spiral_wrap_signed(v231 - v224, 32)
                                                                            let v233 = spiral_wrap_signed(v232 + 1, 32)
                                                                            let v234 = kino_text_at(v71, v224, v233)
                                                                            let v235 = v234 == "-> i32"
                                                                            v235
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                let #(v258, v259) =
                                                    case v238 {
                                                        True -> {
                                                            let v239 = v224 <= 0
                                                            let v256 =
                                                                case v239 {
                                                                    True -> {
                                                                        let v240 = ""
                                                                        v240
                                                                    }
                                                                    False -> {
                                                                        let v241 = kino_text_size(v71)
                                                                        let v242 = 0 >= v241
                                                                        case v242 {
                                                                            True -> {
                                                                                let v243 = ""
                                                                                v243
                                                                            }
                                                                            False -> {
                                                                                let v244 = spiral_wrap_signed(v224 - 1, 32)
                                                                                let v245 = kino_text_size(v71)
                                                                                let v246 = v244 >= v245
                                                                                let v249 =
                                                                                    case v246 {
                                                                                        True -> {
                                                                                            let v247 = kino_text_size(v71)
                                                                                            let v248 = spiral_wrap_signed(v247 - 1, 32)
                                                                                            v248
                                                                                        }
                                                                                        False -> {
                                                                                            v244
                                                                                        }
                                                                                    }
                                                                                let v250 = v249 < 0
                                                                                case v250 {
                                                                                    True -> {
                                                                                        let v251 = ""
                                                                                        v251
                                                                                    }
                                                                                    False -> {
                                                                                        let v252 = spiral_wrap_signed(v249 + 1, 32)
                                                                                        let v253 = kino_text_at(v71, 0, v252)
                                                                                        v253
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            #(1, v256)
                                                        }
                                                        False -> {
                                                            let v257 = ""
                                                            #(0, v257)
                                                        }
                                                    }
                                                let v260 = kino_text_size(v139)
                                                let v261 = kino_text_size(v132)
                                                let v262 = spiral_wrap_signed(v261 - v260, 32)
                                                let v263 = kino_text_size(v139)
                                                let v264 = v262 < 0
                                                let v276 =
                                                    case v264 {
                                                        True -> {
                                                            False
                                                        }
                                                        False -> {
                                                            let v265 = spiral_wrap_signed(v262 + v263, 32)
                                                            let v266 = kino_text_size(v132)
                                                            let v267 = v265 > v266
                                                            case v267 {
                                                                True -> {
                                                                    False
                                                                }
                                                                False -> {
                                                                    let v268 = v263 == 0
                                                                    case v268 {
                                                                        True -> {
                                                                            True
                                                                        }
                                                                        False -> {
                                                                            let v269 = spiral_wrap_signed(v265 - 1, 32)
                                                                            let v270 = spiral_wrap_signed(v269 - v262, 32)
                                                                            let v271 = spiral_wrap_signed(v270 + 1, 32)
                                                                            let v272 = kino_text_at(v132, v262, v271)
                                                                            let v273 = v272 == "-> ()"
                                                                            v273
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                let #(v296, v297) =
                                                    case v276 {
                                                        True -> {
                                                            let v277 = v262 <= 0
                                                            let v294 =
                                                                case v277 {
                                                                    True -> {
                                                                        let v278 = ""
                                                                        v278
                                                                    }
                                                                    False -> {
                                                                        let v279 = kino_text_size(v132)
                                                                        let v280 = 0 >= v279
                                                                        case v280 {
                                                                            True -> {
                                                                                let v281 = ""
                                                                                v281
                                                                            }
                                                                            False -> {
                                                                                let v282 = spiral_wrap_signed(v262 - 1, 32)
                                                                                let v283 = kino_text_size(v132)
                                                                                let v284 = v282 >= v283
                                                                                let v287 =
                                                                                    case v284 {
                                                                                        True -> {
                                                                                            let v285 = kino_text_size(v132)
                                                                                            let v286 = spiral_wrap_signed(v285 - 1, 32)
                                                                                            v286
                                                                                        }
                                                                                        False -> {
                                                                                            v282
                                                                                        }
                                                                                    }
                                                                                let v288 = v287 < 0
                                                                                case v288 {
                                                                                    True -> {
                                                                                        let v289 = ""
                                                                                        v289
                                                                                    }
                                                                                    False -> {
                                                                                        let v290 = spiral_wrap_signed(v287 + 1, 32)
                                                                                        let v291 = kino_text_at(v132, 0, v290)
                                                                                        v291
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            #(1, v294)
                                                        }
                                                        False -> {
                                                            let v295 = ""
                                                            #(0, v295)
                                                        }
                                                    }
                                                let v298 = v258 == 1
                                                let v300 =
                                                    case v298 {
                                                        True -> {
                                                            let v299 = v296 == 1
                                                            v299
                                                        }
                                                        False -> {
                                                            False
                                                        }
                                                    }
                                                case v300 {
                                                    True -> {
                                                        let v301 = v259 == v297
                                                        v301
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
                        }
                    case v305 {
                        True -> {
                            let v306 = "1"
                            v306
                        }
                        False -> {
                            unit_from_43(v0, v7)
                        }
                    }
                }
            }
        }
    }
}
pub fn closure3(capt: Nil) -> fn(String) -> String {
    fn (v0) {
        let v1 = 0
        unit_from_43(v0, v1)
    }
}
pub fn indent_names_46(v0: String, v1: Int, v2: String) -> String {
    let v3 = kino_text_size(v0)
    let v4 = v1 > v3
    let v44 =
        case v4 {
            True -> {
                Us0LineDone
            }
            False -> {
                let v6 = v3 == 0
                let v8 =
                    case v6 {
                        True -> {
                            let v7 = v1 == 0
                            v7
                        }
                        False -> {
                            False
                        }
                    }
                case v8 {
                    True -> {
                        let v9 = ""
                        Us0LineGot(v9, 1)
                    }
                    False -> {
                        let v11 = v1 == v3
                        case v11 {
                            True -> {
                                let v12 = v3 > 0
                                let v16 =
                                    case v12 {
                                        True -> {
                                            let v13 = spiral_wrap_signed(v3 - 1, 32)
                                            let v14 = kino_text_at(v0, v13, 1)
                                            let v15 = v14 == "\n"
                                            v15
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v16 {
                                    True -> {
                                        let v17 = spiral_wrap_signed(v3 + 1, 32)
                                        let v18 = ""
                                        Us0LineGot(v18, v17)
                                    }
                                    False -> {
                                        Us0LineDone
                                    }
                                }
                            }
                            False -> {
                                let v22 = "\n"
                                let v23 = find_char_3(v0, v1, v22)
                                let v24 = v23 < 0
                                case v24 {
                                    True -> {
                                        let v25 = spiral_wrap_signed(v3 - 1, 32)
                                        let v26 = spiral_wrap_signed(v25 - v1, 32)
                                        let v27 = spiral_wrap_signed(v26 + 1, 32)
                                        let v28 = kino_text_at(v0, v1, v27)
                                        Us0LineGot(v28, v3)
                                    }
                                    False -> {
                                        let v30 = v23 == v1
                                        case v30 {
                                            True -> {
                                                let v31 = spiral_wrap_signed(v23 + 1, 32)
                                                let v32 = ""
                                                Us0LineGot(v32, v31)
                                            }
                                            False -> {
                                                let v34 = spiral_wrap_signed(v23 - 1, 32)
                                                let v35 = spiral_wrap_signed(v34 - v1, 32)
                                                let v36 = spiral_wrap_signed(v35 + 1, 32)
                                                let v37 = kino_text_at(v0, v1, v36)
                                                let v38 = spiral_wrap_signed(v23 + 1, 32)
                                                Us0LineGot(v37, v38)
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
    case v44  {
        Us0LineDone -> {
            v2
        }
        Us0LineGot(v45, v46) -> {
            let v47 = v45 == ""
            case v47 {
                True -> {
                    indent_names_46(v0, v46, v2)
                }
                False -> {
                    let v49 = { v2 } <> { "    " }
                    let v50 = { v49 } <> { v45 }
                    let v51 = { v50 } <> { "-\n" }
                    indent_names_46(v0, v46, v51)
                }
            }
        }
    }
}
pub fn closure4(capt: Nil) -> fn(String) -> String {
    fn (v0) {
        let v1 = v0 == ""
        case v1 {
            True -> {
                let v2 = "packages:\n    |core-\nmodules:\n    console\n    main\n"
                v2
            }
            False -> {
                let v3 = 0
                let v4 = ""
                let v5 = indent_names_46(v0, v3, v4)
                let v6 = { "packageDir: .\npackages:\n    |core-\n" } <> { v5 }
                let v7 = { v6 } <> { "modules:\n    console\n    main\n" }
                v7
            }
        }
    }
}
pub fn letter_end_48(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
            let v6 = 0
            let v7 = has_char_12(v5, v6, v4)
            case v7 {
                True -> {
                    let v8 = spiral_wrap_signed(v1 + 1, 32)
                    letter_end_48(v0, v8)
                }
                False -> {
                    v1
                }
            }
        }
    }
}
pub fn walk_49(v0: String, v1: Int, v2: Uh3, v3: String, v4: String) -> Uh3 {
    let v5 = kino_text_size(v0)
    let v6 = v1 > v5
    let v46 =
        case v6 {
            True -> {
                Us0LineDone
            }
            False -> {
                let v8 = v5 == 0
                let v10 =
                    case v8 {
                        True -> {
                            let v9 = v1 == 0
                            v9
                        }
                        False -> {
                            False
                        }
                    }
                case v10 {
                    True -> {
                        let v11 = ""
                        Us0LineGot(v11, 1)
                    }
                    False -> {
                        let v13 = v1 == v5
                        case v13 {
                            True -> {
                                let v14 = v5 > 0
                                let v18 =
                                    case v14 {
                                        True -> {
                                            let v15 = spiral_wrap_signed(v5 - 1, 32)
                                            let v16 = kino_text_at(v0, v15, 1)
                                            let v17 = v16 == "\n"
                                            v17
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v18 {
                                    True -> {
                                        let v19 = spiral_wrap_signed(v5 + 1, 32)
                                        let v20 = ""
                                        Us0LineGot(v20, v19)
                                    }
                                    False -> {
                                        Us0LineDone
                                    }
                                }
                            }
                            False -> {
                                let v24 = "\n"
                                let v25 = find_char_3(v0, v1, v24)
                                let v26 = v25 < 0
                                case v26 {
                                    True -> {
                                        let v27 = spiral_wrap_signed(v5 - 1, 32)
                                        let v28 = spiral_wrap_signed(v27 - v1, 32)
                                        let v29 = spiral_wrap_signed(v28 + 1, 32)
                                        let v30 = kino_text_at(v0, v1, v29)
                                        Us0LineGot(v30, v5)
                                    }
                                    False -> {
                                        let v32 = v25 == v1
                                        case v32 {
                                            True -> {
                                                let v33 = spiral_wrap_signed(v25 + 1, 32)
                                                let v34 = ""
                                                Us0LineGot(v34, v33)
                                            }
                                            False -> {
                                                let v36 = spiral_wrap_signed(v25 - 1, 32)
                                                let v37 = spiral_wrap_signed(v36 - v1, 32)
                                                let v38 = spiral_wrap_signed(v37 + 1, 32)
                                                let v39 = kino_text_at(v0, v1, v38)
                                                let v40 = spiral_wrap_signed(v25 + 1, 32)
                                                Us0LineGot(v39, v40)
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
    case v46  {
        Us0LineDone -> {
            let v47 = v3 == ""
            case v47 {
                True -> {
                    v2
                }
                False -> {
                    let v48 = 0
                    let v49 = trim_start_17(v4, v48)
                    let v50 = kino_text_size(v4)
                    let v51 = trim_end_18(v4, v50)
                    let v52 = v51 <= v49
                    let v58 =
                        case v52 {
                            True -> {
                                let v53 = ""
                                v53
                            }
                            False -> {
                                let v54 = spiral_wrap_signed(v51 - 1, 32)
                                let v55 = spiral_wrap_signed(v54 - v49, 32)
                                let v56 = spiral_wrap_signed(v55 + 1, 32)
                                let v57 = kino_text_at(v4, v49, v56)
                                v57
                            }
                        }
                    let v59 = v58 == ""
                    case v59 {
                        True -> {
                            v2
                        }
                        False -> {
                            Uh3Cell(v3, v58, v2)
                        }
                    }
                }
            }
        }
        Us0LineGot(v63, v64) -> {
            let v65 = "#!"
            let v66 = kino_text_size(v65)
            let v67 = kino_text_size(v63)
            let v68 = v66 > v67
            let v75 =
                case v68 {
                    True -> {
                        False
                    }
                    False -> {
                        let v69 = v66 == 0
                        case v69 {
                            True -> {
                                True
                            }
                            False -> {
                                let v70 = spiral_wrap_signed(v66 - 1, 32)
                                let v71 = spiral_wrap_signed(v70 + 1, 32)
                                let v72 = kino_text_at(v63, 0, v71)
                                let v73 = v72 == "#!"
                                v73
                            }
                        }
                    }
                }
            let v114 =
                case v75 {
                    True -> {
                        let v76 = 2
                        let v77 = letter_end_48(v63, v76)
                        let v78 = v77 == 2
                        case v78 {
                            True -> {
                                Us2NoMark
                            }
                            False -> {
                                let v80 = spiral_wrap_signed(v77 - 2, 32)
                                let v81 = v80 <= 0
                                let v100 =
                                    case v81 {
                                        True -> {
                                            let v82 = ""
                                            v82
                                        }
                                        False -> {
                                            let v83 = kino_text_size(v63)
                                            let v84 = 2 >= v83
                                            case v84 {
                                                True -> {
                                                    let v85 = ""
                                                    v85
                                                }
                                                False -> {
                                                    let v86 = spiral_wrap_signed(2 + v80, 32)
                                                    let v87 = spiral_wrap_signed(v86 - 1, 32)
                                                    let v88 = kino_text_size(v63)
                                                    let v89 = v87 >= v88
                                                    let v92 =
                                                        case v89 {
                                                            True -> {
                                                                let v90 = kino_text_size(v63)
                                                                let v91 = spiral_wrap_signed(v90 - 1, 32)
                                                                v91
                                                            }
                                                            False -> {
                                                                v87
                                                            }
                                                        }
                                                    let v93 = v92 < 2
                                                    case v93 {
                                                        True -> {
                                                            let v94 = ""
                                                            v94
                                                        }
                                                        False -> {
                                                            let v95 = spiral_wrap_signed(v92 - 2, 32)
                                                            let v96 = spiral_wrap_signed(v95 + 1, 32)
                                                            let v97 = kino_text_at(v63, 2, v96)
                                                            v97
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                let v101 = kino_text_size(v63)
                                let v102 = v77 >= v101
                                let v110 =
                                    case v102 {
                                        True -> {
                                            let v103 = ""
                                            v103
                                        }
                                        False -> {
                                            let v104 = v77 <= 0
                                            case v104 {
                                                True -> {
                                                    v63
                                                }
                                                False -> {
                                                    let v105 = spiral_wrap_signed(v101 - 1, 32)
                                                    let v106 = spiral_wrap_signed(v105 - v77, 32)
                                                    let v107 = spiral_wrap_signed(v106 + 1, 32)
                                                    let v108 = kino_text_at(v63, v77, v107)
                                                    v108
                                                }
                                            }
                                        }
                                    }
                                Us2Mark(v100, v110)
                            }
                        }
                    }
                    False -> {
                        Us2NoMark
                    }
                }
            case v114  {
                Us2Mark(v120, v121) -> {
                    let v122 = v3 == ""
                    let v137 =
                        case v122 {
                            True -> {
                                v2
                            }
                            False -> {
                                let v123 = 0
                                let v124 = trim_start_17(v4, v123)
                                let v125 = kino_text_size(v4)
                                let v126 = trim_end_18(v4, v125)
                                let v127 = v126 <= v124
                                let v133 =
                                    case v127 {
                                        True -> {
                                            let v128 = ""
                                            v128
                                        }
                                        False -> {
                                            let v129 = spiral_wrap_signed(v126 - 1, 32)
                                            let v130 = spiral_wrap_signed(v129 - v124, 32)
                                            let v131 = spiral_wrap_signed(v130 + 1, 32)
                                            let v132 = kino_text_at(v4, v124, v131)
                                            v132
                                        }
                                    }
                                let v134 = v133 == ""
                                case v134 {
                                    True -> {
                                        v2
                                    }
                                    False -> {
                                        Uh3Cell(v3, v133, v2)
                                    }
                                }
                            }
                        }
                    let v138 = v120 == "import"
                    case v138 {
                        True -> {
                            let v139 = 0
                            let v140 = trim_start_17(v121, v139)
                            let v141 = kino_text_size(v121)
                            let v142 = trim_end_18(v121, v141)
                            let v143 = v142 <= v140
                            let v149 =
                                case v143 {
                                    True -> {
                                        let v144 = ""
                                        v144
                                    }
                                    False -> {
                                        let v145 = spiral_wrap_signed(v142 - 1, 32)
                                        let v146 = spiral_wrap_signed(v145 - v140, 32)
                                        let v147 = spiral_wrap_signed(v146 + 1, 32)
                                        let v148 = kino_text_at(v121, v140, v147)
                                        v148
                                    }
                                }
                            let v150 = "import"
                            let v151 = Uh3Cell(v150, v149, v137)
                            let v152 = ""
                            walk_49(v0, v64, v151, v3, v152)
                        }
                        False -> {
                            let v154 = v120 == "meta"
                            case v154 {
                                True -> {
                                    let v155 = ""
                                    walk_47(v0, v64, v137, v155)
                                }
                                False -> {
                                    let v157 = v120 == "markdown"
                                    case v157 {
                                        True -> {
                                            let v158 = ""
                                            walk_49(v0, v64, v137, v120, v158)
                                        }
                                        False -> {
                                            let v160 = v120 == "spiral"
                                            case v160 {
                                                True -> {
                                                    let v161 = ""
                                                    walk_49(v0, v64, v137, v120, v161)
                                                }
                                                False -> {
                                                    let v163 = v120 == "fsharp"
                                                    case v163 {
                                                        True -> {
                                                            let v164 = ""
                                                            walk_49(v0, v64, v137, v120, v164)
                                                        }
                                                        False -> {
                                                            let v166 = { "code/" } <> { v120 }
                                                            let v167 = ""
                                                            walk_49(v0, v64, v137, v166, v167)
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
                Us2NoMark -> {
                    let v115 = v4 == ""
                    let v118 =
                        case v115 {
                            True -> {
                                v63
                            }
                            False -> {
                                let v116 = { v4 } <> { "\n" }
                                let v117 = { v116 } <> { v63 }
                                v117
                            }
                        }
                    walk_49(v0, v64, v2, v3, v118)
                }
            }
        }
    }
}
pub fn walk_47(v0: String, v1: Int, v2: Uh3, v3: String) -> Uh3 {
    let v4 = kino_text_size(v0)
    let v5 = v1 > v4
    let v45 =
        case v5 {
            True -> {
                Us0LineDone
            }
            False -> {
                let v7 = v4 == 0
                let v9 =
                    case v7 {
                        True -> {
                            let v8 = v1 == 0
                            v8
                        }
                        False -> {
                            False
                        }
                    }
                case v9 {
                    True -> {
                        let v10 = ""
                        Us0LineGot(v10, 1)
                    }
                    False -> {
                        let v12 = v1 == v4
                        case v12 {
                            True -> {
                                let v13 = v4 > 0
                                let v17 =
                                    case v13 {
                                        True -> {
                                            let v14 = spiral_wrap_signed(v4 - 1, 32)
                                            let v15 = kino_text_at(v0, v14, 1)
                                            let v16 = v15 == "\n"
                                            v16
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v17 {
                                    True -> {
                                        let v18 = spiral_wrap_signed(v4 + 1, 32)
                                        let v19 = ""
                                        Us0LineGot(v19, v18)
                                    }
                                    False -> {
                                        Us0LineDone
                                    }
                                }
                            }
                            False -> {
                                let v23 = "\n"
                                let v24 = find_char_3(v0, v1, v23)
                                let v25 = v24 < 0
                                case v25 {
                                    True -> {
                                        let v26 = spiral_wrap_signed(v4 - 1, 32)
                                        let v27 = spiral_wrap_signed(v26 - v1, 32)
                                        let v28 = spiral_wrap_signed(v27 + 1, 32)
                                        let v29 = kino_text_at(v0, v1, v28)
                                        Us0LineGot(v29, v4)
                                    }
                                    False -> {
                                        let v31 = v24 == v1
                                        case v31 {
                                            True -> {
                                                let v32 = spiral_wrap_signed(v24 + 1, 32)
                                                let v33 = ""
                                                Us0LineGot(v33, v32)
                                            }
                                            False -> {
                                                let v35 = spiral_wrap_signed(v24 - 1, 32)
                                                let v36 = spiral_wrap_signed(v35 - v1, 32)
                                                let v37 = spiral_wrap_signed(v36 + 1, 32)
                                                let v38 = kino_text_at(v0, v1, v37)
                                                let v39 = spiral_wrap_signed(v24 + 1, 32)
                                                Us0LineGot(v38, v39)
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
    case v45  {
        Us0LineDone -> {
            let v46 = v3 == ""
            case v46 {
                True -> {
                    v2
                }
                False -> {
                    let v47 = 0
                    let v48 = trim_start_17(v3, v47)
                    let v49 = kino_text_size(v3)
                    let v50 = trim_end_18(v3, v49)
                    let v51 = v50 <= v48
                    let v57 =
                        case v51 {
                            True -> {
                                let v52 = ""
                                v52
                            }
                            False -> {
                                let v53 = spiral_wrap_signed(v50 - 1, 32)
                                let v54 = spiral_wrap_signed(v53 - v48, 32)
                                let v55 = spiral_wrap_signed(v54 + 1, 32)
                                let v56 = kino_text_at(v3, v48, v55)
                                v56
                            }
                        }
                    let v58 = v57 == ""
                    case v58 {
                        True -> {
                            v2
                        }
                        False -> {
                            Uh3Cell(v3, v57, v2)
                        }
                    }
                }
            }
        }
        Us0LineGot(v62, v63) -> {
            let v64 = "#!"
            let v65 = kino_text_size(v64)
            let v66 = kino_text_size(v62)
            let v67 = v65 > v66
            let v74 =
                case v67 {
                    True -> {
                        False
                    }
                    False -> {
                        let v68 = v65 == 0
                        case v68 {
                            True -> {
                                True
                            }
                            False -> {
                                let v69 = spiral_wrap_signed(v65 - 1, 32)
                                let v70 = spiral_wrap_signed(v69 + 1, 32)
                                let v71 = kino_text_at(v62, 0, v70)
                                let v72 = v71 == "#!"
                                v72
                            }
                        }
                    }
                }
            let v113 =
                case v74 {
                    True -> {
                        let v75 = 2
                        let v76 = letter_end_48(v62, v75)
                        let v77 = v76 == 2
                        case v77 {
                            True -> {
                                Us2NoMark
                            }
                            False -> {
                                let v79 = spiral_wrap_signed(v76 - 2, 32)
                                let v80 = v79 <= 0
                                let v99 =
                                    case v80 {
                                        True -> {
                                            let v81 = ""
                                            v81
                                        }
                                        False -> {
                                            let v82 = kino_text_size(v62)
                                            let v83 = 2 >= v82
                                            case v83 {
                                                True -> {
                                                    let v84 = ""
                                                    v84
                                                }
                                                False -> {
                                                    let v85 = spiral_wrap_signed(2 + v79, 32)
                                                    let v86 = spiral_wrap_signed(v85 - 1, 32)
                                                    let v87 = kino_text_size(v62)
                                                    let v88 = v86 >= v87
                                                    let v91 =
                                                        case v88 {
                                                            True -> {
                                                                let v89 = kino_text_size(v62)
                                                                let v90 = spiral_wrap_signed(v89 - 1, 32)
                                                                v90
                                                            }
                                                            False -> {
                                                                v86
                                                            }
                                                        }
                                                    let v92 = v91 < 2
                                                    case v92 {
                                                        True -> {
                                                            let v93 = ""
                                                            v93
                                                        }
                                                        False -> {
                                                            let v94 = spiral_wrap_signed(v91 - 2, 32)
                                                            let v95 = spiral_wrap_signed(v94 + 1, 32)
                                                            let v96 = kino_text_at(v62, 2, v95)
                                                            v96
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                let v100 = kino_text_size(v62)
                                let v101 = v76 >= v100
                                let v109 =
                                    case v101 {
                                        True -> {
                                            let v102 = ""
                                            v102
                                        }
                                        False -> {
                                            let v103 = v76 <= 0
                                            case v103 {
                                                True -> {
                                                    v62
                                                }
                                                False -> {
                                                    let v104 = spiral_wrap_signed(v100 - 1, 32)
                                                    let v105 = spiral_wrap_signed(v104 - v76, 32)
                                                    let v106 = spiral_wrap_signed(v105 + 1, 32)
                                                    let v107 = kino_text_at(v62, v76, v106)
                                                    v107
                                                }
                                            }
                                        }
                                    }
                                Us2Mark(v99, v109)
                            }
                        }
                    }
                    False -> {
                        Us2NoMark
                    }
                }
            case v113  {
                Us2Mark(v119, v120) -> {
                    let v121 = v3 == ""
                    let v136 =
                        case v121 {
                            True -> {
                                v2
                            }
                            False -> {
                                let v122 = 0
                                let v123 = trim_start_17(v3, v122)
                                let v124 = kino_text_size(v3)
                                let v125 = trim_end_18(v3, v124)
                                let v126 = v125 <= v123
                                let v132 =
                                    case v126 {
                                        True -> {
                                            let v127 = ""
                                            v127
                                        }
                                        False -> {
                                            let v128 = spiral_wrap_signed(v125 - 1, 32)
                                            let v129 = spiral_wrap_signed(v128 - v123, 32)
                                            let v130 = spiral_wrap_signed(v129 + 1, 32)
                                            let v131 = kino_text_at(v3, v123, v130)
                                            v131
                                        }
                                    }
                                let v133 = v132 == ""
                                case v133 {
                                    True -> {
                                        v2
                                    }
                                    False -> {
                                        Uh3Cell(v3, v132, v2)
                                    }
                                }
                            }
                        }
                    let v137 = v119 == "import"
                    case v137 {
                        True -> {
                            let v138 = 0
                            let v139 = trim_start_17(v120, v138)
                            let v140 = kino_text_size(v120)
                            let v141 = trim_end_18(v120, v140)
                            let v142 = v141 <= v139
                            let v148 =
                                case v142 {
                                    True -> {
                                        let v143 = ""
                                        v143
                                    }
                                    False -> {
                                        let v144 = spiral_wrap_signed(v141 - 1, 32)
                                        let v145 = spiral_wrap_signed(v144 - v139, 32)
                                        let v146 = spiral_wrap_signed(v145 + 1, 32)
                                        let v147 = kino_text_at(v120, v139, v146)
                                        v147
                                    }
                                }
                            let v149 = "import"
                            let v150 = Uh3Cell(v149, v148, v136)
                            let v151 = ""
                            walk_49(v0, v63, v150, v3, v151)
                        }
                        False -> {
                            let v153 = v119 == "meta"
                            case v153 {
                                True -> {
                                    let v154 = ""
                                    walk_47(v0, v63, v136, v154)
                                }
                                False -> {
                                    let v156 = v119 == "markdown"
                                    case v156 {
                                        True -> {
                                            let v157 = ""
                                            walk_49(v0, v63, v136, v119, v157)
                                        }
                                        False -> {
                                            let v159 = v119 == "spiral"
                                            case v159 {
                                                True -> {
                                                    let v160 = ""
                                                    walk_49(v0, v63, v136, v119, v160)
                                                }
                                                False -> {
                                                    let v162 = v119 == "fsharp"
                                                    case v162 {
                                                        True -> {
                                                            let v163 = ""
                                                            walk_49(v0, v63, v136, v119, v163)
                                                        }
                                                        False -> {
                                                            let v165 = { "code/" } <> { v119 }
                                                            let v166 = ""
                                                            walk_49(v0, v63, v136, v165, v166)
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
                Us2NoMark -> {
                    let v114 = v3 == ""
                    let v117 =
                        case v114 {
                            True -> {
                                v62
                            }
                            False -> {
                                let v115 = { v3 } <> { "\n" }
                                let v116 = { v115 } <> { v62 }
                                v116
                            }
                        }
                    walk_49(v0, v63, v2, v3, v117)
                }
            }
        }
    }
}
pub fn rev_cells_50(v0: Uh3, v1: Uh3) -> Uh3 {
    case v0  {
        Uh3Cell(v2, v3, v4) -> {
            let v5 = Uh3Cell(v2, v3, v1)
            rev_cells_50(v4, v5)
        }
        Uh3NoCell -> {
            v1
        }
    }
}
pub fn count_cells_51(v0: Uh3) -> Int {
    case v0  {
        Uh3Cell(v1, v2, v3) -> {
            let v4 = count_cells_51(v3)
            let v5 = spiral_wrap_signed(1 + v4, 32)
            v5
        }
        Uh3NoCell -> {
            0
        }
    }
}
pub fn emit_cells_52(v0: Uh3) -> String {
    case v0  {
        Uh3Cell(v2, v3, v4) -> {
            let v5 = { v2 } <> { "\n" }
            let v6 = kino_text_size(v3)
            let v7 = show_i32_20(v6)
            let v8 = { v5 } <> { v7 }
            let v9 = { v8 } <> { "\n" }
            let v10 = { v9 } <> { v3 }
            let v11 = emit_cells_52(v4)
            let v12 = { v10 } <> { v11 }
            v12
        }
        Uh3NoCell -> {
            let v1 = ""
            v1
        }
    }
}
pub fn closure5(capt: Nil) -> fn(String) -> String {
    fn (v0) {
        let v1 = "\r\n"
        let v2 = "\n"
        let v3 = 0
        let v4 = ""
        let v5 = replace_from_0(v0, v1, v2, v3, v4)
        let v6 = 0
        let v7 = Uh3NoCell
        let v8 = walk_47(v5, v6, v7, v4)
        let v9 = Uh3NoCell
        let v10 = rev_cells_50(v8, v9)
        let v11 = count_cells_51(v10)
        let v12 = show_i32_20(v11)
        let v13 = { v12 } <> { "\n" }
        let v14 = emit_cells_52(v10)
        let v15 = { v13 } <> { v14 }
        v15
    }
}
pub fn read_cells_53(v0: String, v1: Int, v2: Int, v3: Uh3) -> Uh3 {
    let v4 = v2 <= 0
    case v4 {
        True -> {
            let v5 = Uh3NoCell
            rev_cells_50(v3, v5)
        }
        False -> {
            let v7 = kino_text_size(v0)
            let v8 = v1 > v7
            let v48 =
                case v8 {
                    True -> {
                        Us0LineDone
                    }
                    False -> {
                        let v10 = v7 == 0
                        let v12 =
                            case v10 {
                                True -> {
                                    let v11 = v1 == 0
                                    v11
                                }
                                False -> {
                                    False
                                }
                            }
                        case v12 {
                            True -> {
                                let v13 = ""
                                Us0LineGot(v13, 1)
                            }
                            False -> {
                                let v15 = v1 == v7
                                case v15 {
                                    True -> {
                                        let v16 = v7 > 0
                                        let v20 =
                                            case v16 {
                                                True -> {
                                                    let v17 = spiral_wrap_signed(v7 - 1, 32)
                                                    let v18 = kino_text_at(v0, v17, 1)
                                                    let v19 = v18 == "\n"
                                                    v19
                                                }
                                                False -> {
                                                    False
                                                }
                                            }
                                        case v20 {
                                            True -> {
                                                let v21 = spiral_wrap_signed(v7 + 1, 32)
                                                let v22 = ""
                                                Us0LineGot(v22, v21)
                                            }
                                            False -> {
                                                Us0LineDone
                                            }
                                        }
                                    }
                                    False -> {
                                        let v26 = "\n"
                                        let v27 = find_char_3(v0, v1, v26)
                                        let v28 = v27 < 0
                                        case v28 {
                                            True -> {
                                                let v29 = spiral_wrap_signed(v7 - 1, 32)
                                                let v30 = spiral_wrap_signed(v29 - v1, 32)
                                                let v31 = spiral_wrap_signed(v30 + 1, 32)
                                                let v32 = kino_text_at(v0, v1, v31)
                                                Us0LineGot(v32, v7)
                                            }
                                            False -> {
                                                let v34 = v27 == v1
                                                case v34 {
                                                    True -> {
                                                        let v35 = spiral_wrap_signed(v27 + 1, 32)
                                                        let v36 = ""
                                                        Us0LineGot(v36, v35)
                                                    }
                                                    False -> {
                                                        let v38 = spiral_wrap_signed(v27 - 1, 32)
                                                        let v39 = spiral_wrap_signed(v38 - v1, 32)
                                                        let v40 = spiral_wrap_signed(v39 + 1, 32)
                                                        let v41 = kino_text_at(v0, v1, v40)
                                                        let v42 = spiral_wrap_signed(v27 + 1, 32)
                                                        Us0LineGot(v41, v42)
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
            case v48  {
                Us0LineDone -> {
                    let v49 = Uh3NoCell
                    rev_cells_50(v3, v49)
                }
                Us0LineGot(v51, v52) -> {
                    let v53 = kino_text_size(v0)
                    let v54 = v52 > v53
                    let v94 =
                        case v54 {
                            True -> {
                                Us0LineDone
                            }
                            False -> {
                                let v56 = v53 == 0
                                let v58 =
                                    case v56 {
                                        True -> {
                                            let v57 = v52 == 0
                                            v57
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v58 {
                                    True -> {
                                        let v59 = ""
                                        Us0LineGot(v59, 1)
                                    }
                                    False -> {
                                        let v61 = v52 == v53
                                        case v61 {
                                            True -> {
                                                let v62 = v53 > 0
                                                let v66 =
                                                    case v62 {
                                                        True -> {
                                                            let v63 = spiral_wrap_signed(v53 - 1, 32)
                                                            let v64 = kino_text_at(v0, v63, 1)
                                                            let v65 = v64 == "\n"
                                                            v65
                                                        }
                                                        False -> {
                                                            False
                                                        }
                                                    }
                                                case v66 {
                                                    True -> {
                                                        let v67 = spiral_wrap_signed(v53 + 1, 32)
                                                        let v68 = ""
                                                        Us0LineGot(v68, v67)
                                                    }
                                                    False -> {
                                                        Us0LineDone
                                                    }
                                                }
                                            }
                                            False -> {
                                                let v72 = "\n"
                                                let v73 = find_char_3(v0, v52, v72)
                                                let v74 = v73 < 0
                                                case v74 {
                                                    True -> {
                                                        let v75 = spiral_wrap_signed(v53 - 1, 32)
                                                        let v76 = spiral_wrap_signed(v75 - v52, 32)
                                                        let v77 = spiral_wrap_signed(v76 + 1, 32)
                                                        let v78 = kino_text_at(v0, v52, v77)
                                                        Us0LineGot(v78, v53)
                                                    }
                                                    False -> {
                                                        let v80 = v73 == v52
                                                        case v80 {
                                                            True -> {
                                                                let v81 = spiral_wrap_signed(v73 + 1, 32)
                                                                let v82 = ""
                                                                Us0LineGot(v82, v81)
                                                            }
                                                            False -> {
                                                                let v84 = spiral_wrap_signed(v73 - 1, 32)
                                                                let v85 = spiral_wrap_signed(v84 - v52, 32)
                                                                let v86 = spiral_wrap_signed(v85 + 1, 32)
                                                                let v87 = kino_text_at(v0, v52, v86)
                                                                let v88 = spiral_wrap_signed(v73 + 1, 32)
                                                                Us0LineGot(v87, v88)
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
                    case v94  {
                        Us0LineDone -> {
                            let v95 = Uh3NoCell
                            rev_cells_50(v3, v95)
                        }
                        Us0LineGot(v97, v98) -> {
                            let v99 = 0
                            let v100 = 0
                            let v101 = 0
                            let v102 = parse_acc_26(v97, v99, v100, v101)
                            let v103 = spiral_wrap_signed(v98 + v102, 32)
                            let v104 = spiral_wrap_signed(v2 - 1, 32)
                            let v105 = v102 <= 0
                            let v123 =
                                case v105 {
                                    True -> {
                                        let v106 = ""
                                        v106
                                    }
                                    False -> {
                                        let v107 = kino_text_size(v0)
                                        let v108 = v98 >= v107
                                        case v108 {
                                            True -> {
                                                let v109 = ""
                                                v109
                                            }
                                            False -> {
                                                let v110 = spiral_wrap_signed(v103 - 1, 32)
                                                let v111 = kino_text_size(v0)
                                                let v112 = v110 >= v111
                                                let v115 =
                                                    case v112 {
                                                        True -> {
                                                            let v113 = kino_text_size(v0)
                                                            let v114 = spiral_wrap_signed(v113 - 1, 32)
                                                            v114
                                                        }
                                                        False -> {
                                                            v110
                                                        }
                                                    }
                                                let v116 = v115 < v98
                                                case v116 {
                                                    True -> {
                                                        let v117 = ""
                                                        v117
                                                    }
                                                    False -> {
                                                        let v118 = spiral_wrap_signed(v115 - v98, 32)
                                                        let v119 = spiral_wrap_signed(v118 + 1, 32)
                                                        let v120 = kino_text_at(v0, v98, v119)
                                                        v120
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            let v124 = Uh3Cell(v51, v123, v3)
                            read_cells_53(v0, v103, v104, v124)
                        }
                    }
                }
            }
        }
    }
}
pub fn export_blocks_54(v0: Us3, v1: Uh3, v2: Uh3) -> Uh3 {
    case v1  {
        Uh3Cell(v5, v6, v7) -> {
            let v8 = v5 == "markdown"
            let v56 =
                case v8 {
                    True -> {
                        True
                    }
                    False -> {
                        case v0  {
                            Us3SpiExport -> {
                                let v9 = v5 == "spiral"
                                case v9 {
                                    True -> {
                                        let v10 = 0
                                        let v11 = trim_start_17(v6, v10)
                                        let v12 = kino_text_size(v6)
                                        let v13 = trim_end_18(v6, v12)
                                        let v14 = v13 <= v11
                                        let v20 =
                                            case v14 {
                                                True -> {
                                                    let v15 = ""
                                                    v15
                                                }
                                                False -> {
                                                    let v16 = spiral_wrap_signed(v13 - 1, 32)
                                                    let v17 = spiral_wrap_signed(v16 - v11, 32)
                                                    let v18 = spiral_wrap_signed(v17 + 1, 32)
                                                    let v19 = kino_text_at(v6, v11, v18)
                                                    v19
                                                }
                                            }
                                        let v21 = "///- "
                                        let v22 = 0
                                        let v23 = find_from_1(v20, v21, v22)
                                        let v24 = v23 >= 0
                                        let v29 =
                                            case v24 {
                                                True -> {
                                                    let v25 = " --real"
                                                    let v26 = 0
                                                    let v27 = find_from_1(v20, v25, v26)
                                                    let v28 = v27 >= 0
                                                    v28
                                                }
                                                False -> {
                                                    False
                                                }
                                            }
                                        let v30 = v29 == False
                                        v30
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            }
                            Us3SpirExport -> {
                                let v32 = v5 == "spiral"
                                case v32 {
                                    True -> {
                                        let v33 = 0
                                        let v34 = trim_start_17(v6, v33)
                                        let v35 = kino_text_size(v6)
                                        let v36 = trim_end_18(v6, v35)
                                        let v37 = v36 <= v34
                                        let v43 =
                                            case v37 {
                                                True -> {
                                                    let v38 = ""
                                                    v38
                                                }
                                                False -> {
                                                    let v39 = spiral_wrap_signed(v36 - 1, 32)
                                                    let v40 = spiral_wrap_signed(v39 - v34, 32)
                                                    let v41 = spiral_wrap_signed(v40 + 1, 32)
                                                    let v42 = kino_text_at(v6, v34, v41)
                                                    v42
                                                }
                                            }
                                        let v44 = "///- "
                                        let v45 = 0
                                        let v46 = find_from_1(v43, v44, v45)
                                        let v47 = v46 >= 0
                                        case v47 {
                                            True -> {
                                                let v48 = " --real"
                                                let v49 = 0
                                                let v50 = find_from_1(v43, v48, v49)
                                                let v51 = v50 >= 0
                                                v51
                                            }
                                            False -> {
                                                False
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
                }
            case v56 {
                True -> {
                    let v57 = Uh3Cell(v5, v6, v2)
                    export_blocks_54(v0, v7, v57)
                }
                False -> {
                    export_blocks_54(v0, v7, v2)
                }
            }
        }
        Uh3NoCell -> {
            let v3 = Uh3NoCell
            rev_cells_50(v2, v3)
        }
    }
}
pub fn keep_docs_55(v0: Uh3) -> Uh3 {
    case v0  {
        Uh3Cell(v2, v3, v4) -> {
            case v4  {
                Uh3NoCell -> {
                    let v5 = v2 == "markdown"
                    case v5 {
                        True -> {
                            Uh3NoCell
                        }
                        False -> {
                            let v7 = Uh3NoCell
                            Uh3Cell(v2, v3, v7)
                        }
                    }
                }
                _ -> {
                    let v10 = keep_docs_55(v4)
                    Uh3Cell(v2, v3, v10)
                }
            }
        }
        Uh3NoCell -> {
            Uh3NoCell
        }
    }
}
pub fn rev_rows_58(v0: Uh4, v1: Uh4) -> Uh4 {
    case v0  {
        Uh4NoRow -> {
            v1
        }
        Uh4Row(v2, v3) -> {
            let v4 = Uh4Row(v2, v1)
            rev_rows_58(v3, v4)
        }
    }
}
pub fn lead_ws_59(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = v4 == " "
            case v5 {
                True -> {
                    let v6 = spiral_wrap_signed(v1 + 1, 32)
                    lead_ws_59(v0, v6)
                }
                False -> {
                    let v8 = v4 == "\t"
                    case v8 {
                        True -> {
                            let v9 = spiral_wrap_signed(v1 + 1, 32)
                            lead_ws_59(v0, v9)
                        }
                        False -> {
                            v1
                        }
                    }
                }
            }
        }
    }
}
pub fn md_go_57(v0: String, v1: Int, v2: Uh4) -> Uh4 {
    let v3 = kino_text_size(v0)
    let v4 = v1 > v3
    let v44 =
        case v4 {
            True -> {
                Us0LineDone
            }
            False -> {
                let v6 = v3 == 0
                let v8 =
                    case v6 {
                        True -> {
                            let v7 = v1 == 0
                            v7
                        }
                        False -> {
                            False
                        }
                    }
                case v8 {
                    True -> {
                        let v9 = ""
                        Us0LineGot(v9, 1)
                    }
                    False -> {
                        let v11 = v1 == v3
                        case v11 {
                            True -> {
                                let v12 = v3 > 0
                                let v16 =
                                    case v12 {
                                        True -> {
                                            let v13 = spiral_wrap_signed(v3 - 1, 32)
                                            let v14 = kino_text_at(v0, v13, 1)
                                            let v15 = v14 == "\n"
                                            v15
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v16 {
                                    True -> {
                                        let v17 = spiral_wrap_signed(v3 + 1, 32)
                                        let v18 = ""
                                        Us0LineGot(v18, v17)
                                    }
                                    False -> {
                                        Us0LineDone
                                    }
                                }
                            }
                            False -> {
                                let v22 = "\n"
                                let v23 = find_char_3(v0, v1, v22)
                                let v24 = v23 < 0
                                case v24 {
                                    True -> {
                                        let v25 = spiral_wrap_signed(v3 - 1, 32)
                                        let v26 = spiral_wrap_signed(v25 - v1, 32)
                                        let v27 = spiral_wrap_signed(v26 + 1, 32)
                                        let v28 = kino_text_at(v0, v1, v27)
                                        Us0LineGot(v28, v3)
                                    }
                                    False -> {
                                        let v30 = v23 == v1
                                        case v30 {
                                            True -> {
                                                let v31 = spiral_wrap_signed(v23 + 1, 32)
                                                let v32 = ""
                                                Us0LineGot(v32, v31)
                                            }
                                            False -> {
                                                let v34 = spiral_wrap_signed(v23 - 1, 32)
                                                let v35 = spiral_wrap_signed(v34 - v1, 32)
                                                let v36 = spiral_wrap_signed(v35 + 1, 32)
                                                let v37 = kino_text_at(v0, v1, v36)
                                                let v38 = spiral_wrap_signed(v23 + 1, 32)
                                                Us0LineGot(v37, v38)
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
    case v44  {
        Us0LineDone -> {
            let v45 = Uh4NoRow
            rev_rows_58(v2, v45)
        }
        Us0LineGot(v47, v48) -> {
            let v49 = kino_text_size(v47)
            let v50 = trim_end_18(v47, v49)
            let v51 = kino_text_size(v47)
            let v52 = v50 < v51
            let v53 =
                case v52 {
                    True -> {
                        v50
                    }
                    False -> {
                        v51
                    }
                }
            let v54 = v53 <= 0
            let v59 =
                case v54 {
                    True -> {
                        let v55 = ""
                        v55
                    }
                    False -> {
                        let v56 = spiral_wrap_signed(v53 - 1, 32)
                        let v57 = spiral_wrap_signed(v56 + 1, 32)
                        let v58 = kino_text_at(v47, 0, v57)
                        v58
                    }
                }
            let v60 = kino_text_size(v59)
            let v61 = " (test)"
            let v62 = kino_text_size(v61)
            let v63 = v60 >= v62
            let v79 =
                case v63 {
                    True -> {
                        let v64 = spiral_wrap_signed(v60 - v62, 32)
                        let v65 = kino_text_size(v61)
                        let v66 = v64 < 0
                        case v66 {
                            True -> {
                                False
                            }
                            False -> {
                                let v67 = spiral_wrap_signed(v64 + v65, 32)
                                let v68 = kino_text_size(v59)
                                let v69 = v67 > v68
                                case v69 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v70 = v65 == 0
                                        case v70 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v71 = spiral_wrap_signed(v67 - 1, 32)
                                                let v72 = spiral_wrap_signed(v71 - v64, 32)
                                                let v73 = spiral_wrap_signed(v72 + 1, 32)
                                                let v74 = kino_text_at(v59, v64, v73)
                                                let v75 = v74 == " (test)"
                                                v75
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    False -> {
                        False
                    }
                }
            case v79 {
                True -> {
                    md_go_57(v0, v48, v2)
                }
                False -> {
                    let v81 = v59 == ""
                    let v109 =
                        case v81 {
                            True -> {
                                let v82 = "/// "
                                v82
                            }
                            False -> {
                                let v83 = 0
                                let v84 = lead_ws_59(v59, v83)
                                let v85 = kino_text_size(v59)
                                let v86 = v84 >= v85
                                case v86 {
                                    True -> {
                                        v59
                                    }
                                    False -> {
                                        let v87 = kino_text_size(v59)
                                        let v88 = v84 < v87
                                        let v89 =
                                            case v88 {
                                                True -> {
                                                    v84
                                                }
                                                False -> {
                                                    v87
                                                }
                                            }
                                        let v90 = v89 <= 0
                                        let v95 =
                                            case v90 {
                                                True -> {
                                                    let v91 = ""
                                                    v91
                                                }
                                                False -> {
                                                    let v92 = spiral_wrap_signed(v89 - 1, 32)
                                                    let v93 = spiral_wrap_signed(v92 + 1, 32)
                                                    let v94 = kino_text_at(v59, 0, v93)
                                                    v94
                                                }
                                            }
                                        let v96 = { v95 } <> { "/// " }
                                        let v97 = kino_text_size(v59)
                                        let v98 = v84 >= v97
                                        let v106 =
                                            case v98 {
                                                True -> {
                                                    let v99 = ""
                                                    v99
                                                }
                                                False -> {
                                                    let v100 = v84 <= 0
                                                    case v100 {
                                                        True -> {
                                                            v59
                                                        }
                                                        False -> {
                                                            let v101 = spiral_wrap_signed(v97 - 1, 32)
                                                            let v102 = spiral_wrap_signed(v101 - v84, 32)
                                                            let v103 = spiral_wrap_signed(v102 + 1, 32)
                                                            let v104 = kino_text_at(v59, v84, v103)
                                                            v104
                                                        }
                                                    }
                                                }
                                            }
                                        let v107 = { v96 } <> { v106 }
                                        v107
                                    }
                                }
                            }
                        }
                    let v110 = Uh4Row(v109, v2)
                    md_go_57(v0, v48, v110)
                }
            }
        }
    }
}
pub fn join_rows_60(v0: Uh4) -> String {
    case v0  {
        Uh4NoRow -> {
            let v1 = ""
            v1
        }
        Uh4Row(v2, v3) -> {
            case v3  {
                Uh4NoRow -> {
                    v2
                }
                _ -> {
                    let v4 = { v2 } <> { "\n" }
                    let v5 = join_rows_60(v3)
                    let v6 = { v4 } <> { v5 }
                    v6
                }
            }
        }
    }
}
pub fn formatted_56(v0: Uh3, v1: Uh3) -> Uh3 {
    case v0  {
        Uh3Cell(v4, v5, v6) -> {
            let v7 = 0
            let v8 = trim_start_17(v5, v7)
            let v9 = kino_text_size(v5)
            let v10 = trim_end_18(v5, v9)
            let v11 = v10 <= v8
            let v17 =
                case v11 {
                    True -> {
                        let v12 = ""
                        v12
                    }
                    False -> {
                        let v13 = spiral_wrap_signed(v10 - 1, 32)
                        let v14 = spiral_wrap_signed(v13 - v8, 32)
                        let v15 = spiral_wrap_signed(v14 + 1, 32)
                        let v16 = kino_text_at(v5, v8, v15)
                        v16
                    }
                }
            let v18 = v4 == "markdown"
            let v41 =
                case v18 {
                    True -> {
                        let v19 = 0
                        let v20 = Uh4NoRow
                        let v21 = md_go_57(v17, v19, v20)
                        join_rows_60(v21)
                    }
                    False -> {
                        let v23 = v4 == "test"
                        case v23 {
                            True -> {
                                v17
                            }
                            False -> {
                                let v24 = "///- "
                                let v25 = 0
                                let v26 = find_from_1(v17, v24, v25)
                                let v27 = v26 >= 0
                                let v37 =
                                    case v27 {
                                        True -> {
                                            let v28 = " --test"
                                            let v29 = 0
                                            let v30 = find_from_1(v17, v28, v29)
                                            let v31 = v30 >= 0
                                            case v31 {
                                                True -> {
                                                    True
                                                }
                                                False -> {
                                                    let v32 = " --ignore"
                                                    let v33 = 0
                                                    let v34 = find_from_1(v17, v32, v33)
                                                    let v35 = v34 >= 0
                                                    v35
                                                }
                                            }
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v37 {
                                    True -> {
                                        let v38 = ""
                                        v38
                                    }
                                    False -> {
                                        v17
                                    }
                                }
                            }
                        }
                    }
                }
            let v42 = v41 == ""
            case v42 {
                True -> {
                    formatted_56(v6, v1)
                }
                False -> {
                    let v44 = Uh3Cell(v4, v41, v1)
                    formatted_56(v6, v44)
                }
            }
        }
        Uh3NoCell -> {
            let v2 = Uh3NoCell
            rev_cells_50(v1, v2)
        }
    }
}
pub fn emit_spi_61(v0: Uh3) -> String {
    case v0  {
        Uh3Cell(v2, v3, v4) -> {
            case v4  {
                Uh3Cell(v6, v7, v8) -> {
                    let v9 = v2 == "markdown"
                    let v12 =
                        case v9 {
                            True -> {
                                let v10 = v6 == "markdown"
                                let v11 = v10 != True
                                v11
                            }
                            False -> {
                                False
                            }
                        }
                    let v15 =
                        case v12 {
                            True -> {
                                let v13 = ""
                                v13
                            }
                            False -> {
                                let v14 = "\n"
                                v14
                            }
                        }
                    let v16 = { v3 } <> { v15 }
                    let v17 = { v16 } <> { "\n" }
                    let v18 = emit_spi_61(v4)
                    let v19 = { v17 } <> { v18 }
                    v19
                }
                Uh3NoCell -> {
                    let v5 = { v3 } <> { "\n" }
                    v5
                }
            }
        }
        Uh3NoCell -> {
            let v1 = ""
            v1
        }
    }
}
pub fn closure6(capt: Nil) -> fn(String) -> String {
    fn (v0) {
        let v1 = Us3SpiExport
        let v2 = kino_text_size(v0)
        let v3 = 0 > v2
        let v40 =
            case v3 {
                True -> {
                    Us0LineDone
                }
                False -> {
                    let v5 = v2 == 0
                    case v5 {
                        True -> {
                            let v6 = ""
                            Us0LineGot(v6, 1)
                        }
                        False -> {
                            let v8 = 0 == v2
                            case v8 {
                                True -> {
                                    let v9 = v2 > 0
                                    let v13 =
                                        case v9 {
                                            True -> {
                                                let v10 = spiral_wrap_signed(v2 - 1, 32)
                                                let v11 = kino_text_at(v0, v10, 1)
                                                let v12 = v11 == "\n"
                                                v12
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    case v13 {
                                        True -> {
                                            let v14 = spiral_wrap_signed(v2 + 1, 32)
                                            let v15 = ""
                                            Us0LineGot(v15, v14)
                                        }
                                        False -> {
                                            Us0LineDone
                                        }
                                    }
                                }
                                False -> {
                                    let v19 = 0
                                    let v20 = "\n"
                                    let v21 = find_char_3(v0, v19, v20)
                                    let v22 = v21 < 0
                                    case v22 {
                                        True -> {
                                            let v23 = spiral_wrap_signed(v2 - 1, 32)
                                            let v24 = spiral_wrap_signed(v23 + 1, 32)
                                            let v25 = kino_text_at(v0, 0, v24)
                                            Us0LineGot(v25, v2)
                                        }
                                        False -> {
                                            let v27 = v21 == 0
                                            case v27 {
                                                True -> {
                                                    let v28 = spiral_wrap_signed(v21 + 1, 32)
                                                    let v29 = ""
                                                    Us0LineGot(v29, v28)
                                                }
                                                False -> {
                                                    let v31 = spiral_wrap_signed(v21 - 1, 32)
                                                    let v32 = spiral_wrap_signed(v31 + 1, 32)
                                                    let v33 = kino_text_at(v0, 0, v32)
                                                    let v34 = spiral_wrap_signed(v21 + 1, 32)
                                                    Us0LineGot(v33, v34)
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
        let v51 =
            case v40  {
                Us0LineDone -> {
                    Uh3NoCell
                }
                Us0LineGot(v42, v43) -> {
                    let v44 = 0
                    let v45 = 0
                    let v46 = 0
                    let v47 = parse_acc_26(v42, v44, v45, v46)
                    let v48 = Uh3NoCell
                    read_cells_53(v0, v43, v47, v48)
                }
            }
        let v52 = Uh3NoCell
        let v53 = export_blocks_54(v1, v51, v52)
        let v54 = keep_docs_55(v53)
        let v55 = Uh3NoCell
        let v56 = formatted_56(v54, v55)
        emit_spi_61(v56)
    }
}
pub fn closure7(capt: Nil) -> fn(String) -> String {
    fn (v0) {
        let v1 = Us3SpirExport
        let v2 = kino_text_size(v0)
        let v3 = 0 > v2
        let v40 =
            case v3 {
                True -> {
                    Us0LineDone
                }
                False -> {
                    let v5 = v2 == 0
                    case v5 {
                        True -> {
                            let v6 = ""
                            Us0LineGot(v6, 1)
                        }
                        False -> {
                            let v8 = 0 == v2
                            case v8 {
                                True -> {
                                    let v9 = v2 > 0
                                    let v13 =
                                        case v9 {
                                            True -> {
                                                let v10 = spiral_wrap_signed(v2 - 1, 32)
                                                let v11 = kino_text_at(v0, v10, 1)
                                                let v12 = v11 == "\n"
                                                v12
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    case v13 {
                                        True -> {
                                            let v14 = spiral_wrap_signed(v2 + 1, 32)
                                            let v15 = ""
                                            Us0LineGot(v15, v14)
                                        }
                                        False -> {
                                            Us0LineDone
                                        }
                                    }
                                }
                                False -> {
                                    let v19 = 0
                                    let v20 = "\n"
                                    let v21 = find_char_3(v0, v19, v20)
                                    let v22 = v21 < 0
                                    case v22 {
                                        True -> {
                                            let v23 = spiral_wrap_signed(v2 - 1, 32)
                                            let v24 = spiral_wrap_signed(v23 + 1, 32)
                                            let v25 = kino_text_at(v0, 0, v24)
                                            Us0LineGot(v25, v2)
                                        }
                                        False -> {
                                            let v27 = v21 == 0
                                            case v27 {
                                                True -> {
                                                    let v28 = spiral_wrap_signed(v21 + 1, 32)
                                                    let v29 = ""
                                                    Us0LineGot(v29, v28)
                                                }
                                                False -> {
                                                    let v31 = spiral_wrap_signed(v21 - 1, 32)
                                                    let v32 = spiral_wrap_signed(v31 + 1, 32)
                                                    let v33 = kino_text_at(v0, 0, v32)
                                                    let v34 = spiral_wrap_signed(v21 + 1, 32)
                                                    Us0LineGot(v33, v34)
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
        let v51 =
            case v40  {
                Us0LineDone -> {
                    Uh3NoCell
                }
                Us0LineGot(v42, v43) -> {
                    let v44 = 0
                    let v45 = 0
                    let v46 = 0
                    let v47 = parse_acc_26(v42, v44, v45, v46)
                    let v48 = Uh3NoCell
                    read_cells_53(v0, v43, v47, v48)
                }
            }
        let v52 = Uh3NoCell
        let v53 = export_blocks_54(v1, v51, v52)
        let v54 = keep_docs_55(v53)
        let v55 = Uh3NoCell
        let v56 = formatted_56(v54, v55)
        emit_spi_61(v56)
    }
}
pub fn last_heading_line_63(v0: String, v1: Int, v2: String) -> String {
    let v3 = kino_text_size(v0)
    let v4 = v1 > v3
    let v44 =
        case v4 {
            True -> {
                Us0LineDone
            }
            False -> {
                let v6 = v3 == 0
                let v8 =
                    case v6 {
                        True -> {
                            let v7 = v1 == 0
                            v7
                        }
                        False -> {
                            False
                        }
                    }
                case v8 {
                    True -> {
                        let v9 = ""
                        Us0LineGot(v9, 1)
                    }
                    False -> {
                        let v11 = v1 == v3
                        case v11 {
                            True -> {
                                let v12 = v3 > 0
                                let v16 =
                                    case v12 {
                                        True -> {
                                            let v13 = spiral_wrap_signed(v3 - 1, 32)
                                            let v14 = kino_text_at(v0, v13, 1)
                                            let v15 = v14 == "\n"
                                            v15
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v16 {
                                    True -> {
                                        let v17 = spiral_wrap_signed(v3 + 1, 32)
                                        let v18 = ""
                                        Us0LineGot(v18, v17)
                                    }
                                    False -> {
                                        Us0LineDone
                                    }
                                }
                            }
                            False -> {
                                let v22 = "\n"
                                let v23 = find_char_3(v0, v1, v22)
                                let v24 = v23 < 0
                                case v24 {
                                    True -> {
                                        let v25 = spiral_wrap_signed(v3 - 1, 32)
                                        let v26 = spiral_wrap_signed(v25 - v1, 32)
                                        let v27 = spiral_wrap_signed(v26 + 1, 32)
                                        let v28 = kino_text_at(v0, v1, v27)
                                        Us0LineGot(v28, v3)
                                    }
                                    False -> {
                                        let v30 = v23 == v1
                                        case v30 {
                                            True -> {
                                                let v31 = spiral_wrap_signed(v23 + 1, 32)
                                                let v32 = ""
                                                Us0LineGot(v32, v31)
                                            }
                                            False -> {
                                                let v34 = spiral_wrap_signed(v23 - 1, 32)
                                                let v35 = spiral_wrap_signed(v34 - v1, 32)
                                                let v36 = spiral_wrap_signed(v35 + 1, 32)
                                                let v37 = kino_text_at(v0, v1, v36)
                                                let v38 = spiral_wrap_signed(v23 + 1, 32)
                                                Us0LineGot(v37, v38)
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
    case v44  {
        Us0LineDone -> {
            v2
        }
        Us0LineGot(v45, v46) -> {
            let v47 = 0
            let v48 = trim_start_17(v45, v47)
            let v49 = kino_text_size(v45)
            let v50 = trim_end_18(v45, v49)
            let v51 = v50 <= v48
            let v57 =
                case v51 {
                    True -> {
                        let v52 = ""
                        v52
                    }
                    False -> {
                        let v53 = spiral_wrap_signed(v50 - 1, 32)
                        let v54 = spiral_wrap_signed(v53 - v48, 32)
                        let v55 = spiral_wrap_signed(v54 + 1, 32)
                        let v56 = kino_text_at(v45, v48, v55)
                        v56
                    }
                }
            let v58 = "#"
            let v59 = kino_text_size(v58)
            let v60 = kino_text_size(v57)
            let v61 = v59 > v60
            let v68 =
                case v61 {
                    True -> {
                        False
                    }
                    False -> {
                        let v62 = v59 == 0
                        case v62 {
                            True -> {
                                True
                            }
                            False -> {
                                let v63 = spiral_wrap_signed(v59 - 1, 32)
                                let v64 = spiral_wrap_signed(v63 + 1, 32)
                                let v65 = kino_text_at(v57, 0, v64)
                                let v66 = v65 == "#"
                                v66
                            }
                        }
                    }
                }
            case v68 {
                True -> {
                    last_heading_line_63(v0, v46, v45)
                }
                False -> {
                    last_heading_line_63(v0, v46, v2)
                }
            }
        }
    }
}
pub fn replace_from_64(v0: String, v1: String, v2: String, v3: Int) -> String {
    let v4 = find_from_1(v0, v1, v3)
    let v5 = v4 < 0
    case v5 {
        True -> {
            let v6 = v3 == 0
            case v6 {
                True -> {
                    v0
                }
                False -> {
                    let v7 = kino_text_size(v0)
                    let v8 = v3 >= v7
                    let v16 =
                        case v8 {
                            True -> {
                                let v9 = ""
                                v9
                            }
                            False -> {
                                let v10 = v3 <= 0
                                case v10 {
                                    True -> {
                                        v0
                                    }
                                    False -> {
                                        let v11 = spiral_wrap_signed(v7 - 1, 32)
                                        let v12 = spiral_wrap_signed(v11 - v3, 32)
                                        let v13 = spiral_wrap_signed(v12 + 1, 32)
                                        let v14 = kino_text_at(v0, v3, v13)
                                        v14
                                    }
                                }
                            }
                        }
                    let v17 = { v2 } <> { v16 }
                    v17
                }
            }
        }
        False -> {
            let v19 = kino_text_size(v1)
            let v20 = spiral_wrap_signed(v4 + v19, 32)
            let v21 = spiral_wrap_signed(v4 - v3, 32)
            let v22 = v21 <= 0
            let v41 =
                case v22 {
                    True -> {
                        let v23 = ""
                        v23
                    }
                    False -> {
                        let v24 = kino_text_size(v0)
                        let v25 = v3 >= v24
                        case v25 {
                            True -> {
                                let v26 = ""
                                v26
                            }
                            False -> {
                                let v27 = spiral_wrap_signed(v3 + v21, 32)
                                let v28 = spiral_wrap_signed(v27 - 1, 32)
                                let v29 = kino_text_size(v0)
                                let v30 = v28 >= v29
                                let v33 =
                                    case v30 {
                                        True -> {
                                            let v31 = kino_text_size(v0)
                                            let v32 = spiral_wrap_signed(v31 - 1, 32)
                                            v32
                                        }
                                        False -> {
                                            v28
                                        }
                                    }
                                let v34 = v33 < v3
                                case v34 {
                                    True -> {
                                        let v35 = ""
                                        v35
                                    }
                                    False -> {
                                        let v36 = spiral_wrap_signed(v33 - v3, 32)
                                        let v37 = spiral_wrap_signed(v36 + 1, 32)
                                        let v38 = kino_text_at(v0, v3, v37)
                                        v38
                                    }
                                }
                            }
                        }
                    }
                }
            let v42 = { v2 } <> { v41 }
            let v43 = { v42 } <> { v2 }
            replace_from_0(v0, v1, v2, v20, v43)
        }
    }
}
pub fn test_name_go_65(v0: String, v1: Int, v2: Bool, v3: String) -> String {
    let v4 = kino_text_size(v0)
    let v5 = v1 >= v4
    case v5 {
        True -> {
            v3
        }
        False -> {
            let v6 = kino_text_byte(v0, v1)
            let v7 = v6 >= 128
            case v7 {
                True -> {
                    let v8 = kino_text_byte(v0, v1)
                    let v9 = v8 < 128
                    let v14 =
                        case v9 {
                            True -> {
                                1
                            }
                            False -> {
                                let v10 = v8 < 224
                                case v10 {
                                    True -> {
                                        2
                                    }
                                    False -> {
                                        let v11 = v8 < 240
                                        case v11 {
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
                    let v15 = kino_text_byte(v0, v1)
                    let v16 = v15 < 128
                    let v21 =
                        case v16 {
                            True -> {
                                1
                            }
                            False -> {
                                let v17 = v15 < 224
                                case v17 {
                                    True -> {
                                        2
                                    }
                                    False -> {
                                        let v18 = v15 < 240
                                        case v18 {
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
                    let v22 = v21 == 1
                    let v78 =
                        case v22 {
                            True -> {
                                v15
                            }
                            False -> {
                                let v23 = v21 == 2
                                case v23 {
                                    True -> {
                                        let v24 = spiral_wrap_signed(v15 - 192, 32)
                                        let v25 = spiral_wrap_signed(v24 * 64, 32)
                                        let v26 = spiral_wrap_signed(v1 + 1, 32)
                                        let v27 = kino_text_size(v0)
                                        let v28 = v26 < v27
                                        let v31 =
                                            case v28 {
                                                True -> {
                                                    let v29 = kino_text_byte(v0, v26)
                                                    let v30 = spiral_wrap_signed(v29 - 128, 32)
                                                    v30
                                                }
                                                False -> {
                                                    0
                                                }
                                            }
                                        let v32 = spiral_wrap_signed(v25 + v31, 32)
                                        v32
                                    }
                                    False -> {
                                        let v33 = v21 == 3
                                        case v33 {
                                            True -> {
                                                let v34 = spiral_wrap_signed(v15 - 224, 32)
                                                let v35 = spiral_wrap_signed(v34 * 4096, 32)
                                                let v36 = spiral_wrap_signed(v1 + 1, 32)
                                                let v37 = kino_text_size(v0)
                                                let v38 = v36 < v37
                                                let v41 =
                                                    case v38 {
                                                        True -> {
                                                            let v39 = kino_text_byte(v0, v36)
                                                            let v40 = spiral_wrap_signed(v39 - 128, 32)
                                                            v40
                                                        }
                                                        False -> {
                                                            0
                                                        }
                                                    }
                                                let v42 = spiral_wrap_signed(v41 * 64, 32)
                                                let v43 = spiral_wrap_signed(v35 + v42, 32)
                                                let v44 = spiral_wrap_signed(v1 + 2, 32)
                                                let v45 = kino_text_size(v0)
                                                let v46 = v44 < v45
                                                let v49 =
                                                    case v46 {
                                                        True -> {
                                                            let v47 = kino_text_byte(v0, v44)
                                                            let v48 = spiral_wrap_signed(v47 - 128, 32)
                                                            v48
                                                        }
                                                        False -> {
                                                            0
                                                        }
                                                    }
                                                let v50 = spiral_wrap_signed(v43 + v49, 32)
                                                v50
                                            }
                                            False -> {
                                                let v51 = spiral_wrap_signed(v15 - 240, 32)
                                                let v52 = spiral_wrap_signed(v51 * 262144, 32)
                                                let v53 = spiral_wrap_signed(v1 + 1, 32)
                                                let v54 = kino_text_size(v0)
                                                let v55 = v53 < v54
                                                let v58 =
                                                    case v55 {
                                                        True -> {
                                                            let v56 = kino_text_byte(v0, v53)
                                                            let v57 = spiral_wrap_signed(v56 - 128, 32)
                                                            v57
                                                        }
                                                        False -> {
                                                            0
                                                        }
                                                    }
                                                let v59 = spiral_wrap_signed(v58 * 4096, 32)
                                                let v60 = spiral_wrap_signed(v52 + v59, 32)
                                                let v61 = spiral_wrap_signed(v1 + 2, 32)
                                                let v62 = kino_text_size(v0)
                                                let v63 = v61 < v62
                                                let v66 =
                                                    case v63 {
                                                        True -> {
                                                            let v64 = kino_text_byte(v0, v61)
                                                            let v65 = spiral_wrap_signed(v64 - 128, 32)
                                                            v65
                                                        }
                                                        False -> {
                                                            0
                                                        }
                                                    }
                                                let v67 = spiral_wrap_signed(v66 * 64, 32)
                                                let v68 = spiral_wrap_signed(v60 + v67, 32)
                                                let v69 = spiral_wrap_signed(v1 + 3, 32)
                                                let v70 = kino_text_size(v0)
                                                let v71 = v69 < v70
                                                let v74 =
                                                    case v71 {
                                                        True -> {
                                                            let v72 = kino_text_byte(v0, v69)
                                                            let v73 = spiral_wrap_signed(v72 - 128, 32)
                                                            v73
                                                        }
                                                        False -> {
                                                            0
                                                        }
                                                    }
                                                let v75 = spiral_wrap_signed(v68 + v74, 32)
                                                v75
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v79 = v78 >= 192
                    let v81 =
                        case v79 {
                            True -> {
                                let v80 = v78 <= 591
                                v80
                            }
                            False -> {
                                False
                            }
                        }
                    let v84 =
                        case v81 {
                            True -> {
                                let v82 = v78 == 215
                                let v83 = v82 != True
                                v83
                            }
                            False -> {
                                False
                            }
                        }
                    let v87 =
                        case v84 {
                            True -> {
                                let v85 = v78 == 247
                                let v86 = v85 != True
                                v86
                            }
                            False -> {
                                False
                            }
                        }
                    let v94 =
                        case v87 {
                            True -> {
                                True
                            }
                            False -> {
                                let v88 = v78 >= 902
                                let v90 =
                                    case v88 {
                                        True -> {
                                            let v89 = v78 <= 1013
                                            v89
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v90 {
                                    True -> {
                                        let v91 = v78 == 903
                                        let v92 = v91 != True
                                        v92
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            }
                        }
                    let v102 =
                        case v94 {
                            True -> {
                                True
                            }
                            False -> {
                                let v95 = v78 >= 1024
                                let v97 =
                                    case v95 {
                                        True -> {
                                            let v96 = v78 <= 1153
                                            v96
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v97 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v98 = v78 >= 1162
                                        case v98 {
                                            True -> {
                                                let v99 = v78 <= 1327
                                                v99
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v110 =
                        case v102 {
                            True -> {
                                True
                            }
                            False -> {
                                let v103 = v78 >= 1329
                                let v105 =
                                    case v103 {
                                        True -> {
                                            let v104 = v78 <= 1366
                                            v104
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v105 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v106 = v78 >= 1377
                                        case v106 {
                                            True -> {
                                                let v107 = v78 <= 1415
                                                v107
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v118 =
                        case v110 {
                            True -> {
                                True
                            }
                            False -> {
                                let v111 = v78 >= 1488
                                let v113 =
                                    case v111 {
                                        True -> {
                                            let v112 = v78 <= 1514
                                            v112
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v113 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v114 = v78 >= 1568
                                        case v114 {
                                            True -> {
                                                let v115 = v78 <= 1610
                                                v115
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v130 =
                        case v118 {
                            True -> {
                                True
                            }
                            False -> {
                                let v119 = v78 >= 4352
                                let v121 =
                                    case v119 {
                                        True -> {
                                            let v120 = v78 <= 4607
                                            v120
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                let v125 =
                                    case v121 {
                                        True -> {
                                            True
                                        }
                                        False -> {
                                            let v122 = v78 >= 12593
                                            case v122 {
                                                True -> {
                                                    let v123 = v78 <= 12686
                                                    v123
                                                }
                                                False -> {
                                                    False
                                                }
                                            }
                                        }
                                    }
                                case v125 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v126 = v78 >= 44032
                                        case v126 {
                                            True -> {
                                                let v127 = v78 <= 55203
                                                v127
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v142 =
                        case v130 {
                            True -> {
                                True
                            }
                            False -> {
                                let v131 = v78 >= 12353
                                let v133 =
                                    case v131 {
                                        True -> {
                                            let v132 = v78 <= 12438
                                            v132
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                let v137 =
                                    case v133 {
                                        True -> {
                                            True
                                        }
                                        False -> {
                                            let v134 = v78 >= 12449
                                            case v134 {
                                                True -> {
                                                    let v135 = v78 <= 12538
                                                    v135
                                                }
                                                False -> {
                                                    False
                                                }
                                            }
                                        }
                                    }
                                case v137 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v138 = v78 >= 19968
                                        case v138 {
                                            True -> {
                                                let v139 = v78 <= 40959
                                                v139
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    case v142 {
                        True -> {
                            let v143 = spiral_wrap_signed(v1 + v14, 32)
                            let v144 = False
                            let v145 = v14 <= 0
                            let v163 =
                                case v145 {
                                    True -> {
                                        let v146 = ""
                                        v146
                                    }
                                    False -> {
                                        let v147 = kino_text_size(v0)
                                        let v148 = v1 >= v147
                                        case v148 {
                                            True -> {
                                                let v149 = ""
                                                v149
                                            }
                                            False -> {
                                                let v150 = spiral_wrap_signed(v143 - 1, 32)
                                                let v151 = kino_text_size(v0)
                                                let v152 = v150 >= v151
                                                let v155 =
                                                    case v152 {
                                                        True -> {
                                                            let v153 = kino_text_size(v0)
                                                            let v154 = spiral_wrap_signed(v153 - 1, 32)
                                                            v154
                                                        }
                                                        False -> {
                                                            v150
                                                        }
                                                    }
                                                let v156 = v155 < v1
                                                case v156 {
                                                    True -> {
                                                        let v157 = ""
                                                        v157
                                                    }
                                                    False -> {
                                                        let v158 = spiral_wrap_signed(v155 - v1, 32)
                                                        let v159 = spiral_wrap_signed(v158 + 1, 32)
                                                        let v160 = kino_text_at(v0, v1, v159)
                                                        v160
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            let v164 = kino_text_lower(v163)
                            let v167 =
                                case v2 {
                                    True -> {
                                        let v165 = v3 == ""
                                        let v166 = v165 != True
                                        v166
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            let v170 =
                                case v167 {
                                    True -> {
                                        let v168 = "_"
                                        v168
                                    }
                                    False -> {
                                        let v169 = ""
                                        v169
                                    }
                                }
                            let v171 = { v3 } <> { v170 }
                            let v172 = { v171 } <> { v164 }
                            test_name_go_65(v0, v143, v144, v172)
                        }
                        False -> {
                            let v174 = spiral_wrap_signed(v1 + v14, 32)
                            let v175 = True
                            test_name_go_65(v0, v174, v175, v3)
                        }
                    }
                }
                False -> {
                    let v178 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_"
                    let v179 = 0
                    let v180 = kino_text_at(v0, v1, 1)
                    let v181 = has_char_12(v178, v179, v180)
                    case v181 {
                        True -> {
                            let v182 = spiral_wrap_signed(v1 + 1, 32)
                            let v183 = False
                            let v184 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                            let v185 = 0
                            let v186 = kino_text_at(v0, v1, 1)
                            let v187 = find_char_3(v184, v185, v186)
                            let v188 = v187 >= 0
                            let v192 =
                                case v188 {
                                    True -> {
                                        let v189 = "abcdefghijklmnopqrstuvwxyz"
                                        let v190 = kino_text_at(v189, v187, 1)
                                        v190
                                    }
                                    False -> {
                                        let v191 = kino_text_at(v0, v1, 1)
                                        v191
                                    }
                                }
                            let v195 =
                                case v2 {
                                    True -> {
                                        let v193 = v3 == ""
                                        let v194 = v193 != True
                                        v194
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            let v198 =
                                case v195 {
                                    True -> {
                                        let v196 = "_"
                                        v196
                                    }
                                    False -> {
                                        let v197 = ""
                                        v197
                                    }
                                }
                            let v199 = { v3 } <> { v198 }
                            let v200 = { v199 } <> { v192 }
                            test_name_go_65(v0, v182, v183, v200)
                        }
                        False -> {
                            let v202 = spiral_wrap_signed(v1 + 1, 32)
                            let v203 = True
                            test_name_go_65(v0, v202, v203, v3)
                        }
                    }
                }
            }
        }
    }
}
pub fn underscore_start_66(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 < v2
    let v6 =
        case v3 {
            True -> {
                let v4 = kino_text_at(v0, v1, 1)
                let v5 = v4 == "_"
                v5
            }
            False -> {
                False
            }
        }
    case v6 {
        True -> {
            let v7 = spiral_wrap_signed(v1 + 1, 32)
            underscore_start_66(v0, v7)
        }
        False -> {
            v1
        }
    }
}
pub fn underscore_end_67(v0: String, v1: Int) -> Int {
    let v2 = v1 > 0
    let v6 =
        case v2 {
            True -> {
                let v3 = spiral_wrap_signed(v1 - 1, 32)
                let v4 = kino_text_at(v0, v3, 1)
                let v5 = v4 == "_"
                v5
            }
            False -> {
                False
            }
        }
    case v6 {
        True -> {
            let v7 = spiral_wrap_signed(v1 - 1, 32)
            underscore_end_67(v0, v7)
        }
        False -> {
            v1
        }
    }
}
pub fn count_row_68(v0: Uh4, v1: String) -> Int {
    case v0  {
        Uh4NoRow -> {
            0
        }
        Uh4Row(v2, v3) -> {
            let v4 = v2 == v1
            case v4 {
                True -> {
                    let v5 = count_row_68(v3, v1)
                    let v6 = spiral_wrap_signed(1 + v5, 32)
                    v6
                }
                False -> {
                    count_row_68(v3, v1)
                }
            }
        }
    }
}
pub fn drop_blank_rows_70(v0: Uh4) -> Uh4 {
    case v0  {
        Uh4NoRow -> {
            Uh4NoRow
        }
        Uh4Row(v2, v3) -> {
            let v4 = 0
            let v5 = trim_start_17(v2, v4)
            let v6 = kino_text_size(v2)
            let v7 = trim_end_18(v2, v6)
            let v8 = v7 <= v5
            let v14 =
                case v8 {
                    True -> {
                        let v9 = ""
                        v9
                    }
                    False -> {
                        let v10 = spiral_wrap_signed(v7 - 1, 32)
                        let v11 = spiral_wrap_signed(v10 - v5, 32)
                        let v12 = spiral_wrap_signed(v11 + 1, 32)
                        let v13 = kino_text_at(v2, v5, v12)
                        v13
                    }
                }
            let v15 = v14 == ""
            case v15 {
                True -> {
                    drop_blank_rows_70(v3)
                }
                False -> {
                    v0
                }
            }
        }
    }
}
pub fn append_rows_71(v0: Uh4, v1: Uh4) -> Uh4 {
    case v0  {
        Uh4NoRow -> {
            v1
        }
        Uh4Row(v2, v3) -> {
            let v4 = append_rows_71(v3, v1)
            Uh4Row(v2, v4)
        }
    }
}
pub fn test_block_go_69(v0: String, v1: Int, v2: Uh4, v3: String, v4: Uh4, v5: String) -> String {
    let v6 = kino_text_size(v0)
    let v7 = v1 > v6
    let v47 =
        case v7 {
            True -> {
                Us0LineDone
            }
            False -> {
                let v9 = v6 == 0
                let v11 =
                    case v9 {
                        True -> {
                            let v10 = v1 == 0
                            v10
                        }
                        False -> {
                            False
                        }
                    }
                case v11 {
                    True -> {
                        let v12 = ""
                        Us0LineGot(v12, 1)
                    }
                    False -> {
                        let v14 = v1 == v6
                        case v14 {
                            True -> {
                                let v15 = v6 > 0
                                let v19 =
                                    case v15 {
                                        True -> {
                                            let v16 = spiral_wrap_signed(v6 - 1, 32)
                                            let v17 = kino_text_at(v0, v16, 1)
                                            let v18 = v17 == "\n"
                                            v18
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v19 {
                                    True -> {
                                        let v20 = spiral_wrap_signed(v6 + 1, 32)
                                        let v21 = ""
                                        Us0LineGot(v21, v20)
                                    }
                                    False -> {
                                        Us0LineDone
                                    }
                                }
                            }
                            False -> {
                                let v25 = "\n"
                                let v26 = find_char_3(v0, v1, v25)
                                let v27 = v26 < 0
                                case v27 {
                                    True -> {
                                        let v28 = spiral_wrap_signed(v6 - 1, 32)
                                        let v29 = spiral_wrap_signed(v28 - v1, 32)
                                        let v30 = spiral_wrap_signed(v29 + 1, 32)
                                        let v31 = kino_text_at(v0, v1, v30)
                                        Us0LineGot(v31, v6)
                                    }
                                    False -> {
                                        let v33 = v26 == v1
                                        case v33 {
                                            True -> {
                                                let v34 = spiral_wrap_signed(v26 + 1, 32)
                                                let v35 = ""
                                                Us0LineGot(v35, v34)
                                            }
                                            False -> {
                                                let v37 = spiral_wrap_signed(v26 - 1, 32)
                                                let v38 = spiral_wrap_signed(v37 - v1, 32)
                                                let v39 = spiral_wrap_signed(v38 + 1, 32)
                                                let v40 = kino_text_at(v0, v1, v39)
                                                let v41 = spiral_wrap_signed(v26 + 1, 32)
                                                Us0LineGot(v40, v41)
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
    case v47  {
        Us0LineDone -> {
            let v48 = { "test " } <> { v5 }
            let v49 = { " " } <> { v3 }
            let v50 = { v49 } <> { " " }
            let v51 = " static "
            let v52 = 0
            let v53 = find_from_1(v50, v51, v52)
            let v54 = v53 >= 0
            let v57 =
                case v54 {
                    True -> {
                        let v55 = " static"
                        v55
                    }
                    False -> {
                        let v56 = ""
                        v56
                    }
                }
            let v58 = { v48 } <> { v57 }
            let v59 = " --print-code "
            let v60 = 0
            let v61 = find_from_1(v50, v59, v60)
            let v62 = v61 >= 0
            let v65 =
                case v62 {
                    True -> {
                        let v63 = " print_code"
                        v63
                    }
                    False -> {
                        let v64 = ""
                        v64
                    }
                }
            let v66 = { v58 } <> { v65 }
            let v67 = " --ignore "
            let v68 = 0
            let v69 = find_from_1(v50, v67, v68)
            let v70 = v69 >= 0
            let v73 =
                case v70 {
                    True -> {
                        let v71 = " ignore"
                        v71
                    }
                    False -> {
                        let v72 = ""
                        v72
                    }
                }
            let v74 = { v66 } <> { v73 }
            let v75 = { v74 } <> { " =" }
            let v76 = drop_blank_rows_70(v4)
            let v77 = Uh4NoRow
            let v78 = rev_rows_58(v76, v77)
            let v79 = Uh4NoRow
            let v80 = rev_rows_58(v2, v79)
            let v81 = Uh4Row(v75, v78)
            let v82 = append_rows_71(v80, v81)
            join_rows_60(v82)
        }
        Us0LineGot(v84, v85) -> {
            let v86 = "///-"
            let v87 = kino_text_size(v86)
            let v88 = kino_text_size(v84)
            let v89 = v87 > v88
            let v96 =
                case v89 {
                    True -> {
                        False
                    }
                    False -> {
                        let v90 = v87 == 0
                        case v90 {
                            True -> {
                                True
                            }
                            False -> {
                                let v91 = spiral_wrap_signed(v87 - 1, 32)
                                let v92 = spiral_wrap_signed(v91 + 1, 32)
                                let v93 = kino_text_at(v84, 0, v92)
                                let v94 = v93 == "///-"
                                v94
                            }
                        }
                    }
                }
            case v96 {
                True -> {
                    let v97 = { v3 } <> { " " }
                    let v98 = kino_text_size(v84)
                    let v99 = 4 >= v98
                    let v105 =
                        case v99 {
                            True -> {
                                let v100 = ""
                                v100
                            }
                            False -> {
                                let v101 = spiral_wrap_signed(v98 - 1, 32)
                                let v102 = spiral_wrap_signed(v101 - 4, 32)
                                let v103 = spiral_wrap_signed(v102 + 1, 32)
                                let v104 = kino_text_at(v84, 4, v103)
                                v104
                            }
                        }
                    let v106 = 0
                    let v107 = trim_start_17(v105, v106)
                    let v108 = kino_text_size(v105)
                    let v109 = trim_end_18(v105, v108)
                    let v110 = v109 <= v107
                    let v116 =
                        case v110 {
                            True -> {
                                let v111 = ""
                                v111
                            }
                            False -> {
                                let v112 = spiral_wrap_signed(v109 - 1, 32)
                                let v113 = spiral_wrap_signed(v112 - v107, 32)
                                let v114 = spiral_wrap_signed(v113 + 1, 32)
                                let v115 = kino_text_at(v105, v107, v114)
                                v115
                            }
                        }
                    let v117 = { v97 } <> { v116 }
                    test_block_go_69(v0, v85, v2, v117, v4, v5)
                }
                False -> {
                    let v119 = "///>"
                    let v120 = kino_text_size(v119)
                    let v121 = kino_text_size(v84)
                    let v122 = v120 > v121
                    let v129 =
                        case v122 {
                            True -> {
                                False
                            }
                            False -> {
                                let v123 = v120 == 0
                                case v123 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v124 = spiral_wrap_signed(v120 - 1, 32)
                                        let v125 = spiral_wrap_signed(v124 + 1, 32)
                                        let v126 = kino_text_at(v84, 0, v125)
                                        let v127 = v126 == "///>"
                                        v127
                                    }
                                }
                            }
                        }
                    case v129 {
                        True -> {
                            let v130 = Uh4Row(v84, v2)
                            test_block_go_69(v0, v85, v130, v3, v4, v5)
                        }
                        False -> {
                            case v4  {
                                Uh4NoRow -> {
                                    let v132 = 0
                                    let v133 = trim_start_17(v84, v132)
                                    let v134 = kino_text_size(v84)
                                    let v135 = trim_end_18(v84, v134)
                                    let v136 = v135 <= v133
                                    let v142 =
                                        case v136 {
                                            True -> {
                                                let v137 = ""
                                                v137
                                            }
                                            False -> {
                                                let v138 = spiral_wrap_signed(v135 - 1, 32)
                                                let v139 = spiral_wrap_signed(v138 - v133, 32)
                                                let v140 = spiral_wrap_signed(v139 + 1, 32)
                                                let v141 = kino_text_at(v84, v133, v140)
                                                v141
                                            }
                                        }
                                    let v143 = v142 == ""
                                    case v143 {
                                        True -> {
                                            let v144 = Uh4NoRow
                                            test_block_go_69(v0, v85, v2, v3, v144, v5)
                                        }
                                        False -> {
                                            let v146 = 0
                                            let v147 = trim_start_17(v84, v146)
                                            let v148 = kino_text_size(v84)
                                            let v149 = trim_end_18(v84, v148)
                                            let v150 = v149 <= v147
                                            let v156 =
                                                case v150 {
                                                    True -> {
                                                        let v151 = ""
                                                        v151
                                                    }
                                                    False -> {
                                                        let v152 = spiral_wrap_signed(v149 - 1, 32)
                                                        let v153 = spiral_wrap_signed(v152 - v147, 32)
                                                        let v154 = spiral_wrap_signed(v153 + 1, 32)
                                                        let v155 = kino_text_at(v84, v147, v154)
                                                        v155
                                                    }
                                                }
                                            let v157 = v156 == ""
                                            let v160 =
                                                case v157 {
                                                    True -> {
                                                        let v158 = ""
                                                        v158
                                                    }
                                                    False -> {
                                                        let v159 = { "    " } <> { v84 }
                                                        v159
                                                    }
                                                }
                                            let v161 = Uh4NoRow
                                            let v162 = Uh4Row(v160, v161)
                                            test_block_go_69(v0, v85, v2, v3, v162, v5)
                                        }
                                    }
                                }
                                _ -> {
                                    let v165 = 0
                                    let v166 = trim_start_17(v84, v165)
                                    let v167 = kino_text_size(v84)
                                    let v168 = trim_end_18(v84, v167)
                                    let v169 = v168 <= v166
                                    let v175 =
                                        case v169 {
                                            True -> {
                                                let v170 = ""
                                                v170
                                            }
                                            False -> {
                                                let v171 = spiral_wrap_signed(v168 - 1, 32)
                                                let v172 = spiral_wrap_signed(v171 - v166, 32)
                                                let v173 = spiral_wrap_signed(v172 + 1, 32)
                                                let v174 = kino_text_at(v84, v166, v173)
                                                v174
                                            }
                                        }
                                    let v176 = v175 == ""
                                    let v179 =
                                        case v176 {
                                            True -> {
                                                let v177 = ""
                                                v177
                                            }
                                            False -> {
                                                let v178 = { "    " } <> { v84 }
                                                v178
                                            }
                                        }
                                    let v180 = Uh4Row(v179, v4)
                                    test_block_go_69(v0, v85, v2, v3, v180, v5)
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
pub fn name_tests_62(v0: Uh3, v1: String, v2: Uh4, v3: Uh3) -> Uh3 {
    case v0  {
        Uh3Cell(v6, v7, v8) -> {
            let v9 = v6 == "markdown"
            case v9 {
                True -> {
                    let v10 = 0
                    let v11 = trim_start_17(v7, v10)
                    let v12 = kino_text_size(v7)
                    let v13 = trim_end_18(v7, v12)
                    let v14 = v13 <= v11
                    let v20 =
                        case v14 {
                            True -> {
                                let v15 = ""
                                v15
                            }
                            False -> {
                                let v16 = spiral_wrap_signed(v13 - 1, 32)
                                let v17 = spiral_wrap_signed(v16 - v11, 32)
                                let v18 = spiral_wrap_signed(v17 + 1, 32)
                                let v19 = kino_text_at(v7, v11, v18)
                                v19
                            }
                        }
                    let v21 = 0
                    let v22 = ""
                    let v23 = last_heading_line_63(v20, v21, v22)
                    let v24 = v23 == ""
                    let v55 =
                        case v24 {
                            True -> {
                                v22
                            }
                            False -> {
                                let v25 = " (test)"
                                let v26 = 0
                                let v27 = replace_from_64(v23, v25, v22, v26)
                                let v28 = 0
                                let v29 = False
                                let v30 = test_name_go_65(v27, v28, v29, v22)
                                let v31 = 0
                                let v32 = underscore_start_66(v30, v31)
                                let v33 = kino_text_size(v30)
                                let v34 = underscore_end_67(v30, v33)
                                let v35 = v34 <= v32
                                case v35 {
                                    True -> {
                                        v22
                                    }
                                    False -> {
                                        let v36 = spiral_wrap_signed(v34 - v32, 32)
                                        let v37 = v36 <= 0
                                        case v37 {
                                            True -> {
                                                v22
                                            }
                                            False -> {
                                                let v38 = kino_text_size(v30)
                                                let v39 = v32 >= v38
                                                case v39 {
                                                    True -> {
                                                        v22
                                                    }
                                                    False -> {
                                                        let v40 = spiral_wrap_signed(v32 + v36, 32)
                                                        let v41 = spiral_wrap_signed(v40 - 1, 32)
                                                        let v42 = kino_text_size(v30)
                                                        let v43 = v41 >= v42
                                                        let v46 =
                                                            case v43 {
                                                                True -> {
                                                                    let v44 = kino_text_size(v30)
                                                                    let v45 = spiral_wrap_signed(v44 - 1, 32)
                                                                    v45
                                                                }
                                                                False -> {
                                                                    v41
                                                                }
                                                            }
                                                        let v47 = v46 < v32
                                                        case v47 {
                                                            True -> {
                                                                v22
                                                            }
                                                            False -> {
                                                                let v48 = spiral_wrap_signed(v46 - v32, 32)
                                                                let v49 = spiral_wrap_signed(v48 + 1, 32)
                                                                let v50 = kino_text_at(v30, v32, v49)
                                                                v50
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
                    let v56 = v55 == ""
                    let v57 =
                        case v56 {
                            True -> {
                                v1
                            }
                            False -> {
                                v55
                            }
                        }
                    let v58 = Uh3Cell(v6, v7, v3)
                    name_tests_62(v8, v57, v2, v58)
                }
                False -> {
                    let v60 = 0
                    let v61 = trim_start_17(v7, v60)
                    let v62 = kino_text_size(v7)
                    let v63 = trim_end_18(v7, v62)
                    let v64 = v63 <= v61
                    let v70 =
                        case v64 {
                            True -> {
                                let v65 = ""
                                v65
                            }
                            False -> {
                                let v66 = spiral_wrap_signed(v63 - 1, 32)
                                let v67 = spiral_wrap_signed(v66 - v61, 32)
                                let v68 = spiral_wrap_signed(v67 + 1, 32)
                                let v69 = kino_text_at(v7, v61, v68)
                                v69
                            }
                        }
                    let v71 = "///- "
                    let v72 = 0
                    let v73 = find_from_1(v70, v71, v72)
                    let v74 = v73 >= 0
                    let v84 =
                        case v74 {
                            True -> {
                                let v75 = " --test"
                                let v76 = 0
                                let v77 = find_from_1(v70, v75, v76)
                                let v78 = v77 >= 0
                                case v78 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v79 = " --ignore"
                                        let v80 = 0
                                        let v81 = find_from_1(v70, v79, v80)
                                        let v82 = v81 >= 0
                                        v82
                                    }
                                }
                            }
                            False -> {
                                False
                            }
                        }
                    case v84 {
                        True -> {
                            let v85 = v1 == ""
                            let v87 =
                                case v85 {
                                    True -> {
                                        let v86 = "cell"
                                        v86
                                    }
                                    False -> {
                                        v1
                                    }
                                }
                            let v88 = count_row_68(v2, v87)
                            let v89 = v88 == 0
                            let v94 =
                                case v89 {
                                    True -> {
                                        v87
                                    }
                                    False -> {
                                        let v90 = { v87 } <> { "_" }
                                        let v91 = spiral_wrap_signed(v88 + 1, 32)
                                        let v92 = show_i32_20(v91)
                                        let v93 = { v90 } <> { v92 }
                                        v93
                                    }
                                }
                            let v95 = Uh4Row(v87, v2)
                            let v96 = 0
                            let v97 = trim_start_17(v7, v96)
                            let v98 = kino_text_size(v7)
                            let v99 = trim_end_18(v7, v98)
                            let v100 = v99 <= v97
                            let v106 =
                                case v100 {
                                    True -> {
                                        let v101 = ""
                                        v101
                                    }
                                    False -> {
                                        let v102 = spiral_wrap_signed(v99 - 1, 32)
                                        let v103 = spiral_wrap_signed(v102 - v97, 32)
                                        let v104 = spiral_wrap_signed(v103 + 1, 32)
                                        let v105 = kino_text_at(v7, v97, v104)
                                        v105
                                    }
                                }
                            let v107 = 0
                            let v108 = Uh4NoRow
                            let v109 = ""
                            let v110 = Uh4NoRow
                            let v111 = test_block_go_69(v106, v107, v108, v109, v110, v94)
                            let v112 = "test"
                            let v113 = Uh3Cell(v112, v111, v3)
                            name_tests_62(v8, v1, v95, v113)
                        }
                        False -> {
                            let v115 = Uh3Cell(v6, v7, v3)
                            name_tests_62(v8, v1, v2, v115)
                        }
                    }
                }
            }
        }
        Uh3NoCell -> {
            let v4 = Uh3NoCell
            rev_cells_50(v3, v4)
        }
    }
}
pub fn closure8(capt: Nil) -> fn(String) -> String {
    fn (v0) {
        let v1 = Us3SpiExport
        let v2 = kino_text_size(v0)
        let v3 = 0 > v2
        let v40 =
            case v3 {
                True -> {
                    Us0LineDone
                }
                False -> {
                    let v5 = v2 == 0
                    case v5 {
                        True -> {
                            let v6 = ""
                            Us0LineGot(v6, 1)
                        }
                        False -> {
                            let v8 = 0 == v2
                            case v8 {
                                True -> {
                                    let v9 = v2 > 0
                                    let v13 =
                                        case v9 {
                                            True -> {
                                                let v10 = spiral_wrap_signed(v2 - 1, 32)
                                                let v11 = kino_text_at(v0, v10, 1)
                                                let v12 = v11 == "\n"
                                                v12
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    case v13 {
                                        True -> {
                                            let v14 = spiral_wrap_signed(v2 + 1, 32)
                                            let v15 = ""
                                            Us0LineGot(v15, v14)
                                        }
                                        False -> {
                                            Us0LineDone
                                        }
                                    }
                                }
                                False -> {
                                    let v19 = 0
                                    let v20 = "\n"
                                    let v21 = find_char_3(v0, v19, v20)
                                    let v22 = v21 < 0
                                    case v22 {
                                        True -> {
                                            let v23 = spiral_wrap_signed(v2 - 1, 32)
                                            let v24 = spiral_wrap_signed(v23 + 1, 32)
                                            let v25 = kino_text_at(v0, 0, v24)
                                            Us0LineGot(v25, v2)
                                        }
                                        False -> {
                                            let v27 = v21 == 0
                                            case v27 {
                                                True -> {
                                                    let v28 = spiral_wrap_signed(v21 + 1, 32)
                                                    let v29 = ""
                                                    Us0LineGot(v29, v28)
                                                }
                                                False -> {
                                                    let v31 = spiral_wrap_signed(v21 - 1, 32)
                                                    let v32 = spiral_wrap_signed(v31 + 1, 32)
                                                    let v33 = kino_text_at(v0, 0, v32)
                                                    let v34 = spiral_wrap_signed(v21 + 1, 32)
                                                    Us0LineGot(v33, v34)
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
        let v51 =
            case v40  {
                Us0LineDone -> {
                    Uh3NoCell
                }
                Us0LineGot(v42, v43) -> {
                    let v44 = 0
                    let v45 = 0
                    let v46 = 0
                    let v47 = parse_acc_26(v42, v44, v45, v46)
                    let v48 = Uh3NoCell
                    read_cells_53(v0, v43, v47, v48)
                }
            }
        let v52 = Uh3NoCell
        let v53 = export_blocks_54(v1, v51, v52)
        let v54 = ""
        let v55 = Uh4NoRow
        let v56 = Uh3NoCell
        let v57 = name_tests_62(v53, v54, v55, v56)
        let v58 = keep_docs_55(v57)
        let v59 = Uh3NoCell
        let v60 = formatted_56(v58, v59)
        emit_spi_61(v60)
    }
}
pub fn closure9(capt: Nil) -> fn(String) -> String {
    fn (v0) {
        let v1 = Us3SpirExport
        let v2 = kino_text_size(v0)
        let v3 = 0 > v2
        let v40 =
            case v3 {
                True -> {
                    Us0LineDone
                }
                False -> {
                    let v5 = v2 == 0
                    case v5 {
                        True -> {
                            let v6 = ""
                            Us0LineGot(v6, 1)
                        }
                        False -> {
                            let v8 = 0 == v2
                            case v8 {
                                True -> {
                                    let v9 = v2 > 0
                                    let v13 =
                                        case v9 {
                                            True -> {
                                                let v10 = spiral_wrap_signed(v2 - 1, 32)
                                                let v11 = kino_text_at(v0, v10, 1)
                                                let v12 = v11 == "\n"
                                                v12
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    case v13 {
                                        True -> {
                                            let v14 = spiral_wrap_signed(v2 + 1, 32)
                                            let v15 = ""
                                            Us0LineGot(v15, v14)
                                        }
                                        False -> {
                                            Us0LineDone
                                        }
                                    }
                                }
                                False -> {
                                    let v19 = 0
                                    let v20 = "\n"
                                    let v21 = find_char_3(v0, v19, v20)
                                    let v22 = v21 < 0
                                    case v22 {
                                        True -> {
                                            let v23 = spiral_wrap_signed(v2 - 1, 32)
                                            let v24 = spiral_wrap_signed(v23 + 1, 32)
                                            let v25 = kino_text_at(v0, 0, v24)
                                            Us0LineGot(v25, v2)
                                        }
                                        False -> {
                                            let v27 = v21 == 0
                                            case v27 {
                                                True -> {
                                                    let v28 = spiral_wrap_signed(v21 + 1, 32)
                                                    let v29 = ""
                                                    Us0LineGot(v29, v28)
                                                }
                                                False -> {
                                                    let v31 = spiral_wrap_signed(v21 - 1, 32)
                                                    let v32 = spiral_wrap_signed(v31 + 1, 32)
                                                    let v33 = kino_text_at(v0, 0, v32)
                                                    let v34 = spiral_wrap_signed(v21 + 1, 32)
                                                    Us0LineGot(v33, v34)
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
        let v51 =
            case v40  {
                Us0LineDone -> {
                    Uh3NoCell
                }
                Us0LineGot(v42, v43) -> {
                    let v44 = 0
                    let v45 = 0
                    let v46 = 0
                    let v47 = parse_acc_26(v42, v44, v45, v46)
                    let v48 = Uh3NoCell
                    read_cells_53(v0, v43, v47, v48)
                }
            }
        let v52 = Uh3NoCell
        let v53 = export_blocks_54(v1, v51, v52)
        let v54 = ""
        let v55 = Uh4NoRow
        let v56 = Uh3NoCell
        let v57 = name_tests_62(v53, v54, v55, v56)
        let v58 = keep_docs_55(v57)
        let v59 = Uh3NoCell
        let v60 = formatted_56(v58, v59)
        emit_spi_61(v60)
    }
}
pub fn take_unicode_ident_74(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = kino_text_byte(v0, v1)
            let v5 = v4 >= 128
            case v5 {
                True -> {
                    let v6 = spiral_wrap_signed(v1 + 1, 32)
                    take_unicode_ident_74(v0, v6)
                }
                False -> {
                    let v8 = kino_text_at(v0, v1, 1)
                    let v9 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_'"
                    let v10 = 0
                    let v11 = has_char_12(v9, v10, v8)
                    case v11 {
                        True -> {
                            let v12 = spiral_wrap_signed(v1 + 1, 32)
                            take_unicode_ident_74(v0, v12)
                        }
                        False -> {
                            v1
                        }
                    }
                }
            }
        }
    }
}
pub fn modes_valid_75(v0: String) -> Bool {
    let v1 = v0 == ""
    case v1 {
        True -> {
            True
        }
        False -> {
            let v2 = " static"
            let v3 = kino_text_size(v2)
            let v4 = kino_text_size(v0)
            let v5 = v3 > v4
            let v12 =
                case v5 {
                    True -> {
                        False
                    }
                    False -> {
                        let v6 = v3 == 0
                        case v6 {
                            True -> {
                                True
                            }
                            False -> {
                                let v7 = spiral_wrap_signed(v3 - 1, 32)
                                let v8 = spiral_wrap_signed(v7 + 1, 32)
                                let v9 = kino_text_at(v0, 0, v8)
                                let v10 = v9 == " static"
                                v10
                            }
                        }
                    }
                }
            case v12 {
                True -> {
                    let v13 = kino_text_size(v0)
                    let v14 = 7 >= v13
                    let v20 =
                        case v14 {
                            True -> {
                                let v15 = ""
                                v15
                            }
                            False -> {
                                let v16 = spiral_wrap_signed(v13 - 1, 32)
                                let v17 = spiral_wrap_signed(v16 - 7, 32)
                                let v18 = spiral_wrap_signed(v17 + 1, 32)
                                let v19 = kino_text_at(v0, 7, v18)
                                v19
                            }
                        }
                    modes_valid_75(v20)
                }
                False -> {
                    let v22 = " print_code"
                    let v23 = kino_text_size(v22)
                    let v24 = kino_text_size(v0)
                    let v25 = v23 > v24
                    let v32 =
                        case v25 {
                            True -> {
                                False
                            }
                            False -> {
                                let v26 = v23 == 0
                                case v26 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v27 = spiral_wrap_signed(v23 - 1, 32)
                                        let v28 = spiral_wrap_signed(v27 + 1, 32)
                                        let v29 = kino_text_at(v0, 0, v28)
                                        let v30 = v29 == " print_code"
                                        v30
                                    }
                                }
                            }
                        }
                    case v32 {
                        True -> {
                            let v33 = kino_text_size(v0)
                            let v34 = 11 >= v33
                            let v40 =
                                case v34 {
                                    True -> {
                                        let v35 = ""
                                        v35
                                    }
                                    False -> {
                                        let v36 = spiral_wrap_signed(v33 - 1, 32)
                                        let v37 = spiral_wrap_signed(v36 - 11, 32)
                                        let v38 = spiral_wrap_signed(v37 + 1, 32)
                                        let v39 = kino_text_at(v0, 11, v38)
                                        v39
                                    }
                                }
                            modes_valid_75(v40)
                        }
                        False -> {
                            let v42 = " ignore"
                            let v43 = kino_text_size(v42)
                            let v44 = kino_text_size(v0)
                            let v45 = v43 > v44
                            let v52 =
                                case v45 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v46 = v43 == 0
                                        case v46 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v47 = spiral_wrap_signed(v43 - 1, 32)
                                                let v48 = spiral_wrap_signed(v47 + 1, 32)
                                                let v49 = kino_text_at(v0, 0, v48)
                                                let v50 = v49 == " ignore"
                                                v50
                                            }
                                        }
                                    }
                                }
                            case v52 {
                                True -> {
                                    let v53 = kino_text_size(v0)
                                    let v54 = 7 >= v53
                                    let v60 =
                                        case v54 {
                                            True -> {
                                                let v55 = ""
                                                v55
                                            }
                                            False -> {
                                                let v56 = spiral_wrap_signed(v53 - 1, 32)
                                                let v57 = spiral_wrap_signed(v56 - 7, 32)
                                                let v58 = spiral_wrap_signed(v57 + 1, 32)
                                                let v59 = kino_text_at(v0, 7, v58)
                                                v59
                                            }
                                        }
                                    modes_valid_75(v60)
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
    }
}
pub fn open_step_73(v0: String, v1: Uh4, v2: Uh4, v3: Bool, v4: Uh3) -> #(Us4, Uh4, Uh3) {
    let v5 = "///>"
    let v6 = kino_text_size(v5)
    let v7 = kino_text_size(v0)
    let v8 = v6 > v7
    let v15 =
        case v8 {
            True -> {
                False
            }
            False -> {
                let v9 = v6 == 0
                case v9 {
                    True -> {
                        True
                    }
                    False -> {
                        let v10 = spiral_wrap_signed(v6 - 1, 32)
                        let v11 = spiral_wrap_signed(v10 + 1, 32)
                        let v12 = kino_text_at(v0, 0, v11)
                        let v13 = v12 == "///>"
                        v13
                    }
                }
            }
        }
    case v15 {
        True -> {
            let v16 =
                case v1  {
                    Uh4NoRow -> {
                        True
                    }
                    _ -> {
                        False
                    }
                }
            case v16 {
                True -> {
                    let v17 = Us4Between
                    let v18 = Uh4Row(v0, v2)
                    #(v17, v18, v4)
                }
                False -> {
                    let v19 = Us4InCode(v1)
                    let v20 = Uh4Row(v0, v2)
                    #(v19, v20, v4)
                }
            }
        }
        False -> {
            let v24 = "test "
            let v25 = kino_text_size(v24)
            let v26 = kino_text_size(v0)
            let v27 = v25 > v26
            let v34 =
                case v27 {
                    True -> {
                        False
                    }
                    False -> {
                        let v28 = v25 == 0
                        case v28 {
                            True -> {
                                True
                            }
                            False -> {
                                let v29 = spiral_wrap_signed(v25 - 1, 32)
                                let v30 = spiral_wrap_signed(v29 + 1, 32)
                                let v31 = kino_text_at(v0, 0, v30)
                                let v32 = v31 == "test "
                                v32
                            }
                        }
                    }
                }
            let v146 =
                case v34 {
                    True -> {
                        let v35 = 5
                        let v36 = take_unicode_ident_74(v0, v35)
                        let v37 = kino_text_size(v0)
                        let v38 = v36 >= v37
                        let v46 =
                            case v38 {
                                True -> {
                                    let v39 = ""
                                    v39
                                }
                                False -> {
                                    let v40 = v36 <= 0
                                    case v40 {
                                        True -> {
                                            v0
                                        }
                                        False -> {
                                            let v41 = spiral_wrap_signed(v37 - 1, 32)
                                            let v42 = spiral_wrap_signed(v41 - v36, 32)
                                            let v43 = spiral_wrap_signed(v42 + 1, 32)
                                            let v44 = kino_text_at(v0, v36, v43)
                                            v44
                                        }
                                    }
                                }
                            }
                        let v47 = kino_text_size(v0)
                        let v48 = v36 >= v47
                        let v56 =
                            case v48 {
                                True -> {
                                    let v49 = ""
                                    v49
                                }
                                False -> {
                                    let v50 = v36 <= 0
                                    case v50 {
                                        True -> {
                                            v0
                                        }
                                        False -> {
                                            let v51 = spiral_wrap_signed(v47 - 1, 32)
                                            let v52 = spiral_wrap_signed(v51 - v36, 32)
                                            let v53 = spiral_wrap_signed(v52 + 1, 32)
                                            let v54 = kino_text_at(v0, v36, v53)
                                            v54
                                        }
                                    }
                                }
                            }
                        let v57 = kino_text_size(v0)
                        let v58 = v36 >= v57
                        let v66 =
                            case v58 {
                                True -> {
                                    let v59 = ""
                                    v59
                                }
                                False -> {
                                    let v60 = v36 <= 0
                                    case v60 {
                                        True -> {
                                            v0
                                        }
                                        False -> {
                                            let v61 = spiral_wrap_signed(v57 - 1, 32)
                                            let v62 = spiral_wrap_signed(v61 - v36, 32)
                                            let v63 = spiral_wrap_signed(v62 + 1, 32)
                                            let v64 = kino_text_at(v0, v36, v63)
                                            v64
                                        }
                                    }
                                }
                            }
                        let v67 = kino_text_size(v66)
                        let v68 = trim_end_18(v56, v67)
                        let v69 = kino_text_size(v46)
                        let v70 = v68 < v69
                        let v71 =
                            case v70 {
                                True -> {
                                    v68
                                }
                                False -> {
                                    v69
                                }
                            }
                        let v72 = v71 <= 0
                        let v77 =
                            case v72 {
                                True -> {
                                    let v73 = ""
                                    v73
                                }
                                False -> {
                                    let v74 = spiral_wrap_signed(v71 - 1, 32)
                                    let v75 = spiral_wrap_signed(v74 + 1, 32)
                                    let v76 = kino_text_at(v46, 0, v75)
                                    v76
                                }
                            }
                        let v78 = kino_text_size(v77)
                        let v79 = v36 > 5
                        let v81 =
                            case v79 {
                                True -> {
                                    let v80 = v78 >= 2
                                    v80
                                }
                                False -> {
                                    False
                                }
                            }
                        let v98 =
                            case v81 {
                                True -> {
                                    let v82 = spiral_wrap_signed(v78 - 2, 32)
                                    let v83 = " ="
                                    let v84 = kino_text_size(v83)
                                    let v85 = v82 < 0
                                    case v85 {
                                        True -> {
                                            False
                                        }
                                        False -> {
                                            let v86 = spiral_wrap_signed(v82 + v84, 32)
                                            let v87 = kino_text_size(v77)
                                            let v88 = v86 > v87
                                            case v88 {
                                                True -> {
                                                    False
                                                }
                                                False -> {
                                                    let v89 = v84 == 0
                                                    case v89 {
                                                        True -> {
                                                            True
                                                        }
                                                        False -> {
                                                            let v90 = spiral_wrap_signed(v86 - 1, 32)
                                                            let v91 = spiral_wrap_signed(v90 - v82, 32)
                                                            let v92 = spiral_wrap_signed(v91 + 1, 32)
                                                            let v93 = kino_text_at(v77, v82, v92)
                                                            let v94 = v93 == " ="
                                                            v94
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                False -> {
                                    False
                                }
                            }
                        let v110 =
                            case v98 {
                                True -> {
                                    let v99 = spiral_wrap_signed(v78 - 2, 32)
                                    let v100 = kino_text_size(v77)
                                    let v101 = v99 < v100
                                    let v102 =
                                        case v101 {
                                            True -> {
                                                v99
                                            }
                                            False -> {
                                                v100
                                            }
                                        }
                                    let v103 = v102 <= 0
                                    let v108 =
                                        case v103 {
                                            True -> {
                                                let v104 = ""
                                                v104
                                            }
                                            False -> {
                                                let v105 = spiral_wrap_signed(v102 - 1, 32)
                                                let v106 = spiral_wrap_signed(v105 + 1, 32)
                                                let v107 = kino_text_at(v77, 0, v106)
                                                v107
                                            }
                                        }
                                    modes_valid_75(v108)
                                }
                                False -> {
                                    False
                                }
                            }
                        case v110 {
                            True -> {
                                let v111 = spiral_wrap_signed(v36 - 5, 32)
                                let v112 = v111 <= 0
                                let v131 =
                                    case v112 {
                                        True -> {
                                            let v113 = ""
                                            v113
                                        }
                                        False -> {
                                            let v114 = kino_text_size(v0)
                                            let v115 = 5 >= v114
                                            case v115 {
                                                True -> {
                                                    let v116 = ""
                                                    v116
                                                }
                                                False -> {
                                                    let v117 = spiral_wrap_signed(5 + v111, 32)
                                                    let v118 = spiral_wrap_signed(v117 - 1, 32)
                                                    let v119 = kino_text_size(v0)
                                                    let v120 = v118 >= v119
                                                    let v123 =
                                                        case v120 {
                                                            True -> {
                                                                let v121 = kino_text_size(v0)
                                                                let v122 = spiral_wrap_signed(v121 - 1, 32)
                                                                v122
                                                            }
                                                            False -> {
                                                                v118
                                                            }
                                                        }
                                                    let v124 = v123 < 5
                                                    case v124 {
                                                        True -> {
                                                            let v125 = ""
                                                            v125
                                                        }
                                                        False -> {
                                                            let v126 = spiral_wrap_signed(v123 - 5, 32)
                                                            let v127 = spiral_wrap_signed(v126 + 1, 32)
                                                            let v128 = kino_text_at(v0, 5, v127)
                                                            v128
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                let v132 = spiral_wrap_signed(v78 - 2, 32)
                                let v133 = kino_text_size(v77)
                                let v134 = v132 < v133
                                let v135 =
                                    case v134 {
                                        True -> {
                                            v132
                                        }
                                        False -> {
                                            v133
                                        }
                                    }
                                let v136 = v135 <= 0
                                let v141 =
                                    case v136 {
                                        True -> {
                                            let v137 = ""
                                            v137
                                        }
                                        False -> {
                                            let v138 = spiral_wrap_signed(v135 - 1, 32)
                                            let v139 = spiral_wrap_signed(v138 + 1, 32)
                                            let v140 = kino_text_at(v77, 0, v139)
                                            v140
                                        }
                                    }
                                Us5Header(v131, v141)
                            }
                            False -> {
                                Us5NoHeader
                            }
                        }
                    }
                    False -> {
                        Us5NoHeader
                    }
                }
            case v146  {
                Us5Header(v147, v148) -> {
                    let v149 =
                        case v1  {
                            Uh4NoRow -> {
                                True
                            }
                            _ -> {
                                False
                            }
                        }
                    let v241 =
                        case v149 {
                            True -> {
                                let v150 = Uh4NoRow
                                let v151 = Uh4NoRow
                                let v152 = rev_rows_58(v150, v151)
                                let v153 = join_rows_60(v152)
                                let v154 = 0
                                let v155 = trim_nl_start_29(v153, v154)
                                let v156 = kino_text_size(v153)
                                let v157 = trim_nl_end_30(v153, v156)
                                let v158 = v157 <= v155
                                let v164 =
                                    case v158 {
                                        True -> {
                                            let v159 = ""
                                            v159
                                        }
                                        False -> {
                                            let v160 = spiral_wrap_signed(v157 - 1, 32)
                                            let v161 = spiral_wrap_signed(v160 - v155, 32)
                                            let v162 = spiral_wrap_signed(v161 + 1, 32)
                                            let v163 = kino_text_at(v153, v155, v162)
                                            v163
                                        }
                                    }
                                let v165 = 0
                                let v166 = trim_start_17(v164, v165)
                                let v167 = kino_text_size(v164)
                                let v168 = trim_end_18(v164, v167)
                                let v169 = v168 <= v166
                                let v175 =
                                    case v169 {
                                        True -> {
                                            let v170 = ""
                                            v170
                                        }
                                        False -> {
                                            let v171 = spiral_wrap_signed(v168 - 1, 32)
                                            let v172 = spiral_wrap_signed(v171 - v166, 32)
                                            let v173 = spiral_wrap_signed(v172 + 1, 32)
                                            let v174 = kino_text_at(v164, v166, v173)
                                            v174
                                        }
                                    }
                                let v176 = v175 == ""
                                case v176 {
                                    True -> {
                                        v4
                                    }
                                    False -> {
                                        let v189 =
                                            case v3 {
                                                True -> {
                                                    let v177 = "///- --real"
                                                    let v178 = kino_text_size(v177)
                                                    let v179 = kino_text_size(v164)
                                                    let v180 = v178 > v179
                                                    let v187 =
                                                        case v180 {
                                                            True -> {
                                                                False
                                                            }
                                                            False -> {
                                                                let v181 = v178 == 0
                                                                case v181 {
                                                                    True -> {
                                                                        True
                                                                    }
                                                                    False -> {
                                                                        let v182 = spiral_wrap_signed(v178 - 1, 32)
                                                                        let v183 = spiral_wrap_signed(v182 + 1, 32)
                                                                        let v184 = kino_text_at(v164, 0, v183)
                                                                        let v185 = v184 == "///- --real"
                                                                        v185
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    let v188 = v187 == False
                                                    v188
                                                }
                                                False -> {
                                                    False
                                                }
                                            }
                                        let v191 =
                                            case v189 {
                                                True -> {
                                                    let v190 = { "///- --real\n\n" } <> { v164 }
                                                    v190
                                                }
                                                False -> {
                                                    v164
                                                }
                                            }
                                        let v192 = "spiral"
                                        Uh3Cell(v192, v191, v4)
                                    }
                                }
                            }
                            False -> {
                                let v195 = Uh4NoRow
                                let v196 = append_rows_71(v195, v1)
                                let v197 = Uh4NoRow
                                let v198 = rev_rows_58(v196, v197)
                                let v199 = join_rows_60(v198)
                                let v200 = 0
                                let v201 = trim_nl_start_29(v199, v200)
                                let v202 = kino_text_size(v199)
                                let v203 = trim_nl_end_30(v199, v202)
                                let v204 = v203 <= v201
                                let v210 =
                                    case v204 {
                                        True -> {
                                            let v205 = ""
                                            v205
                                        }
                                        False -> {
                                            let v206 = spiral_wrap_signed(v203 - 1, 32)
                                            let v207 = spiral_wrap_signed(v206 - v201, 32)
                                            let v208 = spiral_wrap_signed(v207 + 1, 32)
                                            let v209 = kino_text_at(v199, v201, v208)
                                            v209
                                        }
                                    }
                                let v211 = 0
                                let v212 = trim_start_17(v210, v211)
                                let v213 = kino_text_size(v210)
                                let v214 = trim_end_18(v210, v213)
                                let v215 = v214 <= v212
                                let v221 =
                                    case v215 {
                                        True -> {
                                            let v216 = ""
                                            v216
                                        }
                                        False -> {
                                            let v217 = spiral_wrap_signed(v214 - 1, 32)
                                            let v218 = spiral_wrap_signed(v217 - v212, 32)
                                            let v219 = spiral_wrap_signed(v218 + 1, 32)
                                            let v220 = kino_text_at(v210, v212, v219)
                                            v220
                                        }
                                    }
                                let v222 = v221 == ""
                                case v222 {
                                    True -> {
                                        v4
                                    }
                                    False -> {
                                        let v235 =
                                            case v3 {
                                                True -> {
                                                    let v223 = "///- --real"
                                                    let v224 = kino_text_size(v223)
                                                    let v225 = kino_text_size(v210)
                                                    let v226 = v224 > v225
                                                    let v233 =
                                                        case v226 {
                                                            True -> {
                                                                False
                                                            }
                                                            False -> {
                                                                let v227 = v224 == 0
                                                                case v227 {
                                                                    True -> {
                                                                        True
                                                                    }
                                                                    False -> {
                                                                        let v228 = spiral_wrap_signed(v224 - 1, 32)
                                                                        let v229 = spiral_wrap_signed(v228 + 1, 32)
                                                                        let v230 = kino_text_at(v210, 0, v229)
                                                                        let v231 = v230 == "///- --real"
                                                                        v231
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    let v234 = v233 == False
                                                    v234
                                                }
                                                False -> {
                                                    False
                                                }
                                            }
                                        let v237 =
                                            case v235 {
                                                True -> {
                                                    let v236 = { "///- --real\n\n" } <> { v210 }
                                                    v236
                                                }
                                                False -> {
                                                    v210
                                                }
                                            }
                                        let v238 = "spiral"
                                        Uh3Cell(v238, v237, v4)
                                    }
                                }
                            }
                        }
                    let v242 = Uh4NoRow
                    let v243 = Us4InTest(v147, v148, v2, v242)
                    let v244 = Uh4NoRow
                    #(v243, v244, v241)
                }
                Us5NoHeader -> {
                    let v245 = "/// "
                    let v246 = kino_text_size(v245)
                    let v247 = kino_text_size(v0)
                    let v248 = v246 > v247
                    let v255 =
                        case v248 {
                            True -> {
                                False
                            }
                            False -> {
                                let v249 = v246 == 0
                                case v249 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v250 = spiral_wrap_signed(v246 - 1, 32)
                                        let v251 = spiral_wrap_signed(v250 + 1, 32)
                                        let v252 = kino_text_at(v0, 0, v251)
                                        let v253 = v252 == "/// "
                                        v253
                                    }
                                }
                            }
                        }
                    let v257 =
                        case v255 {
                            True -> {
                                True
                            }
                            False -> {
                                let v256 = v0 == "///"
                                v256
                            }
                        }
                    case v257 {
                        True -> {
                            let v258 = 0
                            let v259 = lead_ws_59(v0, v258)
                            let v260 = kino_text_size(v245)
                            let v261 = v259 < 0
                            let v273 =
                                case v261 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v262 = spiral_wrap_signed(v259 + v260, 32)
                                        let v263 = kino_text_size(v0)
                                        let v264 = v262 > v263
                                        case v264 {
                                            True -> {
                                                False
                                            }
                                            False -> {
                                                let v265 = v260 == 0
                                                case v265 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v266 = spiral_wrap_signed(v262 - 1, 32)
                                                        let v267 = spiral_wrap_signed(v266 - v259, 32)
                                                        let v268 = spiral_wrap_signed(v267 + 1, 32)
                                                        let v269 = kino_text_at(v0, v259, v268)
                                                        let v270 = v269 == "/// "
                                                        v270
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            let v304 =
                                case v273 {
                                    True -> {
                                        let v274 = kino_text_size(v0)
                                        let v275 = v259 < v274
                                        let v276 =
                                            case v275 {
                                                True -> {
                                                    v259
                                                }
                                                False -> {
                                                    v274
                                                }
                                            }
                                        let v277 = v276 <= 0
                                        let v282 =
                                            case v277 {
                                                True -> {
                                                    let v278 = ""
                                                    v278
                                                }
                                                False -> {
                                                    let v279 = spiral_wrap_signed(v276 - 1, 32)
                                                    let v280 = spiral_wrap_signed(v279 + 1, 32)
                                                    let v281 = kino_text_at(v0, 0, v280)
                                                    v281
                                                }
                                            }
                                        let v283 = spiral_wrap_signed(v259 + 4, 32)
                                        let v284 = kino_text_size(v0)
                                        let v285 = v283 >= v284
                                        let v293 =
                                            case v285 {
                                                True -> {
                                                    let v286 = ""
                                                    v286
                                                }
                                                False -> {
                                                    let v287 = v283 <= 0
                                                    case v287 {
                                                        True -> {
                                                            v0
                                                        }
                                                        False -> {
                                                            let v288 = spiral_wrap_signed(v284 - 1, 32)
                                                            let v289 = spiral_wrap_signed(v288 - v283, 32)
                                                            let v290 = spiral_wrap_signed(v289 + 1, 32)
                                                            let v291 = kino_text_at(v0, v283, v290)
                                                            v291
                                                        }
                                                    }
                                                }
                                            }
                                        let v294 = { v282 } <> { v293 }
                                        v294
                                    }
                                    False -> {
                                        let v295 = kino_text_size(v0)
                                        let v296 = v259 < v295
                                        let v297 =
                                            case v296 {
                                                True -> {
                                                    v259
                                                }
                                                False -> {
                                                    v295
                                                }
                                            }
                                        let v298 = v297 <= 0
                                        case v298 {
                                            True -> {
                                                let v299 = ""
                                                v299
                                            }
                                            False -> {
                                                let v300 = spiral_wrap_signed(v297 - 1, 32)
                                                let v301 = spiral_wrap_signed(v300 + 1, 32)
                                                let v302 = kino_text_at(v0, 0, v301)
                                                v302
                                            }
                                        }
                                    }
                                }
                            let v305 =
                                case v1  {
                                    Uh4NoRow -> {
                                        True
                                    }
                                    _ -> {
                                        False
                                    }
                                }
                            let v395 =
                                case v305 {
                                    True -> {
                                        let v306 = Uh4NoRow
                                        let v307 = rev_rows_58(v2, v306)
                                        let v308 = join_rows_60(v307)
                                        let v309 = 0
                                        let v310 = trim_nl_start_29(v308, v309)
                                        let v311 = kino_text_size(v308)
                                        let v312 = trim_nl_end_30(v308, v311)
                                        let v313 = v312 <= v310
                                        let v319 =
                                            case v313 {
                                                True -> {
                                                    let v314 = ""
                                                    v314
                                                }
                                                False -> {
                                                    let v315 = spiral_wrap_signed(v312 - 1, 32)
                                                    let v316 = spiral_wrap_signed(v315 - v310, 32)
                                                    let v317 = spiral_wrap_signed(v316 + 1, 32)
                                                    let v318 = kino_text_at(v308, v310, v317)
                                                    v318
                                                }
                                            }
                                        let v320 = 0
                                        let v321 = trim_start_17(v319, v320)
                                        let v322 = kino_text_size(v319)
                                        let v323 = trim_end_18(v319, v322)
                                        let v324 = v323 <= v321
                                        let v330 =
                                            case v324 {
                                                True -> {
                                                    let v325 = ""
                                                    v325
                                                }
                                                False -> {
                                                    let v326 = spiral_wrap_signed(v323 - 1, 32)
                                                    let v327 = spiral_wrap_signed(v326 - v321, 32)
                                                    let v328 = spiral_wrap_signed(v327 + 1, 32)
                                                    let v329 = kino_text_at(v319, v321, v328)
                                                    v329
                                                }
                                            }
                                        let v331 = v330 == ""
                                        case v331 {
                                            True -> {
                                                v4
                                            }
                                            False -> {
                                                let v344 =
                                                    case v3 {
                                                        True -> {
                                                            let v332 = "///- --real"
                                                            let v333 = kino_text_size(v332)
                                                            let v334 = kino_text_size(v319)
                                                            let v335 = v333 > v334
                                                            let v342 =
                                                                case v335 {
                                                                    True -> {
                                                                        False
                                                                    }
                                                                    False -> {
                                                                        let v336 = v333 == 0
                                                                        case v336 {
                                                                            True -> {
                                                                                True
                                                                            }
                                                                            False -> {
                                                                                let v337 = spiral_wrap_signed(v333 - 1, 32)
                                                                                let v338 = spiral_wrap_signed(v337 + 1, 32)
                                                                                let v339 = kino_text_at(v319, 0, v338)
                                                                                let v340 = v339 == "///- --real"
                                                                                v340
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            let v343 = v342 == False
                                                            v343
                                                        }
                                                        False -> {
                                                            False
                                                        }
                                                    }
                                                let v346 =
                                                    case v344 {
                                                        True -> {
                                                            let v345 = { "///- --real\n\n" } <> { v319 }
                                                            v345
                                                        }
                                                        False -> {
                                                            v319
                                                        }
                                                    }
                                                let v347 = "spiral"
                                                Uh3Cell(v347, v346, v4)
                                            }
                                        }
                                    }
                                    False -> {
                                        let v350 = append_rows_71(v2, v1)
                                        let v351 = Uh4NoRow
                                        let v352 = rev_rows_58(v350, v351)
                                        let v353 = join_rows_60(v352)
                                        let v354 = 0
                                        let v355 = trim_nl_start_29(v353, v354)
                                        let v356 = kino_text_size(v353)
                                        let v357 = trim_nl_end_30(v353, v356)
                                        let v358 = v357 <= v355
                                        let v364 =
                                            case v358 {
                                                True -> {
                                                    let v359 = ""
                                                    v359
                                                }
                                                False -> {
                                                    let v360 = spiral_wrap_signed(v357 - 1, 32)
                                                    let v361 = spiral_wrap_signed(v360 - v355, 32)
                                                    let v362 = spiral_wrap_signed(v361 + 1, 32)
                                                    let v363 = kino_text_at(v353, v355, v362)
                                                    v363
                                                }
                                            }
                                        let v365 = 0
                                        let v366 = trim_start_17(v364, v365)
                                        let v367 = kino_text_size(v364)
                                        let v368 = trim_end_18(v364, v367)
                                        let v369 = v368 <= v366
                                        let v375 =
                                            case v369 {
                                                True -> {
                                                    let v370 = ""
                                                    v370
                                                }
                                                False -> {
                                                    let v371 = spiral_wrap_signed(v368 - 1, 32)
                                                    let v372 = spiral_wrap_signed(v371 - v366, 32)
                                                    let v373 = spiral_wrap_signed(v372 + 1, 32)
                                                    let v374 = kino_text_at(v364, v366, v373)
                                                    v374
                                                }
                                            }
                                        let v376 = v375 == ""
                                        case v376 {
                                            True -> {
                                                v4
                                            }
                                            False -> {
                                                let v389 =
                                                    case v3 {
                                                        True -> {
                                                            let v377 = "///- --real"
                                                            let v378 = kino_text_size(v377)
                                                            let v379 = kino_text_size(v364)
                                                            let v380 = v378 > v379
                                                            let v387 =
                                                                case v380 {
                                                                    True -> {
                                                                        False
                                                                    }
                                                                    False -> {
                                                                        let v381 = v378 == 0
                                                                        case v381 {
                                                                            True -> {
                                                                                True
                                                                            }
                                                                            False -> {
                                                                                let v382 = spiral_wrap_signed(v378 - 1, 32)
                                                                                let v383 = spiral_wrap_signed(v382 + 1, 32)
                                                                                let v384 = kino_text_at(v364, 0, v383)
                                                                                let v385 = v384 == "///- --real"
                                                                                v385
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            let v388 = v387 == False
                                                            v388
                                                        }
                                                        False -> {
                                                            False
                                                        }
                                                    }
                                                let v391 =
                                                    case v389 {
                                                        True -> {
                                                            let v390 = { "///- --real\n\n" } <> { v364 }
                                                            v390
                                                        }
                                                        False -> {
                                                            v364
                                                        }
                                                    }
                                                let v392 = "spiral"
                                                Uh3Cell(v392, v391, v4)
                                            }
                                        }
                                    }
                                }
                            let v396 = Uh4NoRow
                            let v397 = Uh4Row(v304, v396)
                            let v398 = Us4InDoc(v397)
                            let v399 = Uh4NoRow
                            #(v398, v399, v395)
                        }
                        False -> {
                            let v400 =
                                case v1  {
                                    Uh4NoRow -> {
                                        True
                                    }
                                    _ -> {
                                        False
                                    }
                                }
                            case v400 {
                                True -> {
                                    let v401 = v0 == ""
                                    let v403 =
                                        case v401 {
                                            True -> {
                                                case v2  {
                                                    Uh4NoRow -> {
                                                        True
                                                    }
                                                    _ -> {
                                                        False
                                                    }
                                                }
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    case v403 {
                                        True -> {
                                            let v404 = Us4Between
                                            let v405 = Uh4NoRow
                                            #(v404, v405, v4)
                                        }
                                        False -> {
                                            let v406 = Uh4Row(v0, v2)
                                            let v407 = Us4InCode(v406)
                                            let v408 = Uh4NoRow
                                            #(v407, v408, v4)
                                        }
                                    }
                                }
                                False -> {
                                    let v412 = append_rows_71(v2, v1)
                                    let v413 = Uh4Row(v0, v412)
                                    let v414 = Us4InCode(v413)
                                    let v415 = Uh4NoRow
                                    #(v414, v415, v4)
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
pub fn spi_walk_72(v0: String, v1: Int, v2: Us4, v3: Uh4, v4: Bool, v5: Uh3) -> Uh3 {
    let v6 = kino_text_size(v0)
    let v7 = v1 > v6
    let v47 =
        case v7 {
            True -> {
                Us0LineDone
            }
            False -> {
                let v9 = v6 == 0
                let v11 =
                    case v9 {
                        True -> {
                            let v10 = v1 == 0
                            v10
                        }
                        False -> {
                            False
                        }
                    }
                case v11 {
                    True -> {
                        let v12 = ""
                        Us0LineGot(v12, 1)
                    }
                    False -> {
                        let v14 = v1 == v6
                        case v14 {
                            True -> {
                                let v15 = v6 > 0
                                let v19 =
                                    case v15 {
                                        True -> {
                                            let v16 = spiral_wrap_signed(v6 - 1, 32)
                                            let v17 = kino_text_at(v0, v16, 1)
                                            let v18 = v17 == "\n"
                                            v18
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v19 {
                                    True -> {
                                        let v20 = spiral_wrap_signed(v6 + 1, 32)
                                        let v21 = ""
                                        Us0LineGot(v21, v20)
                                    }
                                    False -> {
                                        Us0LineDone
                                    }
                                }
                            }
                            False -> {
                                let v25 = "\n"
                                let v26 = find_char_3(v0, v1, v25)
                                let v27 = v26 < 0
                                case v27 {
                                    True -> {
                                        let v28 = spiral_wrap_signed(v6 - 1, 32)
                                        let v29 = spiral_wrap_signed(v28 - v1, 32)
                                        let v30 = spiral_wrap_signed(v29 + 1, 32)
                                        let v31 = kino_text_at(v0, v1, v30)
                                        Us0LineGot(v31, v6)
                                    }
                                    False -> {
                                        let v33 = v26 == v1
                                        case v33 {
                                            True -> {
                                                let v34 = spiral_wrap_signed(v26 + 1, 32)
                                                let v35 = ""
                                                Us0LineGot(v35, v34)
                                            }
                                            False -> {
                                                let v37 = spiral_wrap_signed(v26 - 1, 32)
                                                let v38 = spiral_wrap_signed(v37 - v1, 32)
                                                let v39 = spiral_wrap_signed(v38 + 1, 32)
                                                let v40 = kino_text_at(v0, v1, v39)
                                                let v41 = spiral_wrap_signed(v26 + 1, 32)
                                                Us0LineGot(v40, v41)
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
    case v47  {
        Us0LineDone -> {
            case v2  {
                Us4Between -> {
                    let v48 = Uh4NoRow
                    let v49 = rev_rows_58(v3, v48)
                    let v50 = join_rows_60(v49)
                    let v51 = 0
                    let v52 = trim_nl_start_29(v50, v51)
                    let v53 = kino_text_size(v50)
                    let v54 = trim_nl_end_30(v50, v53)
                    let v55 = v54 <= v52
                    let v61 =
                        case v55 {
                            True -> {
                                let v56 = ""
                                v56
                            }
                            False -> {
                                let v57 = spiral_wrap_signed(v54 - 1, 32)
                                let v58 = spiral_wrap_signed(v57 - v52, 32)
                                let v59 = spiral_wrap_signed(v58 + 1, 32)
                                let v60 = kino_text_at(v50, v52, v59)
                                v60
                            }
                        }
                    let v62 = 0
                    let v63 = trim_start_17(v61, v62)
                    let v64 = kino_text_size(v61)
                    let v65 = trim_end_18(v61, v64)
                    let v66 = v65 <= v63
                    let v72 =
                        case v66 {
                            True -> {
                                let v67 = ""
                                v67
                            }
                            False -> {
                                let v68 = spiral_wrap_signed(v65 - 1, 32)
                                let v69 = spiral_wrap_signed(v68 - v63, 32)
                                let v70 = spiral_wrap_signed(v69 + 1, 32)
                                let v71 = kino_text_at(v61, v63, v70)
                                v71
                            }
                        }
                    let v73 = v72 == ""
                    case v73 {
                        True -> {
                            v5
                        }
                        False -> {
                            let v86 =
                                case v4 {
                                    True -> {
                                        let v74 = "///- --real"
                                        let v75 = kino_text_size(v74)
                                        let v76 = kino_text_size(v61)
                                        let v77 = v75 > v76
                                        let v84 =
                                            case v77 {
                                                True -> {
                                                    False
                                                }
                                                False -> {
                                                    let v78 = v75 == 0
                                                    case v78 {
                                                        True -> {
                                                            True
                                                        }
                                                        False -> {
                                                            let v79 = spiral_wrap_signed(v75 - 1, 32)
                                                            let v80 = spiral_wrap_signed(v79 + 1, 32)
                                                            let v81 = kino_text_at(v61, 0, v80)
                                                            let v82 = v81 == "///- --real"
                                                            v82
                                                        }
                                                    }
                                                }
                                            }
                                        let v85 = v84 == False
                                        v85
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            let v88 =
                                case v86 {
                                    True -> {
                                        let v87 = { "///- --real\n\n" } <> { v61 }
                                        v87
                                    }
                                    False -> {
                                        v61
                                    }
                                }
                            let v89 = "spiral"
                            Uh3Cell(v89, v88, v5)
                        }
                    }
                }
                Us4InCode(v155) -> {
                    let v156 = append_rows_71(v3, v155)
                    let v157 = Uh4NoRow
                    let v158 = rev_rows_58(v156, v157)
                    let v159 = join_rows_60(v158)
                    let v160 = 0
                    let v161 = trim_nl_start_29(v159, v160)
                    let v162 = kino_text_size(v159)
                    let v163 = trim_nl_end_30(v159, v162)
                    let v164 = v163 <= v161
                    let v170 =
                        case v164 {
                            True -> {
                                let v165 = ""
                                v165
                            }
                            False -> {
                                let v166 = spiral_wrap_signed(v163 - 1, 32)
                                let v167 = spiral_wrap_signed(v166 - v161, 32)
                                let v168 = spiral_wrap_signed(v167 + 1, 32)
                                let v169 = kino_text_at(v159, v161, v168)
                                v169
                            }
                        }
                    let v171 = 0
                    let v172 = trim_start_17(v170, v171)
                    let v173 = kino_text_size(v170)
                    let v174 = trim_end_18(v170, v173)
                    let v175 = v174 <= v172
                    let v181 =
                        case v175 {
                            True -> {
                                let v176 = ""
                                v176
                            }
                            False -> {
                                let v177 = spiral_wrap_signed(v174 - 1, 32)
                                let v178 = spiral_wrap_signed(v177 - v172, 32)
                                let v179 = spiral_wrap_signed(v178 + 1, 32)
                                let v180 = kino_text_at(v170, v172, v179)
                                v180
                            }
                        }
                    let v182 = v181 == ""
                    case v182 {
                        True -> {
                            v5
                        }
                        False -> {
                            let v195 =
                                case v4 {
                                    True -> {
                                        let v183 = "///- --real"
                                        let v184 = kino_text_size(v183)
                                        let v185 = kino_text_size(v170)
                                        let v186 = v184 > v185
                                        let v193 =
                                            case v186 {
                                                True -> {
                                                    False
                                                }
                                                False -> {
                                                    let v187 = v184 == 0
                                                    case v187 {
                                                        True -> {
                                                            True
                                                        }
                                                        False -> {
                                                            let v188 = spiral_wrap_signed(v184 - 1, 32)
                                                            let v189 = spiral_wrap_signed(v188 + 1, 32)
                                                            let v190 = kino_text_at(v170, 0, v189)
                                                            let v191 = v190 == "///- --real"
                                                            v191
                                                        }
                                                    }
                                                }
                                            }
                                        let v194 = v193 == False
                                        v194
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            let v197 =
                                case v195 {
                                    True -> {
                                        let v196 = { "///- --real\n\n" } <> { v170 }
                                        v196
                                    }
                                    False -> {
                                        v170
                                    }
                                }
                            let v198 = "spiral"
                            Uh3Cell(v198, v197, v5)
                        }
                    }
                }
                Us4InDoc(v92) -> {
                    let v93 = Uh4NoRow
                    let v94 = rev_rows_58(v92, v93)
                    let v95 = join_rows_60(v94)
                    let v96 = 0
                    let v97 = trim_nl_start_29(v95, v96)
                    let v98 = kino_text_size(v95)
                    let v99 = trim_nl_end_30(v95, v98)
                    let v100 = v99 <= v97
                    let v106 =
                        case v100 {
                            True -> {
                                let v101 = ""
                                v101
                            }
                            False -> {
                                let v102 = spiral_wrap_signed(v99 - 1, 32)
                                let v103 = spiral_wrap_signed(v102 - v97, 32)
                                let v104 = spiral_wrap_signed(v103 + 1, 32)
                                let v105 = kino_text_at(v95, v97, v104)
                                v105
                            }
                        }
                    let v107 = v106 == ""
                    let v110 =
                        case v107 {
                            True -> {
                                v5
                            }
                            False -> {
                                let v108 = "markdown"
                                Uh3Cell(v108, v106, v5)
                            }
                        }
                    let v111 = Uh4NoRow
                    let v112 = rev_rows_58(v3, v111)
                    let v113 = join_rows_60(v112)
                    let v114 = 0
                    let v115 = trim_nl_start_29(v113, v114)
                    let v116 = kino_text_size(v113)
                    let v117 = trim_nl_end_30(v113, v116)
                    let v118 = v117 <= v115
                    let v124 =
                        case v118 {
                            True -> {
                                let v119 = ""
                                v119
                            }
                            False -> {
                                let v120 = spiral_wrap_signed(v117 - 1, 32)
                                let v121 = spiral_wrap_signed(v120 - v115, 32)
                                let v122 = spiral_wrap_signed(v121 + 1, 32)
                                let v123 = kino_text_at(v113, v115, v122)
                                v123
                            }
                        }
                    let v125 = 0
                    let v126 = trim_start_17(v124, v125)
                    let v127 = kino_text_size(v124)
                    let v128 = trim_end_18(v124, v127)
                    let v129 = v128 <= v126
                    let v135 =
                        case v129 {
                            True -> {
                                let v130 = ""
                                v130
                            }
                            False -> {
                                let v131 = spiral_wrap_signed(v128 - 1, 32)
                                let v132 = spiral_wrap_signed(v131 - v126, 32)
                                let v133 = spiral_wrap_signed(v132 + 1, 32)
                                let v134 = kino_text_at(v124, v126, v133)
                                v134
                            }
                        }
                    let v136 = v135 == ""
                    case v136 {
                        True -> {
                            v110
                        }
                        False -> {
                            let v149 =
                                case v4 {
                                    True -> {
                                        let v137 = "///- --real"
                                        let v138 = kino_text_size(v137)
                                        let v139 = kino_text_size(v124)
                                        let v140 = v138 > v139
                                        let v147 =
                                            case v140 {
                                                True -> {
                                                    False
                                                }
                                                False -> {
                                                    let v141 = v138 == 0
                                                    case v141 {
                                                        True -> {
                                                            True
                                                        }
                                                        False -> {
                                                            let v142 = spiral_wrap_signed(v138 - 1, 32)
                                                            let v143 = spiral_wrap_signed(v142 + 1, 32)
                                                            let v144 = kino_text_at(v124, 0, v143)
                                                            let v145 = v144 == "///- --real"
                                                            v145
                                                        }
                                                    }
                                                }
                                            }
                                        let v148 = v147 == False
                                        v148
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            let v151 =
                                case v149 {
                                    True -> {
                                        let v150 = { "///- --real\n\n" } <> { v124 }
                                        v150
                                    }
                                    False -> {
                                        v124
                                    }
                                }
                            let v152 = "spiral"
                            Uh3Cell(v152, v151, v110)
                        }
                    }
                }
                Us4InTest(v201, v202, v203, v204) -> {
                    let v205 = Uh4NoRow
                    let v206 = rev_rows_58(v203, v205)
                    let v207 = drop_blank_rows_70(v204)
                    let v208 = Uh4NoRow
                    let v209 = rev_rows_58(v207, v208)
                    let v210 = { v202 } <> { " " }
                    let v211 = " ignore "
                    let v212 = 0
                    let v213 = find_from_1(v210, v211, v212)
                    let v214 = v213 >= 0
                    let v217 =
                        case v214 {
                            True -> {
                                let v215 = "--ignore"
                                v215
                            }
                            False -> {
                                let v216 = "--test"
                                v216
                            }
                        }
                    let v219 =
                        case v4 {
                            True -> {
                                let v218 = { "--real " } <> { v217 }
                                v218
                            }
                            False -> {
                                v217
                            }
                        }
                    let v220 = " static "
                    let v221 = 0
                    let v222 = find_from_1(v210, v220, v221)
                    let v223 = v222 >= 0
                    let v226 =
                        case v223 {
                            True -> {
                                let v224 = " static"
                                v224
                            }
                            False -> {
                                let v225 = ""
                                v225
                            }
                        }
                    let v227 = " print_code "
                    let v228 = 0
                    let v229 = find_from_1(v210, v227, v228)
                    let v230 = v229 >= 0
                    let v233 =
                        case v230 {
                            True -> {
                                let v231 = " --print-code"
                                v231
                            }
                            False -> {
                                let v232 = ""
                                v232
                            }
                        }
                    let v234 = { v219 } <> { v226 }
                    let v235 = { v234 } <> { v233 }
                    let v236 = { "///- " } <> { v235 }
                    let v237 = ""
                    let v238 = Uh4Row(v237, v209)
                    let v239 = append_rows_71(v206, v238)
                    let v240 = Uh4Row(v236, v239)
                    let v241 = join_rows_60(v240)
                    let v246 =
                        case v4 {
                            True -> {
                                let v242 = { "real_test:" } <> { v201 }
                                Uh3Cell(v242, v241, v5)
                            }
                            False -> {
                                let v244 = { "test:" } <> { v201 }
                                Uh3Cell(v244, v241, v5)
                            }
                        }
                    let v247 = Uh4NoRow
                    let v248 = rev_rows_58(v3, v247)
                    let v249 = join_rows_60(v248)
                    let v250 = 0
                    let v251 = trim_nl_start_29(v249, v250)
                    let v252 = kino_text_size(v249)
                    let v253 = trim_nl_end_30(v249, v252)
                    let v254 = v253 <= v251
                    let v259 =
                        case v254 {
                            True -> {
                                v237
                            }
                            False -> {
                                let v255 = spiral_wrap_signed(v253 - 1, 32)
                                let v256 = spiral_wrap_signed(v255 - v251, 32)
                                let v257 = spiral_wrap_signed(v256 + 1, 32)
                                let v258 = kino_text_at(v249, v251, v257)
                                v258
                            }
                        }
                    let v260 = 0
                    let v261 = trim_start_17(v259, v260)
                    let v262 = kino_text_size(v259)
                    let v263 = trim_end_18(v259, v262)
                    let v264 = v263 <= v261
                    let v269 =
                        case v264 {
                            True -> {
                                v237
                            }
                            False -> {
                                let v265 = spiral_wrap_signed(v263 - 1, 32)
                                let v266 = spiral_wrap_signed(v265 - v261, 32)
                                let v267 = spiral_wrap_signed(v266 + 1, 32)
                                let v268 = kino_text_at(v259, v261, v267)
                                v268
                            }
                        }
                    let v270 = v269 == ""
                    case v270 {
                        True -> {
                            v246
                        }
                        False -> {
                            let v283 =
                                case v4 {
                                    True -> {
                                        let v271 = "///- --real"
                                        let v272 = kino_text_size(v271)
                                        let v273 = kino_text_size(v259)
                                        let v274 = v272 > v273
                                        let v281 =
                                            case v274 {
                                                True -> {
                                                    False
                                                }
                                                False -> {
                                                    let v275 = v272 == 0
                                                    case v275 {
                                                        True -> {
                                                            True
                                                        }
                                                        False -> {
                                                            let v276 = spiral_wrap_signed(v272 - 1, 32)
                                                            let v277 = spiral_wrap_signed(v276 + 1, 32)
                                                            let v278 = kino_text_at(v259, 0, v277)
                                                            let v279 = v278 == "///- --real"
                                                            v279
                                                        }
                                                    }
                                                }
                                            }
                                        let v282 = v281 == False
                                        v282
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            let v285 =
                                case v283 {
                                    True -> {
                                        let v284 = { "///- --real\n\n" } <> { v259 }
                                        v284
                                    }
                                    False -> {
                                        v259
                                    }
                                }
                            let v286 = "spiral"
                            Uh3Cell(v286, v285, v246)
                        }
                    }
                }
            }
        }
        Us0LineGot(v293, v294) -> {
            case v2  {
                Us4Between -> {
                    let v506 = Uh4NoRow
                    let #(v507, v508, v509) = open_step_73(v293, v506, v3, v4, v5)
                    spi_walk_72(v0, v294, v507, v508, v4, v509)
                }
                Us4InCode(v501) -> {
                    let #(v502, v503, v504) = open_step_73(v293, v501, v3, v4, v5)
                    spi_walk_72(v0, v294, v502, v503, v4, v504)
                }
                Us4InDoc(v378) -> {
                    let v379 = 0
                    let v380 = lead_ws_59(v293, v379)
                    let v381 = "/// "
                    let v382 = kino_text_size(v381)
                    let v383 = v380 < 0
                    let v395 =
                        case v383 {
                            True -> {
                                False
                            }
                            False -> {
                                let v384 = spiral_wrap_signed(v380 + v382, 32)
                                let v385 = kino_text_size(v293)
                                let v386 = v384 > v385
                                case v386 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v387 = v382 == 0
                                        case v387 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v388 = spiral_wrap_signed(v384 - 1, 32)
                                                let v389 = spiral_wrap_signed(v388 - v380, 32)
                                                let v390 = spiral_wrap_signed(v389 + 1, 32)
                                                let v391 = kino_text_at(v293, v380, v390)
                                                let v392 = v391 == "/// "
                                                v392
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v407 =
                        case v395 {
                            True -> {
                                True
                            }
                            False -> {
                                let v396 = kino_text_size(v293)
                                let v397 = v380 >= v396
                                let v405 =
                                    case v397 {
                                        True -> {
                                            let v398 = ""
                                            v398
                                        }
                                        False -> {
                                            let v399 = v380 <= 0
                                            case v399 {
                                                True -> {
                                                    v293
                                                }
                                                False -> {
                                                    let v400 = spiral_wrap_signed(v396 - 1, 32)
                                                    let v401 = spiral_wrap_signed(v400 - v380, 32)
                                                    let v402 = spiral_wrap_signed(v401 + 1, 32)
                                                    let v403 = kino_text_at(v293, v380, v402)
                                                    v403
                                                }
                                            }
                                        }
                                    }
                                let v406 = v405 == "///"
                                v406
                            }
                        }
                    case v407 {
                        True -> {
                            let v408 = 0
                            let v409 = lead_ws_59(v293, v408)
                            let v410 = kino_text_size(v381)
                            let v411 = v409 < 0
                            let v423 =
                                case v411 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v412 = spiral_wrap_signed(v409 + v410, 32)
                                        let v413 = kino_text_size(v293)
                                        let v414 = v412 > v413
                                        case v414 {
                                            True -> {
                                                False
                                            }
                                            False -> {
                                                let v415 = v410 == 0
                                                case v415 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v416 = spiral_wrap_signed(v412 - 1, 32)
                                                        let v417 = spiral_wrap_signed(v416 - v409, 32)
                                                        let v418 = spiral_wrap_signed(v417 + 1, 32)
                                                        let v419 = kino_text_at(v293, v409, v418)
                                                        let v420 = v419 == "/// "
                                                        v420
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            let v454 =
                                case v423 {
                                    True -> {
                                        let v424 = kino_text_size(v293)
                                        let v425 = v409 < v424
                                        let v426 =
                                            case v425 {
                                                True -> {
                                                    v409
                                                }
                                                False -> {
                                                    v424
                                                }
                                            }
                                        let v427 = v426 <= 0
                                        let v432 =
                                            case v427 {
                                                True -> {
                                                    let v428 = ""
                                                    v428
                                                }
                                                False -> {
                                                    let v429 = spiral_wrap_signed(v426 - 1, 32)
                                                    let v430 = spiral_wrap_signed(v429 + 1, 32)
                                                    let v431 = kino_text_at(v293, 0, v430)
                                                    v431
                                                }
                                            }
                                        let v433 = spiral_wrap_signed(v409 + 4, 32)
                                        let v434 = kino_text_size(v293)
                                        let v435 = v433 >= v434
                                        let v443 =
                                            case v435 {
                                                True -> {
                                                    let v436 = ""
                                                    v436
                                                }
                                                False -> {
                                                    let v437 = v433 <= 0
                                                    case v437 {
                                                        True -> {
                                                            v293
                                                        }
                                                        False -> {
                                                            let v438 = spiral_wrap_signed(v434 - 1, 32)
                                                            let v439 = spiral_wrap_signed(v438 - v433, 32)
                                                            let v440 = spiral_wrap_signed(v439 + 1, 32)
                                                            let v441 = kino_text_at(v293, v433, v440)
                                                            v441
                                                        }
                                                    }
                                                }
                                            }
                                        let v444 = { v432 } <> { v443 }
                                        v444
                                    }
                                    False -> {
                                        let v445 = kino_text_size(v293)
                                        let v446 = v409 < v445
                                        let v447 =
                                            case v446 {
                                                True -> {
                                                    v409
                                                }
                                                False -> {
                                                    v445
                                                }
                                            }
                                        let v448 = v447 <= 0
                                        case v448 {
                                            True -> {
                                                let v449 = ""
                                                v449
                                            }
                                            False -> {
                                                let v450 = spiral_wrap_signed(v447 - 1, 32)
                                                let v451 = spiral_wrap_signed(v450 + 1, 32)
                                                let v452 = kino_text_at(v293, 0, v451)
                                                v452
                                            }
                                        }
                                    }
                                }
                            let v455 = Uh4Row(v454, v378)
                            let v456 = Us4InDoc(v455)
                            spi_walk_72(v0, v294, v456, v3, v4, v5)
                        }
                        False -> {
                            let v458 = v293 == ""
                            case v458 {
                                True -> {
                                    let v459 = Us4Between
                                    let v460 = Uh4NoRow
                                    let v461 = rev_rows_58(v378, v460)
                                    let v462 = join_rows_60(v461)
                                    let v463 = 0
                                    let v464 = trim_nl_start_29(v462, v463)
                                    let v465 = kino_text_size(v462)
                                    let v466 = trim_nl_end_30(v462, v465)
                                    let v467 = v466 <= v464
                                    let v473 =
                                        case v467 {
                                            True -> {
                                                let v468 = ""
                                                v468
                                            }
                                            False -> {
                                                let v469 = spiral_wrap_signed(v466 - 1, 32)
                                                let v470 = spiral_wrap_signed(v469 - v464, 32)
                                                let v471 = spiral_wrap_signed(v470 + 1, 32)
                                                let v472 = kino_text_at(v462, v464, v471)
                                                v472
                                            }
                                        }
                                    let v474 = v473 == ""
                                    let v477 =
                                        case v474 {
                                            True -> {
                                                v5
                                            }
                                            False -> {
                                                let v475 = "markdown"
                                                Uh3Cell(v475, v473, v5)
                                            }
                                        }
                                    spi_walk_72(v0, v294, v459, v3, v4, v477)
                                }
                                False -> {
                                    let v479 = Us4Between
                                    let v480 = Uh4NoRow
                                    let v481 = rev_rows_58(v378, v480)
                                    let v482 = join_rows_60(v481)
                                    let v483 = 0
                                    let v484 = trim_nl_start_29(v482, v483)
                                    let v485 = kino_text_size(v482)
                                    let v486 = trim_nl_end_30(v482, v485)
                                    let v487 = v486 <= v484
                                    let v493 =
                                        case v487 {
                                            True -> {
                                                let v488 = ""
                                                v488
                                            }
                                            False -> {
                                                let v489 = spiral_wrap_signed(v486 - 1, 32)
                                                let v490 = spiral_wrap_signed(v489 - v484, 32)
                                                let v491 = spiral_wrap_signed(v490 + 1, 32)
                                                let v492 = kino_text_at(v482, v484, v491)
                                                v492
                                            }
                                        }
                                    let v494 = v493 == ""
                                    let v497 =
                                        case v494 {
                                            True -> {
                                                v5
                                            }
                                            False -> {
                                                let v495 = "markdown"
                                                Uh3Cell(v495, v493, v5)
                                            }
                                        }
                                    spi_walk_72(v0, v1, v479, v3, v4, v497)
                                }
                            }
                        }
                    }
                }
                Us4InTest(v295, v296, v297, v298) -> {
                    let v299 = v293 == ""
                    let v308 =
                        case v299 {
                            True -> {
                                True
                            }
                            False -> {
                                let v300 = kino_text_at(v293, 0, 1)
                                let v301 = v300 == " "
                                case v301 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v302 = v300 == "\t"
                                        case v302 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v303 = v300 == "\n"
                                                case v303 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v304 = v300 == "\r"
                                                        v304
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    case v308 {
                        True -> {
                            let v309 = "    "
                            let v310 = kino_text_size(v309)
                            let v311 = kino_text_size(v293)
                            let v312 = v310 > v311
                            let v319 =
                                case v312 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v313 = v310 == 0
                                        case v313 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v314 = spiral_wrap_signed(v310 - 1, 32)
                                                let v315 = spiral_wrap_signed(v314 + 1, 32)
                                                let v316 = kino_text_at(v293, 0, v315)
                                                let v317 = v316 == "    "
                                                v317
                                            }
                                        }
                                    }
                                }
                            let v328 =
                                case v319 {
                                    True -> {
                                        let v320 = kino_text_size(v293)
                                        let v321 = 4 >= v320
                                        case v321 {
                                            True -> {
                                                let v322 = ""
                                                v322
                                            }
                                            False -> {
                                                let v323 = spiral_wrap_signed(v320 - 1, 32)
                                                let v324 = spiral_wrap_signed(v323 - 4, 32)
                                                let v325 = spiral_wrap_signed(v324 + 1, 32)
                                                let v326 = kino_text_at(v293, 4, v325)
                                                v326
                                            }
                                        }
                                    }
                                    False -> {
                                        v293
                                    }
                                }
                            let v329 = Uh4Row(v328, v298)
                            let v330 = Us4InTest(v295, v296, v297, v329)
                            spi_walk_72(v0, v294, v330, v3, v4, v5)
                        }
                        False -> {
                            let v332 = Us4Between
                            let v333 = Uh4NoRow
                            let v334 = Uh4NoRow
                            let v335 = rev_rows_58(v297, v334)
                            let v336 = drop_blank_rows_70(v298)
                            let v337 = Uh4NoRow
                            let v338 = rev_rows_58(v336, v337)
                            let v339 = { v296 } <> { " " }
                            let v340 = " ignore "
                            let v341 = 0
                            let v342 = find_from_1(v339, v340, v341)
                            let v343 = v342 >= 0
                            let v346 =
                                case v343 {
                                    True -> {
                                        let v344 = "--ignore"
                                        v344
                                    }
                                    False -> {
                                        let v345 = "--test"
                                        v345
                                    }
                                }
                            let v348 =
                                case v4 {
                                    True -> {
                                        let v347 = { "--real " } <> { v346 }
                                        v347
                                    }
                                    False -> {
                                        v346
                                    }
                                }
                            let v349 = " static "
                            let v350 = 0
                            let v351 = find_from_1(v339, v349, v350)
                            let v352 = v351 >= 0
                            let v355 =
                                case v352 {
                                    True -> {
                                        let v353 = " static"
                                        v353
                                    }
                                    False -> {
                                        let v354 = ""
                                        v354
                                    }
                                }
                            let v356 = " print_code "
                            let v357 = 0
                            let v358 = find_from_1(v339, v356, v357)
                            let v359 = v358 >= 0
                            let v362 =
                                case v359 {
                                    True -> {
                                        let v360 = " --print-code"
                                        v360
                                    }
                                    False -> {
                                        let v361 = ""
                                        v361
                                    }
                                }
                            let v363 = { v348 } <> { v355 }
                            let v364 = { v363 } <> { v362 }
                            let v365 = { "///- " } <> { v364 }
                            let v366 = ""
                            let v367 = Uh4Row(v366, v338)
                            let v368 = append_rows_71(v335, v367)
                            let v369 = Uh4Row(v365, v368)
                            let v370 = join_rows_60(v369)
                            let v375 =
                                case v4 {
                                    True -> {
                                        let v371 = { "real_test:" } <> { v295 }
                                        Uh3Cell(v371, v370, v5)
                                    }
                                    False -> {
                                        let v373 = { "test:" } <> { v295 }
                                        Uh3Cell(v373, v370, v5)
                                    }
                                }
                            spi_walk_72(v0, v1, v332, v333, v4, v375)
                        }
                    }
                }
            }
        }
    }
}
pub fn interleave_76(v0: Uh3, v1: Uh3, v2: Uh3) -> Uh3 {
    case v1  {
        Uh3Cell(v4, v5, v6) -> {
            let v7 = v4 == "markdown"
            let v8 = v7 != True
            case v8 {
                True -> {
                    let v9 = Uh3Cell(v4, v5, v2)
                    interleave_76(v0, v6, v9)
                }
                False -> {
                    case v0  {
                        Uh3Cell(v12, v13, v14) -> {
                            let v15 = v12 == "markdown"
                            let v16 = v15 != True
                            case v16 {
                                True -> {
                                    let v17 = Uh3Cell(v12, v13, v2)
                                    interleave_76(v14, v1, v17)
                                }
                                False -> {
                                    let v19 = v13 == v5
                                    case v19 {
                                        True -> {
                                            let v20 = Uh3Cell(v12, v13, v2)
                                            interleave_76(v14, v6, v20)
                                        }
                                        False -> {
                                            let v22 = Uh3Cell(v12, v13, v2)
                                            interleave_76(v14, v1, v22)
                                        }
                                    }
                                }
                            }
                        }
                        Uh3NoCell -> {
                            rev_cells_50(v2, v1)
                        }
                    }
                }
            }
        }
        Uh3NoCell -> {
            rev_cells_50(v2, v0)
        }
    }
}
pub fn name_tested_77(v0: Uh3, v1: String, v2: Uh4, v3: Uh4, v4: Uh3) -> Uh3 {
    case v0  {
        Uh3Cell(v5, v6, v7) -> {
            let v8 = v5 == "markdown"
            case v8 {
                True -> {
                    let v9 = 0
                    let v10 = trim_start_17(v6, v9)
                    let v11 = kino_text_size(v6)
                    let v12 = trim_end_18(v6, v11)
                    let v13 = v12 <= v10
                    let v19 =
                        case v13 {
                            True -> {
                                let v14 = ""
                                v14
                            }
                            False -> {
                                let v15 = spiral_wrap_signed(v12 - 1, 32)
                                let v16 = spiral_wrap_signed(v15 - v10, 32)
                                let v17 = spiral_wrap_signed(v16 + 1, 32)
                                let v18 = kino_text_at(v6, v10, v17)
                                v18
                            }
                        }
                    let v20 = 0
                    let v21 = ""
                    let v22 = last_heading_line_63(v19, v20, v21)
                    let v23 = v22 == ""
                    let v54 =
                        case v23 {
                            True -> {
                                v21
                            }
                            False -> {
                                let v24 = " (test)"
                                let v25 = 0
                                let v26 = replace_from_64(v22, v24, v21, v25)
                                let v27 = 0
                                let v28 = False
                                let v29 = test_name_go_65(v26, v27, v28, v21)
                                let v30 = 0
                                let v31 = underscore_start_66(v29, v30)
                                let v32 = kino_text_size(v29)
                                let v33 = underscore_end_67(v29, v32)
                                let v34 = v33 <= v31
                                case v34 {
                                    True -> {
                                        v21
                                    }
                                    False -> {
                                        let v35 = spiral_wrap_signed(v33 - v31, 32)
                                        let v36 = v35 <= 0
                                        case v36 {
                                            True -> {
                                                v21
                                            }
                                            False -> {
                                                let v37 = kino_text_size(v29)
                                                let v38 = v31 >= v37
                                                case v38 {
                                                    True -> {
                                                        v21
                                                    }
                                                    False -> {
                                                        let v39 = spiral_wrap_signed(v31 + v35, 32)
                                                        let v40 = spiral_wrap_signed(v39 - 1, 32)
                                                        let v41 = kino_text_size(v29)
                                                        let v42 = v40 >= v41
                                                        let v45 =
                                                            case v42 {
                                                                True -> {
                                                                    let v43 = kino_text_size(v29)
                                                                    let v44 = spiral_wrap_signed(v43 - 1, 32)
                                                                    v44
                                                                }
                                                                False -> {
                                                                    v40
                                                                }
                                                            }
                                                        let v46 = v45 < v31
                                                        case v46 {
                                                            True -> {
                                                                v21
                                                            }
                                                            False -> {
                                                                let v47 = spiral_wrap_signed(v45 - v31, 32)
                                                                let v48 = spiral_wrap_signed(v47 + 1, 32)
                                                                let v49 = kino_text_at(v29, v31, v48)
                                                                v49
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
                    let v55 = v54 == ""
                    let v56 =
                        case v55 {
                            True -> {
                                v1
                            }
                            False -> {
                                v54
                            }
                        }
                    let v57 = Uh3Cell(v5, v6, v4)
                    name_tested_77(v7, v56, v2, v3, v57)
                }
                False -> {
                    let v59 = "test:"
                    let v60 = kino_text_size(v59)
                    let v61 = kino_text_size(v5)
                    let v62 = v60 > v61
                    let v69 =
                        case v62 {
                            True -> {
                                False
                            }
                            False -> {
                                let v63 = v60 == 0
                                case v63 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v64 = spiral_wrap_signed(v60 - 1, 32)
                                        let v65 = spiral_wrap_signed(v64 + 1, 32)
                                        let v66 = kino_text_at(v5, 0, v65)
                                        let v67 = v66 == "test:"
                                        v67
                                    }
                                }
                            }
                        }
                    let v81 =
                        case v69 {
                            True -> {
                                True
                            }
                            False -> {
                                let v70 = "real_test:"
                                let v71 = kino_text_size(v70)
                                let v72 = kino_text_size(v5)
                                let v73 = v71 > v72
                                case v73 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v74 = v71 == 0
                                        case v74 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v75 = spiral_wrap_signed(v71 - 1, 32)
                                                let v76 = spiral_wrap_signed(v75 + 1, 32)
                                                let v77 = kino_text_at(v5, 0, v76)
                                                let v78 = v77 == "real_test:"
                                                v78
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    case v81 {
                        True -> {
                            let v82 = "real_test:"
                            let v83 = kino_text_size(v82)
                            let v84 = kino_text_size(v5)
                            let v85 = v83 > v84
                            let v92 =
                                case v85 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v86 = v83 == 0
                                        case v86 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v87 = spiral_wrap_signed(v83 - 1, 32)
                                                let v88 = spiral_wrap_signed(v87 + 1, 32)
                                                let v89 = kino_text_at(v5, 0, v88)
                                                let v90 = v89 == "real_test:"
                                                v90
                                            }
                                        }
                                    }
                                }
                            let v95 =
                                case v92 {
                                    True -> {
                                        Us6RealRealm
                                    }
                                    False -> {
                                        Us6SpiRealm
                                    }
                                }
                            let v97 =
                                case v95  {
                                    Us6RealRealm -> {
                                        v3
                                    }
                                    Us6SpiRealm -> {
                                        v2
                                    }
                                }
                            let v98 = 0
                            let v99 = ":"
                            let v100 = find_char_3(v5, v98, v99)
                            let v101 = spiral_wrap_signed(v100 + 1, 32)
                            let v102 = kino_text_size(v5)
                            let v103 = v101 >= v102
                            let v111 =
                                case v103 {
                                    True -> {
                                        let v104 = ""
                                        v104
                                    }
                                    False -> {
                                        let v105 = v101 <= 0
                                        case v105 {
                                            True -> {
                                                v5
                                            }
                                            False -> {
                                                let v106 = spiral_wrap_signed(v102 - 1, 32)
                                                let v107 = spiral_wrap_signed(v106 - v101, 32)
                                                let v108 = spiral_wrap_signed(v107 + 1, 32)
                                                let v109 = kino_text_at(v5, v101, v108)
                                                v109
                                            }
                                        }
                                    }
                                }
                            let v112 = v1 == ""
                            let v114 =
                                case v112 {
                                    True -> {
                                        let v113 = "cell"
                                        v113
                                    }
                                    False -> {
                                        v1
                                    }
                                }
                            let v115 = count_row_68(v97, v114)
                            let v116 = v115 == 0
                            let v121 =
                                case v116 {
                                    True -> {
                                        v114
                                    }
                                    False -> {
                                        let v117 = { v114 } <> { "_" }
                                        let v118 = spiral_wrap_signed(v115 + 1, 32)
                                        let v119 = show_i32_20(v118)
                                        let v120 = { v117 } <> { v119 }
                                        v120
                                    }
                                }
                            let v124 =
                                case v95  {
                                    Us6RealRealm -> {
                                        v2
                                    }
                                    Us6SpiRealm -> {
                                        Uh4Row(v114, v2)
                                    }
                                }
                            let v127 =
                                case v95  {
                                    Us6RealRealm -> {
                                        Uh4Row(v114, v3)
                                    }
                                    Us6SpiRealm -> {
                                        v3
                                    }
                                }
                            let v128 = v121 == v111
                            case v128 {
                                True -> {
                                    let v129 = "spiral"
                                    let v130 = Uh3Cell(v129, v6, v4)
                                    name_tested_77(v7, v1, v124, v127, v130)
                                }
                                False -> {
                                    let v132 = { "#### " } <> { v111 }
                                    let v133 = { v132 } <> { " (test)" }
                                    let v134 = 0
                                    let v135 = trim_start_17(v133, v134)
                                    let v136 = kino_text_size(v133)
                                    let v137 = trim_end_18(v133, v136)
                                    let v138 = v137 <= v135
                                    let v144 =
                                        case v138 {
                                            True -> {
                                                let v139 = ""
                                                v139
                                            }
                                            False -> {
                                                let v140 = spiral_wrap_signed(v137 - 1, 32)
                                                let v141 = spiral_wrap_signed(v140 - v135, 32)
                                                let v142 = spiral_wrap_signed(v141 + 1, 32)
                                                let v143 = kino_text_at(v133, v135, v142)
                                                v143
                                            }
                                        }
                                    let v145 = 0
                                    let v146 = ""
                                    let v147 = last_heading_line_63(v144, v145, v146)
                                    let v148 = v147 == ""
                                    let v179 =
                                        case v148 {
                                            True -> {
                                                v146
                                            }
                                            False -> {
                                                let v149 = " (test)"
                                                let v150 = 0
                                                let v151 = replace_from_64(v147, v149, v146, v150)
                                                let v152 = 0
                                                let v153 = False
                                                let v154 = test_name_go_65(v151, v152, v153, v146)
                                                let v155 = 0
                                                let v156 = underscore_start_66(v154, v155)
                                                let v157 = kino_text_size(v154)
                                                let v158 = underscore_end_67(v154, v157)
                                                let v159 = v158 <= v156
                                                case v159 {
                                                    True -> {
                                                        v146
                                                    }
                                                    False -> {
                                                        let v160 = spiral_wrap_signed(v158 - v156, 32)
                                                        let v161 = v160 <= 0
                                                        case v161 {
                                                            True -> {
                                                                v146
                                                            }
                                                            False -> {
                                                                let v162 = kino_text_size(v154)
                                                                let v163 = v156 >= v162
                                                                case v163 {
                                                                    True -> {
                                                                        v146
                                                                    }
                                                                    False -> {
                                                                        let v164 = spiral_wrap_signed(v156 + v160, 32)
                                                                        let v165 = spiral_wrap_signed(v164 - 1, 32)
                                                                        let v166 = kino_text_size(v154)
                                                                        let v167 = v165 >= v166
                                                                        let v170 =
                                                                            case v167 {
                                                                                True -> {
                                                                                    let v168 = kino_text_size(v154)
                                                                                    let v169 = spiral_wrap_signed(v168 - 1, 32)
                                                                                    v169
                                                                                }
                                                                                False -> {
                                                                                    v165
                                                                                }
                                                                            }
                                                                        let v171 = v170 < v156
                                                                        case v171 {
                                                                            True -> {
                                                                                v146
                                                                            }
                                                                            False -> {
                                                                                let v172 = spiral_wrap_signed(v170 - v156, 32)
                                                                                let v173 = spiral_wrap_signed(v172 + 1, 32)
                                                                                let v174 = kino_text_at(v154, v156, v173)
                                                                                v174
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
                                    let v182 =
                                        case v95  {
                                            Us6RealRealm -> {
                                                v2
                                            }
                                            Us6SpiRealm -> {
                                                Uh4Row(v179, v2)
                                            }
                                        }
                                    let v185 =
                                        case v95  {
                                            Us6RealRealm -> {
                                                Uh4Row(v179, v3)
                                            }
                                            Us6SpiRealm -> {
                                                v3
                                            }
                                        }
                                    let v186 = "spiral"
                                    let v187 = "markdown"
                                    let v188 = Uh3Cell(v187, v133, v4)
                                    let v189 = Uh3Cell(v186, v6, v188)
                                    name_tested_77(v7, v179, v182, v185, v189)
                                }
                            }
                        }
                        False -> {
                            let v192 = Uh3Cell(v5, v6, v4)
                            name_tested_77(v7, v1, v2, v3, v192)
                        }
                    }
                }
            }
        }
        Uh3NoCell -> {
            v4
        }
    }
}
pub fn closure10(capt: Nil) -> fn(#(String, String)) -> String {
    fn (dom) {
        let #(v0, v1) = dom
        let v2 = "\r\n"
        let v3 = "\n"
        let v4 = 0
        let v5 = ""
        let v6 = replace_from_0(v0, v2, v3, v4, v5)
        let v7 = 0
        let v8 = Us4Between
        let v9 = Uh4NoRow
        let v10 = False
        let v11 = Uh3NoCell
        let v12 = spi_walk_72(v6, v7, v8, v9, v10, v11)
        let v13 = Uh3NoCell
        let v14 = rev_cells_50(v12, v13)
        let v15 = 0
        let v16 = replace_from_0(v1, v2, v3, v15, v5)
        let v17 = 0
        let v18 = Us4Between
        let v19 = Uh4NoRow
        let v20 = True
        let v21 = Uh3NoCell
        let v22 = spi_walk_72(v16, v17, v18, v19, v20, v21)
        let v23 = Uh3NoCell
        let v24 = rev_cells_50(v22, v23)
        let v25 = Uh3NoCell
        let v26 = interleave_76(v14, v24, v25)
        let v27 = Uh4NoRow
        let v28 = Uh4NoRow
        let v29 = Uh3NoCell
        let v30 = name_tested_77(v26, v5, v27, v28, v29)
        let v31 = Uh3NoCell
        let v32 = rev_cells_50(v30, v31)
        let v33 = count_cells_51(v32)
        let v34 = show_i32_20(v33)
        let v35 = { v34 } <> { "\n" }
        let v36 = emit_cells_52(v32)
        let v37 = { v35 } <> { v36 }
        v37
    }
}
pub fn heading_marks_end_79(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 < v2
    let v6 =
        case v3 {
            True -> {
                let v4 = kino_text_at(v0, v1, 1)
                let v5 = v4 == "#"
                v5
            }
            False -> {
                False
            }
        }
    case v6 {
        True -> {
            let v7 = spiral_wrap_signed(v1 + 1, 32)
            heading_marks_end_79(v0, v7)
        }
        False -> {
            v1
        }
    }
}
pub fn show_hex_82(v0: Int) -> String {
    let v1 = v0 < 16
    case v1 {
        True -> {
            let v2 = "0123456789abcdef"
            let v3 = kino_text_at(v2, v0, 1)
            v3
        }
        False -> {
            let v4 = v0 / 16
            let v5 = show_hex_82(v4)
            let v6 = v0 % 16
            let v7 = "0123456789abcdef"
            let v8 = kino_text_at(v7, v6, 1)
            let v9 = { v5 } <> { v8 }
            v9
        }
    }
}
pub fn symbol_go_81(v0: String, v1: Int, v2: String) -> String {
    let v3 = kino_text_size(v0)
    let v4 = v1 >= v3
    case v4 {
        True -> {
            v2
        }
        False -> {
            let v5 = kino_text_byte(v0, v1)
            let v6 = v5 < 128
            let v11 =
                case v6 {
                    True -> {
                        let v7 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_"
                        let v8 = 0
                        let v9 = kino_text_at(v0, v1, 1)
                        has_char_12(v7, v8, v9)
                    }
                    False -> {
                        False
                    }
                }
            case v11 {
                True -> {
                    let v12 = spiral_wrap_signed(v1 + 1, 32)
                    let v13 = kino_text_at(v0, v1, 1)
                    let v14 = { v2 } <> { v13 }
                    symbol_go_81(v0, v12, v14)
                }
                False -> {
                    let v16 = kino_text_byte(v0, v1)
                    let v17 = v16 < 128
                    let v22 =
                        case v17 {
                            True -> {
                                1
                            }
                            False -> {
                                let v18 = v16 < 224
                                case v18 {
                                    True -> {
                                        2
                                    }
                                    False -> {
                                        let v19 = v16 < 240
                                        case v19 {
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
                    let v23 = spiral_wrap_signed(v1 + v22, 32)
                    let v24 = { v2 } <> { "u" }
                    let v25 = kino_text_byte(v0, v1)
                    let v26 = v25 < 128
                    let v31 =
                        case v26 {
                            True -> {
                                1
                            }
                            False -> {
                                let v27 = v25 < 224
                                case v27 {
                                    True -> {
                                        2
                                    }
                                    False -> {
                                        let v28 = v25 < 240
                                        case v28 {
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
                    let v32 = v31 == 1
                    let v88 =
                        case v32 {
                            True -> {
                                v25
                            }
                            False -> {
                                let v33 = v31 == 2
                                case v33 {
                                    True -> {
                                        let v34 = spiral_wrap_signed(v25 - 192, 32)
                                        let v35 = spiral_wrap_signed(v34 * 64, 32)
                                        let v36 = spiral_wrap_signed(v1 + 1, 32)
                                        let v37 = kino_text_size(v0)
                                        let v38 = v36 < v37
                                        let v41 =
                                            case v38 {
                                                True -> {
                                                    let v39 = kino_text_byte(v0, v36)
                                                    let v40 = spiral_wrap_signed(v39 - 128, 32)
                                                    v40
                                                }
                                                False -> {
                                                    0
                                                }
                                            }
                                        let v42 = spiral_wrap_signed(v35 + v41, 32)
                                        v42
                                    }
                                    False -> {
                                        let v43 = v31 == 3
                                        case v43 {
                                            True -> {
                                                let v44 = spiral_wrap_signed(v25 - 224, 32)
                                                let v45 = spiral_wrap_signed(v44 * 4096, 32)
                                                let v46 = spiral_wrap_signed(v1 + 1, 32)
                                                let v47 = kino_text_size(v0)
                                                let v48 = v46 < v47
                                                let v51 =
                                                    case v48 {
                                                        True -> {
                                                            let v49 = kino_text_byte(v0, v46)
                                                            let v50 = spiral_wrap_signed(v49 - 128, 32)
                                                            v50
                                                        }
                                                        False -> {
                                                            0
                                                        }
                                                    }
                                                let v52 = spiral_wrap_signed(v51 * 64, 32)
                                                let v53 = spiral_wrap_signed(v45 + v52, 32)
                                                let v54 = spiral_wrap_signed(v1 + 2, 32)
                                                let v55 = kino_text_size(v0)
                                                let v56 = v54 < v55
                                                let v59 =
                                                    case v56 {
                                                        True -> {
                                                            let v57 = kino_text_byte(v0, v54)
                                                            let v58 = spiral_wrap_signed(v57 - 128, 32)
                                                            v58
                                                        }
                                                        False -> {
                                                            0
                                                        }
                                                    }
                                                let v60 = spiral_wrap_signed(v53 + v59, 32)
                                                v60
                                            }
                                            False -> {
                                                let v61 = spiral_wrap_signed(v25 - 240, 32)
                                                let v62 = spiral_wrap_signed(v61 * 262144, 32)
                                                let v63 = spiral_wrap_signed(v1 + 1, 32)
                                                let v64 = kino_text_size(v0)
                                                let v65 = v63 < v64
                                                let v68 =
                                                    case v65 {
                                                        True -> {
                                                            let v66 = kino_text_byte(v0, v63)
                                                            let v67 = spiral_wrap_signed(v66 - 128, 32)
                                                            v67
                                                        }
                                                        False -> {
                                                            0
                                                        }
                                                    }
                                                let v69 = spiral_wrap_signed(v68 * 4096, 32)
                                                let v70 = spiral_wrap_signed(v62 + v69, 32)
                                                let v71 = spiral_wrap_signed(v1 + 2, 32)
                                                let v72 = kino_text_size(v0)
                                                let v73 = v71 < v72
                                                let v76 =
                                                    case v73 {
                                                        True -> {
                                                            let v74 = kino_text_byte(v0, v71)
                                                            let v75 = spiral_wrap_signed(v74 - 128, 32)
                                                            v75
                                                        }
                                                        False -> {
                                                            0
                                                        }
                                                    }
                                                let v77 = spiral_wrap_signed(v76 * 64, 32)
                                                let v78 = spiral_wrap_signed(v70 + v77, 32)
                                                let v79 = spiral_wrap_signed(v1 + 3, 32)
                                                let v80 = kino_text_size(v0)
                                                let v81 = v79 < v80
                                                let v84 =
                                                    case v81 {
                                                        True -> {
                                                            let v82 = kino_text_byte(v0, v79)
                                                            let v83 = spiral_wrap_signed(v82 - 128, 32)
                                                            v83
                                                        }
                                                        False -> {
                                                            0
                                                        }
                                                    }
                                                let v85 = spiral_wrap_signed(v78 + v84, 32)
                                                v85
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v89 = show_hex_82(v88)
                    let v90 = { v24 } <> { v89 }
                    let v91 = { v90 } <> { "_" }
                    symbol_go_81(v0, v23, v91)
                }
            }
        }
    }
}
pub fn index_tests_80(v0: Bool, v1: Uh3, v2: Int, v3: String, v4: String, v5: Uh4, v6: Uh4) -> Uh4 {
    case v1  {
        Uh3Cell(v7, v8, v9) -> {
            let v10 = 0
            let v11 = trim_start_17(v8, v10)
            let v12 = kino_text_size(v8)
            let v13 = trim_end_18(v8, v12)
            let v14 = v13 <= v11
            let v20 =
                case v14 {
                    True -> {
                        let v15 = ""
                        v15
                    }
                    False -> {
                        let v16 = spiral_wrap_signed(v13 - 1, 32)
                        let v17 = spiral_wrap_signed(v16 - v11, 32)
                        let v18 = spiral_wrap_signed(v17 + 1, 32)
                        let v19 = kino_text_at(v8, v11, v18)
                        v19
                    }
                }
            let v21 = v7 == "markdown"
            case v21 {
                True -> {
                    let v22 = 0
                    let v23 = trim_start_17(v8, v22)
                    let v24 = kino_text_size(v8)
                    let v25 = trim_end_18(v8, v24)
                    let v26 = v25 <= v23
                    let v32 =
                        case v26 {
                            True -> {
                                let v27 = ""
                                v27
                            }
                            False -> {
                                let v28 = spiral_wrap_signed(v25 - 1, 32)
                                let v29 = spiral_wrap_signed(v28 - v23, 32)
                                let v30 = spiral_wrap_signed(v29 + 1, 32)
                                let v31 = kino_text_at(v8, v23, v30)
                                v31
                            }
                        }
                    let v33 = 0
                    let v34 = ""
                    let v35 = last_heading_line_63(v32, v33, v34)
                    let v36 = v35 == ""
                    let v67 =
                        case v36 {
                            True -> {
                                v34
                            }
                            False -> {
                                let v37 = " (test)"
                                let v38 = 0
                                let v39 = replace_from_64(v35, v37, v34, v38)
                                let v40 = 0
                                let v41 = False
                                let v42 = test_name_go_65(v39, v40, v41, v34)
                                let v43 = 0
                                let v44 = underscore_start_66(v42, v43)
                                let v45 = kino_text_size(v42)
                                let v46 = underscore_end_67(v42, v45)
                                let v47 = v46 <= v44
                                case v47 {
                                    True -> {
                                        v34
                                    }
                                    False -> {
                                        let v48 = spiral_wrap_signed(v46 - v44, 32)
                                        let v49 = v48 <= 0
                                        case v49 {
                                            True -> {
                                                v34
                                            }
                                            False -> {
                                                let v50 = kino_text_size(v42)
                                                let v51 = v44 >= v50
                                                case v51 {
                                                    True -> {
                                                        v34
                                                    }
                                                    False -> {
                                                        let v52 = spiral_wrap_signed(v44 + v48, 32)
                                                        let v53 = spiral_wrap_signed(v52 - 1, 32)
                                                        let v54 = kino_text_size(v42)
                                                        let v55 = v53 >= v54
                                                        let v58 =
                                                            case v55 {
                                                                True -> {
                                                                    let v56 = kino_text_size(v42)
                                                                    let v57 = spiral_wrap_signed(v56 - 1, 32)
                                                                    v57
                                                                }
                                                                False -> {
                                                                    v53
                                                                }
                                                            }
                                                        let v59 = v58 < v44
                                                        case v59 {
                                                            True -> {
                                                                v34
                                                            }
                                                            False -> {
                                                                let v60 = spiral_wrap_signed(v58 - v44, 32)
                                                                let v61 = spiral_wrap_signed(v60 + 1, 32)
                                                                let v62 = kino_text_at(v42, v44, v61)
                                                                v62
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
                    let v68 = v67 == ""
                    case v68 {
                        True -> {
                            let v69 = spiral_wrap_signed(v2 + 1, 32)
                            index_tests_80(v0, v9, v69, v3, v4, v5, v6)
                        }
                        False -> {
                            let v71 = spiral_wrap_signed(v2 + 1, 32)
                            let v72 = 0
                            let v73 = trim_start_17(v8, v72)
                            let v74 = kino_text_size(v8)
                            let v75 = trim_end_18(v8, v74)
                            let v76 = v75 <= v73
                            let v81 =
                                case v76 {
                                    True -> {
                                        v34
                                    }
                                    False -> {
                                        let v77 = spiral_wrap_signed(v75 - 1, 32)
                                        let v78 = spiral_wrap_signed(v77 - v73, 32)
                                        let v79 = spiral_wrap_signed(v78 + 1, 32)
                                        let v80 = kino_text_at(v8, v73, v79)
                                        v80
                                    }
                                }
                            let v82 = 0
                            let v83 = last_heading_line_63(v81, v82, v34)
                            let v84 = 0
                            let v85 = trim_start_17(v83, v84)
                            let v86 = kino_text_size(v83)
                            let v87 = trim_end_18(v83, v86)
                            let v88 = v87 <= v85
                            let v93 =
                                case v88 {
                                    True -> {
                                        v34
                                    }
                                    False -> {
                                        let v89 = spiral_wrap_signed(v87 - 1, 32)
                                        let v90 = spiral_wrap_signed(v89 - v85, 32)
                                        let v91 = spiral_wrap_signed(v90 + 1, 32)
                                        let v92 = kino_text_at(v83, v85, v91)
                                        v92
                                    }
                                }
                            let v94 = 0
                            let v95 = heading_marks_end_79(v93, v94)
                            let v96 = kino_text_size(v93)
                            let v97 = v95 >= v96
                            let v104 =
                                case v97 {
                                    True -> {
                                        v34
                                    }
                                    False -> {
                                        let v98 = v95 <= 0
                                        case v98 {
                                            True -> {
                                                v93
                                            }
                                            False -> {
                                                let v99 = spiral_wrap_signed(v96 - 1, 32)
                                                let v100 = spiral_wrap_signed(v99 - v95, 32)
                                                let v101 = spiral_wrap_signed(v100 + 1, 32)
                                                let v102 = kino_text_at(v93, v95, v101)
                                                v102
                                            }
                                        }
                                    }
                                }
                            let v105 = " (test)"
                            let v106 = 0
                            let v107 = replace_from_64(v104, v105, v34, v106)
                            let v108 = 0
                            let v109 = trim_start_17(v107, v108)
                            let v110 = kino_text_size(v107)
                            let v111 = trim_end_18(v107, v110)
                            let v112 = v111 <= v109
                            let v117 =
                                case v112 {
                                    True -> {
                                        v34
                                    }
                                    False -> {
                                        let v113 = spiral_wrap_signed(v111 - 1, 32)
                                        let v114 = spiral_wrap_signed(v113 - v109, 32)
                                        let v115 = spiral_wrap_signed(v114 + 1, 32)
                                        let v116 = kino_text_at(v107, v109, v115)
                                        v116
                                    }
                                }
                            index_tests_80(v0, v9, v71, v67, v117, v5, v6)
                        }
                    }
                }
                False -> {
                    let v120 = v7 == "spiral"
                    let v135 =
                        case v120 {
                            True -> {
                                let v121 = "///- "
                                let v122 = 0
                                let v123 = find_from_1(v20, v121, v122)
                                let v124 = v123 >= 0
                                case v124 {
                                    True -> {
                                        let v125 = " --test"
                                        let v126 = 0
                                        let v127 = find_from_1(v20, v125, v126)
                                        let v128 = v127 >= 0
                                        case v128 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v129 = " --ignore"
                                                let v130 = 0
                                                let v131 = find_from_1(v20, v129, v130)
                                                let v132 = v131 >= 0
                                                v132
                                            }
                                        }
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            }
                            False -> {
                                False
                            }
                        }
                    let v146 =
                        case v135 {
                            True -> {
                                let v136 = "///- "
                                let v137 = 0
                                let v138 = find_from_1(v20, v136, v137)
                                let v139 = v138 >= 0
                                let v144 =
                                    case v139 {
                                        True -> {
                                            let v140 = " --real"
                                            let v141 = 0
                                            let v142 = find_from_1(v20, v140, v141)
                                            let v143 = v142 >= 0
                                            v143
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                let v145 = v144 == v0
                                v145
                            }
                            False -> {
                                False
                            }
                        }
                    case v146 {
                        True -> {
                            let v147 = v3 == ""
                            let v149 =
                                case v147 {
                                    True -> {
                                        let v148 = "cell"
                                        v148
                                    }
                                    False -> {
                                        v3
                                    }
                                }
                            let v150 = count_row_68(v5, v149)
                            let v151 = v150 == 0
                            let v156 =
                                case v151 {
                                    True -> {
                                        v149
                                    }
                                    False -> {
                                        let v152 = { v149 } <> { "_" }
                                        let v153 = spiral_wrap_signed(v150 + 1, 32)
                                        let v154 = show_i32_20(v153)
                                        let v155 = { v152 } <> { v154 }
                                        v155
                                    }
                                }
                            let v159 =
                                case v0 {
                                    True -> {
                                        let v157 = "real"
                                        v157
                                    }
                                    False -> {
                                        let v158 = "spi"
                                        v158
                                    }
                                }
                            let v160 = v4 == ""
                            let v161 =
                                case v160 {
                                    True -> {
                                        v156
                                    }
                                    False -> {
                                        v4
                                    }
                                }
                            let v162 = show_i32_20(v2)
                            let v163 = { v162 } <> { "\t" }
                            let v164 = { v163 } <> { v156 }
                            let v165 = { v164 } <> { "\t" }
                            let v166 = kino_text_size(v20)
                            let v167 = 0 > v166
                            let v204 =
                                case v167 {
                                    True -> {
                                        Us0LineDone
                                    }
                                    False -> {
                                        let v169 = v166 == 0
                                        case v169 {
                                            True -> {
                                                let v170 = ""
                                                Us0LineGot(v170, 1)
                                            }
                                            False -> {
                                                let v172 = 0 == v166
                                                case v172 {
                                                    True -> {
                                                        let v173 = v166 > 0
                                                        let v177 =
                                                            case v173 {
                                                                True -> {
                                                                    let v174 = spiral_wrap_signed(v166 - 1, 32)
                                                                    let v175 = kino_text_at(v20, v174, 1)
                                                                    let v176 = v175 == "\n"
                                                                    v176
                                                                }
                                                                False -> {
                                                                    False
                                                                }
                                                            }
                                                        case v177 {
                                                            True -> {
                                                                let v178 = spiral_wrap_signed(v166 + 1, 32)
                                                                let v179 = ""
                                                                Us0LineGot(v179, v178)
                                                            }
                                                            False -> {
                                                                Us0LineDone
                                                            }
                                                        }
                                                    }
                                                    False -> {
                                                        let v183 = 0
                                                        let v184 = "\n"
                                                        let v185 = find_char_3(v20, v183, v184)
                                                        let v186 = v185 < 0
                                                        case v186 {
                                                            True -> {
                                                                let v187 = spiral_wrap_signed(v166 - 1, 32)
                                                                let v188 = spiral_wrap_signed(v187 + 1, 32)
                                                                let v189 = kino_text_at(v20, 0, v188)
                                                                Us0LineGot(v189, v166)
                                                            }
                                                            False -> {
                                                                let v191 = v185 == 0
                                                                case v191 {
                                                                    True -> {
                                                                        let v192 = spiral_wrap_signed(v185 + 1, 32)
                                                                        let v193 = ""
                                                                        Us0LineGot(v193, v192)
                                                                    }
                                                                    False -> {
                                                                        let v195 = spiral_wrap_signed(v185 - 1, 32)
                                                                        let v196 = spiral_wrap_signed(v195 + 1, 32)
                                                                        let v197 = kino_text_at(v20, 0, v196)
                                                                        let v198 = spiral_wrap_signed(v185 + 1, 32)
                                                                        Us0LineGot(v197, v198)
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
                            let v209 =
                                case v204  {
                                    Us0LineDone -> {
                                        let v205 = ""
                                        v205
                                    }
                                    Us0LineGot(v206, v207) -> {
                                        v206
                                    }
                                }
                            let v210 = { " " } <> { v209 }
                            let v211 = { v210 } <> { " " }
                            let v212 = " --ignore "
                            let v213 = 0
                            let v214 = find_from_1(v211, v212, v213)
                            let v215 = v214 >= 0
                            let v224 =
                                case v215 {
                                    True -> {
                                        let v216 = "ignore"
                                        v216
                                    }
                                    False -> {
                                        let v217 = " --test static "
                                        let v218 = 0
                                        let v219 = find_from_1(v211, v217, v218)
                                        let v220 = v219 >= 0
                                        case v220 {
                                            True -> {
                                                let v221 = "static"
                                                v221
                                            }
                                            False -> {
                                                let v222 = "test"
                                                v222
                                            }
                                        }
                                    }
                                }
                            let v225 = { v165 } <> { v224 }
                            let v226 = { v225 } <> { "\t" }
                            let v227 = { v226 } <> { v159 }
                            let v228 = { v227 } <> { "\t" }
                            let v229 = 0
                            let v230 = ""
                            let v231 = symbol_go_81(v156, v229, v230)
                            let v232 = v231 == v156
                            let v234 =
                                case v232 {
                                    True -> {
                                        v156
                                    }
                                    False -> {
                                        let v233 = { "test_" } <> { v231 }
                                        v233
                                    }
                                }
                            let v235 = { v228 } <> { v234 }
                            let v236 = { v235 } <> { "\t" }
                            let v237 = { v236 } <> { v161 }
                            let v238 = spiral_wrap_signed(v2 + 1, 32)
                            let v239 = Uh4Row(v149, v5)
                            let v240 = Uh4Row(v237, v6)
                            index_tests_80(v0, v9, v238, v3, v4, v239, v240)
                        }
                        False -> {
                            let v242 = spiral_wrap_signed(v2 + 1, 32)
                            index_tests_80(v0, v9, v242, v3, v4, v5, v6)
                        }
                    }
                }
            }
        }
        Uh3NoCell -> {
            v6
        }
    }
}
pub fn index_tests_78(v0: Bool, v1: Uh3, v2: Int, v3: String, v4: Uh4, v5: Uh4) -> Uh4 {
    case v1  {
        Uh3Cell(v6, v7, v8) -> {
            let v9 = 0
            let v10 = trim_start_17(v7, v9)
            let v11 = kino_text_size(v7)
            let v12 = trim_end_18(v7, v11)
            let v13 = v12 <= v10
            let v19 =
                case v13 {
                    True -> {
                        let v14 = ""
                        v14
                    }
                    False -> {
                        let v15 = spiral_wrap_signed(v12 - 1, 32)
                        let v16 = spiral_wrap_signed(v15 - v10, 32)
                        let v17 = spiral_wrap_signed(v16 + 1, 32)
                        let v18 = kino_text_at(v7, v10, v17)
                        v18
                    }
                }
            let v20 = v6 == "markdown"
            case v20 {
                True -> {
                    let v21 = 0
                    let v22 = trim_start_17(v7, v21)
                    let v23 = kino_text_size(v7)
                    let v24 = trim_end_18(v7, v23)
                    let v25 = v24 <= v22
                    let v31 =
                        case v25 {
                            True -> {
                                let v26 = ""
                                v26
                            }
                            False -> {
                                let v27 = spiral_wrap_signed(v24 - 1, 32)
                                let v28 = spiral_wrap_signed(v27 - v22, 32)
                                let v29 = spiral_wrap_signed(v28 + 1, 32)
                                let v30 = kino_text_at(v7, v22, v29)
                                v30
                            }
                        }
                    let v32 = 0
                    let v33 = ""
                    let v34 = last_heading_line_63(v31, v32, v33)
                    let v35 = v34 == ""
                    let v66 =
                        case v35 {
                            True -> {
                                v33
                            }
                            False -> {
                                let v36 = " (test)"
                                let v37 = 0
                                let v38 = replace_from_64(v34, v36, v33, v37)
                                let v39 = 0
                                let v40 = False
                                let v41 = test_name_go_65(v38, v39, v40, v33)
                                let v42 = 0
                                let v43 = underscore_start_66(v41, v42)
                                let v44 = kino_text_size(v41)
                                let v45 = underscore_end_67(v41, v44)
                                let v46 = v45 <= v43
                                case v46 {
                                    True -> {
                                        v33
                                    }
                                    False -> {
                                        let v47 = spiral_wrap_signed(v45 - v43, 32)
                                        let v48 = v47 <= 0
                                        case v48 {
                                            True -> {
                                                v33
                                            }
                                            False -> {
                                                let v49 = kino_text_size(v41)
                                                let v50 = v43 >= v49
                                                case v50 {
                                                    True -> {
                                                        v33
                                                    }
                                                    False -> {
                                                        let v51 = spiral_wrap_signed(v43 + v47, 32)
                                                        let v52 = spiral_wrap_signed(v51 - 1, 32)
                                                        let v53 = kino_text_size(v41)
                                                        let v54 = v52 >= v53
                                                        let v57 =
                                                            case v54 {
                                                                True -> {
                                                                    let v55 = kino_text_size(v41)
                                                                    let v56 = spiral_wrap_signed(v55 - 1, 32)
                                                                    v56
                                                                }
                                                                False -> {
                                                                    v52
                                                                }
                                                            }
                                                        let v58 = v57 < v43
                                                        case v58 {
                                                            True -> {
                                                                v33
                                                            }
                                                            False -> {
                                                                let v59 = spiral_wrap_signed(v57 - v43, 32)
                                                                let v60 = spiral_wrap_signed(v59 + 1, 32)
                                                                let v61 = kino_text_at(v41, v43, v60)
                                                                v61
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
                    let v67 = v66 == ""
                    case v67 {
                        True -> {
                            let v68 = spiral_wrap_signed(v2 + 1, 32)
                            index_tests_78(v0, v8, v68, v3, v4, v5)
                        }
                        False -> {
                            let v70 = spiral_wrap_signed(v2 + 1, 32)
                            let v71 = 0
                            let v72 = trim_start_17(v7, v71)
                            let v73 = kino_text_size(v7)
                            let v74 = trim_end_18(v7, v73)
                            let v75 = v74 <= v72
                            let v80 =
                                case v75 {
                                    True -> {
                                        v33
                                    }
                                    False -> {
                                        let v76 = spiral_wrap_signed(v74 - 1, 32)
                                        let v77 = spiral_wrap_signed(v76 - v72, 32)
                                        let v78 = spiral_wrap_signed(v77 + 1, 32)
                                        let v79 = kino_text_at(v7, v72, v78)
                                        v79
                                    }
                                }
                            let v81 = 0
                            let v82 = last_heading_line_63(v80, v81, v33)
                            let v83 = 0
                            let v84 = trim_start_17(v82, v83)
                            let v85 = kino_text_size(v82)
                            let v86 = trim_end_18(v82, v85)
                            let v87 = v86 <= v84
                            let v92 =
                                case v87 {
                                    True -> {
                                        v33
                                    }
                                    False -> {
                                        let v88 = spiral_wrap_signed(v86 - 1, 32)
                                        let v89 = spiral_wrap_signed(v88 - v84, 32)
                                        let v90 = spiral_wrap_signed(v89 + 1, 32)
                                        let v91 = kino_text_at(v82, v84, v90)
                                        v91
                                    }
                                }
                            let v93 = 0
                            let v94 = heading_marks_end_79(v92, v93)
                            let v95 = kino_text_size(v92)
                            let v96 = v94 >= v95
                            let v103 =
                                case v96 {
                                    True -> {
                                        v33
                                    }
                                    False -> {
                                        let v97 = v94 <= 0
                                        case v97 {
                                            True -> {
                                                v92
                                            }
                                            False -> {
                                                let v98 = spiral_wrap_signed(v95 - 1, 32)
                                                let v99 = spiral_wrap_signed(v98 - v94, 32)
                                                let v100 = spiral_wrap_signed(v99 + 1, 32)
                                                let v101 = kino_text_at(v92, v94, v100)
                                                v101
                                            }
                                        }
                                    }
                                }
                            let v104 = " (test)"
                            let v105 = 0
                            let v106 = replace_from_64(v103, v104, v33, v105)
                            let v107 = 0
                            let v108 = trim_start_17(v106, v107)
                            let v109 = kino_text_size(v106)
                            let v110 = trim_end_18(v106, v109)
                            let v111 = v110 <= v108
                            let v116 =
                                case v111 {
                                    True -> {
                                        v33
                                    }
                                    False -> {
                                        let v112 = spiral_wrap_signed(v110 - 1, 32)
                                        let v113 = spiral_wrap_signed(v112 - v108, 32)
                                        let v114 = spiral_wrap_signed(v113 + 1, 32)
                                        let v115 = kino_text_at(v106, v108, v114)
                                        v115
                                    }
                                }
                            index_tests_80(v0, v8, v70, v66, v116, v4, v5)
                        }
                    }
                }
                False -> {
                    let v119 = v6 == "spiral"
                    let v134 =
                        case v119 {
                            True -> {
                                let v120 = "///- "
                                let v121 = 0
                                let v122 = find_from_1(v19, v120, v121)
                                let v123 = v122 >= 0
                                case v123 {
                                    True -> {
                                        let v124 = " --test"
                                        let v125 = 0
                                        let v126 = find_from_1(v19, v124, v125)
                                        let v127 = v126 >= 0
                                        case v127 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v128 = " --ignore"
                                                let v129 = 0
                                                let v130 = find_from_1(v19, v128, v129)
                                                let v131 = v130 >= 0
                                                v131
                                            }
                                        }
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            }
                            False -> {
                                False
                            }
                        }
                    let v145 =
                        case v134 {
                            True -> {
                                let v135 = "///- "
                                let v136 = 0
                                let v137 = find_from_1(v19, v135, v136)
                                let v138 = v137 >= 0
                                let v143 =
                                    case v138 {
                                        True -> {
                                            let v139 = " --real"
                                            let v140 = 0
                                            let v141 = find_from_1(v19, v139, v140)
                                            let v142 = v141 >= 0
                                            v142
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                let v144 = v143 == v0
                                v144
                            }
                            False -> {
                                False
                            }
                        }
                    case v145 {
                        True -> {
                            let v146 = v3 == ""
                            let v148 =
                                case v146 {
                                    True -> {
                                        let v147 = "cell"
                                        v147
                                    }
                                    False -> {
                                        v3
                                    }
                                }
                            let v149 = count_row_68(v4, v148)
                            let v150 = v149 == 0
                            let v155 =
                                case v150 {
                                    True -> {
                                        v148
                                    }
                                    False -> {
                                        let v151 = { v148 } <> { "_" }
                                        let v152 = spiral_wrap_signed(v149 + 1, 32)
                                        let v153 = show_i32_20(v152)
                                        let v154 = { v151 } <> { v153 }
                                        v154
                                    }
                                }
                            let v158 =
                                case v0 {
                                    True -> {
                                        let v156 = "real"
                                        v156
                                    }
                                    False -> {
                                        let v157 = "spi"
                                        v157
                                    }
                                }
                            let v159 =
                                case v146 {
                                    True -> {
                                        v155
                                    }
                                    False -> {
                                        v3
                                    }
                                }
                            let v160 = show_i32_20(v2)
                            let v161 = { v160 } <> { "\t" }
                            let v162 = { v161 } <> { v155 }
                            let v163 = { v162 } <> { "\t" }
                            let v164 = kino_text_size(v19)
                            let v165 = 0 > v164
                            let v202 =
                                case v165 {
                                    True -> {
                                        Us0LineDone
                                    }
                                    False -> {
                                        let v167 = v164 == 0
                                        case v167 {
                                            True -> {
                                                let v168 = ""
                                                Us0LineGot(v168, 1)
                                            }
                                            False -> {
                                                let v170 = 0 == v164
                                                case v170 {
                                                    True -> {
                                                        let v171 = v164 > 0
                                                        let v175 =
                                                            case v171 {
                                                                True -> {
                                                                    let v172 = spiral_wrap_signed(v164 - 1, 32)
                                                                    let v173 = kino_text_at(v19, v172, 1)
                                                                    let v174 = v173 == "\n"
                                                                    v174
                                                                }
                                                                False -> {
                                                                    False
                                                                }
                                                            }
                                                        case v175 {
                                                            True -> {
                                                                let v176 = spiral_wrap_signed(v164 + 1, 32)
                                                                let v177 = ""
                                                                Us0LineGot(v177, v176)
                                                            }
                                                            False -> {
                                                                Us0LineDone
                                                            }
                                                        }
                                                    }
                                                    False -> {
                                                        let v181 = 0
                                                        let v182 = "\n"
                                                        let v183 = find_char_3(v19, v181, v182)
                                                        let v184 = v183 < 0
                                                        case v184 {
                                                            True -> {
                                                                let v185 = spiral_wrap_signed(v164 - 1, 32)
                                                                let v186 = spiral_wrap_signed(v185 + 1, 32)
                                                                let v187 = kino_text_at(v19, 0, v186)
                                                                Us0LineGot(v187, v164)
                                                            }
                                                            False -> {
                                                                let v189 = v183 == 0
                                                                case v189 {
                                                                    True -> {
                                                                        let v190 = spiral_wrap_signed(v183 + 1, 32)
                                                                        let v191 = ""
                                                                        Us0LineGot(v191, v190)
                                                                    }
                                                                    False -> {
                                                                        let v193 = spiral_wrap_signed(v183 - 1, 32)
                                                                        let v194 = spiral_wrap_signed(v193 + 1, 32)
                                                                        let v195 = kino_text_at(v19, 0, v194)
                                                                        let v196 = spiral_wrap_signed(v183 + 1, 32)
                                                                        Us0LineGot(v195, v196)
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
                            let v207 =
                                case v202  {
                                    Us0LineDone -> {
                                        let v203 = ""
                                        v203
                                    }
                                    Us0LineGot(v204, v205) -> {
                                        v204
                                    }
                                }
                            let v208 = { " " } <> { v207 }
                            let v209 = { v208 } <> { " " }
                            let v210 = " --ignore "
                            let v211 = 0
                            let v212 = find_from_1(v209, v210, v211)
                            let v213 = v212 >= 0
                            let v222 =
                                case v213 {
                                    True -> {
                                        let v214 = "ignore"
                                        v214
                                    }
                                    False -> {
                                        let v215 = " --test static "
                                        let v216 = 0
                                        let v217 = find_from_1(v209, v215, v216)
                                        let v218 = v217 >= 0
                                        case v218 {
                                            True -> {
                                                let v219 = "static"
                                                v219
                                            }
                                            False -> {
                                                let v220 = "test"
                                                v220
                                            }
                                        }
                                    }
                                }
                            let v223 = { v163 } <> { v222 }
                            let v224 = { v223 } <> { "\t" }
                            let v225 = { v224 } <> { v158 }
                            let v226 = { v225 } <> { "\t" }
                            let v227 = 0
                            let v228 = ""
                            let v229 = symbol_go_81(v155, v227, v228)
                            let v230 = v229 == v155
                            let v232 =
                                case v230 {
                                    True -> {
                                        v155
                                    }
                                    False -> {
                                        let v231 = { "test_" } <> { v229 }
                                        v231
                                    }
                                }
                            let v233 = { v226 } <> { v232 }
                            let v234 = { v233 } <> { "\t" }
                            let v235 = { v234 } <> { v159 }
                            let v236 = spiral_wrap_signed(v2 + 1, 32)
                            let v237 = Uh4Row(v148, v4)
                            let v238 = Uh4Row(v235, v5)
                            index_tests_78(v0, v8, v236, v3, v237, v238)
                        }
                        False -> {
                            let v240 = spiral_wrap_signed(v2 + 1, 32)
                            index_tests_78(v0, v8, v240, v3, v4, v5)
                        }
                    }
                }
            }
        }
        Uh3NoCell -> {
            v5
        }
    }
}
pub fn closure11(capt: Nil) -> fn(String) -> String {
    fn (v0) {
        let v1 = kino_text_size(v0)
        let v2 = 0 > v1
        let v39 =
            case v2 {
                True -> {
                    Us0LineDone
                }
                False -> {
                    let v4 = v1 == 0
                    case v4 {
                        True -> {
                            let v5 = ""
                            Us0LineGot(v5, 1)
                        }
                        False -> {
                            let v7 = 0 == v1
                            case v7 {
                                True -> {
                                    let v8 = v1 > 0
                                    let v12 =
                                        case v8 {
                                            True -> {
                                                let v9 = spiral_wrap_signed(v1 - 1, 32)
                                                let v10 = kino_text_at(v0, v9, 1)
                                                let v11 = v10 == "\n"
                                                v11
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    case v12 {
                                        True -> {
                                            let v13 = spiral_wrap_signed(v1 + 1, 32)
                                            let v14 = ""
                                            Us0LineGot(v14, v13)
                                        }
                                        False -> {
                                            Us0LineDone
                                        }
                                    }
                                }
                                False -> {
                                    let v18 = 0
                                    let v19 = "\n"
                                    let v20 = find_char_3(v0, v18, v19)
                                    let v21 = v20 < 0
                                    case v21 {
                                        True -> {
                                            let v22 = spiral_wrap_signed(v1 - 1, 32)
                                            let v23 = spiral_wrap_signed(v22 + 1, 32)
                                            let v24 = kino_text_at(v0, 0, v23)
                                            Us0LineGot(v24, v1)
                                        }
                                        False -> {
                                            let v26 = v20 == 0
                                            case v26 {
                                                True -> {
                                                    let v27 = spiral_wrap_signed(v20 + 1, 32)
                                                    let v28 = ""
                                                    Us0LineGot(v28, v27)
                                                }
                                                False -> {
                                                    let v30 = spiral_wrap_signed(v20 - 1, 32)
                                                    let v31 = spiral_wrap_signed(v30 + 1, 32)
                                                    let v32 = kino_text_at(v0, 0, v31)
                                                    let v33 = spiral_wrap_signed(v20 + 1, 32)
                                                    Us0LineGot(v32, v33)
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
        let v50 =
            case v39  {
                Us0LineDone -> {
                    Uh3NoCell
                }
                Us0LineGot(v41, v42) -> {
                    let v43 = 0
                    let v44 = 0
                    let v45 = 0
                    let v46 = parse_acc_26(v41, v43, v44, v45)
                    let v47 = Uh3NoCell
                    read_cells_53(v0, v42, v46, v47)
                }
            }
        let v51 = True
        let v52 = 0
        let v53 = ""
        let v54 = Uh4NoRow
        let v55 = False
        let v56 = 0
        let v57 = Uh4NoRow
        let v58 = Uh4NoRow
        let v59 = index_tests_78(v55, v50, v56, v53, v57, v58)
        let v60 = index_tests_78(v51, v50, v52, v53, v54, v59)
        let v61 = Uh4NoRow
        let v62 = rev_rows_58(v60, v61)
        join_rows_60(v62)
    }
}
pub fn read_sources_83(v0: String, v1: Int, v2: Int, v3: Uh6) -> Uh6 {
    let v4 = v2 <= 0
    case v4 {
        True -> {
            v3
        }
        False -> {
            let v5 = kino_text_size(v0)
            let v6 = v1 > v5
            let v46 =
                case v6 {
                    True -> {
                        Us0LineDone
                    }
                    False -> {
                        let v8 = v5 == 0
                        let v10 =
                            case v8 {
                                True -> {
                                    let v9 = v1 == 0
                                    v9
                                }
                                False -> {
                                    False
                                }
                            }
                        case v10 {
                            True -> {
                                let v11 = ""
                                Us0LineGot(v11, 1)
                            }
                            False -> {
                                let v13 = v1 == v5
                                case v13 {
                                    True -> {
                                        let v14 = v5 > 0
                                        let v18 =
                                            case v14 {
                                                True -> {
                                                    let v15 = spiral_wrap_signed(v5 - 1, 32)
                                                    let v16 = kino_text_at(v0, v15, 1)
                                                    let v17 = v16 == "\n"
                                                    v17
                                                }
                                                False -> {
                                                    False
                                                }
                                            }
                                        case v18 {
                                            True -> {
                                                let v19 = spiral_wrap_signed(v5 + 1, 32)
                                                let v20 = ""
                                                Us0LineGot(v20, v19)
                                            }
                                            False -> {
                                                Us0LineDone
                                            }
                                        }
                                    }
                                    False -> {
                                        let v24 = "\n"
                                        let v25 = find_char_3(v0, v1, v24)
                                        let v26 = v25 < 0
                                        case v26 {
                                            True -> {
                                                let v27 = spiral_wrap_signed(v5 - 1, 32)
                                                let v28 = spiral_wrap_signed(v27 - v1, 32)
                                                let v29 = spiral_wrap_signed(v28 + 1, 32)
                                                let v30 = kino_text_at(v0, v1, v29)
                                                Us0LineGot(v30, v5)
                                            }
                                            False -> {
                                                let v32 = v25 == v1
                                                case v32 {
                                                    True -> {
                                                        let v33 = spiral_wrap_signed(v25 + 1, 32)
                                                        let v34 = ""
                                                        Us0LineGot(v34, v33)
                                                    }
                                                    False -> {
                                                        let v36 = spiral_wrap_signed(v25 - 1, 32)
                                                        let v37 = spiral_wrap_signed(v36 - v1, 32)
                                                        let v38 = spiral_wrap_signed(v37 + 1, 32)
                                                        let v39 = kino_text_at(v0, v1, v38)
                                                        let v40 = spiral_wrap_signed(v25 + 1, 32)
                                                        Us0LineGot(v39, v40)
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
            case v46  {
                Us0LineDone -> {
                    v3
                }
                Us0LineGot(v47, v48) -> {
                    let v49 = kino_text_size(v0)
                    let v50 = v48 > v49
                    let v90 =
                        case v50 {
                            True -> {
                                Us0LineDone
                            }
                            False -> {
                                let v52 = v49 == 0
                                let v54 =
                                    case v52 {
                                        True -> {
                                            let v53 = v48 == 0
                                            v53
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v54 {
                                    True -> {
                                        let v55 = ""
                                        Us0LineGot(v55, 1)
                                    }
                                    False -> {
                                        let v57 = v48 == v49
                                        case v57 {
                                            True -> {
                                                let v58 = v49 > 0
                                                let v62 =
                                                    case v58 {
                                                        True -> {
                                                            let v59 = spiral_wrap_signed(v49 - 1, 32)
                                                            let v60 = kino_text_at(v0, v59, 1)
                                                            let v61 = v60 == "\n"
                                                            v61
                                                        }
                                                        False -> {
                                                            False
                                                        }
                                                    }
                                                case v62 {
                                                    True -> {
                                                        let v63 = spiral_wrap_signed(v49 + 1, 32)
                                                        let v64 = ""
                                                        Us0LineGot(v64, v63)
                                                    }
                                                    False -> {
                                                        Us0LineDone
                                                    }
                                                }
                                            }
                                            False -> {
                                                let v68 = "\n"
                                                let v69 = find_char_3(v0, v48, v68)
                                                let v70 = v69 < 0
                                                case v70 {
                                                    True -> {
                                                        let v71 = spiral_wrap_signed(v49 - 1, 32)
                                                        let v72 = spiral_wrap_signed(v71 - v48, 32)
                                                        let v73 = spiral_wrap_signed(v72 + 1, 32)
                                                        let v74 = kino_text_at(v0, v48, v73)
                                                        Us0LineGot(v74, v49)
                                                    }
                                                    False -> {
                                                        let v76 = v69 == v48
                                                        case v76 {
                                                            True -> {
                                                                let v77 = spiral_wrap_signed(v69 + 1, 32)
                                                                let v78 = ""
                                                                Us0LineGot(v78, v77)
                                                            }
                                                            False -> {
                                                                let v80 = spiral_wrap_signed(v69 - 1, 32)
                                                                let v81 = spiral_wrap_signed(v80 - v48, 32)
                                                                let v82 = spiral_wrap_signed(v81 + 1, 32)
                                                                let v83 = kino_text_at(v0, v48, v82)
                                                                let v84 = spiral_wrap_signed(v69 + 1, 32)
                                                                Us0LineGot(v83, v84)
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
                    case v90  {
                        Us0LineDone -> {
                            v3
                        }
                        Us0LineGot(v91, v92) -> {
                            let v93 = 0
                            let v94 = 0
                            let v95 = 0
                            let v96 = parse_acc_26(v91, v93, v94, v95)
                            let v97 = spiral_wrap_signed(v92 + v96, 32)
                            let v98 = spiral_wrap_signed(v2 - 1, 32)
                            let v99 = v96 <= 0
                            let v117 =
                                case v99 {
                                    True -> {
                                        let v100 = ""
                                        v100
                                    }
                                    False -> {
                                        let v101 = kino_text_size(v0)
                                        let v102 = v92 >= v101
                                        case v102 {
                                            True -> {
                                                let v103 = ""
                                                v103
                                            }
                                            False -> {
                                                let v104 = spiral_wrap_signed(v97 - 1, 32)
                                                let v105 = kino_text_size(v0)
                                                let v106 = v104 >= v105
                                                let v109 =
                                                    case v106 {
                                                        True -> {
                                                            let v107 = kino_text_size(v0)
                                                            let v108 = spiral_wrap_signed(v107 - 1, 32)
                                                            v108
                                                        }
                                                        False -> {
                                                            v104
                                                        }
                                                    }
                                                let v110 = v109 < v92
                                                case v110 {
                                                    True -> {
                                                        let v111 = ""
                                                        v111
                                                    }
                                                    False -> {
                                                        let v112 = spiral_wrap_signed(v109 - v92, 32)
                                                        let v113 = spiral_wrap_signed(v112 + 1, 32)
                                                        let v114 = kino_text_at(v0, v92, v113)
                                                        v114
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            let v118 = Uh6Source(v47, v117, v3)
                            read_sources_83(v0, v97, v98, v118)
                        }
                    }
                }
            }
        }
    }
}
pub fn rev_sources_84(v0: Uh6, v1: Uh6) -> Uh6 {
    case v0  {
        Uh6NoSource -> {
            v1
        }
        Uh6Source(v2, v3, v4) -> {
            let v5 = Uh6Source(v2, v3, v1)
            rev_sources_84(v4, v5)
        }
    }
}
pub fn package_line_86(v0: Uh5) -> String {
    case v0  {
        Uh5Nb(v2, v3) -> {
            case v3  {
                Uh5NoNb -> {
                    let v4 = { "--package " } <> { v2 }
                    v4
                }
                _ -> {
                    let v5 = { "--package " } <> { v2 }
                    let v6 = { v5 } <> { " " }
                    let v7 = package_line_86(v3)
                    let v8 = { v6 } <> { v7 }
                    v8
                }
            }
        }
        Uh5NoNb -> {
            let v1 = ""
            v1
        }
    }
}
pub fn snoc_87(v0: Uh5, v1: String) -> Uh5 {
    case v0  {
        Uh5Nb(v4, v5) -> {
            let v6 = snoc_87(v5, v1)
            Uh5Nb(v4, v6)
        }
        Uh5NoNb -> {
            let v2 = Uh5NoNb
            Uh5Nb(v1, v2)
        }
    }
}
pub fn join_nb_88(v0: Uh5) -> String {
    case v0  {
        Uh5Nb(v2, v3) -> {
            case v3  {
                Uh5NoNb -> {
                    v2
                }
                _ -> {
                    let v4 = { v2 } <> { "\n" }
                    let v5 = join_nb_88(v3)
                    let v6 = { v4 } <> { v5 }
                    v6
                }
            }
        }
        Uh5NoNb -> {
            let v1 = ""
            v1
        }
    }
}
pub fn join_rev_90(v0: Uh5, v1: String, v2: Int) -> String {
    case v0  {
        Uh5Nb(v3, v4) -> {
            let v5 = v2 == 0
            case v5 {
                True -> {
                    let v6 = 1
                    join_rev_90(v4, v3, v6)
                }
                False -> {
                    let v8 = { v3 } <> { "\n" }
                    let v9 = { v8 } <> { v1 }
                    let v10 = 1
                    join_rev_90(v4, v9, v10)
                }
            }
        }
        Uh5NoNb -> {
            v1
        }
    }
}
pub fn rev_nb_91(v0: Uh5, v1: Uh5) -> Uh5 {
    case v0  {
        Uh5Nb(v2, v3) -> {
            let v4 = Uh5Nb(v2, v1)
            rev_nb_91(v3, v4)
        }
        Uh5NoNb -> {
            v1
        }
    }
}
pub fn skip_ws_93(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = v4 == " "
            case v5 {
                True -> {
                    let v6 = spiral_wrap_signed(v1 + 1, 32)
                    skip_ws_93(v0, v6)
                }
                False -> {
                    let v8 = v4 == "\t"
                    case v8 {
                        True -> {
                            let v9 = spiral_wrap_signed(v1 + 1, 32)
                            skip_ws_93(v0, v9)
                        }
                        False -> {
                            v1
                        }
                    }
                }
            }
        }
    }
}
pub fn rev_flags_94(v0: Uh8, v1: Uh8) -> Uh8 {
    case v0  {
        Uh8Flag(v2, v3) -> {
            let v4 = Uh8Flag(v2, v1)
            rev_flags_94(v3, v4)
        }
        Uh8NoFlag -> {
            v1
        }
    }
}
pub fn take_token_95(v0: String, v1: Int) -> Int {
    let v2 = kino_text_size(v0)
    let v3 = v1 >= v2
    case v3 {
        True -> {
            v1
        }
        False -> {
            let v4 = kino_text_at(v0, v1, 1)
            let v5 = v4 == " "
            case v5 {
                True -> {
                    v1
                }
                False -> {
                    let v6 = v4 == "\t"
                    case v6 {
                        True -> {
                            v1
                        }
                        False -> {
                            let v7 = spiral_wrap_signed(v1 + 1, 32)
                            take_token_95(v0, v7)
                        }
                    }
                }
            }
        }
    }
}
pub fn flags_from_92(v0: String, v1: Int, v2: Uh8) -> Uh8 {
    let v3 = skip_ws_93(v0, v1)
    let v4 = kino_text_size(v0)
    let v5 = v3 >= v4
    case v5 {
        True -> {
            let v6 = Uh8NoFlag
            rev_flags_94(v2, v6)
        }
        False -> {
            let v8 = take_token_95(v0, v3)
            let v9 = spiral_wrap_signed(v8 - v3, 32)
            let v10 = v9 <= 0
            let v29 =
                case v10 {
                    True -> {
                        let v11 = ""
                        v11
                    }
                    False -> {
                        let v12 = kino_text_size(v0)
                        let v13 = v3 >= v12
                        case v13 {
                            True -> {
                                let v14 = ""
                                v14
                            }
                            False -> {
                                let v15 = spiral_wrap_signed(v3 + v9, 32)
                                let v16 = spiral_wrap_signed(v15 - 1, 32)
                                let v17 = kino_text_size(v0)
                                let v18 = v16 >= v17
                                let v21 =
                                    case v18 {
                                        True -> {
                                            let v19 = kino_text_size(v0)
                                            let v20 = spiral_wrap_signed(v19 - 1, 32)
                                            v20
                                        }
                                        False -> {
                                            v16
                                        }
                                    }
                                let v22 = v21 < v3
                                case v22 {
                                    True -> {
                                        let v23 = ""
                                        v23
                                    }
                                    False -> {
                                        let v24 = spiral_wrap_signed(v21 - v3, 32)
                                        let v25 = spiral_wrap_signed(v24 + 1, 32)
                                        let v26 = kino_text_at(v0, v3, v25)
                                        v26
                                    }
                                }
                            }
                        }
                    }
                }
            let v30 = Uh8Flag(v29, v2)
            flags_from_92(v0, v8, v30)
        }
    }
}
pub fn has_nb_97(v0: Uh5, v1: String) -> Bool {
    case v0  {
        Uh5Nb(v2, v3) -> {
            let v4 = v2 == v1
            case v4 {
                True -> {
                    True
                }
                False -> {
                    has_nb_97(v3, v1)
                }
            }
        }
        Uh5NoNb -> {
            False
        }
    }
}
pub fn read_flags_96(v0: Uh8, v1: Uh5, v2: Int, v3: Int, v4: String) -> #(Uh5, Int, Int, String) {
    case v0  {
        Uh8Flag(v5, v6) -> {
            let v7 = "--package" == v5
            case v7 {
                True -> {
                    case v6  {
                        Uh8Flag(v8, v9) -> {
                            let v10 = "--"
                            let v11 = kino_text_size(v10)
                            let v12 = kino_text_size(v8)
                            let v13 = v11 > v12
                            let v20 =
                                case v13 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v14 = v11 == 0
                                        case v14 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v15 = spiral_wrap_signed(v11 - 1, 32)
                                                let v16 = spiral_wrap_signed(v15 + 1, 32)
                                                let v17 = kino_text_at(v8, 0, v16)
                                                let v18 = v17 == "--"
                                                v18
                                            }
                                        }
                                    }
                                }
                            case v20 {
                                True -> {
                                    read_flags_96(v9, v1, v2, v3, v4)
                                }
                                False -> {
                                    let v25 = has_nb_97(v1, v8)
                                    let v27 =
                                        case v25 {
                                            True -> {
                                                v1
                                            }
                                            False -> {
                                                snoc_87(v1, v8)
                                            }
                                        }
                                    read_flags_96(v9, v27, v2, v3, v4)
                                }
                            }
                        }
                        _ -> {
                            read_flags_96(v6, v1, v2, v3, v4)
                        }
                    }
                }
                False -> {
                    let v44 = "--ignore" == v5
                    case v44 {
                        True -> {
                            let v45 = 3
                            read_flags_96(v6, v1, v45, v3, v4)
                        }
                        False -> {
                            let v50 = "--test" == v5
                            case v50 {
                                True -> {
                                    case v6  {
                                        Uh8Flag(v51, v52) -> {
                                            let v53 = "static" == v51
                                            case v53 {
                                                True -> {
                                                    let v54 = v2 == 3
                                                    let v55 =
                                                        case v54 {
                                                            True -> {
                                                                3
                                                            }
                                                            False -> {
                                                                2
                                                            }
                                                        }
                                                    read_flags_96(v52, v1, v55, v3, v4)
                                                }
                                                False -> {
                                                    let v60 = v2 >= 2
                                                    let v61 =
                                                        case v60 {
                                                            True -> {
                                                                v2
                                                            }
                                                            False -> {
                                                                1
                                                            }
                                                        }
                                                    read_flags_96(v6, v1, v61, v3, v4)
                                                }
                                            }
                                        }
                                        _ -> {
                                            let v70 = v2 >= 2
                                            let v71 =
                                                case v70 {
                                                    True -> {
                                                        v2
                                                    }
                                                    False -> {
                                                        1
                                                    }
                                                }
                                            read_flags_96(v6, v1, v71, v3, v4)
                                        }
                                    }
                                }
                                False -> {
                                    let v80 = "--real" == v5
                                    case v80 {
                                        True -> {
                                            let v81 = 1
                                            read_flags_96(v6, v1, v2, v81, v4)
                                        }
                                        False -> {
                                            let v86 = "--timeout" == v5
                                            case v86 {
                                                True -> {
                                                    case v6  {
                                                        Uh8Flag(v87, v88) -> {
                                                            let v89 = 0
                                                            let v90 = 0
                                                            let v91 = 0
                                                            let v92 = parse_acc_26(v87, v89, v90, v91)
                                                            let v93 = v92 > 0
                                                            let v94 =
                                                                case v93 {
                                                                    True -> {
                                                                        v87
                                                                    }
                                                                    False -> {
                                                                        v4
                                                                    }
                                                                }
                                                            read_flags_96(v88, v1, v2, v3, v94)
                                                        }
                                                        _ -> {
                                                            read_flags_96(v6, v1, v2, v3, v4)
                                                        }
                                                    }
                                                }
                                                False -> {
                                                    read_flags_96(v6, v1, v2, v3, v4)
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
        Uh8NoFlag -> {
            #(v1, v2, v3, v4)
        }
    }
}
pub fn scan_lines_89(v0: String, v1: Int, v2: Uh5, v3: Int, v4: Int, v5: String, v6: Uh5, v7: Uh5, v8: Int) -> #(Uh5, Int, Int, String, String, Uh5, Int) {
    let v9 = kino_text_size(v0)
    let v10 = v1 > v9
    let v50 =
        case v10 {
            True -> {
                Us0LineDone
            }
            False -> {
                let v12 = v9 == 0
                let v14 =
                    case v12 {
                        True -> {
                            let v13 = v1 == 0
                            v13
                        }
                        False -> {
                            False
                        }
                    }
                case v14 {
                    True -> {
                        let v15 = ""
                        Us0LineGot(v15, 1)
                    }
                    False -> {
                        let v17 = v1 == v9
                        case v17 {
                            True -> {
                                let v18 = v9 > 0
                                let v22 =
                                    case v18 {
                                        True -> {
                                            let v19 = spiral_wrap_signed(v9 - 1, 32)
                                            let v20 = kino_text_at(v0, v19, 1)
                                            let v21 = v20 == "\n"
                                            v21
                                        }
                                        False -> {
                                            False
                                        }
                                    }
                                case v22 {
                                    True -> {
                                        let v23 = spiral_wrap_signed(v9 + 1, 32)
                                        let v24 = ""
                                        Us0LineGot(v24, v23)
                                    }
                                    False -> {
                                        Us0LineDone
                                    }
                                }
                            }
                            False -> {
                                let v28 = "\n"
                                let v29 = find_char_3(v0, v1, v28)
                                let v30 = v29 < 0
                                case v30 {
                                    True -> {
                                        let v31 = spiral_wrap_signed(v9 - 1, 32)
                                        let v32 = spiral_wrap_signed(v31 - v1, 32)
                                        let v33 = spiral_wrap_signed(v32 + 1, 32)
                                        let v34 = kino_text_at(v0, v1, v33)
                                        Us0LineGot(v34, v9)
                                    }
                                    False -> {
                                        let v36 = v29 == v1
                                        case v36 {
                                            True -> {
                                                let v37 = spiral_wrap_signed(v29 + 1, 32)
                                                let v38 = ""
                                                Us0LineGot(v38, v37)
                                            }
                                            False -> {
                                                let v40 = spiral_wrap_signed(v29 - 1, 32)
                                                let v41 = spiral_wrap_signed(v40 - v1, 32)
                                                let v42 = spiral_wrap_signed(v41 + 1, 32)
                                                let v43 = kino_text_at(v0, v1, v42)
                                                let v44 = spiral_wrap_signed(v29 + 1, 32)
                                                Us0LineGot(v43, v44)
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
    case v50  {
        Us0LineDone -> {
            let v51 = ""
            let v52 = 0
            let v53 = join_rev_90(v6, v51, v52)
            let v54 = kino_text_size(v53)
            let v55 = trim_nl_end_30(v53, v54)
            let v56 = v55 <= 0
            let v63 =
                case v56 {
                    True -> {
                        v51
                    }
                    False -> {
                        let v57 = kino_text_size(v53)
                        let v58 = v55 == v57
                        case v58 {
                            True -> {
                                v53
                            }
                            False -> {
                                let v59 = spiral_wrap_signed(v55 - 1, 32)
                                let v60 = spiral_wrap_signed(v59 + 1, 32)
                                let v61 = kino_text_at(v53, 0, v60)
                                v61
                            }
                        }
                    }
                }
            let v64 = Uh5NoNb
            let v65 = rev_nb_91(v7, v64)
            #(v2, v3, v4, v5, v63, v65, v8)
        }
        Us0LineGot(v66, v67) -> {
            let v68 = 0
            let v69 = trim_start_17(v66, v68)
            let v70 = kino_text_size(v66)
            let v71 = trim_end_18(v66, v70)
            let v72 = v71 <= v69
            let v78 =
                case v72 {
                    True -> {
                        let v73 = ""
                        v73
                    }
                    False -> {
                        let v74 = spiral_wrap_signed(v71 - 1, 32)
                        let v75 = spiral_wrap_signed(v74 - v69, 32)
                        let v76 = spiral_wrap_signed(v75 + 1, 32)
                        let v77 = kino_text_at(v66, v69, v76)
                        v77
                    }
                }
            let v79 = "///"
            let v80 = kino_text_size(v79)
            let v81 = kino_text_size(v78)
            let v82 = v80 > v81
            let v89 =
                case v82 {
                    True -> {
                        False
                    }
                    False -> {
                        let v83 = v80 == 0
                        case v83 {
                            True -> {
                                True
                            }
                            False -> {
                                let v84 = spiral_wrap_signed(v80 - 1, 32)
                                let v85 = spiral_wrap_signed(v84 + 1, 32)
                                let v86 = kino_text_at(v78, 0, v85)
                                let v87 = v86 == "///"
                                v87
                            }
                        }
                    }
                }
            case v89 {
                True -> {
                    let v90 = "///- "
                    let v91 = kino_text_size(v90)
                    let v92 = kino_text_size(v78)
                    let v93 = v91 > v92
                    let v100 =
                        case v93 {
                            True -> {
                                False
                            }
                            False -> {
                                let v94 = v91 == 0
                                case v94 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v95 = spiral_wrap_signed(v91 - 1, 32)
                                        let v96 = spiral_wrap_signed(v95 + 1, 32)
                                        let v97 = kino_text_at(v78, 0, v96)
                                        let v98 = v97 == "///- "
                                        v98
                                    }
                                }
                            }
                        }
                    case v100 {
                        True -> {
                            let v101 = kino_text_size(v90)
                            let v102 = kino_text_size(v78)
                            let v103 = v101 >= v102
                            let v111 =
                                case v103 {
                                    True -> {
                                        let v104 = ""
                                        v104
                                    }
                                    False -> {
                                        let v105 = v101 <= 0
                                        case v105 {
                                            True -> {
                                                v78
                                            }
                                            False -> {
                                                let v106 = spiral_wrap_signed(v102 - 1, 32)
                                                let v107 = spiral_wrap_signed(v106 - v101, 32)
                                                let v108 = spiral_wrap_signed(v107 + 1, 32)
                                                let v109 = kino_text_at(v78, v101, v108)
                                                v109
                                            }
                                        }
                                    }
                                }
                            let v112 = 0
                            let v113 = Uh8NoFlag
                            let v114 = flags_from_92(v111, v112, v113)
                            let #(v115, v116, v117, v118) = read_flags_96(v114, v2, v3, v4, v5)
                            scan_lines_89(v0, v67, v115, v116, v117, v118, v6, v7, v8)
                        }
                        False -> {
                            let v126 = "///>"
                            let v127 = kino_text_size(v126)
                            let v128 = kino_text_size(v78)
                            let v129 = v127 > v128
                            let v136 =
                                case v129 {
                                    True -> {
                                        False
                                    }
                                    False -> {
                                        let v130 = v127 == 0
                                        case v130 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v131 = spiral_wrap_signed(v127 - 1, 32)
                                                let v132 = spiral_wrap_signed(v131 + 1, 32)
                                                let v133 = kino_text_at(v78, 0, v132)
                                                let v134 = v133 == "///>"
                                                v134
                                            }
                                        }
                                    }
                                }
                            case v136 {
                                True -> {
                                    let v137 = kino_text_size(v126)
                                    let v138 = kino_text_size(v78)
                                    let v139 = v137 >= v138
                                    let v147 =
                                        case v139 {
                                            True -> {
                                                let v140 = ""
                                                v140
                                            }
                                            False -> {
                                                let v141 = v137 <= 0
                                                case v141 {
                                                    True -> {
                                                        v78
                                                    }
                                                    False -> {
                                                        let v142 = spiral_wrap_signed(v138 - 1, 32)
                                                        let v143 = spiral_wrap_signed(v142 - v137, 32)
                                                        let v144 = spiral_wrap_signed(v143 + 1, 32)
                                                        let v145 = kino_text_at(v78, v137, v144)
                                                        v145
                                                    }
                                                }
                                            }
                                        }
                                    let v148 = 0
                                    let v149 = trim_start_17(v147, v148)
                                    let v150 = kino_text_size(v147)
                                    let v151 = trim_end_18(v147, v150)
                                    let v152 = v151 <= v149
                                    let v158 =
                                        case v152 {
                                            True -> {
                                                let v153 = ""
                                                v153
                                            }
                                            False -> {
                                                let v154 = spiral_wrap_signed(v151 - 1, 32)
                                                let v155 = spiral_wrap_signed(v154 - v149, 32)
                                                let v156 = spiral_wrap_signed(v155 + 1, 32)
                                                let v157 = kino_text_at(v147, v149, v156)
                                                v157
                                            }
                                        }
                                    let v159 = v158 == "_"
                                    let v160 =
                                        case v159 {
                                            True -> {
                                                1
                                            }
                                            False -> {
                                                v8
                                            }
                                        }
                                    scan_lines_89(v0, v67, v2, v3, v4, v5, v6, v7, v160)
                                }
                                False -> {
                                    scan_lines_89(v0, v67, v2, v3, v4, v5, v6, v7, v8)
                                }
                            }
                        }
                    }
                }
                False -> {
                    let v189 = "open "
                    let v190 = kino_text_size(v189)
                    let v191 = kino_text_size(v78)
                    let v192 = v190 > v191
                    let v199 =
                        case v192 {
                            True -> {
                                False
                            }
                            False -> {
                                let v193 = v190 == 0
                                case v193 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v194 = spiral_wrap_signed(v190 - 1, 32)
                                        let v195 = spiral_wrap_signed(v194 + 1, 32)
                                        let v196 = kino_text_at(v78, 0, v195)
                                        let v197 = v196 == "open "
                                        v197
                                    }
                                }
                            }
                        }
                    let v201 =
                        case v199 {
                            True -> {
                                Uh5Nb(v78, v7)
                            }
                            False -> {
                                v7
                            }
                        }
                    let v202 = Uh5Nb(v66, v6)
                    scan_lines_89(v0, v67, v2, v3, v4, v5, v202, v201, v8)
                }
            }
        }
    }
}
pub fn merge_98(v0: Uh5, v1: Uh5) -> Uh5 {
    case v1  {
        Uh5Nb(v2, v3) -> {
            let v4 = has_nb_97(v0, v2)
            let v6 =
                case v4 {
                    True -> {
                        v0
                    }
                    False -> {
                        snoc_87(v0, v2)
                    }
                }
            merge_98(v6, v3)
        }
        Uh5NoNb -> {
            v0
        }
    }
}
pub fn walk_85(v0: Us7, v1: Uh6, v2: Int, v3: Int, v4: Uh5, v5: Uh5, v6: Uh5, v7: Uh5, v8: Uh7) -> Uh7 {
    case v1  {
        Uh6NoSource -> {
            case v0  {
                Us7EveryCell -> {
                    v8
                }
                Us7TestsAndWholeFile -> {
                    let v9 = v3 < 0
                    case v9 {
                        True -> {
                            v8
                        }
                        False -> {
                            let v13 =
                                case v4  {
                                    Uh5NoNb -> {
                                        let v10 = ""
                                        v10
                                    }
                                    _ -> {
                                        let v11 = package_line_86(v4)
                                        let v12 = { "///- " } <> { v11 }
                                        v12
                                    }
                                }
                            let v14 = v13 == ""
                            let v18 =
                                case v14 {
                                    True -> {
                                        Uh5NoNb
                                    }
                                    False -> {
                                        let v16 = Uh5NoNb
                                        snoc_87(v16, v13)
                                    }
                                }
                            let v19 = join_nb_88(v5)
                            let v20 = v19 == ""
                            let v22 =
                                case v20 {
                                    True -> {
                                        v18
                                    }
                                    False -> {
                                        snoc_87(v18, v19)
                                    }
                                }
                            let v23 = join_nb_88(v6)
                            let v24 = v23 == ""
                            let v26 =
                                case v24 {
                                    True -> {
                                        v22
                                    }
                                    False -> {
                                        snoc_87(v22, v23)
                                    }
                                }
                            let v27 = join_nb_88(v26)
                            let v28 = join_nb_88(v7)
                            let v29 = "-"
                            Uh7Step(v3, v29, v27, v28, v8)
                        }
                    }
                }
            }
        }
        Uh6Source(v34, v35, v36) -> {
            let v37 = v34 == "spiral"
            let v38 = v37 != True
            case v38 {
                True -> {
                    let v39 = spiral_wrap_signed(v2 + 1, 32)
                    walk_85(v0, v36, v39, v3, v4, v5, v6, v7, v8)
                }
                False -> {
                    let v41 = "\r\n"
                    let v42 = "\n"
                    let v43 = 0
                    let v44 = ""
                    let v45 = replace_from_0(v35, v41, v42, v43, v44)
                    let v46 = 0
                    let v47 = Uh5NoNb
                    let v48 = 0
                    let v49 = 0
                    let v50 = Uh5NoNb
                    let v51 = Uh5NoNb
                    let v52 = 0
                    let #(v53, v54, v55, v56, v57, v58, v59) = scan_lines_89(v45, v46, v47, v48, v49, v44, v50, v51, v52)
                    let v60 = merge_98(v4, v53)
                    let v61 = v54 == 3
                    case v61 {
                        True -> {
                            let v62 = spiral_wrap_signed(v2 + 1, 32)
                            walk_85(v0, v36, v62, v3, v60, v5, v6, v7, v8)
                        }
                        False -> {
                            let v64 = v59 == 1
                            let #(v239, v240) =
                                case v64 {
                                    True -> {
                                        let v65 = "///> _"
                                        #(v65, v44)
                                    }
                                    False -> {
                                        let v66 = v55 == 1
                                        case v66 {
                                            True -> {
                                                let v67 = 0
                                                let v68 = Uh0NoLine
                                                let v69 = collect_4(v57, v67, v68)
                                                let v70 = count_lines_6(v69)
                                                let v71 = spiral_wrap_signed(v70 - 1, 32)
                                                let v72 = last_block_7(v69, v71)
                                                let v73 = v72 >= 0
                                                let v122 =
                                                    case v73 {
                                                        True -> {
                                                            let v74 = nth_line_8(v69, v72)
                                                            let v75 = "inl main "
                                                            let v76 = kino_text_size(v75)
                                                            let v77 = kino_text_size(v74)
                                                            let v78 = v76 > v77
                                                            let v85 =
                                                                case v78 {
                                                                    True -> {
                                                                        False
                                                                    }
                                                                    False -> {
                                                                        let v79 = v76 == 0
                                                                        case v79 {
                                                                            True -> {
                                                                                True
                                                                            }
                                                                            False -> {
                                                                                let v80 = spiral_wrap_signed(v76 - 1, 32)
                                                                                let v81 = spiral_wrap_signed(v80 + 1, 32)
                                                                                let v82 = kino_text_at(v74, 0, v81)
                                                                                let v83 = v82 == "inl main "
                                                                                v83
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            case v85 {
                                                                True -> {
                                                                    True
                                                                }
                                                                False -> {
                                                                    let v86 = "let main "
                                                                    let v87 = kino_text_size(v86)
                                                                    let v88 = kino_text_size(v74)
                                                                    let v89 = v87 > v88
                                                                    let v96 =
                                                                        case v89 {
                                                                            True -> {
                                                                                False
                                                                            }
                                                                            False -> {
                                                                                let v90 = v87 == 0
                                                                                case v90 {
                                                                                    True -> {
                                                                                        True
                                                                                    }
                                                                                    False -> {
                                                                                        let v91 = spiral_wrap_signed(v87 - 1, 32)
                                                                                        let v92 = spiral_wrap_signed(v91 + 1, 32)
                                                                                        let v93 = kino_text_at(v74, 0, v92)
                                                                                        let v94 = v93 == "let main "
                                                                                        v94
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    case v96 {
                                                                        True -> {
                                                                            True
                                                                        }
                                                                        False -> {
                                                                            let v97 = "inl main("
                                                                            let v98 = kino_text_size(v97)
                                                                            let v99 = kino_text_size(v74)
                                                                            let v100 = v98 > v99
                                                                            let v107 =
                                                                                case v100 {
                                                                                    True -> {
                                                                                        False
                                                                                    }
                                                                                    False -> {
                                                                                        let v101 = v98 == 0
                                                                                        case v101 {
                                                                                            True -> {
                                                                                                True
                                                                                            }
                                                                                            False -> {
                                                                                                let v102 = spiral_wrap_signed(v98 - 1, 32)
                                                                                                let v103 = spiral_wrap_signed(v102 + 1, 32)
                                                                                                let v104 = kino_text_at(v74, 0, v103)
                                                                                                let v105 = v104 == "inl main("
                                                                                                v105
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            case v107 {
                                                                                True -> {
                                                                                    True
                                                                                }
                                                                                False -> {
                                                                                    let v108 = "let main("
                                                                                    let v109 = kino_text_size(v108)
                                                                                    let v110 = kino_text_size(v74)
                                                                                    let v111 = v109 > v110
                                                                                    case v111 {
                                                                                        True -> {
                                                                                            False
                                                                                        }
                                                                                        False -> {
                                                                                            let v112 = v109 == 0
                                                                                            case v112 {
                                                                                                True -> {
                                                                                                    True
                                                                                                }
                                                                                                False -> {
                                                                                                    let v113 = spiral_wrap_signed(v109 - 1, 32)
                                                                                                    let v114 = spiral_wrap_signed(v113 + 1, 32)
                                                                                                    let v115 = kino_text_at(v74, 0, v114)
                                                                                                    let v116 = v115 == "let main("
                                                                                                    v116
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
                                                        False -> {
                                                            False
                                                        }
                                                    }
                                                let #(v163, v164) =
                                                    case v122 {
                                                        True -> {
                                                            let v123 = kino_text_size(v57)
                                                            let v124 = v123 == 0
                                                            let v131 =
                                                                case v124 {
                                                                    True -> {
                                                                        v42
                                                                    }
                                                                    False -> {
                                                                        let v125 = kino_text_size(v57)
                                                                        let v126 = spiral_wrap_signed(v125 - 1, 32)
                                                                        let v127 = kino_text_at(v57, v126, 1)
                                                                        let v128 = v127 == "\n"
                                                                        case v128 {
                                                                            True -> {
                                                                                v57
                                                                            }
                                                                            False -> {
                                                                                let v129 = { v57 } <> { "\n" }
                                                                                v129
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            #(v131, 0)
                                                        }
                                                        False -> {
                                                            let v132 = -1
                                                            let v133 = search_top_9(v69, v71, v132)
                                                            let v134 = v133 < 0
                                                            case v134 {
                                                                True -> {
                                                                    let v135 = kino_text_size(v57)
                                                                    let v136 = v135 == 0
                                                                    let v143 =
                                                                        case v136 {
                                                                            True -> {
                                                                                v42
                                                                            }
                                                                            False -> {
                                                                                let v137 = kino_text_size(v57)
                                                                                let v138 = spiral_wrap_signed(v137 - 1, 32)
                                                                                let v139 = kino_text_at(v57, v138, 1)
                                                                                let v140 = v139 == "\n"
                                                                                case v140 {
                                                                                    True -> {
                                                                                        v57
                                                                                    }
                                                                                    False -> {
                                                                                        let v141 = { v57 } <> { "\n" }
                                                                                        v141
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    let v144 = { v143 } <> { "inl main () : i32 = 0i32\n" }
                                                                    #(v144, 2)
                                                                }
                                                                False -> {
                                                                    let v145 = 0
                                                                    let v146 = map_main_16(v69, v145, v133)
                                                                    let v151 =
                                                                        case v146  {
                                                                            Uh0Line(v147, v148) -> {
                                                                                join_from_19(v148, v147)
                                                                            }
                                                                            Uh0NoLine -> {
                                                                                v44
                                                                            }
                                                                        }
                                                                    let v152 = kino_text_size(v151)
                                                                    let v153 = v152 == 0
                                                                    let v160 =
                                                                        case v153 {
                                                                            True -> {
                                                                                v42
                                                                            }
                                                                            False -> {
                                                                                let v154 = kino_text_size(v151)
                                                                                let v155 = spiral_wrap_signed(v154 - 1, 32)
                                                                                let v156 = kino_text_at(v151, v155, 1)
                                                                                let v157 = v156 == "\n"
                                                                                case v157 {
                                                                                    True -> {
                                                                                        v151
                                                                                    }
                                                                                    False -> {
                                                                                        let v158 = { v151 } <> { "\n" }
                                                                                        v158
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    #(v160, 1)
                                                                }
                                                            }
                                                        }
                                                    }
                                                let v165 = v164 == 1
                                                case v165 {
                                                    True -> {
                                                        let v166 = "inl main () : i32 ="
                                                        let v167 = "inl spiral_kino_real () ="
                                                        let v168 = 0
                                                        let v169 = replace_from_0(v163, v166, v167, v168, v44)
                                                        let v172 =
                                                            case v60  {
                                                                Uh5NoNb -> {
                                                                    v44
                                                                }
                                                                _ -> {
                                                                    let v170 = package_line_86(v60)
                                                                    let v171 = { "///- " } <> { v170 }
                                                                    v171
                                                                }
                                                            }
                                                        let v173 = v172 == ""
                                                        let v177 =
                                                            case v173 {
                                                                True -> {
                                                                    Uh5NoNb
                                                                }
                                                                False -> {
                                                                    let v175 = Uh5NoNb
                                                                    snoc_87(v175, v172)
                                                                }
                                                            }
                                                        let v178 = Uh5NoNb
                                                        let v179 = join_nb_88(v178)
                                                        let v180 = v179 == ""
                                                        let v182 =
                                                            case v180 {
                                                                True -> {
                                                                    v177
                                                                }
                                                                False -> {
                                                                    snoc_87(v177, v179)
                                                                }
                                                            }
                                                        let v183 = Uh5NoNb
                                                        let v184 = join_nb_88(v183)
                                                        let v185 = v184 == ""
                                                        let v187 =
                                                            case v185 {
                                                                True -> {
                                                                    v182
                                                                }
                                                                False -> {
                                                                    snoc_87(v182, v184)
                                                                }
                                                            }
                                                        let v188 = "inl main () : i32 =\n    inl _ = real spiral_kino_real ()\n    0i32"
                                                        let v189 = snoc_87(v187, v188)
                                                        let v190 = join_nb_88(v189)
                                                        let v191 = snoc_87(v7, v169)
                                                        let v192 = join_nb_88(v191)
                                                        #(v190, v192)
                                                    }
                                                    False -> {
                                                        let v195 =
                                                            case v60  {
                                                                Uh5NoNb -> {
                                                                    v44
                                                                }
                                                                _ -> {
                                                                    let v193 = package_line_86(v60)
                                                                    let v194 = { "///- " } <> { v193 }
                                                                    v194
                                                                }
                                                            }
                                                        let v196 = v195 == ""
                                                        let v200 =
                                                            case v196 {
                                                                True -> {
                                                                    Uh5NoNb
                                                                }
                                                                False -> {
                                                                    let v198 = Uh5NoNb
                                                                    snoc_87(v198, v195)
                                                                }
                                                            }
                                                        let v201 = Uh5NoNb
                                                        let v202 = join_nb_88(v201)
                                                        let v203 = v202 == ""
                                                        let v205 =
                                                            case v203 {
                                                                True -> {
                                                                    v200
                                                                }
                                                                False -> {
                                                                    snoc_87(v200, v202)
                                                                }
                                                            }
                                                        let v206 = Uh5NoNb
                                                        let v207 = join_nb_88(v206)
                                                        let v208 = v207 == ""
                                                        let v210 =
                                                            case v208 {
                                                                True -> {
                                                                    v205
                                                                }
                                                                False -> {
                                                                    snoc_87(v205, v207)
                                                                }
                                                            }
                                                        let v211 = join_nb_88(v210)
                                                        let v212 = snoc_87(v7, v57)
                                                        let v213 = join_nb_88(v212)
                                                        #(v211, v213)
                                                    }
                                                }
                                            }
                                            False -> {
                                                let v218 =
                                                    case v60  {
                                                        Uh5NoNb -> {
                                                            v44
                                                        }
                                                        _ -> {
                                                            let v216 = package_line_86(v60)
                                                            let v217 = { "///- " } <> { v216 }
                                                            v217
                                                        }
                                                    }
                                                let v219 = v218 == ""
                                                let v223 =
                                                    case v219 {
                                                        True -> {
                                                            Uh5NoNb
                                                        }
                                                        False -> {
                                                            let v221 = Uh5NoNb
                                                            snoc_87(v221, v218)
                                                        }
                                                    }
                                                let v224 = join_nb_88(v5)
                                                let v225 = v224 == ""
                                                let v227 =
                                                    case v225 {
                                                        True -> {
                                                            v223
                                                        }
                                                        False -> {
                                                            snoc_87(v223, v224)
                                                        }
                                                    }
                                                let v228 = join_nb_88(v6)
                                                let v229 = v228 == ""
                                                let v231 =
                                                    case v229 {
                                                        True -> {
                                                            v227
                                                        }
                                                        False -> {
                                                            snoc_87(v227, v228)
                                                        }
                                                    }
                                                let v232 = v57 == ""
                                                let v234 =
                                                    case v232 {
                                                        True -> {
                                                            v231
                                                        }
                                                        False -> {
                                                            snoc_87(v231, v57)
                                                        }
                                                    }
                                                let v235 = join_nb_88(v234)
                                                let v236 = join_nb_88(v7)
                                                #(v235, v236)
                                            }
                                        }
                                    }
                                }
                            let v241 = v56 == ""
                            let v243 =
                                case v241 {
                                    True -> {
                                        let v242 = "-"
                                        v242
                                    }
                                    False -> {
                                        v56
                                    }
                                }
                            let v248 =
                                case v0  {
                                    Us7EveryCell -> {
                                        True
                                    }
                                    Us7TestsAndWholeFile -> {
                                        let v244 = v54 == 1
                                        case v244 {
                                            True -> {
                                                True
                                            }
                                            False -> {
                                                let v245 = v54 == 2
                                                v245
                                            }
                                        }
                                    }
                                }
                            let v250 =
                                case v248 {
                                    True -> {
                                        Uh7Step(v2, v243, v239, v240, v8)
                                    }
                                    False -> {
                                        v8
                                    }
                                }
                            let v251 = v54 == 1
                            let v252 = v251 != True
                            let v254 =
                                case v252 {
                                    True -> {
                                        let v253 = v59 == 0
                                        v253
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            let v267 =
                                case v254 {
                                    True -> {
                                        let v255 = 0
                                        let v256 = trim_start_17(v57, v255)
                                        let v257 = kino_text_size(v57)
                                        let v258 = trim_end_18(v57, v257)
                                        let v259 = v258 <= v256
                                        let v264 =
                                            case v259 {
                                                True -> {
                                                    v44
                                                }
                                                False -> {
                                                    let v260 = spiral_wrap_signed(v258 - 1, 32)
                                                    let v261 = spiral_wrap_signed(v260 - v256, 32)
                                                    let v262 = spiral_wrap_signed(v261 + 1, 32)
                                                    let v263 = kino_text_at(v57, v256, v262)
                                                    v263
                                                }
                                            }
                                        let v265 = v264 == ""
                                        let v266 = v265 != True
                                        v266
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            let v269 =
                                case v267 {
                                    True -> {
                                        let v268 = v54 == 0
                                        v268
                                    }
                                    False -> {
                                        False
                                    }
                                }
                            let v270 =
                                case v269 {
                                    True -> {
                                        v2
                                    }
                                    False -> {
                                        v3
                                    }
                                }
                            let v271 = v55 == 1
                            case v271 {
                                True -> {
                                    let v272 = spiral_wrap_signed(v2 + 1, 32)
                                    let v274 =
                                        case v267 {
                                            True -> {
                                                snoc_87(v7, v57)
                                            }
                                            False -> {
                                                v7
                                            }
                                        }
                                    walk_85(v0, v36, v272, v270, v60, v5, v6, v274, v250)
                                }
                                False -> {
                                    case v251 {
                                        True -> {
                                            let v276 = spiral_wrap_signed(v2 + 1, 32)
                                            let v277 = merge_98(v5, v58)
                                            walk_85(v0, v36, v276, v270, v60, v277, v6, v7, v250)
                                        }
                                        False -> {
                                            case v267 {
                                                True -> {
                                                    let v279 = spiral_wrap_signed(v2 + 1, 32)
                                                    let v280 = snoc_87(v6, v57)
                                                    walk_85(v0, v36, v279, v270, v60, v5, v280, v7, v250)
                                                }
                                                False -> {
                                                    let v282 = spiral_wrap_signed(v2 + 1, 32)
                                                    walk_85(v0, v36, v282, v270, v60, v5, v6, v7, v250)
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
pub fn rev_steps_99(v0: Uh7, v1: Uh7) -> Uh7 {
    case v0  {
        Uh7NoStep -> {
            v1
        }
        Uh7Step(v2, v3, v4, v5, v6) -> {
            let v7 = Uh7Step(v2, v3, v4, v5, v1)
            rev_steps_99(v6, v7)
        }
    }
}
pub fn count_steps_100(v0: Uh7) -> Int {
    case v0  {
        Uh7NoStep -> {
            0
        }
        Uh7Step(v1, v2, v3, v4, v5) -> {
            let v6 = count_steps_100(v5)
            let v7 = spiral_wrap_signed(1 + v6, 32)
            v7
        }
    }
}
pub fn emit_steps_101(v0: Uh7) -> String {
    case v0  {
        Uh7NoStep -> {
            let v1 = ""
            v1
        }
        Uh7Step(v2, v3, v4, v5, v6) -> {
            let v7 = show_i32_20(v2)
            let v8 = { v7 } <> { "\n" }
            let v9 = { v8 } <> { v3 }
            let v10 = { v9 } <> { "\n" }
            let v11 = kino_text_size(v4)
            let v12 = show_i32_20(v11)
            let v13 = { v10 } <> { v12 }
            let v14 = { v13 } <> { "\n" }
            let v15 = { v14 } <> { v4 }
            let v16 = kino_text_size(v5)
            let v17 = show_i32_20(v16)
            let v18 = { v15 } <> { v17 }
            let v19 = { v18 } <> { "\n" }
            let v20 = { v19 } <> { v5 }
            let v21 = emit_steps_101(v6)
            let v22 = { v20 } <> { v21 }
            v22
        }
    }
}
pub fn closure12(capt: Nil) -> fn(String) -> String {
    fn (v0) {
        let v1 = "\r\n"
        let v2 = "\n"
        let v3 = 0
        let v4 = ""
        let v5 = replace_from_0(v0, v1, v2, v3, v4)
        let v6 = kino_text_size(v5)
        let v7 = 0 > v6
        let v41 =
            case v7 {
                True -> {
                    Us0LineDone
                }
                False -> {
                    let v9 = v6 == 0
                    case v9 {
                        True -> {
                            Us0LineGot(v4, 1)
                        }
                        False -> {
                            let v11 = 0 == v6
                            case v11 {
                                True -> {
                                    let v12 = v6 > 0
                                    let v16 =
                                        case v12 {
                                            True -> {
                                                let v13 = spiral_wrap_signed(v6 - 1, 32)
                                                let v14 = kino_text_at(v5, v13, 1)
                                                let v15 = v14 == "\n"
                                                v15
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    case v16 {
                                        True -> {
                                            let v17 = spiral_wrap_signed(v6 + 1, 32)
                                            Us0LineGot(v4, v17)
                                        }
                                        False -> {
                                            Us0LineDone
                                        }
                                    }
                                }
                                False -> {
                                    let v21 = 0
                                    let v22 = "\n"
                                    let v23 = find_char_3(v5, v21, v22)
                                    let v24 = v23 < 0
                                    case v24 {
                                        True -> {
                                            let v25 = spiral_wrap_signed(v6 - 1, 32)
                                            let v26 = spiral_wrap_signed(v25 + 1, 32)
                                            let v27 = kino_text_at(v5, 0, v26)
                                            Us0LineGot(v27, v6)
                                        }
                                        False -> {
                                            let v29 = v23 == 0
                                            case v29 {
                                                True -> {
                                                    let v30 = spiral_wrap_signed(v23 + 1, 32)
                                                    Us0LineGot(v4, v30)
                                                }
                                                False -> {
                                                    let v32 = spiral_wrap_signed(v23 - 1, 32)
                                                    let v33 = spiral_wrap_signed(v32 + 1, 32)
                                                    let v34 = kino_text_at(v5, 0, v33)
                                                    let v35 = spiral_wrap_signed(v23 + 1, 32)
                                                    Us0LineGot(v34, v35)
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
        case v41  {
            Us0LineDone -> {
                let v42 = "0\n"
                v42
            }
            Us0LineGot(v43, v44) -> {
                let v45 = v43 == "-"
                let v47 =
                    case v45 {
                        True -> {
                            True
                        }
                        False -> {
                            let v46 = v43 == ""
                            v46
                        }
                    }
                let v51 =
                    case v47 {
                        True -> {
                            Uh5NoNb
                        }
                        False -> {
                            let v49 = Uh5NoNb
                            Uh5Nb(v43, v49)
                        }
                    }
                let v52 = Us7EveryCell
                let v53 = kino_text_size(v0)
                let v54 = v44 >= v53
                let v61 =
                    case v54 {
                        True -> {
                            v4
                        }
                        False -> {
                            let v55 = v44 <= 0
                            case v55 {
                                True -> {
                                    v0
                                }
                                False -> {
                                    let v56 = spiral_wrap_signed(v53 - 1, 32)
                                    let v57 = spiral_wrap_signed(v56 - v44, 32)
                                    let v58 = spiral_wrap_signed(v57 + 1, 32)
                                    let v59 = kino_text_at(v0, v44, v58)
                                    v59
                                }
                            }
                        }
                    }
                let v62 = kino_text_size(v61)
                let v63 = 0 > v62
                let v97 =
                    case v63 {
                        True -> {
                            Us0LineDone
                        }
                        False -> {
                            let v65 = v62 == 0
                            case v65 {
                                True -> {
                                    Us0LineGot(v4, 1)
                                }
                                False -> {
                                    let v67 = 0 == v62
                                    case v67 {
                                        True -> {
                                            let v68 = v62 > 0
                                            let v72 =
                                                case v68 {
                                                    True -> {
                                                        let v69 = spiral_wrap_signed(v62 - 1, 32)
                                                        let v70 = kino_text_at(v61, v69, 1)
                                                        let v71 = v70 == "\n"
                                                        v71
                                                    }
                                                    False -> {
                                                        False
                                                    }
                                                }
                                            case v72 {
                                                True -> {
                                                    let v73 = spiral_wrap_signed(v62 + 1, 32)
                                                    Us0LineGot(v4, v73)
                                                }
                                                False -> {
                                                    Us0LineDone
                                                }
                                            }
                                        }
                                        False -> {
                                            let v77 = 0
                                            let v78 = "\n"
                                            let v79 = find_char_3(v61, v77, v78)
                                            let v80 = v79 < 0
                                            case v80 {
                                                True -> {
                                                    let v81 = spiral_wrap_signed(v62 - 1, 32)
                                                    let v82 = spiral_wrap_signed(v81 + 1, 32)
                                                    let v83 = kino_text_at(v61, 0, v82)
                                                    Us0LineGot(v83, v62)
                                                }
                                                False -> {
                                                    let v85 = v79 == 0
                                                    case v85 {
                                                        True -> {
                                                            let v86 = spiral_wrap_signed(v79 + 1, 32)
                                                            Us0LineGot(v4, v86)
                                                        }
                                                        False -> {
                                                            let v88 = spiral_wrap_signed(v79 - 1, 32)
                                                            let v89 = spiral_wrap_signed(v88 + 1, 32)
                                                            let v90 = kino_text_at(v61, 0, v89)
                                                            let v91 = spiral_wrap_signed(v79 + 1, 32)
                                                            Us0LineGot(v90, v91)
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
                let v110 =
                    case v97  {
                        Us0LineDone -> {
                            Uh6NoSource
                        }
                        Us0LineGot(v99, v100) -> {
                            let v101 = 0
                            let v102 = 0
                            let v103 = 0
                            let v104 = parse_acc_26(v99, v101, v102, v103)
                            let v105 = Uh6NoSource
                            let v106 = read_sources_83(v61, v100, v104, v105)
                            let v107 = Uh6NoSource
                            rev_sources_84(v106, v107)
                        }
                    }
                let v111 = 0
                let v112 = -1
                let v113 = Uh5NoNb
                let v114 = Uh5NoNb
                let v115 = Uh5NoNb
                let v116 = Uh7NoStep
                let v117 = walk_85(v52, v110, v111, v112, v51, v113, v114, v115, v116)
                let v118 = Uh7NoStep
                let v119 = rev_steps_99(v117, v118)
                let v120 = count_steps_100(v119)
                let v121 = show_i32_20(v120)
                let v122 = { v121 } <> { "\n" }
                let v123 = emit_steps_101(v119)
                let v124 = { v122 } <> { v123 }
                v124
            }
        }
    }
}
pub fn closure13(capt: Nil) -> fn(String) -> String {
    fn (v0) {
        let v1 = "\r\n"
        let v2 = "\n"
        let v3 = 0
        let v4 = ""
        let v5 = replace_from_0(v0, v1, v2, v3, v4)
        let v6 = kino_text_size(v5)
        let v7 = 0 > v6
        let v41 =
            case v7 {
                True -> {
                    Us0LineDone
                }
                False -> {
                    let v9 = v6 == 0
                    case v9 {
                        True -> {
                            Us0LineGot(v4, 1)
                        }
                        False -> {
                            let v11 = 0 == v6
                            case v11 {
                                True -> {
                                    let v12 = v6 > 0
                                    let v16 =
                                        case v12 {
                                            True -> {
                                                let v13 = spiral_wrap_signed(v6 - 1, 32)
                                                let v14 = kino_text_at(v5, v13, 1)
                                                let v15 = v14 == "\n"
                                                v15
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    case v16 {
                                        True -> {
                                            let v17 = spiral_wrap_signed(v6 + 1, 32)
                                            Us0LineGot(v4, v17)
                                        }
                                        False -> {
                                            Us0LineDone
                                        }
                                    }
                                }
                                False -> {
                                    let v21 = 0
                                    let v22 = "\n"
                                    let v23 = find_char_3(v5, v21, v22)
                                    let v24 = v23 < 0
                                    case v24 {
                                        True -> {
                                            let v25 = spiral_wrap_signed(v6 - 1, 32)
                                            let v26 = spiral_wrap_signed(v25 + 1, 32)
                                            let v27 = kino_text_at(v5, 0, v26)
                                            Us0LineGot(v27, v6)
                                        }
                                        False -> {
                                            let v29 = v23 == 0
                                            case v29 {
                                                True -> {
                                                    let v30 = spiral_wrap_signed(v23 + 1, 32)
                                                    Us0LineGot(v4, v30)
                                                }
                                                False -> {
                                                    let v32 = spiral_wrap_signed(v23 - 1, 32)
                                                    let v33 = spiral_wrap_signed(v32 + 1, 32)
                                                    let v34 = kino_text_at(v5, 0, v33)
                                                    let v35 = spiral_wrap_signed(v23 + 1, 32)
                                                    Us0LineGot(v34, v35)
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
        case v41  {
            Us0LineDone -> {
                let v42 = "0\n"
                v42
            }
            Us0LineGot(v43, v44) -> {
                let v45 = v43 == "-"
                let v47 =
                    case v45 {
                        True -> {
                            True
                        }
                        False -> {
                            let v46 = v43 == ""
                            v46
                        }
                    }
                let v51 =
                    case v47 {
                        True -> {
                            Uh5NoNb
                        }
                        False -> {
                            let v49 = Uh5NoNb
                            Uh5Nb(v43, v49)
                        }
                    }
                let v52 = Us7TestsAndWholeFile
                let v53 = kino_text_size(v0)
                let v54 = v44 >= v53
                let v61 =
                    case v54 {
                        True -> {
                            v4
                        }
                        False -> {
                            let v55 = v44 <= 0
                            case v55 {
                                True -> {
                                    v0
                                }
                                False -> {
                                    let v56 = spiral_wrap_signed(v53 - 1, 32)
                                    let v57 = spiral_wrap_signed(v56 - v44, 32)
                                    let v58 = spiral_wrap_signed(v57 + 1, 32)
                                    let v59 = kino_text_at(v0, v44, v58)
                                    v59
                                }
                            }
                        }
                    }
                let v62 = kino_text_size(v61)
                let v63 = 0 > v62
                let v97 =
                    case v63 {
                        True -> {
                            Us0LineDone
                        }
                        False -> {
                            let v65 = v62 == 0
                            case v65 {
                                True -> {
                                    Us0LineGot(v4, 1)
                                }
                                False -> {
                                    let v67 = 0 == v62
                                    case v67 {
                                        True -> {
                                            let v68 = v62 > 0
                                            let v72 =
                                                case v68 {
                                                    True -> {
                                                        let v69 = spiral_wrap_signed(v62 - 1, 32)
                                                        let v70 = kino_text_at(v61, v69, 1)
                                                        let v71 = v70 == "\n"
                                                        v71
                                                    }
                                                    False -> {
                                                        False
                                                    }
                                                }
                                            case v72 {
                                                True -> {
                                                    let v73 = spiral_wrap_signed(v62 + 1, 32)
                                                    Us0LineGot(v4, v73)
                                                }
                                                False -> {
                                                    Us0LineDone
                                                }
                                            }
                                        }
                                        False -> {
                                            let v77 = 0
                                            let v78 = "\n"
                                            let v79 = find_char_3(v61, v77, v78)
                                            let v80 = v79 < 0
                                            case v80 {
                                                True -> {
                                                    let v81 = spiral_wrap_signed(v62 - 1, 32)
                                                    let v82 = spiral_wrap_signed(v81 + 1, 32)
                                                    let v83 = kino_text_at(v61, 0, v82)
                                                    Us0LineGot(v83, v62)
                                                }
                                                False -> {
                                                    let v85 = v79 == 0
                                                    case v85 {
                                                        True -> {
                                                            let v86 = spiral_wrap_signed(v79 + 1, 32)
                                                            Us0LineGot(v4, v86)
                                                        }
                                                        False -> {
                                                            let v88 = spiral_wrap_signed(v79 - 1, 32)
                                                            let v89 = spiral_wrap_signed(v88 + 1, 32)
                                                            let v90 = kino_text_at(v61, 0, v89)
                                                            let v91 = spiral_wrap_signed(v79 + 1, 32)
                                                            Us0LineGot(v90, v91)
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
                let v110 =
                    case v97  {
                        Us0LineDone -> {
                            Uh6NoSource
                        }
                        Us0LineGot(v99, v100) -> {
                            let v101 = 0
                            let v102 = 0
                            let v103 = 0
                            let v104 = parse_acc_26(v99, v101, v102, v103)
                            let v105 = Uh6NoSource
                            let v106 = read_sources_83(v61, v100, v104, v105)
                            let v107 = Uh6NoSource
                            rev_sources_84(v106, v107)
                        }
                    }
                let v111 = 0
                let v112 = -1
                let v113 = Uh5NoNb
                let v114 = Uh5NoNb
                let v115 = Uh5NoNb
                let v116 = Uh7NoStep
                let v117 = walk_85(v52, v110, v111, v112, v51, v113, v114, v115, v116)
                let v118 = Uh7NoStep
                let v119 = rev_steps_99(v117, v118)
                let v120 = count_steps_100(v119)
                let v121 = show_i32_20(v120)
                let v122 = { v121 } <> { "\n" }
                let v123 = emit_steps_101(v119)
                let v124 = { v122 } <> { v123 }
                v124
            }
        }
    }
}
pub fn prepare(v0: String) -> String {
  closure0(Nil)(v0)
}
pub fn patch_rust(v0: String, v1: String) -> String {
  closure1(Nil)(#(v0, v1))
}
pub fn split_output(v0: String) -> String {
  closure2(Nil)(v0)
}
pub fn unit_result(v0: String) -> String {
  closure3(Nil)(v0)
}
pub fn package_project(v0: String) -> String {
  closure4(Nil)(v0)
}
pub fn parse_dib(v0: String) -> String {
  closure5(Nil)(v0)
}
pub fn to_spi(v0: String) -> String {
  closure6(Nil)(v0)
}
pub fn to_spir(v0: String) -> String {
  closure7(Nil)(v0)
}
pub fn to_spi_tested(v0: String) -> String {
  closure8(Nil)(v0)
}
pub fn to_spir_tested(v0: String) -> String {
  closure9(Nil)(v0)
}
pub fn from_spi(v0: String, v1: String) -> String {
  closure10(Nil)(#(v0, v1))
}
pub fn test_index(v0: String) -> String {
  closure11(Nil)(v0)
}
pub fn plan(v0: String) -> String {
  closure12(Nil)(v0)
}
pub fn plan_tests(v0: String) -> String {
  closure13(Nil)(v0)
}
pub fn main() {
let _v0 = closure0(Nil)
let _ = Nil
let _v1 = closure1(Nil)
let _ = Nil
let _v2 = closure2(Nil)
let _ = Nil
let _v3 = closure3(Nil)
let _ = Nil
let _v4 = closure4(Nil)
let _ = Nil
let _v5 = closure5(Nil)
let _ = Nil
let _v6 = closure6(Nil)
let _ = Nil
let _v7 = closure7(Nil)
let _ = Nil
let _v8 = closure8(Nil)
let _ = Nil
let _v9 = closure9(Nil)
let _ = Nil
let _v10 = closure10(Nil)
let _ = Nil
let _v11 = closure11(Nil)
let _ = Nil
let _v12 = closure12(Nil)
let _ = Nil
let _v13 = closure13(Nil)
let _ = Nil
0
}
