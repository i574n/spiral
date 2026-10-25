pub fn method0(v0: Bool) -> Int {
    case v0 {
        True -> {
            1
        }
        False -> {
            3
        }
    }
}
pub fn method1(v0: Bool, v1: Bool) -> Int {
    let v2 = v0 && v1
    case v2 {
        True -> {
            1
        }
        False -> {
            let v3 = v0 || v1
            case v3 {
                True -> {
                    2
                }
                False -> {
                    3
                }
            }
        }
    }
}
pub fn method2(v0: Bool) -> Int {
    case v0 {
        True -> {
            1
        }
        False -> {
            3
        }
    }
}
pub fn main() {
let v0 = True
let v1 = False
let v2 = method0(v0)
let v3 = method1(v0, v1)
let v4 = method2(v1)
let v5 = v0 == v1
let v6 = v5 == False
let v7 = v2 == 1
let v9 =
    case v7 {
        True -> {
            let v8 = v3 == 2
            v8
        }
        False -> {
            False
        }
    }
let v11 =
    case v9 {
        True -> {
            let v10 = v4 == 3
            v10
        }
        False -> {
            False
        }
    }
let v12 = v11 && v6
case v12 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
