import Base

def spiral_i32_bias(+x: U32) -> U32:
  U32.xor(x, 2147483648)

def spiral_i32_lt(+a: U32, +b: U32) -> Bool:
  U32.is_lt(spiral_i32_bias(a), spiral_i32_bias(b))

def spiral_i32_le(+a: U32, +b: U32) -> Bool:
  U32.is_le(spiral_i32_bias(a), spiral_i32_bias(b))

def spiral_i32_gt(+a: U32, +b: U32) -> Bool:
  U32.is_gt(spiral_i32_bias(a), spiral_i32_bias(b))

def spiral_i32_ge(+a: U32, +b: U32) -> Bool:
  U32.is_ge(spiral_i32_bias(a), spiral_i32_bias(b))

def spiral_i32_is_negative(+x: U32) -> Bool:
  U32.is_ge(x, 2147483648)

def spiral_i32_negate_if(+c: Bool, +x: U32) -> U32:
  match c:
    case True{}:
      U32.sub(0, x)
    case False{}:
      x

def spiral_i32_abs(+x: U32) -> U32:
  spiral_i32_negate_if(spiral_i32_is_negative(x), x)

def spiral_i32_div(+a: U32, +b: U32) -> U32:
  spiral_i32_negate_if(Bool.xor(spiral_i32_is_negative(a), spiral_i32_is_negative(b)), U32.div(spiral_i32_abs(a), spiral_i32_abs(b)))

def spiral_i32_mod(+a: U32, +b: U32) -> U32:
  spiral_i32_negate_if(spiral_i32_is_negative(a), U32.mod(spiral_i32_abs(a), spiral_i32_abs(b)))

def spiral_i32_shift_right_if(+c: Bool, +a: U32, +n: U32) -> U32:
  match c:
    case True{}:
      U32.not(U32.shrn(U32.not(a), U32.to_nat(n)))
    case False{}:
      U32.shrn(a, U32.to_nat(n))

def spiral_i32_shift_right(+a: U32, +n: U32) -> U32:
  spiral_i32_shift_right_if(spiral_i32_is_negative(a), a, n)

def spiral_i32_show_if(+c: Bool, +x: U32) -> String:
  match c:
    case True{}:
      "-" ++ U32.show(U32.sub(0, x))
    case False{}:
      U32.show(x)

def spiral_i32_show(+x: U32) -> String:
  spiral_i32_show_if(spiral_i32_is_negative(x), x)
def spiral_utf8_width_from(+c: U32, +below_2: Bool, +below_3: Bool, +below_4: Bool) -> U32:
  match below_2:
    case True{}:
      {1 : U32}
    case False{}:
      match below_3:
        case True{}:
          {2 : U32}
        case False{}:
          match below_4:
            case True{}:
              {3 : U32}
            case False{}:
              {4 : U32}

def spiral_utf8_width(+c: U32) -> U32:
  spiral_utf8_width_from(c, U32.is_lt(c, 128), U32.is_lt(c, 2048), U32.is_lt(c, 65536))

def spiral_utf8_lead_mask(+single: Bool, +w: U32) -> U32:
  match single:
    case True{}:
      {0 : U32}
    case False{}:
      U32.and(U32.shln(255, U32.to_nat(U32.sub(8, w))), 255)

def spiral_utf8_byte_from(+lead: Bool, +c: U32, +w: U32, +k: U32) -> U32:
  match lead:
    case True{}:
      U32.or(spiral_utf8_lead_mask(U32.is_eq(w, 1), w), U32.shrn(c, U32.to_nat(U32.mul(6, U32.sub(w, 1)))))
    case False{}:
      U32.or(128, U32.and(U32.shrn(c, U32.to_nat(U32.mul(6, U32.sub(U32.sub(w, 1), k)))), 63))

def spiral_utf8_byte(+c: U32, +w: U32, +k: U32) -> U32:
  spiral_utf8_byte_from(U32.is_eq(k, 0), c, w, k)

@unsafe
def spiral_string_bytes(+s: String) -> U32:
  match s:
    case SNil{}:
      {0 : U32}
    case SCon{+h, +t}:
      U32.add(spiral_utf8_width(Char.to_u32(h)), spiral_string_bytes(t))

@unsafe
def spiral_string_byte_at_from(+inside: Bool, +c: U32, +w: U32, +i: U32, +t: String) -> U32:
  match inside:
    case True{}:
      spiral_utf8_byte(c, w, i)
    case False{}:
      spiral_string_byte_at(t, U32.sub(i, w))

