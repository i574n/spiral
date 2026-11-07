pub type Us0 {
    Us0Zero
    Us0One
}
pub fn main() {
    let v2 =
        case Us0Zero  {
            Us0One -> False
            Us0Zero -> True
        }
    case v2 {
        True -> 0
        False -> 1
    }
}
