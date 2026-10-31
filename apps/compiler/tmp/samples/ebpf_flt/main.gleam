pub fn main() {
    let v0 = -2.0
    let v1 = -1.0
    let v2 = 0.0
    let v3 = v0 <. v1
    let v5 =
        case v3 {
            True -> {
                let v4 = v1 <. v2
                v4
            }
            False -> False
        }
    let v8 =
        case v5 {
            True -> {
                let v6 = v0 >. v1
                let v7 = v6 == False
                v7
            }
            False -> False
        }
    let v11 =
        case v8 {
            True -> {
                let v9 = v0 >=. v1
                let v10 = v9 == False
                v10
            }
            False -> False
        }
    let v13 =
        case v11 {
            True -> {
                let v12 = v1 <=. v2
                v12
            }
            False -> False
        }
    case v13 {
        True -> 0
        False -> 1
    }
}
