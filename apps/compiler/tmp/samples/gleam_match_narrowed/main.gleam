import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Us0 {
    Us0Circle(f0i0 : Int)
    Us0Square(f1i0 : Int)
    Us0Tri(f2i0 : Int)
    Us0Dot
}
pub fn pick_0(v0: Int) -> Us0 {
    let v1 = v0 == 0
    case v1 {
        True -> {
            Us0Circle(5)
        }
        False -> {
            let v3 = v0 == 1
            case v3 {
                True -> {
                    Us0Square(4)
                }
                False -> {
                    let v5 = v0 == 2
                    case v5 {
                        True -> {
                            Us0Tri(7)
                        }
                        False -> {
                            Us0Dot
                        }
                    }
                }
            }
        }
    }
}
pub fn measure_1(v0: Us0, v1: Int) -> Int {
    case v0  {
        Us0Circle(v2) -> {
            let v3 = spiral_wrap_signed(v2 * 3, 32)
            v3
        }
        _ -> {
            let v4 = spiral_wrap_signed(v1 * v1, 32)
            let v5 = v4 > 3
            case v0  {
                Us0Dot -> {
                    v4
                }
                Us0Square(v6) -> {
                    case v5 {
                        True -> {
                            let v7 = spiral_wrap_signed(v6 * v6, 32)
                            v7
                        }
                        False -> {
                            v6
                        }
                    }
                }
                Us0Tri(v9) -> {
                    case v5 {
                        True -> {
                            let v10 = spiral_wrap_signed(v9 * 2, 32)
                            v10
                        }
                        False -> {
                            v9
                        }
                    }
                }
                _ -> panic as "spiral: union case ruled out by partial evaluation"
            }
        }
    }
}
pub fn measure_tri_2(v0: Us0, v1: Int) -> Int {
    case v0  {
        Us0Circle(v2) -> {
            v2
        }
        Us0Dot -> {
            0
        }
        Us0Square(v3) -> {
            v3
        }
        _ -> {
            let v4 = spiral_wrap_signed(v1 + 2, 32)
            case v0  {
                Us0Tri(v5) -> {
                    let v6 = spiral_wrap_signed(v5 * v4, 32)
                    v6
                }
                _ -> panic as "spiral: union case ruled out by partial evaluation"
            }
        }
    }
}
pub fn main() {
    let v0 = 0
    let v1 = pick_0(v0)
    let v2 = measure_1(v1, v0)
    let v3 = spiral_wrap_signed(v0 + 1, 32)
    let v4 = pick_0(v3)
    let v5 = measure_1(v4, v3)
    let v6 = spiral_wrap_signed(v2 + v5, 32)
    let v7 = spiral_wrap_signed(v0 + 2, 32)
    let v8 = pick_0(v7)
    let v9 = measure_1(v8, v7)
    let v10 = spiral_wrap_signed(v6 + v9, 32)
    let v11 = spiral_wrap_signed(v0 + 3, 32)
    let v12 = pick_0(v11)
    let v13 = measure_1(v12, v11)
    let v14 = spiral_wrap_signed(v10 + v13, 32)
    let v15 = pick_0(v7)
    let v16 = measure_tri_2(v15, v0)
    let v17 = spiral_wrap_signed(v14 + v16, 32)
    let v18 = pick_0(v0)
    let v19 = measure_tri_2(v18, v0)
    let v20 = spiral_wrap_signed(v17 + v19, 32)
    v20
}
