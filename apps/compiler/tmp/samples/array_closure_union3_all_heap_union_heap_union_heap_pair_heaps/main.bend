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
def spiral_array_depth_go(+wanted: U32, +size: U32, +depth: U32, done: Bool) -> U32:
  match done:
    case True{}:
      depth
    case False{}:
      spiral_array_depth_go(wanted, U32.shl(size), U32.add(depth, 1), U32.is_le(wanted, U32.shl(size)))

@unsafe
def spiral_array_depth(+wanted: U32) -> U32:
  spiral_array_depth_go(wanted, 1, 0, U32.is_le(wanted, 1))
type U0 is Type:
  U0_None{}
  U0_Held{f0: (((U32 & String) & (U32 & String)) & U32)}

type U1 is Type:
  U1_Absent{}
  U1_Box{f0: (U0)}
  U1_Mark{f0: U32}

@unsafe
def spiral_main_if1(+c: Bool, +v8: (((U32 & String) & (U32 & String)) & U32)) -> IO(U0):
  match c:
    case True{}:
      do IO<U0>:
        IO.pure(U0, U0_Held{v8})
    case False{}:
      do IO<U0>:
        IO.pure(U0, U0_None{})

@unsafe
def spiral_main_if2(+c: Bool, +v13: (U0)) -> IO(U1):
  match c:
    case True{}:
      do IO<U1>:
        IO.pure(U1, U1_Box{v13})
    case False{}:
      do IO<U1>:
        IO.pure(U1, U1_Mark{{1 : U32}})

@unsafe
def f_c0_if3_if4(+c: Bool, +v0: U1, +v1: U32) -> IO(U1):
  match c:
    case True{}:
      do IO<U1>:
        return v0
    case False{}:
      do IO<U1>:
        IO.pure(U1, U1_Mark{v1})

@unsafe
def f_c0_if3(+c: Bool, +v0: U1, +v1: U32, +v2: U32) -> IO(U1):
  match c:
    case True{}:
      do IO<U1>:
        IO.pure(U1, U1_Absent{})
    case False{}:
      do IO<U1>:
        +v5 : Bool <- IO.pure(Bool, U32.is_eq(v2, {1 : U32}))
        f_c0_if3_if4(v5, v0, v1)

@unsafe
def f_c0(+v0: U1, +v1: U32, +v2: U32) -> IO(U1):
  do IO<U1>:
    +v3 : Bool <- IO.pure(Bool, U32.is_eq(v2, {0 : U32}))
    f_c0_if3(v3, v0, v1, v2)

@unsafe
def spiral_array_fill_go_a0(+depth: U32, +v: U1, leaf: Bool) -> Array<U1>:
  match leaf:
    case True{}:
      ALeaf{v}
    case False{}:
      ANode{spiral_array_fill_a0(U32.sub(depth, 1), v), spiral_array_fill_a0(U32.sub(depth, 1), v)}

@unsafe
def spiral_array_fill_a0(+depth: U32, +v: U1) -> Array<U1>:
  spiral_array_fill_go_a0(depth, v, U32.is_eq(depth, 0))

@unsafe
def spiral_array_peek_lo_a0(ys: Array<U1>, r: Array<U1> & U1) -> Array<U1> & U1:
  (nxs, v) = r
  (ANode{nxs, ys}, v)

@unsafe
def spiral_array_peek_hi_a0(xs: Array<U1>, r: Array<U1> & U1) -> Array<U1> & U1:
  (nys, v) = r
  (ANode{xs, nys}, v)

@unsafe
def spiral_array_peek_go_a0(a: Array<U1>, +n: U32, +i: U32, z: Bool) -> Array<U1> & U1:
  match a z:
    case ALeaf{+x} _:
      (ALeaf{x}, x)
    case ANode{xs, ys} True{}:
      +h = U32.shr(n)
      spiral_array_peek_lo_a0(ys, spiral_array_peek_go_a0(xs, h, i, U32.is_lt(i, U32.shr(h))))
    case ANode{xs, ys} False{}:
      +h = U32.shr(n)
      +j = U32.sub(i, h)
      spiral_array_peek_hi_a0(xs, spiral_array_peek_go_a0(ys, h, j, U32.is_lt(j, U32.shr(h))))

