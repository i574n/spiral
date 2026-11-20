pub fn main() {
    let v0 = -1.5
    let v1 = 2.0
    let v2 = v0 /. v1
    let v4 = v0 *. v1
    let v5 = v4 +. 0.5
    let v7 = v2 == -0.75
    case v7 {
        True -> {
            let v8 = v5 == -2.5
            case v8 {
                True -> 0
                False -> 2
            }
        }
        False -> 1
    }
}
