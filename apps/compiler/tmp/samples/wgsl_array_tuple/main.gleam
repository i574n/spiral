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

pub fn spiral_array_create_filled(size: Int, value: a) -> SpiralArray(a) {
  list.repeat(option.Some(value), size) |> array.from_list(option.None) |> spiral_array_from_storage(size)
}

pub fn spiral_array_from_list(values: List(a)) -> SpiralArray(a) {
  values |> list.map(option.Some) |> array.from_list(option.None) |> spiral_array_from_storage(list.length(values))
}

pub fn spiral_array_to_list(xs: SpiralArray(a)) -> List(a) {
  list.repeat(Nil, xs.size) |> list.index_map(fn(_, i) { spiral_array_get(xs, i) })
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

pub fn main() {
let v0 = 3
let v1 = spiral_array_create(v0)
let v2 = 4
spiral_array_set(v1, 0, #(v2, True))
spiral_array_set(v1, 1, #(7, False))
spiral_array_set(v1, 2, #(9, True))
let #(v3, v4) = spiral_array_get(v1, 0)
let #(v5, v6) = spiral_array_get(v1, 1)
let v7 = 2
let #(v8, v9) = spiral_array_get(v1, v7)
let v10 =
    case v4 {
        True -> {
            1
        }
        False -> {
            0
        }
    }
let v11 =
    case v6 {
        True -> {
            10
        }
        False -> {
            0
        }
    }
let v12 =
    case v9 {
        True -> {
            100
        }
        False -> {
            0
        }
    }
let v13 = spiral_wrap_signed(v3 + v5, 32)
let v14 = spiral_wrap_signed(v13 + v8, 32)
let v15 = spiral_wrap_signed(v14 + v10, 32)
let v16 = spiral_wrap_signed(v15 + v11, 32)
let v17 = spiral_wrap_signed(v16 + v12, 32)
v17
}
