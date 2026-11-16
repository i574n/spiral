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
    Us0Circle(f0i0 : Float)
    Us0Square(f1i0 : Float)
    Us0Dot
}
pub fn main() {
    let v1 = Us0Circle(1.5)
    let v3 = Us0Square(2.5)
    let v8 = "Circle"
    let v9 = "Square"
    let v10 = "Dot"
    let v11 = spiral_array_from_list([ v8, v9, v10 ])
    let v12 = case v1 { Us0Circle(..) -> 0 Us0Square(..) -> 1 Us0Dot -> 2 }
    let v13 = spiral_array_get(v11, v12)
    let v14 = v13 == "Circle"
    let v19 =
        case v14 {
            True -> {
                let v15 = spiral_array_from_list([ v8, v9, v10 ])
                let v16 = case v3 { Us0Circle(..) -> 0 Us0Square(..) -> 1 Us0Dot -> 2 }
                let v17 = spiral_array_get(v15, v16)
                v17 == "Square"
            }
            False -> False
        }
    let v24 =
        case v19 {
            True -> {
                let v20 = spiral_array_from_list([ v8, v9, v10 ])
                let v21 = case Us0Dot { Us0Circle(..) -> 0 Us0Square(..) -> 1 Us0Dot -> 2 }
                let v22 = spiral_array_get(v20, v21)
                v22 == "Dot"
            }
            False -> False
        }
    case v24 {
        True -> 42
        False -> 1
    }
}
