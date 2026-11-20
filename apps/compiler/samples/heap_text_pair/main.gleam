pub type Heap0 { Heap0(l0 : String, l1 : String) }
pub fn main() {
    let v2 = Heap0(l0: "hi", l1: "yo")
    let #(v3, v4) = #(v2.l0, v2.l1)
    let v5 = v3 == "hi"
    let v7 =
        case v5 {
            True -> {
                v4 == "yo"
            }
            False -> False
        }
    case v7 {
        True -> 0
        False -> 1
    }
}
