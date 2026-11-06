import gleam/string
import gleam/order
pub fn main() {
    let v0 = "a"
    let v1 = "b"
    let v2 = "é"
    let v3 = "éx"
    let v5 = string.compare(v0, v0) == order.Lt
    case v5 {
        True -> 1
        False -> {
            let v6 = string.compare(v0, v1) == order.Lt
            let v8 =
                case v6 {
                    True -> {
                        string.compare(v1, v2) == order.Lt
                    }
                    False -> False
                }
            let v10 =
                case v8 {
                    True -> {
                        string.compare(v2, v3) == order.Lt
                    }
                    False -> False
                }
            let v12 =
                case v10 {
                    True -> {
                        string.compare("", v0) == order.Lt
                    }
                    False -> False
                }
            let v14 =
                case v12 {
                    True -> {
                        string.compare(v0, v0) != order.Gt
                    }
                    False -> False
                }
            let v16 =
                case v14 {
                    True -> {
                        string.compare(v0, v0) != order.Lt
                    }
                    False -> False
                }
            let v18 =
                case v16 {
                    True -> {
                        string.compare(v3, v2) == order.Gt
                    }
                    False -> False
                }
            let v20 =
                case v18 {
                    True -> {
                        string.compare(v1, v0) != order.Lt
                    }
                    False -> False
                }
            case v20 {
                True -> 0
                False -> 1
            }
        }
    }
}
