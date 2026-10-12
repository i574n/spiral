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
def runtime_byte_0(+v0: String, +v1: U32) -> IO(U32):
  do IO<U32>:
    +v2 : U32 <- IO.pure(U32, spiral_string_byte_at(v0, v1))
    return v2

@unsafe
def codepoint_length_loop_1_if1_if2(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: Bool, +v7: U32, +v8: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v9 : Bool <- IO.pure(Bool, U32.is_lt(v7, v2))
        return v9

@unsafe
def codepoint_length_loop_1_if1_if3(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: Bool, +v7: U32, +v8: Bool, +v10: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return v4
    case False{}:
      do IO<U32>:
        +v11 : U32 <- IO.pure(U32, U32.add(v4, {1 : U32}))
        return v11

@unsafe
def codepoint_length_loop_1_if1(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return v4
    case False{}:
      do IO<U32>:
        +v7 : U32 <- IO.pure(U32, spiral_string_byte_at(v0, v3))
        +v8 : Bool <- IO.pure(Bool, U32.is_lt(v7, v1))
        +v10 : Bool <- codepoint_length_loop_1_if1_if2(v8, v0, v1, v2, v3, v4, v5, v6, v7, v8)
        +v12 : U32 <- codepoint_length_loop_1_if1_if3(v10, v0, v1, v2, v3, v4, v5, v6, v7, v8, v10)
        +v13 : U32 <- IO.pure(U32, U32.add(v3, {1 : U32}))
        codepoint_length_loop_1(v0, v1, v2, v13, v12, v5)

@unsafe
def codepoint_length_loop_1(+v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32) -> IO(U32):
  do IO<U32>:
    +v6 : Bool <- IO.pure(Bool, U32.is_eq(v3, v5))
    codepoint_length_loop_1_if1(v6, v0, v1, v2, v3, v4, v5, v6)

@unsafe
def codepoint_byte_offset_loop_2_if4_if5(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: U32, +v9: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v10 : Bool <- IO.pure(Bool, U32.is_lt(v8, v2))
        return v10

@unsafe
def codepoint_byte_offset_loop_2_if4_if6_if7(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: U32, +v9: Bool, +v11: Bool, +v14: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return v4
    case False{}:
      do IO<U32>:
        +v15 : U32 <- IO.pure(U32, U32.add(v4, {1 : U32}))
        +v16 : U32 <- IO.pure(U32, U32.add(v5, {1 : U32}))
        codepoint_byte_offset_loop_2(v0, v1, v2, v3, v15, v16, v6)

@unsafe
def codepoint_byte_offset_loop_2_if4_if6(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool, +v8: U32, +v9: Bool, +v11: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v12 : U32 <- IO.pure(U32, U32.add(v4, {1 : U32}))
        codepoint_byte_offset_loop_2(v0, v1, v2, v3, v12, v5, v6)
    case False{}:
      do IO<U32>:
        +v14 : Bool <- IO.pure(Bool, U32.is_eq(v5, v3))
        codepoint_byte_offset_loop_2_if4_if6_if7(v14, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v11, v14)

@unsafe
def codepoint_byte_offset_loop_2_if4(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32, +v7: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return v6
    case False{}:
      do IO<U32>:
        +v8 : U32 <- IO.pure(U32, spiral_string_byte_at(v0, v4))
        +v9 : Bool <- IO.pure(Bool, U32.is_lt(v8, v1))
        +v11 : Bool <- codepoint_byte_offset_loop_2_if4_if5(v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)
        codepoint_byte_offset_loop_2_if4_if6(v11, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v11)

@unsafe
def codepoint_byte_offset_loop_2(+v0: String, +v1: U32, +v2: U32, +v3: U32, +v4: U32, +v5: U32, +v6: U32) -> IO(U32):
  do IO<U32>:
    +v7 : Bool <- IO.pure(Bool, U32.is_eq(v4, v6))
    codepoint_byte_offset_loop_2_if4(v7, v0, v1, v2, v3, v4, v5, v6, v7)

@unsafe
def spiral_main_if8_if9_if10_if11_if12_if13_if14(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: U32, +v16: U32, +v17: U32, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: U32, +v25: U32, +v26: U32, +v27: U32, +v28: U32, +v29: U32, +v30: String, +v31: U32, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: U32, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: String, +v51: U32, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: U32, +v59: U32, +v60: U32, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: U32, +v68: U32, +v69: U32, +v70: String, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: U32, +v76: U32, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: String, +v83: U32, +v84: U32, +v85: U32, +v86: U32, +v87: String, +v88: U32, +v89: U32, +v90: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: U32, +v95: Bool, +v96: Bool, +v97: U32, +v98: Bool, +v99: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main_if8_if9_if10_if11_if12_if13(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: U32, +v16: U32, +v17: U32, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: U32, +v25: U32, +v26: U32, +v27: U32, +v28: U32, +v29: U32, +v30: String, +v31: U32, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: U32, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: String, +v51: U32, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: U32, +v59: U32, +v60: U32, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: U32, +v68: U32, +v69: U32, +v70: String, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: U32, +v76: U32, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: String, +v83: U32, +v84: U32, +v85: U32, +v86: U32, +v87: String, +v88: U32, +v89: U32, +v90: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: U32, +v95: Bool, +v96: Bool, +v97: U32, +v98: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v99 : Bool <- IO.pure(Bool, U32.is_eq(v79, {5 : U32}))
        spiral_main_if8_if9_if10_if11_if12_if13_if14(v99, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98, v99)
    case False{}:
      do IO<U32>:
        return {2 : U32}

@unsafe
def spiral_main_if8_if9_if10_if11_if12(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: U32, +v16: U32, +v17: U32, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: U32, +v25: U32, +v26: U32, +v27: U32, +v28: U32, +v29: U32, +v30: String, +v31: U32, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: U32, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: String, +v51: U32, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: U32, +v59: U32, +v60: U32, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: U32, +v68: U32, +v69: U32, +v70: String, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: U32, +v76: U32, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: String, +v83: U32, +v84: U32, +v85: U32, +v86: U32, +v87: String, +v88: U32, +v89: U32, +v90: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: U32, +v95: Bool, +v96: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v97 : U32 <- IO.pure(U32, spiral_string_bytes(v70))
        +v98 : Bool <- IO.pure(Bool, U32.is_eq(v97, {8 : U32}))
        spiral_main_if8_if9_if10_if11_if12_if13(v98, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98)
    case False{}:
      do IO<U32>:
        return {3 : U32}

@unsafe
def spiral_main_if8_if9_if10_if11(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: U32, +v16: U32, +v17: U32, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: U32, +v25: U32, +v26: U32, +v27: U32, +v28: U32, +v29: U32, +v30: String, +v31: U32, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: U32, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: String, +v51: U32, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: U32, +v59: U32, +v60: U32, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: U32, +v68: U32, +v69: U32, +v70: String, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: U32, +v76: U32, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: String, +v83: U32, +v84: U32, +v85: U32, +v86: U32, +v87: String, +v88: U32, +v89: U32, +v90: Bool, +v91: U32, +v92: Bool, +v93: Bool, +v94: U32, +v95: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v96 : Bool <- IO.pure(Bool, U32.is_eq(v86, v89))
        spiral_main_if8_if9_if10_if11_if12(v96, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96)
    case False{}:
      do IO<U32>:
        return {4 : U32}

@unsafe
def spiral_main_if8_if9_if10(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: U32, +v16: U32, +v17: U32, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: U32, +v25: U32, +v26: U32, +v27: U32, +v28: U32, +v29: U32, +v30: String, +v31: U32, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: U32, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: String, +v51: U32, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: U32, +v59: U32, +v60: U32, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: U32, +v68: U32, +v69: U32, +v70: String, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: U32, +v76: U32, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: String, +v83: U32, +v84: U32, +v85: U32, +v86: U32, +v87: String, +v88: U32, +v89: U32, +v90: Bool, +v91: U32, +v92: Bool, +v93: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v94 : U32 <- IO.pure(U32, spiral_string_bytes(v50))
        +v95 : Bool <- IO.pure(Bool, U32.is_eq(v94, {4 : U32}))
        spiral_main_if8_if9_if10_if11(v95, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95)
    case False{}:
      do IO<U32>:
        return {5 : U32}

@unsafe
def spiral_main_if8_if9(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: U32, +v16: U32, +v17: U32, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: U32, +v25: U32, +v26: U32, +v27: U32, +v28: U32, +v29: U32, +v30: String, +v31: U32, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: U32, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: String, +v51: U32, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: U32, +v59: U32, +v60: U32, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: U32, +v68: U32, +v69: U32, +v70: String, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: U32, +v76: U32, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: String, +v83: U32, +v84: U32, +v85: U32, +v86: U32, +v87: String, +v88: U32, +v89: U32, +v90: Bool, +v91: U32, +v92: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v93 : Bool <- IO.pure(Bool, U32.is_eq(v81, v84))
        spiral_main_if8_if9_if10(v93, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93)
    case False{}:
      do IO<U32>:
        return {6 : U32}

@unsafe
def spiral_main_if8(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: U32, +v16: U32, +v17: U32, +v18: U32, +v19: U32, +v20: U32, +v21: U32, +v22: U32, +v23: U32, +v24: U32, +v25: U32, +v26: U32, +v27: U32, +v28: U32, +v29: U32, +v30: String, +v31: U32, +v32: U32, +v33: U32, +v34: U32, +v35: U32, +v36: U32, +v37: U32, +v38: U32, +v39: U32, +v40: U32, +v41: U32, +v42: U32, +v43: U32, +v44: U32, +v45: U32, +v46: U32, +v47: U32, +v48: U32, +v49: U32, +v50: String, +v51: U32, +v52: U32, +v53: U32, +v54: U32, +v55: U32, +v56: U32, +v57: U32, +v58: U32, +v59: U32, +v60: U32, +v61: U32, +v62: U32, +v63: U32, +v64: U32, +v65: U32, +v66: U32, +v67: U32, +v68: U32, +v69: U32, +v70: String, +v71: U32, +v72: U32, +v73: U32, +v74: U32, +v75: U32, +v76: U32, +v77: U32, +v78: U32, +v79: U32, +v80: U32, +v81: U32, +v82: String, +v83: U32, +v84: U32, +v85: U32, +v86: U32, +v87: String, +v88: U32, +v89: U32, +v90: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v91 : U32 <- IO.pure(U32, spiral_string_bytes(v30))
        +v92 : Bool <- IO.pure(Bool, U32.is_eq(v91, {2 : U32}))
        spiral_main_if8_if9(v92, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92)
    case False{}:
      do IO<U32>:
        return {7 : U32}

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : String <- IO.pure(String, "À")
    +v1 : U32 <- IO.pure(U32, {1 : U32})
    +v2 : U32 <- runtime_byte_0(v0, v1)
    +v3 : String <- IO.pure(String, "©")
    +v4 : U32 <- IO.pure(U32, {0 : U32})
    +v5 : U32 <- runtime_byte_0(v3, v4)
    +v6 : String <- IO.pure(String, "Aéλ🙂Z")
    +v7 : U32 <- IO.pure(U32, {0 : U32})
    +v8 : U32 <- IO.pure(U32, {0 : U32})
    +v9 : U32 <- IO.pure(U32, {10 : U32})
    +v10 : U32 <- codepoint_length_loop_1(v6, v2, v5, v7, v8, v9)
    +v11 : U32 <- IO.pure(U32, {1 : U32})
    +v12 : U32 <- runtime_byte_0(v0, v11)
    +v13 : U32 <- IO.pure(U32, {0 : U32})
    +v14 : U32 <- runtime_byte_0(v3, v13)
    +v15 : U32 <- IO.pure(U32, {1 : U32})
    +v16 : U32 <- IO.pure(U32, {0 : U32})
    +v17 : U32 <- IO.pure(U32, {0 : U32})
    +v18 : U32 <- IO.pure(U32, {10 : U32})
    +v19 : U32 <- codepoint_byte_offset_loop_2(v6, v12, v14, v15, v16, v17, v18)
    +v20 : U32 <- IO.pure(U32, {1 : U32})
    +v21 : U32 <- runtime_byte_0(v0, v20)
    +v22 : U32 <- IO.pure(U32, {0 : U32})
    +v23 : U32 <- runtime_byte_0(v3, v22)
    +v24 : U32 <- IO.pure(U32, {2 : U32})
    +v25 : U32 <- IO.pure(U32, {0 : U32})
    +v26 : U32 <- IO.pure(U32, {0 : U32})
    +v27 : U32 <- IO.pure(U32, {10 : U32})
    +v28 : U32 <- codepoint_byte_offset_loop_2(v6, v21, v23, v24, v25, v26, v27)
    +v29 : U32 <- IO.pure(U32, U32.sub(v28, {1 : U32}))
    +v30 : String <- spiral_string_slice("Aéλ🙂Z", v19, v29)
    +v31 : U32 <- IO.pure(U32, {1 : U32})
    +v32 : U32 <- runtime_byte_0(v0, v31)
    +v33 : U32 <- IO.pure(U32, {0 : U32})
    +v34 : U32 <- runtime_byte_0(v3, v33)
    +v35 : U32 <- IO.pure(U32, {3 : U32})
    +v36 : U32 <- IO.pure(U32, {0 : U32})
    +v37 : U32 <- IO.pure(U32, {0 : U32})
    +v38 : U32 <- IO.pure(U32, {10 : U32})
    +v39 : U32 <- codepoint_byte_offset_loop_2(v6, v32, v34, v35, v36, v37, v38)
    +v40 : U32 <- IO.pure(U32, {1 : U32})
    +v41 : U32 <- runtime_byte_0(v0, v40)
    +v42 : U32 <- IO.pure(U32, {0 : U32})
    +v43 : U32 <- runtime_byte_0(v3, v42)
    +v44 : U32 <- IO.pure(U32, {4 : U32})
    +v45 : U32 <- IO.pure(U32, {0 : U32})
    +v46 : U32 <- IO.pure(U32, {0 : U32})
    +v47 : U32 <- IO.pure(U32, {10 : U32})
    +v48 : U32 <- codepoint_byte_offset_loop_2(v6, v41, v43, v44, v45, v46, v47)
    +v49 : U32 <- IO.pure(U32, U32.sub(v48, {1 : U32}))
    +v50 : String <- spiral_string_slice("Aéλ🙂Z", v39, v49)
    +v51 : U32 <- IO.pure(U32, {1 : U32})
    +v52 : U32 <- runtime_byte_0(v0, v51)
    +v53 : U32 <- IO.pure(U32, {0 : U32})
    +v54 : U32 <- runtime_byte_0(v3, v53)
    +v55 : U32 <- IO.pure(U32, {1 : U32})
    +v56 : U32 <- IO.pure(U32, {0 : U32})
    +v57 : U32 <- IO.pure(U32, {0 : U32})
    +v58 : U32 <- IO.pure(U32, {10 : U32})
    +v59 : U32 <- codepoint_byte_offset_loop_2(v6, v52, v54, v55, v56, v57, v58)
    +v60 : U32 <- IO.pure(U32, {1 : U32})
    +v61 : U32 <- runtime_byte_0(v0, v60)
    +v62 : U32 <- IO.pure(U32, {0 : U32})
    +v63 : U32 <- runtime_byte_0(v3, v62)
    +v64 : U32 <- IO.pure(U32, {4 : U32})
    +v65 : U32 <- IO.pure(U32, {0 : U32})
    +v66 : U32 <- IO.pure(U32, {0 : U32})
    +v67 : U32 <- IO.pure(U32, {10 : U32})
    +v68 : U32 <- codepoint_byte_offset_loop_2(v6, v61, v63, v64, v65, v66, v67)
    +v69 : U32 <- IO.pure(U32, U32.sub(v68, {1 : U32}))
    +v70 : String <- spiral_string_slice("Aéλ🙂Z", v59, v69)
    +v71 : U32 <- IO.pure(U32, {1 : U32})
    +v72 : U32 <- runtime_byte_0(v0, v71)
    +v73 : U32 <- IO.pure(U32, {0 : U32})
    +v74 : U32 <- runtime_byte_0(v3, v73)
    +v75 : U32 <- IO.pure(U32, {3 : U32})
    +v76 : U32 <- IO.pure(U32, {0 : U32})
    +v77 : U32 <- IO.pure(U32, {0 : U32})
    +v78 : U32 <- IO.pure(U32, {10 : U32})
    +v79 : U32 <- codepoint_byte_offset_loop_2(v6, v72, v74, v75, v76, v77, v78)
    +v80 : U32 <- IO.pure(U32, {0 : U32})
    +v81 : U32 <- runtime_byte_0(v30, v80)
    +v82 : String <- IO.pure(String, "é")
    +v83 : U32 <- IO.pure(U32, {0 : U32})
    +v84 : U32 <- runtime_byte_0(v82, v83)
    +v85 : U32 <- IO.pure(U32, {3 : U32})
    +v86 : U32 <- runtime_byte_0(v50, v85)
    +v87 : String <- IO.pure(String, "🙂")
    +v88 : U32 <- IO.pure(U32, {3 : U32})
    +v89 : U32 <- runtime_byte_0(v87, v88)
    +v90 : Bool <- IO.pure(Bool, U32.is_eq(v10, {5 : U32}))
    spiral_main_if8(v90, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