@unsafe
def spiral_string_byte_at(+s: String, +i: U32) -> U32:
  match s:
    case SNil{}:
      {0 : U32}
    case SCon{+h, +t}:
      spiral_string_byte_at_from(U32.is_lt(i, spiral_utf8_width(Char.to_u32(h))), Char.to_u32(h), spiral_utf8_width(Char.to_u32(h)), i, t)

@unsafe
def spiral_string_keep(+keep: Bool, +h: Char, +rest: String) -> String:
  match keep:
    case True{}:
      SCon{h, rest}
    case False{}:
      rest

@unsafe
def spiral_string_slice_go(+s: String, +offset: U32, +from: U32, +until: U32) -> String:
  match s:
    case SNil{}:
      SNil{}
    case SCon{+h, +t}:
      spiral_string_keep(Bool.and(U32.is_ge(offset, from), U32.is_lt(offset, until)), h, spiral_string_slice_go(t, U32.add(offset, spiral_utf8_width(Char.to_u32(h))), from, until))

@unsafe
def spiral_string_is_boundary(+s: String, +offset: U32, +x: U32) -> Bool:
  match s:
    case SNil{}:
      U32.is_eq(offset, x)
    case SCon{+h, +t}:
      Bool.or(U32.is_eq(offset, x), spiral_string_is_boundary(t, U32.add(offset, spiral_utf8_width(Char.to_u32(h))), x))

def spiral_string_slice_checked(+valid: Bool, +s: String, +from: U32, +until: U32) -> IO(String):
  match valid:
    case True{}:
      IO.pure(String, spiral_string_slice_go(s, {0 : U32}, from, until))
    case False{}:
      IO.die(String, 3, "")

def spiral_string_slice(+s: String, +from: U32, +to: U32) -> IO(String):
  spiral_string_slice_checked(Bool.and(Bool.and(Bool.not(U32.is_ge(from, 2147483648)), U32.is_le(U32.add(to, 1), spiral_string_bytes(s))), Bool.and(Bool.and(U32.is_le(from, U32.add(to, 1)), spiral_string_is_boundary(s, {0 : U32}, from)), spiral_string_is_boundary(s, {0 : U32}, U32.add(to, 1)))), s, from, U32.add(to, 1))

@unsafe
def spiral_i32_to_f32(+value: U32) -> F32:
  spiral_i32_to_f32_signed(value, spiral_i32_is_negative(value))

@unsafe
def spiral_i32_to_f32_signed(+value: U32, negative: Bool) -> F32:
  match negative:
    case True{}:
      F32.neg(U32.to_f32(U32.sub(0, value)))
    case False{}:
      U32.to_f32(value)

@unsafe
def spiral_f32_to_i32(+value: F32) -> U32:
  spiral_f32_to_i32_signed(value, F32.is_lt(value, 0.0))

@unsafe
def spiral_f32_to_i32_signed(+value: F32, negative: Bool) -> U32:
  match negative:
    case True{}:
      U32.sub(0, F32.to_u32(F32.neg(value)))
    case False{}:
      F32.to_u32(value)
@unsafe
def spiral_array_depth_go(+wanted: U32, +size: U32, +depth: U32, done: Bool) -> U32:
  match done:
    case True{}:
      depth
    case False{}:
      spiral_array_depth_go(wanted, U32.shl(size), U32.add(depth, 1), U32.is_le(wanted, U32.shl(size)))

@unsafe
def spiral_array_depth(+wanted: U32) -> U32:
  spiral_array_depth_go(wanted, 1, 0, U32.is_le(wanted, 1))

@unsafe
def method1(+v0: U32) -> IO(U32 & U32 & Bool):
  do IO<U32 & U32 & Bool>:
    +v1 : U32 <- IO.pure(U32, U32.add(v0, {2 : U32}))
    +v2 : Bool <- IO.pure(Bool, spiral_i32_gt(v0, {0 : U32}))
    return (v0, v1, v2)

