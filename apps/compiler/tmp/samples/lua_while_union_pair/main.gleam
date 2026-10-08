import gary
import gary/array
import gleam/list
import gleam/option
import gleam/int
pub type SpiralArrayKey

pub type SpiralArray(a) {
  SpiralArray(key: SpiralArrayKey, size: Int)
}

@external(erlang, "erlang", "make_ref")
pub fn spiral_array_new_key() -> SpiralArrayKey

@external(erlang, "erlang", "put")
pub fn spiral_array_store(key: SpiralArrayKey, storage: gary.ErlangArray(option.Option(a))) -> b

@external(erlang, "erlang", "get")
pub fn spiral_array_load(key: SpiralArrayKey) -> gary.ErlangArray(option.Option(a))

pub fn spiral_array_from_storage(storage: gary.ErlangArray(option.Option(a)), size: Int) -> SpiralArray(a) {
  let key = spiral_array_new_key()
  let _ = spiral_array_store(key, storage)
  SpiralArray(key: key, size: size)
}

pub fn spiral_array_create(size: Int) -> SpiralArray(a) {
  list.repeat(option.None, size) |> array.from_list(option.None) |> spiral_array_from_storage(size)
}

pub fn spiral_array_from_list(values: List(a)) -> SpiralArray(a) {
  values |> list.map(option.Some) |> array.from_list(option.None) |> spiral_array_from_storage(list.length(values))
}

pub fn spiral_array_get(xs: SpiralArray(a), i: Int) -> a {
  case i >= 0 && i < xs.size {
    True ->
      case spiral_array_load(xs.key) |> array.get(i) {
        Ok(option.Some(x)) -> x
        _ -> panic as "spiral array: read of an element that was never set"
      }
    False -> panic as "spiral array: index out of bounds"
  }
}

pub fn spiral_array_set(xs: SpiralArray(a), i: Int, value: a) -> Nil {
  case i >= 0 && i < xs.size {
    True -> {
      let assert Ok(storage) = spiral_array_load(xs.key) |> array.set(i, option.Some(value))
      let _ = spiral_array_store(xs.key, storage)
      Nil
    }
    False -> panic as "spiral array: index out of bounds"
  }
}

pub type SpiralRef(a) {
  SpiralRef(key: SpiralArrayKey)
}

@external(erlang, "erlang", "put")
pub fn spiral_ref_store(key: SpiralArrayKey, value: a) -> b

@external(erlang, "erlang", "get")
pub fn spiral_ref_load(key: SpiralArrayKey) -> a

pub fn spiral_ref_new(value: a) -> SpiralRef(a) {
  let key = spiral_array_new_key()
  let _ = spiral_ref_store(key, value)
  SpiralRef(key: key)
}

pub fn spiral_ref_get(reference: SpiralRef(a)) -> a {
  spiral_ref_load(reference.key)
}

pub fn spiral_ref_set(reference: SpiralRef(a), value: a) -> Nil {
  let _ = spiral_ref_store(reference.key, value)
  Nil
}

pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn spiral_int_power(base: Int, exponent: Int) -> Int {
  case exponent <= 0 {
    True -> 1
    False -> base * spiral_int_power(base, exponent - 1)
  }
}

@external(erlang, "math", "pow")
pub fn spiral_math_pow(base: Float, exponent: Float) -> Float

pub type Mut0 { Mut0(l0 : Int) }
pub type Mut1 { Mut1(l0 : Int) }
pub type Uh0 {
    Uh0i0
    Uh0i1(Int, Uh0)
}
pub type Mut2 { Mut2(l0 : Uh0) }
pub fn method0(v0: SpiralRef(Mut0)) -> Bool {
    let v1 = spiral_ref_get(v0).l0
    let v2 = v1 < 3
    v2
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
    let v2 = v1 < 4
    v2
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
                False -> {
                Nil
                }
            }
            let v16 = spiral_ref_get(v9).l0
            let v17 = Uh0i1(v11, v16)
            spiral_ref_set(v9, Mut2(l0: v17))
            let v18 = spiral_wrap_signed(v11 + 1, 32)
            spiral_ref_set(v6, Mut1(l0: v18))
            loop1(v6, v7, v9)
        }
        False -> #(v6, v7, v9)
    }
}
pub fn main() {
let v0 = spiral_array_create(3)
let v1 = spiral_ref_new(Mut0(l0: 0))
let #(v0, v1) = loop0(v0, v1)
let v6 = spiral_ref_new(Mut1(l0: 0))
let v7 = spiral_ref_new(Mut1(l0: 0))
let v8 = Uh0i0
let v9 = spiral_ref_new(Mut2(l0: v8))
let #(v6, v7, v9) = loop1(v6, v7, v9)
let v19 = spiral_ref_get(v9).l0
let v38 =
    case v19  {
        Uh0i1(v20, v21) -> {
            case v21  {
                Uh0i1(v22, v23) -> {
                    case v23  {
                        Uh0i1(v24, v25) -> {
                            case v25  {
                                Uh0i1(v26, v27) -> {
                                    case v27  {
                                        Uh0i0 -> {
                                            let v28 = spiral_wrap_signed(v20 * 64, 32)
                                            let v29 = spiral_wrap_signed(v22 * 16, 32)
                                            let v30 = spiral_wrap_signed(v28 + v29, 32)
                                            let v31 = spiral_wrap_signed(v24 * 4, 32)
                                            let v32 = spiral_wrap_signed(v30 + v31, 32)
                                            let v33 = spiral_wrap_signed(v32 + v26, 32)
                                            v33
                                        }
                                        _ -> {
                                            -1
                                        }
                                    }
                                }
                                _ -> {
                                    -1
                                }
                            }
                        }
                        _ -> {
                            -1
                        }
                    }
                }
                _ -> {
                    -1
                }
            }
        }
        _ -> {
            -1
        }
    }
let v39 = spiral_ref_get(v7).l0
let v40 = spiral_wrap_signed(v38 + v39, 32)
let v41 = spiral_array_get(v0, 2)
let v42 = spiral_wrap_signed(v40 + v41, 32)
let v43 = spiral_array_get(v0, 1)
let v44 = spiral_wrap_signed(v42 - v43, 32)
v44
}
