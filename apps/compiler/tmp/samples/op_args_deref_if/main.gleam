import gleam/int
import gleam/io
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


pub type Mut0 { Mut0(l0 : String) }
pub fn main() {
    let v0 = "deref"
    let v1 = spiral_ref_new(Mut0(l0: v0))
    let v2 = 3
    let v3 = "deref!"
    spiral_ref_set(v1, Mut0(l0: v3))
    let v4 = spiral_ref_get(v1).l0
    let v5 = v2 == 3
    let v7 =
        case v5 {
            True -> {
                let v6 = spiral_wrap_signed(v2 + 1, 32)
                v6
            }
            False -> 0
        }
    io.print(v4 <> " " <> int.to_string(v7) <> "\n")
    let v8 = spiral_wrap_signed(v2 * 2, 32)
    let v9 = v2 > 0
    let v10 =
        case v9 {
            True -> 6
            False -> 0
        }
    let v11 = v8 == v10
    case v11 {
        True -> 0
        False -> 1
    }
}
