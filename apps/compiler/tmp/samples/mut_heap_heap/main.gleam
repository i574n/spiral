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
pub type Mut0 { Mut0(l0 : Heap1) }
pub fn main() {
    let v2 = Heap0(l0: 3, l1: "no")
    let v4 = Heap1(l0: v2, l1: 1)
    let v5 = spiral_ref_new(Mut0(l0: v4))
    let v8 = Heap0(l0: 7, l1: "hi")
    let v10 = Heap1(l0: v8, l1: 4)
    spiral_ref_set(v5, Mut0(l0: v10))
    let v11 = spiral_ref_get(v5).l0
    let #(v12, v13) = #(v11.l0, v11.l1)
    let #(v14, v15) = #(v12.l0, v12.l1)
    let v16 = v14 == 7
    let v18 =
        case v16 {
            True -> {
                v15 == "hi"
            }
            False -> False
        }
    let v20 =
        case v18 {
            True -> {
                v13 == 4
            }
            False -> False
        }
    case v20 {
        True -> 0
        False -> 1
    }
}
