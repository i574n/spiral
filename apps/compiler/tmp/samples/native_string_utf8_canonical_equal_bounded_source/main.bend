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

@unsafe
def runtime_byte_2(+v0: String, +v1: U32) -> IO(U32):
  do IO<U32>:
    +v2 : U32 <- IO.pure(U32, spiral_string_byte_at(v0, v1))
    return v2

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if9_if10(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v13: U32, +v14: Bool, +v16: U32, +v17: U32, +v18: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v19 : Bool <- IO.pure(Bool, spiral_i32_lt(v17, {192 : U32}))
        return v19

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if9_if11(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v13: U32, +v14: Bool, +v16: U32, +v17: U32, +v18: Bool, +v20: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v21 : U32 <- IO.pure(U32, U32.sub(v8, {192 : U32}))
        +v22 : U32 <- IO.pure(U32, U32.mul(v21, {64 : U32}))
        +v23 : U32 <- IO.pure(U32, U32.sub(v17, {128 : U32}))
        +v24 : U32 <- IO.pure(U32, U32.add(v22, v23))
        return v24
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if9(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v13: U32, +v14: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is truncated.")
    case False{}:
      do IO<U32>:
        +v16 : U32 <- runtime_byte_2(v0, v13)
        +v17 : U32 <- IO.pure(U32, v16)
        +v18 : Bool <- IO.pure(Bool, spiral_i32_lt(v17, {128 : U32}))
        +v20 : Bool <- utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if9_if10(v18, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v13, v14, v16, v17, v18)
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if9_if11(v20, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v13, v14, v16, v17, v18, v20)

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if14(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v38 : Bool <- IO.pure(Bool, spiral_i32_lt(v34, {192 : U32}))
        return v38

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if15_if16(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool, +v39: Bool, +v40: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v41 : Bool <- IO.pure(Bool, spiral_i32_lt(v36, {192 : U32}))
        return v41

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if15_if17_if18_if19_if20(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool, +v39: Bool, +v40: Bool, +v42: Bool, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v52: Bool, +v53: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence encodes a surrogate.")
    case False{}:
      do IO<U32>:
        return v49

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if15_if17_if18_if19(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool, +v39: Bool, +v40: Bool, +v42: Bool, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v52: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v53 : Bool <- IO.pure(Bool, spiral_i32_le(v49, {57343 : U32}))
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if15_if17_if18_if19_if20(v53, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37, v39, v40, v42, v43, v44, v45, v46, v47, v48, v49, v50, v52, v53)
    case False{}:
      do IO<U32>:
        return v49

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if15_if17_if18(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool, +v39: Bool, +v40: Bool, +v42: Bool, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is overlong.")
    case False{}:
      do IO<U32>:
        +v52 : Bool <- IO.pure(Bool, spiral_i32_ge(v49, {55296 : U32}))
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if15_if17_if18_if19(v52, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37, v39, v40, v42, v43, v44, v45, v46, v47, v48, v49, v50, v52)

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if15_if17(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool, +v39: Bool, +v40: Bool, +v42: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v43 : U32 <- IO.pure(U32, U32.sub(v8, {224 : U32}))
        +v44 : U32 <- IO.pure(U32, U32.mul(v43, {4096 : U32}))
        +v45 : U32 <- IO.pure(U32, U32.sub(v34, {128 : U32}))
        +v46 : U32 <- IO.pure(U32, U32.mul(v45, {64 : U32}))
        +v47 : U32 <- IO.pure(U32, U32.add(v44, v46))
        +v48 : U32 <- IO.pure(U32, U32.sub(v36, {128 : U32}))
        +v49 : U32 <- IO.pure(U32, U32.add(v47, v48))
        +v50 : Bool <- IO.pure(Bool, spiral_i32_lt(v49, {2048 : U32}))
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if15_if17_if18(v50, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37, v39, v40, v42, v43, v44, v45, v46, v47, v48, v49, v50)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if15(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool, +v39: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v40 : Bool <- IO.pure(Bool, spiral_i32_lt(v36, {128 : U32}))
        +v42 : Bool <- utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if15_if16(v40, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37, v39, v40)
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if15_if17(v42, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37, v39, v40, v42)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is truncated.")
    case False{}:
      do IO<U32>:
        +v32 : U32 <- IO.pure(U32, U32.add(v1, {1 : U32}))
        +v33 : U32 <- runtime_byte_2(v0, v32)
        +v34 : U32 <- IO.pure(U32, v33)
        +v35 : U32 <- runtime_byte_2(v0, v29)
        +v36 : U32 <- IO.pure(U32, v35)
        +v37 : Bool <- IO.pure(Bool, spiral_i32_lt(v34, {128 : U32}))
        +v39 : Bool <- utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if14(v37, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37)
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13_if15(v39, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37, v39)

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if23(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v76 : Bool <- IO.pure(Bool, spiral_i32_lt(v69, {192 : U32}))
        return v76

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24_if25(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool, +v78: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v79 : Bool <- IO.pure(Bool, spiral_i32_lt(v72, {192 : U32}))
        return v79

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24_if26_if27(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool, +v78: Bool, +v80: Bool, +v81: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v82 : Bool <- IO.pure(Bool, spiral_i32_lt(v74, {192 : U32}))
        return v82

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24_if26_if28_if29_if30(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool, +v78: Bool, +v80: Bool, +v81: Bool, +v83: Bool, +v84: U32, +v85: U32, +v86: U32, +v87: U32, +v88: U32, +v89: U32, +v90: U32, +v91: U32, +v92: U32, +v93: U32, +v94: Bool, +v96: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 scalar is above U+10FFFF.")
    case False{}:
      do IO<U32>:
        return v93

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24_if26_if28_if29(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool, +v78: Bool, +v80: Bool, +v81: Bool, +v83: Bool, +v84: U32, +v85: U32, +v86: U32, +v87: U32, +v88: U32, +v89: U32, +v90: U32, +v91: U32, +v92: U32, +v93: U32, +v94: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is overlong.")
    case False{}:
      do IO<U32>:
        +v96 : Bool <- IO.pure(Bool, spiral_i32_gt(v93, {1114111 : U32}))
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24_if26_if28_if29_if30(v96, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77, v78, v80, v81, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v96)

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24_if26_if28(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool, +v78: Bool, +v80: Bool, +v81: Bool, +v83: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v84 : U32 <- IO.pure(U32, U32.sub(v8, {240 : U32}))
        +v85 : U32 <- IO.pure(U32, U32.mul(v84, {262144 : U32}))
        +v86 : U32 <- IO.pure(U32, U32.sub(v69, {128 : U32}))
        +v87 : U32 <- IO.pure(U32, U32.mul(v86, {4096 : U32}))
        +v88 : U32 <- IO.pure(U32, U32.add(v85, v87))
        +v89 : U32 <- IO.pure(U32, U32.sub(v72, {128 : U32}))
        +v90 : U32 <- IO.pure(U32, U32.mul(v89, {64 : U32}))
        +v91 : U32 <- IO.pure(U32, U32.add(v88, v90))
        +v92 : U32 <- IO.pure(U32, U32.sub(v74, {128 : U32}))
        +v93 : U32 <- IO.pure(U32, U32.add(v91, v92))
        +v94 : Bool <- IO.pure(Bool, spiral_i32_lt(v93, {65536 : U32}))
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24_if26_if28_if29(v94, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77, v78, v80, v81, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24_if26(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool, +v78: Bool, +v80: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v81 : Bool <- IO.pure(Bool, spiral_i32_lt(v74, {128 : U32}))
        +v83 : Bool <- utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24_if26_if27(v81, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77, v78, v80, v81)
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24_if26_if28(v83, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77, v78, v80, v81, v83)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v78 : Bool <- IO.pure(Bool, spiral_i32_lt(v72, {128 : U32}))
        +v80 : Bool <- utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24_if25(v78, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77, v78)
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24_if26(v80, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77, v78, v80)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is truncated.")
    case False{}:
      do IO<U32>:
        +v67 : U32 <- IO.pure(U32, U32.add(v1, {1 : U32}))
        +v68 : U32 <- runtime_byte_2(v0, v67)
        +v69 : U32 <- IO.pure(U32, v68)
        +v70 : U32 <- IO.pure(U32, U32.add(v1, {2 : U32}))
        +v71 : U32 <- runtime_byte_2(v0, v70)
        +v72 : U32 <- IO.pure(U32, v71)
        +v73 : U32 <- runtime_byte_2(v0, v64)
        +v74 : U32 <- IO.pure(U32, v73)
        +v75 : Bool <- IO.pure(Bool, spiral_i32_lt(v69, {128 : U32}))
        +v77 : Bool <- utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if23(v75, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75)
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22_if24(v77, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77)

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v64 : U32 <- IO.pure(U32, U32.add(v1, {3 : U32}))
        +v65 : Bool <- IO.pure(Bool, spiral_i32_ge(v64, v2))
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21_if22(v65, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 scalar starts with an invalid lead byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v29 : U32 <- IO.pure(U32, U32.add(v1, {2 : U32}))
        +v30 : Bool <- IO.pure(Bool, spiral_i32_ge(v29, v2))
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if13(v30, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30)
    case False{}:
      do IO<U32>:
        +v63 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {245 : U32}))
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12_if21(v63, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63)

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v13 : U32 <- IO.pure(U32, U32.add(v1, {1 : U32}))
        +v14 : Bool <- IO.pure(Bool, spiral_i32_ge(v13, v2))
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if9(v14, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v13, v14)
    case False{}:
      do IO<U32>:
        +v28 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {240 : U32}))
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8_if12(v28, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28)

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6_if7(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 scalar starts with an invalid lead byte.")
    case False{}:
      do IO<U32>:
        +v12 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {224 : U32}))
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7_if8(v12, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12)

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5_if6(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return v8
    case False{}:
      do IO<U32>:
        +v10 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {194 : U32}))
        utf8_scalar_at_byte_offset_1_if4_if5_if6_if7(v10, v0, v1, v2, v3, v5, v7, v8, v9, v10)

@unsafe
def utf8_scalar_at_byte_offset_1_if4_if5(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 byte offset is outside the string.")
    case False{}:
      do IO<U32>:
        +v7 : U32 <- runtime_byte_2(v0, v1)
        +v8 : U32 <- IO.pure(U32, v7)
        +v9 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {128 : U32}))
        utf8_scalar_at_byte_offset_1_if4_if5_if6(v9, v0, v1, v2, v3, v5, v7, v8, v9)

@unsafe
def utf8_scalar_at_byte_offset_1_if4(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 byte offset is negative.")
    case False{}:
      do IO<U32>:
        +v5 : Bool <- IO.pure(Bool, spiral_i32_ge(v1, v2))
        utf8_scalar_at_byte_offset_1_if4_if5(v5, v0, v1, v2, v3, v5)

@unsafe
def utf8_scalar_at_byte_offset_1(+v0: String, +v1: U32) -> IO(U32):
  do IO<U32>:
    +v2 : U32 <- IO.pure(U32, spiral_string_bytes(v0))
    +v3 : Bool <- IO.pure(Bool, spiral_i32_lt(v1, {0 : U32}))
    utf8_scalar_at_byte_offset_1_if4(v3, v0, v1, v2, v3)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if31_if32_if33(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {3 : U32}
    case False{}:
      do IO<U32>:
        return {4 : U32}

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if31_if32(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v16: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {2 : U32}
    case False{}:
      do IO<U32>:
        +v17 : Bool <- IO.pure(Bool, spiral_i32_lt(v14, {65536 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if31_if32_if33(v17, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v16, v17)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if31(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {1 : U32}
    case False{}:
      do IO<U32>:
        +v16 : Bool <- IO.pure(Bool, spiral_i32_lt(v14, {2048 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if31_if32(v16, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v16)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43_if44_if45_if46_if47_if48_if49(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool, +v25: Bool, +v26: Bool, +v27: Bool, +v28: Bool, +v29: Bool, +v30: Bool, +v31: Bool, +v32: Bool, +v33: Bool, +v34: Bool, +v35: Bool, +v36: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({111 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        return (v14, {4294967295 : U32})

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43_if44_if45_if46_if47_if48(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool, +v25: Bool, +v26: Bool, +v27: Bool, +v28: Bool, +v29: Bool, +v30: Bool, +v31: Bool, +v32: Bool, +v33: Bool, +v34: Bool, +v35: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({111 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v36 : Bool <- IO.pure(Bool, U32.is_eq(v14, {245 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43_if44_if45_if46_if47_if48_if49(v36, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43_if44_if45_if46_if47(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool, +v25: Bool, +v26: Bool, +v27: Bool, +v28: Bool, +v29: Bool, +v30: Bool, +v31: Bool, +v32: Bool, +v33: Bool, +v34: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({101 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v35 : Bool <- IO.pure(Bool, U32.is_eq(v14, {243 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43_if44_if45_if46_if47_if48(v35, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43_if44_if45_if46(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool, +v25: Bool, +v26: Bool, +v27: Bool, +v28: Bool, +v29: Bool, +v30: Bool, +v31: Bool, +v32: Bool, +v33: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({99 : U32}, {807 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v34 : Bool <- IO.pure(Bool, U32.is_eq(v14, {233 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43_if44_if45_if46_if47(v34, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43_if44_if45(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool, +v25: Bool, +v26: Bool, +v27: Bool, +v28: Bool, +v29: Bool, +v30: Bool, +v31: Bool, +v32: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {776 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v33 : Bool <- IO.pure(Bool, U32.is_eq(v14, {231 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43_if44_if45_if46(v33, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43_if44(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool, +v25: Bool, +v26: Bool, +v27: Bool, +v28: Bool, +v29: Bool, +v30: Bool, +v31: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v32 : Bool <- IO.pure(Bool, U32.is_eq(v14, {228 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43_if44_if45(v32, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool, +v25: Bool, +v26: Bool, +v27: Bool, +v28: Bool, +v29: Bool, +v30: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v31 : Bool <- IO.pure(Bool, U32.is_eq(v14, {227 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43_if44(v31, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool, +v25: Bool, +v26: Bool, +v27: Bool, +v28: Bool, +v29: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {768 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v30 : Bool <- IO.pure(Bool, U32.is_eq(v14, {225 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43(v30, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool, +v25: Bool, +v26: Bool, +v27: Bool, +v28: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({79 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v29 : Bool <- IO.pure(Bool, U32.is_eq(v14, {224 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41_if42(v29, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool, +v25: Bool, +v26: Bool, +v27: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({79 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v28 : Bool <- IO.pure(Bool, U32.is_eq(v14, {213 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40_if41(v28, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24, v25, v26, v27, v28)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool, +v25: Bool, +v26: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({69 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v27 : Bool <- IO.pure(Bool, U32.is_eq(v14, {211 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39_if40(v27, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24, v25, v26, v27)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool, +v25: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({67 : U32}, {807 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v26 : Bool <- IO.pure(Bool, U32.is_eq(v14, {201 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38_if39(v26, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24, v25, v26)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool, +v24: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {776 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v25 : Bool <- IO.pure(Bool, U32.is_eq(v14, {199 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37_if38(v25, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24, v25)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v24 : Bool <- IO.pure(Bool, U32.is_eq(v14, {196 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36_if37(v24, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23, v24)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool, +v22: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v23 : Bool <- IO.pure(Bool, U32.is_eq(v14, {195 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35_if36(v23, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22, v23)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {768 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v22 : Bool <- IO.pure(Bool, U32.is_eq(v14, {193 : U32}))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34_if35(v22, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21, v22)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3_k50(+p: U32 & U32, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool, +v14: U32, +v15: Bool, +v20: U32, +v21: Bool) -> IO(U32 & U32 & U32):
  (+v67, +v68) = p
  do IO<U32 & U32 & U32>:
    +v69 : U32 <- IO.pure(U32, U32.add(v2, v20))
    return (v67, v69, v68)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2_if3(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool) -> IO(U32 & U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32 & U32>:
        IO.die(U32 & U32 & U32, 1, "UTF-8 canonical stream offset exceeds the string.")
    case False{}:
      do IO<U32 & U32 & U32>:
        +v14 : U32 <- utf8_scalar_at_byte_offset_1(v0, v2)
        +v15 : Bool <- IO.pure(Bool, spiral_i32_lt(v14, {128 : U32}))
        +v20 : U32 <- utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if31(v15, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15)
        +v21 : Bool <- IO.pure(Bool, U32.is_eq(v14, {192 : U32}))
        +p : U32 & U32 <- utf8_canonical_equal_bounded_loop_0_if1_if2_if3_if34(v21, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21)
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3_k50(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v14, v15, v20, v21)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1_if2(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v9: Bool) -> IO(U32 & U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32 & U32>:
        return ({4294967295 : U32}, v2, {4294967295 : U32})
    case False{}:
      do IO<U32 & U32 & U32>:
        +v10 : Bool <- IO.pure(Bool, spiral_i32_gt(v2, v6))
        utf8_canonical_equal_bounded_loop_0_if1_if2_if3(v10, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)

@unsafe
def utf8_canonical_equal_bounded_loop_0_if1(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool) -> IO(U32 & U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32 & U32>:
        return (v4, v2, {4294967295 : U32})
    case False{}:
      do IO<U32 & U32 & U32>:
        +v9 : Bool <- IO.pure(Bool, U32.is_eq(v2, v6))
        utf8_canonical_equal_bounded_loop_0_if1_if2(v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if55_if56_if57(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v87: Bool, +v88: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {3 : U32}
    case False{}:
      do IO<U32>:
        return {4 : U32}

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if55_if56(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v87: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {2 : U32}
    case False{}:
      do IO<U32>:
        +v88 : Bool <- IO.pure(Bool, spiral_i32_lt(v85, {65536 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if55_if56_if57(v88, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v87, v88)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if55(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {1 : U32}
    case False{}:
      do IO<U32>:
        +v87 : Bool <- IO.pure(Bool, spiral_i32_lt(v85, {2048 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if55_if56(v87, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v87)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72_if73(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool, +v96: Bool, +v97: Bool, +v98: Bool, +v99: Bool, +v100: Bool, +v101: Bool, +v102: Bool, +v103: Bool, +v104: Bool, +v105: Bool, +v106: Bool, +v107: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({111 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        return (v85, {4294967295 : U32})

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool, +v96: Bool, +v97: Bool, +v98: Bool, +v99: Bool, +v100: Bool, +v101: Bool, +v102: Bool, +v103: Bool, +v104: Bool, +v105: Bool, +v106: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({111 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v107 : Bool <- IO.pure(Bool, U32.is_eq(v85, {245 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72_if73(v107, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105, v106, v107)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool, +v96: Bool, +v97: Bool, +v98: Bool, +v99: Bool, +v100: Bool, +v101: Bool, +v102: Bool, +v103: Bool, +v104: Bool, +v105: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({101 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v106 : Bool <- IO.pure(Bool, U32.is_eq(v85, {243 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72(v106, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105, v106)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67_if68_if69_if70(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool, +v96: Bool, +v97: Bool, +v98: Bool, +v99: Bool, +v100: Bool, +v101: Bool, +v102: Bool, +v103: Bool, +v104: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({99 : U32}, {807 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v105 : Bool <- IO.pure(Bool, U32.is_eq(v85, {233 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71(v105, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67_if68_if69(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool, +v96: Bool, +v97: Bool, +v98: Bool, +v99: Bool, +v100: Bool, +v101: Bool, +v102: Bool, +v103: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {776 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v104 : Bool <- IO.pure(Bool, U32.is_eq(v85, {231 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67_if68_if69_if70(v104, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67_if68(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool, +v96: Bool, +v97: Bool, +v98: Bool, +v99: Bool, +v100: Bool, +v101: Bool, +v102: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v103 : Bool <- IO.pure(Bool, U32.is_eq(v85, {228 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67_if68_if69(v103, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool, +v96: Bool, +v97: Bool, +v98: Bool, +v99: Bool, +v100: Bool, +v101: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v102 : Bool <- IO.pure(Bool, U32.is_eq(v85, {227 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67_if68(v102, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool, +v96: Bool, +v97: Bool, +v98: Bool, +v99: Bool, +v100: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {768 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v101 : Bool <- IO.pure(Bool, U32.is_eq(v85, {225 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66_if67(v101, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool, +v96: Bool, +v97: Bool, +v98: Bool, +v99: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({79 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v100 : Bool <- IO.pure(Bool, U32.is_eq(v85, {224 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65_if66(v100, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool, +v96: Bool, +v97: Bool, +v98: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({79 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v99 : Bool <- IO.pure(Bool, U32.is_eq(v85, {213 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64_if65(v99, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95, v96, v97, v98, v99)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool, +v96: Bool, +v97: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({69 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v98 : Bool <- IO.pure(Bool, U32.is_eq(v85, {211 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63_if64(v98, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95, v96, v97, v98)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool, +v96: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({67 : U32}, {807 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v97 : Bool <- IO.pure(Bool, U32.is_eq(v85, {201 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62_if63(v97, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95, v96, v97)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool, +v95: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {776 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v96 : Bool <- IO.pure(Bool, U32.is_eq(v85, {199 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61_if62(v96, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95, v96)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v95 : Bool <- IO.pure(Bool, U32.is_eq(v85, {196 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60_if61(v95, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94, v95)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool, +v93: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v94 : Bool <- IO.pure(Bool, U32.is_eq(v85, {195 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59_if60(v94, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93, v94)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {768 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v93 : Bool <- IO.pure(Bool, U32.is_eq(v85, {193 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58_if59(v93, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92, v93)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_k74(+p: U32 & U32, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool, +v85: U32, +v86: Bool, +v91: U32, +v92: Bool) -> IO(U32 & U32 & U32):
  (+v138, +v139) = p
  do IO<U32 & U32 & U32>:
    +v140 : U32 <- IO.pure(U32, U32.add(v3, v91))
    return (v138, v140, v139)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool, +v81: Bool) -> IO(U32 & U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32 & U32>:
        IO.die(U32 & U32 & U32, 1, "UTF-8 canonical stream offset exceeds the string.")
    case False{}:
      do IO<U32 & U32 & U32>:
        +v85 : U32 <- utf8_scalar_at_byte_offset_1(v1, v3)
        +v86 : Bool <- IO.pure(Bool, spiral_i32_lt(v85, {128 : U32}))
        +v91 : U32 <- utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if55(v86, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86)
        +v92 : Bool <- IO.pure(Bool, U32.is_eq(v85, {192 : U32}))
        +p : U32 & U32 <- utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_if58(v92, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92)
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54_k74(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81, v85, v86, v91, v92)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52_if53(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v80: Bool) -> IO(U32 & U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32 & U32>:
        return ({4294967295 : U32}, v3, {4294967295 : U32})
    case False{}:
      do IO<U32 & U32 & U32>:
        +v81 : Bool <- IO.pure(Bool, spiral_i32_gt(v3, v7))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53_if54(v81, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80, v81)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_if52(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool) -> IO(U32 & U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32 & U32>:
        return (v5, v3, {4294967295 : U32})
    case False{}:
      do IO<U32 & U32 & U32>:
        +v80 : Bool <- IO.pure(Bool, U32.is_eq(v3, v7))
        utf8_canonical_equal_bounded_loop_0_k51_if52_if53(v80, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v80)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_k75_if76_if77_if78(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v147: U32, +v148: U32, +v149: U32, +v150: Bool, +v152: Bool, +v153: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        utf8_canonical_equal_bounded_loop_0(v0, v1, v77, v148, v78, v149, v6, v7)
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_k75_if76_if77(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v147: U32, +v148: U32, +v149: U32, +v150: Bool, +v152: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v153 : Bool <- IO.pure(Bool, U32.is_eq(v76, v147))
        utf8_canonical_equal_bounded_loop_0_k51_k75_if76_if77_if78(v153, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v147, v148, v149, v150, v152, v153)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_k75_if76(+c: Bool, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool, +v147: U32, +v148: U32, +v149: U32, +v150: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v151 : Bool <- IO.pure(Bool, U32.is_eq(v147, {4294967295 : U32}))
        return v151
    case False{}:
      do IO<Bool>:
        +v152 : Bool <- IO.pure(Bool, spiral_i32_lt(v147, {0 : U32}))
        utf8_canonical_equal_bounded_loop_0_k51_k75_if76_if77(v152, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v147, v148, v149, v150, v152)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51_k75(+p: U32 & U32 & U32, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool, +v76: U32, +v77: U32, +v78: U32, +v79: Bool) -> IO(Bool):
  (+v147, +v148, +v149) = p
  do IO<Bool>:
    +v150 : Bool <- IO.pure(Bool, spiral_i32_lt(v76, {0 : U32}))
    utf8_canonical_equal_bounded_loop_0_k51_k75_if76(v150, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79, v147, v148, v149, v150)

@unsafe
def utf8_canonical_equal_bounded_loop_0_k51(+p: U32 & U32 & U32, +v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32, +v8: Bool) -> IO(Bool):
  (+v76, +v77, +v78) = p
  do IO<Bool>:
    +v79 : Bool <- IO.pure(Bool, spiral_i32_ge(v5, {0 : U32}))
    +p : U32 & U32 & U32 <- utf8_canonical_equal_bounded_loop_0_k51_if52(v79, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79)
    utf8_canonical_equal_bounded_loop_0_k51_k75(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v76, v77, v78, v79)

@unsafe
def utf8_canonical_equal_bounded_loop_0(+v0: String, +v1: String, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: U32) -> IO(Bool):
  do IO<Bool>:
    +v8 : Bool <- IO.pure(Bool, spiral_i32_ge(v4, {0 : U32}))
    +p : U32 & U32 & U32 <- utf8_canonical_equal_bounded_loop_0_if1(v8, v0, v1, v2, v3, v4, v5, v6, v7, v8)
    utf8_canonical_equal_bounded_loop_0_k51(p, v0, v1, v2, v3, v4, v5, v6, v7, v8)

@unsafe
def spiral_main_if79_if80_if81_if82_if83_if84_if85_if86_if87_if88(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: String, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: Bool, +v16: String, +v17: String, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: Bool, +v25: String, +v26: String, +v27: U32, +v28: U32, +v29: U32, +v30: U32, +v31: U32, +v32: U32, +v33: Bool, +v34: String, +v35: String, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: Bool, +v43: String, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v51: String, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: Bool, +v59: String, +v60: String, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: Bool, +v68: String, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v76: String, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: U32, +v83: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {10 : U32}
    case False{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main_if79_if80_if81_if82_if83_if84_if85_if86_if87(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: String, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: Bool, +v16: String, +v17: String, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: Bool, +v25: String, +v26: String, +v27: U32, +v28: U32, +v29: U32, +v30: U32, +v31: U32, +v32: U32, +v33: Bool, +v34: String, +v35: String, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: Bool, +v43: String, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v51: String, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: Bool, +v59: String, +v60: String, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: Bool, +v68: String, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v76: String, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: U32, +v83: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {9 : U32}
    case False{}:
      do IO<U32>:
        spiral_main_if79_if80_if81_if82_if83_if84_if85_if86_if87_if88(v83, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83)

@unsafe
def spiral_main_if79_if80_if81_if82_if83_if84_if85_if86(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: String, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: Bool, +v16: String, +v17: String, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: Bool, +v25: String, +v26: String, +v27: U32, +v28: U32, +v29: U32, +v30: U32, +v31: U32, +v32: U32, +v33: Bool, +v34: String, +v35: String, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: Bool, +v43: String, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v51: String, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: Bool, +v59: String, +v60: String, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: Bool, +v68: String, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v76: String, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: U32, +v83: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {8 : U32}
    case False{}:
      do IO<U32>:
        spiral_main_if79_if80_if81_if82_if83_if84_if85_if86_if87(v75, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83)

@unsafe
def spiral_main_if79_if80_if81_if82_if83_if84_if85(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: String, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: Bool, +v16: String, +v17: String, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: Bool, +v25: String, +v26: String, +v27: U32, +v28: U32, +v29: U32, +v30: U32, +v31: U32, +v32: U32, +v33: Bool, +v34: String, +v35: String, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: Bool, +v43: String, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v51: String, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: Bool, +v59: String, +v60: String, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: Bool, +v68: String, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v76: String, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: U32, +v83: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {7 : U32}
    case False{}:
      do IO<U32>:
        spiral_main_if79_if80_if81_if82_if83_if84_if85_if86(v67, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83)

@unsafe
def spiral_main_if79_if80_if81_if82_if83_if84(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: String, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: Bool, +v16: String, +v17: String, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: Bool, +v25: String, +v26: String, +v27: U32, +v28: U32, +v29: U32, +v30: U32, +v31: U32, +v32: U32, +v33: Bool, +v34: String, +v35: String, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: Bool, +v43: String, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v51: String, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: Bool, +v59: String, +v60: String, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: Bool, +v68: String, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v76: String, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: U32, +v83: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        spiral_main_if79_if80_if81_if82_if83_if84_if85(v58, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83)
    case False{}:
      do IO<U32>:
        return {6 : U32}

@unsafe
def spiral_main_if79_if80_if81_if82_if83(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: String, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: Bool, +v16: String, +v17: String, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: Bool, +v25: String, +v26: String, +v27: U32, +v28: U32, +v29: U32, +v30: U32, +v31: U32, +v32: U32, +v33: Bool, +v34: String, +v35: String, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: Bool, +v43: String, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v51: String, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: Bool, +v59: String, +v60: String, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: Bool, +v68: String, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v76: String, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: U32, +v83: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        spiral_main_if79_if80_if81_if82_if83_if84(v50, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83)
    case False{}:
      do IO<U32>:
        return {5 : U32}

@unsafe
def spiral_main_if79_if80_if81_if82(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: String, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: Bool, +v16: String, +v17: String, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: Bool, +v25: String, +v26: String, +v27: U32, +v28: U32, +v29: U32, +v30: U32, +v31: U32, +v32: U32, +v33: Bool, +v34: String, +v35: String, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: Bool, +v43: String, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v51: String, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: Bool, +v59: String, +v60: String, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: Bool, +v68: String, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v76: String, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: U32, +v83: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        spiral_main_if79_if80_if81_if82_if83(v42, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83)
    case False{}:
      do IO<U32>:
        return {4 : U32}

@unsafe
def spiral_main_if79_if80_if81(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: String, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: Bool, +v16: String, +v17: String, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: Bool, +v25: String, +v26: String, +v27: U32, +v28: U32, +v29: U32, +v30: U32, +v31: U32, +v32: U32, +v33: Bool, +v34: String, +v35: String, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: Bool, +v43: String, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v51: String, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: Bool, +v59: String, +v60: String, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: Bool, +v68: String, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v76: String, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: U32, +v83: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        spiral_main_if79_if80_if81_if82(v33, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83)
    case False{}:
      do IO<U32>:
        return {3 : U32}

@unsafe
def spiral_main_if79_if80(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: String, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: Bool, +v16: String, +v17: String, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: Bool, +v25: String, +v26: String, +v27: U32, +v28: U32, +v29: U32, +v30: U32, +v31: U32, +v32: U32, +v33: Bool, +v34: String, +v35: String, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: Bool, +v43: String, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v51: String, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: Bool, +v59: String, +v60: String, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: Bool, +v68: String, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v76: String, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: U32, +v83: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        spiral_main_if79_if80_if81(v24, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83)
    case False{}:
      do IO<U32>:
        return {2 : U32}

@unsafe
def spiral_main_if79(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: String, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: Bool, +v16: String, +v17: String, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: Bool, +v25: String, +v26: String, +v27: U32, +v28: U32, +v29: U32, +v30: U32, +v31: U32, +v32: U32, +v33: Bool, +v34: String, +v35: String, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: Bool, +v43: String, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v51: String, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: Bool, +v59: String, +v60: String, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: Bool, +v68: String, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v76: String, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: U32, +v83: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        spiral_main_if79_if80(v15, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83)
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : String <- IO.pure(String, "plain")
    +v1 : U32 <- IO.pure(U32, {0 : U32})
    +v2 : U32 <- IO.pure(U32, {0 : U32})
    +v3 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v4 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v5 : U32 <- IO.pure(U32, {5 : U32})
    +v6 : U32 <- IO.pure(U32, {5 : U32})
    +v7 : Bool <- utf8_canonical_equal_bounded_loop_0(v0, v0, v1, v2, v3, v4, v5, v6)
    +v8 : String <- IO.pure(String, "")
    +v9 : U32 <- IO.pure(U32, {0 : U32})
    +v10 : U32 <- IO.pure(U32, {0 : U32})
    +v11 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v12 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v13 : U32 <- IO.pure(U32, {0 : U32})
    +v14 : U32 <- IO.pure(U32, {0 : U32})
    +v15 : Bool <- utf8_canonical_equal_bounded_loop_0(v8, v8, v9, v10, v11, v12, v13, v14)
    +v16 : String <- IO.pure(String, "éõç")
    +v17 : String <- IO.pure(String, "éõç")
    +v18 : U32 <- IO.pure(U32, {0 : U32})
    +v19 : U32 <- IO.pure(U32, {0 : U32})
    +v20 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v21 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v22 : U32 <- IO.pure(U32, {6 : U32})
    +v23 : U32 <- IO.pure(U32, {9 : U32})
    +v24 : Bool <- utf8_canonical_equal_bounded_loop_0(v16, v17, v18, v19, v20, v21, v22, v23)
    +v25 : String <- IO.pure(String, "é̃")
    +v26 : String <- IO.pure(String, "é̃")
    +v27 : U32 <- IO.pure(U32, {0 : U32})
    +v28 : U32 <- IO.pure(U32, {0 : U32})
    +v29 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v30 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v31 : U32 <- IO.pure(U32, {4 : U32})
    +v32 : U32 <- IO.pure(U32, {5 : U32})
    +v33 : Bool <- utf8_canonical_equal_bounded_loop_0(v25, v26, v27, v28, v29, v30, v31, v32)
    +v34 : String <- IO.pure(String, "À")
    +v35 : String <- IO.pure(String, "À")
    +v36 : U32 <- IO.pure(U32, {0 : U32})
    +v37 : U32 <- IO.pure(U32, {0 : U32})
    +v38 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v39 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v40 : U32 <- IO.pure(U32, {2 : U32})
    +v41 : U32 <- IO.pure(U32, {3 : U32})
    +v42 : Bool <- utf8_canonical_equal_bounded_loop_0(v34, v35, v36, v37, v38, v39, v40, v41)
    +v43 : String <- IO.pure(String, "Ω")
    +v44 : U32 <- IO.pure(U32, {0 : U32})
    +v45 : U32 <- IO.pure(U32, {0 : U32})
    +v46 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v47 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v48 : U32 <- IO.pure(U32, {2 : U32})
    +v49 : U32 <- IO.pure(U32, {2 : U32})
    +v50 : Bool <- utf8_canonical_equal_bounded_loop_0(v43, v43, v44, v45, v46, v47, v48, v49)
    +v51 : String <- IO.pure(String, "ẽ́")
    +v52 : U32 <- IO.pure(U32, {0 : U32})
    +v53 : U32 <- IO.pure(U32, {0 : U32})
    +v54 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v55 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v56 : U32 <- IO.pure(U32, {5 : U32})
    +v57 : U32 <- IO.pure(U32, {5 : U32})
    +v58 : Bool <- utf8_canonical_equal_bounded_loop_0(v26, v51, v52, v53, v54, v55, v56, v57)
    +v59 : String <- IO.pure(String, "é")
    +v60 : String <- IO.pure(String, "á")
    +v61 : U32 <- IO.pure(U32, {0 : U32})
    +v62 : U32 <- IO.pure(U32, {0 : U32})
    +v63 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v64 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v65 : U32 <- IO.pure(U32, {2 : U32})
    +v66 : U32 <- IO.pure(U32, {2 : U32})
    +v67 : Bool <- utf8_canonical_equal_bounded_loop_0(v59, v60, v61, v62, v63, v64, v65, v66)
    +v68 : String <- IO.pure(String, "ω")
    +v69 : U32 <- IO.pure(U32, {0 : U32})
    +v70 : U32 <- IO.pure(U32, {0 : U32})
    +v71 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v72 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v73 : U32 <- IO.pure(U32, {2 : U32})
    +v74 : U32 <- IO.pure(U32, {2 : U32})
    +v75 : Bool <- utf8_canonical_equal_bounded_loop_0(v43, v68, v69, v70, v71, v72, v73, v74)
    +v76 : String <- IO.pure(String, "e")
    +v77 : U32 <- IO.pure(U32, {0 : U32})
    +v78 : U32 <- IO.pure(U32, {0 : U32})
    +v79 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v80 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v81 : U32 <- IO.pure(U32, {2 : U32})
    +v82 : U32 <- IO.pure(U32, {1 : U32})
    +v83 : Bool <- utf8_canonical_equal_bounded_loop_0(v59, v76, v77, v78, v79, v80, v81, v82)
    spiral_main_if79(v7, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
