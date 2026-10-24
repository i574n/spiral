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
def spiral_string_keep(+keep: Bool, +h: Char, +rest: String) -> String:
  match keep:
    case True{}:
      SCon{h, rest}
    case False{}:
      rest

@unsafe
def spiral_string_slice_go(+s: String, +offset: U32, +from: U32, +until: U32) -> String:
  match s:
    case SNil{}:
      SNil{}
    case SCon{+h, +t}:
      spiral_string_keep(Bool.and(U32.is_ge(offset, from), U32.is_lt(offset, until)), h, spiral_string_slice_go(t, U32.add(offset, spiral_utf8_width(Char.to_u32(h))), from, until))

@unsafe
def spiral_string_is_boundary(+s: String, +offset: U32, +x: U32) -> Bool:
  match s:
    case SNil{}:
      U32.is_eq(offset, x)
    case SCon{+h, +t}:
      Bool.or(U32.is_eq(offset, x), spiral_string_is_boundary(t, U32.add(offset, spiral_utf8_width(Char.to_u32(h))), x))

def spiral_string_slice_checked(+valid: Bool, +s: String, +from: U32, +until: U32) -> IO(String):
  match valid:
    case True{}:
      IO.pure(String, spiral_string_slice_go(s, {0 : U32}, from, until))
    case False{}:
      IO.die(String, 3, "")

def spiral_string_slice(+s: String, +from: U32, +to: U32) -> IO(String):
  spiral_string_slice_checked(Bool.and(Bool.and(Bool.not(U32.is_ge(from, 2147483648)), U32.is_le(U32.add(to, 1), spiral_string_bytes(s))), Bool.and(U32.is_le(from, U32.add(to, 1)), Bool.or(U32.is_eq(from, U32.add(to, 1)), Bool.and(spiral_string_is_boundary(s, {0 : U32}, from), spiral_string_is_boundary(s, {0 : U32}, U32.add(to, 1)))))), s, from, U32.add(to, 1))

@unsafe
def spiral_main_if1_if2(+c: Bool, +v8: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v17 : Bool <- IO.pure(Bool, U32.is_eq(v8, {97 : U32}))
        return v17
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if1_if3(+c: Bool, +v6: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v19 : Bool <- IO.pure(Bool, U32.is_eq(v6, {3 : U32}))
        return v19
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if1_if4(+c: Bool, +v10: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v21 : Bool <- IO.pure(Bool, U32.is_eq(v10, {1 : U32}))
        return v21
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if1_if5(+c: Bool, +v12: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v23 : Bool <- IO.pure(Bool, U32.is_eq(v12, {0 : U32}))
        return v23
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if1_if6(+c: Bool, +v14: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v25 : Bool <- IO.pure(Bool, U32.is_eq(v14, {2 : U32}))
        return v25
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if1_if7(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main_if1(+c: Bool, +v1: U32, +v6: U32, +v8: U32, +v10: U32, +v12: U32, +v14: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {1 : U32}
    case False{}:
      do IO<U32>:
        +v16 : Bool <- IO.pure(Bool, U32.is_eq(v1, {2 : U32}))
        +v18 : Bool <- spiral_main_if1_if2(v16, v8)
        +v20 : Bool <- spiral_main_if1_if3(v18, v6)
        +v22 : Bool <- spiral_main_if1_if4(v20, v10)
        +v24 : Bool <- spiral_main_if1_if5(v22, v12)
        +v26 : Bool <- spiral_main_if1_if6(v24, v14)
        spiral_main_if1_if7(v26)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : String <- IO.pure(String, "é")
    +v1 : U32 <- IO.pure(U32, spiral_string_bytes(v0))
    +v2 : U32 <- IO.pure(U32, spiral_string_byte_at(v0, {0 : U32}))
    +v3 : U32 <- IO.pure(U32, spiral_string_byte_at(v0, {1 : U32}))
    +v4 : String <- IO.pure(String, "x")
    +v5 : String <- IO.pure(String, String.append(v0, v4))
    +v6 : U32 <- IO.pure(U32, spiral_string_bytes(v5))
    +v7 : String <- IO.pure(String, "ab")
    +v8 : U32 <- IO.pure(U32, spiral_string_byte_at(v7, {0 : U32}))
    +v9 : String <- spiral_string_slice(v7, {0 : U32}, {0 : U32})
    +v10 : U32 <- IO.pure(U32, spiral_string_bytes(v9))
    +v11 : String <- spiral_string_slice(v7, {1 : U32}, {0 : U32})
    +v12 : U32 <- IO.pure(U32, spiral_string_bytes(v11))
    +v13 : String <- spiral_string_slice(v0, {0 : U32}, {1 : U32})
    +v14 : U32 <- IO.pure(U32, spiral_string_bytes(v13))
    +v15 : Bool <- IO.pure(Bool, U32.is_eq(v2, v3))
    spiral_main_if1(v15, v1, v6, v8, v10, v12, v14)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
