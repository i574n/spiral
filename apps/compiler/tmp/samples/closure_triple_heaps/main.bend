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
def f_c0(+v0: (U32 & String), +v1: (U32 & String), +v2: (U32 & String), +v3: U32) -> IO((U32 & String) & (U32 & String) & (U32 & String)):
  do IO<(U32 & String) & (U32 & String) & (U32 & String)>:
    return (v0, v1, v2)

@unsafe
def spiral_main_k1_field2(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def spiral_main_k1_k3_field4(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def spiral_main_k1_k3_k5_field6(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def spiral_main_k1_k3_k5_k7_if8(+c: Bool, +v14: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v20 : Bool <- IO.pure(Bool, String.eq(v14, "hi"))
        return v20
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k1_k3_k5_k7_if9(+c: Bool, +v15: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v22 : Bool <- IO.pure(Bool, U32.is_eq(v15, {4 : U32}))
        return v22
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k1_k3_k5_k7_if10(+c: Bool, +v16: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v24 : Bool <- IO.pure(Bool, String.eq(v16, "yo"))
        return v24
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k1_k3_k5_k7_if11(+c: Bool, +v17: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v26 : Bool <- IO.pure(Bool, U32.is_eq(v17, {9 : U32}))
        return v26
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k1_k3_k5_k7_if12(+c: Bool, +v18: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v28 : Bool <- IO.pure(Bool, String.eq(v18, "ok"))
        return v28
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k1_k3_k5_k7_if13(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main_k1_k3_k5_k7(+p: U32 & String, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: ((U32) -> IO((U32 & String) & (U32 & String) & (U32 & String))), +v10: (U32 & String), +v11: (U32 & String), +v12: (U32 & String), +v13: U32, +v14: String, +v15: U32, +v16: String) -> IO(U32):
  (+v17, +v18) = p
  do IO<U32>:
    +v19 : Bool <- IO.pure(Bool, U32.is_eq(v13, {7 : U32}))
    +v21 : Bool <- spiral_main_k1_k3_k5_k7_if8(v19, v14)
    +v23 : Bool <- spiral_main_k1_k3_k5_k7_if9(v21, v15)
    +v25 : Bool <- spiral_main_k1_k3_k5_k7_if10(v23, v16)
    +v27 : Bool <- spiral_main_k1_k3_k5_k7_if11(v25, v17)
    +v29 : Bool <- spiral_main_k1_k3_k5_k7_if12(v27, v18)
    spiral_main_k1_k3_k5_k7_if13(v29)

@unsafe
def spiral_main_k1_k3_k5(+p: U32 & String, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: ((U32) -> IO((U32 & String) & (U32 & String) & (U32 & String))), +v10: (U32 & String), +v11: (U32 & String), +v12: (U32 & String), +v13: U32, +v14: String) -> IO(U32):
  (+v15, +v16) = p
  do IO<U32>:
    +p : U32 & String <- spiral_main_k1_k3_k5_field6(v12)
    spiral_main_k1_k3_k5_k7(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16)

@unsafe
def spiral_main_k1_k3(+p: U32 & String, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: ((U32) -> IO((U32 & String) & (U32 & String) & (U32 & String))), +v10: (U32 & String), +v11: (U32 & String), +v12: (U32 & String)) -> IO(U32):
  (+v13, +v14) = p
  do IO<U32>:
    +p : U32 & String <- spiral_main_k1_k3_field4(v11)
    spiral_main_k1_k3_k5(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14)

@unsafe
def spiral_main_k1(+p: (U32 & String) & (U32 & String) & (U32 & String), +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: ((U32) -> IO((U32 & String) & (U32 & String) & (U32 & String)))) -> IO(U32):
  (+v10, +v11, +v12) = p
  do IO<U32>:
    +p : U32 & String <- spiral_main_k1_field2(v10)
    spiral_main_k1_k3(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {7 : U32})
    +v1 : String <- IO.pure(String, "hi")
    +v2 : (U32 & String) <- IO.pure((U32 & String), (v0, v1))
    +v3 : U32 <- IO.pure(U32, {4 : U32})
    +v4 : String <- IO.pure(String, "yo")
    +v5 : (U32 & String) <- IO.pure((U32 & String), (v3, v4))
    +v6 : U32 <- IO.pure(U32, {9 : U32})
    +v7 : String <- IO.pure(String, "ok")
    +v8 : (U32 & String) <- IO.pure((U32 & String), (v6, v7))
    +v9 : ((U32) -> IO((U32 & String) & (U32 & String) & (U32 & String))) <- IO.pure(((U32) -> IO((U32 & String) & (U32 & String) & (U32 & String))), d => f_c0(v2, v5, v8, d))
    +p : (U32 & String) & (U32 & String) & (U32 & String) <- v9({1 : U32})
    spiral_main_k1(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
