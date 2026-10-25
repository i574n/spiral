pub fn method0(v0: Int) -> Int {
    let v1 = v0 == 0
    case v1 {
        True -> {
            1
        }
        False -> {
            v0
        }
    }
}
pub fn main() {
let v0 = 100
let v1 = method0(v0)
let v2 = v1 == 100
case v2 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
