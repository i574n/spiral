import main_types.{Uh0RegexAlt, Uh0RegexCat, Uh0RegexChar, Uh0RegexStar, Uh2RegexAlt, Uh2RegexCat, Uh2RegexChar, Uh2RegexStar, Uh3InputCons, Uh3InputEmpty, Us0BitOne, Us0BitZero, Us3TriA, Us3TriB, Us3TriC}
import main_part1.{loop_0, loop_14}
import main_part2.{accepts_18, run_17}

pub fn main() {
    let v0 = 200
    let v1 = 32
    let v2 = 16
    let v3 = Us0BitZero
    let v4 = Uh0RegexChar(v3)
    let v5 = Us0BitOne
    let v6 = Uh0RegexChar(v5)
    let v7 = Uh0RegexAlt(v4, v6)
    let v8 = Uh0RegexStar(v7)
    let v9 = Us0BitZero
    let v10 = Uh0RegexChar(v9)
    let v11 = Uh0RegexCat(v8, v10)
    let v12 = 1
    let v13 = 0
    let v14 = loop_0(v1, v11, v0, v12, v13)
    let v15 = v14 == 93
    case v15 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-compiled-ends-with-zero-count"
        }
    }
    let v16 = Us0BitZero
    let v17 = Uh0RegexChar(v16)
    let v18 = Us0BitZero
    let v19 = Uh0RegexChar(v18)
    let v20 = Us0BitZero
    let v21 = Uh0RegexChar(v20)
    let v22 = Uh0RegexCat(v19, v21)
    let v23 = Uh0RegexAlt(v17, v22)
    let v24 = Uh0RegexStar(v23)
    let v25 = Us0BitOne
    let v26 = Uh0RegexChar(v25)
    let v27 = Uh0RegexCat(v24, v26)
    let v28 = 1
    let v29 = 0
    let v30 = loop_14(v2, v27, v28, v29)
    let v31 = v30 == 16
    case v31 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-compiled-zero-runs-count"
        }
    }
    let v32 = Us3TriA
    let v33 = Uh2RegexChar(v32)
    let v34 = Us3TriB
    let v35 = Uh2RegexChar(v34)
    let v36 = Uh2RegexAlt(v33, v35)
    let v37 = Uh2RegexStar(v36)
    let v38 = Us3TriC
    let v39 = Uh2RegexChar(v38)
    let v40 = Uh2RegexCat(v37, v39)
    let v41 = Us3TriA
    let v42 = Us3TriB
    let v43 = Us3TriA
    let v44 = Us3TriC
    let v45 = Uh3InputEmpty
    let v46 = Uh3InputCons(v44, v45)
    let v47 = Uh3InputCons(v43, v46)
    let v48 = Uh3InputCons(v42, v47)
    let v49 = Uh3InputCons(v41, v48)
    let v50 = Us3TriA
    let v51 = Us3TriB
    let v52 = Us3TriA
    let v53 = Us3TriB
    let v54 = Uh3InputEmpty
    let v55 = Uh3InputCons(v53, v54)
    let v56 = Uh3InputCons(v52, v55)
    let v57 = Uh3InputCons(v51, v56)
    let v58 = Uh3InputCons(v50, v57)
    let v59 = 0
    let v60 = run_17(v59, v49)
    let v62 =
        case v60 {
            True -> {
                accepts_18(v40, v49)
            }
            False -> {
                False
            }
        }
    let v68 =
        case v62 {
            True -> {
                let v63 = 0
                let v64 = run_17(v63, v58)
                case v64 {
                    True -> {
                        False
                    }
                    False -> {
                        let v65 = accepts_18(v40, v58)
                        let v66 = v65 == False
                        v66
                    }
                }
            }
            False -> {
                False
            }
        }
    case v68 {
        True -> {
            0
        }
        False -> {
            panic as "brzozowski-compiled-ternary-disagrees"
        }
    }
}
