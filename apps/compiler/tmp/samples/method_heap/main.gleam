pub type Heap0 { Heap0(l0 : Int) }
pub fn method0(v0: Heap0) -> Heap0 {
    v0
}
pub fn main() {
    let v0 = 7
    let v1 = Heap0(l0: v0)
    let v2 = method0(v1)
    let v3 = v2.l0
    let v4 = v3 == 7
    case v4 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
