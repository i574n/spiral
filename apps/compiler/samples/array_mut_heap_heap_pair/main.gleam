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
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub type Mut0 { Mut0(l0 : Heap2) }
pub fn main() {
    let v2 = Heap0(l0: 1, l1: "no")
    let v5 = Heap0(l0: 2, l1: "zz")
    let v6 = Heap1(l0: v2, l1: v5)
    let v8 = Heap2(l0: v6, l1: 3)
    let v9 = spiral_ref_new(Mut0(l0: v8))
    let v10 = spiral_array_create(1)
    spiral_array_set(v10, 0, v9)
    let v13 = Heap0(l0: 7, l1: "hi")
    let v16 = Heap0(l0: 4, l1: "yo")
    let v17 = Heap1(l0: v13, l1: v16)
    let v19 = Heap2(l0: v17, l1: 2)
    let v20 = spiral_array_get(v10, 0)
    spiral_ref_set(v20, Mut0(l0: v19))
    let v21 = spiral_ref_get(v20).l0
    let #(v22, v23) = #(v21.l0, v21.l1)
    let #(v24, v25) = #(v22.l0, v22.l1)
    let #(v26, v27) = #(v24.l0, v24.l1)
    let #(v28, v29) = #(v25.l0, v25.l1)
    let v30 = v26 == 7
    let v32 =
        case v30 {
            True -> {
                v27 == "hi"
            }
            False -> False
        }
    let v34 =
        case v32 {
            True -> {
                v28 == 4
            }
            False -> False
        }
    let v36 =
        case v34 {
            True -> {
                v29 == "yo"
            }
            False -> False
        }
    let v38 =
        case v36 {
            True -> {
                v23 == 2
            }
            False -> False
        }
    case v38 {
        True -> 0
        False -> 1
    }
}
