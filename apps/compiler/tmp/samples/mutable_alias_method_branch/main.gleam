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










pub type SpiralRef(a) {
  SpiralRef(key: SpiralArrayKey)
}

@external(erlang, "erlang", "put")
pub fn spiral_ref_store(key: SpiralArrayKey, value: a) -> b

@external(erlang, "erlang", "get")
pub fn spiral_ref_load(key: SpiralArrayKey) -> a

pub fn spiral_ref_new(value: a) -> SpiralRef(a) {
  let key = spiral_array_new_key()
  let _ = spiral_ref_store(key, value)
  SpiralRef(key: key)
}

pub fn spiral_ref_get(reference: SpiralRef(a)) -> a {
  spiral_ref_load(reference.key)
}

pub fn spiral_ref_set(reference: SpiralRef(a), value: a) -> Nil {
  let _ = spiral_ref_store(reference.key, value)
  Nil
}

pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Mut0 { Mut0(l0 : Int) }
pub fn method0(v0: SpiralRef(Mut0)) -> Nil {
    let v1 = spiral_ref_get(v0).l0
    let v2 = spiral_wrap_signed(v1 + 5, 32)
    spiral_ref_set(v0, Mut0(l0: v2))
    Nil
}
pub fn method1(_v0: SpiralRef(Mut0)) -> Nil {
    Nil
}
pub fn method2(v0: SpiralRef(Mut0)) -> Nil {
    let v1 = spiral_ref_get(v0).l0
    let v2 = spiral_wrap_signed(v1 + 7, 32)
    spiral_ref_set(v0, Mut0(l0: v2))
    Nil
}
pub fn main() {
    let v0 = spiral_ref_new(Mut0(l0: 0))
    method0(v0)
    method1(v0)
    method2(v0)
    let v1 = spiral_ref_get(v0).l0
    let v2 = spiral_wrap_signed(v1 - 12, 32)
    v2
}
