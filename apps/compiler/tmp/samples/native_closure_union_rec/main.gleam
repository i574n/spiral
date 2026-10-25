import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Uh0 {
    Uh0Cons(Int, fn(Nil) -> Uh0)
    Uh0Nil
}
pub fn closure0(capt: #(Int)) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let #(v0) = capt
        let v1 = spiral_wrap_unsigned(v0 - 1, 64)
        build_0(v1)
    }
}
pub fn build_0(v0: Int) -> Uh0 {
    let v1 = v0 == 0
    case v1 {
        True -> {
            Uh0Nil
        }
        False -> {
            let v3 = closure0(#(v0))
            Uh0Cons(v0, v3)
        }
    }
}
pub fn sum_1(v0: Uh0, v1: Int) -> Int {
    case v0  {
        Uh0Cons(v2, v3) -> {
            let v4 = v3(Nil)
            let v5 = spiral_wrap_unsigned(v1 + v2, 64)
            sum_1(v4, v5)
        }
        Uh0Nil -> {
            v1
        }
    }
}
pub fn main() {
    let v0 = 10
    let v1 = build_0(v0)
    let v2 = 0
    let v3 = sum_1(v1, v2)
    let v4 = 5
    let v5 = spiral_wrap_signed(v3, 32)
    let v6 = spiral_wrap_signed(v4 * 2, 32)
    let v7 = spiral_wrap_signed(v4 + v6, 32)
    let v8 = spiral_wrap_signed(v5 + v7, 32)
    v8
}
