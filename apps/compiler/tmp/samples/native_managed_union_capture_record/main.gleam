import gary
import gary/array
import gleam/list
import gleam/option
import gleam/int
import gleam/bit_array
import gleam/string
pub type SpiralArrayKey

pub type SpiralArray(a) {
  SpiralArray(key: SpiralArrayKey, size: Int)
}

@external(erlang, "erlang", "make_ref")
pub fn spiral_array_new_key() -> SpiralArrayKey

@external(erlang, "erlang", "put")
pub fn spiral_array_store(key: SpiralArrayKey, storage: gary.ErlangArray(option.Option(a))) -> b

@external(erlang, "erlang", "get")
pub fn spiral_array_load(key: SpiralArrayKey) -> gary.ErlangArray(option.Option(a))

pub fn spiral_array_from_storage(storage: gary.ErlangArray(option.Option(a)), size: Int) -> SpiralArray(a) {
  let key = spiral_array_new_key()
  let _ = spiral_array_store(key, storage)
  SpiralArray(key: key, size: size)
}

pub fn spiral_array_create(size: Int) -> SpiralArray(a) {
  list.repeat(option.None, size) |> array.from_list(option.None) |> spiral_array_from_storage(size)
}

pub fn spiral_array_from_list(values: List(a)) -> SpiralArray(a) {
  values |> list.map(option.Some) |> array.from_list(option.None) |> spiral_array_from_storage(list.length(values))
}

pub fn spiral_array_get(xs: SpiralArray(a), i: Int) -> a {
  case i >= 0 && i < xs.size {
    True ->
      case spiral_array_load(xs.key) |> array.get(i) {
        Ok(option.Some(x)) -> x
        _ -> panic as "spiral array: read of an element that was never set"
      }
    False -> panic as "spiral array: index out of bounds"
  }
}

pub fn spiral_array_set(xs: SpiralArray(a), i: Int, value: a) -> Nil {
  case i >= 0 && i < xs.size {
    True -> {
      let assert Ok(storage) = spiral_array_load(xs.key) |> array.set(i, option.Some(value))
      let _ = spiral_array_store(xs.key, storage)
      Nil
    }
    False -> panic as "spiral array: index out of bounds"
  }
}

pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn spiral_int_power(base: Int, exponent: Int) -> Int {
  case exponent <= 0 {
    True -> 1
    False -> base * spiral_int_power(base, exponent - 1)
  }
}

@external(erlang, "math", "pow")
pub fn spiral_math_pow(base: Float, exponent: Float) -> Float

@external(erlang, "erlang", "halt")
pub fn spiral_halt(code: Int) -> a

pub fn spiral_string_length(text: String) -> Int {
  bit_array.byte_size(bit_array.from_string(text))
}

pub fn spiral_string_index(text: String, index: Int) -> String {
  case bit_array.slice(bit_array.from_string(text), index, 1) {
    Ok(<<byte>>) ->
      case string.utf_codepoint(byte) {
        Ok(codepoint) -> string.from_utf_codepoints([codepoint])
        Error(_) -> spiral_halt(3)
      }
    _ -> spiral_halt(3)
  }
}

pub fn spiral_string_slice(text: String, from: Int, to: Int) -> String {
  let bytes = bit_array.from_string(text)
  let length = bit_array.byte_size(bytes)
  case from < 0 || from > length || to < from - 1 || to >= length {
    True -> spiral_halt(3)
    False ->
      case to < from {
        True -> ""
        False ->
          case bit_array.slice(bytes, from, to - from + 1) {
            Ok(part) ->
              case bit_array.to_string(part) {
                Ok(slice) -> slice
                Error(_) -> spiral_halt(3)
              }
            Error(_) -> spiral_halt(3)
          }
      }
  }
}

pub type Us0 {
    Us0i0
    Us0i1(f1i0 : String, f1i1 : SpiralArray(Int))
}
pub fn closure1(capt: #(Us0)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v12 =
            case v0  {
                Us0i0 -> {
                    3
                }
                Us0i1(v2, v3) -> {
                    let v4 = spiral_string_length(v2)
                    let v5 = v3.size
                    let v6 = spiral_wrap_signed(v4 + v5, 32)
                    let v7 = spiral_array_get(v3, 0)
                    let v8 = spiral_wrap_signed(v6 + v7, 32)
                    let v9 = spiral_array_get(v3, 1)
                    let v10 = spiral_wrap_signed(v8 + v9, 32)
                    v10
                }
            }
        let v13 = spiral_wrap_signed(v12 + v1, 32)
        v13
    }
}
pub fn closure0(capt: Nil) -> fn(Int) -> fn(Int) -> Int {
    fn (v0) {
        let v1 = spiral_array_create(2)
        spiral_array_set(v1, 0, v0)
        let v2 = spiral_wrap_signed(v0 + 1, 32)
        spiral_array_set(v1, 1, v2)
        let v3 = v0 == 0
        let v7 =
            case v3 {
                True -> {
                    Us0i0
                }
                False -> {
                    let v5 = "hi"
                    Us0i1(v5, v1)
                }
            }
        closure1(#(v7))
    }
}
pub fn method0(v0: fn(Int) -> fn(Int) -> Int) -> fn(Int) -> Int {
    v0( 0  )
}
pub fn method1(v0: fn(Int) -> fn(Int) -> Int) -> fn(Int) -> Int {
    v0( 4  )
}
pub fn method4(v0: fn(Int) -> Int) -> Int {
    let v1 = v0( 2  )
    let v2 = spiral_wrap_signed(v1 + 5, 32)
    v2
}
pub fn method3(v0: fn(Int) -> Int) -> Int {
    let v1 = v0( 1  )
    let v2 = method4(v0)
    let v3 = spiral_wrap_signed(v1 + v2, 32)
    v3
}
pub fn method2(v0: fn(Int) -> Int, v1: fn(Int) -> Int) -> Int {
    let v2 = v0( 5  )
    let v3 = method3(v1)
    let v4 = spiral_wrap_signed(v2 + v3, 32)
    v4
}
pub fn main() {
let v0 = closure0(Nil)
let v1 = method0(v0)
let v2 = method1(v0)
method2(v1, v2)
}
