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
                let v7 = v6 == v2
                v7
            }
            False -> False
        }
    let v11 =
        case v8 {
            True -> {
                let v9 = float.exponential(v0)
                let v10 = v9 == v1
                v10
            }
            False -> False
        }
    let v14 =
        case v11 {
            True -> {
                let v12 = float.exponential(v2)
                let v13 = v12 == v3
                v13
            }
            False -> False
        }
    let v17 =
        case v14 {
            True -> {
                let v15 = maths.tanh(v0)
                let v16 = v15 == v0
                v16
            }
            False -> False
        }
    let v20 =
        case v17 {
            True -> {
                let v18 = maths.tanh(v2)
                let v19 = v18 == v2
                v19
            }
            False -> False
        }
    let v23 =
        case v20 {
            True -> {
                let v21 = maths.sin(v0)
                let v22 = v21 == v0
                v22
            }
            False -> False
        }
    let v26 =
        case v23 {
            True -> {
                let v24 = maths.sin(v2)
                let v25 = v24 == v2
                v25
            }
            False -> False
        }
    let v29 =
        case v26 {
            True -> {
                let v27 = maths.cos(v0)
                let v28 = v27 == v1
                v28
            }
            False -> False
        }
    let v32 =
        case v29 {
            True -> {
                let v30 = maths.cos(v2)
                let v31 = v30 == v3
                v31
            }
            False -> False
        }
    case v32 {
        True -> 0
        False -> 1
    }
}
