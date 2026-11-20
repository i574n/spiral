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
}
pub type Heap4 { Heap4(l0 : Us1) }
pub fn score_0(v0: Us1) -> Int {
    case v0  {
        Us1Absent -> 1
        Us1Box(v1) -> {
            let v2 = v1.l0
            case v2  {
                Us0Held(v3) -> {
                    let #(v4, v5) = #(v3.l0, v3.l1)
                    let #(v6, v7) = #(v4.l0, v4.l1)
                    let #(v8, v9) = #(v6.l0, v6.l1)
                    let #(v10, v11) = #(v7.l0, v7.l1)
                    let v12 = v8 == 7
                    let v14 =
                        case v12 {
                            True -> {
                                v9 == "hi"
                            }
                            False -> False
                        }
                    let v16 =
                        case v14 {
                            True -> {
                                v10 == 4
                            }
                            False -> False
                        }
                    let v18 =
                        case v16 {
                            True -> {
                                v11 == "yo"
                            }
                            False -> False
                        }
                    let v20 =
                        case v18 {
                            True -> {
                                v5 == 2
                            }
                            False -> False
                        }
                    case v20 {
                        True -> 0
                        False -> 1
                    }
                }
                Us0None -> 1
            }
        }
    }
}
pub fn score_b_1(v0: Us1) -> Int {
    case v0  {
        Us1Absent -> 1
        Us1Box(v1) -> {
            let v2 = v1.l0
            case v2  {
                Us0Held(v3) -> {
                    let #(v4, v5) = #(v3.l0, v3.l1)
                    let #(v6, v7) = #(v4.l0, v4.l1)
                    let #(v8, v9) = #(v6.l0, v6.l1)
                    let #(v10, v11) = #(v7.l0, v7.l1)
                    let v12 = v8 == 8
                    let v14 =
                        case v12 {
                            True -> {
                                v9 == "ok"
                            }
                            False -> False
                        }
                    let v16 =
                        case v14 {
                            True -> {
                                v10 == 5
                            }
                            False -> False
                        }
                    let v18 =
                        case v16 {
                            True -> {
                                v11 == "no"
                            }
                            False -> False
                        }
                    let v20 =
                        case v18 {
                            True -> {
                                v5 == 9
                            }
                            False -> False
                        }
                    case v20 {
                        True -> 0
                        False -> 1
                    }
                }
                Us0None -> 1
            }
        }
    }
}
pub fn main() {
    let v2 = Heap0(l0: 7, l1: "hi")
    let v5 = Heap0(l0: 4, l1: "yo")
    let v6 = Heap1(l0: v2, l1: v5)
    let v8 = Heap2(l0: v6, l1: 2)
    let v9 = Us0Held(v8)
    let v10 = Heap3(l0: v9)
    let v11 = Us1Box(v10)
    let v12 = Heap4(l0: v11)
    let v15 = Heap0(l0: 8, l1: "ok")
    let v18 = Heap0(l0: 5, l1: "no")
    let v19 = Heap1(l0: v15, l1: v18)
    let v21 = Heap2(l0: v19, l1: 9)
    let v22 = Us0Held(v21)
    let v23 = Heap3(l0: v22)
    let v24 = Us1Box(v23)
    let v25 = Heap4(l0: v24)
    let v26 = spiral_array_create(2)
    spiral_array_set(v26, 0, v12)
    spiral_array_set(v26, 1, v25)
    let v27 = spiral_array_get(v26, 0)
    let v28 = spiral_array_get(v26, 1)
    let v29 = v27.l0
    let v30 = v28.l0
    let v31 = score_0(v29)
    let v32 = score_b_1(v30)
    let v33 = v31 == 0
    let v35 =
        case v33 {
            True -> {
                v32 == 0
            }
            False -> False
        }
    case v35 {
        True -> 0
        False -> 1
    }
}
