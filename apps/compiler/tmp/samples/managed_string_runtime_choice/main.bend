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
def choose_0_if1(+c: Bool) -> IO(String):
  match c:
    case True{}:
      do IO<String>:
        +v1 : String <- IO.pure(String, "alpha")
        return v1
    case False{}:
      do IO<String>:
        +v2 : String <- IO.pure(String, "beta")
        return v2

@unsafe
def choose_0(+v0: Bool) -> IO(String):
  do IO<String>:
    choose_0_if1(v0)

@unsafe
def measure_1(+v0: String) -> IO(U32):
  do IO<U32>:
    +v1 : U32 <- IO.pure(U32, spiral_string_bytes(v0))
    return v1

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : Bool <- IO.pure(Bool, True{})
    +v1 : String <- choose_0(v0)
    +v2 : Bool <- IO.pure(Bool, False{})
    +v3 : String <- choose_0(v2)
    +v4 : U32 <- measure_1(v1)
    +v5 : U32 <- measure_1(v1)
    +v6 : U32 <- IO.pure(U32, U32.add(v4, v5))
    +v7 : U32 <- measure_1(v3)
    +v8 : U32 <- IO.pure(U32, U32.add(v6, v7))
    +v9 : U32 <- IO.pure(U32, U32.sub(v8, {14 : U32}))
    return v9

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
