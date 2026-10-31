import gary
import gary/array
import gleam/list
import gleam/option
import gleam/int
import gleam/io
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


pub type Mut0 { Mut0(l0 : String) }
pub fn main() {
    let v0 = "deref"
    let v1 = spiral_ref_new(Mut0(l0: v0))
    let v2 = 3
    let v3 = "deref!"
    spiral_ref_set(v1, Mut0(l0: v3))
    let v4 = spiral_ref_get(v1).l0
    let v5 = v2 == 3
    let v7 =
        case v5 {
            True -> {
                let v6 = spiral_wrap_signed(v2 + 1, 32)
                v6
            }
            False -> 0
        }
    io.print(v4 <> " " <> int.to_string(v7) <> "\n")
    let v8 = spiral_wrap_signed(v2 * 2, 32)
    let v9 = v2 > 0
    let v10 =
        case v9 {
            True -> 6
            False -> 0
        }
    let v11 = v8 == v10
    case v11 {
        True -> 0
        False -> 1
    }
}
