pub type Heap0 { Heap0(l0 : Int, l1 : String) }
pub fn main() {
    let v0 = 20000
    let v1 = "hi"
    let v2 = Heap0(l0: v0, l1: v1)
    let #(v3, v4) = #(v2.l0, v2.l1)
    let v5 = v3 == 20000
    let v7 =
        case v5 {
            True -> {
                let v6 = v4 == "hi"
                v6
            }
            False -> {
                False
            }
        }
    case v7 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
