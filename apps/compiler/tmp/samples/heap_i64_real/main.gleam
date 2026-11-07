pub type Heap0 { Heap0(l0 : Int, l1 : Float) }
pub fn main() {
    let v2 = Heap0(l0: 5000000000, l1: 1.5)
    let #(v3, v4) = #(v2.l0, v2.l1)
    let v5 = v3 == 5000000000
    let v7 =
        case v5 {
            True -> {
                v4 == 1.5
            }
            False -> False
        }
    case v7 {
        True -> 0
        False -> 1
    }
}
