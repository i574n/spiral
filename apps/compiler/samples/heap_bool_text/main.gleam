pub type Heap0 { Heap0(l0 : Bool, l1 : String) }
pub fn main() {
    let v2 = Heap0(l0: True, l1: "hi")
    let #(v3, v4) = #(v2.l0, v2.l1)
    let v6 =
        case v3 {
            True -> {
                v4 == "hi"
            }
            False -> False
        }
    case v6 {
        True -> 0
        False -> 1
    }
}
