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
def f_c0(+v0: (F32 & String), +v1: U32) -> IO((F32 & String)):
  do IO<(F32 & String)>:
    return v0

@unsafe
def spiral_main_field1(+p: F32 & String) -> IO(F32 & String):
  (+w0, +w1) = p
  IO.pure(F32 & String, (w0, w1))

@unsafe
def spiral_main_k2_if3(+c: Bool, +v6: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v8 : Bool <- IO.pure(Bool, String.eq(v6, "hi"))
        return v8
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k2_if4(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main_k2(+p: F32 & String, +v0: F32, +v1: String, +v2: (F32 & String), +v3: ((U32) -> IO((F32 & String))), +v4: (F32 & String)) -> IO(U32):
  (+v5, +v6) = p
  do IO<U32>:
    +v7 : Bool <- IO.pure(Bool, F32.is_eq(v5, 1.5))
    +v9 : Bool <- spiral_main_k2_if3(v7, v6)
    spiral_main_k2_if4(v9)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : F32 <- IO.pure(F32, 1.5)
    +v1 : String <- IO.pure(String, "hi")
    +v2 : (F32 & String) <- IO.pure((F32 & String), (v0, v1))
    +v3 : ((U32) -> IO((F32 & String))) <- IO.pure(((U32) -> IO((F32 & String))), d => f_c0(v2, d))
    +v4 : (F32 & String) <- v3({1 : U32})
    +p : F32 & String <- spiral_main_field1(v4)
    spiral_main_k2(p, v0, v1, v2, v3, v4)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
