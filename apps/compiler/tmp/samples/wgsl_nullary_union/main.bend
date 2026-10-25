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
  U0_North{}
  U0_East{}
  U0_South{}
  U0_West{}

@unsafe
def spiral_main_unbox1(+u: U0, +v0: U0) -> IO(U0):
  match u:
    case U0_North{}:
      do IO<U0>:
        IO.pure(U0, U0_East{})
    case U0_East{}:
      do IO<U0>:
        IO.pure(U0, U0_South{})
    case U0_South{}:
      do IO<U0>:
        IO.pure(U0, U0_West{})
    case U0_West{}:
      do IO<U0>:
        IO.pure(U0, U0_North{})

@unsafe
def spiral_main_unbox2(+u: U0, +v0: U0, +v8: U0) -> IO(U0):
  match u:
    case U0_North{}:
      do IO<U0>:
        IO.pure(U0, U0_East{})
    case U0_East{}:
      do IO<U0>:
        IO.pure(U0, U0_South{})
    case U0_South{}:
      do IO<U0>:
        IO.pure(U0, U0_West{})
    case U0_West{}:
      do IO<U0>:
        IO.pure(U0, U0_North{})

@unsafe
def spiral_main_unbox3(+u: U0, +u1: U0, +v0: U0, +v8: U0, +v16: U0, +v17: U0) -> IO(Bool):
  match u:
    case U0_North{}:
      match u1:
        case U0_North{}:
          do IO<Bool>:
            return True{}
        case U0_East{}:
          do IO<Bool>:
            return False{}
        case U0_South{}:
          do IO<Bool>:
            return False{}
        case U0_West{}:
          do IO<Bool>:
            return False{}
    case U0_East{}:
      match u1:
        case U0_North{}:
          do IO<Bool>:
            return False{}
        case U0_East{}:
          do IO<Bool>:
            return True{}
        case U0_South{}:
          do IO<Bool>:
            return False{}
        case U0_West{}:
          do IO<Bool>:
            return False{}
    case U0_South{}:
      match u1:
        case U0_North{}:
          do IO<Bool>:
            return False{}
        case U0_East{}:
          do IO<Bool>:
            return False{}
        case U0_South{}:
          do IO<Bool>:
            return True{}
        case U0_West{}:
          do IO<Bool>:
            return False{}
    case U0_West{}:
      match u1:
        case U0_North{}:
          do IO<Bool>:
            return False{}
        case U0_East{}:
          do IO<Bool>:
            return False{}
        case U0_South{}:
          do IO<Bool>:
            return False{}
        case U0_West{}:
          do IO<Bool>:
            return True{}

@unsafe
def spiral_main_if4(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {100 : U32}
    case False{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main_unbox5(+u: U0, +v0: U0, +v8: U0, +v16: U0, +v17: U0, +v18: Bool, +v19: U32) -> IO(U32):
  match u:
    case U0_North{}:
      do IO<U32>:
        return {1 : U32}
    case U0_East{}:
      do IO<U32>:
        return {2 : U32}
    case U0_South{}:
      do IO<U32>:
        return {7 : U32}
    case U0_West{}:
      do IO<U32>:
        return {7 : U32}

@unsafe
def spiral_main_unbox6(+u: U0, +v0: U0, +v8: U0, +v16: U0, +v17: U0, +v18: Bool, +v19: U32, +v21: U32) -> IO(U32):
  match u:
    case U0_North{}:
      do IO<U32>:
        return {1 : U32}
    case U0_East{}:
      do IO<U32>:
        return {2 : U32}
    case U0_South{}:
      do IO<U32>:
        return {7 : U32}
    case U0_West{}:
      do IO<U32>:
        return {7 : U32}

@unsafe
def spiral_main_unbox7(+u: U0, +v0: U0, +v8: U0, +v16: U0, +v17: U0, +v18: Bool, +v19: U32, +v21: U32, +v23: U32, +v24: U32, +v25: U32) -> IO(U32):
  match u:
    case U0_North{}:
      do IO<U32>:
        return {1 : U32}
    case U0_East{}:
      do IO<U32>:
        return {2 : U32}
    case U0_South{}:
      do IO<U32>:
        return {7 : U32}
    case U0_West{}:
      do IO<U32>:
        return {7 : U32}

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U0 <- IO.pure(U0, U0_North{})
    +v8 : U0 <- spiral_main_unbox1(v0, v0)
    +v16 : U0 <- spiral_main_unbox2(v8, v0, v8)
    +v17 : U0 <- IO.pure(U0, U0_South{})
    +v18 : Bool <- spiral_main_unbox3(v16, v17, v0, v8, v16, v17)
    +v19 : U32 <- spiral_main_if4(v18)
    +v21 : U32 <- spiral_main_unbox5(v0, v0, v8, v16, v17, v18, v19)
    +v23 : U32 <- spiral_main_unbox6(v8, v0, v8, v16, v17, v18, v19, v21)
    +v24 : U32 <- IO.pure(U32, U32.mul(v23, {3 : U32}))
    +v25 : U32 <- IO.pure(U32, U32.add(v21, v24))
    +v27 : U32 <- spiral_main_unbox7(v16, v0, v8, v16, v17, v18, v19, v21, v23, v24, v25)
    +v28 : U32 <- IO.pure(U32, U32.mul(v27, {9 : U32}))
    +v29 : U32 <- IO.pure(U32, U32.add(v25, v28))
    +v30 : U32 <- IO.pure(U32, U32.add(v29, v19))
    return v30

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
