pub fn method1(v0: Int) -> Bool {
    let v1 = v0 == 42
    v1
}
pub fn method0(v0: Int) -> Bool {
    method1(v0)
}
pub fn main() {
let v0 = 42
let v1 = method0(v0)
case v1 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
