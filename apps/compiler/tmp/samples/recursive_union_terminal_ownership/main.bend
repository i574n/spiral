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
  U0_Leaf{}
  U0_Node{f0: U32, f1: U0, f2: U0}

@unsafe
def sum_1_unbox1(+u: U0, +v0: U0) -> IO(U32):
  match u:
    case U0_Leaf{}:
      do IO<U32>:
        return {0 : U32}
    case U0_Node{+v1, +v2, +v3}:
      do IO<U32>:
        +v4 : U32 <- sum_1(v2)
        +v5 : U32 <- sum_1(v3)
        +v6 : U32 <- IO.pure(U32, U32.add(v4, v5))
        +v7 : U32 <- IO.pure(U32, U32.add(v1, v6))
        return v7

@unsafe
def sum_1(+v0: U0) -> IO(U32):
  do IO<U32>:
    sum_1_unbox1(v0, v0)

@unsafe
def consume_pair_0(+v0: U0, +v1: U0) -> IO(U32):
  do IO<U32>:
    +v2 : U32 <- sum_1(v0)
    +v3 : U32 <- sum_1(v1)
    +v4 : U32 <- IO.pure(U32, U32.add(v2, v3))
    return v4

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {1 : U32})
    +v1 : U32 <- IO.pure(U32, {2 : U32})
    +v2 : U0 <- IO.pure(U0, U0_Leaf{})
    +v3 : U0 <- IO.pure(U0, U0_Node{v1, v2, v2})
    +v4 : U0 <- IO.pure(U0, U0_Node{v0, v3, v3})
    +v5 : U32 <- IO.pure(U32, {1 : U32})
    +v6 : U32 <- IO.pure(U32, {2 : U32})
    +v7 : U0 <- IO.pure(U0, U0_Leaf{})
    +v8 : U0 <- IO.pure(U0, U0_Node{v6, v7, v7})
    +v9 : U0 <- IO.pure(U0, U0_Node{v5, v8, v8})
    +v10 : U32 <- consume_pair_0(v4, v9)
    +v11 : U32 <- IO.pure(U32, U32.sub(v10, {10 : U32}))
    return v11

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
