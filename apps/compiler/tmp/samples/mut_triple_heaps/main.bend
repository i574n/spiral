import Base

def spiral_i32_bias(+x: U32) -> U32:
  U32.xor(x, 2147483648)

def spiral_i32_lt(+a: U32, +b: U32) -> Bool:
  U32.is_lt(spiral_i32_bias(a), spiral_i32_bias(b))

def spiral_i32_le(+a: U32, +b: U32) -> Bool:
  U32.is_le(spiral_i32_bias(a), spiral_i32_bias(b))

def spiral_i32_gt(+a: U32, +b: U32) -> Bool:
  U32.is_gt(spiral_i32_bias(a), spiral_i32_bias(b))

def spiral_i32_ge(+a: U32, +b: U32) -> Bool:
  U32.is_ge(spiral_i32_bias(a), spiral_i32_bias(b))

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

def spiral_i32_shift_right_if(+c: Bool, +a: U32, +n: U32) -> U32:
  match c:
    case True{}:
      U32.not(U32.shrn(U32.not(a), U32.to_nat(n)))
    case False{}:
      U32.shrn(a, U32.to_nat(n))

def spiral_i32_shift_right(+a: U32, +n: U32) -> U32:
  spiral_i32_shift_right_if(spiral_i32_is_negative(a), a, n)

def spiral_i32_show_if(+c: Bool, +x: U32) -> String:
  match c:
    case True{}:
      "-" ++ U32.show(U32.sub(0, x))
    case False{}:
      U32.show(x)

def spiral_i32_show(+x: U32) -> String:
  spiral_i32_show_if(spiral_i32_is_negative(x), x)
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
def spiral_i32_to_f32(+value: U32) -> F32:
  spiral_i32_to_f32_signed(value, spiral_i32_is_negative(value))

@unsafe
def spiral_i32_to_f32_signed(+value: U32, negative: Bool) -> F32:
  match negative:
    case True{}:
      F32.neg(U32.to_f32(U32.sub(0, value)))
    case False{}:
      U32.to_f32(value)

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
def spiral_array_depth_go(+wanted: U32, +size: U32, +depth: U32, done: Bool) -> U32:
  match done:
    case True{}:
      depth
    case False{}:
      spiral_array_depth_go(wanted, U32.shl(size), U32.add(depth, 1), U32.is_le(wanted, U32.shl(size)))

@unsafe
def spiral_array_depth(+wanted: U32) -> U32:
  spiral_array_depth_go(wanted, 1, 0, U32.is_le(wanted, 1))

@unsafe
def spiral_array_fill_go_a0(+depth: U32, +v: ((U32 & String) & (U32 & String) & (U32 & String)), leaf: Bool) -> Array<((U32 & String) & (U32 & String) & (U32 & String))>:
  match leaf:
    case True{}:
      ALeaf{v}
    case False{}:
      ANode{spiral_array_fill_a0(U32.sub(depth, 1), v), spiral_array_fill_a0(U32.sub(depth, 1), v)}

@unsafe
def spiral_array_fill_a0(+depth: U32, +v: ((U32 & String) & (U32 & String) & (U32 & String))) -> Array<((U32 & String) & (U32 & String) & (U32 & String))>:
  spiral_array_fill_go_a0(depth, v, U32.is_eq(depth, 0))

@unsafe
def spiral_array_peek_lo_a0(ys: Array<((U32 & String) & (U32 & String) & (U32 & String))>, r: Array<((U32 & String) & (U32 & String) & (U32 & String))> & ((U32 & String) & (U32 & String) & (U32 & String))) -> Array<((U32 & String) & (U32 & String) & (U32 & String))> & ((U32 & String) & (U32 & String) & (U32 & String)):
  (nxs, v) = r
  (ANode{nxs, ys}, v)

@unsafe
def spiral_array_peek_hi_a0(xs: Array<((U32 & String) & (U32 & String) & (U32 & String))>, r: Array<((U32 & String) & (U32 & String) & (U32 & String))> & ((U32 & String) & (U32 & String) & (U32 & String))) -> Array<((U32 & String) & (U32 & String) & (U32 & String))> & ((U32 & String) & (U32 & String) & (U32 & String)):
  (nys, v) = r
  (ANode{xs, nys}, v)

@unsafe
def spiral_array_peek_go_a0(a: Array<((U32 & String) & (U32 & String) & (U32 & String))>, +n: U32, +i: U32, z: Bool) -> Array<((U32 & String) & (U32 & String) & (U32 & String))> & ((U32 & String) & (U32 & String) & (U32 & String)):
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
def spiral_array_peek_at_a0(+i: U32, an: Array<((U32 & String) & (U32 & String) & (U32 & String))> & U32) -> Array<((U32 & String) & (U32 & String) & (U32 & String))> & ((U32 & String) & (U32 & String) & (U32 & String)):
  (a, +n) = an
  spiral_array_peek_go_a0(a, n, i, U32.is_lt(i, U32.shr(n)))

