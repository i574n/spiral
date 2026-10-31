pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Int) }
pub type Heap2 { Heap2(l0 : Heap1, l1 : Int) }
pub fn f_c0(capt: #(Heap2)) -> fn(Int) -> Heap2 {
    fn (v1) {
        let #(v0) = capt
        v0
    }
}
pub fn main() {
    let v0 = 7
    let v1 = "hi"
    let v2 = Heap0(l0: v0, l1: v1)
    let v3 = 1
    let v4 = Heap1(l0: v2, l1: v3)
    let v5 = 2
    let v6 = Heap2(l0: v4, l1: v5)
    let v7 = f_c0(#(v6))
    let v8 = v7(1)
    let #(v9, v10) = #(v8.l0, v8.l1)
    let #(v11, v12) = #(v9.l0, v9.l1)
    let #(v13, v14) = #(v11.l0, v11.l1)
    let v15 = v13 == 7
    let v17 =
        case v15 {
            True -> {
                let v16 = v14 == "hi"
                v16
            }
            False -> False
        }
    let v19 =
        case v17 {
            True -> {
                let v18 = v12 == 1
                v18
            }
            False -> False
        }
    let v21 =
        case v19 {
            True -> {
                let v20 = v10 == 2
                v20
            }
            False -> False
        }
    case v21 {
        True -> 0
        False -> 1
    }
}
