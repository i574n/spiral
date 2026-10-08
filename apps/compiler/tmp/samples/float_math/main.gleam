pub fn method0(v0: Float, v1: Float) -> Float {
    let v2 = v0 *. v1
    let v3 = v2 +. 0.5
    v3
}
pub fn main() {
let v0 = 1.5
let v1 = 2.0
let v2 = method0(v0, v1)
let v3 = v2 >=. 3.5
case v3 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
