pub fn main() {
    let v0 = -3
    let v1 = -4
    let v2 = -3
    let v3 = 4294967295
    let v4 = 0
    let v5 = 4294967295
    let v6 = -1.5
    let v7 = -0.5
    let v8 = -1.5
    let v9 = v0 != v1
    let v10 = v0 != v2
    let v11 = v3 != v4
    let v12 = v3 != v5
    let v13 = v6 != v7
    let v14 = v6 != v8
    let v15 = v9 && v11
    let v16 = v15 && v13
    case v16 {
        True -> {
            case v10 {
                True -> {
                    1
                }
                False -> {
                    case v12 {
                        True -> {
                            2
                        }
                        False -> {
                            case v14 {
                                True -> {
                                    3
                                }
                                False -> {
                                    0
                                }
                            }
                        }
                    }
                }
            }
        }
        False -> {
            4
        }
    }
}