@unsafe
def spiral_array_new_a0(+length: U32, +v: ((U32 & String) & (U32 & String) & (U32 & String))) -> IO(Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32):
  do IO<Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32>:
    +c : Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) <- Chan.new(Array<((U32 & String) & (U32 & String) & (U32 & String))>, 1)
    _ : Result<&1, &1, Array<((U32 & String) & (U32 & String) & (U32 & String))>, Unit> <- Chan.send(Array<((U32 & String) & (U32 & String) & (U32 & String))>, c, spiral_array_fill_a0(spiral_array_depth(length), v))
    return (c, length)

@unsafe
def spiral_array_length_a0(+arr: Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32) -> U32:
  (c, +n) = arr
  n

@unsafe
def spiral_array_get_back_a0(+c: Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>), r: Array<((U32 & String) & (U32 & String) & (U32 & String))> & ((U32 & String) & (U32 & String) & (U32 & String))) -> IO(((U32 & String) & (U32 & String) & (U32 & String))):
  (a, +v) = r
  do IO<((U32 & String) & (U32 & String) & (U32 & String))>:
    _ : Result<&1, &1, Array<((U32 & String) & (U32 & String) & (U32 & String))>, Unit> <- Chan.send(Array<((U32 & String) & (U32 & String) & (U32 & String))>, c, a)
    return v

@unsafe
def spiral_array_get_taken_a0(+c: Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>), +i: U32, m: Maybe<&1, Array<((U32 & String) & (U32 & String) & (U32 & String))>>) -> IO(((U32 & String) & (U32 & String) & (U32 & String))):
  match m:
    case None{}:
      IO.die(((U32 & String) & (U32 & String) & (U32 & String)), 3, "")
    case Some{a}:
      spiral_array_get_back_a0(c, spiral_array_peek_at_a0(i, Array.size(((U32 & String) & (U32 & String) & (U32 & String)), a)))

@unsafe
def spiral_array_get_checked_a0(+c: Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>), +i: U32, inside: Bool) -> IO(((U32 & String) & (U32 & String) & (U32 & String))):
  match inside:
    case True{}:
      do IO<((U32 & String) & (U32 & String) & (U32 & String))>:
        m : Maybe<&1, Array<((U32 & String) & (U32 & String) & (U32 & String))>> <- Chan.recv(Array<((U32 & String) & (U32 & String) & (U32 & String))>, c)
        spiral_array_get_taken_a0(c, i, m)
    case False{}:
      IO.die(((U32 & String) & (U32 & String) & (U32 & String)), 3, "")

@unsafe
def spiral_array_get_a0(+arr: Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32, +i: U32) -> IO(((U32 & String) & (U32 & String) & (U32 & String))):
  (+c, +n) = arr
  spiral_array_get_checked_a0(c, i, U32.is_lt(i, n))

@unsafe
def spiral_array_set_back_a0(+c: Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>), r: Array<((U32 & String) & (U32 & String) & (U32 & String))> & ((U32 & String) & (U32 & String) & (U32 & String))) -> IO(Unit):
  (a, old) = r
  do IO<Unit>:
    _ : Result<&1, &1, Array<((U32 & String) & (U32 & String) & (U32 & String))>, Unit> <- Chan.send(Array<((U32 & String) & (U32 & String) & (U32 & String))>, c, a)
    return Unit{}

@unsafe
def spiral_array_set_taken_a0(+c: Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>), +i: U32, +v: ((U32 & String) & (U32 & String) & (U32 & String)), m: Maybe<&1, Array<((U32 & String) & (U32 & String) & (U32 & String))>>) -> IO(Unit):
  match m:
    case None{}:
      IO.die(Unit, 3, "")
    case Some{a}:
      spiral_array_set_back_a0(c, Array.swap(((U32 & String) & (U32 & String) & (U32 & String)), a, i, v))

@unsafe
def spiral_array_set_checked_a0(+c: Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>), +i: U32, +v: ((U32 & String) & (U32 & String) & (U32 & String)), inside: Bool) -> IO(Unit):
  match inside:
    case True{}:
      do IO<Unit>:
        m : Maybe<&1, Array<((U32 & String) & (U32 & String) & (U32 & String))>> <- Chan.recv(Array<((U32 & String) & (U32 & String) & (U32 & String))>, c)
        spiral_array_set_taken_a0(c, i, v, m)
    case False{}:
      IO.die(Unit, 3, "")

