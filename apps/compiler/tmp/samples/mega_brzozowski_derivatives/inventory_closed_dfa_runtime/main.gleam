import main_types.{Uh0SymbolListCons, Uh0SymbolListNil, Uh1InputListCons, Uh2InputEmpty, Uh3SymbolListCons, Uh3SymbolListNil, Uh4InputListCons, Uh5InputEmpty, Uh6InputCons, Uh6InputEmpty, Uh7RegexAlt, Uh7RegexCat, Uh7RegexChar, Uh7RegexStar, Uh8RegexAlt, Uh8RegexCat, Uh8RegexChar, Uh8RegexStar, Us0BitOne, Us0BitZero, Us1TriA, Us1TriB, Us1TriC, Us2ModelC, Us3InventoryDfaInputOutsideInventory}
import main_part1.{input_list_append_3, input_list_append_7, input_prepend_symbols_to_corpus_1, input_prepend_symbols_to_corpus_5, input_singletons_from_symbols_0, input_singletons_from_symbols_4, loop_8}
import main_part2.{loop_21, loop_34}

pub fn main() {
    let v0 = Us0BitZero
    let v1 = Us0BitOne
    let v2 = Uh0SymbolListNil
    let v3 = Uh0SymbolListCons(v1, v2)
    let v4 = Uh0SymbolListCons(v0, v3)
    let v5 = input_singletons_from_symbols_0(v4)
    let v6 = Uh2InputEmpty
    let v7 = Uh1InputListCons(v6, v5)
    let v8 = Us0BitZero
    let v9 = Us0BitOne
    let v10 = Uh0SymbolListNil
    let v11 = Uh0SymbolListCons(v9, v10)
    let v12 = Uh0SymbolListCons(v8, v11)
    let v13 = Us0BitZero
    let v14 = Us0BitOne
    let v15 = Uh0SymbolListNil
    let v16 = Uh0SymbolListCons(v14, v15)
    let v17 = Uh0SymbolListCons(v13, v16)
    let v18 = input_singletons_from_symbols_0(v17)
    let v19 = input_prepend_symbols_to_corpus_1(v12, v18)
    let v20 = input_list_append_3(v7, v19)
    let v21 = Us1TriA
    let v22 = Us1TriB
    let v23 = Us1TriC
    let v24 = Uh3SymbolListNil
    let v25 = Uh3SymbolListCons(v23, v24)
    let v26 = Uh3SymbolListCons(v22, v25)
    let v27 = Uh3SymbolListCons(v21, v26)
    let v28 = input_singletons_from_symbols_4(v27)
    let v29 = Uh5InputEmpty
    let v30 = Uh4InputListCons(v29, v28)
    let v31 = Us1TriA
    let v32 = Us1TriB
    let v33 = Us1TriC
    let v34 = Uh3SymbolListNil
    let v35 = Uh3SymbolListCons(v33, v34)
    let v36 = Uh3SymbolListCons(v32, v35)
    let v37 = Uh3SymbolListCons(v31, v36)
    let v38 = Us1TriA
    let v39 = Us1TriB
    let v40 = Us1TriC
    let v41 = Uh3SymbolListNil
    let v42 = Uh3SymbolListCons(v40, v41)
    let v43 = Uh3SymbolListCons(v39, v42)
    let v44 = Uh3SymbolListCons(v38, v43)
    let v45 = input_singletons_from_symbols_4(v44)
    let v46 = input_prepend_symbols_to_corpus_5(v37, v45)
    let v47 = input_list_append_7(v30, v46)
    let v48 = Us2ModelC
    let v49 = Uh6InputEmpty
    let v50 = Uh6InputCons(v48, v49)
    let v51 = Us0BitZero
    let v52 = Uh7RegexChar(v51)
    let v53 = Us0BitOne
    let v54 = Uh7RegexChar(v53)
    let v55 = Uh7RegexAlt(v52, v54)
    let v56 = Uh7RegexStar(v55)
    let v57 = Us0BitZero
    let v58 = Uh7RegexChar(v57)
    let v59 = Uh7RegexCat(v56, v58)
    let v60 = loop_8(v59, v20)
    let v75 =
        case v60 {
            True -> {
                let v61 = Us1TriA
                let v62 = Uh8RegexChar(v61)
                let v63 = Us1TriB
                let v64 = Uh8RegexChar(v63)
                let v65 = Uh8RegexAlt(v62, v64)
                let v66 = Uh8RegexStar(v65)
                let v67 = Us1TriC
                let v68 = Uh8RegexChar(v67)
                let v69 = Uh8RegexCat(v66, v68)
                let v70 = loop_21(v69, v47)
                case v70 {
                    True -> {
                        let v71 = 1
                        let v72 = loop_34(v71, v50)
                        case v72  {
                            Us3InventoryDfaInputOutsideInventory -> {
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
            }
            False -> {
                False
            }
        }
    case v75 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
