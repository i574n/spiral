pub fn main() {
    let v0 = 1.5
    let v1 = -2.0
    let v2 = -0.5
    let v3 = v0 /. v1
    let v4 = v2 /. v1
    let v5 = v3 == -0.75
    let v7 =
        case v5 {
            True -> {
                let v6 = v4 == 0.25
                v6
            }
            False -> {
                False
            }
        }
    case v7 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
