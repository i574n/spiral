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

pub type Mut0 { Mut0(l0 : Int, l1 : String) }
pub fn main() {
    let v0 = 1
    let v1 = "no"
    let v2 = spiral_ref_new(Mut0(l0: v0, l1: v1))
    let v3 = 4000000000
    let v4 = "hi"
    spiral_ref_set(v2, Mut0(l0: v3, l1: v4))
    let #(v5, v6) = #(spiral_ref_get(v2).l0, spiral_ref_get(v2).l1)
    let v7 = v5 == 4000000000
    let v9 =
        case v7 {
            True -> {
                let v8 = v6 == "hi"
                v8
            }
            False -> False
        }
    case v9 {
        True -> 0
        False -> 1
    }
}
