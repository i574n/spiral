pub type Heap0 { Heap0(l0 : Int, l1 : String, l2 : Bool) }
pub fn main() {
    let v0 = 4000000000
    let v1 = "hi"
    let v2 = True
    let v3 = Heap0(l0: v0, l1: v1, l2: v2)
    let #(v4, v5, v6) = #(v3.l0, v3.l1, v3.l2)
    let v7 = v4 == 4000000000
    let v9 =
        case v7 {
            True -> {
                let v8 = v5 == "hi"
                v8
            }
            False -> False
        }
    let v10 = v9 && v6
    case v10 {
        True -> 0
        False -> 1
    }
}
