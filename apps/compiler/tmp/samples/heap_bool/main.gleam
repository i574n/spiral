pub type Heap0 { Heap0(l0 : Bool) }
pub fn main() {
    let v0 = True
    let v1 = Heap0(l0: v0)
    let v2 = v1.l0
    case v2 {
        True -> 0
        False -> 1
    }
}
