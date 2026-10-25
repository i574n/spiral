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
  U0_Circle{f0: U32}
  U0_Rect{f0: U32, f1: U32}
  U0_Empty{}

@unsafe
def spiral_main_unbox1_if2(+c: Bool, +v12: U32, +v14: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v16 : Bool <- IO.pure(Bool, U32.is_eq(v12, v14))
        return v16
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_unbox1(+u: U0, +u1: U0, +v0: U32, +v1: U0, +v2: U32, +v3: U32, +v4: U0, +v5: U0, +v6: U32, +v7: U0) -> IO(Bool):
  match u:
    case U0_Circle{+v8}:
      match u1:
        case U0_Circle{+v9}:
          do IO<Bool>:
            +v10 : Bool <- IO.pure(Bool, U32.is_eq(v8, v9))
            return v10
        case U0_Rect{unused0, unused1}:
          do IO<Bool>:
            return False{}
        case U0_Empty{}:
          do IO<Bool>:
            return False{}
    case U0_Rect{+v11, +v12}:
      match u1:
        case U0_Circle{unused0}:
          do IO<Bool>:
            return False{}
        case U0_Rect{+v13, +v14}:
          do IO<Bool>:
            +v15 : Bool <- IO.pure(Bool, U32.is_eq(v11, v13))
            spiral_main_unbox1_if2(v15, v12, v14)
        case U0_Empty{}:
          do IO<Bool>:
            return False{}
    case U0_Empty{}:
      match u1:
        case U0_Circle{unused0}:
          do IO<Bool>:
            return False{}
        case U0_Rect{unused0, unused1}:
          do IO<Bool>:
            return False{}
        case U0_Empty{}:
          do IO<Bool>:
            return True{}

@unsafe
def spiral_main_if3(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {100 : U32}
    case False{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main_unbox4(+u: U0, +v0: U32, +v1: U0, +v2: U32, +v3: U32, +v4: U0, +v5: U0, +v6: U32, +v7: U0, +v18: Bool, +v19: U32) -> IO(U32):
  match u:
    case U0_Circle{+v20}:
      do IO<U32>:
        +v21 : U32 <- IO.pure(U32, U32.mul({3 : U32}, v20))
        +v22 : U32 <- IO.pure(U32, U32.mul(v21, v20))
        return v22
    case U0_Rect{+v23, +v24}:
      do IO<U32>:
        +v25 : U32 <- IO.pure(U32, U32.mul(v23, v24))
        return v25
    case U0_Empty{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main_unbox5(+u: U0, +v0: U32, +v1: U0, +v2: U32, +v3: U32, +v4: U0, +v5: U0, +v6: U32, +v7: U0, +v18: Bool, +v19: U32, +v28: U32) -> IO(U32):
  match u:
    case U0_Circle{+v29}:
      do IO<U32>:
        +v30 : U32 <- IO.pure(U32, U32.mul({3 : U32}, v29))
        +v31 : U32 <- IO.pure(U32, U32.mul(v30, v29))
        return v31
    case U0_Rect{+v32, +v33}:
      do IO<U32>:
        +v34 : U32 <- IO.pure(U32, U32.mul(v32, v33))
        return v34
    case U0_Empty{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main_unbox6(+u: U0, +v0: U32, +v1: U0, +v2: U32, +v3: U32, +v4: U0, +v5: U0, +v6: U32, +v7: U0, +v18: Bool, +v19: U32, +v28: U32, +v37: U32, +v38: U32) -> IO(U32):
  match u:
    case U0_Circle{+v39}:
      do IO<U32>:
        +v40 : U32 <- IO.pure(U32, U32.mul({3 : U32}, v39))
        +v41 : U32 <- IO.pure(U32, U32.mul(v40, v39))
        return v41
    case U0_Rect{+v42, +v43}:
      do IO<U32>:
        +v44 : U32 <- IO.pure(U32, U32.mul(v42, v43))
        return v44
    case U0_Empty{}:
      do IO<U32>:
        return {0 : U32}

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {2 : U32})
    +v1 : U0 <- IO.pure(U0, U0_Circle{v0})
    +v2 : U32 <- IO.pure(U32, {3 : U32})
    +v3 : U32 <- IO.pure(U32, {4 : U32})
    +v4 : U0 <- IO.pure(U0, U0_Rect{v2, v3})
    +v5 : U0 <- IO.pure(U0, U0_Empty{})
    +v6 : U32 <- IO.pure(U32, {2 : U32})
    +v7 : U0 <- IO.pure(U0, U0_Circle{v6})
    +v18 : Bool <- spiral_main_unbox1(v1, v7, v0, v1, v2, v3, v4, v5, v6, v7)
    +v19 : U32 <- spiral_main_if3(v18)
    +v28 : U32 <- spiral_main_unbox4(v1, v0, v1, v2, v3, v4, v5, v6, v7, v18, v19)
    +v37 : U32 <- spiral_main_unbox5(v4, v0, v1, v2, v3, v4, v5, v6, v7, v18, v19, v28)
    +v38 : U32 <- IO.pure(U32, U32.add(v28, v37))
    +v47 : U32 <- spiral_main_unbox6(v5, v0, v1, v2, v3, v4, v5, v6, v7, v18, v19, v28, v37, v38)
    +v48 : U32 <- IO.pure(U32, U32.add(v38, v47))
    +v49 : U32 <- IO.pure(U32, U32.add(v48, v19))
    return v49

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
