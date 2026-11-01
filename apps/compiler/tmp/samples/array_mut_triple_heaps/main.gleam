import gleam/list
import gleam/option
pub type SpiralRefCell(a)

pub type SpiralRef(a) {
  SpiralRef(cell: SpiralRefCell(a))
}

@external(erlang, "main_ffi", "ref_new")
@external(javascript, "./main_ffi.mjs", "ref_new")
pub fn spiral_ref_cell_new(value: a) -> SpiralRefCell(a)

@external(erlang, "main_ffi", "ref_get")
@external(javascript, "./main_ffi.mjs", "ref_get")
pub fn spiral_ref_cell_get(cell: SpiralRefCell(a)) -> a

@external(erlang, "main_ffi", "ref_set")
@external(javascript, "./main_ffi.mjs", "ref_set")
pub fn spiral_ref_cell_set(cell: SpiralRefCell(a), value: a) -> Nil

pub fn spiral_ref_new(value: a) -> SpiralRef(a) {
  SpiralRef(cell: spiral_ref_cell_new(value))
}

pub fn spiral_ref_get(reference: SpiralRef(a)) -> a {
  spiral_ref_cell_get(reference.cell)
}

pub fn spiral_ref_set(reference: SpiralRef(a), value: a) -> Nil {
  spiral_ref_cell_set(reference.cell, value)
}

pub type SpiralArrayStore(a)

pub type SpiralArray(a) {
  SpiralArray(store: SpiralArrayStore(option.Option(a)), size: Int)
}

@external(erlang, "main_ffi", "array_new")
@external(javascript, "./main_ffi.mjs", "array_new")
pub fn spiral_array_store_new(size: Int, fill: a) -> SpiralArrayStore(a)

@external(erlang, "main_ffi", "array_get")
@external(javascript, "./main_ffi.mjs", "array_get")
pub fn spiral_array_store_get(store: SpiralArrayStore(a), i: Int) -> a

@external(erlang, "main_ffi", "array_set")
@external(javascript, "./main_ffi.mjs", "array_set")
pub fn spiral_array_store_set(store: SpiralArrayStore(a), i: Int, value: a) -> Nil

pub fn spiral_array_create(size: Int) -> SpiralArray(a) {
  SpiralArray(store: spiral_array_store_new(size, option.None), size: size)
}




pub fn spiral_array_get(xs: SpiralArray(a), i: Int) -> a {
  case i >= 0 && i < xs.size {
    True ->
      case spiral_array_store_get(xs.store, i) {
        option.Some(x) -> x
        option.None -> panic as "spiral array: read of an element that was never set"
      }
    False -> panic as "spiral array: index out of bounds"
  }
}

pub fn spiral_array_set(xs: SpiralArray(a), i: Int, value: a) -> Nil {
  case i >= 0 && i < xs.size {
    True -> spiral_array_store_set(xs.store, i, option.Some(value))
    False -> panic as "spiral array: index out of bounds"
  }
}

pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Mut0 { Mut0(l0 : Heap0, l1 : Heap0, l2 : Heap0) }
pub fn main() {
    let v0 = 1
    let v1 = "no"
    let v2 = Heap0(l0: v0, l1: v1)
    let v3 = 2
    let v4 = "zz"
    let v5 = Heap0(l0: v3, l1: v4)
    let v6 = 3
    let v7 = "aa"
    let v8 = Heap0(l0: v6, l1: v7)
    let v9 = spiral_ref_new(Mut0(l0: v2, l1: v5, l2: v8))
    let v10 = spiral_array_create(1)
    spiral_array_set(v10, 0, v9)
    let v11 = 7
    let v12 = "hi"
    let v13 = Heap0(l0: v11, l1: v12)
    let v14 = 4
    let v15 = "yo"
    let v16 = Heap0(l0: v14, l1: v15)
    let v17 = 9
    let v18 = "ok"
    let v19 = Heap0(l0: v17, l1: v18)
    let v20 = spiral_array_get(v10, 0)
    spiral_ref_set(v20, Mut0(l0: v13, l1: v16, l2: v19))
    let #(v21, v22, v23) = #(spiral_ref_get(v20).l0, spiral_ref_get(v20).l1, spiral_ref_get(v20).l2)
    let #(v24, v25) = #(v21.l0, v21.l1)
    let #(v26, v27) = #(v22.l0, v22.l1)
    let #(v28, v29) = #(v23.l0, v23.l1)
    let v30 = v24 == 7
    let v32 =
        case v30 {
            True -> {
                let v31 = v25 == "hi"
                v31
            }
            False -> False
        }
    let v34 =
        case v32 {
            True -> {
                let v33 = v26 == 4
                v33
            }
            False -> False
        }
    let v36 =
        case v34 {
            True -> {
                let v35 = v27 == "yo"
                v35
            }
            False -> False
        }
    let v38 =
        case v36 {
            True -> {
                let v37 = v28 == 9
                v37
            }
            False -> False
        }
    let v40 =
        case v38 {
            True -> {
                let v39 = v29 == "ok"
                v39
            }
            False -> False
        }
    case v40 {
        True -> 0
        False -> 1
    }
}
