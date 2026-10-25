import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Uh0 {
    Uh0Link(Int, Uh0)
    Uh0End
}
pub fn build_0(v0: Int, v1: Uh0) -> Uh0 {
    let v2 = v0 == 0
    case v2 {
        True -> {
            v1
        }
        False -> {
            let v3 = spiral_wrap_signed(v0 - 1, 32)
            let v4 = Uh0Link(v0, v1)
            build_0(v3, v4)
        }
    }
}
pub fn sum_1(v0: Uh0, v1: Int) -> Int {
    case v0  {
        Uh0End -> {
            v1
        }
        Uh0Link(v2, v3) -> {
            let v4 = spiral_wrap_signed(v1 * 31, 32)
            let v5 = spiral_wrap_signed(v4 + v2, 32)
            let v6 = v5 % 9973
            sum_1(v3, v6)
        }
    }
}
pub fn main() {
    let v0 = 1000000
    let v1 = Uh0End
    let v2 = build_0(v0, v1)
    let v3 = 0
    let v4 = sum_1(v2, v3)
    let v5 = v4 % 256
    v5
}
