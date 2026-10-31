import gary
import gary/array
import gleam/list
import gleam/option
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

pub type Mut0 { Mut0(l0 : String) }
pub fn main() {
    let v0 = "no"
    let v1 = spiral_ref_new(Mut0(l0: v0))
    let v2 = "hi"
    spiral_ref_set(v1, Mut0(l0: v2))
    let v3 = spiral_ref_get(v1).l0
    let v4 = v3 == "hi"
    case v4 {
        True -> 0
        False -> 1
    }
}
