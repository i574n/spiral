import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Us0 {
    Us0Idle
    Us0Text(f1i0 : String)
    Us0Note(f2i0 : String)
}
pub fn closure0(capt: Nil) -> fn(Int) -> Us0 {
    fn (v0) {
        let v1 = v0 == 1
        case v1 {
            True -> {
                let v2 = "alpha"
                Us0Text(v2)
            }
            False -> {
                let v4 = "beta"
                Us0Note(v4)
            }
        }
    }
}
pub fn method0(v0: fn(Int) -> Us0) -> Us0 {
    v0( 1  )
}
pub fn method1(v0: fn(Int) -> Us0) -> Us0 {
    v0( 2  )
}
pub fn main() {
let v0 = closure0(Nil)
let v1 = method0(v0)
let v6 =
    case v1  {
        Us0Idle -> {
            3
        }
        Us0Note(v3) -> {
            6
        }
        Us0Text(v2) -> {
            5
        }
    }
let v7 = method1(v0)
let v12 =
    case v7  {
        Us0Idle -> {
            3
        }
        Us0Note(v9) -> {
            6
        }
        Us0Text(v8) -> {
            5
        }
    }
let v13 = spiral_wrap_signed(v6 + v12, 32)
let v14 = spiral_wrap_signed(v13 + 31, 32)
v14
}
