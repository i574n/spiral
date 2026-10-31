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
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap0, f1i1 : Heap0)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Held(v1, v2) -> {
            let #(v3, v4) = #(v1.l0, v1.l1)
            let #(v5, v6) = #(v2.l0, v2.l1)
            let v7 = v3 == 7
            let v9 =
                case v7 {
                    True -> {
                        let v8 = v4 == "hi"
                        v8
                    }
                    False -> False
                }
            let v11 =
                case v9 {
                    True -> {
                        let v10 = v5 == 4
                        v10
                    }
                    False -> False
                }
            let v13 =
                case v11 {
                    True -> {
                        let v12 = v6 == "yo"
                        v12
                    }
                    False -> False
                }
            case v13 {
                True -> 0
                False -> 1
            }
        }
        Us0None -> 1
    }
}
pub fn main() {
    let v0 = 7
    let v1 = "hi"
    let v2 = Heap0(l0: v0, l1: v1)
    let v3 = 4
    let v4 = "yo"
    let v5 = Heap0(l0: v3, l1: v4)
    let v6 = spiral_array_create(1)
    let v7 = True
    let v10 =
        case v7 {
            True -> Us0Held(v2, v5)
            False -> Us0None
        }
    spiral_array_set(v6, 0, v10)
    let v11 = spiral_array_get(v6, 0)
    score_0(v11)
}
