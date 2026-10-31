import gleam/string
import gleam/order
pub fn main() {
    let v0 = "a"
    let v1 = "b"
    let v2 = "é"
    let v3 = "éx"
    let v4 = ""
    let v5 = string.compare(v0, v0) == order.Lt
    case v5 {
        True -> 1
        False -> {
            let v6 = string.compare(v0, v1) == order.Lt
            let v8 =
                case v6 {
                    True -> {
                        let v7 = string.compare(v1, v2) == order.Lt
                        v7
                    }
                    False -> False
                }
            let v10 =
                case v8 {
                    True -> {
                        let v9 = string.compare(v2, v3) == order.Lt
                        v9
                    }
                    False -> False
                }
            let v12 =
                case v10 {
                    True -> {
                        let v11 = string.compare(v4, v0) == order.Lt
                        v11
                    }
                    False -> False
                }
            let v14 =
                case v12 {
                    True -> {
                        let v13 = string.compare(v0, v0) != order.Gt
                        v13
                    }
                    False -> False
                }
            let v16 =
                case v14 {
                    True -> {
                        let v15 = string.compare(v0, v0) != order.Lt
                        v15
                    }
                    False -> False
                }
            let v18 =
                case v16 {
                    True -> {
                        let v17 = string.compare(v3, v2) == order.Gt
                        v17
                    }
                    False -> False
                }
            let v20 =
                case v18 {
                    True -> {
                        let v19 = string.compare(v1, v0) != order.Lt
                        v19
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
