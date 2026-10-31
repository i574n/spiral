import gleam/int
import gary
import gary/array
import gleam/list
import gleam/option
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type SpiralArrayKey

pub type SpiralArray(a) {
  SpiralArray(key: SpiralArrayKey, size: Int)
}

@external(erlang, "erlang", "make_ref")
pub fn spiral_array_new_key() -> SpiralArrayKey

@external(erlang, "erlang", "put")
pub fn spiral_array_store(key: SpiralArrayKey, storage: gary.ErlangArray(option.Option(a))) -> b

@external(erlang, "erlang", "get")
pub fn spiral_array_load(key: SpiralArrayKey) -> gary.ErlangArray(option.Option(a))

pub fn spiral_array_from_storage(storage: gary.ErlangArray(option.Option(a)), size: Int) -> SpiralArray(a) {
  let key = spiral_array_new_key()
  let _ = spiral_array_store(key, storage)
  SpiralArray(key: key, size: size)
}


pub fn spiral_array_create_filled(size: Int, value: a) -> SpiralArray(a) {
  list.repeat(option.Some(value), size) |> array.from_list(option.None) |> spiral_array_from_storage(size)
}



pub fn spiral_array_get(xs: SpiralArray(a), i: Int) -> a {
  case i >= 0 && i < xs.size {
    True ->
      case spiral_array_load(xs.key) |> array.get(i) {
        Ok(option.Some(x)) -> x
        _ -> panic as "spiral array: read of an element that was never set"
      }
    False -> panic as "spiral array: index out of bounds"
  }
}

pub fn spiral_array_set(xs: SpiralArray(a), i: Int, value: a) -> Nil {
  case i >= 0 && i < xs.size {
    True -> {
      let assert Ok(storage) = spiral_array_load(xs.key) |> array.set(i, option.Some(value))
      let _ = spiral_array_store(xs.key, storage)
      Nil
    }
    False -> panic as "spiral array: index out of bounds"
  }
}

