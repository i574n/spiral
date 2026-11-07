import gleam/list
import gleam/option
import gleam/int
pub type SpiralArrayStore(a)

pub type SpiralArray(a) {
  SpiralArray(store: SpiralArrayStore(option.Option(a)), size: Int)
}

@external(erlang, "main_ffi", "array_new")
@external(javascript, "./main_ffi.mjs", "array_new")
pub fn spiral_array_store_new(size: Int, fill: a) -> SpiralArrayStore(a)

@external(erlang, "main_ffi", "array_get")
@external(javascript, "./main_ffi.mjs", "array_get")
pub fn spiral_array_store_get(store: SpiralArrayStore(a), i: Int) -> a

@external(erlang, "main_ffi", "array_set")
@external(javascript, "./main_ffi.mjs", "array_set")
pub fn spiral_array_store_set(store: SpiralArrayStore(a), i: Int, value: a) -> Nil


pub fn spiral_array_create_filled(size: Int, value: a) -> SpiralArray(a) {
  SpiralArray(store: spiral_array_store_new(size, option.Some(value)), size: size)
}



pub fn spiral_array_get(xs: SpiralArray(a), i: Int) -> a {
  case i >= 0 && i < xs.size {
    True ->
      case spiral_array_store_get(xs.store, i) {
        option.Some(x) -> x
        option.None -> panic as "spiral array: read of an element that was never set"
      }
    False -> panic as "spiral array: index out of bounds"
  }
}

pub fn spiral_array_set(xs: SpiralArray(a), i: Int, value: a) -> Nil {
  case i >= 0 && i < xs.size {
    True -> spiral_array_store_set(xs.store, i, option.Some(value))
    False -> panic as "spiral array: index out of bounds"
  }
}

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
pub type Mut1 { Mut1(l0 : Int) }
pub type Uh0 {
    Uh0Nil
    Uh0Cons(Int, Uh0)
}
pub type Mut2 { Mut2(l0 : Uh0) }
pub fn method0(v0: SpiralRef(Mut0)) -> Bool {
    let v1 = spiral_ref_get(v0).l0
    v1 < 3
}
pub fn loop0 (v0: SpiralArray(Int), v1: SpiralRef(Mut0)) {
    case method0(v1) {
        True -> {
            let v3 = spiral_ref_get(v1).l0
            let v4 = spiral_wrap_signed(v3 * 5, 32)
            spiral_array_set(v0, v3, v4)
            let v5 = spiral_wrap_signed(v3 + 1, 32)
            spiral_ref_set(v1, Mut0(l0: v5))
            loop0(v0, v1)
        }
        False -> #(v0, v1)
    }
}
pub fn method1(v0: SpiralRef(Mut1)) -> Bool {
    let v1 = spiral_ref_get(v0).l0
    v1 < 4
}
pub fn loop1 (v6: SpiralRef(Mut1), v7: SpiralRef(Mut1), v9: SpiralRef(Mut2)) {
    case method1(v6) {
        True -> {
            let v11 = spiral_ref_get(v6).l0
            let v12 = v11 % 2
            let v13 = v12 == 1
            case v13 {
                True -> {
                    let v14 = spiral_ref_get(v7).l0
                    let v15 = spiral_wrap_signed(v14 + 1, 32)
                    spiral_ref_set(v7, Mut1(l0: v15))
                    Nil
                }
                False -> Nil
            }
            let v16 = spiral_ref_get(v9).l0
            let v17 = Uh0Cons(v11, v16)
            spiral_ref_set(v9, Mut2(l0: v17))
            let v18 = spiral_wrap_signed(v11 + 1, 32)
            spiral_ref_set(v6, Mut1(l0: v18))
            loop1(v6, v7, v9)
        }
        False -> #(v6, v7, v9)
    }
}
pub fn main() {
    let v0 = spiral_array_create_filled(3, 0)
    let v1 = spiral_ref_new(Mut0(l0: 0))
    let #(v0, v1) = loop0(v0, v1)
    let v6 = spiral_ref_new(Mut1(l0: 0))
    let v7 = spiral_ref_new(Mut1(l0: 0))
    let v9 = spiral_ref_new(Mut2(l0: Uh0Nil))
    let #(v6, v7, v9) = loop1(v6, v7, v9)
    let v19 = spiral_ref_get(v9).l0
    let v38 =
        case v19  {
            Uh0Cons(v20, v21) -> {
                case v21  {
                    Uh0Cons(v22, v23) -> {
                        case v23  {
                            Uh0Cons(v24, v25) -> {
                                case v25  {
                                    Uh0Cons(v26, v27) -> {
                                        case v27  {
                                            Uh0Nil -> {
                                                let v28 = spiral_wrap_signed(v20 * 64, 32)
                                                let v29 = spiral_wrap_signed(v22 * 16, 32)
                                                let v30 = spiral_wrap_signed(v28 + v29, 32)
                                                let v31 = spiral_wrap_signed(v24 * 4, 32)
                                                let v32 = spiral_wrap_signed(v30 + v31, 32)
                                                spiral_wrap_signed(v32 + v26, 32)
                                            }
                                            _ -> -1
                                        }
                                    }
                                    _ -> -1
                                }
                            }
                            _ -> -1
                        }
                    }
                    _ -> -1
                }
            }
            _ -> -1
        }
    let v39 = spiral_ref_get(v7).l0
    let v40 = spiral_wrap_signed(v38 + v39, 32)
    let v41 = spiral_array_get(v0, 2)
    let v42 = spiral_wrap_signed(v40 + v41, 32)
    let v43 = spiral_array_get(v0, 1)
    spiral_wrap_signed(v42 - v43, 32)
}
