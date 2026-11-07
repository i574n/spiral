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
pub fn closure1(capt: #(Us0)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v12 =
            case v0  {
                Us0Empty -> 3
                Us0Item(v2, v3) -> {
                    let v4 = spiral_string_length(v2)
                    let v5 = v3.size
                    let v6 = spiral_wrap_signed(v4 + v5, 32)
                    let v7 = spiral_array_get(v3, 0)
                    let v8 = spiral_wrap_signed(v6 + v7, 32)
                    let v9 = spiral_array_get(v3, 1)
                    spiral_wrap_signed(v8 + v9, 32)
                }
            }
        spiral_wrap_signed(v12 + v1, 32)
    }
}
pub fn closure0(capt: Nil) -> fn(Int) -> fn(Int) -> Int {
    fn (v0) {
        let v1 = spiral_array_create_filled(2, 0)
        spiral_array_set(v1, 0, v0)
        let v2 = spiral_wrap_signed(v0 + 1, 32)
        spiral_array_set(v1, 1, v2)
        let v3 = v0 == 0
        let v7 =
            case v3 {
                True -> Us0Empty
                False -> {
                    Us0Item("hi", v1)
                }
            }
        closure1(#(v7))
    }
}
pub fn method0(v0: fn(Int) -> fn(Int) -> Int) -> fn(Int) -> Int {
    v0(0)
}
pub fn method1(v0: fn(Int) -> fn(Int) -> Int) -> fn(Int) -> Int {
    v0(4)
}
pub fn method4(v0: fn(Int) -> Int) -> Int {
    let v1 = v0(2)
    spiral_wrap_signed(v1 + 5, 32)
}
pub fn method3(v0: fn(Int) -> Int) -> Int {
    let v1 = v0(1)
    let v2 = method4(v0)
    spiral_wrap_signed(v1 + v2, 32)
}
pub fn method2(v0: fn(Int) -> Int, v1: fn(Int) -> Int) -> Int {
    let v2 = v0(5)
    let v3 = method3(v1)
    spiral_wrap_signed(v2 + v3, 32)
}
pub fn main() {
    let v0 = closure0(Nil)
    let v1 = method0(v0)
    let v2 = method1(v0)
    method2(v1, v2)
}