pub type Us0 {
    Us0BitZero
    Us0BitOne
}
pub type Uh0 {
    Uh0RegexEmpty
    Uh0RegexEpsilon
    Uh0RegexChar(Us0)
    Uh0RegexAlt(Uh0, Uh0)
    Uh0RegexCat(Uh0, Uh0)
    Uh0RegexStar(Uh0)
}
pub type Uh1 {
    Uh1InputEmpty
    Uh1InputCons(Us0, Uh1)
}
pub type Us1 {
    Us1SymbolLess
    Us1SymbolSame
    Us1SymbolGreater
}
pub type Us2 {
    Us2Nullable
    Us2NonNullable
}
pub type Uh2 {
    Uh2RegexListNil
    Uh2RegexListCons(Uh0, Uh2)
}
pub fn random_bit_input_1(v0: Int, v1: Int, v2: Uh1) -> #(Uh1, Int) {
    let v3 = 0 < v1
    case v3 {
        True -> {
            let v4 = spiral_wrap_unsigned(v0 * 1103515245, 64)
            let v5 = spiral_wrap_unsigned(v4 + 12345, 64)
            let v6 = int.bitwise_and(v5, 2147483647)
            let v7 = spiral_wrap_signed(v1 - 1, 32)
            let v8 = int.bitwise_shift_right(v6, 16)
            let v9 = int.bitwise_and(v8, 1)
            let v10 = v9 == 0
            let v13 =
                case v10 {
                    True -> {
                        let v11 = Us0BitZero
                        v11
                    }
                    False -> {
                        let v12 = Us0BitOne
                        v12
                    }
                }
            let v14 = Uh1InputCons(v13, v2)
            random_bit_input_1(v6, v7, v14)
        }
        False -> #(v2, v0)
    }
}
pub fn regex_compare_7(v0: Uh0, v1: Uh0) -> Us1 {
    case v0  {
        Uh0RegexAlt(v53, v54) -> {
            case v1  {
                Uh0RegexAlt(v55, v56) -> {
                    let v57 = regex_compare_7(v53, v55)
                    case v57  {
                        Us1SymbolSame -> regex_compare_7(v54, v56)
                        _ -> v57
                    }
                }
                _ -> Us1SymbolGreater
            }
        }
        Uh0RegexCat(v28, v29) -> {
            case v1  {
                Uh0RegexCat(v34, v35) -> {
                    let v36 = regex_compare_7(v28, v34)
                    case v36  {
                        Us1SymbolSame -> regex_compare_7(v29, v35)
                        _ -> v36
                    }
                }
                Uh0RegexChar(v32) -> Us1SymbolGreater
                Uh0RegexEmpty -> Us1SymbolGreater
                Uh0RegexEpsilon -> Us1SymbolGreater
                _ -> Us1SymbolLess
            }
        }
        Uh0RegexChar(v10) -> {
            case v1  {
                Uh0RegexChar(v13) -> {
                    case v10  {
                        Us0BitOne -> {
                            case v13  {
                                Us0BitOne -> Us1SymbolSame
                                Us0BitZero -> Us1SymbolGreater
                            }
                        }
                        Us0BitZero -> {
                            case v13  {
                                Us0BitOne -> Us1SymbolLess
                                Us0BitZero -> Us1SymbolSame
                            }
                        }
                    }
                }
                Uh0RegexEmpty -> Us1SymbolGreater
                Uh0RegexEpsilon -> Us1SymbolGreater
                _ -> Us1SymbolLess
            }
        }
        Uh0RegexEmpty -> {
            case v1  {
                Uh0RegexEmpty -> Us1SymbolSame
                _ -> Us1SymbolLess
            }
        }
        Uh0RegexEpsilon -> {
            case v1  {
                Uh0RegexEmpty -> Us1SymbolGreater
                Uh0RegexEpsilon -> Us1SymbolSame
                _ -> Us1SymbolLess
            }
        }
        Uh0RegexStar(v44) -> {
            case v1  {
                Uh0RegexAlt(v45, v46) -> Us1SymbolLess
                Uh0RegexStar(v48) -> regex_compare_7(v44, v48)
                _ -> Us1SymbolGreater
            }
        }
    }
}
pub fn alt_insert_sorted_6(v0: Uh0, v1: Uh0) -> Uh0 {
    case v1  {
        Uh0RegexAlt(v2, v3) -> {
            let v4 = regex_compare_7(v0, v2)
            case v4  {
                Us1SymbolGreater -> {
                    let v6 = alt_insert_sorted_6(v0, v3)
                    Uh0RegexAlt(v2, v6)
                }
                Us1SymbolLess -> Uh0RegexAlt(v0, v1)
                Us1SymbolSame -> v1
            }
        }
        Uh0RegexEmpty -> v0
        _ -> {
            let v11 = regex_compare_7(v0, v1)
            case v11  {
                Us1SymbolGreater -> Uh0RegexAlt(v1, v0)
                Us1SymbolLess -> Uh0RegexAlt(v0, v1)
                Us1SymbolSame -> v1
            }
        }
    }
}
pub fn make_alt_5(v0: Uh0, v1: Uh0) -> Uh0 {
    case v0  {
        Uh0RegexAlt(v2, v3) -> {
            let v4 = alt_insert_sorted_6(v2, v1)
            make_alt_5(v3, v4)
        }
        Uh0RegexEmpty -> v1
        _ -> alt_insert_sorted_6(v0, v1)
    }
}
pub fn regex_equal_9(v0: Uh0, v1: Uh0) -> Bool {
    case v0  {
        Uh0RegexAlt(v18, v19) -> {
            case v1  {
                Uh0RegexAlt(v20, v21) -> {
                    let v22 = regex_equal_9(v18, v20)
                    case v22 {
                        True -> regex_equal_9(v19, v21)
                        False -> False
                    }
                }
                _ -> False
            }
        }
        Uh0RegexCat(v26, v27) -> {
            case v1  {
                Uh0RegexCat(v28, v29) -> {
                    let v30 = regex_equal_9(v26, v28)
                    case v30 {
                        True -> regex_equal_9(v27, v29)
                        False -> False
                    }
                }
                _ -> False
            }
        }
        Uh0RegexChar(v4) -> {
            case v1  {
                Uh0RegexChar(v5) -> {
                    let v15 =
                        case v4  {
                            Us0BitOne -> {
                                case v5  {
                                    Us0BitOne -> Us1SymbolSame
                                    Us0BitZero -> Us1SymbolGreater
                                }
                            }
                            Us0BitZero -> {
                                case v5  {
                                    Us0BitOne -> Us1SymbolLess
                                    Us0BitZero -> Us1SymbolSame
                                }
                            }
                        }
                    case v15  {
                        Us1SymbolSame -> True
                        _ -> False
                    }
                }
                _ -> False
            }
        }
        Uh0RegexEmpty -> {
            case v1  {
                Uh0RegexEmpty -> True
                _ -> False
            }
        }
        Uh0RegexEpsilon -> {
            case v1  {
                Uh0RegexEpsilon -> True
                _ -> False
            }
        }
        Uh0RegexStar(v34) -> {
            case v1  {
                Uh0RegexStar(v35) -> regex_equal_9(v34, v35)
                _ -> False
            }
        }
    }
}
pub fn make_cat_8(v0: Uh0, v1: Uh0) -> Uh0 {
    case v0  {
        Uh0RegexEmpty -> Uh0RegexEmpty
        _ -> {
            case v1  {
                Uh0RegexEmpty -> Uh0RegexEmpty
                _ -> {
                    case v0  {
                        Uh0RegexEpsilon -> v1
                        _ -> {
                            case v1  {
                                Uh0RegexEpsilon -> v0
                                _ -> {
                                    case v0  {
                                        Uh0RegexCat(v12, v13) -> {
                                            let v14 = make_cat_8(v13, v1)
                                            Uh0RegexCat(v12, v14)
                                        }
                                        Uh0RegexStar(v4) -> {
                                            case v1  {
                                                Uh0RegexStar(v5) -> {
                                                    let v6 = regex_equal_9(v4, v5)
                                                    case v6 {
                                                        True -> Uh0RegexStar(v4)
                                                        False -> Uh0RegexCat(v0, v1)
                                                    }
                                                }
                                                _ -> Uh0RegexCat(v0, v1)
                                            }
                                        }
                                        _ -> Uh0RegexCat(v0, v1)
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
pub fn make_star_10(v0: Uh0) -> Uh0 {
    case v0  {
        Uh0RegexEmpty -> Uh0RegexEpsilon
        Uh0RegexEpsilon -> Uh0RegexEpsilon
        Uh0RegexStar(v3) -> Uh0RegexStar(v3)
        _ -> Uh0RegexStar(v0)
    }
}
pub fn normalize_4(v0: Uh0) -> Uh0 {
    case v0  {
        Uh0RegexAlt(v5, v6) -> {
            let v7 = normalize_4(v5)
            let v8 = normalize_4(v6)
            make_alt_5(v7, v8)
        }
        Uh0RegexCat(v10, v11) -> {
            let v12 = normalize_4(v10)
            let v13 = normalize_4(v11)
            make_cat_8(v12, v13)
        }
        Uh0RegexChar(v3) -> Uh0RegexChar(v3)
        Uh0RegexEmpty -> Uh0RegexEmpty
        Uh0RegexEpsilon -> Uh0RegexEpsilon
        Uh0RegexStar(v15) -> {
            let v16 = normalize_4(v15)
            make_star_10(v16)
        }
    }
}
pub fn nullable_12(v0: Uh0) -> Us2 {
    case v0  {
        Uh0RegexAlt(v5, v6) -> {
            let v7 = nullable_12(v5)
            let v8 = nullable_12(v6)
            case v7  {
                Us2Nullable -> Us2Nullable
                _ -> {
                    case v8  {
                        Us2Nullable -> Us2Nullable
                        _ -> {
                            case v7  {
                                Us2NonNullable -> {
                                    case v8  {
                                        Us2NonNullable -> Us2NonNullable
                                        _ -> panic as "spiral: union case ruled out by partial evaluation"
                                    }
                                }
                                _ -> panic as "spiral: union case ruled out by partial evaluation"
                            }
                        }
                    }
                }
            }
        }
        Uh0RegexCat(v16, v17) -> {
            let v18 = nullable_12(v16)
            let v19 = nullable_12(v17)
            case v18  {
                Us2Nullable -> {
                    case v19  {
                        Us2Nullable -> Us2Nullable
                        _ -> Us2NonNullable
                    }
                }
                _ -> Us2NonNullable
            }
        }
        Uh0RegexChar(v3) -> Us2NonNullable
        Uh0RegexEmpty -> Us2NonNullable
        Uh0RegexEpsilon -> Us2Nullable
        Uh0RegexStar(v25) -> Us2Nullable
    }
}
pub fn derivative_11(v0: Uh0, v1: Us0) -> Uh0 {
    case v0  {
        Uh0RegexAlt(v19, v20) -> {
            let v21 = derivative_11(v19, v1)
            let v22 = derivative_11(v20, v1)
            make_alt_5(v21, v22)
        }
        Uh0RegexCat(v24, v25) -> {
            let v26 = nullable_12(v24)
            case v26  {
                Us2NonNullable -> {
                    let v31 = derivative_11(v24, v1)
                    make_cat_8(v31, v25)
                }
                Us2Nullable -> {
                    let v27 = derivative_11(v24, v1)
                    let v28 = make_cat_8(v27, v25)
                    let v29 = derivative_11(v25, v1)
                    make_alt_5(v28, v29)
                }
            }
        }
        Uh0RegexChar(v4) -> {
            let v14 =
                case v4  {
                    Us0BitOne -> {
                        case v1  {
                            Us0BitOne -> Us1SymbolSame
                            Us0BitZero -> Us1SymbolGreater
                        }
                    }
                    Us0BitZero -> {
                        case v1  {
                            Us0BitOne -> Us1SymbolLess
                            Us0BitZero -> Us1SymbolSame
                        }
                    }
                }
            let v15 =
                case v14  {
                    Us1SymbolSame -> True
                    _ -> False
                }
            case v15 {
                True -> Uh0RegexEpsilon
                False -> Uh0RegexEmpty
            }
        }
        Uh0RegexEmpty -> Uh0RegexEmpty
        Uh0RegexEpsilon -> Uh0RegexEmpty
        Uh0RegexStar(v35) -> {
            let v36 = derivative_11(v35, v1)
            let v37 = make_star_10(v35)
            make_cat_8(v36, v37)
        }
    }
}
pub fn canonical_derivative_3(v0: Uh0, v1: Us0) -> Uh0 {
    let v2 = normalize_4(v0)
    let v3 = derivative_11(v2, v1)
    normalize_4(v3)
}
pub fn accepts_2(v0: Uh0, v1: Uh1) -> Bool {
    case v1  {
        Uh1InputCons(v6, v7) -> {
            let v8 = canonical_derivative_3(v0, v6)
            accepts_2(v8, v7)
        }
        Uh1InputEmpty -> {
            let v2 = normalize_4(v0)
            let v3 = nullable_12(v2)
            case v3  {
                Us2NonNullable -> False
                Us2Nullable -> True
            }
        }
    }
}
pub fn loop_0(v0: Uh0, v1: Int, v2: Int, v3: Int, v4: Int) -> Int {
    let v5 = 0 < v2
    case v5 {
        True -> {
            let v6 = Uh1InputEmpty
            let #(v7, v8) = random_bit_input_1(v3, v1, v6)
            let v9 = accepts_2(v0, v7)
            let v11 =
                case v9 {
                    True -> {
                        let v10 = spiral_wrap_signed(v4 + 1, 32)
                        v10
                    }
                    False -> v4
                }
            let v12 = spiral_wrap_signed(v2 - 1, 32)
            loop_0(v0, v1, v12, v8, v11)
        }
        False -> v4
    }
}
pub fn zeros_input_14(v0: Int, v1: Uh1) -> Uh1 {
    let v2 = 0 < v0
    case v2 {
        True -> {
            let v3 = spiral_wrap_signed(v0 - 1, 32)
            let v4 = Us0BitZero
            let v5 = Uh1InputCons(v4, v1)
            zeros_input_14(v3, v5)
        }
        False -> v1
    }
}
pub fn loop_13(v0: Uh0, v1: Int, v2: Int, v3: Int) -> Int {
    let v4 = v1 < v2
    case v4 {
        True -> v3
        False -> {
            let v5 = Uh1InputEmpty
            let v6 = zeros_input_14(v2, v5)
            let v7 = accepts_2(v0, v6)
            let v9 =
                case v7 {
                    True -> {
                        let v8 = spiral_wrap_signed(v3 + 1, 32)
                        v8
                    }
                    False -> v3
                }
            let v10 = Us0BitOne
            let v11 = Uh1InputEmpty
            let v12 = Uh1InputCons(v10, v11)
            let v13 = zeros_input_14(v2, v12)
            let v14 = accepts_2(v0, v13)
            let v16 =
                case v14 {
                    True -> {
                        let v15 = spiral_wrap_signed(v9 + 1, 32)
                        v15
                    }
                    False -> v9
                }
            let v17 = spiral_wrap_signed(v2 + 1, 32)
            loop_13(v0, v1, v17, v16)
        }
    }
}
pub fn backtrack_stack_16(v0: Uh2, v1: Uh1) -> Bool {
    case v0  {
        Uh2RegexListCons(v6, v7) -> {
            case v6  {
                Uh0RegexAlt(v27, v28) -> {
                    let v29 = Uh2RegexListCons(v27, v7)
                    let v30 = backtrack_stack_16(v29, v1)
                    case v30 {
                        True -> True
                        False -> {
                            let v31 = Uh2RegexListCons(v28, v7)
                            backtrack_stack_16(v31, v1)
                        }
                    }
                }
                Uh0RegexCat(v34, v35) -> {
                    let v36 = Uh2RegexListCons(v35, v7)
                    let v37 = Uh2RegexListCons(v34, v36)
                    backtrack_stack_16(v37, v1)
                }
                Uh0RegexChar(v9) -> {
                    case v1  {
                        Uh1InputCons(v10, v11) -> {
                            let v21 =
                                case v9  {
                                    Us0BitOne -> {
                                        case v10  {
                                            Us0BitOne -> Us1SymbolSame
                                            Us0BitZero -> Us1SymbolGreater
                                        }
                                    }
                                    Us0BitZero -> {
                                        case v10  {
                                            Us0BitOne -> Us1SymbolLess
                                            Us0BitZero -> Us1SymbolSame
                                        }
                                    }
                                }
                            let v22 =
                                case v21  {
                                    Us1SymbolSame -> True
                                    _ -> False
                                }
                            case v22 {
                                True -> backtrack_stack_16(v7, v11)
                                False -> False
                            }
                        }
                        Uh1InputEmpty -> False
                    }
                }
                Uh0RegexEmpty -> False
                Uh0RegexEpsilon -> backtrack_stack_16(v7, v1)
                Uh0RegexStar(v39) -> {
                    let v40 = Uh2RegexListCons(v39, v0)
                    let v41 = backtrack_stack_16(v40, v1)
                    case v41 {
                        True -> True
                        False -> backtrack_stack_16(v7, v1)
                    }
                }
            }
        }
        Uh2RegexListNil -> {
            case v1  {
                Uh1InputCons(v2, v3) -> False
                Uh1InputEmpty -> True
            }
        }
    }
}
pub fn loop_15(v0: Uh0, v1: Int, v2: Int, v3: Int, v4: Int) -> Int {
    let v5 = 0 < v2
    case v5 {
        True -> {
            let v6 = Uh1InputEmpty
            let #(v7, v8) = random_bit_input_1(v3, v1, v6)
            let v9 = Uh2RegexListNil
            let v10 = Uh2RegexListCons(v0, v9)
            let v11 = backtrack_stack_16(v10, v7)
            let v13 =
                case v11 {
                    True -> {
                        let v12 = spiral_wrap_signed(v4 + 1, 32)
                        v12
                    }
                    False -> v4
                }
            let v14 = spiral_wrap_signed(v2 - 1, 32)
            loop_15(v0, v1, v14, v8, v13)
        }
        False -> v4
    }
}
pub fn loop_17(v0: Uh0, v1: Int, v2: Int, v3: Int) -> Int {
    let v4 = v1 < v2
    case v4 {
        True -> v3
        False -> {
            let v5 = Uh1InputEmpty
            let v6 = zeros_input_14(v2, v5)
            let v7 = Uh2RegexListNil
            let v8 = Uh2RegexListCons(v0, v7)
            let v9 = backtrack_stack_16(v8, v6)
            let v11 =
                case v9 {
                    True -> {
                        let v10 = spiral_wrap_signed(v3 + 1, 32)
                        v10
                    }
                    False -> v3
                }
            let v12 = Us0BitOne
            let v13 = Uh1InputEmpty
            let v14 = Uh1InputCons(v12, v13)
            let v15 = zeros_input_14(v2, v14)
            let v16 = Uh2RegexListNil
            let v17 = Uh2RegexListCons(v0, v16)
            let v18 = backtrack_stack_16(v17, v15)
            let v20 =
                case v18 {
                    True -> {
                        let v19 = spiral_wrap_signed(v11 + 1, 32)
                        v19
                    }
                    False -> v11
                }
            let v21 = spiral_wrap_signed(v2 + 1, 32)
            loop_17(v0, v1, v21, v20)
        }
    }
}
pub fn run_19(v0: Int, v1: Uh1) -> Bool {
    case v1  {
        Uh1InputCons(v3, v4) -> {
            case v3  {
                Us0BitOne -> {
                    let v9 = 0
                    run_19(v9, v4)
                }
                Us0BitZero -> {
                    let v6 = 1
                    run_19(v6, v4)
                }
            }
        }
        Uh1InputEmpty -> {
            let v2 = v0 == 1
            v2
        }
    }
}
pub fn loop_18(v0: Int, v1: Int, v2: Int, v3: Int) -> Int {
    let v4 = 0 < v1
    case v4 {
        True -> {
            let v5 = Uh1InputEmpty
            let #(v6, v7) = random_bit_input_1(v2, v0, v5)
            let v8 = 0
            let v9 = run_19(v8, v6)
            let v11 =
                case v9 {
                    True -> {
                        let v10 = spiral_wrap_signed(v3 + 1, 32)
                        v10
                    }
                    False -> v3
                }
            let v12 = spiral_wrap_signed(v1 - 1, 32)
            loop_18(v0, v12, v7, v11)
        }
        False -> v3
    }
}
pub fn run_21(v0: Int, v1: Uh1) -> Bool {
    case v1  {
        Uh1InputCons(v17, v18) -> {
            case v17  {
                Us0BitOne -> {
                    let v50 = v0 == 0
                    let v79 =
                        case v50 {
                            True -> 1
                            False -> {
                                let v51 = v0 == 1
                                case v51 {
                                    True -> 6
                                    False -> {
                                        let v52 = v0 == 2
                                        case v52 {
                                            True -> 11
                                            False -> {
                                                let v53 = v0 == 3
                                                case v53 {
                                                    True -> 5
                                                    False -> {
                                                        let v54 = v0 == 4
                                                        case v54 {
                                                            True -> 1
                                                            False -> {
                                                                let v55 = v0 == 5
                                                                case v55 {
                                                                    True -> 6
                                                                    False -> {
                                                                        let v56 = v0 == 6
                                                                        case v56 {
                                                                            True -> 13
                                                                            False -> {
                                                                                let v57 = v0 == 7
                                                                                case v57 {
                                                                                    True -> 9
                                                                                    False -> {
                                                                                        let v58 = v0 == 8
                                                                                        case v58 {
                                                                                            True -> 5
                                                                                            False -> {
                                                                                                let v59 = v0 == 9
                                                                                                case v59 {
                                                                                                    True -> 12
                                                                                                    False -> {
                                                                                                        let v60 = v0 == 10
                                                                                                        case v60 {
                                                                                                            True -> 11
                                                                                                            False -> {
                                                                                                                let v61 = v0 == 11
                                                                                                                case v61 {
                                                                                                                    True -> 12
                                                                                                                    False -> {
                                                                                                                        let v62 = v0 == 12
                                                                                                                        case v62 {
                                                                                                                            True -> 13
                                                                                                                            False -> {
                                                                                                                                let v63 = v0 == 13
                                                                                                                                case v63 {
                                                                                                                                    True -> 15
                                                                                                                                    False -> {
                                                                                                                                        let v64 = v0 == 14
                                                                                                                                        case v64 {
                                                                                                                                            True -> 9
                                                                                                                                            False -> 15
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    run_21(v79, v18)
                }
                Us0BitZero -> {
                    let v19 = v0 == 0
                    let v48 =
                        case v19 {
                            True -> 0
                            False -> {
                                let v20 = v0 == 1
                                case v20 {
                                    True -> 2
                                    False -> {
                                        let v21 = v0 == 2
                                        case v21 {
                                            True -> 3
                                            False -> {
                                                let v22 = v0 == 3
                                                case v22 {
                                                    True -> 4
                                                    False -> {
                                                        let v23 = v0 == 4
                                                        case v23 {
                                                            True -> 0
                                                            False -> {
                                                                let v24 = v0 == 5
                                                                case v24 {
                                                                    True -> 2
                                                                    False -> {
                                                                        let v25 = v0 == 6
                                                                        case v25 {
                                                                            True -> 7
                                                                            False -> {
                                                                                let v26 = v0 == 7
                                                                                case v26 {
                                                                                    True -> 8
                                                                                    False -> {
                                                                                        let v27 = v0 == 8
                                                                                        case v27 {
                                                                                            True -> 4
                                                                                            False -> {
                                                                                                let v28 = v0 == 9
                                                                                                case v28 {
                                                                                                    True -> 10
                                                                                                    False -> {
                                                                                                        let v29 = v0 == 10
                                                                                                        case v29 {
                                                                                                            True -> 3
                                                                                                            False -> {
                                                                                                                let v30 = v0 == 11
                                                                                                                case v30 {
                                                                                                                    True -> 10
                                                                                                                    False -> {
                                                                                                                        let v31 = v0 == 12
                                                                                                                        case v31 {
                                                                                                                            True -> 7
                                                                                                                            False -> {
                                                                                                                                let v32 = v0 == 13
                                                                                                                                case v32 {
                                                                                                                                    True -> 14
                                                                                                                                    False -> {
                                                                                                                                        let v33 = v0 == 14
                                                                                                                                        case v33 {
                                                                                                                                            True -> 8
                                                                                                                                            False -> 14
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    run_21(v48, v18)
                }
            }
        }
        Uh1InputEmpty -> {
            let v2 = v0 == 4
            case v2 {
                True -> True
                False -> {
                    let v3 = v0 == 5
                    case v3 {
                        True -> True
                        False -> {
                            let v4 = v0 == 8
                            case v4 {
                                True -> True
                                False -> {
                                    let v5 = v0 == 9
                                    case v5 {
                                        True -> True
                                        False -> {
                                            let v6 = v0 == 10
                                            case v6 {
                                                True -> True
                                                False -> {
                                                    let v7 = v0 == 12
                                                    case v7 {
                                                        True -> True
                                                        False -> {
                                                            let v8 = v0 == 14
                                                            case v8 {
                                                                True -> True
                                                                False -> {
                                                                    let v9 = v0 == 15
                                                                    v9
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
pub fn loop_20(v0: Int, v1: Int, v2: Int, v3: Int) -> Int {
    let v4 = 0 < v1
    case v4 {
        True -> {
            let v5 = Uh1InputEmpty
            let #(v6, v7) = random_bit_input_1(v2, v0, v5)
            let v8 = 0
            let v9 = run_21(v8, v6)
            let v11 =
                case v9 {
                    True -> {
                        let v10 = spiral_wrap_signed(v3 + 1, 32)
                        v10
                    }
                    False -> v3
                }
            let v12 = spiral_wrap_signed(v1 - 1, 32)
            loop_20(v0, v12, v7, v11)
        }
        False -> v3
    }
}
pub fn run_23(v0: Int, v1: Uh1) -> Bool {
    case v1  {
        Uh1InputCons(v3, v4) -> {
            case v3  {
                Us0BitOne -> {
                    let v13 = v0 == 0
                    let v19 =
                        case v13 {
                            True -> 3
                            False -> {
                                let v14 = v0 == 1
                                case v14 {
                                    True -> 3
                                    False -> {
                                        let v15 = v0 == 2
                                        case v15 {
                                            True -> 3
                                            False -> 4
                                        }
                                    }
                                }
                            }
                        }
                    run_23(v19, v4)
                }
                Us0BitZero -> {
                    let v5 = v0 == 0
                    let v11 =
                        case v5 {
                            True -> 1
                            False -> {
                                let v6 = v0 == 1
                                case v6 {
                                    True -> 2
                                    False -> {
                                        let v7 = v0 == 2
                                        case v7 {
                                            True -> 2
                                            False -> 4
                                        }
                                    }
                                }
                            }
                        }
                    run_23(v11, v4)
                }
            }
        }
        Uh1InputEmpty -> {
            let v2 = v0 == 3
            v2
        }
    }
}
pub fn loop_22(v0: Int, v1: Int, v2: Int) -> Int {
    let v3 = v0 < v1
    case v3 {
        True -> v2
        False -> {
            let v4 = Uh1InputEmpty
            let v5 = zeros_input_14(v1, v4)
            let v6 = 0
            let v7 = run_23(v6, v5)
            let v9 =
                case v7 {
                    True -> {
                        let v8 = spiral_wrap_signed(v2 + 1, 32)
                        v8
                    }
                    False -> v2
                }
            let v10 = Us0BitOne
            let v11 = Uh1InputEmpty
            let v12 = Uh1InputCons(v10, v11)
            let v13 = zeros_input_14(v1, v12)
            let v14 = 0
            let v15 = run_23(v14, v13)
            let v17 =
                case v15 {
                    True -> {
                        let v16 = spiral_wrap_signed(v9 + 1, 32)
                        v16
                    }
                    False -> v9
                }
            let v18 = spiral_wrap_signed(v1 + 1, 32)
            loop_22(v0, v18, v17)
        }
    }
}
pub fn loop_24(v0: SpiralArray(Int), v1: Int) -> Nil {
    let v2 = v1 < 8192
    case v2 {
        True -> {
            spiral_array_set(v0, v1, 0)
            let v3 = spiral_wrap_signed(v1 + 1, 32)
            loop_24(v0, v3)
        }
        False -> Nil
    }
}
pub fn loop_25(v0: SpiralArray(Int), v1: Int) -> Nil {
    let v2 = v1 < 1
    case v2 {
        True -> {
            spiral_array_set(v0, v1, 0)
            let v3 = spiral_wrap_signed(v1 + 1, 32)
            loop_25(v0, v3)
        }
        False -> Nil
    }
}
pub fn probe_27(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int, v9: Int, v10: Int) -> Int {
    let v11 = spiral_array_get(v4, v10)
    let v12 = v11 == 0
    case v12 {
        True -> {
            let v13 = spiral_array_get(v6, 0)
            let v14 = v13 < 4096
            case v14 {
                True -> {
                    spiral_array_set(v0, v13, v7)
                    spiral_array_set(v1, v13, v8)
                    spiral_array_set(v2, v13, v9)
                    let v15 = v7 == 1
                    let v32 =
                        case v15 {
                            True -> True
                            False -> {
                                let v16 = v7 == 5
                                case v16 {
                                    True -> True
                                    False -> {
                                        let v17 = v7 == 3
                                        case v17 {
                                            True -> {
                                                let v18 = spiral_array_get(v3, v8)
                                                let v19 = v18 == 1
                                                case v19 {
                                                    True -> True
                                                    False -> {
                                                        let v20 = spiral_array_get(v3, v9)
                                                        let v21 = v20 == 1
                                                        v21
                                                    }
                                                }
                                            }
                                            False -> {
                                                let v23 = v7 == 4
                                                case v23 {
                                                    True -> {
                                                        let v24 = spiral_array_get(v3, v8)
                                                        let v25 = v24 == 1
                                                        case v25 {
                                                            True -> {
                                                                let v26 = spiral_array_get(v3, v9)
                                                                let v27 = v26 == 1
                                                                v27
                                                            }
                                                            False -> False
                                                        }
                                                    }
                                                    False -> False
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v33 =
                        case v32 {
                            True -> 1
                            False -> 0
                        }
                    spiral_array_set(v3, v13, v33)
                    let v34 = spiral_wrap_signed(v13 + 1, 32)
                    spiral_array_set(v4, v10, v34)
                    spiral_array_set(v6, 0, v34)
                    v13
                }
                False -> panic as "brzozowski-interned-store-full"
            }
        }
        False -> {
            let v37 = spiral_wrap_signed(v11 - 1, 32)
            let v38 = spiral_array_get(v0, v37)
            let v39 = v38 == v7
            let v42 =
                case v39 {
                    True -> {
                        let v40 = spiral_array_get(v1, v37)
                        let v41 = v40 == v8
                        v41
                    }
                    False -> False
                }
            let v45 =
                case v42 {
                    True -> {
                        let v43 = spiral_array_get(v2, v37)
                        let v44 = v43 == v9
                        v44
                    }
                    False -> False
                }
            case v45 {
                True -> v37
                False -> {
                    let v46 = spiral_wrap_signed(v10 + 1, 32)
                    let v47 = int.bitwise_and(v46, 8191)
                    probe_27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v47)
                }
            }
        }
    }
}
pub fn interned_node_26(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int, v9: Int) -> Int {
    let v10 = spiral_wrap_signed(v7 * 1024, 32)
    let v11 = spiral_wrap_signed(v10 + v8, 32)
    let v12 = spiral_wrap_signed(v11 * 4099, 32)
    let v13 = spiral_wrap_signed(v12 + v9, 32)
    let v14 = int.bitwise_and(v13, 8191)
    probe_27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14)
}
pub fn interned_alt_insert_30(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int) -> Int {
    let v9 = v8 == 0
    case v9 {
        True -> v7
        False -> {
            let v10 = spiral_array_get(v0, v8)
            let v11 = v10 == 3
            case v11 {
                True -> {
                    let v12 = spiral_array_get(v1, v8)
                    let v13 = v7 < v12
                    case v13 {
                        True -> {
                            let v14 = 3
                            interned_node_26(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8)
                        }
                        False -> {
                            let v16 = v7 == v12
                            case v16 {
                                True -> v8
                                False -> {
                                    let v17 = 3
                                    let v18 = spiral_array_get(v2, v8)
                                    let v19 = interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v18)
                                    interned_node_26(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19)
                                }
                            }
                        }
                    }
                }
                False -> {
                    let v23 = v7 < v8
                    case v23 {
                        True -> {
                            let v24 = 3
                            interned_node_26(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8)
                        }
                        False -> {
                            let v26 = v7 == v8
                            case v26 {
                                True -> v8
                                False -> {
                                    let v27 = 3
                                    interned_node_26(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7)
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
pub fn interned_make_alt_29(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int) -> Int {
    let v9 = v7 == 0
    case v9 {
        True -> v8
        False -> {
            let v10 = spiral_array_get(v0, v7)
            let v11 = v10 == 3
            case v11 {
                True -> {
                    let v12 = spiral_array_get(v2, v7)
                    let v13 = spiral_array_get(v1, v7)
                    let v14 = interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v13, v8)
                    interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v12, v14)
                }
                False -> interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v8)
            }
        }
    }
}
pub fn interned_make_cat_31(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int) -> Int {
    let v9 = v7 == 0
    case v9 {
        True -> 0
        False -> {
            let v10 = v8 == 0
            case v10 {
                True -> 0
                False -> {
                    let v11 = v7 == 1
                    case v11 {
                        True -> v8
                        False -> {
                            let v12 = v8 == 1
                            case v12 {
                                True -> v7
                                False -> {
                                    let v13 = spiral_array_get(v0, v7)
                                    let v14 = v13 == 5
                                    let v17 =
                                        case v14 {
                                            True -> {
                                                let v15 = spiral_array_get(v0, v8)
                                                let v16 = v15 == 5
                                                v16
                                            }
                                            False -> False
                                        }
                                    case v17 {
                                        True -> {
                                            let v18 = spiral_array_get(v1, v7)
                                            let v19 = spiral_array_get(v1, v8)
                                            let v20 = v18 == v19
                                            case v20 {
                                                True -> v7
                                                False -> {
                                                    let v21 = 4
                                                    interned_node_26(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8)
                                                }
                                            }
                                        }
                                        False -> {
                                            let v24 = spiral_array_get(v0, v7)
                                            let v25 = v24 == 4
                                            case v25 {
                                                True -> {
                                                    let v26 = 4
                                                    let v27 = spiral_array_get(v1, v7)
                                                    let v28 = spiral_array_get(v2, v7)
                                                    let v29 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v8)
                                                    interned_node_26(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29)
                                                }
                                                False -> {
                                                    let v31 = 4
                                                    interned_node_26(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8)
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
pub fn interned_of_regex_raw_28(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Uh0) -> Int {
    case v7  {
        Uh0RegexAlt(v14, v15) -> {
            let v16 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v14)
            let v17 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v15)
            interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v16, v17)
        }
        Uh0RegexCat(v19, v20) -> {
            let v21 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v19)
            let v22 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v20)
            interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v21, v22)
        }
        Uh0RegexChar(v8) -> {
            let v9 = 2
            let v11 =
                case v8  {
                    Us0BitOne -> 1
                    Us0BitZero -> 0
                }
            let v12 = 0
            interned_node_26(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12)
        }
        Uh0RegexEmpty -> 0
        Uh0RegexEpsilon -> 1
        Uh0RegexStar(v24) -> {
            let v25 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v24)
            let v26 = spiral_array_get(v0, v25)
            let v27 = v26 < 2
            case v27 {
                True -> 1
                False -> {
                    let v28 = v26 == 5
                    case v28 {
                        True -> v25
                        False -> {
                            let v29 = 5
                            let v30 = 0
                            interned_node_26(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30)
                        }
                    }
                }
            }
        }
    }
}
pub fn interned_derivative_raw_35(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int) -> Int {
    let v9 = spiral_wrap_signed(v7 * 2, 32)
    let v10 = spiral_wrap_signed(v9 + v8, 32)
    let v11 = spiral_array_get(v5, v10)
    let v12 = v11 == 0
    case v12 {
        True -> {
            let v13 = spiral_array_get(v0, v7)
            let v14 = v13 < 2
            let v41 =
                case v14 {
                    True -> 0
                    False -> {
                        let v15 = v13 == 2
                        case v15 {
                            True -> {
                                let v16 = spiral_array_get(v1, v7)
                                let v17 = v16 == v8
                                case v17 {
                                    True -> 1
                                    False -> 0
                                }
                            }
                            False -> {
                                let v19 = v13 == 3
                                case v19 {
                                    True -> {
                                        let v20 = spiral_array_get(v1, v7)
                                        let v21 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v20, v8)
                                        let v22 = spiral_array_get(v2, v7)
                                        let v23 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v22, v8)
                                        interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v21, v23)
                                    }
                                    False -> {
                                        let v25 = v13 == 4
                                        case v25 {
                                            True -> {
                                                let v26 = spiral_array_get(v1, v7)
                                                let v27 = spiral_array_get(v2, v7)
                                                let v28 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v26, v8)
                                                let v29 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v27)
                                                let v30 = spiral_array_get(v3, v26)
                                                let v31 = v30 == 1
                                                case v31 {
                                                    True -> {
                                                        let v32 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v27, v8)
                                                        interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v29, v32)
                                                    }
                                                    False -> v29
                                                }
                                            }
                                            False -> {
                                                let v35 = spiral_array_get(v1, v7)
                                                let v36 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v35, v8)
                                                interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v36, v7)
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            let v42 = spiral_wrap_signed(v41 + 1, 32)
            spiral_array_set(v5, v10, v42)
            v41
        }
        False -> {
            let v43 = spiral_wrap_signed(v11 - 1, 32)
            v43
        }
    }
}
pub fn loop_34(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Uh1) -> Bool {
    let v9 = v7 == 0
    case v9 {
        True -> False
        False -> {
            case v8  {
                Uh1InputCons(v12, v13) -> {
                    let v15 =
                        case v12  {
                            Us0BitOne -> 1
                            Us0BitZero -> 0
                        }
                    let v16 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v7, v15)
                    loop_34(v0, v1, v2, v3, v4, v5, v6, v16, v13)
                }
                Uh1InputEmpty -> {
                    let v10 = spiral_array_get(v3, v7)
                    let v11 = v10 == 1
                    v11
                }
            }
        }
    }
}
pub fn interned_accepts_33(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Uh1) -> Bool {
    loop_34(v0, v1, v2, v3, v4, v5, v6, v7, v8)
}
pub fn loop_32(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int, v9: Int, v10: Int, v11: Int) -> Int {
    let v12 = 0 < v9
    case v12 {
        True -> {
            let v13 = Uh1InputEmpty
            let #(v14, v15) = random_bit_input_1(v10, v7, v13)
            let v16 = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v14)
            let v18 =
                case v16 {
                    True -> {
                        let v17 = spiral_wrap_signed(v11 + 1, 32)
                        v17
                    }
                    False -> v11
                }
            let v19 = spiral_wrap_signed(v9 - 1, 32)
            loop_32(v0, v1, v2, v3, v4, v5, v6, v7, v8, v19, v15, v18)
        }
        False -> v11
    }
}
pub fn loop_36(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int, v9: Int, v10: Int) -> Int {
    let v11 = v7 < v9
    case v11 {
        True -> v10
        False -> {
            let v12 = Uh1InputEmpty
            let v13 = zeros_input_14(v9, v12)
            let v14 = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v13)
            let v16 =
                case v14 {
                    True -> {
                        let v15 = spiral_wrap_signed(v10 + 1, 32)
                        v15
                    }
                    False -> v10
                }
            let v17 = Us0BitOne
            let v18 = Uh1InputEmpty
            let v19 = Uh1InputCons(v17, v18)
            let v20 = zeros_input_14(v9, v19)
            let v21 = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v20)
            let v23 =
                case v21 {
                    True -> {
                        let v22 = spiral_wrap_signed(v16 + 1, 32)
                        v22
                    }
                    False -> v16
                }
            let v24 = spiral_wrap_signed(v9 + 1, 32)
            loop_36(v0, v1, v2, v3, v4, v5, v6, v7, v8, v24, v23)
        }
    }
}
pub fn main() {
    let v0 = 200
    let v1 = 32
    let v2 = Us0BitZero
    let v3 = Uh0RegexChar(v2)
    let v4 = Us0BitOne
    let v5 = Uh0RegexChar(v4)
    let v6 = Uh0RegexAlt(v3, v5)
    let v7 = Uh0RegexStar(v6)
    let v8 = Us0BitZero
    let v9 = Uh0RegexChar(v8)
    let v10 = Uh0RegexCat(v7, v9)
    let v11 = Us0BitZero
    let v12 = Uh0RegexChar(v11)
    let v13 = Us0BitOne
    let v14 = Uh0RegexChar(v13)
    let v15 = Uh0RegexAlt(v12, v14)
    let v16 = Uh0RegexStar(v15)
    let v17 = Us0BitOne
    let v18 = Uh0RegexChar(v17)
    let v19 = Us0BitZero
    let v20 = Uh0RegexChar(v19)
    let v21 = Us0BitOne
    let v22 = Uh0RegexChar(v21)
    let v23 = Uh0RegexAlt(v20, v22)
    let v24 = Us0BitZero
    let v25 = Uh0RegexChar(v24)
    let v26 = Us0BitOne
    let v27 = Uh0RegexChar(v26)
    let v28 = Uh0RegexAlt(v25, v27)
    let v29 = Us0BitZero
    let v30 = Uh0RegexChar(v29)
    let v31 = Us0BitOne
    let v32 = Uh0RegexChar(v31)
    let v33 = Uh0RegexAlt(v30, v32)
    let v34 = Uh0RegexCat(v28, v33)
    let v35 = Uh0RegexCat(v23, v34)
    let v36 = Uh0RegexCat(v18, v35)
    let v37 = Uh0RegexCat(v16, v36)
    let v38 = 1
    let v39 = 0
    let v40 = loop_0(v10, v1, v0, v38, v39)
    let v41 = loop_0(v37, v1, v0, v38, v39)
    let v42 = 16
    let v43 = Us0BitZero
    let v44 = Uh0RegexChar(v43)
    let v45 = Us0BitZero
    let v46 = Uh0RegexChar(v45)
    let v47 = Us0BitZero
    let v48 = Uh0RegexChar(v47)
    let v49 = Uh0RegexCat(v46, v48)
    let v50 = Uh0RegexAlt(v44, v49)
    let v51 = Uh0RegexStar(v50)
    let v52 = Us0BitOne
    let v53 = Uh0RegexChar(v52)
    let v54 = Uh0RegexCat(v51, v53)
    let v55 = 0
    let v56 = 1
    let v57 = loop_13(v54, v42, v56, v55)
    let v58 = 200
    let v59 = 32
    let v60 = Us0BitZero
    let v61 = Uh0RegexChar(v60)
    let v62 = Us0BitOne
    let v63 = Uh0RegexChar(v62)
    let v64 = Uh0RegexAlt(v61, v63)
    let v65 = Uh0RegexStar(v64)
    let v66 = Us0BitZero
    let v67 = Uh0RegexChar(v66)
    let v68 = Uh0RegexCat(v65, v67)
    let v69 = Us0BitZero
    let v70 = Uh0RegexChar(v69)
    let v71 = Us0BitOne
    let v72 = Uh0RegexChar(v71)
    let v73 = Uh0RegexAlt(v70, v72)
    let v74 = Uh0RegexStar(v73)
    let v75 = Us0BitOne
    let v76 = Uh0RegexChar(v75)
    let v77 = Us0BitZero
    let v78 = Uh0RegexChar(v77)
    let v79 = Us0BitOne
    let v80 = Uh0RegexChar(v79)
    let v81 = Uh0RegexAlt(v78, v80)
    let v82 = Us0BitZero
    let v83 = Uh0RegexChar(v82)
    let v84 = Us0BitOne
    let v85 = Uh0RegexChar(v84)
    let v86 = Uh0RegexAlt(v83, v85)
    let v87 = Us0BitZero
    let v88 = Uh0RegexChar(v87)
    let v89 = Us0BitOne
    let v90 = Uh0RegexChar(v89)
    let v91 = Uh0RegexAlt(v88, v90)
    let v92 = Uh0RegexCat(v86, v91)
    let v93 = Uh0RegexCat(v81, v92)
    let v94 = Uh0RegexCat(v76, v93)
    let v95 = Uh0RegexCat(v74, v94)
    let v96 = 1
    let v97 = 0
    let v98 = loop_15(v68, v59, v58, v96, v97)
    let v99 = loop_15(v95, v59, v58, v96, v97)
    let v100 = 16
    let v101 = Us0BitZero
    let v102 = Uh0RegexChar(v101)
    let v103 = Us0BitZero
    let v104 = Uh0RegexChar(v103)
    let v105 = Us0BitZero
    let v106 = Uh0RegexChar(v105)
    let v107 = Uh0RegexCat(v104, v106)
    let v108 = Uh0RegexAlt(v102, v107)
    let v109 = Uh0RegexStar(v108)
    let v110 = Us0BitOne
    let v111 = Uh0RegexChar(v110)
    let v112 = Uh0RegexCat(v109, v111)
    let v113 = 0
    let v114 = 1
    let v115 = loop_17(v112, v100, v114, v113)
    let v116 = v40 == v98
    let v118 =
        case v116 {
            True -> {
                let v117 = v41 == v99
                v117
            }
            False -> False
        }
    let v120 =
        case v118 {
            True -> {
                let v119 = v57 == v115
                v119
            }
            False -> False
        }
    case v120 {
        True -> Nil
        False -> panic as "brzozowski-bench-engines-disagree"
    }
    let v121 = 200
    let v122 = 32
    let v123 = 1
    let v124 = 0
    let v125 = loop_18(v122, v121, v123, v124)
    let v126 = loop_20(v122, v121, v123, v124)
    let v127 = 16
    let v128 = 0
    let v129 = 1
    let v130 = loop_22(v127, v129, v128)
    let v131 = v40 == v125
    let v133 =
        case v131 {
            True -> {
                let v132 = v41 == v126
                v132
            }
            False -> False
        }
    let v135 =
        case v133 {
            True -> {
                let v134 = v57 == v130
                v134
            }
            False -> False
        }
    case v135 {
        True -> Nil
        False -> panic as "brzozowski-bench-engines-disagree"
    }
    let v136 = 200
    let v137 = 32
    let v138 = spiral_array_create_filled(4096, 0)
    let v139 = spiral_array_create_filled(4096, 0)
    let v140 = spiral_array_create_filled(4096, 0)
    let v141 = spiral_array_create_filled(4096, 0)
    let v142 = spiral_array_create_filled(8192, 0)
    let v143 = spiral_array_create_filled(8192, 0)
    let v144 = spiral_array_create_filled(1, 0)
    let v145 = 0
    loop_24(v142, v145)
    let v146 = 0
    loop_24(v143, v146)
    let v147 = 0
    loop_25(v144, v147)
    let v148 = 0
    let v149 = 0
    let v150 = 0
    let v151 = interned_node_26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150)
    let v152 = 1
    let v153 = 0
    let v154 = 0
    let v155 = interned_node_26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154)
    let v156 = v151 == 0
    let v158 =
        case v156 {
            True -> {
                let v157 = v155 == 1
                v157
            }
            False -> False
        }
    let #(v166, v167, v168, v169, v170, v171, v172) =
        case v158 {
            True -> #(v138, v139, v140, v141, v142, v143, v144)
            False -> panic as "brzozowski-interned-store-init"
        }
    let v173 = Us0BitZero
    let v174 = Uh0RegexChar(v173)
    let v175 = Us0BitOne
    let v176 = Uh0RegexChar(v175)
    let v177 = Uh0RegexAlt(v174, v176)
    let v178 = Uh0RegexStar(v177)
    let v179 = Us0BitZero
    let v180 = Uh0RegexChar(v179)
    let v181 = Uh0RegexCat(v178, v180)
    let v182 = interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v181)
    let v183 = 1
    let v184 = 0
    let v185 = loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184)
    let v186 = Us0BitZero
    let v187 = Uh0RegexChar(v186)
    let v188 = Us0BitOne
    let v189 = Uh0RegexChar(v188)
    let v190 = Uh0RegexAlt(v187, v189)
    let v191 = Uh0RegexStar(v190)
    let v192 = Us0BitOne
    let v193 = Uh0RegexChar(v192)
    let v194 = Us0BitZero
    let v195 = Uh0RegexChar(v194)
    let v196 = Us0BitOne
    let v197 = Uh0RegexChar(v196)
    let v198 = Uh0RegexAlt(v195, v197)
    let v199 = Us0BitZero
    let v200 = Uh0RegexChar(v199)
    let v201 = Us0BitOne
    let v202 = Uh0RegexChar(v201)
    let v203 = Uh0RegexAlt(v200, v202)
    let v204 = Us0BitZero
    let v205 = Uh0RegexChar(v204)
    let v206 = Us0BitOne
    let v207 = Uh0RegexChar(v206)
    let v208 = Uh0RegexAlt(v205, v207)
    let v209 = Uh0RegexCat(v203, v208)
    let v210 = Uh0RegexCat(v198, v209)
    let v211 = Uh0RegexCat(v193, v210)
    let v212 = Uh0RegexCat(v191, v211)
    let v213 = interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v212)
    let v214 = 1
    let v215 = 0
    let v216 = loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215)
    let v217 = 16
    let v218 = spiral_array_create_filled(4096, 0)
    let v219 = spiral_array_create_filled(4096, 0)
    let v220 = spiral_array_create_filled(4096, 0)
    let v221 = spiral_array_create_filled(4096, 0)
    let v222 = spiral_array_create_filled(8192, 0)
    let v223 = spiral_array_create_filled(8192, 0)
    let v224 = spiral_array_create_filled(1, 0)
    let v225 = 0
    loop_24(v222, v225)
    let v226 = 0
    loop_24(v223, v226)
    let v227 = 0
    loop_25(v224, v227)
    let v228 = 0
    let v229 = 0
    let v230 = 0
    let v231 = interned_node_26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230)
    let v232 = 1
    let v233 = 0
    let v234 = 0
    let v235 = interned_node_26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234)
    let v236 = v231 == 0
    let v238 =
        case v236 {
            True -> {
                let v237 = v235 == 1
                v237
            }
            False -> False
        }
    let #(v246, v247, v248, v249, v250, v251, v252) =
        case v238 {
            True -> #(v218, v219, v220, v221, v222, v223, v224)
            False -> panic as "brzozowski-interned-store-init"
        }
    let v253 = Us0BitZero
    let v254 = Uh0RegexChar(v253)
    let v255 = Us0BitZero
    let v256 = Uh0RegexChar(v255)
    let v257 = Us0BitZero
    let v258 = Uh0RegexChar(v257)
    let v259 = Uh0RegexCat(v256, v258)
    let v260 = Uh0RegexAlt(v254, v259)
    let v261 = Uh0RegexStar(v260)
    let v262 = Us0BitOne
    let v263 = Uh0RegexChar(v262)
    let v264 = Uh0RegexCat(v261, v263)
    let v265 = interned_of_regex_raw_28(v246, v247, v248, v249, v250, v251, v252, v264)
    let v266 = 1
    let v267 = 0
    let v268 = loop_36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267)
    let v269 = v40 == v185
    let v271 =
        case v269 {
            True -> {
                let v270 = v41 == v216
                v270
            }
            False -> False
        }
    let v273 =
        case v271 {
            True -> {
                let v272 = v57 == v268
                v272
            }
            False -> False
        }
    case v273 {
        True -> Nil
        False -> panic as "brzozowski-bench-engines-disagree"
    }
    let v274 = v57 == 16
    case v274 {
        True -> Nil
        False -> panic as "brzozowski-bench-zero-runs-count"
    }
    let v275 = v40 == 93
    case v275 {
        True -> Nil
        False -> panic as "brzozowski-bench-ends-with-zero-count"
    }
    let v276 = v41 == 97
    case v276 {
        True -> Nil
        False -> panic as "brzozowski-bench-fourth-from-end-count"
    }
    0
}
