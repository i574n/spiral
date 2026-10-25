import gary
import gary/array
import gleam/list
import gleam/option
import gleam/int
pub type SpiralArrayKey

pub type SpiralArray(a) {
  SpiralArray(key: SpiralArrayKey, size: Int)
}

@external(erlang, "erlang", "make_ref")
pub fn spiral_array_new_key() -> SpiralArrayKey

@external(erlang, "erlang", "put")
pub fn spiral_array_store(key: SpiralArrayKey, storage: gary.ErlangArray(option.Option(a))) -> b


pub fn spiral_array_from_storage(storage: gary.ErlangArray(option.Option(a)), size: Int) -> SpiralArray(a) {
  let key = spiral_array_new_key()
  let _ = spiral_array_store(key, storage)
  SpiralArray(key: key, size: size)
}


pub fn spiral_array_create_filled(size: Int, value: a) -> SpiralArray(a) {
  list.repeat(option.Some(value), size) |> array.from_list(option.None) |> spiral_array_from_storage(size)
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
            let v5 = spiral_wrap_signed(v3 + v4, 32)
            v5
        }
        Uh0Nil -> {
            0
        }
    }
}
pub fn main() {
    let v0 = 2
    let v1 = spiral_array_create_filled(v0, 0)
    let v2 = Uh0Nil
    let v3 = Uh0Cons(v1, v2)
    let v4 = Uh0Cons(v1, v3)
    let v5 = sum_0(v4)
    let v6 = spiral_wrap_signed(v5 - 4, 32)
    v6
}
