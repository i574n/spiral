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

pub fn method1(v0: Int, v1: SpiralArray(Int), v2: SpiralArray(Int)) -> SpiralArray(Int) {
    let v3 = spiral_wrap_signed(v0 - 1, 32)
    let v4 = v3 == 0
    case v4 {
        True -> {
            v2
        }
        False -> {
            method1(v3, v2, v1)
        }
    }
}
pub fn method0(v0: SpiralArray(Int), v1: SpiralArray(Int)) -> SpiralArray(Int) {
    let v2 = 1000000
    let v3 = v2 == 0
    case v3 {
        True -> {
            v0
        }
        False -> {
            method1(v2, v0, v1)
        }
    }
}
pub fn main() {
let v0 = 1
let v1 = spiral_array_create(v0)
let v2 = spiral_array_create(v0)
spiral_array_set(v1, 0, 7)
spiral_array_set(v2, 0, 11)
let v3 = method0(v1, v2)
spiral_array_set(v3, 0, 13)
let v4 = spiral_array_get(v1, 0)
let v5 = v4 == 13
case v5 {
    True -> {
        let v6 = spiral_array_get(v2, 0)
        let v7 = v6 == 11
        case v7 {
            True -> {
                0
            }
            False -> {
                2
            }
        }
    }
    False -> {
        1
    }
}
}
