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
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
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
    let v9 = spiral_array_create(1)
    spiral_array_set(v9, 0, v8)
    let v10 = spiral_array_get(v9, 0)
    let #(v11, v12) = #(v10.l0, v10.l1)
    let #(v13, v14) = #(v11.l0, v11.l1)
    let #(v15, v16) = #(v13.l0, v13.l1)
    let #(v17, v18) = #(v14.l0, v14.l1)
    let v19 = v15 == 7
    let v21 =
        case v19 {
            True -> {
                let v20 = v16 == "hi"
                v20
            }
            False -> False
        }
    let v23 =
        case v21 {
            True -> {
                let v22 = v17 == 4
                v22
            }
            False -> False
        }
    let v25 =
        case v23 {
            True -> {
                let v24 = v18 == "yo"
                v24
            }
            False -> False
        }
    let v27 =
        case v25 {
            True -> {
                let v26 = v12 == 2
                v26
            }
            False -> False
        }
    case v27 {
        True -> 0
        False -> 1
    }
}
