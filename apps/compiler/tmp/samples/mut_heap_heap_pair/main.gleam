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
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub type Mut0 { Mut0(l0 : Heap2) }
pub fn main() {
    let v2 = Heap0(l0: 1, l1: "no")
    let v5 = Heap0(l0: 2, l1: "zz")
    let v6 = Heap1(l0: v2, l1: v5)
    let v8 = Heap2(l0: v6, l1: 3)
    let v9 = spiral_ref_new(Mut0(l0: v8))
    let v12 = Heap0(l0: 7, l1: "hi")
    let v15 = Heap0(l0: 4, l1: "yo")
    let v16 = Heap1(l0: v12, l1: v15)
    let v18 = Heap2(l0: v16, l1: 2)
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
                v25 == "hi"
            }
            False -> False
        }
    let v32 =
        case v30 {
            True -> {
                v26 == 4
            }
            False -> False
        }
    let v34 =
        case v32 {
            True -> {
                v27 == "yo"
            }
            False -> False
        }
    let v36 =
        case v34 {
            True -> {
                v21 == 2
            }
            False -> False
        }
    case v36 {
        True -> 0
        False -> 1
    }
}
