pub type Heap0 { Heap0(l0 : String, l1 : String) }
pub fn main() {
    let v0 = "hi"
    let v1 = Heap0(l0: v0, l1: v0)
    let #(v2, v3) = #(v1.l0, v1.l1)
    let v4 = v2 == v3
    case v4 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
