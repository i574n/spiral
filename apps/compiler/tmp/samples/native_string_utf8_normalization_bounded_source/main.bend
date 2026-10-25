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
def spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({111 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        return (v2, {4294967295 : U32})

@unsafe
def spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37_if38_if39_if40_if41_if42(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({111 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v33 : Bool <- IO.pure(Bool, U32.is_eq(v2, {245 : U32}))
        spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37_if38_if39_if40_if41_if42_if43(v33, v2)

@unsafe
def spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37_if38_if39_if40_if41(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({101 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v32 : Bool <- IO.pure(Bool, U32.is_eq(v2, {243 : U32}))
        spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37_if38_if39_if40_if41_if42(v32, v2)

@unsafe
def spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37_if38_if39_if40(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({99 : U32}, {807 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v31 : Bool <- IO.pure(Bool, U32.is_eq(v2, {233 : U32}))
        spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37_if38_if39_if40_if41(v31, v2)

@unsafe
def spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37_if38_if39(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {776 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v30 : Bool <- IO.pure(Bool, U32.is_eq(v2, {231 : U32}))
        spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37_if38_if39_if40(v30, v2)

@unsafe
def spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37_if38(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v29 : Bool <- IO.pure(Bool, U32.is_eq(v2, {228 : U32}))
        spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37_if38_if39(v29, v2)

@unsafe
def spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v28 : Bool <- IO.pure(Bool, U32.is_eq(v2, {227 : U32}))
        spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37_if38(v28, v2)

@unsafe
def spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {768 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v27 : Bool <- IO.pure(Bool, U32.is_eq(v2, {225 : U32}))
        spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36_if37(v27, v2)

@unsafe
def spiral_main_if28_if29_if30_if31_if32_if33_if34_if35(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({79 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v26 : Bool <- IO.pure(Bool, U32.is_eq(v2, {224 : U32}))
        spiral_main_if28_if29_if30_if31_if32_if33_if34_if35_if36(v26, v2)

@unsafe
def spiral_main_if28_if29_if30_if31_if32_if33_if34(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({79 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v25 : Bool <- IO.pure(Bool, U32.is_eq(v2, {213 : U32}))
        spiral_main_if28_if29_if30_if31_if32_if33_if34_if35(v25, v2)

@unsafe
def spiral_main_if28_if29_if30_if31_if32_if33(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({69 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v24 : Bool <- IO.pure(Bool, U32.is_eq(v2, {211 : U32}))
        spiral_main_if28_if29_if30_if31_if32_if33_if34(v24, v2)

@unsafe
def spiral_main_if28_if29_if30_if31_if32(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({67 : U32}, {807 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v23 : Bool <- IO.pure(Bool, U32.is_eq(v2, {201 : U32}))
        spiral_main_if28_if29_if30_if31_if32_if33(v23, v2)

@unsafe
def spiral_main_if28_if29_if30_if31(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {776 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v22 : Bool <- IO.pure(Bool, U32.is_eq(v2, {199 : U32}))
        spiral_main_if28_if29_if30_if31_if32(v22, v2)

@unsafe
def spiral_main_if28_if29_if30(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v21 : Bool <- IO.pure(Bool, U32.is_eq(v2, {196 : U32}))
        spiral_main_if28_if29_if30_if31(v21, v2)

@unsafe
def spiral_main_if28_if29(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v20 : Bool <- IO.pure(Bool, U32.is_eq(v2, {195 : U32}))
        spiral_main_if28_if29_if30(v20, v2)

@unsafe
def spiral_main_if28(+c: Bool, +v2: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {768 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v19 : Bool <- IO.pure(Bool, U32.is_eq(v2, {193 : U32}))
        spiral_main_if28_if29(v19, v2)

@unsafe
def spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54_if55_if56_if57_if58_if59_if60(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({111 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        return (v5, {4294967295 : U32})

@unsafe
def spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54_if55_if56_if57_if58_if59(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({111 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v81 : Bool <- IO.pure(Bool, U32.is_eq(v5, {245 : U32}))
        spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54_if55_if56_if57_if58_if59_if60(v81, v5)

@unsafe
def spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54_if55_if56_if57_if58(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({101 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v80 : Bool <- IO.pure(Bool, U32.is_eq(v5, {243 : U32}))
        spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54_if55_if56_if57_if58_if59(v80, v5)

@unsafe
def spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54_if55_if56_if57(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({99 : U32}, {807 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v79 : Bool <- IO.pure(Bool, U32.is_eq(v5, {233 : U32}))
        spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54_if55_if56_if57_if58(v79, v5)

@unsafe
def spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54_if55_if56(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {776 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v78 : Bool <- IO.pure(Bool, U32.is_eq(v5, {231 : U32}))
        spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54_if55_if56_if57(v78, v5)

@unsafe
def spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54_if55(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v77 : Bool <- IO.pure(Bool, U32.is_eq(v5, {228 : U32}))
        spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54_if55_if56(v77, v5)

@unsafe
def spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v76 : Bool <- IO.pure(Bool, U32.is_eq(v5, {227 : U32}))
        spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54_if55(v76, v5)

@unsafe
def spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {768 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v75 : Bool <- IO.pure(Bool, U32.is_eq(v5, {225 : U32}))
        spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53_if54(v75, v5)

@unsafe
def spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({79 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v74 : Bool <- IO.pure(Bool, U32.is_eq(v5, {224 : U32}))
        spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52_if53(v74, v5)

@unsafe
def spiral_main_k44_if45_if46_if47_if48_if49_if50_if51(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({79 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v73 : Bool <- IO.pure(Bool, U32.is_eq(v5, {213 : U32}))
        spiral_main_k44_if45_if46_if47_if48_if49_if50_if51_if52(v73, v5)

@unsafe
def spiral_main_k44_if45_if46_if47_if48_if49_if50(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({69 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v72 : Bool <- IO.pure(Bool, U32.is_eq(v5, {211 : U32}))
        spiral_main_k44_if45_if46_if47_if48_if49_if50_if51(v72, v5)

@unsafe
def spiral_main_k44_if45_if46_if47_if48_if49(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({67 : U32}, {807 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v71 : Bool <- IO.pure(Bool, U32.is_eq(v5, {201 : U32}))
        spiral_main_k44_if45_if46_if47_if48_if49_if50(v71, v5)

@unsafe
def spiral_main_k44_if45_if46_if47_if48(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {776 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v70 : Bool <- IO.pure(Bool, U32.is_eq(v5, {199 : U32}))
        spiral_main_k44_if45_if46_if47_if48_if49(v70, v5)

@unsafe
def spiral_main_k44_if45_if46_if47(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v69 : Bool <- IO.pure(Bool, U32.is_eq(v5, {196 : U32}))
        spiral_main_k44_if45_if46_if47_if48(v69, v5)

@unsafe
def spiral_main_k44_if45_if46(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v68 : Bool <- IO.pure(Bool, U32.is_eq(v5, {195 : U32}))
        spiral_main_k44_if45_if46_if47(v68, v5)

@unsafe
def spiral_main_k44_if45(+c: Bool, +v5: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {768 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v67 : Bool <- IO.pure(Bool, U32.is_eq(v5, {193 : U32}))
        spiral_main_k44_if45_if46(v67, v5)

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72_if73_if74_if75_if76_if77(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({111 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        return (v8, {4294967295 : U32})

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72_if73_if74_if75_if76(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({111 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v129 : Bool <- IO.pure(Bool, U32.is_eq(v8, {245 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72_if73_if74_if75_if76_if77(v129, v8)

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72_if73_if74_if75(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({101 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v128 : Bool <- IO.pure(Bool, U32.is_eq(v8, {243 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72_if73_if74_if75_if76(v128, v8)

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72_if73_if74(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({99 : U32}, {807 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v127 : Bool <- IO.pure(Bool, U32.is_eq(v8, {233 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72_if73_if74_if75(v127, v8)

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72_if73(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {776 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v126 : Bool <- IO.pure(Bool, U32.is_eq(v8, {231 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72_if73_if74(v126, v8)

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v125 : Bool <- IO.pure(Bool, U32.is_eq(v8, {228 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72_if73(v125, v8)

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v124 : Bool <- IO.pure(Bool, U32.is_eq(v8, {227 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71_if72(v124, v8)

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({97 : U32}, {768 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v123 : Bool <- IO.pure(Bool, U32.is_eq(v8, {225 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70_if71(v123, v8)

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({79 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v122 : Bool <- IO.pure(Bool, U32.is_eq(v8, {224 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69_if70(v122, v8)

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({79 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v121 : Bool <- IO.pure(Bool, U32.is_eq(v8, {213 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68_if69(v121, v8)

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65_if66_if67(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({69 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v120 : Bool <- IO.pure(Bool, U32.is_eq(v8, {211 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65_if66_if67_if68(v120, v8)

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65_if66(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({67 : U32}, {807 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v119 : Bool <- IO.pure(Bool, U32.is_eq(v8, {201 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65_if66_if67(v119, v8)

@unsafe
def spiral_main_k44_k61_if62_if63_if64_if65(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {776 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v118 : Bool <- IO.pure(Bool, U32.is_eq(v8, {199 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65_if66(v118, v8)

@unsafe
def spiral_main_k44_k61_if62_if63_if64(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {771 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v117 : Bool <- IO.pure(Bool, U32.is_eq(v8, {196 : U32}))
        spiral_main_k44_k61_if62_if63_if64_if65(v117, v8)

@unsafe
def spiral_main_k44_k61_if62_if63(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {769 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v116 : Bool <- IO.pure(Bool, U32.is_eq(v8, {195 : U32}))
        spiral_main_k44_k61_if62_if63_if64(v116, v8)

@unsafe
def spiral_main_k44_k61_if62(+c: Bool, +v8: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({65 : U32}, {768 : U32})
    case False{}:
      do IO<U32 & U32>:
        +v115 : Bool <- IO.pure(Bool, U32.is_eq(v8, {193 : U32}))
        spiral_main_k44_k61_if62_if63(v115, v8)

@unsafe
def spiral_main_k44_k61_k78_if79(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {233 : U32}
    case False{}:
      do IO<U32>:
        return {4294967295 : U32}

@unsafe
def spiral_main_k44_k61_k78_if80(+c: Bool, +v11: U32, +v163: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({101 : U32}, v11)
    case False{}:
      do IO<U32 & U32>:
        return (v163, {4294967295 : U32})

@unsafe
def spiral_main_k44_k61_k78_k81_if82_if83(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {245 : U32}
    case False{}:
      do IO<U32>:
        return {4294967295 : U32}

@unsafe
def spiral_main_k44_k61_k78_k81_if82(+c: Bool, +v14: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {243 : U32}
    case False{}:
      do IO<U32>:
        +v168 : Bool <- IO.pure(Bool, U32.is_eq(v14, {771 : U32}))
        spiral_main_k44_k61_k78_k81_if82_if83(v168)

@unsafe
def spiral_main_k44_k61_k78_k81_if84(+c: Bool, +v14: U32, +v170: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({111 : U32}, v14)
    case False{}:
      do IO<U32 & U32>:
        return (v170, {4294967295 : U32})

@unsafe
def spiral_main_k44_k61_k78_k81_k85_if86(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {231 : U32}
    case False{}:
      do IO<U32>:
        return {4294967295 : U32}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_if87(+c: Bool, +v17: U32, +v175: U32) -> IO(U32 & U32):
  match c:
    case True{}:
      do IO<U32 & U32>:
        return ({99 : U32}, v17)
    case False{}:
      do IO<U32 & U32>:
        return (v175, {4294967295 : U32})

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88_if89(+c: Bool, +v11: U32, +v65: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v180 : Bool <- IO.pure(Bool, U32.is_eq(v65, v11))
        return v180
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88_if90_if91(+c: Bool, +v14: U32, +v113: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v183 : Bool <- IO.pure(Bool, U32.is_eq(v113, v14))
        return v183
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if93(+c: Bool, +v17: U32, +v161: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v186 : Bool <- IO.pure(Bool, U32.is_eq(v161, v17))
        return v186
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94_if95(+c: Bool, +v166: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v189 : Bool <- IO.pure(Bool, U32.is_eq(v166, {4294967295 : U32}))
        return v189
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94_if96_if97(+c: Bool, +v173: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v192 : Bool <- IO.pure(Bool, U32.is_eq(v173, {4294967295 : U32}))
        return v192
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94_if96_if98_if99(+c: Bool, +v178: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v195 : Bool <- IO.pure(Bool, U32.is_eq(v178, {4294967295 : U32}))
        return v195
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94_if96_if98_if100(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {6 : U32}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94_if96_if98(+c: Bool, +v8: U32, +v177: U32, +v178: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v194 : Bool <- IO.pure(Bool, U32.is_eq(v177, v8))
        +v196 : Bool <- spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94_if96_if98_if99(v194, v178)
        spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94_if96_if98_if100(v196)
    case False{}:
      do IO<U32>:
        return {5 : U32}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94_if96(+c: Bool, +v5: U32, +v8: U32, +v172: U32, +v173: U32, +v177: U32, +v178: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v191 : Bool <- IO.pure(Bool, U32.is_eq(v172, v5))
        +v193 : Bool <- spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94_if96_if97(v191, v173)
        spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94_if96_if98(v193, v8, v177, v178)
    case False{}:
      do IO<U32>:
        return {4 : U32}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94(+c: Bool, +v2: U32, +v5: U32, +v8: U32, +v165: U32, +v166: U32, +v172: U32, +v173: U32, +v177: U32, +v178: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v188 : Bool <- IO.pure(Bool, U32.is_eq(v165, v2))
        +v190 : Bool <- spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94_if95(v188, v166)
        spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94_if96(v190, v5, v8, v172, v173, v177, v178)
    case False{}:
      do IO<U32>:
        return {3 : U32}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88_if90_if92(+c: Bool, +v2: U32, +v5: U32, +v8: U32, +v17: U32, +v160: U32, +v161: U32, +v165: U32, +v166: U32, +v172: U32, +v173: U32, +v177: U32, +v178: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v185 : Bool <- IO.pure(Bool, U32.is_eq(v160, {99 : U32}))
        +v187 : Bool <- spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if93(v185, v17, v161)
        spiral_main_k44_k61_k78_k81_k85_k88_if90_if92_if94(v187, v2, v5, v8, v165, v166, v172, v173, v177, v178)
    case False{}:
      do IO<U32>:
        return {2 : U32}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88_if90(+c: Bool, +v2: U32, +v5: U32, +v8: U32, +v14: U32, +v17: U32, +v112: U32, +v113: U32, +v160: U32, +v161: U32, +v165: U32, +v166: U32, +v172: U32, +v173: U32, +v177: U32, +v178: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v182 : Bool <- IO.pure(Bool, U32.is_eq(v112, {111 : U32}))
        +v184 : Bool <- spiral_main_k44_k61_k78_k81_k85_k88_if90_if91(v182, v14, v113)
        spiral_main_k44_k61_k78_k81_k85_k88_if90_if92(v184, v2, v5, v8, v17, v160, v161, v165, v166, v172, v173, v177, v178)
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main_k44_k61_k78_k81_k85_k88(+p: U32 & U32, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: String, +v10: U32, +v11: U32, +v12: String, +v13: U32, +v14: U32, +v15: String, +v16: U32, +v17: U32, +v18: Bool, +v64: U32, +v65: U32, +v66: Bool, +v112: U32, +v113: U32, +v114: Bool, +v160: U32, +v161: U32, +v162: Bool, +v163: U32, +v164: Bool, +v165: U32, +v166: U32, +v167: Bool, +v170: U32, +v171: Bool, +v172: U32, +v173: U32, +v174: Bool, +v175: U32, +v176: Bool) -> IO(U32):
  (+v177, +v178) = p
  do IO<U32>:
    +v179 : Bool <- IO.pure(Bool, U32.is_eq(v64, {101 : U32}))
    +v181 : Bool <- spiral_main_k44_k61_k78_k81_k85_k88_if89(v179, v11, v65)
    spiral_main_k44_k61_k78_k81_k85_k88_if90(v181, v2, v5, v8, v14, v17, v112, v113, v160, v161, v165, v166, v172, v173, v177, v178)

@unsafe
def spiral_main_k44_k61_k78_k81_k85(+p: U32 & U32, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: String, +v10: U32, +v11: U32, +v12: String, +v13: U32, +v14: U32, +v15: String, +v16: U32, +v17: U32, +v18: Bool, +v64: U32, +v65: U32, +v66: Bool, +v112: U32, +v113: U32, +v114: Bool, +v160: U32, +v161: U32, +v162: Bool, +v163: U32, +v164: Bool, +v165: U32, +v166: U32, +v167: Bool, +v170: U32, +v171: Bool) -> IO(U32):
  (+v172, +v173) = p
  do IO<U32>:
    +v174 : Bool <- IO.pure(Bool, U32.is_eq(v17, {807 : U32}))
    +v175 : U32 <- spiral_main_k44_k61_k78_k81_k85_if86(v174)
    +v176 : Bool <- IO.pure(Bool, spiral_i32_lt(v175, {0 : U32}))
    +p : U32 & U32 <- spiral_main_k44_k61_k78_k81_k85_if87(v176, v17, v175)
    spiral_main_k44_k61_k78_k81_k85_k88(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v64, v65, v66, v112, v113, v114, v160, v161, v162, v163, v164, v165, v166, v167, v170, v171, v172, v173, v174, v175, v176)

@unsafe
def spiral_main_k44_k61_k78_k81(+p: U32 & U32, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: String, +v10: U32, +v11: U32, +v12: String, +v13: U32, +v14: U32, +v15: String, +v16: U32, +v17: U32, +v18: Bool, +v64: U32, +v65: U32, +v66: Bool, +v112: U32, +v113: U32, +v114: Bool, +v160: U32, +v161: U32, +v162: Bool, +v163: U32, +v164: Bool) -> IO(U32):
  (+v165, +v166) = p
  do IO<U32>:
    +v167 : Bool <- IO.pure(Bool, U32.is_eq(v14, {769 : U32}))
    +v170 : U32 <- spiral_main_k44_k61_k78_k81_if82(v167, v14)
    +v171 : Bool <- IO.pure(Bool, spiral_i32_lt(v170, {0 : U32}))
    +p : U32 & U32 <- spiral_main_k44_k61_k78_k81_if84(v171, v14, v170)
    spiral_main_k44_k61_k78_k81_k85(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v64, v65, v66, v112, v113, v114, v160, v161, v162, v163, v164, v165, v166, v167, v170, v171)

@unsafe
def spiral_main_k44_k61_k78(+p: U32 & U32, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: String, +v10: U32, +v11: U32, +v12: String, +v13: U32, +v14: U32, +v15: String, +v16: U32, +v17: U32, +v18: Bool, +v64: U32, +v65: U32, +v66: Bool, +v112: U32, +v113: U32, +v114: Bool) -> IO(U32):
  (+v160, +v161) = p
  do IO<U32>:
    +v162 : Bool <- IO.pure(Bool, U32.is_eq(v11, {769 : U32}))
    +v163 : U32 <- spiral_main_k44_k61_k78_if79(v162)
    +v164 : Bool <- IO.pure(Bool, spiral_i32_lt(v163, {0 : U32}))
    +p : U32 & U32 <- spiral_main_k44_k61_k78_if80(v164, v11, v163)
    spiral_main_k44_k61_k78_k81(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v64, v65, v66, v112, v113, v114, v160, v161, v162, v163, v164)

@unsafe
def spiral_main_k44_k61(+p: U32 & U32, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: String, +v10: U32, +v11: U32, +v12: String, +v13: U32, +v14: U32, +v15: String, +v16: U32, +v17: U32, +v18: Bool, +v64: U32, +v65: U32, +v66: Bool) -> IO(U32):
  (+v112, +v113) = p
  do IO<U32>:
    +v114 : Bool <- IO.pure(Bool, U32.is_eq(v8, {192 : U32}))
    +p : U32 & U32 <- spiral_main_k44_k61_if62(v114, v8)
    spiral_main_k44_k61_k78(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v64, v65, v66, v112, v113, v114)

@unsafe
def spiral_main_k44(+p: U32 & U32, +v0: String, +v1: U32, +v2: U32, +v3: String, +v4: U32, +v5: U32, +v6: String, +v7: U32, +v8: U32, +v9: String, +v10: U32, +v11: U32, +v12: String, +v13: U32, +v14: U32, +v15: String, +v16: U32, +v17: U32, +v18: Bool) -> IO(U32):
  (+v64, +v65) = p
  do IO<U32>:
    +v66 : Bool <- IO.pure(Bool, U32.is_eq(v5, {192 : U32}))
    +p : U32 & U32 <- spiral_main_k44_if45(v66, v5)
    spiral_main_k44_k61(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v64, v65, v66)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : String <- IO.pure(String, "é")
    +v1 : U32 <- IO.pure(U32, {0 : U32})
    +v2 : U32 <- utf8_scalar_at_byte_offset_0(v0, v1)
    +v3 : String <- IO.pure(String, "õ")
    +v4 : U32 <- IO.pure(U32, {0 : U32})
    +v5 : U32 <- utf8_scalar_at_byte_offset_0(v3, v4)
    +v6 : String <- IO.pure(String, "ç")
    +v7 : U32 <- IO.pure(U32, {0 : U32})
    +v8 : U32 <- utf8_scalar_at_byte_offset_0(v6, v7)
    +v9 : String <- IO.pure(String, "́")
    +v10 : U32 <- IO.pure(U32, {0 : U32})
    +v11 : U32 <- utf8_scalar_at_byte_offset_0(v9, v10)
    +v12 : String <- IO.pure(String, "̃")
    +v13 : U32 <- IO.pure(U32, {0 : U32})
    +v14 : U32 <- utf8_scalar_at_byte_offset_0(v12, v13)
    +v15 : String <- IO.pure(String, "̧")
    +v16 : U32 <- IO.pure(U32, {0 : U32})
    +v17 : U32 <- utf8_scalar_at_byte_offset_0(v15, v16)
    +v18 : Bool <- IO.pure(Bool, U32.is_eq(v2, {192 : U32}))
    +p : U32 & U32 <- spiral_main_if28(v18, v2)
    spiral_main_k44(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
