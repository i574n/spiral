pub fn main() {
    let v0 = 3
    let v1 = 4
    let v2 = 1
    let v3 = 1
    let v4 = 1.5
    let v5 = 0.0 -. v4
    let v6 = v0 != v1
    case v6 {
        True -> {
            let v7 = v2 != v3
            case v7 {
                True -> {
                    2
                }
                False -> {
                    let v8 = v5 == -1.5
                    case v8 {
                        True -> {
                            0
                        }
                        False -> {
                            3
                        }
                    }
                }
            }
        }
        False -> {
            1
        }
    }
}
