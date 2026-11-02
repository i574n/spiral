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

pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn method0(v0: SpiralArray(Int)) -> Nil {
    let v1 = 1
    let v2 = 9
    spiral_array_set(v0, v1, v2)
    Nil
}
pub fn method1(v0: SpiralArray(Int)) -> Int {
    let v1 = 0
    let v2 = spiral_array_get(v0, v1)
    v2
}
pub fn method2(v0: SpiralArray(Int)) -> Int {
    let v1 = 1
    let v2 = spiral_array_get(v0, v1)
    v2
}
pub fn main() {
    let v0 = 2
    let v1 = spiral_array_create_filled(v0, 0)
    spiral_array_set(v1, 0, 1)
    spiral_array_set(v1, 1, 2)
    method0(v1)
    let v2 = method1(v1)
    let v3 = method2(v1)
    let v4 = spiral_wrap_signed(v2 + v3, 32)
    let v5 = spiral_wrap_signed(v4 - 10, 32)
    v5
}
