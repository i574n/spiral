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

pub fn spiral_array_create(size: Int) -> SpiralArray(a) {
  list.repeat(option.None, size) |> array.from_list(option.None) |> spiral_array_from_storage(size)
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
        Us1Absent -> {
            1
        }
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
                                let v13 = v9 == "hi"
                                v13
                            }
                            False -> {
                                False
                            }
                        }
                    let v16 =
                        case v14 {
                            True -> {
                                let v15 = v10 == 4
                                v15
                            }
                            False -> {
                                False
                            }
                        }
                    let v18 =
                        case v16 {
                            True -> {
                                let v17 = v11 == "yo"
                                v17
                            }
                            False -> {
                                False
                            }
                        }
                    let v20 =
                        case v18 {
                            True -> {
                                let v19 = v5 == 2
                                v19
                            }
                            False -> {
                                False
                            }
                        }
                    case v20 {
                        True -> {
                            0
                        }
                        False -> {
                            1
                        }
                    }
                }
                Us0None -> {
                    1
                }
            }
        }
    }
}
pub fn score_b_1(v0: Us1) -> Int {
    case v0  {
        Us1Absent -> {
            1
        }
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
                                let v13 = v9 == "ok"
                                v13
                            }
                            False -> {
                                False
                            }
                        }
                    let v16 =
                        case v14 {
                            True -> {
                                let v15 = v10 == 5
                                v15
                            }
                            False -> {
                                False
                            }
                        }
                    let v18 =
                        case v16 {
                            True -> {
                                let v17 = v11 == "no"
                                v17
                            }
                            False -> {
                                False
                            }
                        }
                    let v20 =
                        case v18 {
                            True -> {
                                let v19 = v5 == 9
                                v19
                            }
                            False -> {
                                False
                            }
                        }
                    case v20 {
                        True -> {
                            0
                        }
                        False -> {
                            1
                        }
                    }
                }
                Us0None -> {
                    1
                }
            }
        }
    }
}
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
    let v9 = Us0Held(v8)
    let v10 = Heap3(l0: v9)
    let v11 = Us1Box(v10)
    let v12 = Heap4(l0: v11)
    let v13 = 8
    let v14 = "ok"
    let v15 = Heap0(l0: v13, l1: v14)
    let v16 = 5
    let v17 = "no"
    let v18 = Heap0(l0: v16, l1: v17)
    let v19 = Heap1(l0: v15, l1: v18)
    let v20 = 9
    let v21 = Heap2(l0: v19, l1: v20)
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
                let v34 = v32 == 0
                v34
            }
            False -> {
                False
            }
        }
    case v35 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
