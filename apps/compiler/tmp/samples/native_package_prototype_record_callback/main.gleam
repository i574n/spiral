import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  case value >= 0 - half && value < half {
    True -> value
    False -> int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
  }
}

pub fn spiral_wrap_i32(value: Int) -> Int {
  case value >= -2147483648 && value <= 2147483647 {
    True -> value
    False -> spiral_wrap_signed(value, 32)
  }
}


pub fn closure0(capt: #(Int)) -> fn(#(Int, Int)) -> #(Int, Int) {
    fn (dom) {
        let #(v1, v2) = dom
        let #(v0) = capt
        let v3 = spiral_wrap_i32(v1 - 8)
        let v4 = spiral_wrap_i32(v3 + v0)
        let v5 = spiral_wrap_i32(v2 - 18)
        #(v4, v5)
    }
}
pub fn method0(v0: fn(#(Int, Int)) -> #(Int, Int)) -> #(Int, Int) {
    v0(#(10, 20))
}
pub fn main() {
    let v1 = closure0(#(1))
    let #(v2, v3) = method0(v1)
    let v4 = spiral_wrap_i32(10 + v2)
    let v5 = spiral_wrap_i32(20 + v3)
    let v6 = spiral_wrap_i32(v4 + v5)
    spiral_wrap_i32(v6 + 7)
}
