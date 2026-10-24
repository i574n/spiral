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

type U0 is Data:
  U0_Circle{f0: U32}
  U0_Square{f0: U32}
  U0_Tri{f0: U32}
  U0_Dot{}

@unsafe
def pick_0_if1_if2_if3(+c: Bool) -> IO(U0):
  match c:
    case True{}:
      do IO<U0>:
        IO.pure(U0, U0_Tri{{7 : U32}})
    case False{}:
      do IO<U0>:
        IO.pure(U0, U0_Dot{})

@unsafe
def pick_0_if1_if2(+c: Bool, +v0: U32) -> IO(U0):
  match c:
    case True{}:
      do IO<U0>:
        IO.pure(U0, U0_Square{{4 : U32}})
    case False{}:
      do IO<U0>:
        +v5 : Bool <- IO.pure(Bool, U32.is_eq(v0, {2 : U32}))
        pick_0_if1_if2_if3(v5)

@unsafe
def pick_0_if1(+c: Bool, +v0: U32) -> IO(U0):
  match c:
    case True{}:
      do IO<U0>:
        IO.pure(U0, U0_Circle{{5 : U32}})
    case False{}:
      do IO<U0>:
        +v3 : Bool <- IO.pure(Bool, U32.is_eq(v0, {1 : U32}))
        pick_0_if1_if2(v3, v0)

@unsafe
def pick_0(+v0: U32) -> IO(U0):
  do IO<U0>:
    +v1 : Bool <- IO.pure(Bool, U32.is_eq(v0, {0 : U32}))
    pick_0_if1(v1, v0)

