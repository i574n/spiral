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

pub fn loop_0(v0: Int, v1: SpiralArray(Int), v2: Int, v3: Int, v4: Int) -> Int {
    let v5 = v3 >= v0
    case v5 {
        True -> {
            v4
        }
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
let v0 = spiral_array_create(4)
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
