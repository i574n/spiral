import gleam/list
import gleam/option
import gleam/int
import gleam/bit_array
import gleam/string
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

pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn spiral_string_length(text: String) -> Int {
  bit_array.byte_size(bit_array.from_string(text))
}

pub type Us0 {
    Us0Empty
    Us0Item(f1i0 : String, f1i1 : SpiralArray(Int))
}
pub fn closure0(capt: Nil) -> fn(Int) -> Us0 {
    fn (v0) {
        let v1 = v0 == 0
        case v1 {
            True -> Us0Empty
            False -> {
                let v3 = spiral_array_create_filled(2, 0)
                spiral_array_set(v3, 0, v0)
                let v4 = spiral_wrap_signed(v0 + 1, 32)
                spiral_array_set(v3, 1, v4)
                let v5 = "hi"
                Us0Item(v5, v3)
            }
        }
    }
}
pub fn method0(v0: fn(Int) -> Us0) -> Us0 {
    v0(0)
}
pub fn method1(v0: fn(Int) -> Us0) -> Us0 {
    v0(4)
}
pub fn main() {
    let v0 = closure0(Nil)
    let v1 = method0(v0)
    let v12 =
        case v1  {
            Us0Empty -> 3
            Us0Item(v2, v3) -> {
                let v4 = spiral_string_length(v2)
                let v5 = v3.size
                let v6 = spiral_wrap_signed(v4 + v5, 32)
                let v7 = spiral_array_get(v3, 0)
                let v8 = spiral_wrap_signed(v6 + v7, 32)
                let v9 = spiral_array_get(v3, 1)
                let v10 = spiral_wrap_signed(v8 + v9, 32)
                v10
            }
        }
    let v13 = method1(v0)
    let v24 =
        case v13  {
            Us0Empty -> 3
            Us0Item(v14, v15) -> {
                let v16 = spiral_string_length(v14)
                let v17 = v15.size
                let v18 = spiral_wrap_signed(v16 + v17, 32)
                let v19 = spiral_array_get(v15, 0)
                let v20 = spiral_wrap_signed(v18 + v19, 32)
                let v21 = spiral_array_get(v15, 1)
                let v22 = spiral_wrap_signed(v20 + v21, 32)
                v22
            }
        }
    let v25 = spiral_wrap_signed(v12 + v24, 32)
    let v26 = spiral_wrap_signed(v25 + 26, 32)
    v26
}
