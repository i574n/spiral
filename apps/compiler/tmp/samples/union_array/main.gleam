import gleam/list
import gleam/option
pub type SpiralArrayStore(a)

pub type SpiralArray(a) {
  SpiralArray(store: SpiralArrayStore(option.Option(a)), size: Int)
}

@external(erlang, "main_ffi", "array_new")
@external(javascript, "./main_ffi.mjs", "array_new")
pub fn spiral_array_store_new(size: Int, fill: a) -> SpiralArrayStore(a)

@external(erlang, "main_ffi", "array_get")
@external(javascript, "./main_ffi.mjs", "array_get")
pub fn spiral_array_store_get(store: SpiralArrayStore(a), i: Int) -> a

@external(erlang, "main_ffi", "array_set")
@external(javascript, "./main_ffi.mjs", "array_set")
pub fn spiral_array_store_set(store: SpiralArrayStore(a), i: Int, value: a) -> Nil


pub fn spiral_array_create_filled(size: Int, value: a) -> SpiralArray(a) {
  SpiralArray(store: spiral_array_store_new(size, option.Some(value)), size: size)
}



pub fn spiral_array_get(xs: SpiralArray(a), i: Int) -> a {
  case i >= 0 && i < xs.size {
    True ->
      case spiral_array_store_get(xs.store, i) {
        option.Some(x) -> x
        option.None -> panic as "spiral array: read of an element that was never set"
      }
    False -> panic as "spiral array: index out of bounds"
  }
}

pub fn spiral_array_set(xs: SpiralArray(a), i: Int, value: a) -> Nil {
  case i >= 0 && i < xs.size {
    True -> spiral_array_store_set(xs.store, i, option.Some(value))
    False -> panic as "spiral array: index out of bounds"
  }
}

pub type Us0 {
    Us0Missing
    Us0Held(f1i0 : SpiralArray(Int))
}
pub fn main() {
    let v1 = spiral_array_create_filled(2, 0)
    spiral_array_set(v1, 0, 7)
    let v6 =
        case True {
            True -> Us0Held(v1)
            False -> Us0Missing
        }
    case v6  {
        Us0Held(v7) -> {
            let v8 = spiral_array_get(v7, 0)
            let v9 = v8 == 7
            case v9 {
                True -> 0
                False -> 1
            }
        }
        Us0Missing -> 1
    }
}
