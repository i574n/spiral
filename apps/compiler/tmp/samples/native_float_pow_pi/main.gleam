import gleam/float
pub fn spiral_math_pow(base: Float, exponent: Float) -> Float {
  case float.power(base, exponent) {
    Ok(power) -> power
    Error(_) -> panic as "spiral math: pow outside the real domain"
  }
}

pub fn main() {
    let v0 = 2.0
    let v1 = 3.0
    let v2 = 2.0
    let v3 = 3.0
    let v4 = 3.1415927
    let v5 = 3.141592653589793
    let v6 = spiral_math_pow(v0, v1)
    let v7 = v6 == 8.0
    let v10 =
        case v7 {
            True -> {
                let v8 = spiral_math_pow(v2, v3)
                let v9 = v8 == 8.0
                v9
            }
            False -> False
        }
    let v12 =
        case v10 {
            True -> {
                let v11 = v4 >. 3.0
                v11
            }
            False -> False
        }
    let v14 =
        case v12 {
            True -> {
                let v13 = v4 <. 4.0
                v13
            }
            False -> False
        }
    let v16 =
        case v14 {
            True -> {
                let v15 = v5 >. 3.0
                v15
            }
            False -> False
        }
    let v18 =
        case v16 {
            True -> {
                let v17 = v5 <. 4.0
                v17
            }
            False -> False
        }
    case v18 {
        True -> 0
        False -> 1
    }
}
