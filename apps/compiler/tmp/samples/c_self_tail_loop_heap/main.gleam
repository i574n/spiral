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


pub fn loop_0(v0: Int, v1: SpiralArray(Int), v2: Int, v3: Int, v4: Int) -> Int {
    let v5 = v3 >= v0
    case v5 {
        True -> v4
        False -> {
            let v6 = v3 % 4
            let v7 = spiral_array_get(v1, v6)
            let v8 = spiral_wrap_signed(v3 + 1, 32)
            let v9 = spiral_wrap_signed(v4 * 7, 32)
            let v10 = spiral_wrap_signed(v9 + v7, 32)
            let v11 = spiral_wrap_signed(v10 + v2, 32)
            let v12 = v11 % 9973
            loop_0(v0, v1, v2, v8, v12)
        }
    }
}
pub fn main() {
    let v0 = spiral_array_create_filled(4, 0)
    spiral_array_set(v0, 0, 1)
    spiral_array_set(v0, 1, 2)
    spiral_array_set(v0, 2, 3)
    spiral_array_set(v0, 3, 4)
    let v1 = 0
    let v2 = 1000000
    let v3 = 0
    let v4 = 0
    let v5 = loop_0(v2, v0, v1, v3, v4)
    let v6 = v5 % 256
    v6
}
