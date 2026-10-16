pub fn main() {
let v0 = 3
let v1 = 4
let v2 = 1
let v3 = 1
let v4 = 1.5
let v5 = 0.0 -. v4
let v6 = v0 == v1
let v7 = v6 != True
case v7 {
    True -> {
        let v8 = v2 == v3
        let v9 = v8 != True
        case v9 {
            True -> {
                2
            }
            False -> {
                let v10 = v5 == -1.5
                case v10 {
                    True -> {
                        0
                    }
                    False -> {
                        3
                    }
                }
            }
        }
    }
    False -> {
        1
    }
}
}
