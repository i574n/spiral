import Base

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
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25_if26_if27_if28(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {28 : U32}
    case False{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25_if26_if27(+c: Bool, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {27 : U32}
    case False{}:
      do IO<U32>:
        +v64 : U32 <- IO.pure(U32, spiral_string_byte_at(v5, {3 : U32}))
        +v65 : Bool <- IO.pure(Bool, U32.is_ne(v64, {99 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25_if26_if27_if28(v65)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25_if26(+c: Bool, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {26 : U32}
    case False{}:
      do IO<U32>:
        +v62 : U32 <- IO.pure(U32, spiral_string_bytes(v5))
        +v63 : Bool <- IO.pure(Bool, U32.is_ne(v62, {5 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25_if26_if27(v63, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25(+c: Bool, +v4: String, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {25 : U32}
    case False{}:
      do IO<U32>:
        +v60 : U32 <- IO.pure(U32, spiral_string_byte_at(v4, {22 : U32}))
        +v61 : Bool <- IO.pure(Bool, U32.is_ne(v60, {100 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25_if26(v61, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24(+c: Bool, +v4: String, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {24 : U32}
    case False{}:
      do IO<U32>:
        +v58 : U32 <- IO.pure(U32, spiral_string_byte_at(v4, {17 : U32}))
        +v59 : Bool <- IO.pure(Bool, U32.is_ne(v58, {10 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24_if25(v59, v4, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23(+c: Bool, +v4: String, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {23 : U32}
    case False{}:
      do IO<U32>:
        +v56 : U32 <- IO.pure(U32, spiral_string_byte_at(v4, {10 : U32}))
        +v57 : Bool <- IO.pure(Bool, U32.is_ne(v56, {115 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23_if24(v57, v4, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22(+c: Bool, +v4: String, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {22 : U32}
    case False{}:
      do IO<U32>:
        +v54 : U32 <- IO.pure(U32, spiral_string_byte_at(v4, {6 : U32}))
        +v55 : Bool <- IO.pure(Bool, U32.is_ne(v54, {32 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22_if23(v55, v4, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21(+c: Bool, +v4: String, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {21 : U32}
    case False{}:
      do IO<U32>:
        +v52 : U32 <- IO.pure(U32, spiral_string_bytes(v4))
        +v53 : Bool <- IO.pure(Bool, U32.is_ne(v52, {23 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21_if22(v53, v4, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20(+c: Bool, +v3: String, +v4: String, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {20 : U32}
    case False{}:
      do IO<U32>:
        +v50 : U32 <- IO.pure(U32, spiral_string_byte_at(v3, {4 : U32}))
        +v51 : Bool <- IO.pure(Bool, U32.is_ne(v50, {34 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20_if21(v51, v4, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19(+c: Bool, +v3: String, +v4: String, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {19 : U32}
    case False{}:
      do IO<U32>:
        +v48 : U32 <- IO.pure(U32, spiral_string_bytes(v3))
        +v49 : Bool <- IO.pure(Bool, U32.is_ne(v48, {7 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19_if20(v49, v3, v4, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18(+c: Bool, +v2: String, +v3: String, +v4: String, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {18 : U32}
    case False{}:
      do IO<U32>:
        +v46 : U32 <- IO.pure(U32, spiral_string_byte_at(v2, {7 : U32}))
        +v47 : Bool <- IO.pure(Bool, U32.is_ne(v46, {34 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18_if19(v47, v3, v4, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17(+c: Bool, +v2: String, +v3: String, +v4: String, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {17 : U32}
    case False{}:
      do IO<U32>:
        +v44 : U32 <- IO.pure(U32, spiral_string_bytes(v2))
        +v45 : Bool <- IO.pure(Bool, U32.is_ne(v44, {8 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17_if18(v45, v2, v3, v4, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16(+c: Bool, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {16 : U32}
    case False{}:
      do IO<U32>:
        +v42 : U32 <- IO.pure(U32, spiral_string_bytes(v1))
        +v43 : Bool <- IO.pure(Bool, U32.is_ne(v42, {3 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16_if17(v43, v2, v3, v4, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {15 : U32}
    case False{}:
      do IO<U32>:
        +v41 : Bool <- IO.pure(Bool, U32.is_ne(v0, {16 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15_if16(v41, v1, v2, v3, v4, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v10: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {14 : U32}
    case False{}:
      do IO<U32>:
        +v39 : U32 <- IO.pure(U32, spiral_string_byte_at(v10, {5 : U32}))
        +v40 : Bool <- IO.pure(Bool, U32.is_ne(v39, {10 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14_if15(v40, v0, v1, v2, v3, v4, v5)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v10: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {13 : U32}
    case False{}:
      do IO<U32>:
        +v37 : U32 <- IO.pure(U32, spiral_string_byte_at(v10, {0 : U32}))
        +v38 : Bool <- IO.pure(Bool, U32.is_ne(v37, {10 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13_if14(v38, v0, v1, v2, v3, v4, v5, v10)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v10: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {12 : U32}
    case False{}:
      do IO<U32>:
        +v35 : U32 <- IO.pure(U32, spiral_string_bytes(v10))
        +v36 : Bool <- IO.pure(Bool, U32.is_ne(v35, {11 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12_if13(v36, v0, v1, v2, v3, v4, v5, v10)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v9: String, +v10: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {11 : U32}
    case False{}:
      do IO<U32>:
        +v33 : U32 <- IO.pure(U32, spiral_string_byte_at(v9, {82 : U32}))
        +v34 : Bool <- IO.pure(Bool, U32.is_ne(v33, {100 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11_if12(v34, v0, v1, v2, v3, v4, v5, v10)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v9: String, +v10: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {10 : U32}
    case False{}:
      do IO<U32>:
        +v31 : U32 <- IO.pure(U32, spiral_string_byte_at(v9, {57 : U32}))
        +v32 : Bool <- IO.pure(Bool, U32.is_ne(v31, {105 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10_if11(v32, v0, v1, v2, v3, v4, v5, v9, v10)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v9: String, +v10: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {9 : U32}
    case False{}:
      do IO<U32>:
        +v29 : U32 <- IO.pure(U32, spiral_string_byte_at(v9, {39 : U32}))
        +v30 : Bool <- IO.pure(Bool, U32.is_ne(v29, {36 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9_if10(v30, v0, v1, v2, v3, v4, v5, v9, v10)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7_if8(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: U32, +v14: Bool, +v15: U32, +v16: Bool, +v17: U32, +v18: Bool, +v19: U32, +v20: Bool, +v21: U32, +v22: Bool, +v23: U32, +v24: Bool, +v25: U32, +v26: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {8 : U32}
    case False{}:
      do IO<U32>:
        +v27 : U32 <- IO.pure(U32, spiral_string_byte_at(v9, {38 : U32}))
        +v28 : Bool <- IO.pure(Bool, U32.is_ne(v27, {10 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8_if9(v28, v0, v1, v2, v3, v4, v5, v9, v10)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6_if7(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: U32, +v14: Bool, +v15: U32, +v16: Bool, +v17: U32, +v18: Bool, +v19: U32, +v20: Bool, +v21: U32, +v22: Bool, +v23: U32, +v24: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {7 : U32}
    case False{}:
      do IO<U32>:
        +v25 : U32 <- IO.pure(U32, spiral_string_byte_at(v9, {37 : U32}))
        +v26 : Bool <- IO.pure(Bool, U32.is_ne(v25, {10 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7_if8(v26, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26)

@unsafe
def spiral_main_if1_if2_if3_if4_if5_if6(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: U32, +v14: Bool, +v15: U32, +v16: Bool, +v17: U32, +v18: Bool, +v19: U32, +v20: Bool, +v21: U32, +v22: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {6 : U32}
    case False{}:
      do IO<U32>:
        +v23 : U32 <- IO.pure(U32, spiral_string_byte_at(v9, {5 : U32}))
        +v24 : Bool <- IO.pure(Bool, U32.is_ne(v23, {10 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6_if7(v24, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24)

@unsafe
def spiral_main_if1_if2_if3_if4_if5(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: U32, +v14: Bool, +v15: U32, +v16: Bool, +v17: U32, +v18: Bool, +v19: U32, +v20: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {5 : U32}
    case False{}:
      do IO<U32>:
        +v21 : U32 <- IO.pure(U32, spiral_string_bytes(v9))
        +v22 : Bool <- IO.pure(Bool, U32.is_ne(v21, {83 : U32}))
        spiral_main_if1_if2_if3_if4_if5_if6(v22, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22)

@unsafe
def spiral_main_if1_if2_if3_if4(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: U32, +v14: Bool, +v15: U32, +v16: Bool, +v17: U32, +v18: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {4 : U32}
    case False{}:
      do IO<U32>:
        +v19 : U32 <- IO.pure(U32, spiral_string_byte_at(v8, {1 : U32}))
        +v20 : Bool <- IO.pure(Bool, U32.is_ne(v19, {92 : U32}))
        spiral_main_if1_if2_if3_if4_if5(v20, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20)

@unsafe
def spiral_main_if1_if2_if3(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: U32, +v14: Bool, +v15: U32, +v16: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {3 : U32}
    case False{}:
      do IO<U32>:
        +v17 : U32 <- IO.pure(U32, spiral_string_bytes(v8))
        +v18 : Bool <- IO.pure(Bool, U32.is_ne(v17, {4 : U32}))
        spiral_main_if1_if2_if3_if4(v18, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18)

@unsafe
def spiral_main_if1_if2(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool, +v13: U32, +v14: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {2 : U32}
    case False{}:
      do IO<U32>:
        +v15 : U32 <- IO.pure(U32, spiral_string_bytes(v7))
        +v16 : Bool <- IO.pure(Bool, U32.is_ne(v15, {0 : U32}))
        spiral_main_if1_if2_if3(v16, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16)

@unsafe
def spiral_main_if1(+c: Bool, +v0: U32, +v1: String, +v2: String, +v3: String, +v4: String, +v5: String, +v6: String, +v7: String, +v8: String, +v9: String, +v10: String, +v11: U32, +v12: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {1 : U32}
    case False{}:
      do IO<U32>:
        +v13 : U32 <- IO.pure(U32, spiral_string_byte_at(v6, {2 : U32}))
        +v14 : Bool <- IO.pure(Bool, U32.is_ne(v13, {34 : U32}))
        spiral_main_if1_if2(v14, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14)

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
    +v12 : Bool <- IO.pure(Bool, U32.is_ne(v11, {7 : U32}))
    spiral_main_if1(v12, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
