import Base

def spiral_i32_is_negative(+x: U32) -> Bool:
  U32.is_ge(x, 2147483648)

def spiral_i32_negate_if(+c: Bool, +x: U32) -> U32:
  match c:
    case True{}:
      U32.sub(0, x)
    case False{}:
      x

def spiral_i32_abs(+x: U32) -> U32:
  spiral_i32_negate_if(spiral_i32_is_negative(x), x)

def spiral_i32_div(+a: U32, +b: U32) -> U32:
  spiral_i32_negate_if(Bool.xor(spiral_i32_is_negative(a), spiral_i32_is_negative(b)), U32.div(spiral_i32_abs(a), spiral_i32_abs(b)))

def spiral_i32_mod(+a: U32, +b: U32) -> U32:
  spiral_i32_negate_if(spiral_i32_is_negative(a), U32.mod(spiral_i32_abs(a), spiral_i32_abs(b)))

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
def spiral_main_if1(+c: Bool, +v6: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v12 : Bool <- IO.pure(Bool, U32.is_eq(v6, {1 : U32}))
        return v12
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if2(+c: Bool, +v7: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v14 : Bool <- IO.pure(Bool, U32.is_eq(v7, {3 : U32}))
        return v14
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3(+c: Bool, +v8: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v16 : Bool <- IO.pure(Bool, U32.is_eq(v8, {4294967295 : U32}))
        return v16
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if4(+c: Bool, +v9: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v18 : Bool <- IO.pure(Bool, U32.is_eq(v9, {14 : U32}))
        return v18
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if5(+c: Bool, +v10: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v20 : Bool <- IO.pure(Bool, U32.is_eq(v10, {2 : U32}))
        return v20
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if6(+c: Bool) -> IO(U32):
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
    +v0 : U32 <- IO.pure(U32, {7 : U32})
    +v1 : U32 <- IO.pure(U32, {4294967294 : U32})
    +v2 : U32 <- IO.pure(U32, {4294967289 : U32})
    +v3 : U32 <- IO.pure(U32, {100 : U32})
    +v4 : U32 <- IO.pure(U32, {7 : U32})
    +v5 : U32 <- IO.pure(U32, spiral_i32_div(v0, v1))
    +v6 : U32 <- IO.pure(U32, spiral_i32_mod(v0, v1))
    +v7 : U32 <- IO.pure(U32, spiral_i32_div(v2, v1))
    +v8 : U32 <- IO.pure(U32, spiral_i32_mod(v2, v1))
    +v9 : U32 <- IO.pure(U32, U32.div(v3, v4))
    +v10 : U32 <- IO.pure(U32, U32.mod(v3, v4))
    +v11 : Bool <- IO.pure(Bool, U32.is_eq(v5, {4294967293 : U32}))
    +v13 : Bool <- spiral_main_if1(v11, v6)
    +v15 : Bool <- spiral_main_if2(v13, v7)
    +v17 : Bool <- spiral_main_if3(v15, v8)
    +v19 : Bool <- spiral_main_if4(v17, v9)
    +v21 : Bool <- spiral_main_if5(v19, v10)
    spiral_main_if6(v21)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
