import main_types.{Uh0InputCons, Uh0InputEmpty, Uh1InputCons, Uh1InputEmpty, Uh2RegexAlt, Uh2RegexCat, Uh2RegexChar, Uh2RegexStar, Uh3RegexChar, Uh3RegexStar, Us0BitOne, Us0BitZero, Us1TriA, Us1TriB, Us4BitMatcherRaw}
import main_part1.{accepts_0}
import main_part2.{accepts_11, bit_match_value_23, decide_bit_match_22}

pub fn main() {
    let v0 = Us0BitOne
    let v1 = Us0BitOne
    let v2 = Us0BitZero
    let v3 = Uh0InputEmpty
    let v4 = Uh0InputCons(v2, v3)
    let v5 = Uh0InputCons(v1, v4)
    let v6 = Uh0InputCons(v0, v5)
    let v7 = Us0BitOne
    let v8 = Us0BitOne
    let v9 = Us0BitOne
    let v10 = Uh0InputEmpty
    let v11 = Uh0InputCons(v9, v10)
    let v12 = Uh0InputCons(v8, v11)
    let v13 = Uh0InputCons(v7, v12)
    let v14 = Us1TriA
    let v15 = Us1TriA
    let v16 = Us1TriA
    let v17 = Uh1InputEmpty
    let v18 = Uh1InputCons(v16, v17)
    let v19 = Uh1InputCons(v15, v18)
    let v20 = Uh1InputCons(v14, v19)
    let v21 = Us1TriA
    let v22 = Us1TriA
    let v23 = Us1TriB
    let v24 = Uh1InputEmpty
    let v25 = Uh1InputCons(v23, v24)
    let v26 = Uh1InputCons(v22, v25)
    let v27 = Uh1InputCons(v21, v26)
    let v28 = Us0BitZero
    let v29 = Uh2RegexChar(v28)
    let v30 = Us0BitOne
    let v31 = Uh2RegexChar(v30)
    let v32 = Uh2RegexAlt(v29, v31)
    let v33 = Uh2RegexStar(v32)
    let v34 = Us0BitZero
    let v35 = Uh2RegexChar(v34)
    let v36 = Uh2RegexCat(v33, v35)
    let v37 = accepts_0(v36, v6)
    case v37 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-expected-true"
        }
    }
    let v38 = Us0BitZero
    let v39 = Uh2RegexChar(v38)
    let v40 = Us0BitOne
    let v41 = Uh2RegexChar(v40)
    let v42 = Uh2RegexAlt(v39, v41)
    let v43 = Uh2RegexStar(v42)
    let v44 = Us0BitZero
    let v45 = Uh2RegexChar(v44)
    let v46 = Uh2RegexCat(v43, v45)
    let v47 = accepts_0(v46, v13)
    case v47 {
        True -> {
            panic as "brzozowski-expected-false"
        }
        False -> {
        Nil
        }
    }
    let v48 = Us1TriA
    let v49 = Uh3RegexChar(v48)
    let v50 = Uh3RegexStar(v49)
    let v51 = accepts_11(v50, v20)
    case v51 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-expected-true"
        }
    }
    let v52 = Us1TriA
    let v53 = Uh3RegexChar(v52)
    let v54 = Uh3RegexStar(v53)
    let v55 = accepts_11(v54, v27)
    case v55 {
        True -> {
            panic as "brzozowski-expected-false"
        }
        False -> {
        Nil
        }
    }
    let v56 = Us0BitZero
    let v57 = Uh2RegexChar(v56)
    let v58 = Us0BitOne
    let v59 = Uh2RegexChar(v58)
    let v60 = Uh2RegexAlt(v57, v59)
    let v61 = Uh2RegexStar(v60)
    let v62 = Us0BitZero
    let v63 = Uh2RegexChar(v62)
    let v64 = Uh2RegexCat(v61, v63)
    let v65 = Us4BitMatcherRaw(v64, v6)
    let v66 = decide_bit_match_22(v65)
    let v67 = Us0BitZero
    let v68 = Uh2RegexChar(v67)
    let v69 = Us0BitOne
    let v70 = Uh2RegexChar(v69)
    let v71 = Uh2RegexAlt(v68, v70)
    let v72 = Uh2RegexStar(v71)
    let v73 = Us0BitZero
    let v74 = Uh2RegexChar(v73)
    let v75 = Uh2RegexCat(v72, v74)
    let v76 = Us4BitMatcherRaw(v75, v13)
    let v77 = decide_bit_match_22(v76)
    let v78 = bit_match_value_23(v66)
    case v78 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-expected-true"
        }
    }
    let v79 = bit_match_value_23(v77)
    case v79 {
        True -> {
            panic as "brzozowski-expected-false"
        }
        False -> {
        Nil
        }
    }
    0
}
