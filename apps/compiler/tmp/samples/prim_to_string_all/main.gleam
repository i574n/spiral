import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn main() {
    let v11 = int.to_string(-128)
    let v12 = v11 == "-128"
    let v13 =
        case v12 {
            True -> 0
            False -> 1
        }
    let v14 = int.to_string(-32768)
    let v15 = v14 == "-32768"
    let v16 =
        case v15 {
            True -> 0
            False -> 1
        }
    let v17 = spiral_wrap_signed(v13 + v16, 32)
    let v18 = int.to_string(-5)
    let v19 = v18 == "-5"
    let v20 =
        case v19 {
            True -> 0
            False -> 1
        }
    let v21 = spiral_wrap_signed(v17 + v20, 32)
    let v22 = int.to_string(-1234567890123)
    let v23 = v22 == "-1234567890123"
    let v24 =
        case v23 {
            True -> 0
            False -> 1
        }
    let v25 = spiral_wrap_signed(v21 + v24, 32)
    let v26 = int.to_string(255)
    let v27 = v26 == "255"
    let v28 =
        case v27 {
            True -> 0
            False -> 1
        }
    let v29 = spiral_wrap_signed(v25 + v28, 32)
    let v30 = int.to_string(65535)
    let v31 = v30 == "65535"
    let v32 =
        case v31 {
            True -> 0
            False -> 1
        }
    let v33 = spiral_wrap_signed(v29 + v32, 32)
    let v34 = int.to_string(4294967295)
    let v35 = v34 == "4294967295"
    let v36 =
        case v35 {
            True -> 0
            False -> 1
        }
    let v37 = spiral_wrap_signed(v33 + v36, 32)
    let v38 = int.to_string(18446744073709551615)
    let v39 = v38 == "18446744073709551615"
    let v40 =
        case v39 {
            True -> 0
            False -> 1
        }
    let v41 = spiral_wrap_signed(v37 + v40, 32)
    let v42 = case True { True -> "true" False -> "false" }
    let v43 = v42 == "true"
    let v44 =
        case v43 {
            True -> 0
            False -> 1
        }
    let v45 = spiral_wrap_signed(v41 + v44, 32)
    let v46 = case False { True -> "true" False -> "false" }
    let v47 = v46 == "false"
    let v48 =
        case v47 {
            True -> 0
            False -> 1
        }
    let v49 = spiral_wrap_signed(v45 + v48, 32)
    let v51 = "a" == "a"
    let v52 =
        case v51 {
            True -> 0
            False -> 1
        }
    let v53 = spiral_wrap_signed(v49 + v52, 32)
    let v54 = int.to_string(7)
    let v55 = v54 == "7"
    let v56 =
        case v55 {
            True -> 0
            False -> 1
        }
    let v57 = spiral_wrap_signed(v53 + v56, 32)
    let v58 = case False { True -> "true" False -> "false" }
    let v59 = v58 == "false"
    let v60 =
        case v59 {
            True -> 0
            False -> 1
        }
    let v61 = spiral_wrap_signed(v57 + v60, 32)
    let v63 = "z" == "z"
    let v64 =
        case v63 {
            True -> 0
            False -> 1
        }
    let v65 = spiral_wrap_signed(v61 + v64, 32)
    let v66 = int.to_string(-3)
    let v67 = v66 == "-3"
    let v68 =
        case v67 {
            True -> 0
            False -> 1
        }
    spiral_wrap_signed(v65 + v68, 32)
}