@unsafe
def spiral_array_peek_at_a0(+i: U32, an: Array<U1> & U32) -> Array<U1> & U1:
  (a, +n) = an
  spiral_array_peek_go_a0(a, n, i, U32.is_lt(i, U32.shr(n)))

@unsafe
def spiral_array_new_a0(+length: U32, +v: U1) -> IO(Chan(Array<U1>) & U32):
  do IO<Chan(Array<U1>) & U32>:
    +c : Chan(Array<U1>) <- Chan.new(Array<U1>, 1)
    _ : Result<&1, &1, Array<U1>, Unit> <- Chan.send(Array<U1>, c, spiral_array_fill_a0(spiral_array_depth(length), v))
    return (c, length)

@unsafe
def spiral_array_length_a0(+arr: Chan(Array<U1>) & U32) -> U32:
  (c, +n) = arr
  n

@unsafe
def spiral_array_get_back_a0(+c: Chan(Array<U1>), r: Array<U1> & U1) -> IO(U1):
  (a, +v) = r
  do IO<U1>:
    _ : Result<&1, &1, Array<U1>, Unit> <- Chan.send(Array<U1>, c, a)
    return v

@unsafe
def spiral_array_get_taken_a0(+c: Chan(Array<U1>), +i: U32, m: Maybe<&1, Array<U1>>) -> IO(U1):
  match m:
    case None{}:
      IO.die(U1, 3, "")
    case Some{a}:
      spiral_array_get_back_a0(c, spiral_array_peek_at_a0(i, Array.size(U1, a)))

@unsafe
def spiral_array_get_checked_a0(+c: Chan(Array<U1>), +i: U32, inside: Bool) -> IO(U1):
  match inside:
    case True{}:
      do IO<U1>:
        m : Maybe<&1, Array<U1>> <- Chan.recv(Array<U1>, c)
        spiral_array_get_taken_a0(c, i, m)
    case False{}:
      IO.die(U1, 3, "")

@unsafe
def spiral_array_get_a0(+arr: Chan(Array<U1>) & U32, +i: U32) -> IO(U1):
  (+c, +n) = arr
  spiral_array_get_checked_a0(c, i, U32.is_lt(i, n))

@unsafe
def spiral_array_set_back_a0(+c: Chan(Array<U1>), r: Array<U1> & U1) -> IO(Unit):
  (a, old) = r
  do IO<Unit>:
    _ : Result<&1, &1, Array<U1>, Unit> <- Chan.send(Array<U1>, c, a)
    return Unit{}

@unsafe
def spiral_array_set_taken_a0(+c: Chan(Array<U1>), +i: U32, +v: U1, m: Maybe<&1, Array<U1>>) -> IO(Unit):
  match m:
    case None{}:
      IO.die(Unit, 3, "")
    case Some{a}:
      spiral_array_set_back_a0(c, Array.swap(U1, a, i, v))

@unsafe
def spiral_array_set_checked_a0(+c: Chan(Array<U1>), +i: U32, +v: U1, inside: Bool) -> IO(Unit):
  match inside:
    case True{}:
      do IO<Unit>:
        m : Maybe<&1, Array<U1>> <- Chan.recv(Array<U1>, c)
        spiral_array_set_taken_a0(c, i, v, m)
    case False{}:
      IO.die(Unit, 3, "")

@unsafe
def spiral_array_set_a0(+arr: Chan(Array<U1>) & U32, +i: U32, +v: U1) -> IO(Unit):
  (+c, +n) = arr
  spiral_array_set_checked_a0(c, i, v, U32.is_lt(i, n))

@unsafe
def score_0_unbox5_field6(+p: U0) -> IO(U0):
  IO.pure(U0, p)

@unsafe
def score_0_unbox5_unbox7_field8(+p: ((U32 & String) & (U32 & String)) & U32) -> IO(((U32 & String) & (U32 & String)) & U32):
  (+w0, +w1) = p
  IO.pure(((U32 & String) & (U32 & String)) & U32, (w0, w1))

