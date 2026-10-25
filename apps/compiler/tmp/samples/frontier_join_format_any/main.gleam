import gleam/string
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
pub fn format_real_2(v0: Int) -> String {
    let v1 = ""
    let v2 = spiral_ref_new(Mut0(l0: v1))
    let v3 = string.inspect(v0)
    let v4 = spiral_ref_get(v2).l0
    let v5 = v4 <> v3 
    spiral_ref_set(v2, Mut0(l0: v5))
    let v6 = spiral_ref_get(v2).l0
    v6
}
pub fn method1() -> String {
    let v0 = "Some"
    let v1 = "("
    let v2 = v0 <> v1 
    let v3 = 1
    let v4 = format_real_2(v3)
    let v5 = v2 <> v4 
    let v6 = ")"
    let v7 = v5 <> v6 
    v7
}
pub fn method0() -> String {
    let v0 = method1()
    let v1 = "x: "
    let v2 = v1 <> v0 
    v2
}
pub fn main() {
    let v0 = method0()
    let v1 = v0 == ""
    case v1 {
        True -> {
            1
        }
        False -> {
            0
        }
    }
}
