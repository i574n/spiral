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
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub type Mut0 { Mut0(l0 : Heap2) }
pub fn main() {
let v0 = 1
let v1 = "no"
let v2 = Heap0(l0: v0, l1: v1)
let v3 = 2
let v4 = "zz"
let v5 = Heap0(l0: v3, l1: v4)
let v6 = Heap1(l0: v2, l1: v5)
let v7 = 3
let v8 = Heap2(l0: v6, l1: v7)
let v9 = spiral_ref_new(Mut0(l0: v8))
let v10 = spiral_array_create(1)
spiral_array_set(v10, 0, v9)
let v11 = 7
let v12 = "hi"
let v13 = Heap0(l0: v11, l1: v12)
let v14 = 4
let v15 = "yo"
let v16 = Heap0(l0: v14, l1: v15)
let v17 = Heap1(l0: v13, l1: v16)
let v18 = 2
let v19 = Heap2(l0: v17, l1: v18)
let v20 = spiral_array_get(v10, 0)
spiral_ref_set(v20, Mut0(l0: v19))
let v21 = spiral_ref_get(v20).l0
let #(v22, v23) = #(v21.l0, v21.l1)
let #(v24, v25) = #(v22.l0, v22.l1)
let #(v26, v27) = #(v24.l0, v24.l1)
let #(v28, v29) = #(v25.l0, v25.l1)
let v30 = v26 == 7
let v32 =
    case v30 {
        True -> {
            let v31 = v27 == "hi"
            v31
        }
        False -> {
            False
        }
    }
let v34 =
    case v32 {
        True -> {
            let v33 = v28 == 4
            v33
        }
        False -> {
            False
        }
    }
let v36 =
    case v34 {
        True -> {
            let v35 = v29 == "yo"
            v35
        }
        False -> {
            False
        }
    }
let v38 =
    case v36 {
        True -> {
            let v37 = v23 == 2
            v37
        }
        False -> {
            False
        }
    }
case v38 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
