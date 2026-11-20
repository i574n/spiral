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
pub type Us0 {
    Us0None
    Us0Held(f1i0 : Heap2)
}
pub type Heap3 { Heap3(l0 : Us0) }
pub type Us1 {
    Us1Absent
    Us1Box(f1i0 : Heap3)
    Us1Mark(f2i0 : Int)
}
pub fn score_0(v0: Us1) -> Int {
    case v0  {
        Us1Absent -> 1
        Us1Box(v3) -> {
            let v4 = v3.l0
            case v4  {
                Us0Held(v5) -> {
                    let #(v6, v7) = #(v5.l0, v5.l1)
                    let #(v8, v9) = #(v6.l0, v6.l1)
                    let #(v10, v11) = #(v8.l0, v8.l1)
                    let #(v12, v13) = #(v9.l0, v9.l1)
                    let v14 = v10 == 7
                    let v16 =
                        case v14 {
                            True -> {
                                v11 == "hi"
                            }
                            False -> False
                        }
                    let v18 =
                        case v16 {
                            True -> {
                                v12 == 4
                            }
                            False -> False
                        }
                    let v20 =
                        case v18 {
                            True -> {
                                v13 == "yo"
                            }
                            False -> False
                        }
                    let v22 =
                        case v20 {
                            True -> {
                                v7 == 2
                            }
                            False -> False
                        }
                    case v22 {
                        True -> 0
                        False -> 1
                    }
                }
                Us0None -> 1
            }
        }
        Us1Mark(v1) -> 1
    }
}
pub fn main() {
    let v2 = Heap0(l0: 7, l1: "hi")
    let v5 = Heap0(l0: 4, l1: "yo")
    let v6 = Heap1(l0: v2, l1: v5)
    let v8 = Heap2(l0: v6, l1: 2)
    let v12 =
        case True {
            True -> Us0Held(v8)
            False -> Us0None
        }
    let v13 = Heap3(l0: v12)
    let v17 =
        case True {
            True -> Us1Box(v13)
            False -> Us1Mark(1)
        }
    let v19 = spiral_array_create(2)
    spiral_array_set(v19, 0, v17)
    let v20 = Us1Mark(3)
    spiral_array_set(v19, 1, v20)
    let v21 = spiral_array_get(v19, 0)
    let v22 = spiral_array_get(v19, 1)
    let v23 = score_0(v21)
    let v24 = score_0(v22)
    let v25 = v23 == 0
    let v27 =
        case v25 {
            True -> {
                v24 == 1
            }
            False -> False
        }
    case v27 {
        True -> 0
        False -> 1
    }
}
