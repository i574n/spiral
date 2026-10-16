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
}
pub fn closure0(capt: Nil) -> fn(Int) -> Us0 {
    fn (v0) {
        let v1 = "managed"
        Us0Text(v1)
    }
}
pub fn method0(v0: fn(Int) -> Us0) -> Us0 {
    v0( 2  )
}
pub fn main() {
let v0 = closure0(Nil)
let v1 = method0(v0)
let v4 =
    case v1  {
        Us0Idle -> {
            3
        }
        Us0Text(v2) -> {
            11
        }
    }
let v5 = spiral_wrap_signed(v4 + 31, 32)
v5
}
