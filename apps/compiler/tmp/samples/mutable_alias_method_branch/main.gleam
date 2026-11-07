import gleam/int
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

pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Mut0 { Mut0(l0 : Int) }
pub fn method0(v0: SpiralRef(Mut0)) -> Nil {
    let v1 = spiral_ref_get(v0).l0
    let v2 = spiral_wrap_signed(v1 + 5, 32)
    spiral_ref_set(v0, Mut0(l0: v2))
    Nil
}
pub fn method1(_v0: SpiralRef(Mut0)) -> Nil {
    Nil
}
pub fn method2(v0: SpiralRef(Mut0)) -> Nil {
    let v1 = spiral_ref_get(v0).l0
    let v2 = spiral_wrap_signed(v1 + 7, 32)
    spiral_ref_set(v0, Mut0(l0: v2))
    Nil
}
pub fn main() {
    let v0 = spiral_ref_new(Mut0(l0: 0))
    method0(v0)
    method1(v0)
    method2(v0)
    let v1 = spiral_ref_get(v0).l0
    spiral_wrap_signed(v1 - 12, 32)
}
