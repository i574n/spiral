pub type Heap0 { Heap0(l0 : Int) }
pub fn main() {
    let v0 = 100
    let v1 = Heap0(l0: v0)
    let v2 = v1.l0
    let v3 = v2 == 100
    case v3 {
        True -> 0
        False -> 1
    }
}
