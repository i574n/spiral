pub type Us0 {
    Us0Empty
    Us0Full(f1i0 : Int)
}
pub fn pick_0(v0: Us0) -> Int {
    case v0  {
        Us0Empty -> {
            0
        }
        Us0Full(v1) -> {
            v1
        }
    }
}
pub fn main() {
let v0 = True
let v3 =
    case v0 {
        True -> {
            Us0Full(7)
        }
        False -> {
            Us0Empty
        }
    }
let v6 =
    case v0 {
        True -> {
            Us0Empty
        }
        False -> {
            Us0Full(1)
        }
    }
let v7 = pick_0(v3)
let v8 = v7 == 7
let v11 =
    case v8 {
        True -> {
            let v9 = pick_0(v6)
            let v10 = v9 == 0
            v10
        }
        False -> {
            False
        }
    }
case v11 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
