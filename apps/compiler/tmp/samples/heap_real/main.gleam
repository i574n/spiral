pub type Heap0 { Heap0(l0 : Float) }
pub fn main() {
    let v0 = 1.5
    let v1 = Heap0(l0: v0)
    let v2 = v1.l0
    let v3 = v2 == 1.5
    case v3 {
        True -> 0
        False -> 1
    }
}
