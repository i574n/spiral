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
pub type Heap1 { Heap1(l0 : Heap0, l1 : Int) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub type Mut0 { Mut0(l0 : Heap2) }
pub fn main() {
    let v2 = Heap0(l0: 3, l1: "no")
    let v4 = Heap1(l0: v2, l1: 1)
    let v6 = Heap2(l0: v4, l1: 2)
    let v7 = spiral_ref_new(Mut0(l0: v6))
    let v10 = Heap0(l0: 7, l1: "hi")
    let v12 = Heap1(l0: v10, l1: 4)
    let v14 = Heap2(l0: v12, l1: 5)
    spiral_ref_set(v7, Mut0(l0: v14))
    let v15 = spiral_ref_get(v7).l0
    let #(v16, v17) = #(v15.l0, v15.l1)
    let #(v18, v19) = #(v16.l0, v16.l1)
    let #(v20, v21) = #(v18.l0, v18.l1)
    let v22 = v20 == 7
    let v24 =
        case v22 {
            True -> {
                v21 == "hi"
            }
            False -> False
        }
    let v26 =
        case v24 {
            True -> {
                v19 == 4
            }
            False -> False
        }
    let v28 =
        case v26 {
            True -> {
                v17 == 5
            }
            False -> False
        }
    case v28 {
        True -> 0
        False -> 1
    }
}
