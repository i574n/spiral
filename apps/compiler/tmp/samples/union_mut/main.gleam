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

pub type Mut0 { Mut0(l0 : Int) }
pub type Us0 {
    Us0Missing
    Us0Held(f1i0 : SpiralRef(Mut0))
}
pub fn main() {
    let v0 = spiral_ref_new(Mut0(l0: 1))
    let v1 = True
    let v4 =
        case v1 {
            True -> Us0Held(v0)
            False -> Us0Missing
        }
    case v4  {
        Us0Held(v5) -> {
            spiral_ref_set(v5, Mut0(l0: 7))
            let v6 = spiral_ref_get(v5).l0
            let v7 = v6 == 7
            case v7 {
                True -> 0
                False -> 1
            }
        }
        Us0Missing -> 1
    }
}
