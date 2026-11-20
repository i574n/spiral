pub fn main() {
    let v1 = -2.0
    let v3 = 1.5 /. v1
    let v4 = -0.5 /. v1
    let v5 = v3 == -0.75
    let v7 =
        case v5 {
            True -> {
                v4 == 0.25
            }
            False -> False
        }
    case v7 {
        True -> 0
        False -> 1
    }
}
