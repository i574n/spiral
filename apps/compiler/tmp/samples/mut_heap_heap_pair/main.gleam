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
pub type Mut0 { Mut0(l0 : Heap2) }
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
    let v9 = spiral_ref_new(Mut0(l0: v8))
    let v10 = 7
    let v11 = "hi"
    let v12 = Heap0(l0: v10, l1: v11)
    let v13 = 4
    let v14 = "yo"
    let v15 = Heap0(l0: v13, l1: v14)
    let v16 = Heap1(l0: v12, l1: v15)
    let v17 = 2
    let v18 = Heap2(l0: v16, l1: v17)
    spiral_ref_set(v9, Mut0(l0: v18))
    let v19 = spiral_ref_get(v9).l0
    let #(v20, v21) = #(v19.l0, v19.l1)
    let #(v22, v23) = #(v20.l0, v20.l1)
    let #(v24, v25) = #(v22.l0, v22.l1)
    let #(v26, v27) = #(v23.l0, v23.l1)
    let v28 = v24 == 7
    let v30 =
        case v28 {
            True -> {
                let v29 = v25 == "hi"
                v29
            }
            False -> False
        }
    let v32 =
        case v30 {
            True -> {
                let v31 = v26 == 4
                v31
            }
            False -> False
        }
    let v34 =
        case v32 {
            True -> {
                let v33 = v27 == "yo"
                v33
            }
            False -> False
        }
    let v36 =
        case v34 {
            True -> {
                let v35 = v21 == 2
                v35
            }
            False -> False
        }
    case v36 {
        True -> 0
        False -> 1
    }
}