@unsafe
def spiral_array_set_a0(+arr: Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32, +i: U32, +v: ((U32 & String) & (U32 & String) & (U32 & String))) -> IO(Unit):
  (+c, +n) = arr
  spiral_array_set_checked_a0(c, i, v, U32.is_lt(i, n))

@unsafe
def spiral_main_set1_put(+c: (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32), +p: (U32 & String) & (U32 & String) & (U32 & String), +n: (U32 & String) & (U32 & String) & (U32 & String)) -> IO(Unit):
  (+w0, +w1, +w2) = p
  (+x0, +x1, +x2) = n
  spiral_array_set_a0(c, {0 : U32}, (x0, x1, x2))

@unsafe
def spiral_main_set1(+c: (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32), +n: (U32 & String) & (U32 & String) & (U32 & String)) -> IO(Unit):
  do IO<Unit>:
    +p : (U32 & String) & (U32 & String) & (U32 & String) <- spiral_array_get_a0(c, {0 : U32})
    spiral_main_set1_put(c, p, n)

@unsafe
def spiral_main_k2_field3(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def spiral_main_k2_k4_field5(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def spiral_main_k2_k4_k6_field7(+p: U32 & String) -> IO(U32 & String):
  (+w0, +w1) = p
  IO.pure(U32 & String, (w0, w1))

@unsafe
def spiral_main_k2_k4_k6_k8_if9(+c: Bool, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32), +v10: U32, +v11: String, +v12: (U32 & String), +v13: U32, +v14: String, +v15: (U32 & String), +v16: U32, +v17: String, +v18: (U32 & String), +v19: (U32 & String), +v20: (U32 & String), +v21: (U32 & String), +v22: U32, +v23: String, +v24: U32, +v25: String, +v26: U32, +v27: String, +v28: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v29 : Bool <- IO.pure(Bool, String.eq(v23, "hi"))
        return v29
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k2_k4_k6_k8_if10(+c: Bool, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32), +v10: U32, +v11: String, +v12: (U32 & String), +v13: U32, +v14: String, +v15: (U32 & String), +v16: U32, +v17: String, +v18: (U32 & String), +v19: (U32 & String), +v20: (U32 & String), +v21: (U32 & String), +v22: U32, +v23: String, +v24: U32, +v25: String, +v26: U32, +v27: String, +v28: Bool, +v30: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v31 : Bool <- IO.pure(Bool, U32.is_eq(v24, {4 : U32}))
        return v31
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k2_k4_k6_k8_if11(+c: Bool, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32), +v10: U32, +v11: String, +v12: (U32 & String), +v13: U32, +v14: String, +v15: (U32 & String), +v16: U32, +v17: String, +v18: (U32 & String), +v19: (U32 & String), +v20: (U32 & String), +v21: (U32 & String), +v22: U32, +v23: String, +v24: U32, +v25: String, +v26: U32, +v27: String, +v28: Bool, +v30: Bool, +v32: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v33 : Bool <- IO.pure(Bool, String.eq(v25, "yo"))
        return v33
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k2_k4_k6_k8_if12(+c: Bool, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32), +v10: U32, +v11: String, +v12: (U32 & String), +v13: U32, +v14: String, +v15: (U32 & String), +v16: U32, +v17: String, +v18: (U32 & String), +v19: (U32 & String), +v20: (U32 & String), +v21: (U32 & String), +v22: U32, +v23: String, +v24: U32, +v25: String, +v26: U32, +v27: String, +v28: Bool, +v30: Bool, +v32: Bool, +v34: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v35 : Bool <- IO.pure(Bool, U32.is_eq(v26, {9 : U32}))
        return v35
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k2_k4_k6_k8_if13(+c: Bool, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32), +v10: U32, +v11: String, +v12: (U32 & String), +v13: U32, +v14: String, +v15: (U32 & String), +v16: U32, +v17: String, +v18: (U32 & String), +v19: (U32 & String), +v20: (U32 & String), +v21: (U32 & String), +v22: U32, +v23: String, +v24: U32, +v25: String, +v26: U32, +v27: String, +v28: Bool, +v30: Bool, +v32: Bool, +v34: Bool, +v36: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v37 : Bool <- IO.pure(Bool, String.eq(v27, "ok"))
        return v37
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k2_k4_k6_k8_if14(+c: Bool, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32), +v10: U32, +v11: String, +v12: (U32 & String), +v13: U32, +v14: String, +v15: (U32 & String), +v16: U32, +v17: String, +v18: (U32 & String), +v19: (U32 & String), +v20: (U32 & String), +v21: (U32 & String), +v22: U32, +v23: String, +v24: U32, +v25: String, +v26: U32, +v27: String, +v28: Bool, +v30: Bool, +v32: Bool, +v34: Bool, +v36: Bool, +v38: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main_k2_k4_k6_k8(+p: U32 & String, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32), +v10: U32, +v11: String, +v12: (U32 & String), +v13: U32, +v14: String, +v15: (U32 & String), +v16: U32, +v17: String, +v18: (U32 & String), +v19: (U32 & String), +v20: (U32 & String), +v21: (U32 & String), +v22: U32, +v23: String, +v24: U32, +v25: String) -> IO(U32):
  (+v26, +v27) = p
  do IO<U32>:
    +v28 : Bool <- IO.pure(Bool, U32.is_eq(v22, {7 : U32}))
    +v30 : Bool <- spiral_main_k2_k4_k6_k8_if9(v28, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28)
    +v32 : Bool <- spiral_main_k2_k4_k6_k8_if10(v30, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v30)
    +v34 : Bool <- spiral_main_k2_k4_k6_k8_if11(v32, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v30, v32)
    +v36 : Bool <- spiral_main_k2_k4_k6_k8_if12(v34, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v30, v32, v34)
    +v38 : Bool <- spiral_main_k2_k4_k6_k8_if13(v36, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v30, v32, v34, v36)
    spiral_main_k2_k4_k6_k8_if14(v38, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v30, v32, v34, v36, v38)

@unsafe
def spiral_main_k2_k4_k6(+p: U32 & String, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32), +v10: U32, +v11: String, +v12: (U32 & String), +v13: U32, +v14: String, +v15: (U32 & String), +v16: U32, +v17: String, +v18: (U32 & String), +v19: (U32 & String), +v20: (U32 & String), +v21: (U32 & String), +v22: U32, +v23: String) -> IO(U32):
  (+v24, +v25) = p
  do IO<U32>:
    +p : U32 & String <- spiral_main_k2_k4_k6_field7(v21)
    spiral_main_k2_k4_k6_k8(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25)

