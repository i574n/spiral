import Base

def spiral_i32_bias(+x: U32) -> U32:
  U32.xor(x, 2147483648)

def spiral_i32_lt(+a: U32, +b: U32) -> Bool:
  U32.is_lt(spiral_i32_bias(a), spiral_i32_bias(b))

def spiral_i32_le(+a: U32, +b: U32) -> Bool:
  U32.is_le(spiral_i32_bias(a), spiral_i32_bias(b))

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

@unsafe
def spiral_f32_to_i32(+value: F32) -> U32:
  spiral_f32_to_i32_signed(value, F32.is_lt(value, 0.0))

@unsafe
def spiral_f32_to_i32_signed(+value: F32, negative: Bool) -> U32:
  match negative:
    case True{}:
      U32.sub(0, F32.to_u32(F32.neg(value)))
    case False{}:
      F32.to_u32(value)
@unsafe
def spiral_main_if1(+c: Bool, +v0: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v22 : Bool <- IO.pure(Bool, spiral_i32_le(v0, v0))
        return v22
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if2(+c: Bool, +v0: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v24 : Bool <- IO.pure(Bool, spiral_i32_gt(v0, {0 : U32}))
        +v25 : Bool <- IO.pure(Bool, Bool.not(Bool.xor(v24, False{})))
        return v25
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3_if4(+c: Bool, +v0: U32, +v11: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v28 : Bool <- IO.pure(Bool, U32.is_eq(v11, v0))
        return v28
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3_if5(+c: Bool, +v2: U32, +v12: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v30 : Bool <- IO.pure(Bool, U32.is_eq(v12, v2))
        return v30
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3_if6(+c: Bool, +v1: U32, +v13: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v32 : Bool <- IO.pure(Bool, U32.is_eq(v13, v1))
        return v32
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3_if7_if8(+c: Bool, +v15: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v35 : Bool <- IO.pure(Bool, U32.is_eq(v15, {2 : U32}))
        return v35
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3_if7_if9_if10(+c: Bool, +v17: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v38 : Bool <- IO.pure(Bool, U32.is_eq(v17, {2147483647 : U32}))
        return v38
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3_if7_if9_if11(+c: Bool, +v18: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v40 : Bool <- IO.pure(Bool, U32.is_eq(v18, {2 : U32}))
        return v40
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3_if7_if9_if12_if13(+c: Bool, +v20: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v43 : Bool <- IO.pure(Bool, U32.is_eq(v20, {1 : U32}))
        return v43
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3_if7_if9_if12_if14(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {5 : U32}

@unsafe
def spiral_main_if3_if7_if9_if12(+c: Bool, +v1: U32, +v19: U32, +v20: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v42 : Bool <- IO.pure(Bool, U32.is_eq(v19, v1))
        +v44 : Bool <- spiral_main_if3_if7_if9_if12_if13(v42, v20)
        spiral_main_if3_if7_if9_if12_if14(v44)
    case False{}:
      do IO<U32>:
        return {4 : U32}

@unsafe
def spiral_main_if3_if7_if9(+c: Bool, +v1: U32, +v16: U32, +v17: U32, +v18: U32, +v19: U32, +v20: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v37 : Bool <- IO.pure(Bool, U32.is_eq(v16, {1073741824 : U32}))
        +v39 : Bool <- spiral_main_if3_if7_if9_if10(v37, v17)
        +v41 : Bool <- spiral_main_if3_if7_if9_if11(v39, v18)
        spiral_main_if3_if7_if9_if12(v41, v1, v19, v20)
    case False{}:
      do IO<U32>:
        return {3 : U32}

@unsafe
def spiral_main_if3_if7(+c: Bool, +v1: U32, +v2: U32, +v14: U32, +v15: U32, +v16: U32, +v17: U32, +v18: U32, +v19: U32, +v20: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v34 : Bool <- IO.pure(Bool, U32.is_eq(v14, v2))
        +v36 : Bool <- spiral_main_if3_if7_if8(v34, v15)
        spiral_main_if3_if7_if9(v36, v1, v16, v17, v18, v19, v20)
    case False{}:
      do IO<U32>:
        return {2 : U32}

@unsafe
def spiral_main_if3(+c: Bool, +v0: U32, +v1: U32, +v2: U32, +v10: U32, +v11: U32, +v12: U32, +v13: U32, +v14: U32, +v15: U32, +v16: U32, +v17: U32, +v18: U32, +v19: U32, +v20: U32) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        +v27 : Bool <- IO.pure(Bool, U32.is_gt(v10, {1 : U32}))
        +v29 : Bool <- spiral_main_if3_if4(v27, v0, v11)
        +v31 : Bool <- spiral_main_if3_if5(v29, v2, v12)
        +v33 : Bool <- spiral_main_if3_if6(v31, v1, v13)
        spiral_main_if3_if7(v33, v1, v2, v14, v15, v16, v17, v18, v19, v20)
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {2147483648 : U32})
    +v1 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v2 : U32 <- IO.pure(U32, {4294967295 : U32})
    +v3 : F32 <- IO.pure(F32, 0.0)
    +v4 : F32 <- IO.pure(F32, 1.9)
    +v5 : F32 <- IO.pure(F32, 2.9)
    +v6 : U32 <- IO.pure(U32, {4294967294 : U32})
    +v7 : U32 <- IO.pure(U32, {5 : U32})
    +v8 : U32 <- IO.pure(U32, {0 : U32})
    +v9 : F32 <- IO.pure(F32, F32.sub(v3, v4))
    +v10 : U32 <- IO.pure(U32, v0)
    +v11 : U32 <- IO.pure(U32, v10)
    +v12 : U32 <- IO.pure(U32, v1)
    +v13 : U32 <- IO.pure(U32, v2)
    +v14 : U32 <- IO.pure(U32, spiral_f32_to_i32(v9))
    +v15 : U32 <- IO.pure(U32, spiral_f32_to_i32(v5))
    +v16 : U32 <- IO.pure(U32, U32.div(v10, {2 : U32}))
    +v17 : U32 <- IO.pure(U32, U32.div(v6, {2 : U32}))
    +v18 : U32 <- IO.pure(U32, U32.mod(v7, {3 : U32}))
    +v19 : U32 <- IO.pure(U32, U32.not(v8))
    +v20 : U32 <- IO.pure(U32, U32.shrn(v1, U32.to_nat({31 : U32})))
    +v21 : Bool <- IO.pure(Bool, spiral_i32_lt(v0, {4294967295 : U32}))
    +v23 : Bool <- spiral_main_if1(v21, v0)
    +v26 : Bool <- spiral_main_if2(v23, v0)
    spiral_main_if3(v26, v0, v1, v2, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
