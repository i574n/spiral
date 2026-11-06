pub fn main() {
    let v5 = 0.0 -. 1.5
    let v6 = 3 != 4
    case v6 {
        True -> {
            let v7 = 1 != 1
            case v7 {
                True -> 2
                False -> {
                    let v8 = v5 == -1.5
                    case v8 {
                        True -> 0
                        False -> 3
                    }
                }
            }
        }
        False -> 1
    }
}
