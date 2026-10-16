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

pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Int) }
pub type Mut0 { Mut0(l0 : Heap1) }
pub fn main() {
let v0 = 3
let v1 = "no"
let v2 = Heap0(l0: v0, l1: v1)
let v3 = 1
let v4 = Heap1(l0: v2, l1: v3)
let v5 = spiral_ref_new(Mut0(l0: v4))
let v6 = 7
let v7 = "hi"
let v8 = Heap0(l0: v6, l1: v7)
let v9 = 4
let v10 = Heap1(l0: v8, l1: v9)
spiral_ref_set(v5, Mut0(l0: v10))
let v11 = spiral_ref_get(v5).l0
let #(v12, v13) = #(v11.l0, v11.l1)
let #(v14, v15) = #(v12.l0, v12.l1)
let v16 = v14 == 7
let v18 =
    case v16 {
        True -> {
            let v17 = v15 == "hi"
            v17
        }
        False -> {
            False
        }
    }
let v20 =
    case v18 {
        True -> {
            let v19 = v13 == 4
            v19
        }
        False -> {
            False
        }
    }
case v20 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
