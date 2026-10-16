pub type Heap0 { Heap0(l0 : Bool, l1 : String) }
pub fn main() {
let v0 = True
let v1 = "hi"
let v2 = Heap0(l0: v0, l1: v1)
let #(v3, v4) = #(v2.l0, v2.l1)
let v6 =
    case v3 {
        True -> {
            let v5 = v4 == "hi"
            v5
        }
        False -> {
            False
        }
    }
case v6 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
