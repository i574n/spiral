pub type Us0 {
    Us0i0
    Us0i1
}
pub fn main() {
let v0 = Us0i0
let v2 =
    case v0  {
        Us0i1 -> {
            False
        }
        Us0i0 -> {
            True
        }
    }
case v2 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