@unsafe
def measure_1_unbox4_unbox5_if6(+c: Bool, +v6: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v7 : U32 <- IO.pure(U32, U32.mul(v6, v6))
        return v7
    case False{}:
      do IO<U32>:
        return v6

@unsafe
def measure_1_unbox4_unbox5_if7(+c: Bool, +v9: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v10 : U32 <- IO.pure(U32, U32.mul(v9, {2 : U32}))
        return v10
    case False{}:
      do IO<U32>:
        return v9

@unsafe
def measure_1_unbox4_unbox5(+u: U0, +v0: U0, +v1: U32, +v4: U32, +v5: Bool) -> IO(U32):
  match u:
    case U0_Circle{unused0}:
      do IO<U32>:
        IO.die(U32, 3, "")
    case U0_Square{+v6}:
      do IO<U32>:
        measure_1_unbox4_unbox5_if6(v5, v6)
    case U0_Tri{+v9}:
      do IO<U32>:
        measure_1_unbox4_unbox5_if7(v5, v9)
    case U0_Dot{}:
      do IO<U32>:
        return v4

@unsafe
def measure_1_unbox4_unbox8_if9(+c: Bool, +v6: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v7 : U32 <- IO.pure(U32, U32.mul(v6, v6))
        return v7
    case False{}:
      do IO<U32>:
        return v6

@unsafe
def measure_1_unbox4_unbox8_if10(+c: Bool, +v9: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v10 : U32 <- IO.pure(U32, U32.mul(v9, {2 : U32}))
        return v10
    case False{}:
      do IO<U32>:
        return v9

@unsafe
def measure_1_unbox4_unbox8(+u: U0, +v0: U0, +v1: U32, +v4: U32, +v5: Bool) -> IO(U32):
  match u:
    case U0_Circle{unused0}:
      do IO<U32>:
        IO.die(U32, 3, "")
    case U0_Square{+v6}:
      do IO<U32>:
        measure_1_unbox4_unbox8_if9(v5, v6)
    case U0_Tri{+v9}:
      do IO<U32>:
        measure_1_unbox4_unbox8_if10(v5, v9)
    case U0_Dot{}:
      do IO<U32>:
        return v4

@unsafe
def measure_1_unbox4_unbox11_if12(+c: Bool, +v6: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v7 : U32 <- IO.pure(U32, U32.mul(v6, v6))
        return v7
    case False{}:
      do IO<U32>:
        return v6

@unsafe
def measure_1_unbox4_unbox11_if13(+c: Bool, +v9: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v10 : U32 <- IO.pure(U32, U32.mul(v9, {2 : U32}))
        return v10
    case False{}:
      do IO<U32>:
        return v9

@unsafe
def measure_1_unbox4_unbox11(+u: U0, +v0: U0, +v1: U32, +v4: U32, +v5: Bool) -> IO(U32):
  match u:
    case U0_Circle{unused0}:
      do IO<U32>:
        IO.die(U32, 3, "")
    case U0_Square{+v6}:
      do IO<U32>:
        measure_1_unbox4_unbox11_if12(v5, v6)
    case U0_Tri{+v9}:
      do IO<U32>:
        measure_1_unbox4_unbox11_if13(v5, v9)
    case U0_Dot{}:
      do IO<U32>:
        return v4

@unsafe
def measure_1_unbox4(+u: U0, +v0: U0, +v1: U32) -> IO(U32):
  match u:
    case U0_Circle{+v2}:
      do IO<U32>:
        +v3 : U32 <- IO.pure(U32, U32.mul(v2, {3 : U32}))
        return v3
    case U0_Square{unused0}:
      do IO<U32>:
        +v4 : U32 <- IO.pure(U32, U32.mul(v1, v1))
        +v5 : Bool <- IO.pure(Bool, spiral_i32_gt(v4, {3 : U32}))
        measure_1_unbox4_unbox5(v0, v0, v1, v4, v5)
    case U0_Tri{unused0}:
      do IO<U32>:
        +v4 : U32 <- IO.pure(U32, U32.mul(v1, v1))
        +v5 : Bool <- IO.pure(Bool, spiral_i32_gt(v4, {3 : U32}))
        measure_1_unbox4_unbox8(v0, v0, v1, v4, v5)
    case U0_Dot{}:
      do IO<U32>:
        +v4 : U32 <- IO.pure(U32, U32.mul(v1, v1))
        +v5 : Bool <- IO.pure(Bool, spiral_i32_gt(v4, {3 : U32}))
        measure_1_unbox4_unbox11(v0, v0, v1, v4, v5)

@unsafe
def measure_1(+v0: U0, +v1: U32) -> IO(U32):
  do IO<U32>:
    measure_1_unbox4(v0, v0, v1)

@unsafe
def measure_tri_2_unbox14_unbox15(+u: U0, +v0: U0, +v1: U32, +v4: U32) -> IO(U32):
  match u:
    case U0_Circle{unused0}:
      do IO<U32>:
        IO.die(U32, 3, "")
    case U0_Square{unused0}:
      do IO<U32>:
        IO.die(U32, 3, "")
    case U0_Tri{+v5}:
      do IO<U32>:
        +v6 : U32 <- IO.pure(U32, U32.mul(v5, v4))
        return v6
    case U0_Dot{}:
      do IO<U32>:
        IO.die(U32, 3, "")

@unsafe
def measure_tri_2_unbox14(+u: U0, +v0: U0, +v1: U32) -> IO(U32):
  match u:
    case U0_Circle{+v2}:
      do IO<U32>:
        return v2
    case U0_Square{+v3}:
      do IO<U32>:
        return v3
    case U0_Tri{unused0}:
      do IO<U32>:
        +v4 : U32 <- IO.pure(U32, U32.add(v1, {2 : U32}))
        measure_tri_2_unbox14_unbox15(v0, v0, v1, v4)
    case U0_Dot{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def measure_tri_2(+v0: U0, +v1: U32) -> IO(U32):
  do IO<U32>:
    measure_tri_2_unbox14(v0, v0, v1)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {0 : U32})
    +v1 : U0 <- pick_0(v0)
    +v2 : U32 <- measure_1(v1, v0)
    +v3 : U32 <- IO.pure(U32, U32.add(v0, {1 : U32}))
    +v4 : U0 <- pick_0(v3)
    +v5 : U32 <- measure_1(v4, v3)
    +v6 : U32 <- IO.pure(U32, U32.add(v2, v5))
    +v7 : U32 <- IO.pure(U32, U32.add(v0, {2 : U32}))
    +v8 : U0 <- pick_0(v7)
    +v9 : U32 <- measure_1(v8, v7)
    +v10 : U32 <- IO.pure(U32, U32.add(v6, v9))
    +v11 : U32 <- IO.pure(U32, U32.add(v0, {3 : U32}))
    +v12 : U0 <- pick_0(v11)
    +v13 : U32 <- measure_1(v12, v11)
    +v14 : U32 <- IO.pure(U32, U32.add(v10, v13))
    +v15 : U0 <- pick_0(v7)
    +v16 : U32 <- measure_tri_2(v15, v0)
    +v17 : U32 <- IO.pure(U32, U32.add(v14, v16))
    +v18 : U0 <- pick_0(v0)
    +v19 : U32 <- measure_tri_2(v18, v0)
    +v20 : U32 <- IO.pure(U32, U32.add(v17, v19))
    return v20

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
