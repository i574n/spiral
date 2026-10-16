pub fn method0(v0: Int, v1: String) -> #(Int, String) {
    let v2 = v0 == 0
    case v2 {
        True -> {
            let v3 = "no"
            #(0, v3)
        }
        False -> {
            #(v0, v1)
        }
    }
}
pub fn main() {
let v0 = 7
let v1 = "hi"
let #(v2, v3) = method0(v0, v1)
let v4 = v2 == 7
let v6 =
    case v4 {
        True -> {
            let v5 = v3 == "hi"
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
