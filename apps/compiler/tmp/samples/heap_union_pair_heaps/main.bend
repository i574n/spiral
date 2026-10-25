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
  U0_Held{f0: (U32 & String), f1: (U32 & String)}

@unsafe
def spiral_main_if1(+c: Bool, +v2: (U32 & String), +v5: (U32 & String)) -> IO(U0):
  match c:
    case True{}:
      do IO<U0>:
        IO.pure(U0, U0_Held{v2, v5})
    case False{}:
      do IO<U0>:
        IO.pure(U0, U0_None{})

@unsafe
def spiral_main_field2(+p: U0) -> IO(U0):
  IO.pure(U0, p)

@unsafe
def score_0_unbox3_field4(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def score_0_unbox3_k5_field6(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def score_0_unbox3_k5_k7_if8(+c: Bool, +v4: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v8 : Bool <- IO.pure(Bool, String.eq(v4, "hi"))
        return v8
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox3_k5_k7_if9(+c: Bool, +v5: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v10 : Bool <- IO.pure(Bool, U32.is_eq(v5, {4 : U32}))
        return v10
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox3_k5_k7_if10(+c: Bool, +v6: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v12 : Bool <- IO.pure(Bool, String.eq(v6, "yo"))
        return v12
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox3_k5_k7_if11(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def score_0_unbox3_k5_k7(+p: U32 & String, +v0: U0, +v1: (U32 & String), +v2: (U32 & String), +v3: U32, +v4: String) -> IO(U32):
  (+v5, +v6) = p
  do IO<U32>:
    +v7 : Bool <- IO.pure(Bool, U32.is_eq(v3, {7 : U32}))
    +v9 : Bool <- score_0_unbox3_k5_k7_if8(v7, v4)
    +v11 : Bool <- score_0_unbox3_k5_k7_if9(v9, v5)
    +v13 : Bool <- score_0_unbox3_k5_k7_if10(v11, v6)
    score_0_unbox3_k5_k7_if11(v13)

@unsafe
def score_0_unbox3_k5(+p: U32 & String, +v0: U0, +v1: (U32 & String), +v2: (U32 & String)) -> IO(U32):
  (+v3, +v4) = p
  do IO<U32>:
    +p : U32 & String <- score_0_unbox3_k5_field6(v2)
    score_0_unbox3_k5_k7(p, v0, v1, v2, v3, v4)

@unsafe
def score_0_unbox3(+u: U0, +v0: U0) -> IO(U32):
  match u:
    case U0_None{}:
      do IO<U32>:
        return {1 : U32}
    case U0_Held{+v1, +v2}:
      do IO<U32>:
        +p : U32 & String <- score_0_unbox3_field4(v1)
        score_0_unbox3_k5(p, v0, v1, v2)

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
    +v6 : Bool <- IO.pure(Bool, True{})
    +v9 : U0 <- spiral_main_if1(v6, v2, v5)
    +v10 : (U0) <- IO.pure((U0), v9)
    +v11 : U0 <- spiral_main_field2(v10)
    score_0(v11)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
