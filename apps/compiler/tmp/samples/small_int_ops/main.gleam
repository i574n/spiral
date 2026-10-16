import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn main() {
let v0 = 100
let v1 = 3
let v2 = spiral_wrap_signed(v0 * v1, 8)
let v3 = -8
let v4 = 2
let v5 = v3 / v4
let v6 = v3 % v1
let v7 = spiral_wrap_signed(0 - v1, 8)
let v8 = spiral_wrap_signed(int.bitwise_shift_left(v0, 1), 8)
let v9 = 200
let v10 = 3
let v11 = v9 / v10
let v12 = v9 % v10
let v13 = 15
let v14 = int.bitwise_and(v9, v13)
let v15 = int.bitwise_or(v9, v13)
let v16 = int.bitwise_exclusive_or(v9, v13)
let v17 = spiral_wrap_unsigned(int.bitwise_not(v13), 8)
let v18 = 20000
let v19 = 7
let v20 = v18 / v19
let v21 = v18 % v19
let v22 = spiral_wrap_signed(0 - v18, 16)
let v23 = 40000
let v24 = spiral_wrap_unsigned(int.bitwise_shift_left(v23, 1), 16)
let v25 = v2 == 44
let v27 =
    case v25 {
        True -> {
            let v26 = v5 == -4
            v26
        }
        False -> {
            False
        }
    }
let v29 =
    case v27 {
        True -> {
            let v28 = v6 == -2
            v28
        }
        False -> {
            False
        }
    }
let v31 =
    case v29 {
        True -> {
            let v30 = v7 == -3
            v30
        }
        False -> {
            False
        }
    }
let v33 =
    case v31 {
        True -> {
            let v32 = v8 == -56
            v32
        }
        False -> {
            False
        }
    }
let v35 =
    case v33 {
        True -> {
            let v34 = v11 == 66
            v34
        }
        False -> {
            False
        }
    }
let v37 =
    case v35 {
        True -> {
            let v36 = v12 == 2
            v36
        }
        False -> {
            False
        }
    }
let v39 =
    case v37 {
        True -> {
            let v38 = v14 == 8
            v38
        }
        False -> {
            False
        }
    }
let v41 =
    case v39 {
        True -> {
            let v40 = v15 == 207
            v40
        }
        False -> {
            False
        }
    }
let v43 =
    case v41 {
        True -> {
            let v42 = v16 == 199
            v42
        }
        False -> {
            False
        }
    }
let v45 =
    case v43 {
        True -> {
            let v44 = v17 == 240
            v44
        }
        False -> {
            False
        }
    }
let v47 =
    case v45 {
        True -> {
            let v46 = v20 == 2857
            v46
        }
        False -> {
            False
        }
    }
let v49 =
    case v47 {
        True -> {
            let v48 = v21 == 1
            v48
        }
        False -> {
            False
        }
    }
let v51 =
    case v49 {
        True -> {
            let v50 = v22 == -20000
            v50
        }
        False -> {
            False
        }
    }
let v53 =
    case v51 {
        True -> {
            let v52 = v24 == 14464
            v52
        }
        False -> {
            False
        }
    }
case v53 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
