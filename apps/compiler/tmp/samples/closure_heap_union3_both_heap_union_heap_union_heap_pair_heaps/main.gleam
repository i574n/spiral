import gary
import gary/array
import gleam/list
import gleam/option
pub type SpiralArrayKey

pub type SpiralArray(a) {
  SpiralArray(key: SpiralArrayKey, size: Int)
}

@external(erlang, "erlang", "make_ref")
pub fn spiral_array_new_key() -> SpiralArrayKey










pub type SpiralRef(a) {
  SpiralRef(key: SpiralArrayKey)
}

@external(erlang, "erlang", "put")
pub fn spiral_ref_store(key: SpiralArrayKey, value: a) -> b

@external(erlang, "erlang", "get")
pub fn spiral_ref_load(key: SpiralArrayKey) -> a

pub fn spiral_ref_new(value: a) -> SpiralRef(a) {
  let key = spiral_array_new_key()
  let _ = spiral_ref_store(key, value)
  SpiralRef(key: key)
}

pub fn spiral_ref_get(reference: SpiralRef(a)) -> a {
  spiral_ref_load(reference.key)
}

pub fn spiral_ref_set(reference: SpiralRef(a), value: a) -> Nil {
  let _ = spiral_ref_store(reference.key, value)
  Nil
}

pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap2)
}
pub type Heap3 { Heap3(l0 : Us0) }
pub type Us1 {
    Us1Absent
    Us1Box(f1i0 : Heap3)
    Us1Mark(f2i0 : Int)
}
pub type Heap4 { Heap4(l0 : Us1) }
pub type Mut0 { Mut0(l0 : Heap4) }
pub fn f_c0(capt: #(Heap4, Heap4)) -> fn(Int) -> Heap4 {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 == 0
        case v3 {
            True -> {
                v1
            }
            False -> {
                v0
            }
        }
    }
}
pub fn score_0(v0: Us1) -> Int {
    case v0  {
        Us1Absent -> {
            1
        }
        Us1Box(v3) -> {
            let v4 = v3.l0
            case v4  {
                Us0Held(v5) -> {
                    let #(v6, v7) = #(v5.l0, v5.l1)
                    let #(v8, v9) = #(v6.l0, v6.l1)
                    let #(v10, v11) = #(v8.l0, v8.l1)
                    let #(v12, v13) = #(v9.l0, v9.l1)
                    let v14 = v10 == 7
                    let v16 =
                        case v14 {
                            True -> {
                                let v15 = v11 == "hi"
                                v15
                            }
                            False -> {
                                False
                            }
                        }
                    let v18 =
                        case v16 {
                            True -> {
                                let v17 = v12 == 4
                                v17
                            }
                            False -> {
                                False
                            }
                        }
                    let v20 =
                        case v18 {
                            True -> {
                                let v19 = v13 == "yo"
                                v19
                            }
                            False -> {
                                False
                            }
                        }
                    let v22 =
                        case v20 {
                            True -> {
                                let v21 = v7 == 2
                                v21
                            }
                            False -> {
                                False
                            }
                        }
                    case v22 {
                        True -> {
                            0
                        }
                        False -> {
                            1
                        }
                    }
                }
                Us0None -> {
                    1
                }
            }
        }
        Us1Mark(v1) -> {
            1
        }
    }
}
pub fn main() {
    let v0 = 7
    let v1 = "hi"
    let v2 = Heap0(l0: v0, l1: v1)
    let v3 = 4
    let v4 = "yo"
    let v5 = Heap0(l0: v3, l1: v4)
    let v6 = Heap1(l0: v2, l1: v5)
    let v7 = 2
    let v8 = Heap2(l0: v6, l1: v7)
    let v9 = True
    let v12 =
        case v9 {
            True -> {
                Us0Held(v8)
            }
            False -> {
                Us0None
            }
        }
    let v13 = Heap3(l0: v12)
    let v14 = True
    let v17 =
        case v14 {
            True -> {
                Us1Box(v13)
            }
            False -> {
                Us1Mark(1)
            }
        }
    let v18 = 3
    let v19 = Heap4(l0: v17)
    let v20 = Us1Mark(v18)
    let v21 = Heap4(l0: v20)
    let v22 = f_c0(#(v19, v21))
    let v23 = v22(1)
    let v24 = spiral_ref_new(Mut0(l0: v23))
    let v25 = spiral_ref_get(v24).l0
    let v26 = v25.l0
    let v27 = score_0(v26)
    let v28 = v22(0)
    spiral_ref_set(v24, Mut0(l0: v28))
    let v29 = spiral_ref_get(v24).l0
    let v30 = v29.l0
    let v31 = score_0(v30)
    let v32 = v27 == 0
    let v34 =
        case v32 {
            True -> {
                let v33 = v31 == 1
                v33
            }
            False -> {
                False
            }
        }
    case v34 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
