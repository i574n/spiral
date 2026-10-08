@external(erlang, "math", "sqrt")
pub fn spiral_math_sqrt(x: Float) -> Float

pub fn main() {
let v0 = 144.0
let v1 = 81.0
let v2 = spiral_math_sqrt(v0)
let v3 = spiral_math_sqrt(v1)
let v4 = v2 == 12.0
let v6 =
    case v4 {
        True -> {
            let v5 = v3 == 9.0
            v5
        }
        False -> {
            False
        }
    }
case v6 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
