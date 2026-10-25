import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn f_c0(capt: Nil) -> fn(Int) -> #(Int, Int) {
    fn (v0) {
        let v1 = spiral_wrap_signed(v0 + 1, 32)
        #(v0, v1)
    }
}
pub fn main() {
let v0 = 3
let v1 = f_c0(Nil)
let #(v2, v3) = v1( v0  )
let v4 = v2 == 3
let v6 =
    case v4 {
        True -> {
            let v5 = v3 == 4
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
