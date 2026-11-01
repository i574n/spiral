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
pub type Mut0 { Mut0(l0 : Heap0, l1 : Heap0) }
pub fn main() {
    let v0 = 1
    let v1 = "no"
    let v2 = Heap0(l0: v0, l1: v1)
    let v3 = 2
    let v4 = "zz"
    let v5 = Heap0(l0: v3, l1: v4)
    let v6 = spiral_ref_new(Mut0(l0: v2, l1: v5))
    let v7 = spiral_array_create(1)
    spiral_array_set(v7, 0, v6)
    let v8 = 7
    let v9 = "hi"
    let v10 = Heap0(l0: v8, l1: v9)
    let v11 = 4
    let v12 = "yo"
    let v13 = Heap0(l0: v11, l1: v12)
    let v14 = spiral_array_get(v7, 0)
    spiral_ref_set(v14, Mut0(l0: v10, l1: v13))
    let #(v15, v16) = #(spiral_ref_get(v14).l0, spiral_ref_get(v14).l1)
    let #(v17, v18) = #(v15.l0, v15.l1)
    let #(v19, v20) = #(v16.l0, v16.l1)
    let v21 = v17 == 7
    let v23 =
        case v21 {
            True -> {
                let v22 = v18 == "hi"
                v22
            }
            False -> False
        }
    let v25 =
        case v23 {
            True -> {
                let v24 = v19 == 4
                v24
            }
            False -> False
        }
    let v27 =
        case v25 {
            True -> {
                let v26 = v20 == "yo"
                v26
            }
            False -> False
        }
    case v27 {
        True -> 0
        False -> 1
    }
}
