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

pub fn spiral_array_create(size: Int) -> SpiralArray(a) {
  SpiralArray(store: spiral_array_store_new(size, option.None), size: size)
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


pub fn main() {
    let v1 = spiral_array_create(3)
    spiral_array_set(v1, 0, #(4, True))
    spiral_array_set(v1, 1, #(7, False))
    spiral_array_set(v1, 2, #(9, True))
    let #(v3, v4) = spiral_array_get(v1, 0)
    let #(v5, v6) = spiral_array_get(v1, 1)
    let #(v8, v9) = spiral_array_get(v1, 2)
    let v10 =
        case v4 {
            True -> 1
            False -> 0
        }
    let v11 =
        case v6 {
            True -> 10
            False -> 0
        }
    let v12 =
        case v9 {
            True -> 100
            False -> 0
        }
    let v13 = spiral_wrap_signed(v3 + v5, 32)
    let v14 = spiral_wrap_signed(v13 + v8, 32)
    let v15 = spiral_wrap_signed(v14 + v10, 32)
    let v16 = spiral_wrap_signed(v15 + v11, 32)
    spiral_wrap_signed(v16 + v12, 32)
}
