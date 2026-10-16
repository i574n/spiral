import gleam/int
import gleam/float
pub fn main() {
let v0 = 1.5
let v1 = -2.0
let v2 = v0 /. v1
let v3 = 1000000.0
let v4 = v3 *. v3
let v5 = v4 *. v3
let v6 = v5 *. 10000.0
let v7 = v6 *. v6
let v8 = 3
let v9 = int.to_float(v8)
let v10 = 2.9
let v11 = -1.9
let v12 = float.truncate(v10)
let v13 = float.truncate(v11)
let v14 = 1.5
let v15 = v14
let v16 = v2 == -0.75
let v18 =
    case v16 {
        True -> {
            let v17 = v7 >. v6
            v17
        }
        False -> {
            False
        }
    }
let v21 =
    case v18 {
        True -> {
            let v19 = v7 *. v6
            let v20 = v7 <. v19
            v20
        }
        False -> {
            False
        }
    }
let v23 =
    case v21 {
        True -> {
            let v22 = v9 == 3.0
            v22
        }
        False -> {
            False
        }
    }
let v25 =
    case v23 {
        True -> {
            let v24 = v12 == 2
            v24
        }
        False -> {
            False
        }
    }
let v27 =
    case v25 {
        True -> {
            let v26 = v13 == -1
            v26
        }
        False -> {
            False
        }
    }
let v29 =
    case v27 {
        True -> {
            let v28 = v15 == 1.5
            v28
        }
        False -> {
            False
        }
    }
case v29 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
