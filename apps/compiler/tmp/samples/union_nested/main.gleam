import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Us0 {
    Us0A(f0i0 : Int)
    Us0B(f1i0 : Int)
}
pub type Us1 {
    Us1Wrap(f0i0 : Us0)
    Us1Other(f1i0 : Int)
}
pub fn score_inner_1(v0: Us0) -> Int {
    case v0  {
        Us0A(v1) -> {
            v1
        }
        Us0B(v2) -> {
            let v3 = spiral_wrap_signed(0 - v2, 32)
            v3
        }
    }
}
pub fn score_0(v0: Us1) -> Int {
    case v0  {
        Us1Other(v3) -> {
            v3
        }
        Us1Wrap(v1) -> {
            score_inner_1(v1)
        }
    }
}
pub fn main() {
let v0 = True
let v4 =
    case v0 {
        True -> {
            let v1 = Us0A(7)
            Us1Wrap(v1)
        }
        False -> {
            Us1Other(1)
        }
    }
let v8 =
    case v0 {
        True -> {
            Us1Other(4)
        }
        False -> {
            let v6 = Us0B(2)
            Us1Wrap(v6)
        }
    }
let v9 = score_0(v4)
let v10 = v9 == 7
let v13 =
    case v10 {
        True -> {
            let v11 = score_0(v8)
            let v12 = v11 == 4
            v12
        }
        False -> {
            False
        }
    }
case v13 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
