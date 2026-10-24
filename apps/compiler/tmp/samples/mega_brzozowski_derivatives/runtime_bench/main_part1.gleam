import gary
import gary/array
import gleam/int
import gleam/list
import gleam/option
import main_types.{type SpiralArrayKey, type SpiralArray, type Us0, type Uh0, type Uh1, type Us1, type Us2, type Uh2, SpiralArray, Uh0RegexAlt, Uh0RegexCat, Uh0RegexChar, Uh0RegexEmpty, Uh0RegexEpsilon, Uh0RegexStar, Uh1InputCons, Uh1InputEmpty, Uh2RegexListCons, Uh2RegexListNil, Us0BitOne, Us0BitZero, Us1SymbolGreater, Us1SymbolLess, Us1SymbolSame, Us2NonNullable, Us2Nullable}

pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
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
        False -> {
            #(v2, v0)
        }
    }
}

pub fn regex_compare_7(v0: Uh0, v1: Uh0) -> Us1 {
    case v0  {
        Uh0RegexAlt(v53, v54) -> {
            case v1  {
                Uh0RegexAlt(v55, v56) -> {
                    let v57 = regex_compare_7(v53, v55)
                    case v57  {
                        Us1SymbolSame -> {
                            regex_compare_7(v54, v56)
                        }
                        _ -> {
                            v57
                        }
                    }
                }
                _ -> {
                    Us1SymbolGreater
                }
            }
        }
        Uh0RegexCat(v28, v29) -> {
            case v1  {
                Uh0RegexCat(v34, v35) -> {
                    let v36 = regex_compare_7(v28, v34)
                    case v36  {
                        Us1SymbolSame -> {
                            regex_compare_7(v29, v35)
                        }
                        _ -> {
                            v36
                        }
                    }
                }
                Uh0RegexChar(v32) -> {
                    Us1SymbolGreater
                }
                Uh0RegexEmpty -> {
                    Us1SymbolGreater
                }
                Uh0RegexEpsilon -> {
                    Us1SymbolGreater
                }
                _ -> {
                    Us1SymbolLess
                }
            }
        }
        Uh0RegexChar(v10) -> {
            case v1  {
                Uh0RegexChar(v13) -> {
                    case v10  {
                        Us0BitOne -> {
                            case v13  {
                                Us0BitOne -> {
                                    Us1SymbolSame
                                }
                                Us0BitZero -> {
                                    Us1SymbolGreater
                                }
                            }
                        }
                        Us0BitZero -> {
                            case v13  {
                                Us0BitOne -> {
                                    Us1SymbolLess
                                }
                                Us0BitZero -> {
                                    Us1SymbolSame
                                }
                            }
                        }
                    }
                }
                Uh0RegexEmpty -> {
                    Us1SymbolGreater
                }
                Uh0RegexEpsilon -> {
                    Us1SymbolGreater
                }
                _ -> {
                    Us1SymbolLess
                }
            }
        }
        Uh0RegexEmpty -> {
            case v1  {
                Uh0RegexEmpty -> {
                    Us1SymbolSame
                }
                _ -> {
                    Us1SymbolLess
                }
            }
        }
        Uh0RegexEpsilon -> {
            case v1  {
                Uh0RegexEmpty -> {
                    Us1SymbolGreater
                }
                Uh0RegexEpsilon -> {
                    Us1SymbolSame
                }
                _ -> {
                    Us1SymbolLess
                }
            }
        }
        Uh0RegexStar(v44) -> {
            case v1  {
                Uh0RegexAlt(v45, v46) -> {
                    Us1SymbolLess
                }
                Uh0RegexStar(v48) -> {
                    regex_compare_7(v44, v48)
                }
                _ -> {
                    Us1SymbolGreater
                }
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
                Us1SymbolLess -> {
                    Uh0RegexAlt(v0, v1)
                }
                Us1SymbolSame -> {
                    v1
                }
            }
        }
        Uh0RegexEmpty -> {
            v0
        }
        _ -> {
            let v11 = regex_compare_7(v0, v1)
            case v11  {
                Us1SymbolGreater -> {
                    Uh0RegexAlt(v1, v0)
                }
                Us1SymbolLess -> {
                    Uh0RegexAlt(v0, v1)
                }
                Us1SymbolSame -> {
                    v1
                }
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
        Uh0RegexEmpty -> {
            v1
        }
        _ -> {
            alt_insert_sorted_6(v0, v1)
        }
    }
}

pub fn regex_equal_9(v0: Uh0, v1: Uh0) -> Bool {
    case v0  {
        Uh0RegexAlt(v18, v19) -> {
            case v1  {
                Uh0RegexAlt(v20, v21) -> {
                    let v22 = regex_equal_9(v18, v20)
                    case v22 {
                        True -> {
                            regex_equal_9(v19, v21)
                        }
                        False -> {
                            False
                        }
                    }
                }
                _ -> {
                    False
                }
            }
        }
        Uh0RegexCat(v26, v27) -> {
            case v1  {
                Uh0RegexCat(v28, v29) -> {
                    let v30 = regex_equal_9(v26, v28)
                    case v30 {
                        True -> {
                            regex_equal_9(v27, v29)
                        }
                        False -> {
                            False
                        }
                    }
                }
                _ -> {
                    False
                }
            }
        }
        Uh0RegexChar(v4) -> {
            case v1  {
                Uh0RegexChar(v5) -> {
                    let v15 =
                        case v4  {
                            Us0BitOne -> {
                                case v5  {
                                    Us0BitOne -> {
                                        Us1SymbolSame
                                    }
                                    Us0BitZero -> {
                                        Us1SymbolGreater
                                    }
                                }
                            }
                            Us0BitZero -> {
                                case v5  {
                                    Us0BitOne -> {
                                        Us1SymbolLess
                                    }
                                    Us0BitZero -> {
                                        Us1SymbolSame
                                    }
                                }
                            }
                        }
                    case v15  {
                        Us1SymbolSame -> {
                            True
                        }
                        _ -> {
                            False
                        }
                    }
                }
                _ -> {
                    False
                }
            }
        }
        Uh0RegexEmpty -> {
            case v1  {
                Uh0RegexEmpty -> {
                    True
                }
                _ -> {
                    False
                }
            }
        }
        Uh0RegexEpsilon -> {
            case v1  {
                Uh0RegexEpsilon -> {
                    True
                }
                _ -> {
                    False
                }
            }
        }
        Uh0RegexStar(v34) -> {
            case v1  {
                Uh0RegexStar(v35) -> {
                    regex_equal_9(v34, v35)
                }
                _ -> {
                    False
                }
            }
        }
    }
}

pub fn make_cat_8(v0: Uh0, v1: Uh0) -> Uh0 {
    case v0  {
        Uh0RegexEmpty -> {
            Uh0RegexEmpty
        }
        _ -> {
            case v1  {
                Uh0RegexEmpty -> {
                    Uh0RegexEmpty
                }
                _ -> {
                    case v0  {
                        Uh0RegexEpsilon -> {
                            v1
                        }
                        _ -> {
                            case v1  {
                                Uh0RegexEpsilon -> {
                                    v0
                                }
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
                                                        True -> {
                                                            Uh0RegexStar(v4)
                                                        }
                                                        False -> {
                                                            Uh0RegexCat(v0, v1)
                                                        }
                                                    }
                                                }
                                                _ -> {
                                                    Uh0RegexCat(v0, v1)
                                                }
                                            }
                                        }
                                        _ -> {
                                            Uh0RegexCat(v0, v1)
                                        }
                                    }
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
        Uh0RegexEmpty -> {
            Uh0RegexEpsilon
        }
        Uh0RegexEpsilon -> {
            Uh0RegexEpsilon
        }
        Uh0RegexStar(v3) -> {
            Uh0RegexStar(v3)
        }
        _ -> {
            Uh0RegexStar(v0)
        }
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
        Uh0RegexChar(v3) -> {
            Uh0RegexChar(v3)
        }
        Uh0RegexEmpty -> {
            Uh0RegexEmpty
        }
        Uh0RegexEpsilon -> {
            Uh0RegexEpsilon
        }
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
                Us2Nullable -> {
                    Us2Nullable
                }
                _ -> {
                    case v8  {
                        Us2Nullable -> {
                            Us2Nullable
                        }
                        _ -> {
                            case v7  {
                                Us2NonNullable -> {
                                    case v8  {
                                        Us2NonNullable -> {
                                            Us2NonNullable
                                        }
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
                        Us2Nullable -> {
                            Us2Nullable
                        }
                        _ -> {
                            Us2NonNullable
                        }
                    }
                }
                _ -> {
                    Us2NonNullable
                }
            }
        }
        Uh0RegexChar(v3) -> {
            Us2NonNullable
        }
        Uh0RegexEmpty -> {
            Us2NonNullable
        }
        Uh0RegexEpsilon -> {
            Us2Nullable
        }
        Uh0RegexStar(v25) -> {
            Us2Nullable
        }
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
                            Us0BitOne -> {
                                Us1SymbolSame
                            }
                            Us0BitZero -> {
                                Us1SymbolGreater
                            }
                        }
                    }
                    Us0BitZero -> {
                        case v1  {
                            Us0BitOne -> {
                                Us1SymbolLess
                            }
                            Us0BitZero -> {
                                Us1SymbolSame
                            }
                        }
                    }
                }
            let v15 =
                case v14  {
                    Us1SymbolSame -> {
                        True
                    }
                    _ -> {
                        False
                    }
                }
            case v15 {
                True -> {
                    Uh0RegexEpsilon
                }
                False -> {
                    Uh0RegexEmpty
                }
            }
        }
        Uh0RegexEmpty -> {
            Uh0RegexEmpty
        }
        Uh0RegexEpsilon -> {
            Uh0RegexEmpty
        }
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
                Us2NonNullable -> {
                    False
                }
                Us2Nullable -> {
                    True
                }
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
                    False -> {
                        v4
                    }
                }
            let v12 = spiral_wrap_signed(v2 - 1, 32)
            loop_0(v0, v1, v12, v8, v11)
        }
        False -> {
            v4
        }
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
        False -> {
            v1
        }
    }
}

