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
pub fn score_0(v0: Us1) -> Int {
    case v0  {
        Us1Absent -> 1
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
                            False -> False
                        }
                    let v18 =
                        case v16 {
                            True -> {
                                let v17 = v12 == 4
                                v17
                            }
                            False -> False
                        }
                    let v20 =
                        case v18 {
                            True -> {
                                let v19 = v13 == "yo"
                                v19
                            }
                            False -> False
                        }
                    let v22 =
                        case v20 {
                            True -> {
                                let v21 = v7 == 2
                                v21
                            }
                            False -> False
                        }
                    case v22 {
                        True -> 0
                        False -> 1
                    }
                }
                Us0None -> 1
            }
        }
        Us1Mark(v1) -> 1
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
            True -> Us0Held(v8)
            False -> Us0None
        }
    let v13 = Heap3(l0: v12)
    let v14 = True
    let v17 =
        case v14 {
            True -> Us1Box(v13)
            False -> Us1Mark(1)
        }
    let v18 = 3
    let v19 = Heap4(l0: v17)
    let v20 = Us1Mark(v18)
    let v21 = Heap4(l0: v20)
    let v22 = spiral_ref_new(Mut0(l0: v19))
    let v23 = spiral_array_create(1)
    spiral_array_set(v23, 0, v22)
    let v24 = spiral_array_get(v23, 0)
    let v25 = spiral_ref_get(v24).l0
    let v26 = v25.l0
    let v27 = score_0(v26)
    spiral_ref_set(v24, Mut0(l0: v21))
    let v28 = spiral_ref_get(v24).l0
    let v29 = v28.l0
    let v30 = score_0(v29)
    let v31 = v27 == 0
    let v33 =
        case v31 {
            True -> {
                let v32 = v30 == 1
                v32
            }
            False -> False
        }
    case v33 {
        True -> 0
        False -> 1
    }
}
