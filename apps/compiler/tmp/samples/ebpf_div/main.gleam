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
                v6 == 1
            }
            False -> False
        }
    let v15 =
        case v13 {
            True -> {
                v7 == 3
            }
            False -> False
        }
    let v17 =
        case v15 {
            True -> {
                v8 == -1
            }
            False -> False
        }
    let v19 =
        case v17 {
            True -> {
                v9 == 14
            }
            False -> False
        }
    let v21 =
        case v19 {
            True -> {
                v10 == 2
            }
            False -> False
        }
    case v21 {
        True -> 0
        False -> 1
    }
}
