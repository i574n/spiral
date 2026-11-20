pub fn main() {
    let v0 = "x"
    let v1 = v0 == " "
    let v3 =
        case v1 {
            True -> True
            False -> {
                v0 == "/"
            }
        }
    case v3 {
        True -> 1
        False -> 0
    }
}
