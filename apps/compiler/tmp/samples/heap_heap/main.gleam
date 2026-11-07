pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub type Heap1 { Heap1(l0 : Heap0, l1 : Int) }
pub fn main() {
    let v2 = Heap0(l0: 7, l1: "hi")
    let v4 = Heap1(l0: v2, l1: 1)
    let #(v5, v6) = #(v4.l0, v4.l1)
    let #(v7, v8) = #(v5.l0, v5.l1)
    let v9 = v7 == 7
    let v11 =
        case v9 {
            True -> {
                v8 == "hi"
            }
            False -> False
        }
    let v13 =
        case v11 {
            True -> {
                v6 == 1
            }
            False -> False
        }
    case v13 {
        True -> 0
        False -> 1
    }
}
