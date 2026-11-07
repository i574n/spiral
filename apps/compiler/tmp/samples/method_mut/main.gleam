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

pub type Mut0 { Mut0(l0 : Int) }
pub fn method0(v0: SpiralRef(Mut0)) -> SpiralRef(Mut0) {
    v0
}
pub fn main() {
    let v0 = spiral_ref_new(Mut0(l0: 1))
    let v1 = method0(v0)
    spiral_ref_set(v1, Mut0(l0: 7))
    let v2 = spiral_ref_get(v1).l0
    let v3 = v2 == 7
    case v3 {
        True -> 0
        False -> 1
    }
}
