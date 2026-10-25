pub fn method0(v0: Int) -> Float {
    let v1 = v0 == 0
    case v1 {
        True -> {
            0.0
        }
        False -> {
            1.5
        }
    }
}
pub fn main() {
let v0 = 7
let v1 = method0(v0)
let v2 = v1 == 1.5
case v2 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
