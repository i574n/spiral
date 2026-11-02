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

pub type Heap0 { Heap0(l0 : SpiralArray(Float), l1 : Int) }
pub fn main() {
    let v0 = spiral_array_create_filled(1, 0.0)
    let v1 = 1.5
    spiral_array_set(v0, 0, v1)
    let v2 = 7
    let v3 = Heap0(l0: v0, l1: v2)
    let #(v4, v5) = #(v3.l0, v3.l1)
    let v6 = spiral_array_get(v4, 0)
    let v7 = v6 == 1.5
    let v9 =
        case v7 {
            True -> {
                let v8 = v5 == 7
                v8
            }
            False -> False
        }
    case v9 {
        True -> 0
        False -> 1
    }
}
