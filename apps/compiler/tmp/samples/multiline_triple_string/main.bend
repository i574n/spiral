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
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25_if26_if27_if28(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool, +v58: U32, +v59: Bool, +v60: Bool, +v61: U32, +v62: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v66: Bool, +v67: U32, +v68: Bool, +v69: Bool, +v70: U32, +v71: Bool, +v72: Bool, +v73: U32, +v74: Bool, +v75: Bool, +v76: U32, +v77: Bool, +v78: Bool, +v79: U32, +v80: Bool, +v81: Bool, +v82: U32, +v83: Bool, +v84: Bool, +v85: U32, +v86: Bool, +v87: Bool, +v88: U32, +v89: Bool, +v90: Bool, +v91: U32, +v92: Bool, +v93: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {28 : U32}
    case False{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25_if26_if27(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool, +v58: U32, +v59: Bool, +v60: Bool, +v61: U32, +v62: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v66: Bool, +v67: U32, +v68: Bool, +v69: Bool, +v70: U32, +v71: Bool, +v72: Bool, +v73: U32, +v74: Bool, +v75: Bool, +v76: U32, +v77: Bool, +v78: Bool, +v79: U32, +v80: Bool, +v81: Bool, +v82: U32, +v83: Bool, +v84: Bool, +v85: U32, +v86: Bool, +v87: Bool, +v88: U32, +v89: Bool, +v90: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {27 : U32}
    case False{}:
      do IO<U32>:
        +v91 : U32 <- IO.pure(U32, spiral_string_byte_at(v5, {3 : U32}))
        +v92 : Bool <- IO.pure(Bool, U32.is_eq(v91, {99 : U32}))
        +v93 : Bool <- IO.pure(Bool, Bool.xor(v92, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25_if26_if27_if28(v93, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25_if26(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool, +v58: U32, +v59: Bool, +v60: Bool, +v61: U32, +v62: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v66: Bool, +v67: U32, +v68: Bool, +v69: Bool, +v70: U32, +v71: Bool, +v72: Bool, +v73: U32, +v74: Bool, +v75: Bool, +v76: U32, +v77: Bool, +v78: Bool, +v79: U32, +v80: Bool, +v81: Bool, +v82: U32, +v83: Bool, +v84: Bool, +v85: U32, +v86: Bool, +v87: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {26 : U32}
    case False{}:
      do IO<U32>:
        +v88 : U32 <- IO.pure(U32, spiral_string_bytes(v5))
        +v89 : Bool <- IO.pure(Bool, U32.is_eq(v88, {5 : U32}))
        +v90 : Bool <- IO.pure(Bool, Bool.xor(v89, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25_if26_if27(v90, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool, +v58: U32, +v59: Bool, +v60: Bool, +v61: U32, +v62: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v66: Bool, +v67: U32, +v68: Bool, +v69: Bool, +v70: U32, +v71: Bool, +v72: Bool, +v73: U32, +v74: Bool, +v75: Bool, +v76: U32, +v77: Bool, +v78: Bool, +v79: U32, +v80: Bool, +v81: Bool, +v82: U32, +v83: Bool, +v84: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {25 : U32}
    case False{}:
      do IO<U32>:
        +v85 : U32 <- IO.pure(U32, spiral_string_byte_at(v4, {22 : U32}))
        +v86 : Bool <- IO.pure(Bool, U32.is_eq(v85, {100 : U32}))
        +v87 : Bool <- IO.pure(Bool, Bool.xor(v86, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25_if26(v87, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool, +v58: U32, +v59: Bool, +v60: Bool, +v61: U32, +v62: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v66: Bool, +v67: U32, +v68: Bool, +v69: Bool, +v70: U32, +v71: Bool, +v72: Bool, +v73: U32, +v74: Bool, +v75: Bool, +v76: U32, +v77: Bool, +v78: Bool, +v79: U32, +v80: Bool, +v81: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {24 : U32}
    case False{}:
      do IO<U32>:
        +v82 : U32 <- IO.pure(U32, spiral_string_byte_at(v4, {17 : U32}))
        +v83 : Bool <- IO.pure(Bool, U32.is_eq(v82, {10 : U32}))
        +v84 : Bool <- IO.pure(Bool, Bool.xor(v83, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25(v84, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool, +v58: U32, +v59: Bool, +v60: Bool, +v61: U32, +v62: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v66: Bool, +v67: U32, +v68: Bool, +v69: Bool, +v70: U32, +v71: Bool, +v72: Bool, +v73: U32, +v74: Bool, +v75: Bool, +v76: U32, +v77: Bool, +v78: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {23 : U32}
    case False{}:
      do IO<U32>:
        +v79 : U32 <- IO.pure(U32, spiral_string_byte_at(v4, {10 : U32}))
        +v80 : Bool <- IO.pure(Bool, U32.is_eq(v79, {115 : U32}))
        +v81 : Bool <- IO.pure(Bool, Bool.xor(v80, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24(v81, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool, +v58: U32, +v59: Bool, +v60: Bool, +v61: U32, +v62: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v66: Bool, +v67: U32, +v68: Bool, +v69: Bool, +v70: U32, +v71: Bool, +v72: Bool, +v73: U32, +v74: Bool, +v75: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {22 : U32}
    case False{}:
      do IO<U32>:
        +v76 : U32 <- IO.pure(U32, spiral_string_byte_at(v4, {6 : U32}))
        +v77 : Bool <- IO.pure(Bool, U32.is_eq(v76, {32 : U32}))
        +v78 : Bool <- IO.pure(Bool, Bool.xor(v77, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23(v78, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool, +v58: U32, +v59: Bool, +v60: Bool, +v61: U32, +v62: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v66: Bool, +v67: U32, +v68: Bool, +v69: Bool, +v70: U32, +v71: Bool, +v72: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {21 : U32}
    case False{}:
      do IO<U32>:
        +v73 : U32 <- IO.pure(U32, spiral_string_bytes(v4))
        +v74 : Bool <- IO.pure(Bool, U32.is_eq(v73, {23 : U32}))
        +v75 : Bool <- IO.pure(Bool, Bool.xor(v74, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22(v75, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool, +v58: U32, +v59: Bool, +v60: Bool, +v61: U32, +v62: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v66: Bool, +v67: U32, +v68: Bool, +v69: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {20 : U32}
    case False{}:
      do IO<U32>:
        +v70 : U32 <- IO.pure(U32, spiral_string_byte_at(v3, {4 : U32}))
        +v71 : Bool <- IO.pure(Bool, U32.is_eq(v70, {34 : U32}))
        +v72 : Bool <- IO.pure(Bool, Bool.xor(v71, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21(v72, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool, +v58: U32, +v59: Bool, +v60: Bool, +v61: U32, +v62: Bool, +v63: Bool, +v64: U32, +v65: Bool, +v66: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {19 : U32}
    case False{}:
      do IO<U32>:
        +v67 : U32 <- IO.pure(U32, spiral_string_bytes(v3))
        +v68 : Bool <- IO.pure(Bool, U32.is_eq(v67, {7 : U32}))
        +v69 : Bool <- IO.pure(Bool, Bool.xor(v68, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20(v69, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool, +v58: U32, +v59: Bool, +v60: Bool, +v61: U32, +v62: Bool, +v63: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {18 : U32}
    case False{}:
      do IO<U32>:
        +v64 : U32 <- IO.pure(U32, spiral_string_byte_at(v2, {7 : U32}))
        +v65 : Bool <- IO.pure(Bool, U32.is_eq(v64, {34 : U32}))
        +v66 : Bool <- IO.pure(Bool, Bool.xor(v65, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19(v66, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool, +v58: U32, +v59: Bool, +v60: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {17 : U32}
    case False{}:
      do IO<U32>:
        +v61 : U32 <- IO.pure(U32, spiral_string_bytes(v2))
        +v62 : Bool <- IO.pure(Bool, U32.is_eq(v61, {8 : U32}))
        +v63 : Bool <- IO.pure(Bool, Bool.xor(v62, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18(v63, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool, +v56: Bool, +v57: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {16 : U32}
    case False{}:
      do IO<U32>:
        +v58 : U32 <- IO.pure(U32, spiral_string_bytes(v1))
        +v59 : Bool <- IO.pure(Bool, U32.is_eq(v58, {3 : U32}))
        +v60 : Bool <- IO.pure(Bool, Bool.xor(v59, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17(v60, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool, +v53: U32, +v54: Bool, +v55: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {15 : U32}
    case False{}:
      do IO<U32>:
        +v56 : Bool <- IO.pure(Bool, U32.is_eq(v0, {16 : U32}))
        +v57 : Bool <- IO.pure(Bool, Bool.xor(v56, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16(v57, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool, +v50: U32, +v51: Bool, +v52: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {14 : U32}
    case False{}:
      do IO<U32>:
        +v53 : U32 <- IO.pure(U32, spiral_string_byte_at(v10, {5 : U32}))
        +v54 : Bool <- IO.pure(Bool, U32.is_eq(v53, {10 : U32}))
        +v55 : Bool <- IO.pure(Bool, Bool.xor(v54, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15(v55, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool, +v47: U32, +v48: Bool, +v49: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {13 : U32}
    case False{}:
      do IO<U32>:
        +v50 : U32 <- IO.pure(U32, spiral_string_byte_at(v10, {0 : U32}))
        +v51 : Bool <- IO.pure(Bool, U32.is_eq(v50, {10 : U32}))
        +v52 : Bool <- IO.pure(Bool, Bool.xor(v51, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14(v52, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool, +v44: U32, +v45: Bool, +v46: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {12 : U32}
    case False{}:
      do IO<U32>:
        +v47 : U32 <- IO.pure(U32, spiral_string_bytes(v10))
        +v48 : Bool <- IO.pure(Bool, U32.is_eq(v47, {11 : U32}))
        +v49 : Bool <- IO.pure(Bool, Bool.xor(v48, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13(v49, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool, +v41: U32, +v42: Bool, +v43: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {11 : U32}
    case False{}:
      do IO<U32>:
        +v44 : U32 <- IO.pure(U32, spiral_string_byte_at(v9, {82 : U32}))
        +v45 : Bool <- IO.pure(Bool, U32.is_eq(v44, {100 : U32}))
        +v46 : Bool <- IO.pure(Bool, Bool.xor(v45, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12(v46, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool, +v38: U32, +v39: Bool, +v40: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {10 : U32}
    case False{}:
      do IO<U32>:
        +v41 : U32 <- IO.pure(U32, spiral_string_byte_at(v9, {57 : U32}))
        +v42 : Bool <- IO.pure(Bool, U32.is_eq(v41, {105 : U32}))
        +v43 : Bool <- IO.pure(Bool, Bool.xor(v42, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11(v43, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool, +v35: U32, +v36: Bool, +v37: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {9 : U32}
    case False{}:
      do IO<U32>:
        +v38 : U32 <- IO.pure(U32, spiral_string_byte_at(v9, {39 : U32}))
        +v39 : Bool <- IO.pure(Bool, U32.is_eq(v38, {36 : U32}))
        +v40 : Bool <- IO.pure(Bool, Bool.xor(v39, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10(v40, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool, +v32: U32, +v33: Bool, +v34: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {8 : U32}
    case False{}:
      do IO<U32>:
        +v35 : U32 <- IO.pure(U32, spiral_string_byte_at(v9, {38 : U32}))
        +v36 : Bool <- IO.pure(Bool, U32.is_eq(v35, {10 : U32}))
        +v37 : Bool <- IO.pure(Bool, Bool.xor(v36, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9(v37, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool, +v29: U32, +v30: Bool, +v31: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {7 : U32}
    case False{}:
      do IO<U32>:
        +v32 : U32 <- IO.pure(U32, spiral_string_byte_at(v9, {37 : U32}))
        +v33 : Bool <- IO.pure(Bool, U32.is_eq(v32, {10 : U32}))
        +v34 : Bool <- IO.pure(Bool, Bool.xor(v33, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8(v34, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool, +v26: U32, +v27: Bool, +v28: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {6 : U32}
    case False{}:
      do IO<U32>:
        +v29 : U32 <- IO.pure(U32, spiral_string_byte_at(v9, {5 : U32}))
        +v30 : Bool <- IO.pure(Bool, U32.is_eq(v29, {10 : U32}))
        +v31 : Bool <- IO.pure(Bool, Bool.xor(v30, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7(v31, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31)

@unsafe
def spiral_main_if1_if2_if3_if4_if5(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool, +v23: U32, +v24: Bool, +v25: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {5 : U32}
    case False{}:
      do IO<U32>:
        +v26 : U32 <- IO.pure(U32, spiral_string_bytes(v9))
        +v27 : Bool <- IO.pure(Bool, U32.is_eq(v26, {83 : U32}))
        +v28 : Bool <- IO.pure(Bool, Bool.xor(v27, True{}))
        spiral_main_if1_if2_if3_if4_if5_if6(v28, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28)

@unsafe
def spiral_main_if1_if2_if3_if4(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool, +v20: U32, +v21: Bool, +v22: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {4 : U32}
    case False{}:
      do IO<U32>:
        +v23 : U32 <- IO.pure(U32, spiral_string_byte_at(v8, {1 : U32}))
        +v24 : Bool <- IO.pure(Bool, U32.is_eq(v23, {92 : U32}))
        +v25 : Bool <- IO.pure(Bool, Bool.xor(v24, True{}))
        spiral_main_if1_if2_if3_if4_if5(v25, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25)

@unsafe
def spiral_main_if1_if2_if3(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool, +v17: U32, +v18: Bool, +v19: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {3 : U32}
    case False{}:
      do IO<U32>:
        +v20 : U32 <- IO.pure(U32, spiral_string_bytes(v8))
        +v21 : Bool <- IO.pure(Bool, U32.is_eq(v20, {4 : U32}))
        +v22 : Bool <- IO.pure(Bool, Bool.xor(v21, True{}))
        spiral_main_if1_if2_if3_if4(v22, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22)

@unsafe
def spiral_main_if1_if2(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool, +v14: U32, +v15: Bool, +v16: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {2 : U32}
    case False{}:
      do IO<U32>:
        +v17 : U32 <- IO.pure(U32, spiral_string_bytes(v7))
        +v18 : Bool <- IO.pure(Bool, U32.is_eq(v17, {0 : U32}))
        +v19 : Bool <- IO.pure(Bool, Bool.xor(v18, True{}))
        spiral_main_if1_if2_if3(v19, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19)

@unsafe
def spiral_main_if1(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {1 : U32}
    case False{}:
      do IO<U32>:
        +v14 : U32 <- IO.pure(U32, spiral_string_byte_at(v6, {2 : U32}))
        +v15 : Bool <- IO.pure(Bool, U32.is_eq(v14, {34 : U32}))
        +v16 : Bool <- IO.pure(Bool, Bool.xor(v15, True{}))
        spiral_main_if1_if2(v16, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {16 : U32})
    +v1 : String <- IO.pure(String, "x\ny")
    +v2 : String <- IO.pure(String, "say \"hi\"")
    +v3 : String <- IO.pure(String, "a \"\"\" b")
    +v4 : String <- IO.pure(String, "first\n    second\n\nthird")
    +v5 : String <- IO.pure(String, "ab\ncd")
    +v6 : String <- IO.pure(String, "a \"b\" c")
    +v7 : String <- IO.pure(String, "")
    +v8 : String <- IO.pure(String, "a\\nb")
    +v9 : String <- IO.pure(String, "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented")
    +v10 : String <- IO.pure(String, "\ntop\n\nlevel")
    +v11 : U32 <- IO.pure(U32, spiral_string_bytes(v6))
    +v12 : Bool <- IO.pure(Bool, U32.is_eq(v11, {7 : U32}))
    +v13 : Bool <- IO.pure(Bool, Bool.xor(v12, True{}))
    spiral_main_if1(v13, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
