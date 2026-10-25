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
def method0_if1(+c: Bool, +v0: String, +v1: String) -> IO(String & String):
  match c:
    case True{}:
      do IO<String & String>:
        +v3 : String <- IO.pure(String, "no")
        +v4 : String <- IO.pure(String, "nay")
        return (v3, v4)
    case False{}:
      do IO<String & String>:
        return (v0, v1)

@unsafe
def method0(+v0: String, +v1: String) -> IO(String & String):
  do IO<String & String>:
    +v2 : Bool <- IO.pure(Bool, String.eq(v0, ""))
    method0_if1(v2, v0, v1)

@unsafe
def spiral_main_k2_if3(+c: Bool, +v3: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v5 : Bool <- IO.pure(Bool, String.eq(v3, "yo"))
        return v5
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
def spiral_main_k2(+p: String & String, +v0: String, +v1: String) -> IO(U32):
  (+v2, +v3) = p
  do IO<U32>:
    +v4 : Bool <- IO.pure(Bool, String.eq(v2, "hi"))
    +v6 : Bool <- spiral_main_k2_if3(v4, v3)
    spiral_main_k2_if4(v6)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : String <- IO.pure(String, "hi")
    +v1 : String <- IO.pure(String, "yo")
    +p : String & String <- method0(v0, v1)
    spiral_main_k2(p, v0, v1)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