@unsafe
def method2_if2(+c: Bool, +v0: U32, +v1: U32, +v2: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v3 : U32 <- IO.pure(U32, U32.add(v0, v1))
        +v4 : U32 <- IO.pure(U32, U32.sub(v3, {4 : U32}))
        return v4
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def method2(+v0: U32, +v1: U32, +v2: Bool) -> IO(U32):
  do IO<U32>:
    method2_if2(v2, v0, v1, v2)

@unsafe
def method4(+v0: F32) -> IO(Bool & F32 & U32):
  do IO<Bool & F32 & U32>:
    +v1 : Bool <- IO.pure(Bool, F32.is_ge(v0, 3.5))
    return (v1, v0, {7 : U32})

@unsafe
def method5_if4_if5(+c: Bool, +v0: Bool, +v1: F32, +v2: U32, +v3: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v4 : U32 <- IO.pure(U32, U32.sub(v2, {7 : U32}))
        return v4
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def method5_if4(+c: Bool, +v0: Bool, +v1: F32, +v2: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v3 : Bool <- IO.pure(Bool, F32.is_ge(v1, 3.5))
        method5_if4_if5(v3, v0, v1, v2, v3)
    case False{}:
      do IO<U32>:
        return {2 : U32}

@unsafe
def method5(+v0: Bool, +v1: F32, +v2: U32) -> IO(U32):
  do IO<U32>:
    method5_if4(v0, v0, v1, v2)

@unsafe
def method7(+v0: String) -> IO(Bool):
  do IO<Bool>:
    return True{}

@unsafe
def method9(+v0: U32) -> IO(Bool):
  do IO<Bool>:
    +v1 : U32 <- IO.pure(U32, U32.add(v0, {5 : U32}))
    +v2 : U32 <- IO.pure(U32, U32.mod(v1, {4 : U32}))
    +v3 : Bool <- IO.pure(Bool, U32.is_eq(v2, {0 : U32}))
    return v3

@unsafe
def method11(+v0: U32, +v1: U32) -> IO(U32):
  do IO<U32>:
    +v2 : U32 <- IO.pure(U32, U32.mul(v0, v1))
    +v3 : U32 <- IO.pure(U32, U32.add(v2, {5 : U32}))
    +v4 : U32 <- IO.pure(U32, spiral_i32_div(v3, {3 : U32}))
    return v4

@unsafe
def method10(+v0: U32) -> IO(U32):
  do IO<U32>:
    +v1 : U32 <- IO.pure(U32, {4 : U32})
    +v2 : U32 <- IO.pure(U32, {4 : U32})
    +v3 : U32 <- method11(v1, v2)
    +v4 : U32 <- IO.pure(U32, U32.add(v0, v3))
    +v5 : U32 <- IO.pure(U32, U32.sub(v4, {7 : U32}))
    return v5

@unsafe
def method8_if7(+c: Bool, +v0: U32, +v1: U32, +v2: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        method10(v0)
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def method8(+v0: U32) -> IO(U32):
  do IO<U32>:
    +v1 : U32 <- IO.pure(U32, {7 : U32})
    +v2 : Bool <- method9(v1)
    method8_if7(v2, v0, v1, v2)

@unsafe
def method6_if6(+c: Bool, +v0: U32, +v1: String, +v2: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        method8(v0)
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def method6(+v0: U32) -> IO(U32):
  do IO<U32>:
    +v1 : String <- IO.pure(String, "spiral")
    +v2 : Bool <- method7(v1)
    method6_if6(v2, v0, v1, v2)

@unsafe
def method3_k3(+p: Bool & F32 & U32, +v0: U32, +v1: F32) -> IO(U32):
  (+v2, +v3, +v4) = p
  do IO<U32>:
    +v5 : U32 <- method5(v2, v3, v4)
    +v6 : U32 <- IO.pure(U32, U32.add(v0, v5))
    method6(v6)

@unsafe
def method3(+v0: U32) -> IO(U32):
  do IO<U32>:
    +v1 : F32 <- IO.pure(F32, 4.0)
    +p : Bool & F32 & U32 <- method4(v1)
    method3_k3(p, v0, v1)

@unsafe
def method0_k1(+p: U32 & U32 & Bool, +v0: U32, +v1: U32) -> IO(U32):
  (+v2, +v3, +v4) = p
  do IO<U32>:
    +v5 : U32 <- method2(v2, v3, v4)
    +v6 : U32 <- IO.pure(U32, U32.add(v0, v5))
    method3(v6)

@unsafe
def method0(+v0: U32) -> IO(U32):
  do IO<U32>:
    +v1 : U32 <- IO.pure(U32, {1 : U32})
    +p : U32 & U32 & Bool <- method1(v1)
    method0_k1(p, v0, v1)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {0 : U32})
    method0(v0)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
