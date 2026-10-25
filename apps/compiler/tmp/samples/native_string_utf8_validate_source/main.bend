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
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if8_if9(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v13: U32, +v14: Bool, +v16: U32, +v17: U32, +v18: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v19 : Bool <- IO.pure(Bool, spiral_i32_lt(v17, {192 : U32}))
        return v19

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if8_if10(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v13: U32, +v14: Bool, +v16: U32, +v17: U32, +v18: Bool, +v20: Bool) -> IO(U32):
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
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if8(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v13: U32, +v14: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is truncated.")
    case False{}:
      do IO<U32>:
        +v16 : U32 <- runtime_byte_2(v0, v13)
        +v17 : U32 <- IO.pure(U32, v16)
        +v18 : Bool <- IO.pure(Bool, spiral_i32_lt(v17, {128 : U32}))
        +v20 : Bool <- utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if8_if9(v18, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v13, v14, v16, v17, v18)
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if8_if10(v20, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v13, v14, v16, v17, v18, v20)

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if13(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v38 : Bool <- IO.pure(Bool, spiral_i32_lt(v34, {192 : U32}))
        return v38

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if14_if15(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool, +v39: Bool, +v40: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v41 : Bool <- IO.pure(Bool, spiral_i32_lt(v36, {192 : U32}))
        return v41

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if14_if16_if17_if18_if19(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool, +v39: Bool, +v40: Bool, +v42: Bool, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v52: Bool, +v53: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence encodes a surrogate.")
    case False{}:
      do IO<U32>:
        return v49

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if14_if16_if17_if18(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool, +v39: Bool, +v40: Bool, +v42: Bool, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool, +v52: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v53 : Bool <- IO.pure(Bool, spiral_i32_le(v49, {57343 : U32}))
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if14_if16_if17_if18_if19(v53, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37, v39, v40, v42, v43, v44, v45, v46, v47, v48, v49, v50, v52, v53)
    case False{}:
      do IO<U32>:
        return v49

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if14_if16_if17(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool, +v39: Bool, +v40: Bool, +v42: Bool, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is overlong.")
    case False{}:
      do IO<U32>:
        +v52 : Bool <- IO.pure(Bool, spiral_i32_ge(v49, {55296 : U32}))
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if14_if16_if17_if18(v52, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37, v39, v40, v42, v43, v44, v45, v46, v47, v48, v49, v50, v52)

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if14_if16(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool, +v39: Bool, +v40: Bool, +v42: Bool) -> IO(U32):
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
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if14_if16_if17(v50, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37, v39, v40, v42, v43, v44, v45, v46, v47, v48, v49, v50)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if14(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: Bool, +v39: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v40 : Bool <- IO.pure(Bool, spiral_i32_lt(v36, {128 : U32}))
        +v42 : Bool <- utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if14_if15(v40, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37, v39, v40)
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if14_if16(v42, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37, v39, v40, v42)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v29: U32, +v30: Bool) -> IO(U32):
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
        +v39 : Bool <- utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if13(v37, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37)
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12_if14(v39, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30, v32, v33, v34, v35, v36, v37, v39)

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if22(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v76 : Bool <- IO.pure(Bool, spiral_i32_lt(v69, {192 : U32}))
        return v76

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23_if24(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool, +v78: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v79 : Bool <- IO.pure(Bool, spiral_i32_lt(v72, {192 : U32}))
        return v79

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23_if25_if26(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool, +v78: Bool, +v80: Bool, +v81: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v82 : Bool <- IO.pure(Bool, spiral_i32_lt(v74, {192 : U32}))
        return v82

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23_if25_if27_if28_if29(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool, +v78: Bool, +v80: Bool, +v81: Bool, +v83: Bool, +v84: U32, +v85: U32, +v86: U32, +v87: U32, +v88: U32, +v89: U32, +v90: U32, +v91: U32, +v92: U32, +v93: U32, +v94: Bool, +v96: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 scalar is above U+10FFFF.")
    case False{}:
      do IO<U32>:
        return v93

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23_if25_if27_if28(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool, +v78: Bool, +v80: Bool, +v81: Bool, +v83: Bool, +v84: U32, +v85: U32, +v86: U32, +v87: U32, +v88: U32, +v89: U32, +v90: U32, +v91: U32, +v92: U32, +v93: U32, +v94: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is overlong.")
    case False{}:
      do IO<U32>:
        +v96 : Bool <- IO.pure(Bool, spiral_i32_gt(v93, {1114111 : U32}))
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23_if25_if27_if28_if29(v96, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77, v78, v80, v81, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v96)

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23_if25_if27(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool, +v78: Bool, +v80: Bool, +v81: Bool, +v83: Bool) -> IO(U32):
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
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23_if25_if27_if28(v94, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77, v78, v80, v81, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23_if25(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool, +v78: Bool, +v80: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v81 : Bool <- IO.pure(Bool, spiral_i32_lt(v74, {128 : U32}))
        +v83 : Bool <- utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23_if25_if26(v81, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77, v78, v80, v81)
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23_if25_if27(v83, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77, v78, v80, v81, v83)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v67: U32, +v68: U32, +v69: U32, +v70: U32, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: Bool, +v77: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v78 : Bool <- IO.pure(Bool, spiral_i32_lt(v72, {128 : U32}))
        +v80 : Bool <- utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23_if24(v78, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77, v78)
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23_if25(v80, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77, v78, v80)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool, +v64: U32, +v65: Bool) -> IO(U32):
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
        +v77 : Bool <- utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if22(v75, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75)
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21_if23(v77, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65, v67, v68, v69, v70, v71, v72, v73, v74, v75, v77)

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool, +v63: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v64 : U32 <- IO.pure(U32, U32.add(v1, {3 : U32}))
        +v65 : Bool <- IO.pure(Bool, spiral_i32_ge(v64, v2))
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20_if21(v65, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63, v64, v65)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 scalar starts with an invalid lead byte.")

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool, +v28: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v29 : U32 <- IO.pure(U32, U32.add(v1, {2 : U32}))
        +v30 : Bool <- IO.pure(Bool, spiral_i32_ge(v29, v2))
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if12(v30, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v29, v30)
    case False{}:
      do IO<U32>:
        +v63 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {245 : U32}))
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11_if20(v63, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28, v63)

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool, +v12: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v13 : U32 <- IO.pure(U32, U32.add(v1, {1 : U32}))
        +v14 : Bool <- IO.pure(Bool, spiral_i32_ge(v13, v2))
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if8(v14, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v13, v14)
    case False{}:
      do IO<U32>:
        +v28 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {240 : U32}))
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7_if11(v28, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12, v28)

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5_if6(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool, +v10: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 scalar starts with an invalid lead byte.")
    case False{}:
      do IO<U32>:
        +v12 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {224 : U32}))
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6_if7(v12, v0, v1, v2, v3, v5, v7, v8, v9, v10, v12)

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4_if5(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool, +v7: U32, +v8: U32, +v9: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return v8
    case False{}:
      do IO<U32>:
        +v10 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {194 : U32}))
        utf8_scalar_at_byte_offset_1_if3_if4_if5_if6(v10, v0, v1, v2, v3, v5, v7, v8, v9, v10)

@unsafe
def utf8_scalar_at_byte_offset_1_if3_if4(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool, +v5: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 byte offset is outside the string.")
    case False{}:
      do IO<U32>:
        +v7 : U32 <- runtime_byte_2(v0, v1)
        +v8 : U32 <- IO.pure(U32, v7)
        +v9 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {128 : U32}))
        utf8_scalar_at_byte_offset_1_if3_if4_if5(v9, v0, v1, v2, v3, v5, v7, v8, v9)

@unsafe
def utf8_scalar_at_byte_offset_1_if3(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 byte offset is negative.")
    case False{}:
      do IO<U32>:
        +v5 : Bool <- IO.pure(Bool, spiral_i32_ge(v1, v2))
        utf8_scalar_at_byte_offset_1_if3_if4(v5, v0, v1, v2, v3, v5)

@unsafe
def utf8_scalar_at_byte_offset_1(+v0: String, +v1: U32) -> IO(U32):
  do IO<U32>:
    +v2 : U32 <- IO.pure(U32, spiral_string_bytes(v0))
    +v3 : Bool <- IO.pure(Bool, spiral_i32_lt(v1, {0 : U32}))
    utf8_scalar_at_byte_offset_1_if3(v3, v0, v1, v2, v3)

@unsafe
def utf8_validate_loop_0_if1_if2_if30_if31_if32(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: Bool, +v5: Bool, +v7: U32, +v8: Bool, +v9: Bool, +v10: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {3 : U32}
    case False{}:
      do IO<U32>:
        return {4 : U32}

@unsafe
def utf8_validate_loop_0_if1_if2_if30_if31(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: Bool, +v5: Bool, +v7: U32, +v8: Bool, +v9: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {2 : U32}
    case False{}:
      do IO<U32>:
        +v10 : Bool <- IO.pure(Bool, spiral_i32_lt(v7, {65536 : U32}))
        utf8_validate_loop_0_if1_if2_if30_if31_if32(v10, v0, v1, v2, v3, v4, v5, v7, v8, v9, v10)

@unsafe
def utf8_validate_loop_0_if1_if2_if30(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: Bool, +v5: Bool, +v7: U32, +v8: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {1 : U32}
    case False{}:
      do IO<U32>:
        +v9 : Bool <- IO.pure(Bool, spiral_i32_lt(v7, {2048 : U32}))
        utf8_validate_loop_0_if1_if2_if30_if31(v9, v0, v1, v2, v3, v4, v5, v7, v8, v9)

@unsafe
def utf8_validate_loop_0_if1_if2(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: Bool, +v5: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 scalar width exceeds the string.")
    case False{}:
      do IO<U32>:
        +v7 : U32 <- utf8_scalar_at_byte_offset_1(v0, v1)
        +v8 : Bool <- IO.pure(Bool, spiral_i32_lt(v7, {128 : U32}))
        +v13 : U32 <- utf8_validate_loop_0_if1_if2_if30(v8, v0, v1, v2, v3, v4, v5, v7, v8)
        +v14 : U32 <- IO.pure(U32, U32.add(v1, v13))
        +v15 : U32 <- IO.pure(U32, U32.add(v2, {1 : U32}))
        utf8_validate_loop_0(v0, v14, v15, v3)

@unsafe
def utf8_validate_loop_0_if1(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return v2
    case False{}:
      do IO<U32>:
        +v5 : Bool <- IO.pure(Bool, spiral_i32_gt(v1, v3))
        utf8_validate_loop_0_if1_if2(v5, v0, v1, v2, v3, v4, v5)

@unsafe
def utf8_validate_loop_0(+v0: String, +v1: U32, +v2: U32, +v3: U32) -> IO(U32):
  do IO<U32>:
    +v4 : Bool <- IO.pure(Bool, U32.is_eq(v1, v3))
    utf8_validate_loop_0_if1(v4, v0, v1, v2, v3, v4)

@unsafe
def spiral_main_if33_if34(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: String, +v6: U32, +v7: U32, +v8: U32, +v9: U32, +v10: Bool, +v11: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {2 : U32}

@unsafe
def spiral_main_if33(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: String, +v6: U32, +v7: U32, +v8: U32, +v9: U32, +v10: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v11 : Bool <- IO.pure(Bool, U32.is_eq(v9, {0 : U32}))
        spiral_main_if33_if34(v11, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11)
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : String <- IO.pure(String, "Aéλ🙂Z")
    +v1 : U32 <- IO.pure(U32, {0 : U32})
    +v2 : U32 <- IO.pure(U32, {0 : U32})
    +v3 : U32 <- IO.pure(U32, {10 : U32})
    +v4 : U32 <- utf8_validate_loop_0(v0, v1, v2, v3)
    +v5 : String <- IO.pure(String, "")
    +v6 : U32 <- IO.pure(U32, {0 : U32})
    +v7 : U32 <- IO.pure(U32, {0 : U32})
    +v8 : U32 <- IO.pure(U32, {0 : U32})
    +v9 : U32 <- utf8_validate_loop_0(v5, v6, v7, v8)
    +v10 : Bool <- IO.pure(Bool, U32.is_eq(v4, {5 : U32}))
    spiral_main_if33(v10, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
