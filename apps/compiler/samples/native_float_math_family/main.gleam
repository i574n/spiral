import gleam/float
import gleam_community/maths
pub fn spiral_math_log(x: Float) -> Float {
  case float.logarithm(x) {
    Ok(value) -> value
    Error(_) -> panic as "spiral math: log outside the real domain"
  }
}

pub fn main() {
    let v0 = 0.0
    let v1 = 1.0
    let v2 = 0.0
    let v3 = 1.0
    let v4 = spiral_math_log(v1)
    let v5 = v4 == v0
    let v8 =
        case v5 {
            True -> {
                let v6 = spiral_math_log(v3)
                v6 == v2
            }
            False -> False
        }
    let v11 =
        case v8 {
            True -> {
                let v9 = float.exponential(v0)
                v9 == v1
            }
            False -> False
        }
    let v14 =
        case v11 {
            True -> {
                let v12 = float.exponential(v2)
                v12 == v3
            }
            False -> False
        }
    let v17 =
        case v14 {
            True -> {
                let v15 = maths.tanh(v0)
                v15 == v0
            }
            False -> False
        }
    let v20 =
        case v17 {
            True -> {
                let v18 = maths.tanh(v2)
                v18 == v2
            }
            False -> False
        }
    let v23 =
        case v20 {
            True -> {
                let v21 = maths.sin(v0)
                v21 == v0
            }
            False -> False
        }
    let v26 =
        case v23 {
            True -> {
                let v24 = maths.sin(v2)
                v24 == v2
            }
            False -> False
        }
    let v29 =
        case v26 {
            True -> {
                let v27 = maths.cos(v0)
                v27 == v1
            }
            False -> False
        }
    let v32 =
        case v29 {
            True -> {
                let v30 = maths.cos(v2)
                v30 == v3
            }
            False -> False
        }
    case v32 {
        True -> 0
        False -> 1
    }
}
