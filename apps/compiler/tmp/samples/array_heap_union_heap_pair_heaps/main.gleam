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

pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap2)
}
pub type Heap3 { Heap3(l0 : Us0) }
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Held(v1) -> {
            let #(v2, v3) = #(v1.l0, v1.l1)
            let #(v4, v5) = #(v2.l0, v2.l1)
            let #(v6, v7) = #(v4.l0, v4.l1)
            let #(v8, v9) = #(v5.l0, v5.l1)
            let v10 = v6 == 7
            let v12 =
                case v10 {
                    True -> {
                        let v11 = v7 == "hi"
                        v11
                    }
                    False -> {
                        False
                    }
                }
            let v14 =
                case v12 {
                    True -> {
                        let v13 = v8 == 4
                        v13
                    }
                    False -> {
                        False
                    }
                }
            let v16 =
                case v14 {
                    True -> {
                        let v15 = v9 == "yo"
                        v15
                    }
                    False -> {
                        False
                    }
                }
            let v18 =
                case v16 {
                    True -> {
                        let v17 = v3 == 2
                        v17
                    }
                    False -> {
                        False
                    }
                }
            case v18 {
                True -> {
                    0
                }
                False -> {
                    1
                }
            }
        }
        Us0None -> {
            1
        }
    }
}
pub fn main() {
let v0 = 7
let v1 = "hi"
let v2 = Heap0(l0: v0, l1: v1)
let v3 = 4
let v4 = "yo"
let v5 = Heap0(l0: v3, l1: v4)
let v6 = Heap1(l0: v2, l1: v5)
let v7 = 2
let v8 = Heap2(l0: v6, l1: v7)
let v9 = True
let v12 =
    case v9 {
        True -> {
            Us0Held(v8)
        }
        False -> {
            Us0None
        }
    }
let v13 = Heap3(l0: v12)
let v14 = spiral_array_create(1)
spiral_array_set(v14, 0, v13)
let v15 = spiral_array_get(v14, 0)
let v16 = v15.l0
score_0(v16)
}
