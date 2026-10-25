import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Heap0 { Heap0(l0 : fn(Int) -> Int) }
pub fn f_c0(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = spiral_wrap_signed(v1 + v0, 32)
        v2
    }
}
pub fn main() {
let v0 = 3
let v1 = f_c0(#(v0))
let v2 = Heap0(l0: v1)
let v3 = v2.l0
let v4 = v3( 4  )
let v5 = v4 == 7
case v5 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
