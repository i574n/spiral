pub fn method0(v0: Int) -> String {
    let v1 = v0 == 0
    case v1 {
        True -> {
            let v2 = "no"
            v2
        }
        False -> {
            let v3 = "hi"
            v3
        }
    }
}
pub fn main() {
let v0 = 7
let v1 = method0(v0)
let v2 = v1 == "hi"
case v2 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