@unsafe
def score_0_unbox5_unbox7_k9_field10(+p: (U32 & String) & (U32 & String)) -> IO((U32 & String) & (U32 & String)):
  (+w0, +w1) = p
  IO.pure((U32 & String) & (U32 & String), (w0, w1))

@unsafe
def score_0_unbox5_unbox7_k9_k11_field12(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def score_0_unbox5_unbox7_k9_k11_k13_field14(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def score_0_unbox5_unbox7_k9_k11_k13_k15_if16(+c: Bool, +v11: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v15 : Bool <- IO.pure(Bool, String.eq(v11, "hi"))
        return v15
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox5_unbox7_k9_k11_k13_k15_if17(+c: Bool, +v12: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v17 : Bool <- IO.pure(Bool, U32.is_eq(v12, {4 : U32}))
        return v17
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox5_unbox7_k9_k11_k13_k15_if18(+c: Bool, +v13: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v19 : Bool <- IO.pure(Bool, String.eq(v13, "yo"))
        return v19
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox5_unbox7_k9_k11_k13_k15_if19(+c: Bool, +v7: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v21 : Bool <- IO.pure(Bool, U32.is_eq(v7, {2 : U32}))
        return v21
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox5_unbox7_k9_k11_k13_k15_if20(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def score_0_unbox5_unbox7_k9_k11_k13_k15(+p: U32 & String, +v0: U1, +v3: (U0), +v4: U0, +v5: (((U32 & String) & (U32 & String)) & U32), +v6: ((U32 & String) & (U32 & String)), +v7: U32, +v8: (U32 & String), +v9: (U32 & String), +v10: U32, +v11: String) -> IO(U32):
  (+v12, +v13) = p
  do IO<U32>:
    +v14 : Bool <- IO.pure(Bool, U32.is_eq(v10, {7 : U32}))
    +v16 : Bool <- score_0_unbox5_unbox7_k9_k11_k13_k15_if16(v14, v11)
    +v18 : Bool <- score_0_unbox5_unbox7_k9_k11_k13_k15_if17(v16, v12)
    +v20 : Bool <- score_0_unbox5_unbox7_k9_k11_k13_k15_if18(v18, v13)
    +v22 : Bool <- score_0_unbox5_unbox7_k9_k11_k13_k15_if19(v20, v7)
    score_0_unbox5_unbox7_k9_k11_k13_k15_if20(v22)

@unsafe
def score_0_unbox5_unbox7_k9_k11_k13(+p: U32 & String, +v0: U1, +v3: (U0), +v4: U0, +v5: (((U32 & String) & (U32 & String)) & U32), +v6: ((U32 & String) & (U32 & String)), +v7: U32, +v8: (U32 & String), +v9: (U32 & String)) -> IO(U32):
  (+v10, +v11) = p
  do IO<U32>:
    +p : U32 & String <- score_0_unbox5_unbox7_k9_k11_k13_field14(v9)
    score_0_unbox5_unbox7_k9_k11_k13_k15(p, v0, v3, v4, v5, v6, v7, v8, v9, v10, v11)

@unsafe
def score_0_unbox5_unbox7_k9_k11(+p: (U32 & String) & (U32 & String), +v0: U1, +v3: (U0), +v4: U0, +v5: (((U32 & String) & (U32 & String)) & U32), +v6: ((U32 & String) & (U32 & String)), +v7: U32) -> IO(U32):
  (+v8, +v9) = p
  do IO<U32>:
    +p : U32 & String <- score_0_unbox5_unbox7_k9_k11_field12(v8)
    score_0_unbox5_unbox7_k9_k11_k13(p, v0, v3, v4, v5, v6, v7, v8, v9)

@unsafe
def score_0_unbox5_unbox7_k9(+p: ((U32 & String) & (U32 & String)) & U32, +v0: U1, +v3: (U0), +v4: U0, +v5: (((U32 & String) & (U32 & String)) & U32)) -> IO(U32):
  (+v6, +v7) = p
  do IO<U32>:
    +p : (U32 & String) & (U32 & String) <- score_0_unbox5_unbox7_k9_field10(v6)
    score_0_unbox5_unbox7_k9_k11(p, v0, v3, v4, v5, v6, v7)

@unsafe
def score_0_unbox5_unbox7(+u: U0, +v0: U1, +v3: (U0), +v4: U0) -> IO(U32):
  match u:
    case U0_None{}:
      do IO<U32>:
        return {1 : U32}
    case U0_Held{+v5}:
      do IO<U32>:
        +p : ((U32 & String) & (U32 & String)) & U32 <- score_0_unbox5_unbox7_field8(v5)
        score_0_unbox5_unbox7_k9(p, v0, v3, v4, v5)

@unsafe
def score_0_unbox5(+u: U1, +v0: U1) -> IO(U32):
  match u:
    case U1_Absent{}:
      do IO<U32>:
        return {1 : U32}
    case U1_Box{+v3}:
      do IO<U32>:
        +v4 : U0 <- score_0_unbox5_field6(v3)
        score_0_unbox5_unbox7(v4, v0, v3, v4)
    case U1_Mark{+v1}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def score_0(+v0: U1) -> IO(U32):
  do IO<U32>:
    score_0_unbox5(v0, v0)

@unsafe
def spiral_main_if21(+c: Bool, +v27: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v31 : Bool <- IO.pure(Bool, U32.is_eq(v27, {1 : U32}))
        return v31
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if22(+c: Bool, +v29: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v33 : Bool <- IO.pure(Bool, U32.is_eq(v29, {1 : U32}))
        return v33
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if23(+c: Bool) -> IO(U32):
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
    +v1 : String <- IO.pure(String, "hi")
    +v2 : (U32 & String) <- IO.pure((U32 & String), (v0, v1))
    +v3 : U32 <- IO.pure(U32, {4 : U32})
    +v4 : String <- IO.pure(String, "yo")
    +v5 : (U32 & String) <- IO.pure((U32 & String), (v3, v4))
    +v6 : ((U32 & String) & (U32 & String)) <- IO.pure(((U32 & String) & (U32 & String)), (v2, v5))
    +v7 : U32 <- IO.pure(U32, {2 : U32})
    +v8 : (((U32 & String) & (U32 & String)) & U32) <- IO.pure((((U32 & String) & (U32 & String)) & U32), (v6, v7))
    +v9 : Bool <- IO.pure(Bool, True{})
    +v12 : U0 <- spiral_main_if1(v9, v8)
    +v13 : (U0) <- IO.pure((U0), v12)
    +v14 : Bool <- IO.pure(Bool, True{})
    +v17 : U1 <- spiral_main_if2(v14, v13)
    +v18 : U32 <- IO.pure(U32, {3 : U32})
    +v19 : ((U32) -> IO(U1)) <- IO.pure(((U32) -> IO(U1)), d => f_c0(v17, v18, d))
    +v20 : (Chan(Array<U1>) & U32) <- spiral_array_new_a0({3 : U32}, U1_Absent{})
    +v21 : U1 <- v19({1 : U32})
    spiral_array_set_a0(v20, {0 : U32}, v21)
    +v22 : U1 <- v19({2 : U32})
    spiral_array_set_a0(v20, {1 : U32}, v22)
    +v23 : U1 <- v19({0 : U32})
    spiral_array_set_a0(v20, {2 : U32}, v23)
    +v24 : U1 <- spiral_array_get_a0(v20, {0 : U32})
    +v25 : U32 <- score_0(v24)
    +v26 : U1 <- spiral_array_get_a0(v20, {1 : U32})
    +v27 : U32 <- score_0(v26)
    +v28 : U1 <- spiral_array_get_a0(v20, {2 : U32})
    +v29 : U32 <- score_0(v28)
    +v30 : Bool <- IO.pure(Bool, U32.is_eq(v25, {0 : U32}))
    +v32 : Bool <- spiral_main_if21(v30, v27)
    +v34 : Bool <- spiral_main_if22(v32, v29)
    spiral_main_if23(v34)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
