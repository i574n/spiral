import gary
import gary/array
import gleam/list
import gleam/option
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

pub type SpiralRef(a) {
  SpiralRef(key: SpiralArrayKey)
}

@external(erlang, "erlang", "put")
pub fn spiral_ref_store(key: SpiralArrayKey, value: a) -> b

@external(erlang, "erlang", "get")
pub fn spiral_ref_load(key: SpiralArrayKey) -> a

pub fn spiral_ref_new(value: a) -> SpiralRef(a) {
  let key = spiral_array_new_key()
  let _ = spiral_ref_store(key, value)
  SpiralRef(key: key)
}

pub fn spiral_ref_get(reference: SpiralRef(a)) -> a {
  spiral_ref_load(reference.key)
}

pub fn spiral_ref_set(reference: SpiralRef(a), value: a) -> Nil {
  let _ = spiral_ref_store(reference.key, value)
  Nil
}

pub type Mut0 { Mut0(l0 : Int, l1 : String) }
pub fn main() {
let v0 = 3
let v1 = "no"
let v2 = spiral_ref_new(Mut0(l0: v0, l1: v1))
let v3 = 7
let v4 = "hi"
spiral_ref_set(v2, Mut0(l0: v3, l1: v4))
let #(v5, v6) = #(spiral_ref_get(v2).l0, spiral_ref_get(v2).l1)
let v7 = v5 == 7
let v9 =
    case v7 {
        True -> {
            let v8 = v6 == "hi"
            v8
        }
        False -> {
            False
        }
    }
case v9 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
