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


pub fn f_c0(capt: #(SpiralArray(Int))) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = v0.size
        spiral_wrap_signed(v2 + v1, 32)
    }
}
pub fn main() {
    let v0 = spiral_array_create_filled(2, 0)
    let v1 = f_c0(#(v0))
    v1(40)
}
