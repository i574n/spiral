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

def spiral_narrow_i8(+x: U32) -> U32:
  U32.sub(U32.xor(U32.and(x, 255), 128), 128)

def spiral_narrow_i16(+x: U32) -> U32:
  U32.sub(U32.xor(U32.and(x, 65535), 32768), 32768)

@unsafe
def spiral_main_if1(+c: Bool, +v4: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v17 : Bool <- IO.pure(Bool, U32.is_eq(v4, {44 : U32}))
        return v17
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if2(+c: Bool, +v6: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v19 : Bool <- IO.pure(Bool, U32.is_eq(v6, {4294967292 : U32}))
        return v19
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3(+c: Bool, +v7: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v21 : Bool <- IO.pure(Bool, U32.is_eq(v7, {100 : U32}))
        return v21
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if4(+c: Bool, +v9: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v23 : Bool <- IO.pure(Bool, U32.is_eq(v9, {4294941760 : U32}))
        return v23
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if5(+c: Bool, +v11: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v25 : Bool <- IO.pure(Bool, U32.is_eq(v11, {14464 : U32}))
        return v25
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if6(+c: Bool, +v13: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v27 : Bool <- IO.pure(Bool, U32.is_eq(v13, {7 : U32}))
        return v27
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if7(+c: Bool, +v15: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v29 : Bool <- IO.pure(Bool, U32.is_eq(v15, {9 : U32}))
        return v29
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if8(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {100 : U32})
    +v1 : U32 <- IO.pure(U32, spiral_narrow_i8(U32.add(v0, v0)))
    +v2 : U32 <- IO.pure(U32, {200 : U32})
    +v3 : U32 <- IO.pure(U32, {100 : U32})
    +v4 : U32 <- IO.pure(U32, U32.and(U32.add(v2, v3), 255))
    +v5 : U32 <- IO.pure(U32, {4294967288 : U32})
    +v6 : U32 <- IO.pure(U32, spiral_narrow_i8(spiral_i32_shift_right(v5, {1 : U32})))
    +v7 : U32 <- IO.pure(U32, U32.and(U32.shrn(v2, U32.to_nat({1 : U32})), 255))
    +v8 : U32 <- IO.pure(U32, {20000 : U32})
    +v9 : U32 <- IO.pure(U32, spiral_narrow_i16(U32.add(v8, v8)))
    +v10 : U32 <- IO.pure(U32, {40000 : U32})
    +v11 : U32 <- IO.pure(U32, U32.and(U32.add(v10, v10), 65535))
    +v12 : U32 <- IO.pure(U32, {7 : U32})
    +v13 : U32 <- IO.pure(U32, spiral_narrow_i8(v12))
    +v14 : U32 <- IO.pure(U32, {9 : U32})
    +v15 : U32 <- IO.pure(U32, v14)
    +v16 : Bool <- IO.pure(Bool, U32.is_eq(v1, {4294967240 : U32}))
    +v18 : Bool <- spiral_main_if1(v16, v4)
    +v20 : Bool <- spiral_main_if2(v18, v6)
    +v22 : Bool <- spiral_main_if3(v20, v7)
    +v24 : Bool <- spiral_main_if4(v22, v9)
    +v26 : Bool <- spiral_main_if5(v24, v11)
    +v28 : Bool <- spiral_main_if6(v26, v13)
    +v30 : Bool <- spiral_main_if7(v28, v15)
    spiral_main_if8(v30)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
