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


pub fn spiral_array_create_filled(size: Int, value: a) -> SpiralArray(a) {
  list.repeat(option.Some(value), size) |> array.from_list(option.None) |> spiral_array_from_storage(size)
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

pub type Us0 {
    Us0None
    Us0Held(f1i0 : SpiralArray(String), f1i1 : Bool)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Held(v1, v2) -> {
            let v3 = spiral_array_get(v1, 0)
            let v4 = v3 == "hi"
            let v5 = v4 && v2
            case v5 {
                True -> 0
                False -> 1
            }
        }
        Us0None -> 1
    }
}
pub fn main() {
    let v0 = spiral_array_create_filled(1, "")
    let v1 = "hi"
    spiral_array_set(v0, 0, v1)
    let v2 = True
    let v5 =
        case v2 {
            True -> Us0Held(v0, v2)
            False -> Us0None
        }
    score_0(v5)
}
