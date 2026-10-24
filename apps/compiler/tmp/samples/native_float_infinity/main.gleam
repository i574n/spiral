pub fn main() {
    let v0 = infinityf
    let v1 = infinity
    let v2 = 0.0 -. v0
    let v3 = 0.0 -. v1
    let v4 = 1.0
    let v5 = 1.0
    let v6 = False
    let v8 =
        case v6 {
            True -> {
                True
            }
            False -> {
                let v7 = False
                v7
            }
        }
    case v8 {
        True -> {
            3
        }
        False -> {
            let v9 = v0 >. v4
            let v11 =
                case v9 {
                    True -> {
                        let v10 = v1 >. v5
                        v10
                    }
                    False -> {
                        False
                    }
                }
            case v11 {
                True -> {
                    let v12 = v2 <. 0.0
                    let v14 =
                        case v12 {
                            True -> {
                                let v13 = v3 <. 0.0
                                v13
                            }
                            False -> {
                                False
                            }
                        }
                    case v14 {
                        True -> {
                            0
                        }
                        False -> {
                            2
                        }
                    }
                }
                False -> {
                    1
                }
            }
        }
    }
}
