pub fn main() {
    let v0 = infinityf
    let v1 = infinity
    let v2 = 0.0 -. v0
    let v3 = 0.0 -. v1
    let v8 =
        case False {
            True -> True
            False -> {
                False
            }
        }
    case v8 {
        True -> 3
        False -> {
            let v9 = v0 >. 1.0
            let v11 =
                case v9 {
                    True -> {
                        v1 >. 1.0
                    }
                    False -> False
                }
            case v11 {
                True -> {
                    let v12 = v2 <. 0.0
                    let v14 =
                        case v12 {
                            True -> {
                                v3 <. 0.0
                            }
                            False -> False
                        }
                    case v14 {
                        True -> 0
                        False -> 2
                    }
                }
                False -> 1
            }
        }
    }
}
