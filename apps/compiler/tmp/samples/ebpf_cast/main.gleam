import gleam/int
import gleam/float
pub fn main() {
    let v4 = int.to_float(3)
    let v5 = int.to_float(-2)
    let v6 = int.to_float(7)
    let v7 = float.truncate(2.9)
    let v8 = v4 == 3.0
    let v10 =
        case v8 {
            True -> {
                v5 == -2.0
            }
            False -> False
        }
    let v12 =
        case v10 {
            True -> {
                v6 == 7.0
            }
            False -> False
        }
    let v14 =
        case v12 {
            True -> {
                v7 == 2
            }
            False -> False
        }
    case v14 {
        True -> 0
        False -> 1
    }
}
