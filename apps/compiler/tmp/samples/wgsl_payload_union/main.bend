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
  spiral_string_slice_checked(Bool.and(Bool.and(Bool.not(U32.is_ge(from, 2147483648)), U32.is_le(U32.add(to, 1), spiral_string_bytes(s))), Bool.and(U32.is_le(from, U32.add(to, 1)), Bool.or(U32.is_eq(from, U32.add(to, 1)), Bool.and(spiral_string_is_boundary(s, {0 : U32}, from), spiral_string_is_boundary(s, {0 : U32}, U32.add(to, 1)))))), s, from, U32.add(to, 1))

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

type U0 is Data:
  U0_Circle{f0: U32}
  U0_Rect{f0: U32, f1: U32}
  U0_Empty{}

@unsafe
def spiral_main_unbox1_if2(+c: Bool, +v0: U32, +v1: U0, +v2: U32, +v3: U32, +v4: U0, +v5: U0, +v6: U32, +v7: U0, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v16 : Bool <- IO.pure(Bool, U32.is_eq(v12, v14))
        return v16
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_unbox1(+u: U0, +u1: U0, +v0: U32, +v1: U0, +v2: U32, +v3: U32, +v4: U0, +v5: U0, +v6: U32, +v7: U0) -> IO(Bool):
  match u:
    case U0_Circle{+v8}:
      match u1:
        case U0_Circle{+v9}:
          do IO<Bool>:
            +v10 : Bool <- IO.pure(Bool, U32.is_eq(v8, v9))
            return v10
        case U0_Rect{unused0, unused1}:
          do IO<Bool>:
            return False{}
        case U0_Empty{}:
          do IO<Bool>:
            return False{}
    case U0_Rect{+v11, +v12}:
      match u1:
        case U0_Circle{unused0}:
          do IO<Bool>:
            return False{}
        case U0_Rect{+v13, +v14}:
          do IO<Bool>:
            +v15 : Bool <- IO.pure(Bool, U32.is_eq(v11, v13))
            spiral_main_unbox1_if2(v15, v0, v1, v2, v3, v4, v5, v6, v7, v11, v12, v13, v14, v15)
        case U0_Empty{}:
          do IO<Bool>:
            return False{}
    case U0_Empty{}:
      match u1:
        case U0_Circle{unused0}:
          do IO<Bool>:
            return False{}
        case U0_Rect{unused0, unused1}:
          do IO<Bool>:
            return False{}
        case U0_Empty{}:
          do IO<Bool>:
            return True{}

@unsafe
def spiral_main_if3(+c: Bool, +v0: U32, +v1: U0, +v2: U32, +v3: U32, +v4: U0, +v5: U0, +v6: U32, +v7: U0, +v18: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {100 : U32}
    case False{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main_unbox4(+u: U0, +v0: U32, +v1: U0, +v2: U32, +v3: U32, +v4: U0, +v5: U0, +v6: U32, +v7: U0, +v18: Bool, +v19: U32) -> IO(U32):
  match u:
    case U0_Circle{+v20}:
      do IO<U32>:
        +v21 : U32 <- IO.pure(U32, U32.mul({3 : U32}, v20))
        +v22 : U32 <- IO.pure(U32, U32.mul(v21, v20))
        return v22
    case U0_Rect{+v23, +v24}:
      do IO<U32>:
        +v25 : U32 <- IO.pure(U32, U32.mul(v23, v24))
        return v25
    case U0_Empty{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main_unbox5(+u: U0, +v0: U32, +v1: U0, +v2: U32, +v3: U32, +v4: U0, +v5: U0, +v6: U32, +v7: U0, +v18: Bool, +v19: U32, +v28: U32) -> IO(U32):
  match u:
    case U0_Circle{+v29}:
      do IO<U32>:
        +v30 : U32 <- IO.pure(U32, U32.mul({3 : U32}, v29))
        +v31 : U32 <- IO.pure(U32, U32.mul(v30, v29))
        return v31
    case U0_Rect{+v32, +v33}:
      do IO<U32>:
        +v34 : U32 <- IO.pure(U32, U32.mul(v32, v33))
        return v34
    case U0_Empty{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main_unbox6(+u: U0, +v0: U32, +v1: U0, +v2: U32, +v3: U32, +v4: U0, +v5: U0, +v6: U32, +v7: U0, +v18: Bool, +v19: U32, +v28: U32, +v37: U32, +v38: U32) -> IO(U32):
  match u:
    case U0_Circle{+v39}:
      do IO<U32>:
        +v40 : U32 <- IO.pure(U32, U32.mul({3 : U32}, v39))
        +v41 : U32 <- IO.pure(U32, U32.mul(v40, v39))
        return v41
    case U0_Rect{+v42, +v43}:
      do IO<U32>:
        +v44 : U32 <- IO.pure(U32, U32.mul(v42, v43))
        return v44
    case U0_Empty{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {2 : U32})
    +v1 : U0 <- IO.pure(U0, U0_Circle{v0})
    +v2 : U32 <- IO.pure(U32, {3 : U32})
    +v3 : U32 <- IO.pure(U32, {4 : U32})
    +v4 : U0 <- IO.pure(U0, U0_Rect{v2, v3})
    +v5 : U0 <- IO.pure(U0, U0_Empty{})
    +v6 : U32 <- IO.pure(U32, {2 : U32})
    +v7 : U0 <- IO.pure(U0, U0_Circle{v6})
    +v18 : Bool <- spiral_main_unbox1(v1, v7, v0, v1, v2, v3, v4, v5, v6, v7)
    +v19 : U32 <- spiral_main_if3(v18, v0, v1, v2, v3, v4, v5, v6, v7, v18)
    +v28 : U32 <- spiral_main_unbox4(v1, v0, v1, v2, v3, v4, v5, v6, v7, v18, v19)
    +v37 : U32 <- spiral_main_unbox5(v4, v0, v1, v2, v3, v4, v5, v6, v7, v18, v19, v28)
    +v38 : U32 <- IO.pure(U32, U32.add(v28, v37))
    +v47 : U32 <- spiral_main_unbox6(v5, v0, v1, v2, v3, v4, v5, v6, v7, v18, v19, v28, v37, v38)
    +v48 : U32 <- IO.pure(U32, U32.add(v38, v47))
    +v49 : U32 <- IO.pure(U32, U32.add(v48, v19))
    return v49

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
