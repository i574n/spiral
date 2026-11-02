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


pub fn main() {
    let v0 = 5
    let v1 = spiral_array_create_filled(v0, 0)
    spiral_array_set(v1, 0, 0)
    spiral_array_set(v1, 1, 1)
    spiral_array_set(v1, 2, 4)
    let v2 = 3
    spiral_array_set(v1, v2, 9)
    let v3 = spiral_wrap_signed(v2 + 1, 32)
    spiral_array_set(v1, v3, 16)
    let v4 = spiral_array_create_filled(3, False)
    spiral_array_set(v4, 0, False)
    spiral_array_set(v4, 1, True)
    spiral_array_set(v4, 2, False)
    let v5 = spiral_array_get(v1, 1)
    let v6 = spiral_array_get(v1, 2)
    let v7 = spiral_wrap_signed(v5 + v6, 32)
    let v8 = spiral_array_get(v1, 3)
    let v9 = spiral_wrap_signed(v7 + v8, 32)
    let v10 = spiral_array_get(v1, 4)
    let v11 = spiral_wrap_signed(v9 + v10, 32)
    let v12 = spiral_array_get(v4, 1)
    let v15 =
        case v12 {
            True -> {
                let v13 = spiral_array_get(v4, 0)
                case v13 {
                    True -> 0
                    False -> 100
                }
            }
            False -> 0
        }
    let v16 = spiral_wrap_signed(v11 + v15, 32)
    let v17 = v1.size
    let v18 = spiral_wrap_signed(v16 + v17, 32)
    v18
}
