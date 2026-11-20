pub type Us0 {
    Us0Vowel(f0i0 : Int)
}
pub type Uh0 {
    Uh0Nil
    Uh0Cons(Us0, Uh0)
}
pub fn method0(v0: Uh0, v1: Uh0) -> Bool {
    case v1,v0  {
        Uh0Cons(v2, v3),Uh0Cons(v4, v5) -> {
            let v9 =
                case v2,v4  {
                    Us0Vowel(v6),Us0Vowel(v7) -> {
                        v6 == v7
                    }
                    _,_ -> False
                }
            case v9 {
                True -> method0(v5, v3)
                False -> False
            }
        }
        Uh0Nil,Uh0Nil -> True
        _,_ -> False
    }
}
pub fn main() {
    let v1 = Us0Vowel(1)
    let v3 = Us0Vowel(1)
    let v5 = Us0Vowel(2)
    let v7 = Uh0Cons(v5, Uh0Nil)
    let v8 = Uh0Cons(v1, v7)
    let v10 = Uh0Cons(v5, Uh0Nil)
    let v11 = Uh0Cons(v3, v10)
    let v13 = Uh0Cons(v1, Uh0Nil)
    let v17 =
        case v1,v3  {
            Us0Vowel(v14),Us0Vowel(v15) -> {
                v14 == v15
            }
            _,_ -> False
        }
    let v23 =
        case v17 {
            True -> {
                let v21 =
                    case v1,v5  {
                        Us0Vowel(v18),Us0Vowel(v19) -> {
                            v18 == v19
                        }
                        _,_ -> False
                    }
                v21 == False
            }
            False -> False
        }
    let v30 =
        case v23 {
            True -> {
                let v27 =
                    case v1,v3  {
                        Us0Vowel(v24),Us0Vowel(v25) -> {
                            v24 == v25
                        }
                        _,_ -> False
                    }
                case v27 {
                    True -> method0(v11, v8)
                    False -> False
                }
            }
            False -> False
        }
    let v38 =
        case v30 {
            True -> {
                let v34 =
                    case v1,v5  {
                        Us0Vowel(v31),Us0Vowel(v32) -> {
                            v31 == v32
                        }
                        _,_ -> False
                    }
                let v36 =
                    case v34 {
                        True -> method0(v13, v8)
                        False -> False
                    }
                v36 == False
            }
            False -> False
        }
    case v38 {
        True -> 0
        False -> 1
    }
}
