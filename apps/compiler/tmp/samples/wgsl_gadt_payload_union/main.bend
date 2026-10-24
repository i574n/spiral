import Base

def spiral_i32_bias(+x: U32) -> U32:
  U32.xor(x, 2147483648)

def spiral_i32_gt(+a: U32, +b: U32) -> Bool:
  U32.is_gt(spiral_i32_bias(a), spiral_i32_bias(b))

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

type U1 is Data:
  U1_Living{f0: U32, f1: U32}

type U2 is Data:
  U2_Fallen{f0: U32}

type U0 is Data:
  U0_Survived{f0: U1}
  U0_Slain{f0: U2}

@unsafe
def spiral_main_if1(+c: Bool, +v0: U32) -> IO(U0):
  match c:
    case True{}:
      do IO<U0>:
        +v2 : U1 <- IO.pure(U1, U1_Living{v0, {100 : U32}})
        IO.pure(U0, U0_Survived{v2})
    case False{}:
      do IO<U0>:
        +v4 : U2 <- IO.pure(U2, U2_Fallen{{100 : U32}})
        IO.pure(U0, U0_Slain{v4})

@unsafe
def spiral_main_unbox2_unbox3_if4(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main_unbox2_unbox3(+u: U1, +v0: U32, +v1: Bool, +v6: U0, +v7: U1) -> IO(U32):
  match u:
    case U1_Living{+v8, +v9}:
      do IO<U32>:
        +v10 : Bool <- IO.pure(Bool, U32.is_eq(v8, {60 : U32}))
        spiral_main_unbox2_unbox3_if4(v10)

@unsafe
def spiral_main_unbox2(+u: U0, +v0: U32, +v1: Bool, +v6: U0) -> IO(U32):
  match u:
    case U0_Survived{+v7}:
      do IO<U32>:
        spiral_main_unbox2_unbox3(v7, v0, v1, v6, v7)
    case U0_Slain{+v13}:
      do IO<U32>:
        return {2 : U32}

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {60 : U32})
    +v1 : Bool <- IO.pure(Bool, spiral_i32_gt(v0, {0 : U32}))
    +v6 : U0 <- spiral_main_if1(v1, v0)
    spiral_main_unbox2(v6, v0, v1, v6)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