@unsafe
def spiral_main_k2_k4(+p: U32 & String, +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32), +v10: U32, +v11: String, +v12: (U32 & String), +v13: U32, +v14: String, +v15: (U32 & String), +v16: U32, +v17: String, +v18: (U32 & String), +v19: (U32 & String), +v20: (U32 & String), +v21: (U32 & String)) -> IO(U32):
  (+v22, +v23) = p
  do IO<U32>:
    +p : U32 & String <- spiral_main_k2_k4_field5(v20)
    spiral_main_k2_k4_k6(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23)

@unsafe
def spiral_main_k2(+p: (U32 & String) & (U32 & String) & (U32 & String), +v0: U32, +v1: String, +v2: (U32 & String), +v3: U32, +v4: String, +v5: (U32 & String), +v6: U32, +v7: String, +v8: (U32 & String), +v9: (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32), +v10: U32, +v11: String, +v12: (U32 & String), +v13: U32, +v14: String, +v15: (U32 & String), +v16: U32, +v17: String, +v18: (U32 & String)) -> IO(U32):
  (+v19, +v20, +v21) = p
  do IO<U32>:
    +p : U32 & String <- spiral_main_k2_field3(v19)
    spiral_main_k2_k4(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : U32 <- IO.pure(U32, {1 : U32})
    +v1 : String <- IO.pure(String, "no")
    +v2 : (U32 & String) <- IO.pure((U32 & String), (v0, v1))
    +v3 : U32 <- IO.pure(U32, {2 : U32})
    +v4 : String <- IO.pure(String, "zz")
    +v5 : (U32 & String) <- IO.pure((U32 & String), (v3, v4))
    +v6 : U32 <- IO.pure(U32, {3 : U32})
    +v7 : String <- IO.pure(String, "aa")
    +v8 : (U32 & String) <- IO.pure((U32 & String), (v6, v7))
    +v9 : (Chan(Array<((U32 & String) & (U32 & String) & (U32 & String))>) & U32) <- spiral_array_new_a0({1 : U32}, (v2, v5, v8))
    +v10 : U32 <- IO.pure(U32, {7 : U32})
    +v11 : String <- IO.pure(String, "hi")
    +v12 : (U32 & String) <- IO.pure((U32 & String), (v10, v11))
    +v13 : U32 <- IO.pure(U32, {4 : U32})
    +v14 : String <- IO.pure(String, "yo")
    +v15 : (U32 & String) <- IO.pure((U32 & String), (v13, v14))
    +v16 : U32 <- IO.pure(U32, {9 : U32})
    +v17 : String <- IO.pure(String, "ok")
    +v18 : (U32 & String) <- IO.pure((U32 & String), (v16, v17))
    spiral_main_set1(v9, (v12, v15, v18))
    +p : (U32 & String) & (U32 & String) & (U32 & String) <- spiral_array_get_a0(v9, {0 : U32})
    spiral_main_k2(p, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
