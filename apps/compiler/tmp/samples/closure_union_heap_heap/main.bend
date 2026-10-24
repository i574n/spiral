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
  U0_Held{f0: ((U32 & String) & U32)}

@unsafe
def f_c0_if1(+c: Bool, +v0: ((U32 & String) & U32)) -> IO(U0):
  match c:
    case True{}:
      do IO<U0>:
        IO.pure(U0, U0_None{})
    case False{}:
      do IO<U0>:
        IO.pure(U0, U0_Held{v0})

@unsafe
def f_c0(+v0: ((U32 & String) & U32), +v1: U32) -> IO(U0):
  do IO<U0>:
    +v2 : Bool <- IO.pure(Bool, U32.is_eq(v1, {0 : U32}))
    f_c0_if1(v2, v0)

@unsafe
def score_0_unbox2_field3(+p: (U32 & String) & U32) -> IO((U32 & String) & U32):
  (+w0, +w1) = p
  IO.pure((U32 & String) & U32, (w0, w1))

@unsafe
def score_0_unbox2_k4_field5(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def score_0_unbox2_k4_k6_if7(+c: Bool, +v5: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v7 : Bool <- IO.pure(Bool, String.eq(v5, "hi"))
        return v7
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox2_k4_k6_if8(+c: Bool, +v3: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v9 : Bool <- IO.pure(Bool, U32.is_eq(v3, {1 : U32}))
        return v9
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox2_k4_k6_if9(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def score_0_unbox2_k4_k6(+p: U32 & String, +v0: U0, +v1: ((U32 & String) & U32), +v2: (U32 & String), +v3: U32) -> IO(U32):
  (+v4, +v5) = p
  do IO<U32>:
    +v6 : Bool <- IO.pure(Bool, U32.is_eq(v4, {7 : U32}))
    +v8 : Bool <- score_0_unbox2_k4_k6_if7(v6, v5)
    +v10 : Bool <- score_0_unbox2_k4_k6_if8(v8, v3)
    score_0_unbox2_k4_k6_if9(v10)

@unsafe
def score_0_unbox2_k4(+p: (U32 & String) & U32, +v0: U0, +v1: ((U32 & String) & U32)) -> IO(U32):
  (+v2, +v3) = p
  do IO<U32>:
    +p : U32 & String <- score_0_unbox2_k4_field5(v2)
    score_0_unbox2_k4_k6(p, v0, v1, v2, v3)

@unsafe
def score_0_unbox2(+u: U0, +v0: U0) -> IO(U32):
  match u:
    case U0_None{}:
      do IO<U32>:
        return {1 : U32}
    case U0_Held{+v1}:
      do IO<U32>:
        +p : (U32 & String) & U32 <- score_0_unbox2_field3(v1)
        score_0_unbox2_k4(p, v0, v1)

@unsafe
def score_0(+v0: U0) -> IO(U32):
  do IO<U32>:
    score_0_unbox2(v0, v0)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {7 : U32})
    +v1 : String <- IO.pure(String, "hi")
    +v2 : (U32 & String) <- IO.pure((U32 & String), (v0, v1))
    +v3 : U32 <- IO.pure(U32, {1 : U32})
    +v4 : ((U32 & String) & U32) <- IO.pure(((U32 & String) & U32), (v2, v3))
    +v5 : ((U32) -> IO(U0)) <- IO.pure(((U32) -> IO(U0)), d => f_c0(v4, d))
    +v6 : U0 <- v5({1 : U32})
    score_0(v6)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
