pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Heap0) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub fn f_c0(capt: #(Heap2)) -> fn(Int) -> Heap2 {
    fn (v1) {
        let #(v0) = capt
        v0
    }
}
pub fn main() {
    let v2 = Heap0(l0: 7, l1: "hi")
    let v5 = Heap0(l0: 4, l1: "yo")
    let v6 = Heap1(l0: v2, l1: v5)
    let v8 = Heap2(l0: v6, l1: 2)
    let v9 = f_c0(#(v8))
    let v10 = v9(1)
    let #(v11, v12) = #(v10.l0, v10.l1)
    let #(v13, v14) = #(v11.l0, v11.l1)
    let #(v15, v16) = #(v13.l0, v13.l1)
    let #(v17, v18) = #(v14.l0, v14.l1)
    let v19 = v15 == 7
    let v21 =
        case v19 {
            True -> {
                v16 == "hi"
            }
            False -> False
        }
    let v23 =
        case v21 {
            True -> {
                v17 == 4
            }
            False -> False
        }
    let v25 =
        case v23 {
            True -> {
                v18 == "yo"
            }
            False -> False
        }
    let v27 =
        case v25 {
            True -> {
                v12 == 2
            }
            False -> False
        }
    case v27 {
        True -> 0
        False -> 1
    }
}
