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

pub fn spiral_array_create(size: Int) -> SpiralArray(a) {
  SpiralArray(store: spiral_array_store_new(size, option.None), size: size)
}


pub fn spiral_array_from_list(values: List(a)) -> SpiralArray(a) {
  let xs = spiral_array_create(list.length(values))
  let _ = list.index_map(values, fn(x, i) { spiral_array_set(xs, i, x) })
  xs
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
    Us0First
    Us0Second
}
pub fn main() {
    let v3 = ""
    let v4 = "First"
    let v5 = "Second"
    let v6 = spiral_array_from_list([ v3, v4, v5 ])
    let v7 = case Us0First { Us0First -> 1 Us0Second -> 2 }
    let v8 = spiral_array_get(v6, v7)
    let v9 = v8 == "First"
    let v14 =
        case v9 {
            True -> {
                let v10 = spiral_array_from_list([ v3, v4, v5 ])
                let v11 = case Us0Second { Us0First -> 1 Us0Second -> 2 }
                let v12 = spiral_array_get(v10, v11)
                v12 == "Second"
            }
            False -> False
        }
    case v14 {
        True -> 42
        False -> 1
    }
}
