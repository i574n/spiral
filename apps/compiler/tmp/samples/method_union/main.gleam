pub type Us0 {
    Us0None
    Us0Some(f1i0 : Int)
}
pub fn method0(v0: Int) -> Us0 {
    let v1 = v0 == 0
    case v1 {
        True -> Us0None
        False -> Us0Some(v0)
    }
}
pub fn main() {
    let v0 = 7
    let v1 = method0(v0)
    case v1  {
        Us0None -> 1
        Us0Some(v2) -> {
            let v3 = v2 == 7
            case v3 {
                True -> 0
                False -> 1
            }
        }
    }
}
