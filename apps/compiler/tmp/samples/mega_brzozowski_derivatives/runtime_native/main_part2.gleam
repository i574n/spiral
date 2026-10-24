import main_types.{type Us1, type Uh1, type Us3, type Uh3, type Us4, type Us5, Uh1InputCons, Uh1InputEmpty, Uh3RegexAlt, Uh3RegexCat, Uh3RegexChar, Uh3RegexEmpty, Uh3RegexEpsilon, Uh3RegexStar, Us1TriA, Us1TriB, Us1TriC, Us2SymbolGreater, Us2SymbolLess, Us2SymbolSame, Us3NonNullable, Us3Nullable, Us4BitMatcherRaw, Us5BitMatcherDecided}
import main_part1.{accepts_0, make_alt_14, make_cat_17}

pub fn make_star_19(v0: Uh3) -> Uh3 {
    case v0  {
        Uh3RegexEmpty -> {
            Uh3RegexEpsilon
        }
        Uh3RegexEpsilon -> {
            Uh3RegexEpsilon
        }
        Uh3RegexStar(v3) -> {
            Uh3RegexStar(v3)
        }
        _ -> {
            Uh3RegexStar(v0)
        }
    }
}

pub fn normalize_13(v0: Uh3) -> Uh3 {
    case v0  {
        Uh3RegexAlt(v5, v6) -> {
            let v7 = normalize_13(v5)
            let v8 = normalize_13(v6)
            make_alt_14(v7, v8)
        }
        Uh3RegexCat(v10, v11) -> {
            let v12 = normalize_13(v10)
            let v13 = normalize_13(v11)
            make_cat_17(v12, v13)
        }
        Uh3RegexChar(v3) -> {
            Uh3RegexChar(v3)
        }
        Uh3RegexEmpty -> {
            Uh3RegexEmpty
        }
        Uh3RegexEpsilon -> {
            Uh3RegexEpsilon
        }
        Uh3RegexStar(v15) -> {
            let v16 = normalize_13(v15)
            make_star_19(v16)
        }
    }
}

pub fn nullable_21(v0: Uh3) -> Us3 {
    case v0  {
        Uh3RegexAlt(v5, v6) -> {
            let v7 = nullable_21(v5)
            let v8 = nullable_21(v6)
            case v7  {
                Us3Nullable -> {
                    Us3Nullable
                }
                _ -> {
                    case v8  {
                        Us3Nullable -> {
                            Us3Nullable
                        }
                        _ -> {
                            case v7  {
                                Us3NonNullable -> {
                                    case v8  {
                                        Us3NonNullable -> {
                                            Us3NonNullable
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
        Uh3RegexCat(v16, v17) -> {
            let v18 = nullable_21(v16)
            let v19 = nullable_21(v17)
            case v18  {
                Us3Nullable -> {
                    case v19  {
                        Us3Nullable -> {
                            Us3Nullable
                        }
                        _ -> {
                            Us3NonNullable
                        }
                    }
                }
                _ -> {
                    Us3NonNullable
                }
            }
        }
        Uh3RegexChar(v3) -> {
            Us3NonNullable
        }
        Uh3RegexEmpty -> {
            Us3NonNullable
        }
        Uh3RegexEpsilon -> {
            Us3Nullable
        }
        Uh3RegexStar(v25) -> {
            Us3Nullable
        }
    }
}

pub fn derivative_20(v0: Uh3, v1: Us1) -> Uh3 {
    case v0  {
        Uh3RegexAlt(v25, v26) -> {
            let v27 = derivative_20(v25, v1)
            let v28 = derivative_20(v26, v1)
            make_alt_14(v27, v28)
        }
        Uh3RegexCat(v30, v31) -> {
            let v32 = nullable_21(v30)
            case v32  {
                Us3NonNullable -> {
                    let v37 = derivative_20(v30, v1)
                    make_cat_17(v37, v31)
                }
                Us3Nullable -> {
                    let v33 = derivative_20(v30, v1)
                    let v34 = make_cat_17(v33, v31)
                    let v35 = derivative_20(v31, v1)
                    make_alt_14(v34, v35)
                }
            }
        }
        Uh3RegexChar(v4) -> {
            let v20 =
                case v4  {
                    Us1TriA -> {
                        case v1  {
                            Us1TriA -> {
                                Us2SymbolSame
                            }
                            _ -> {
                                Us2SymbolLess
                            }
                        }
                    }
                    _ -> {
                        case v1  {
                            Us1TriA -> {
                                Us2SymbolGreater
                            }
                            _ -> {
                                case v4  {
                                    Us1TriB -> {
                                        case v1  {
                                            Us1TriB -> {
                                                Us2SymbolSame
                                            }
                                            Us1TriC -> {
                                                Us2SymbolLess
                                            }
                                            _ -> panic as "spiral: union case ruled out by partial evaluation"
                                        }
                                    }
                                    Us1TriC -> {
                                        case v1  {
                                            Us1TriB -> {
                                                Us2SymbolGreater
                                            }
                                            Us1TriC -> {
                                                Us2SymbolSame
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
            let v21 =
                case v20  {
                    Us2SymbolSame -> {
                        True
                    }
                    _ -> {
                        False
                    }
                }
            case v21 {
                True -> {
                    Uh3RegexEpsilon
                }
                False -> {
                    Uh3RegexEmpty
                }
            }
        }
        Uh3RegexEmpty -> {
            Uh3RegexEmpty
        }
        Uh3RegexEpsilon -> {
            Uh3RegexEmpty
        }
        Uh3RegexStar(v41) -> {
            let v42 = derivative_20(v41, v1)
            let v43 = make_star_19(v41)
            make_cat_17(v42, v43)
        }
    }
}

pub fn canonical_derivative_12(v0: Uh3, v1: Us1) -> Uh3 {
    let v2 = normalize_13(v0)
    let v3 = derivative_20(v2, v1)
    normalize_13(v3)
}

pub fn accepts_11(v0: Uh3, v1: Uh1) -> Bool {
    case v1  {
        Uh1InputCons(v6, v7) -> {
            let v8 = canonical_derivative_12(v0, v6)
            accepts_11(v8, v7)
        }
        Uh1InputEmpty -> {
            let v2 = normalize_13(v0)
            let v3 = nullable_21(v2)
            case v3  {
                Us3NonNullable -> {
                    False
                }
                Us3Nullable -> {
                    True
                }
            }
        }
    }
}

pub fn decide_bit_match_22(v0: Us4) -> Us5 {
    case v0  {
        Us4BitMatcherRaw(v1, v2) -> {
            let v3 = accepts_0(v1, v2)
            Us5BitMatcherDecided(v1, v2, v3)
        }
    }
}

pub fn bit_match_value_23(v0: Us5) -> Bool {
    case v0  {
        Us5BitMatcherDecided(v1, v2, v3) -> {
            v3
        }
    }
}
