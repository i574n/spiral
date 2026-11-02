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
    let v0 = 1
    let v1 = "no"
    let v2 = Heap0(l0: v0, l1: v1)
    let v3 = 2
    let v4 = "zz"
    let v5 = Heap0(l0: v3, l1: v4)
    let v6 = 3
    let v7 = "aa"
    let v8 = Heap0(l0: v6, l1: v7)
    let v9 = spiral_ref_new(Mut0(l0: v2, l1: v5, l2: v8))
    let v10 = 7
    let v11 = "hi"
    let v12 = Heap0(l0: v10, l1: v11)
    let v13 = 4
    let v14 = "yo"
    let v15 = Heap0(l0: v13, l1: v14)
    let v16 = 9
    let v17 = "ok"
    let v18 = Heap0(l0: v16, l1: v17)
    spiral_ref_set(v9, Mut0(l0: v12, l1: v15, l2: v18))
    let #(v19, v20, v21) = #(spiral_ref_get(v9).l0, spiral_ref_get(v9).l1, spiral_ref_get(v9).l2)
    let #(v22, v23) = #(v19.l0, v19.l1)
    let #(v24, v25) = #(v20.l0, v20.l1)
    let #(v26, v27) = #(v21.l0, v21.l1)
    let v28 = v22 == 7
    let v30 =
        case v28 {
            True -> {
                let v29 = v23 == "hi"
                v29
            }
            False -> False
        }
    let v32 =
        case v30 {
            True -> {
                let v31 = v24 == 4
                v31
            }
            False -> False
        }
    let v34 =
        case v32 {
            True -> {
                let v33 = v25 == "yo"
                v33
            }
            False -> False
        }
    let v36 =
        case v34 {
            True -> {
                let v35 = v26 == 9
                v35
            }
            False -> False
        }
    let v38 =
        case v36 {
            True -> {
                let v37 = v27 == "ok"
                v37
            }
            False -> False
        }
    case v38 {
        True -> 0
        False -> 1
    }
}
