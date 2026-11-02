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
pub type Us0 {
    Us0Missing
    Us0Held(f1i0 : SpiralRef(Mut0))
}
pub fn main() {
    let v0 = spiral_ref_new(Mut0(l0: 1))
    let v1 = True
    let v4 =
        case v1 {
            True -> Us0Held(v0)
            False -> Us0Missing
        }
    case v4  {
        Us0Held(v5) -> {
            spiral_ref_set(v5, Mut0(l0: 7))
            let v6 = spiral_ref_get(v5).l0
            let v7 = v6 == 7
            case v7 {
                True -> 0
                False -> 1
            }
        }
        Us0Missing -> 1
    }
}
