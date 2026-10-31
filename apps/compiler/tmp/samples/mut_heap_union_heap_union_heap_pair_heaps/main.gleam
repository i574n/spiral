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
}
pub type Heap4 { Heap4(l0 : Us1) }
pub type Mut0 { Mut0(l0 : Heap4) }
pub fn score_0(v0: Us1) -> Int {
    case v0  {
        Us1Absent -> 1
        Us1Box(v1) -> {
            let v2 = v1.l0
            case v2  {
                Us0Held(v3) -> {
                    let #(v4, v5) = #(v3.l0, v3.l1)
                    let #(v6, v7) = #(v4.l0, v4.l1)
                    let #(v8, v9) = #(v6.l0, v6.l1)
                    let #(v10, v11) = #(v7.l0, v7.l1)
                    let v12 = v8 == 7
                    let v14 =
                        case v12 {
                            True -> {
                                let v13 = v9 == "hi"
                                v13
                            }
                            False -> False
                        }
                    let v16 =
                        case v14 {
                            True -> {
                                let v15 = v10 == 4
                                v15
                            }
                            False -> False
                        }
                    let v18 =
                        case v16 {
                            True -> {
                                let v17 = v11 == "yo"
                                v17
                            }
                            False -> False
                        }
                    let v20 =
                        case v18 {
                            True -> {
                                let v19 = v5 == 2
                                v19
                            }
                            False -> False
                        }
                    case v20 {
                        True -> 0
                        False -> 1
                    }
                }
                Us0None -> 1
            }
        }
    }
}
pub fn main() {
    let v0 = 1
    let v1 = "no"
    let v2 = Heap0(l0: v0, l1: v1)
    let v3 = 2
    let v4 = "zz"
    let v5 = Heap0(l0: v3, l1: v4)
    let v6 = Heap1(l0: v2, l1: v5)
    let v7 = 3
    let v8 = Heap2(l0: v6, l1: v7)
    let v9 = True
    let v12 =
        case v9 {
            True -> Us0Held(v8)
            False -> Us0None
        }
    let v13 = Heap3(l0: v12)
    let v14 = True
    let v17 =
        case v14 {
            True -> Us1Box(v13)
            False -> Us1Absent
        }
    let v18 = Heap4(l0: v17)
    let v19 = spiral_ref_new(Mut0(l0: v18))
    let v20 = 7
    let v21 = "hi"
    let v22 = Heap0(l0: v20, l1: v21)
    let v23 = 4
    let v24 = "yo"
    let v25 = Heap0(l0: v23, l1: v24)
    let v26 = Heap1(l0: v22, l1: v25)
    let v27 = 2
    let v28 = Heap2(l0: v26, l1: v27)
    let v29 = True
    let v32 =
        case v29 {
            True -> Us0Held(v28)
            False -> Us0None
        }
    let v33 = Heap3(l0: v32)
    let v34 = True
    let v37 =
        case v34 {
            True -> Us1Box(v33)
            False -> Us1Absent
        }
    let v38 = Heap4(l0: v37)
    spiral_ref_set(v19, Mut0(l0: v38))
    let v39 = spiral_ref_get(v19).l0
    let v40 = v39.l0
    score_0(v40)
}
