import gleam/list
import gleam/option
import gleam/int
pub type SpiralArrayStore(a)

pub type SpiralArray(a) {
  SpiralArray(store: SpiralArrayStore(option.Option(a)), size: Int)
}

@external(erlang, "main_ffi", "array_new")
@external(javascript, "./main_ffi.mjs", "array_new")
pub fn spiral_array_store_new(size: Int, fill: a) -> SpiralArrayStore(a)




pub fn spiral_array_create_filled(size: Int, value: a) -> SpiralArray(a) {
  SpiralArray(store: spiral_array_store_new(size, option.Some(value)), size: size)
}





pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Uh0 {
    Uh0Nil
    Uh0Cons(SpiralArray(Int), Uh0)
}
pub fn sum_0(v0: Uh0) -> Int {
    case v0  {
        Uh0Cons(v1, v2) -> {
            let v3 = v1.size
            let v4 = sum_0(v2)
            spiral_wrap_signed(v3 + v4, 32)
        }
        Uh0Nil -> 0
    }
}
pub fn main() {
    let v1 = spiral_array_create_filled(2, 0)
    let v3 = Uh0Cons(v1, Uh0Nil)
    let v4 = Uh0Cons(v1, v3)
    let v5 = sum_0(v4)
    spiral_wrap_signed(v5 - 4, 32)
}
