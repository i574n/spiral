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

type U0 is Data:
  U0_Idle{}
  U0_Hit{f0: U32}
  U0_Flag{f0: Bool}

@unsafe
def spiral_main_if1_if2(+c: Bool) -> IO(U0):
  match c:
    case True{}:
      do IO<U0>:
        IO.pure(U0, U0_Hit{{7 : U32}})
    case False{}:
      do IO<U0>:
        IO.pure(U0, U0_Flag{True{}})

@unsafe
def spiral_main_if1(+c: Bool, +v0: U32) -> IO(U0):
  match c:
    case True{}:
      do IO<U0>:
        IO.pure(U0, U0_Idle{})
    case False{}:
      do IO<U0>:
        +v3 : Bool <- IO.pure(Bool, U32.is_eq(v0, {1 : U32}))
        spiral_main_if1_if2(v3)

@unsafe
def closure0_unbox3_if4(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {11 : U32}
    case False{}:
      do IO<U32>:
        return {5 : U32}

@unsafe
def closure0_unbox3(+u: U0, +v0: U0, +v1: U32) -> IO(U32):
  match u:
    case U0_Idle{}:
      do IO<U32>:
        return {3 : U32}
    case U0_Hit{+v2}:
      do IO<U32>:
        return v2
    case U0_Flag{+v3}:
      do IO<U32>:
        closure0_unbox3_if4(v3)

@unsafe
def closure0(+v0: U0, +v1: U32) -> IO(U32):
  do IO<U32>:
    +v7 : U32 <- closure0_unbox3(v0, v0, v1)
    +v8 : U32 <- IO.pure(U32, U32.add(v7, v1))
    return v8

@unsafe
def method0(+v0: ((U32) -> IO(U32))) -> IO(U32):
  do IO<U32>:
    v0({31 : U32})

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {2 : U32})
    +v1 : Bool <- IO.pure(Bool, U32.is_eq(v0, {0 : U32}))
    +v7 : U0 <- spiral_main_if1(v1, v0)
    +v8 : ((U32) -> IO(U32)) <- IO.pure(((U32) -> IO(U32)), d => closure0(v7, d))
    method0(v8)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
