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
  case value >= 0 - half && value < half {
    True -> value
    False -> int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
  }
}

pub fn spiral_wrap_i32(value: Int) -> Int {
  case value >= -2147483648 && value <= 2147483647 {
    True -> value
    False -> spiral_wrap_signed(value, 32)
  }
}


pub type Us0 {
    Us0Empty
    Us0Values(f1i0 : SpiralArray(Int))
}
pub fn bump_0(v0: Us0) -> Int {
    case v0  {
        Us0Empty -> 0
        Us0Values(v1) -> {
            let v2 = spiral_array_get(v1, 0)
            let v3 = spiral_wrap_i32(v2 + 1)
            spiral_array_set(v1, 0, v3)
            0
        }
    }
}
pub fn score_1(v0: Us0) -> Int {
    case v0  {
        Us0Empty -> 0
        Us0Values(v1) -> {
            let v2 = v1.size
            let v3 = spiral_array_get(v1, 0)
            let v4 = spiral_wrap_i32(v2 + v3)
            let v5 = spiral_array_get(v1, 1)
            spiral_wrap_i32(v4 + v5)
        }
    }
}
pub fn main() {
    let v1 = spiral_array_create_filled(2, 0)
    spiral_array_set(v1, 0, 4)
    spiral_array_set(v1, 1, 5)
    let v2 = Us0Values(v1)
    let v3 = bump_0(v2)
    let v4 = Us0Values(v1)
    let v5 = score_1(v4)
    let v6 = spiral_wrap_i32(v5 + v3)
    spiral_wrap_i32(v6 - 12)
}
