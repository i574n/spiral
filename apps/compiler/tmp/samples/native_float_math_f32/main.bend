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
def spiral_main_if1(+c: Bool, +v0: F32, +v1: F32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v8 : F32 <- IO.pure(F32, F32.exp(v0))
        +v9 : Bool <- IO.pure(Bool, F32.is_eq(v8, v1))
        return v9
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if2(+c: Bool, +v0: F32, +v1: F32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v11 : F32 <- IO.pure(F32, F32.log(v1))
        +v12 : Bool <- IO.pure(Bool, F32.is_eq(v11, v0))
        return v12
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3(+c: Bool, +v0: F32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v14 : F32 <- IO.pure(F32, F32.sin(v0))
        +v15 : Bool <- IO.pure(Bool, F32.is_eq(v14, v0))
        return v15
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if4(+c: Bool, +v0: F32, +v1: F32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v17 : F32 <- IO.pure(F32, F32.cos(v0))
        +v18 : Bool <- IO.pure(Bool, F32.is_eq(v17, v1))
        return v18
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if5(+c: Bool, +v0: F32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v20 : F32 <- IO.pure(F32, F32.tanh(v0))
        +v21 : Bool <- IO.pure(Bool, F32.is_eq(v20, v0))
        return v21
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if6(+c: Bool, +v1: F32, +v3: F32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v23 : F32 <- IO.pure(F32, F32.pow(v3, v1))
        +v24 : Bool <- IO.pure(Bool, F32.is_eq(v23, v3))
        return v24
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if7(+c: Bool, +v5: F32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v26 : Bool <- IO.pure(Bool, F32.is_ne(v5, v5))
        return v26
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if8_if9(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {2 : U32}
    case False{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main_if8(+c: Bool, +v1: F32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v28 : Bool <- IO.pure(Bool, F32.is_ne(v1, v1))
        spiral_main_if8_if9(v28)
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : F32 <- IO.pure(F32, 0.0)
    +v1 : F32 <- IO.pure(F32, 1.0)
    +v2 : F32 <- IO.pure(F32, 4.0)
    +v3 : F32 <- IO.pure(F32, 3.0)
    +v4 : F32 <- IO.pure(F32, F32.div(1.0, 0.0))
    +v5 : F32 <- IO.pure(F32, F32.sub(v4, v4))
    +v6 : F32 <- IO.pure(F32, F32.sqrt(v2))
    +v7 : Bool <- IO.pure(Bool, F32.is_eq(v6, 2.0))
    +v10 : Bool <- spiral_main_if1(v7, v0, v1)
    +v13 : Bool <- spiral_main_if2(v10, v0, v1)
    +v16 : Bool <- spiral_main_if3(v13, v0)
    +v19 : Bool <- spiral_main_if4(v16, v0, v1)
    +v22 : Bool <- spiral_main_if5(v19, v0)
    +v25 : Bool <- spiral_main_if6(v22, v1, v3)
    +v27 : Bool <- spiral_main_if7(v25, v5)
    spiral_main_if8(v27, v1)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