pub fn loop_13(v0: Uh0, v1: Int, v2: Int, v3: Int) -> Int {
    let v4 = v1 < v2
    case v4 {
        True -> {
            v3
        }
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
                    False -> {
                        v3
                    }
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
                    False -> {
                        v9
                    }
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
                        True -> {
                            True
                        }
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
                                            Us0BitOne -> {
                                                Us1SymbolSame
                                            }
                                            Us0BitZero -> {
                                                Us1SymbolGreater
                                            }
                                        }
                                    }
                                    Us0BitZero -> {
                                        case v10  {
                                            Us0BitOne -> {
                                                Us1SymbolLess
                                            }
                                            Us0BitZero -> {
                                                Us1SymbolSame
                                            }
                                        }
                                    }
                                }
                            let v22 =
                                case v21  {
                                    Us1SymbolSame -> {
                                        True
                                    }
                                    _ -> {
                                        False
                                    }
                                }
                            case v22 {
                                True -> {
                                    backtrack_stack_16(v7, v11)
                                }
                                False -> {
                                    False
                                }
                            }
                        }
                        Uh1InputEmpty -> {
                            False
                        }
                    }
                }
                Uh0RegexEmpty -> {
                    False
                }
                Uh0RegexEpsilon -> {
                    backtrack_stack_16(v7, v1)
                }
                Uh0RegexStar(v39) -> {
                    let v40 = Uh2RegexListCons(v39, v0)
                    let v41 = backtrack_stack_16(v40, v1)
                    case v41 {
                        True -> {
                            True
                        }
                        False -> {
                            backtrack_stack_16(v7, v1)
                        }
                    }
                }
            }
        }
        Uh2RegexListNil -> {
            case v1  {
                Uh1InputCons(v2, v3) -> {
                    False
                }
                Uh1InputEmpty -> {
                    True
                }
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
                    False -> {
                        v4
                    }
                }
            let v14 = spiral_wrap_signed(v2 - 1, 32)
            loop_15(v0, v1, v14, v8, v13)
        }
        False -> {
            v4
        }
    }
}

pub fn loop_17(v0: Uh0, v1: Int, v2: Int, v3: Int) -> Int {
    let v4 = v1 < v2
    case v4 {
        True -> {
            v3
        }
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
                    False -> {
                        v3
                    }
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
                    False -> {
                        v11
                    }
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
