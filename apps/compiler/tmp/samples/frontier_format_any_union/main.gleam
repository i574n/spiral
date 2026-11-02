import gleam/string
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

pub type Mut0 { Mut0(l0 : String) }
pub fn format_real_1(v0: Int) -> String {
    let v1 = ""
    let v2 = spiral_ref_new(Mut0(l0: v1))
    let v3 = string.inspect(v0)
    let v4 = spiral_ref_get(v2).l0
    let v5 = v4 <> v3 
    spiral_ref_set(v2, Mut0(l0: v5))
    let v6 = spiral_ref_get(v2).l0
    v6
}
pub fn method0() -> String {
    let v0 = "Some"
    let v1 = "("
    let v2 = v0 <> v1 
    let v3 = 1
    let v4 = format_real_1(v3)
    let v5 = v2 <> v4 
    let v6 = ")"
    let v7 = v5 <> v6 
    v7
}
pub fn main() {
    let v0 = method0()
    let v1 = "x: "
    let v2 = v1 <> v0 
    let v3 = v2 == ""
    case v3 {
        True -> 1
        False -> 0
    }
}
