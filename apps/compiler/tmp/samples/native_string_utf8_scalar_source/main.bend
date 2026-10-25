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
def runtime_byte_1(+v0: String, +v1: U32) -> IO(U32):
  do IO<U32>:
    +v2 : U32 <- IO.pure(U32, spiral_string_byte_at(v0, v1))
    return v2

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if6_if7(+c: Bool, +v17: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v19 : Bool <- IO.pure(Bool, spiral_i32_lt(v17, {192 : U32}))
        return v19

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if6_if8(+c: Bool, +v8: U32, +v17: U32) -> IO(U32):
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
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if6(+c: Bool, +v0: String, +v8: U32, +v13: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is truncated.")
    case False{}:
      do IO<U32>:
        +v16 : U32 <- runtime_byte_1(v0, v13)
        +v17 : U32 <- IO.pure(U32, v16)
        +v18 : Bool <- IO.pure(Bool, spiral_i32_lt(v17, {128 : U32}))
        +v20 : Bool <- utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if6_if7(v18, v17)
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if6_if8(v20, v8, v17)

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if11(+c: Bool, +v34: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v38 : Bool <- IO.pure(Bool, spiral_i32_lt(v34, {192 : U32}))
        return v38

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if12_if13(+c: Bool, +v36: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v41 : Bool <- IO.pure(Bool, spiral_i32_lt(v36, {192 : U32}))
        return v41

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if12_if14_if15_if16_if17(+c: Bool, +v49: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence encodes a surrogate.")
    case False{}:
      do IO<U32>:
        return v49

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if12_if14_if15_if16(+c: Bool, +v49: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v53 : Bool <- IO.pure(Bool, spiral_i32_le(v49, {57343 : U32}))
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if12_if14_if15_if16_if17(v53, v49)
    case False{}:
      do IO<U32>:
        return v49

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if12_if14_if15(+c: Bool, +v49: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is overlong.")
    case False{}:
      do IO<U32>:
        +v52 : Bool <- IO.pure(Bool, spiral_i32_ge(v49, {55296 : U32}))
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if12_if14_if15_if16(v52, v49)

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if12_if14(+c: Bool, +v8: U32, +v34: U32, +v36: U32) -> IO(U32):
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
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if12_if14_if15(v50, v49)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if12(+c: Bool, +v8: U32, +v34: U32, +v36: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v40 : Bool <- IO.pure(Bool, spiral_i32_lt(v36, {128 : U32}))
        +v42 : Bool <- utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if12_if13(v40, v36)
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if12_if14(v42, v8, v34, v36)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10(+c: Bool, +v0: String, +v1: U32, +v8: U32, +v29: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is truncated.")
    case False{}:
      do IO<U32>:
        +v32 : U32 <- IO.pure(U32, U32.add(v1, {1 : U32}))
        +v33 : U32 <- runtime_byte_1(v0, v32)
        +v34 : U32 <- IO.pure(U32, v33)
        +v35 : U32 <- runtime_byte_1(v0, v29)
        +v36 : U32 <- IO.pure(U32, v35)
        +v37 : Bool <- IO.pure(Bool, spiral_i32_lt(v34, {128 : U32}))
        +v39 : Bool <- utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if11(v37, v34)
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10_if12(v39, v8, v34, v36)

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if20(+c: Bool, +v69: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v76 : Bool <- IO.pure(Bool, spiral_i32_lt(v69, {192 : U32}))
        return v76

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21_if22(+c: Bool, +v72: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v79 : Bool <- IO.pure(Bool, spiral_i32_lt(v72, {192 : U32}))
        return v79

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21_if23_if24(+c: Bool, +v74: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        return False{}
    case False{}:
      do IO<Bool>:
        +v82 : Bool <- IO.pure(Bool, spiral_i32_lt(v74, {192 : U32}))
        return v82

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21_if23_if25_if26_if27(+c: Bool, +v93: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 scalar is above U+10FFFF.")
    case False{}:
      do IO<U32>:
        return v93

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21_if23_if25_if26(+c: Bool, +v93: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is overlong.")
    case False{}:
      do IO<U32>:
        +v96 : Bool <- IO.pure(Bool, spiral_i32_gt(v93, {1114111 : U32}))
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21_if23_if25_if26_if27(v96, v93)

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21_if23_if25(+c: Bool, +v8: U32, +v69: U32, +v72: U32, +v74: U32) -> IO(U32):
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
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21_if23_if25_if26(v94, v93)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21_if23(+c: Bool, +v8: U32, +v69: U32, +v72: U32, +v74: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v81 : Bool <- IO.pure(Bool, spiral_i32_lt(v74, {128 : U32}))
        +v83 : Bool <- utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21_if23_if24(v81, v74)
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21_if23_if25(v83, v8, v69, v72, v74)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21(+c: Bool, +v8: U32, +v69: U32, +v72: U32, +v74: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v78 : Bool <- IO.pure(Bool, spiral_i32_lt(v72, {128 : U32}))
        +v80 : Bool <- utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21_if22(v78, v72)
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21_if23(v80, v8, v69, v72, v74)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence has an invalid continuation byte.")

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19(+c: Bool, +v0: String, +v1: U32, +v8: U32, +v64: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 sequence is truncated.")
    case False{}:
      do IO<U32>:
        +v67 : U32 <- IO.pure(U32, U32.add(v1, {1 : U32}))
        +v68 : U32 <- runtime_byte_1(v0, v67)
        +v69 : U32 <- IO.pure(U32, v68)
        +v70 : U32 <- IO.pure(U32, U32.add(v1, {2 : U32}))
        +v71 : U32 <- runtime_byte_1(v0, v70)
        +v72 : U32 <- IO.pure(U32, v71)
        +v73 : U32 <- runtime_byte_1(v0, v64)
        +v74 : U32 <- IO.pure(U32, v73)
        +v75 : Bool <- IO.pure(Bool, spiral_i32_lt(v69, {128 : U32}))
        +v77 : Bool <- utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if20(v75, v69)
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19_if21(v77, v8, v69, v72, v74)

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v8: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v64 : U32 <- IO.pure(U32, U32.add(v1, {3 : U32}))
        +v65 : Bool <- IO.pure(Bool, spiral_i32_ge(v64, v2))
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18_if19(v65, v0, v1, v8, v64)
    case False{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 scalar starts with an invalid lead byte.")

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v8: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v29 : U32 <- IO.pure(U32, U32.add(v1, {2 : U32}))
        +v30 : Bool <- IO.pure(Bool, spiral_i32_ge(v29, v2))
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if10(v30, v0, v1, v8, v29)
    case False{}:
      do IO<U32>:
        +v63 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {245 : U32}))
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9_if18(v63, v0, v1, v2, v8)

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v8: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v13 : U32 <- IO.pure(U32, U32.add(v1, {1 : U32}))
        +v14 : Bool <- IO.pure(Bool, spiral_i32_ge(v13, v2))
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if6(v14, v0, v8, v13)
    case False{}:
      do IO<U32>:
        +v28 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {240 : U32}))
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5_if9(v28, v0, v1, v2, v8)

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3_if4(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v8: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 scalar starts with an invalid lead byte.")
    case False{}:
      do IO<U32>:
        +v12 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {224 : U32}))
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4_if5(v12, v0, v1, v2, v8)

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2_if3(+c: Bool, +v0: String, +v1: U32, +v2: U32, +v8: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return v8
    case False{}:
      do IO<U32>:
        +v10 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {194 : U32}))
        utf8_scalar_at_byte_offset_0_if1_if2_if3_if4(v10, v0, v1, v2, v8)

@unsafe
def utf8_scalar_at_byte_offset_0_if1_if2(+c: Bool, +v0: String, +v1: U32, +v2: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 byte offset is outside the string.")
    case False{}:
      do IO<U32>:
        +v7 : U32 <- runtime_byte_1(v0, v1)
        +v8 : U32 <- IO.pure(U32, v7)
        +v9 : Bool <- IO.pure(Bool, spiral_i32_lt(v8, {128 : U32}))
        utf8_scalar_at_byte_offset_0_if1_if2_if3(v9, v0, v1, v2, v8)

@unsafe
def utf8_scalar_at_byte_offset_0_if1(+c: Bool, +v0: String, +v1: U32, +v2: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        IO.die(U32, 1, "UTF-8 byte offset is negative.")
    case False{}:
      do IO<U32>:
        +v5 : Bool <- IO.pure(Bool, spiral_i32_ge(v1, v2))
        utf8_scalar_at_byte_offset_0_if1_if2(v5, v0, v1, v2)

@unsafe
def utf8_scalar_at_byte_offset_0(+v0: String, +v1: U32) -> IO(U32):
  do IO<U32>:
    +v2 : U32 <- IO.pure(U32, spiral_string_bytes(v0))
    +v3 : Bool <- IO.pure(Bool, spiral_i32_lt(v1, {0 : U32}))
    utf8_scalar_at_byte_offset_0_if1(v3, v0, v1, v2)

@unsafe
def spiral_main_if28_if29_if30_if31_if32(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {5 : U32}

@unsafe
def spiral_main_if28_if29_if30_if31(+c: Bool, +v10: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v15 : Bool <- IO.pure(Bool, U32.is_eq(v10, {90 : U32}))
        spiral_main_if28_if29_if30_if31_if32(v15)
    case False{}:
      do IO<U32>:
        return {4 : U32}

@unsafe
def spiral_main_if28_if29_if30(+c: Bool, +v8: U32, +v10: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v14 : Bool <- IO.pure(Bool, U32.is_eq(v8, {128578 : U32}))
        spiral_main_if28_if29_if30_if31(v14, v10)
    case False{}:
      do IO<U32>:
        return {3 : U32}

@unsafe
def spiral_main_if28_if29(+c: Bool, +v6: U32, +v8: U32, +v10: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v13 : Bool <- IO.pure(Bool, U32.is_eq(v6, {955 : U32}))
        spiral_main_if28_if29_if30(v13, v8, v10)
    case False{}:
      do IO<U32>:
        return {2 : U32}

@unsafe
def spiral_main_if28(+c: Bool, +v4: U32, +v6: U32, +v8: U32, +v10: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v12 : Bool <- IO.pure(Bool, U32.is_eq(v4, {233 : U32}))
        spiral_main_if28_if29(v12, v6, v8, v10)
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : String <- IO.pure(String, "Aéλ🙂Z")
    +v1 : U32 <- IO.pure(U32, {0 : U32})
    +v2 : U32 <- utf8_scalar_at_byte_offset_0(v0, v1)
    +v3 : U32 <- IO.pure(U32, {1 : U32})
    +v4 : U32 <- utf8_scalar_at_byte_offset_0(v0, v3)
    +v5 : U32 <- IO.pure(U32, {3 : U32})
    +v6 : U32 <- utf8_scalar_at_byte_offset_0(v0, v5)
    +v7 : U32 <- IO.pure(U32, {5 : U32})
    +v8 : U32 <- utf8_scalar_at_byte_offset_0(v0, v7)
    +v9 : U32 <- IO.pure(U32, {9 : U32})
    +v10 : U32 <- utf8_scalar_at_byte_offset_0(v0, v9)
    +v11 : Bool <- IO.pure(Bool, U32.is_eq(v2, {65 : U32}))
    spiral_main_if28(v11, v4, v6, v8, v10)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
