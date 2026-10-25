pub fn main() {
    let v0 = "A"
    let v1 = "B"
    let v2 = v0 == "A"
    case v2 {
        True -> {
            let v3 = v1 == "B"
            case v3 {
                True -> {
                    let v4 = v0 == v1
                    case v4 {
                        True -> {
                            2
                        }
                        False -> {
                            0
                        }
                    }
                }
                False -> {
                    3
                }
            }
        }
        False -> {
            1
        }
    }
}
