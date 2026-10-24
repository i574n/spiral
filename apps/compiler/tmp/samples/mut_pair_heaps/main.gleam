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
pub type Mut0 { Mut0(l0 : Heap0, l1 : Heap0) }
pub fn main() {
    let v0 = 1
    let v1 = "no"
    let v2 = Heap0(l0: v0, l1: v1)
    let v3 = 2
    let v4 = "zz"
    let v5 = Heap0(l0: v3, l1: v4)
    let v6 = spiral_ref_new(Mut0(l0: v2, l1: v5))
    let v7 = 7
    let v8 = "hi"
    let v9 = Heap0(l0: v7, l1: v8)
    let v10 = 4
    let v11 = "yo"
    let v12 = Heap0(l0: v10, l1: v11)
    spiral_ref_set(v6, Mut0(l0: v9, l1: v12))
    let #(v13, v14) = #(spiral_ref_get(v6).l0, spiral_ref_get(v6).l1)
    let #(v15, v16) = #(v13.l0, v13.l1)
    let #(v17, v18) = #(v14.l0, v14.l1)
    let v19 = v15 == 7
    let v21 =
        case v19 {
            True -> {
                let v20 = v16 == "hi"
                v20
            }
            False -> {
                False
            }
        }
    let v23 =
        case v21 {
            True -> {
                let v22 = v17 == 4
                v22
            }
            False -> {
                False
            }
        }
    let v25 =
        case v23 {
            True -> {
                let v24 = v18 == "yo"
                v24
            }
            False -> {
                False
            }
        }
    case v25 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
