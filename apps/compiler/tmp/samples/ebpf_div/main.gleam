pub fn main() {
    let v0 = 7
    let v1 = -2
    let v2 = -7
    let v3 = 100
    let v4 = 7
    let v5 = v0 / v1
    let v6 = v0 % v1
    let v7 = v2 / v1
    let v8 = v2 % v1
    let v9 = v3 / v4
    let v10 = v3 % v4
    let v11 = v5 == -3
    let v13 =
        case v11 {
            True -> {
                let v12 = v6 == 1
                v12
            }
            False -> {
                False
            }
        }
    let v15 =
        case v13 {
            True -> {
                let v14 = v7 == 3
                v14
            }
            False -> {
                False
            }
        }
    let v17 =
        case v15 {
            True -> {
                let v16 = v8 == -1
                v16
            }
            False -> {
                False
            }
        }
    let v19 =
        case v17 {
            True -> {
                let v18 = v9 == 14
                v18
            }
            False -> {
                False
            }
        }
    let v21 =
        case v19 {
            True -> {
                let v20 = v10 == 2
                v20
            }
            False -> {
                False
            }
        }
    case v21 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
