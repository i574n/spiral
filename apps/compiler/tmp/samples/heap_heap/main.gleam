pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Int) }
pub fn main() {
    let v0 = 7
    let v1 = "hi"
    let v2 = Heap0(l0: v0, l1: v1)
    let v3 = 1
    let v4 = Heap1(l0: v2, l1: v3)
    let #(v5, v6) = #(v4.l0, v4.l1)
    let #(v7, v8) = #(v5.l0, v5.l1)
    let v9 = v7 == 7
    let v11 =
        case v9 {
            True -> {
                let v10 = v8 == "hi"
                v10
            }
            False -> False
        }
    let v13 =
        case v11 {
            True -> {
                let v12 = v6 == 1
                v12
            }
            False -> False
        }
    case v13 {
        True -> 0
        False -> 1
    }
}
