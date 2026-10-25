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

@unsafe
def spiral_array_fill_go_a0(+depth: U32, +v: (U1), leaf: Bool) -> Array<(U1)>:
  match leaf:
    case True{}:
      ALeaf{v}
    case False{}:
      ANode{spiral_array_fill_a0(U32.sub(depth, 1), v), spiral_array_fill_a0(U32.sub(depth, 1), v)}

@unsafe
def spiral_array_fill_a0(+depth: U32, +v: (U1)) -> Array<(U1)>:
  spiral_array_fill_go_a0(depth, v, U32.is_eq(depth, 0))

@unsafe
def spiral_array_peek_lo_a0(ys: Array<(U1)>, r: Array<(U1)> & (U1)) -> Array<(U1)> & (U1):
  (nxs, v) = r
  (ANode{nxs, ys}, v)

@unsafe
def spiral_array_peek_hi_a0(xs: Array<(U1)>, r: Array<(U1)> & (U1)) -> Array<(U1)> & (U1):
  (nys, v) = r
  (ANode{xs, nys}, v)

@unsafe
def spiral_array_peek_go_a0(a: Array<(U1)>, +n: U32, +i: U32, z: Bool) -> Array<(U1)> & (U1):
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
def spiral_array_peek_at_a0(+i: U32, an: Array<(U1)> & U32) -> Array<(U1)> & (U1):
  (a, +n) = an
  spiral_array_peek_go_a0(a, n, i, U32.is_lt(i, U32.shr(n)))

@unsafe
def spiral_array_new_a0(+length: U32, +v: (U1)) -> IO(Chan(Array<(U1)>) & U32):
  do IO<Chan(Array<(U1)>) & U32>:
    +c : Chan(Array<(U1)>) <- Chan.new(Array<(U1)>, 1)
    _ : Result<&1, &1, Array<(U1)>, Unit> <- Chan.send(Array<(U1)>, c, spiral_array_fill_a0(spiral_array_depth(length), v))
    return (c, length)

@unsafe
def spiral_array_length_a0(+arr: Chan(Array<(U1)>) & U32) -> U32:
  (c, +n) = arr
  n

@unsafe
def spiral_array_get_back_a0(+c: Chan(Array<(U1)>), r: Array<(U1)> & (U1)) -> IO((U1)):
  (a, +v) = r
  do IO<(U1)>:
    _ : Result<&1, &1, Array<(U1)>, Unit> <- Chan.send(Array<(U1)>, c, a)
    return v

@unsafe
def spiral_array_get_taken_a0(+c: Chan(Array<(U1)>), +i: U32, m: Maybe<&1, Array<(U1)>>) -> IO((U1)):
  match m:
    case None{}:
      IO.die((U1), 3, "")
    case Some{a}:
      spiral_array_get_back_a0(c, spiral_array_peek_at_a0(i, Array.size((U1), a)))

@unsafe
def spiral_array_get_checked_a0(+c: Chan(Array<(U1)>), +i: U32, inside: Bool) -> IO((U1)):
  match inside:
    case True{}:
      do IO<(U1)>:
        m : Maybe<&1, Array<(U1)>> <- Chan.recv(Array<(U1)>, c)
        spiral_array_get_taken_a0(c, i, m)
    case False{}:
      IO.die((U1), 3, "")

@unsafe
def spiral_array_get_a0(+arr: Chan(Array<(U1)>) & U32, +i: U32) -> IO((U1)):
  (+c, +n) = arr
  spiral_array_get_checked_a0(c, i, U32.is_lt(i, n))

@unsafe
def spiral_array_set_back_a0(+c: Chan(Array<(U1)>), r: Array<(U1)> & (U1)) -> IO(Unit):
  (a, old) = r
  do IO<Unit>:
    _ : Result<&1, &1, Array<(U1)>, Unit> <- Chan.send(Array<(U1)>, c, a)
    return Unit{}

@unsafe
def spiral_array_set_taken_a0(+c: Chan(Array<(U1)>), +i: U32, +v: (U1), m: Maybe<&1, Array<(U1)>>) -> IO(Unit):
  match m:
    case None{}:
      IO.die(Unit, 3, "")
    case Some{a}:
      spiral_array_set_back_a0(c, Array.swap((U1), a, i, v))

@unsafe
def spiral_array_set_checked_a0(+c: Chan(Array<(U1)>), +i: U32, +v: (U1), inside: Bool) -> IO(Unit):
  match inside:
    case True{}:
      do IO<Unit>:
        m : Maybe<&1, Array<(U1)>> <- Chan.recv(Array<(U1)>, c)
        spiral_array_set_taken_a0(c, i, v, m)
    case False{}:
      IO.die(Unit, 3, "")

