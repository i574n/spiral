import gleam/float
pub fn spiral_math_pow(base: Float, exponent: Float) -> Float {
  case float.power(base, exponent) {
    Ok(power) -> power
    Error(_) -> panic as "spiral math: pow outside the real domain"
  }
}

pub fn main() {
    let v4 = 3.1415927
    let v5 = 3.141592653589793
    let v6 = spiral_math_pow(2.0, 3.0)
    let v7 = v6 == 8.0
    let v10 =
        case v7 {
            True -> {
                let v8 = spiral_math_pow(2.0, 3.0)
                v8 == 8.0
            }
            False -> False
        }
    let v12 =
        case v10 {
            True -> {
                v4 >. 3.0
            }
            False -> False
        }
    let v14 =
        case v12 {
            True -> {
                v4 <. 4.0
            }
            False -> False
        }
    let v16 =
        case v14 {
            True -> {
                v5 >. 3.0
            }
            False -> False
        }
    let v18 =
        case v16 {
            True -> {
                v5 <. 4.0
            }
            False -> False
        }
    case v18 {
        True -> 0
        False -> 1
    }
}
