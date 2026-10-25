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

type U0 is Type:
  U0_None{}
  U0_Held{f0: (((U32 & String) & (U32 & String)) & U32)}

@unsafe
def spiral_main_if1(+c: Bool, +v8: (((U32 & String) & (U32 & String)) & U32)) -> IO(U0):
  match c:
    case True{}:
      do IO<U0>:
        IO.pure(U0, U0_Held{v8})
    case False{}:
      do IO<U0>:
        IO.pure(U0, U0_None{})

@unsafe
def spiral_main_field2(+p: U0) -> IO(U0):
  IO.pure(U0, p)

@unsafe
def score_0_unbox3_field4(+p: ((U32 & String) & (U32 & String)) & U32) -> IO(((U32 & String) & (U32 & String)) & U32):
  (+w0, +w1) = p
  IO.pure(((U32 & String) & (U32 & String)) & U32, (w0, w1))

@unsafe
def score_0_unbox3_k5_field6(+p: (U32 & String) & (U32 & String)) -> IO((U32 & String) & (U32 & String)):
  (+w0, +w1) = p
  IO.pure((U32 & String) & (U32 & String), (w0, w1))

@unsafe
def score_0_unbox3_k5_k7_field8(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def score_0_unbox3_k5_k7_k9_field10(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def score_0_unbox3_k5_k7_k9_k11_if12(+c: Bool, +v7: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v11 : Bool <- IO.pure(Bool, String.eq(v7, "hi"))
        return v11
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox3_k5_k7_k9_k11_if13(+c: Bool, +v8: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v13 : Bool <- IO.pure(Bool, U32.is_eq(v8, {4 : U32}))
        return v13
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox3_k5_k7_k9_k11_if14(+c: Bool, +v9: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v15 : Bool <- IO.pure(Bool, String.eq(v9, "yo"))
        return v15
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox3_k5_k7_k9_k11_if15(+c: Bool, +v3: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v17 : Bool <- IO.pure(Bool, U32.is_eq(v3, {2 : U32}))
        return v17
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox3_k5_k7_k9_k11_if16(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def score_0_unbox3_k5_k7_k9_k11(+p: U32 & String, +v0: U0, +v1: (((U32 & String) & (U32 & String)) & U32), +v2: ((U32 & String) & (U32 & String)), +v3: U32, +v4: (U32 & String), +v5: (U32 & String), +v6: U32, +v7: String) -> IO(U32):
  (+v8, +v9) = p
  do IO<U32>:
    +v10 : Bool <- IO.pure(Bool, U32.is_eq(v6, {7 : U32}))
    +v12 : Bool <- score_0_unbox3_k5_k7_k9_k11_if12(v10, v7)
    +v14 : Bool <- score_0_unbox3_k5_k7_k9_k11_if13(v12, v8)
    +v16 : Bool <- score_0_unbox3_k5_k7_k9_k11_if14(v14, v9)
    +v18 : Bool <- score_0_unbox3_k5_k7_k9_k11_if15(v16, v3)
    score_0_unbox3_k5_k7_k9_k11_if16(v18)

@unsafe
def score_0_unbox3_k5_k7_k9(+p: U32 & String, +v0: U0, +v1: (((U32 & String) & (U32 & String)) & U32), +v2: ((U32 & String) & (U32 & String)), +v3: U32, +v4: (U32 & String), +v5: (U32 & String)) -> IO(U32):
  (+v6, +v7) = p
  do IO<U32>:
    +p : U32 & String <- score_0_unbox3_k5_k7_k9_field10(v5)
    score_0_unbox3_k5_k7_k9_k11(p, v0, v1, v2, v3, v4, v5, v6, v7)

@unsafe
def score_0_unbox3_k5_k7(+p: (U32 & String) & (U32 & String), +v0: U0, +v1: (((U32 & String) & (U32 & String)) & U32), +v2: ((U32 & String) & (U32 & String)), +v3: U32) -> IO(U32):
  (+v4, +v5) = p
  do IO<U32>:
    +p : U32 & String <- score_0_unbox3_k5_k7_field8(v4)
    score_0_unbox3_k5_k7_k9(p, v0, v1, v2, v3, v4, v5)

@unsafe
def score_0_unbox3_k5(+p: ((U32 & String) & (U32 & String)) & U32, +v0: U0, +v1: (((U32 & String) & (U32 & String)) & U32)) -> IO(U32):
  (+v2, +v3) = p
  do IO<U32>:
    +p : (U32 & String) & (U32 & String) <- score_0_unbox3_k5_field6(v2)
    score_0_unbox3_k5_k7(p, v0, v1, v2, v3)

@unsafe
def score_0_unbox3(+u: U0, +v0: U0) -> IO(U32):
  match u:
    case U0_None{}:
      do IO<U32>:
        return {1 : U32}
    case U0_Held{+v1}:
      do IO<U32>:
        +p : ((U32 & String) & (U32 & String)) & U32 <- score_0_unbox3_field4(v1)
        score_0_unbox3_k5(p, v0, v1)

@unsafe
def score_0(+v0: U0) -> IO(U32):
  do IO<U32>:
    score_0_unbox3(v0, v0)

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
    +v9 : Bool <- IO.pure(Bool, True{})
    +v12 : U0 <- spiral_main_if1(v9, v8)
    +v13 : (U0) <- IO.pure((U0), v12)
    +v14 : U0 <- spiral_main_field2(v13)
    score_0(v14)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
