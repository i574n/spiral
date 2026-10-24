import gleam/int
import gleam/float
pub fn main() {
    let v0 = 3
    let v1 = -2
    let v2 = 7
    let v3 = 2.9
    let v4 = int.to_float(v0)
    let v5 = int.to_float(v1)
    let v6 = int.to_float(v2)
    let v7 = float.truncate(v3)
    let v8 = v4 == 3.0
    let v10 =
        case v8 {
            True -> {
                let v9 = v5 == -2.0
                v9
            }
            False -> {
                False
            }
        }
    let v12 =
        case v10 {
            True -> {
                let v11 = v6 == 7.0
                v11
            }
            False -> {
                False
            }
        }
    let v14 =
        case v12 {
            True -> {
                let v13 = v7 == 2
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
            1
        }
    }
}
