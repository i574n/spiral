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
type U0 is Data:
  U0_None{}
  U0_Both{f0: String, f1: String}

@unsafe
def spiral_array_fill_go_a0(+depth: U32, +v: U0, leaf: Bool) -> Array<U0>:
  match leaf:
    case True{}:
      ALeaf{v}
    case False{}:
      ANode{spiral_array_fill_a0(U32.sub(depth, 1), v), spiral_array_fill_a0(U32.sub(depth, 1), v)}

@unsafe
def spiral_array_fill_a0(+depth: U32, +v: U0) -> Array<U0>:
  spiral_array_fill_go_a0(depth, v, U32.is_eq(depth, 0))

@unsafe
def spiral_array_peek_lo_a0(ys: Array<U0>, r: Array<U0> & U0) -> Array<U0> & U0:
  (nxs, v) = r
  (ANode{nxs, ys}, v)

@unsafe
def spiral_array_peek_hi_a0(xs: Array<U0>, r: Array<U0> & U0) -> Array<U0> & U0:
  (nys, v) = r
  (ANode{xs, nys}, v)

@unsafe
def spiral_array_peek_go_a0(a: Array<U0>, +n: U32, +i: U32, z: Bool) -> Array<U0> & U0:
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
def spiral_array_peek_at_a0(+i: U32, an: Array<U0> & U32) -> Array<U0> & U0:
  (a, +n) = an
  spiral_array_peek_go_a0(a, n, i, U32.is_lt(i, U32.shr(n)))

@unsafe
def spiral_array_new_a0(+length: U32, +v: U0) -> IO(Chan(Array<U0>) & U32):
  do IO<Chan(Array<U0>) & U32>:
    +c : Chan(Array<U0>) <- Chan.new(Array<U0>, 1)
    _ : Result<&1, &1, Array<U0>, Unit> <- Chan.send(Array<U0>, c, spiral_array_fill_a0(spiral_array_depth(length), v))
    return (c, length)

@unsafe
def spiral_array_length_a0(+arr: Chan(Array<U0>) & U32) -> U32:
  (c, +n) = arr
  n

@unsafe
def spiral_array_get_back_a0(+c: Chan(Array<U0>), r: Array<U0> & U0) -> IO(U0):
  (a, +v) = r
  do IO<U0>:
    _ : Result<&1, &1, Array<U0>, Unit> <- Chan.send(Array<U0>, c, a)
    return v

@unsafe
def spiral_array_get_taken_a0(+c: Chan(Array<U0>), +i: U32, m: Maybe<&1, Array<U0>>) -> IO(U0):
  match m:
    case None{}:
      IO.die(U0, 3, "")
    case Some{a}:
      spiral_array_get_back_a0(c, spiral_array_peek_at_a0(i, Array.size(U0, a)))

@unsafe
def spiral_array_get_checked_a0(+c: Chan(Array<U0>), +i: U32, inside: Bool) -> IO(U0):
  match inside:
    case True{}:
      do IO<U0>:
        m : Maybe<&1, Array<U0>> <- Chan.recv(Array<U0>, c)
        spiral_array_get_taken_a0(c, i, m)
    case False{}:
      IO.die(U0, 3, "")

@unsafe
def spiral_array_get_a0(+arr: Chan(Array<U0>) & U32, +i: U32) -> IO(U0):
  (+c, +n) = arr
  spiral_array_get_checked_a0(c, i, U32.is_lt(i, n))

@unsafe
def spiral_array_set_back_a0(+c: Chan(Array<U0>), r: Array<U0> & U0) -> IO(Unit):
  (a, old) = r
  do IO<Unit>:
    _ : Result<&1, &1, Array<U0>, Unit> <- Chan.send(Array<U0>, c, a)
    return Unit{}

@unsafe
def spiral_array_set_taken_a0(+c: Chan(Array<U0>), +i: U32, +v: U0, m: Maybe<&1, Array<U0>>) -> IO(Unit):
  match m:
    case None{}:
      IO.die(Unit, 3, "")
    case Some{a}:
      spiral_array_set_back_a0(c, Array.swap(U0, a, i, v))

@unsafe
def spiral_array_set_checked_a0(+c: Chan(Array<U0>), +i: U32, +v: U0, inside: Bool) -> IO(Unit):
  match inside:
    case True{}:
      do IO<Unit>:
        m : Maybe<&1, Array<U0>> <- Chan.recv(Array<U0>, c)
        spiral_array_set_taken_a0(c, i, v, m)
    case False{}:
      IO.die(Unit, 3, "")

@unsafe
def spiral_array_set_a0(+arr: Chan(Array<U0>) & U32, +i: U32, +v: U0) -> IO(Unit):
  (+c, +n) = arr
  spiral_array_set_checked_a0(c, i, v, U32.is_lt(i, n))

@unsafe
def spiral_main_if1(+c: Bool, +v1: String, +v2: String) -> IO(U0):
  match c:
    case True{}:
      do IO<U0>:
        IO.pure(U0, U0_Both{v1, v2})
    case False{}:
      do IO<U0>:
        IO.pure(U0, U0_None{})

@unsafe
def score_0_unbox2_if3(+c: Bool, +v2: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v4 : Bool <- IO.pure(Bool, String.eq(v2, "yo"))
        return v4
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def score_0_unbox2_if4(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def score_0_unbox2(+u: U0, +v0: U0) -> IO(U32):
  match u:
    case U0_None{}:
      do IO<U32>:
        return {1 : U32}
    case U0_Both{+v1, +v2}:
      do IO<U32>:
        +v3 : Bool <- IO.pure(Bool, String.eq(v1, "hi"))
        +v5 : Bool <- score_0_unbox2_if3(v3, v2)
        score_0_unbox2_if4(v5)

@unsafe
def score_0(+v0: U0) -> IO(U32):
  do IO<U32>:
    score_0_unbox2(v0, v0)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : (Chan(Array<U0>) & U32) <- spiral_array_new_a0({1 : U32}, U0_None{})
    +v1 : String <- IO.pure(String, "hi")
    +v2 : String <- IO.pure(String, "yo")
    +v3 : Bool <- IO.pure(Bool, True{})
    +v6 : U0 <- spiral_main_if1(v3, v1, v2)
    spiral_array_set_a0(v0, {0 : U32}, v6)
    +v7 : U0 <- spiral_array_get_a0(v0, {0 : U32})
    score_0(v7)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
