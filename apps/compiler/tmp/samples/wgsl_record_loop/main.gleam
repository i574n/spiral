import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn loop_0(v0: Int, v1: Int, v2: Int, v3: Int) -> #(Int, Int) {
    let v4 = v1 >= v0
    let #(v9, v10) =
        case v4 {
            True -> #(v2, v3)
            False -> {
                let v5 = spiral_wrap_signed(v1 + 1, 32)
                let v6 = spiral_wrap_signed(v2 + 1, 32)
                let #(v7, v8) = loop_0(v0, v5, v6, v3)
                #(v7, v8)
            }
        }
    #(v9, v10)
}
pub fn main() {
    let v0 = 5
    let v1 = 0
    let v2 = 1
    let v3 = 2
    let #(v4, v5) = loop_0(v0, v1, v2, v3)
    let v6 = spiral_wrap_signed(v4 + v5, 32)
    v6
}
