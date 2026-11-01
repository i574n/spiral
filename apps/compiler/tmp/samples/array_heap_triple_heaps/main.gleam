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

pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0, l2 : Heap0) }
pub fn main() {
    let v0 = 7
    let v1 = "hi"
    let v2 = Heap0(l0: v0, l1: v1)
    let v3 = 4
    let v4 = "yo"
    let v5 = Heap0(l0: v3, l1: v4)
    let v6 = 9
    let v7 = "ok"
    let v8 = Heap0(l0: v6, l1: v7)
    let v9 = Heap1(l0: v2, l1: v5, l2: v8)
    let v10 = spiral_array_create(1)
    spiral_array_set(v10, 0, v9)
    let v11 = spiral_array_get(v10, 0)
    let #(v12, v13, v14) = #(v11.l0, v11.l1, v11.l2)
    let #(v15, v16) = #(v12.l0, v12.l1)
    let #(v17, v18) = #(v13.l0, v13.l1)
    let #(v19, v20) = #(v14.l0, v14.l1)
    let v21 = v15 == 7
    let v23 =
        case v21 {
            True -> {
                let v22 = v16 == "hi"
                v22
            }
            False -> False
        }
    let v25 =
        case v23 {
            True -> {
                let v24 = v17 == 4
                v24
            }
            False -> False
        }
    let v27 =
        case v25 {
            True -> {
                let v26 = v18 == "yo"
                v26
            }
            False -> False
        }
    let v29 =
        case v27 {
            True -> {
                let v28 = v19 == 9
                v28
            }
            False -> False
        }
    let v31 =
        case v29 {
            True -> {
                let v30 = v20 == "ok"
                v30
            }
            False -> False
        }
    case v31 {
        True -> 0
        False -> 1
    }
}
