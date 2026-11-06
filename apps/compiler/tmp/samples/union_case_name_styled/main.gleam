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
    Us0DeepBlue
    Us0LightGreen(f1i0 : Float)
    Us0Red
}
pub fn main() {
    let v1 = Us0LightGreen(0.5)
    let v4 = "deep_blue"
    let v5 = "light_green"
    let v6 = "red"
    let v7 = spiral_array_from_list([ v4, v5, v6 ])
    let v8 = case v1 { Us0DeepBlue -> 0 Us0LightGreen(..) -> 1 Us0Red -> 2 }
    let v9 = spiral_array_get(v7, v8)
    let v10 = v9 == "light_green"
    let v17 =
        case v10 {
            True -> {
                let v13 = spiral_array_from_list([ "deep-blue", "light-green", v6 ])
                let v14 = case Us0DeepBlue { Us0DeepBlue -> 0 Us0LightGreen(..) -> 1 Us0Red -> 2 }
                let v15 = spiral_array_get(v13, v14)
                v15 == "deep-blue"
            }
            False -> False
        }
    let v23 =
        case v17 {
            True -> {
                let v20 = spiral_array_from_list([ "deepblue", "lightgreen", v6 ])
                let v21 = spiral_array_get(v20, v8)
                v21 == "lightgreen"
            }
            False -> False
        }
    let v28 =
        case v23 {
            True -> {
                let v24 = spiral_array_from_list([ v4, v5, v6 ])
                let v25 = case Us0Red { Us0DeepBlue -> 0 Us0LightGreen(..) -> 1 Us0Red -> 2 }
                let v26 = spiral_array_get(v24, v25)
                v26 == "red"
            }
            False -> False
        }
    let v35 =
        case v28 {
            True -> {
                let v32 = spiral_array_from_list([ "DeepBlue", "LightGreen", "Red" ])
                let v33 = spiral_array_get(v32, v8)
                v33 == "LightGreen"
            }
            False -> False
        }
    case v35 {
        True -> 42
        False -> 1
    }
}
