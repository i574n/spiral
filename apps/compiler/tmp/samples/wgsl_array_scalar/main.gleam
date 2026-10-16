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
let v0 = 5
let v1 = spiral_array_create(v0)
spiral_array_set(v1, 0, 0)
spiral_array_set(v1, 1, 1)
spiral_array_set(v1, 2, 4)
let v2 = 3
spiral_array_set(v1, v2, 9)
let v3 = spiral_wrap_signed(v2 + 1, 32)
spiral_array_set(v1, v3, 16)
let v4 = spiral_array_create(3)
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
                True -> {
                    0
                }
                False -> {
                    100
                }
            }
        }
        False -> {
            0
        }
    }
let v16 = spiral_wrap_signed(v11 + v15, 32)
let v17 = v1.size
let v18 = spiral_wrap_signed(v16 + v17, 32)
v18
}
