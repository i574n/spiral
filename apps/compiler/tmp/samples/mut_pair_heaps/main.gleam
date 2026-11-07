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

pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Mut0 { Mut0(l0 : Heap0, l1 : Heap0) }
pub fn main() {
    let v2 = Heap0(l0: 1, l1: "no")
    let v5 = Heap0(l0: 2, l1: "zz")
    let v6 = spiral_ref_new(Mut0(l0: v2, l1: v5))
    let v9 = Heap0(l0: 7, l1: "hi")
    let v12 = Heap0(l0: 4, l1: "yo")
    spiral_ref_set(v6, Mut0(l0: v9, l1: v12))
    let #(v13, v14) = #(spiral_ref_get(v6).l0, spiral_ref_get(v6).l1)
    let #(v15, v16) = #(v13.l0, v13.l1)
    let #(v17, v18) = #(v14.l0, v14.l1)
    let v19 = v15 == 7
    let v21 =
        case v19 {
            True -> {
                v16 == "hi"
            }
            False -> False
        }
    let v23 =
        case v21 {
            True -> {
                v17 == 4
            }
            False -> False
        }
    let v25 =
        case v23 {
            True -> {
                v18 == "yo"
            }
            False -> False
        }
    case v25 {
        True -> 0
        False -> 1
    }
}