@unsafe
def spiral_array_set_a0(+arr: Chan(Array<(U1)>) & U32, +i: U32, +v: (U1)) -> IO(Unit):
  (+c, +n) = arr
  spiral_array_set_checked_a0(c, i, v, U32.is_lt(i, n))

@unsafe
def spiral_main_field1(+p: U1) -> IO(U1):
  IO.pure(U1, p)

@unsafe
def spiral_main_field2(+p: U1) -> IO(U1):
  IO.pure(U1, p)

@unsafe
def score_0_unbox3_field4(+p: U0) -> IO(U0):
  IO.pure(U0, p)

@unsafe
def score_0_unbox3_unbox5_field6(+p: ((U32 & String) & (U32 & String)) & U32) -> IO(((U32 & String) & (U32 & String)) & U32):
  (+w0, +w1) = p
  IO.pure(((U32 & String) & (U32 & String)) & U32, (w0, w1))

@unsafe
def score_0_unbox3_unbox5_k7_field8(+p: (U32 & String) & (U32 & String)) -> IO((U32 & String) & (U32 & String)):
  (+w0, +w1) = p
  IO.pure((U32 & String) & (U32 & String), (w0, w1))

@unsafe
def score_0_unbox3_unbox5_k7_k9_field10(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def score_0_unbox3_unbox5_k7_k9_k11_field12(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def score_0_unbox3_unbox5_k7_k9_k11_k13_if14(+c: Bool, +v9: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v13 : Bool <- IO.pure(Bool, String.eq(v9, "hi"))
        return v13
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox3_unbox5_k7_k9_k11_k13_if15(+c: Bool, +v10: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v15 : Bool <- IO.pure(Bool, U32.is_eq(v10, {4 : U32}))
        return v15
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox3_unbox5_k7_k9_k11_k13_if16(+c: Bool, +v11: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v17 : Bool <- IO.pure(Bool, String.eq(v11, "yo"))
        return v17
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox3_unbox5_k7_k9_k11_k13_if17(+c: Bool, +v5: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v19 : Bool <- IO.pure(Bool, U32.is_eq(v5, {2 : U32}))
        return v19
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox3_unbox5_k7_k9_k11_k13_if18(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def score_0_unbox3_unbox5_k7_k9_k11_k13(+p: U32 & String, +v0: U1, +v1: (U0), +v2: U0, +v3: (((U32 & String) & (U32 & String)) & U32), +v4: ((U32 & String) & (U32 & String)), +v5: U32, +v6: (U32 & String), +v7: (U32 & String), +v8: U32, +v9: String) -> IO(U32):
  (+v10, +v11) = p
  do IO<U32>:
    +v12 : Bool <- IO.pure(Bool, U32.is_eq(v8, {7 : U32}))
    +v14 : Bool <- score_0_unbox3_unbox5_k7_k9_k11_k13_if14(v12, v9)
    +v16 : Bool <- score_0_unbox3_unbox5_k7_k9_k11_k13_if15(v14, v10)
    +v18 : Bool <- score_0_unbox3_unbox5_k7_k9_k11_k13_if16(v16, v11)
    +v20 : Bool <- score_0_unbox3_unbox5_k7_k9_k11_k13_if17(v18, v5)
    score_0_unbox3_unbox5_k7_k9_k11_k13_if18(v20)

@unsafe
def score_0_unbox3_unbox5_k7_k9_k11(+p: U32 & String, +v0: U1, +v1: (U0), +v2: U0, +v3: (((U32 & String) & (U32 & String)) & U32), +v4: ((U32 & String) & (U32 & String)), +v5: U32, +v6: (U32 & String), +v7: (U32 & String)) -> IO(U32):
  (+v8, +v9) = p
  do IO<U32>:
    +p : U32 & String <- score_0_unbox3_unbox5_k7_k9_k11_field12(v7)
    score_0_unbox3_unbox5_k7_k9_k11_k13(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)

@unsafe
def score_0_unbox3_unbox5_k7_k9(+p: (U32 & String) & (U32 & String), +v0: U1, +v1: (U0), +v2: U0, +v3: (((U32 & String) & (U32 & String)) & U32), +v4: ((U32 & String) & (U32 & String)), +v5: U32) -> IO(U32):
  (+v6, +v7) = p
  do IO<U32>:
    +p : U32 & String <- score_0_unbox3_unbox5_k7_k9_field10(v6)
    score_0_unbox3_unbox5_k7_k9_k11(p, v0, v1, v2, v3, v4, v5, v6, v7)

@unsafe
def score_0_unbox3_unbox5_k7(+p: ((U32 & String) & (U32 & String)) & U32, +v0: U1, +v1: (U0), +v2: U0, +v3: (((U32 & String) & (U32 & String)) & U32)) -> IO(U32):
  (+v4, +v5) = p
  do IO<U32>:
    +p : (U32 & String) & (U32 & String) <- score_0_unbox3_unbox5_k7_field8(v4)
    score_0_unbox3_unbox5_k7_k9(p, v0, v1, v2, v3, v4, v5)

@unsafe
def score_0_unbox3_unbox5(+u: U0, +v0: U1, +v1: (U0), +v2: U0) -> IO(U32):
  match u:
    case U0_None{}:
      do IO<U32>:
        return {1 : U32}
    case U0_Held{+v3}:
      do IO<U32>:
        +p : ((U32 & String) & (U32 & String)) & U32 <- score_0_unbox3_unbox5_field6(v3)
        score_0_unbox3_unbox5_k7(p, v0, v1, v2, v3)

@unsafe
def score_0_unbox3(+u: U1, +v0: U1) -> IO(U32):
  match u:
    case U1_Absent{}:
      do IO<U32>:
        return {1 : U32}
    case U1_Box{+v1}:
      do IO<U32>:
        +v2 : U0 <- score_0_unbox3_field4(v1)
        score_0_unbox3_unbox5(v2, v0, v1, v2)

@unsafe
def score_0(+v0: U1) -> IO(U32):
  do IO<U32>:
    score_0_unbox3(v0, v0)

@unsafe
def score_b_1_unbox19_field20(+p: U0) -> IO(U0):
  IO.pure(U0, p)

@unsafe
def score_b_1_unbox19_unbox21_field22(+p: ((U32 & String) & (U32 & String)) & U32) -> IO(((U32 & String) & (U32 & String)) & U32):
  (+w0, +w1) = p
  IO.pure(((U32 & String) & (U32 & String)) & U32, (w0, w1))

@unsafe
def score_b_1_unbox19_unbox21_k23_field24(+p: (U32 & String) & (U32 & String)) -> IO((U32 & String) & (U32 & String)):
  (+w0, +w1) = p
  IO.pure((U32 & String) & (U32 & String), (w0, w1))

@unsafe
def score_b_1_unbox19_unbox21_k23_k25_field26(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def score_b_1_unbox19_unbox21_k23_k25_k27_field28(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def score_b_1_unbox19_unbox21_k23_k25_k27_k29_if30(+c: Bool, +v9: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v13 : Bool <- IO.pure(Bool, String.eq(v9, "ok"))
        return v13
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_b_1_unbox19_unbox21_k23_k25_k27_k29_if31(+c: Bool, +v10: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v15 : Bool <- IO.pure(Bool, U32.is_eq(v10, {5 : U32}))
        return v15
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_b_1_unbox19_unbox21_k23_k25_k27_k29_if32(+c: Bool, +v11: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v17 : Bool <- IO.pure(Bool, String.eq(v11, "no"))
        return v17
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_b_1_unbox19_unbox21_k23_k25_k27_k29_if33(+c: Bool, +v5: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v19 : Bool <- IO.pure(Bool, U32.is_eq(v5, {9 : U32}))
        return v19
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_b_1_unbox19_unbox21_k23_k25_k27_k29_if34(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def score_b_1_unbox19_unbox21_k23_k25_k27_k29(+p: U32 & String, +v0: U1, +v1: (U0), +v2: U0, +v3: (((U32 & String) & (U32 & String)) & U32), +v4: ((U32 & String) & (U32 & String)), +v5: U32, +v6: (U32 & String), +v7: (U32 & String), +v8: U32, +v9: String) -> IO(U32):
  (+v10, +v11) = p
  do IO<U32>:
    +v12 : Bool <- IO.pure(Bool, U32.is_eq(v8, {8 : U32}))
    +v14 : Bool <- score_b_1_unbox19_unbox21_k23_k25_k27_k29_if30(v12, v9)
    +v16 : Bool <- score_b_1_unbox19_unbox21_k23_k25_k27_k29_if31(v14, v10)
    +v18 : Bool <- score_b_1_unbox19_unbox21_k23_k25_k27_k29_if32(v16, v11)
    +v20 : Bool <- score_b_1_unbox19_unbox21_k23_k25_k27_k29_if33(v18, v5)
    score_b_1_unbox19_unbox21_k23_k25_k27_k29_if34(v20)

@unsafe
def score_b_1_unbox19_unbox21_k23_k25_k27(+p: U32 & String, +v0: U1, +v1: (U0), +v2: U0, +v3: (((U32 & String) & (U32 & String)) & U32), +v4: ((U32 & String) & (U32 & String)), +v5: U32, +v6: (U32 & String), +v7: (U32 & String)) -> IO(U32):
  (+v8, +v9) = p
  do IO<U32>:
    +p : U32 & String <- score_b_1_unbox19_unbox21_k23_k25_k27_field28(v7)
    score_b_1_unbox19_unbox21_k23_k25_k27_k29(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)

@unsafe
def score_b_1_unbox19_unbox21_k23_k25(+p: (U32 & String) & (U32 & String), +v0: U1, +v1: (U0), +v2: U0, +v3: (((U32 & String) & (U32 & String)) & U32), +v4: ((U32 & String) & (U32 & String)), +v5: U32) -> IO(U32):
  (+v6, +v7) = p
  do IO<U32>:
    +p : U32 & String <- score_b_1_unbox19_unbox21_k23_k25_field26(v6)
    score_b_1_unbox19_unbox21_k23_k25_k27(p, v0, v1, v2, v3, v4, v5, v6, v7)

@unsafe
def score_b_1_unbox19_unbox21_k23(+p: ((U32 & String) & (U32 & String)) & U32, +v0: U1, +v1: (U0), +v2: U0, +v3: (((U32 & String) & (U32 & String)) & U32)) -> IO(U32):
  (+v4, +v5) = p
  do IO<U32>:
    +p : (U32 & String) & (U32 & String) <- score_b_1_unbox19_unbox21_k23_field24(v4)
    score_b_1_unbox19_unbox21_k23_k25(p, v0, v1, v2, v3, v4, v5)

@unsafe
def score_b_1_unbox19_unbox21(+u: U0, +v0: U1, +v1: (U0), +v2: U0) -> IO(U32):
  match u:
    case U0_None{}:
      do IO<U32>:
        return {1 : U32}
    case U0_Held{+v3}:
      do IO<U32>:
        +p : ((U32 & String) & (U32 & String)) & U32 <- score_b_1_unbox19_unbox21_field22(v3)
        score_b_1_unbox19_unbox21_k23(p, v0, v1, v2, v3)

@unsafe
def score_b_1_unbox19(+u: U1, +v0: U1) -> IO(U32):
  match u:
    case U1_Absent{}:
      do IO<U32>:
        return {1 : U32}
    case U1_Box{+v1}:
      do IO<U32>:
        +v2 : U0 <- score_b_1_unbox19_field20(v1)
        score_b_1_unbox19_unbox21(v2, v0, v1, v2)

@unsafe
def score_b_1(+v0: U1) -> IO(U32):
  do IO<U32>:
    score_b_1_unbox19(v0, v0)

@unsafe
def spiral_main_if35(+c: Bool, +v32: U32) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v34 : Bool <- IO.pure(Bool, U32.is_eq(v32, {0 : U32}))
        return v34
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if36(+c: Bool) -> IO(U32):
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
    +v9 : U0 <- IO.pure(U0, U0_Held{v8})
    +v10 : (U0) <- IO.pure((U0), v9)
    +v11 : U1 <- IO.pure(U1, U1_Box{v10})
    +v12 : (U1) <- IO.pure((U1), v11)
    +v13 : U32 <- IO.pure(U32, {8 : U32})
    +v14 : String <- IO.pure(String, "ok")
    +v15 : (U32 & String) <- IO.pure((U32 & String), (v13, v14))
    +v16 : U32 <- IO.pure(U32, {5 : U32})
    +v17 : String <- IO.pure(String, "no")
    +v18 : (U32 & String) <- IO.pure((U32 & String), (v16, v17))
    +v19 : ((U32 & String) & (U32 & String)) <- IO.pure(((U32 & String) & (U32 & String)), (v15, v18))
    +v20 : U32 <- IO.pure(U32, {9 : U32})
    +v21 : (((U32 & String) & (U32 & String)) & U32) <- IO.pure((((U32 & String) & (U32 & String)) & U32), (v19, v20))
    +v22 : U0 <- IO.pure(U0, U0_Held{v21})
    +v23 : (U0) <- IO.pure((U0), v22)
    +v24 : U1 <- IO.pure(U1, U1_Box{v23})
    +v25 : (U1) <- IO.pure((U1), v24)
    +v26 : (Chan(Array<(U1)>) & U32) <- spiral_array_new_a0({2 : U32}, U1_Absent{})
    spiral_array_set_a0(v26, {0 : U32}, v12)
    spiral_array_set_a0(v26, {1 : U32}, v25)
    +v27 : (U1) <- spiral_array_get_a0(v26, {0 : U32})
    +v28 : (U1) <- spiral_array_get_a0(v26, {1 : U32})
    +v29 : U1 <- spiral_main_field1(v27)
    +v30 : U1 <- spiral_main_field2(v28)
    +v31 : U32 <- score_0(v29)
    +v32 : U32 <- score_b_1(v30)
    +v33 : Bool <- IO.pure(Bool, U32.is_eq(v31, {0 : U32}))
    +v35 : Bool <- spiral_main_if35(v33, v32)
    spiral_main_if36(v35)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
