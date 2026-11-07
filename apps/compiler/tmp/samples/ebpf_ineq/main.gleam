pub fn main() {
    let v0 = -3
    let v3 = 4294967295
    let v6 = -1.5
    let v9 = v0 != -4
    let v10 = v0 != -3
    let v11 = v3 != 0
    let v12 = v3 != 4294967295
    let v13 = v6 != -0.5
    let v14 = v6 != -1.5
    let v15 = v9 && v11
    let v16 = v15 && v13
    case v16 {
        True -> {
            case v10 {
                True -> 1
                False -> {
                    case v12 {
                        True -> 2
                        False -> {
                            case v14 {
                                True -> 3
                                False -> 0
                            }
                        }
                    }
                }
            }
        }
        False -> 4
    }
}
