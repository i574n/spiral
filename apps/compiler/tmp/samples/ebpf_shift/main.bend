import Base

def spiral_i32_is_negative(+x: U32) -> Bool:
  U32.is_ge(x, 2147483648)

def spiral_i32_shift_right_if(+c: Bool, +a: U32, +n: U32) -> U32:
  match c:
    case True{}:
      U32.not(U32.shrn(U32.not(a), U32.to_nat(n)))
    case False{}:
      U32.shrn(a, U32.to_nat(n))

def spiral_i32_shift_right(+a: U32, +n: U32) -> U32:
  spiral_i32_shift_right_if(spiral_i32_is_negative(a), a, n)

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
def spiral_main_if1_if2_if3_if4(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {4 : U32}

@unsafe
def spiral_main_if1_if2_if3(+c: Bool, +v8: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v12 : Bool <- IO.pure(Bool, U32.is_eq(v8, {4294967294 : U32}))
        spiral_main_if1_if2_if3_if4(v12)
    case False{}:
      do IO<U32>:
        return {3 : U32}

@unsafe
def spiral_main_if1_if2(+c: Bool, +v7: U32, +v8: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v11 : Bool <- IO.pure(Bool, U32.is_eq(v7, {268435455 : U32}))
        spiral_main_if1_if2_if3(v11, v8)
    case False{}:
      do IO<U32>:
        return {2 : U32}

@unsafe
def spiral_main_if1(+c: Bool, +v6: U32, +v7: U32, +v8: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v10 : Bool <- IO.pure(Bool, U32.is_eq(v6, {6 : U32}))
        spiral_main_if1_if2(v10, v7, v8)
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {4294967288 : U32})
    +v1 : U32 <- IO.pure(U32, {3 : U32})
    +v2 : U32 <- IO.pure(U32, {1 : U32})
    +v3 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v4 : U32 <- IO.pure(U32, {4 : U32})
    +v5 : U32 <- IO.pure(U32, spiral_i32_shift_right(v0, v2))
    +v6 : U32 <- IO.pure(U32, U32.shln(v1, U32.to_nat(v2)))
    +v7 : U32 <- IO.pure(U32, U32.shrn(v3, U32.to_nat(v4)))
    +v8 : U32 <- IO.pure(U32, U32.shln(v3, U32.to_nat(v2)))
    +v9 : Bool <- IO.pure(Bool, U32.is_eq(v5, {4294967292 : U32}))
    spiral_main_if1(v9, v6, v7, v8)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
