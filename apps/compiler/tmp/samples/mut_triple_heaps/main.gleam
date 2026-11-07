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
pub type Mut0 { Mut0(l0 : Heap0, l1 : Heap0, l2 : Heap0) }
pub fn main() {
    let v2 = Heap0(l0: 1, l1: "no")
    let v5 = Heap0(l0: 2, l1: "zz")
    let v8 = Heap0(l0: 3, l1: "aa")
    let v9 = spiral_ref_new(Mut0(l0: v2, l1: v5, l2: v8))
    let v12 = Heap0(l0: 7, l1: "hi")
    let v15 = Heap0(l0: 4, l1: "yo")
    let v18 = Heap0(l0: 9, l1: "ok")
    spiral_ref_set(v9, Mut0(l0: v12, l1: v15, l2: v18))
    let #(v19, v20, v21) = #(spiral_ref_get(v9).l0, spiral_ref_get(v9).l1, spiral_ref_get(v9).l2)
    let #(v22, v23) = #(v19.l0, v19.l1)
    let #(v24, v25) = #(v20.l0, v20.l1)
    let #(v26, v27) = #(v21.l0, v21.l1)
    let v28 = v22 == 7
    let v30 =
        case v28 {
            True -> {
                v23 == "hi"
            }
            False -> False
        }
    let v32 =
        case v30 {
            True -> {
                v24 == 4
            }
            False -> False
        }
    let v34 =
        case v32 {
            True -> {
                v25 == "yo"
            }
            False -> False
        }
    let v36 =
        case v34 {
            True -> {
                v26 == 9
            }
            False -> False
        }
    let v38 =
        case v36 {
            True -> {
                v27 == "ok"
            }
            False -> False
        }
    case v38 {
        True -> 0
        False -> 1
    }
}
