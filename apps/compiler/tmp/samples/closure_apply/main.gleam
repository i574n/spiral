import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn f_c0(capt: Nil) -> fn(Int) -> Int {
    fn (v0) {
        let v1 = spiral_wrap_signed(v0 + 1, 32)
        v1
    }
}
pub fn main() {
let v0 = f_c0(Nil)
let v1 = v0( 6  )
let v2 = v1 == 7
case v2 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
