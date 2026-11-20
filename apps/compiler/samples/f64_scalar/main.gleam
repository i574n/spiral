import gleam/int
import gleam/float
pub fn main() {
    let v2 = 1.5 /. -2.0
    let v3 = 1000000.0
    let v4 = v3 *. v3
    let v5 = v4 *. v3
    let v6 = v5 *. 10000.0
    let v7 = v6 *. v6
    let v9 = int.to_float(3)
    let v12 = float.truncate(2.9)
    let v13 = float.truncate(-1.9)
    let v16 = v2 == -0.75
    let v18 =
        case v16 {
            True -> {
                v7 >. v6
            }
            False -> False
        }
    let v21 =
        case v18 {
            True -> {
                let v19 = v7 *. v6
                v7 <. v19
            }
            False -> False
        }
    let v23 =
        case v21 {
            True -> {
                v9 == 3.0
            }
            False -> False
        }
    let v25 =
        case v23 {
            True -> {
                v12 == 2
            }
            False -> False
        }
    let v27 =
        case v25 {
            True -> {
                v13 == -1
            }
            False -> False
        }
    let v29 =
        case v27 {
            True -> {
                1.5 == 1.5
            }
            False -> False
        }
    case v29 {
        True -> 0
        False -> 1
    }
}
