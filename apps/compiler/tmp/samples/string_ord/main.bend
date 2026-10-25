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
def spiral_main_if1_if2(+c: Bool, +v1: String, +v2: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v7 : Bool <- IO.pure(Bool, String.is_lt(v1, v2))
        return v7
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if1_if3(+c: Bool, +v2: String, +v3: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v9 : Bool <- IO.pure(Bool, String.is_lt(v2, v3))
        return v9
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if1_if4(+c: Bool, +v0: String, +v4: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v11 : Bool <- IO.pure(Bool, String.is_lt(v4, v0))
        return v11
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if1_if5(+c: Bool, +v0: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v13 : Bool <- IO.pure(Bool, String.is_le(v0, v0))
        return v13
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if1_if6(+c: Bool, +v0: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v15 : Bool <- IO.pure(Bool, String.is_ge(v0, v0))
        return v15
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if1_if7(+c: Bool, +v2: String, +v3: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v17 : Bool <- IO.pure(Bool, String.is_gt(v3, v2))
        return v17
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if1_if8(+c: Bool, +v0: String, +v1: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v19 : Bool <- IO.pure(Bool, String.is_ge(v1, v0))
        return v19
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if1_if9(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main_if1(+c: Bool, +v0: String, +v1: String, +v2: String, +v3: String, +v4: String) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {1 : U32}
    case False{}:
      do IO<U32>:
        +v6 : Bool <- IO.pure(Bool, String.is_lt(v0, v1))
        +v8 : Bool <- spiral_main_if1_if2(v6, v1, v2)
        +v10 : Bool <- spiral_main_if1_if3(v8, v2, v3)
        +v12 : Bool <- spiral_main_if1_if4(v10, v0, v4)
        +v14 : Bool <- spiral_main_if1_if5(v12, v0)
        +v16 : Bool <- spiral_main_if1_if6(v14, v0)
        +v18 : Bool <- spiral_main_if1_if7(v16, v2, v3)
        +v20 : Bool <- spiral_main_if1_if8(v18, v0, v1)
        spiral_main_if1_if9(v20)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : String <- IO.pure(String, "a")
    +v1 : String <- IO.pure(String, "b")
    +v2 : String <- IO.pure(String, "é")
    +v3 : String <- IO.pure(String, "éx")
    +v4 : String <- IO.pure(String, "")
    +v5 : Bool <- IO.pure(Bool, String.is_lt(v0, v0))
    spiral_main_if1(v5, v0, v1, v2, v3, v4)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
