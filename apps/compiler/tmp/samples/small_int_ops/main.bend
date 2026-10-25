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

def spiral_narrow_i8(+x: U32) -> U32:
  U32.sub(U32.xor(U32.and(x, 255), 128), 128)

def spiral_narrow_i16(+x: U32) -> U32:
  U32.sub(U32.xor(U32.and(x, 65535), 32768), 32768)

@unsafe
def spiral_main_if1(+c: Bool, +v5: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v26 : Bool <- IO.pure(Bool, U32.is_eq(v5, {4294967292 : U32}))
        return v26
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if2(+c: Bool, +v6: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v28 : Bool <- IO.pure(Bool, U32.is_eq(v6, {4294967294 : U32}))
        return v28
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3(+c: Bool, +v7: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v30 : Bool <- IO.pure(Bool, U32.is_eq(v7, {4294967293 : U32}))
        return v30
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if4(+c: Bool, +v8: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v32 : Bool <- IO.pure(Bool, U32.is_eq(v8, {4294967240 : U32}))
        return v32
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if5(+c: Bool, +v11: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v34 : Bool <- IO.pure(Bool, U32.is_eq(v11, {66 : U32}))
        return v34
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if6(+c: Bool, +v12: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v36 : Bool <- IO.pure(Bool, U32.is_eq(v12, {2 : U32}))
        return v36
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if7(+c: Bool, +v14: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v38 : Bool <- IO.pure(Bool, U32.is_eq(v14, {8 : U32}))
        return v38
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if8(+c: Bool, +v15: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v40 : Bool <- IO.pure(Bool, U32.is_eq(v15, {207 : U32}))
        return v40
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if9(+c: Bool, +v16: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v42 : Bool <- IO.pure(Bool, U32.is_eq(v16, {199 : U32}))
        return v42
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if10(+c: Bool, +v17: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v44 : Bool <- IO.pure(Bool, U32.is_eq(v17, {240 : U32}))
        return v44
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if11(+c: Bool, +v20: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v46 : Bool <- IO.pure(Bool, U32.is_eq(v20, {2857 : U32}))
        return v46
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if12(+c: Bool, +v21: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v48 : Bool <- IO.pure(Bool, U32.is_eq(v21, {1 : U32}))
        return v48
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if13(+c: Bool, +v22: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v50 : Bool <- IO.pure(Bool, U32.is_eq(v22, {4294947296 : U32}))
        return v50
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if14(+c: Bool, +v24: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v52 : Bool <- IO.pure(Bool, U32.is_eq(v24, {14464 : U32}))
        return v52
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if15(+c: Bool) -> IO(U32):
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
    +v1 : U32 <- IO.pure(U32, {3 : U32})
    +v2 : U32 <- IO.pure(U32, spiral_narrow_i8(U32.mul(v0, v1)))
    +v3 : U32 <- IO.pure(U32, {4294967288 : U32})
    +v4 : U32 <- IO.pure(U32, {2 : U32})
    +v5 : U32 <- IO.pure(U32, spiral_narrow_i8(spiral_i32_div(v3, v4)))
    +v6 : U32 <- IO.pure(U32, spiral_narrow_i8(spiral_i32_mod(v3, v1)))
    +v7 : U32 <- IO.pure(U32, spiral_narrow_i8(U32.sub(0, v1)))
    +v8 : U32 <- IO.pure(U32, spiral_narrow_i8(U32.shln(v0, U32.to_nat({1 : U32}))))
    +v9 : U32 <- IO.pure(U32, {200 : U32})
    +v10 : U32 <- IO.pure(U32, {3 : U32})
    +v11 : U32 <- IO.pure(U32, U32.and(U32.div(v9, v10), 255))
    +v12 : U32 <- IO.pure(U32, U32.and(U32.mod(v9, v10), 255))
    +v13 : U32 <- IO.pure(U32, {15 : U32})
    +v14 : U32 <- IO.pure(U32, U32.and(U32.and(v9, v13), 255))
    +v15 : U32 <- IO.pure(U32, U32.and(U32.or(v9, v13), 255))
    +v16 : U32 <- IO.pure(U32, U32.and(U32.xor(v9, v13), 255))
    +v17 : U32 <- IO.pure(U32, U32.and(U32.not(v13), 255))
    +v18 : U32 <- IO.pure(U32, {20000 : U32})
    +v19 : U32 <- IO.pure(U32, {7 : U32})
    +v20 : U32 <- IO.pure(U32, spiral_narrow_i16(spiral_i32_div(v18, v19)))
    +v21 : U32 <- IO.pure(U32, spiral_narrow_i16(spiral_i32_mod(v18, v19)))
    +v22 : U32 <- IO.pure(U32, spiral_narrow_i16(U32.sub(0, v18)))
    +v23 : U32 <- IO.pure(U32, {40000 : U32})
    +v24 : U32 <- IO.pure(U32, U32.and(U32.shln(v23, U32.to_nat({1 : U32})), 65535))
    +v25 : Bool <- IO.pure(Bool, U32.is_eq(v2, {44 : U32}))
    +v27 : Bool <- spiral_main_if1(v25, v5)
    +v29 : Bool <- spiral_main_if2(v27, v6)
    +v31 : Bool <- spiral_main_if3(v29, v7)
    +v33 : Bool <- spiral_main_if4(v31, v8)
    +v35 : Bool <- spiral_main_if5(v33, v11)
    +v37 : Bool <- spiral_main_if6(v35, v12)
    +v39 : Bool <- spiral_main_if7(v37, v14)
    +v41 : Bool <- spiral_main_if8(v39, v15)
    +v43 : Bool <- spiral_main_if9(v41, v16)
    +v45 : Bool <- spiral_main_if10(v43, v17)
    +v47 : Bool <- spiral_main_if11(v45, v20)
    +v49 : Bool <- spiral_main_if12(v47, v21)
    +v51 : Bool <- spiral_main_if13(v49, v22)
    +v53 : Bool <- spiral_main_if14(v51, v24)
    spiral_main_if15(v53)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
