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
def f_c0(+v0: (((U32 & String) & (U32 & String)) & U32), +v1: U32) -> IO((((U32 & String) & (U32 & String)) & U32)):
  do IO<(((U32 & String) & (U32 & String)) & U32)>:
    return v0

@unsafe
def spiral_main_field1(+p: ((U32 & String) & (U32 & String)) & U32) -> IO(((U32 & String) & (U32 & String)) & U32):
  (+w0, +w1) = p
  IO.pure(((U32 & String) & (U32 & String)) & U32, (w0, w1))

@unsafe
def spiral_main_k2_field3(+p: (U32 & String) & (U32 & String)) -> IO((U32 & String) & (U32 & String)):
  (+w0, +w1) = p
  IO.pure((U32 & String) & (U32 & String), (w0, w1))

@unsafe
def spiral_main_k2_k4_field5(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def spiral_main_k2_k4_k6_field7(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def spiral_main_k2_k4_k6_k8_if9(+c: Bool, +v16: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v20 : Bool <- IO.pure(Bool, String.eq(v16, "hi"))
        return v20
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k2_k4_k6_k8_if10(+c: Bool, +v17: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v22 : Bool <- IO.pure(Bool, U32.is_eq(v17, {4 : U32}))
        return v22
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k2_k4_k6_k8_if11(+c: Bool, +v18: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v24 : Bool <- IO.pure(Bool, String.eq(v18, "yo"))
        return v24
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k2_k4_k6_k8_if12(+c: Bool, +v12: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v26 : Bool <- IO.pure(Bool, U32.is_eq(v12, {2 : U32}))
        return v26
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k2_k4_k6_k8_if13(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main_k2_k4_k6_k8(+p: U32 & String, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: ((U32 & String) & (U32 & String)), +v7: U32, +v8: (((U32 & String) & (U32 & String)) & U32), +v9: ((U32) -> IO((((U32 & String) & (U32 & String)) & U32))), +v10: (((U32 & String) & (U32 & String)) & U32), +v11: ((U32 & String) & (U32 & String)), +v12: U32, +v13: (U32 & String), +v14: (U32 & String), +v15: U32, +v16: String) -> IO(U32):
  (+v17, +v18) = p
  do IO<U32>:
    +v19 : Bool <- IO.pure(Bool, U32.is_eq(v15, {7 : U32}))
    +v21 : Bool <- spiral_main_k2_k4_k6_k8_if9(v19, v16)
    +v23 : Bool <- spiral_main_k2_k4_k6_k8_if10(v21, v17)
    +v25 : Bool <- spiral_main_k2_k4_k6_k8_if11(v23, v18)
    +v27 : Bool <- spiral_main_k2_k4_k6_k8_if12(v25, v12)
    spiral_main_k2_k4_k6_k8_if13(v27)

@unsafe
def spiral_main_k2_k4_k6(+p: U32 & String, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: ((U32 & String) & (U32 & String)), +v7: U32, +v8: (((U32 & String) & (U32 & String)) & U32), +v9: ((U32) -> IO((((U32 & String) & (U32 & String)) & U32))), +v10: (((U32 & String) & (U32 & String)) & U32), +v11: ((U32 & String) & (U32 & String)), +v12: U32, +v13: (U32 & String), +v14: (U32 & String)) -> IO(U32):
  (+v15, +v16) = p
  do IO<U32>:
    +p : U32 & String <- spiral_main_k2_k4_k6_field7(v14)
    spiral_main_k2_k4_k6_k8(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16)

@unsafe
def spiral_main_k2_k4(+p: (U32 & String) & (U32 & String), +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: ((U32 & String) & (U32 & String)), +v7: U32, +v8: (((U32 & String) & (U32 & String)) & U32), +v9: ((U32) -> IO((((U32 & String) & (U32 & String)) & U32))), +v10: (((U32 & String) & (U32 & String)) & U32), +v11: ((U32 & String) & (U32 & String)), +v12: U32) -> IO(U32):
  (+v13, +v14) = p
  do IO<U32>:
    +p : U32 & String <- spiral_main_k2_k4_field5(v13)
    spiral_main_k2_k4_k6(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14)

@unsafe
def spiral_main_k2(+p: ((U32 & String) & (U32 & String)) & U32, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: ((U32 & String) & (U32 & String)), +v7: U32, +v8: (((U32 & String) & (U32 & String)) & U32), +v9: ((U32) -> IO((((U32 & String) & (U32 & String)) & U32))), +v10: (((U32 & String) & (U32 & String)) & U32)) -> IO(U32):
  (+v11, +v12) = p
  do IO<U32>:
    +p : (U32 & String) & (U32 & String) <- spiral_main_k2_field3(v11)
    spiral_main_k2_k4(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {7 : U32})
    +v1 : String <- IO.pure(String, "hi")
    +v2 : (U32 & String) <- IO.pure((U32 & String), (v0, v1))
    +v3 : U32 <- IO.pure(U32, {4 : U32})
    +v4 : String <- IO.pure(String, "yo")
    +v5 : (U32 & String) <- IO.pure((U32 & String), (v3, v4))
    +v6 : ((U32 & String) & (U32 & String)) <- IO.pure(((U32 & String) & (U32 & String)), (v2, v5))
    +v7 : U32 <- IO.pure(U32, {2 : U32})
    +v8 : (((U32 & String) & (U32 & String)) & U32) <- IO.pure((((U32 & String) & (U32 & String)) & U32), (v6, v7))
    +v9 : ((U32) -> IO((((U32 & String) & (U32 & String)) & U32))) <- IO.pure(((U32) -> IO((((U32 & String) & (U32 & String)) & U32))), d => f_c0(v8, d))
    +v10 : (((U32 & String) & (U32 & String)) & U32) <- v9({1 : U32})
    +p : ((U32 & String) & (U32 & String)) & U32 <- spiral_main_field1(v10)
    spiral_main_k2(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
