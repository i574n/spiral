pub type Heap0 { Heap0(l0 : Int, l1 : String, l2 : Bool) }
pub fn main() {
    let v3 = Heap0(l0: 7, l1: "hi", l2: True)
    let #(v4, v5, v6) = #(v3.l0, v3.l1, v3.l2)
    let v7 = v4 == 7
    let v9 =
        case v7 {
            True -> {
                v5 == "hi"
            }
            False -> False
        }
    let v10 = v9 && v6
    case v10 {
        True -> 0
        False -> 1
    }
}
