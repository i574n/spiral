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
def w64_bit(+c: Bool) -> U32:
  match c:
    case True{}:
      {1 : U32}
    case False{}:
      {0 : U32}

def w64_add_with(+ah: U32, +bh: U32, +al: U32, +lo: U32) -> U32 & U32:
  (U32.add(U32.add(ah, bh), w64_bit(U32.is_lt(lo, al))), lo)

def w64_add(a: U32 & U32, b: U32 & U32) -> U32 & U32:
  (+ah, +al) = a
  (+bh, +bl) = b
  w64_add_with(ah, bh, al, U32.add(al, bl))

def w64_mul32_with(+p00: U32, +mid: U32, +p11: U32, +mid_carry: U32) -> U32 & U32:
  w64_add((U32.add(p11, U32.add(U32.shrn(mid, U32.to_nat(16)), U32.shln(mid_carry, U32.to_nat(16)))), U32.shln(mid, U32.to_nat(16))), ({0 : U32}, p00))

def w64_mul32_mid(+p00: U32, +p01: U32, +p10: U32, +p11: U32) -> U32 & U32:
  w64_mul32_with(p00, U32.add(p01, p10), p11, w64_bit(U32.is_lt(U32.add(p01, p10), p01)))

def w64_mul32(+a: U32, +b: U32) -> U32 & U32:
  w64_mul32_mid(U32.mul(U32.and(a, 65535), U32.and(b, 65535)), U32.mul(U32.and(a, 65535), U32.shrn(b, U32.to_nat(16))), U32.mul(U32.shrn(a, U32.to_nat(16)), U32.and(b, 65535)), U32.mul(U32.shrn(a, U32.to_nat(16)), U32.shrn(b, U32.to_nat(16))))

def w64_mul_with(low: U32 & U32, +cross: U32) -> U32 & U32:
  (+lh, +ll) = low
  (U32.add(lh, cross), ll)

def w64_mul(a: U32 & U32, b: U32 & U32) -> U32 & U32:
  (+ah, +al) = a
  (+bh, +bl) = b
  w64_mul_with(w64_mul32(al, bl), U32.add(U32.mul(ah, bl), U32.mul(al, bh)))

def w64_eq(a: U32 & U32, +h: U32, +l: U32) -> Bool:
  (+ah, +al) = a
  Bool.and(U32.is_eq(ah, h), U32.is_eq(al, l))

def w64_not(a: U32 & U32) -> U32 & U32:
  (+ah, +al) = a
  (U32.not(ah), U32.not(al))

def w64_neg(a: U32 & U32) -> U32 & U32:
  w64_add(w64_not(a), ({0 : U32}, {1 : U32}))

def w64_sub(a: U32 & U32, b: U32 & U32) -> U32 & U32:
  w64_add(a, w64_neg(b))

def w64_pick_bool(+same: Bool, +low: Bool, +high: Bool) -> Bool:
  match same:
    case True{}:
      low
    case False{}:
      high

def w64_ult_with(+ah: U32, +al: U32, +bh: U32, +bl: U32) -> Bool:
  w64_pick_bool(U32.is_eq(ah, bh), U32.is_lt(al, bl), U32.is_lt(ah, bh))

def w64_ult(a: U32 & U32, b: U32 & U32) -> Bool:
  (+ah, +al) = a
  (+bh, +bl) = b
  w64_ult_with(ah, al, bh, bl)

def w64_slt(a: U32 & U32, b: U32 & U32) -> Bool:
  (+ah, +al) = a
  (+bh, +bl) = b
  w64_ult_with(U32.xor(ah, 2147483648), al, U32.xor(bh, 2147483648), bl)

def w64_pick(+first: Bool, a: U32 & U32, b: U32 & U32) -> U32 & U32:
  match first:
    case True{}:
      a
    case False{}:
      b

def w64_shl(a: U32 & U32, +n: U32) -> U32 & U32:
  (+ah, +al) = a
  w64_pick(U32.is_eq(n, 0), (ah, al), w64_pick(U32.is_lt(n, 32), (U32.or(U32.shln(ah, U32.to_nat(n)), U32.shrn(al, U32.to_nat(U32.sub(32, n)))), U32.shln(al, U32.to_nat(n))), (U32.shln(al, U32.to_nat(U32.sub(n, 32))), {0 : U32})))

def w64_lshr(a: U32 & U32, +n: U32) -> U32 & U32:
  (+ah, +al) = a
  w64_pick(U32.is_eq(n, 0), (ah, al), w64_pick(U32.is_lt(n, 32), (U32.shrn(ah, U32.to_nat(n)), U32.or(U32.shrn(al, U32.to_nat(n)), U32.shln(ah, U32.to_nat(U32.sub(32, n))))), ({0 : U32}, U32.shrn(ah, U32.to_nat(U32.sub(n, 32))))))

def w64_or(a: U32 & U32, b: U32 & U32) -> U32 & U32:
  (+ah, +al) = a
  (+bh, +bl) = b
  (U32.or(ah, bh), U32.or(al, bl))

def w64_ashr(a: U32 & U32, +n: U32) -> U32 & U32:
  (+ah, +al) = a
  w64_pick(U32.is_lt(ah, 2147483648), w64_lshr((ah, al), n), w64_pick(U32.is_eq(n, 0), (ah, al), w64_or(w64_lshr((ah, al), n), w64_shl(({4294967295 : U32}, {4294967295 : U32}), U32.sub(64, n)))))

def w64_and(a: U32 & U32, b: U32 & U32) -> U32 & U32:
  (+ah, +al) = a
  (+bh, +bl) = b
  (U32.and(ah, bh), U32.and(al, bl))

def u32_pick(+first: Bool, +a: U32, +b: U32) -> U32:
  match first:
    case True{}:
      a
    case False{}:
      b

def w64_bit_at(+nh: U32, +nl: U32, +k: U32) -> U32:
  u32_pick(U32.is_lt(k, 32), U32.and(U32.shrn(nl, U32.to_nat(k)), 1), U32.and(U32.shrn(nh, U32.to_nat(U32.sub(k, 32))), 1))

def w64_udiv_rec(fuel: Nat, +i: U32, +nh: U32, +nl: U32, +dh: U32, +dl: U32, +qh: U32, +ql: U32, +rh: U32, +rl: U32) -> (U32 & U32) & (U32 & U32):
  match fuel:
    case 0n:
      ((qh, ql), (rh, rl))
    case 1n+p:
      +k = U32.sub(i, 1)
      +sh = U32.or(U32.shln(rh, U32.to_nat(1)), U32.shrn(rl, U32.to_nat(31)))
      +sl = U32.or(U32.shln(rl, U32.to_nat(1)), w64_bit_at(nh, nl, k))
      +take = Bool.not(w64_ult_with(sh, sl, dh, dl))
      +th = U32.sub(U32.sub(sh, dh), w64_bit(U32.is_lt(sl, dl)))
      +tl = U32.sub(sl, dl)
      +nqh = u32_pick(Bool.and(take, Bool.not(U32.is_lt(k, 32))), U32.or(qh, U32.shln(1, U32.to_nat(U32.sub(k, 32)))), qh)
      +nql = u32_pick(Bool.and(take, U32.is_lt(k, 32)), U32.or(ql, U32.shln(1, U32.to_nat(k))), ql)
      w64_udiv_rec(p, k, nh, nl, dh, dl, nqh, nql, u32_pick(take, th, sh), u32_pick(take, tl, sl))

def w64_udivmod(n: U32 & U32, d: U32 & U32) -> (U32 & U32) & (U32 & U32):
  (+nh, +nl) = n
  (+dh, +dl) = d
  w64_udiv_rec(64n, 64, nh, nl, dh, dl, {0 : U32}, {0 : U32}, {0 : U32}, {0 : U32})

def w64_quotient(qr: (U32 & U32) & (U32 & U32)) -> U32 & U32:
  (q, r) = qr
  q

def w64_remainder(qr: (U32 & U32) & (U32 & U32)) -> U32 & U32:
  (q, r) = qr
  r

def w64_abs_with(+h: U32, +l: U32) -> U32 & U32:
  w64_pick(U32.is_lt(h, 2147483648), (h, l), w64_neg((h, l)))

def w64_sdiv(n: U32 & U32, d: U32 & U32) -> U32 & U32:
  (+nh, +nl) = n
  (+dh, +dl) = d
  w64_pick(Bool.xor(U32.is_lt(nh, 2147483648), U32.is_lt(dh, 2147483648)), w64_neg(w64_quotient(w64_udivmod(w64_abs_with(nh, nl), w64_abs_with(dh, dl)))), w64_quotient(w64_udivmod(w64_abs_with(nh, nl), w64_abs_with(dh, dl))))

def w64_srem(n: U32 & U32, d: U32 & U32) -> U32 & U32:
  (+nh, +nl) = n
  (+dh, +dl) = d
  w64_pick(U32.is_lt(nh, 2147483648), w64_remainder(w64_udivmod(w64_abs_with(nh, nl), w64_abs_with(dh, dl))), w64_neg(w64_remainder(w64_udivmod(w64_abs_with(nh, nl), w64_abs_with(dh, dl)))))

def w64_udiv(n: U32 & U32, d: U32 & U32) -> U32 & U32:
  w64_quotient(w64_udivmod(n, d))

def w64_urem(n: U32 & U32, d: U32 & U32) -> U32 & U32:
  w64_remainder(w64_udivmod(n, d))

def w64_hi(p: U32 & U32) -> U32:
  (+h, +l) = p
  h

def w64_lo(p: U32 & U32) -> U32:
  (+h, +l) = p
  l

def w64_of_u32(+x: U32) -> U32 & U32:
  ({0 : U32}, x)

def w64_of_i32(+x: U32) -> U32 & U32:
  (u32_pick(U32.is_lt(x, 2147483648), {0 : U32}, {4294967295 : U32}), x)

def w64_show_rec(fuel: Nat, +stop: Bool, +h: U32, +l: U32, acc: String) -> String:
  match fuel:
    case 0n:
      acc
    case 1n+p:
      match stop:
        case True{}:
          acc
        case False{}:
          +qh = w64_hi(w64_udiv((h, l), ({0 : U32}, {10 : U32})))
          +ql = w64_lo(w64_udiv((h, l), ({0 : U32}, {10 : U32})))
          +digit = w64_lo(w64_urem((h, l), ({0 : U32}, {10 : U32})))
          w64_show_rec(p, Bool.and(U32.is_eq(qh, 0), U32.is_eq(ql, 0)), qh, ql, U32.show(digit) ++ acc)

def w64_show_u(p: U32 & U32) -> String:
  (+h, +l) = p
  w64_show_rec(20n, False{}, h, l, "")

def w64_show_s_if(+negative: Bool, +h: U32, +l: U32) -> String:
  match negative:
    case True{}:
      "-" ++ w64_show_u(w64_neg((h, l)))
    case False{}:
      w64_show_u((h, l))

def w64_show_s(p: U32 & U32) -> String:
  (+h, +l) = p
  w64_show_s_if(Bool.not(U32.is_lt(h, 2147483648)), h, l)

def w64_equal(a: U32 & U32, b: U32 & U32) -> Bool:
  (+ah, +al) = a
  (+bh, +bl) = b
  Bool.and(U32.is_eq(ah, bh), U32.is_eq(al, bl))

def w64_xor(a: U32 & U32, b: U32 & U32) -> U32 & U32:
  (+ah, +al) = a
  (+bh, +bl) = b
  (U32.xor(ah, bh), U32.xor(al, bl))
@unsafe
def spiral_array_fill_go_a0(+depth: U32, +v: ((U32 & U32) & String), leaf: Bool) -> Array<((U32 & U32) & String)>:
  match leaf:
    case True{}:
      ALeaf{v}
    case False{}:
      ANode{spiral_array_fill_a0(U32.sub(depth, 1), v), spiral_array_fill_a0(U32.sub(depth, 1), v)}

@unsafe
def spiral_array_fill_a0(+depth: U32, +v: ((U32 & U32) & String)) -> Array<((U32 & U32) & String)>:
  spiral_array_fill_go_a0(depth, v, U32.is_eq(depth, 0))

@unsafe
def spiral_array_peek_lo_a0(ys: Array<((U32 & U32) & String)>, r: Array<((U32 & U32) & String)> & ((U32 & U32) & String)) -> Array<((U32 & U32) & String)> & ((U32 & U32) & String):
  (nxs, v) = r
  (ANode{nxs, ys}, v)

@unsafe
def spiral_array_peek_hi_a0(xs: Array<((U32 & U32) & String)>, r: Array<((U32 & U32) & String)> & ((U32 & U32) & String)) -> Array<((U32 & U32) & String)> & ((U32 & U32) & String):
  (nys, v) = r
  (ANode{xs, nys}, v)

@unsafe
def spiral_array_peek_go_a0(a: Array<((U32 & U32) & String)>, +n: U32, +i: U32, z: Bool) -> Array<((U32 & U32) & String)> & ((U32 & U32) & String):
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
def spiral_array_peek_at_a0(+i: U32, an: Array<((U32 & U32) & String)> & U32) -> Array<((U32 & U32) & String)> & ((U32 & U32) & String):
  (a, +n) = an
  spiral_array_peek_go_a0(a, n, i, U32.is_lt(i, U32.shr(n)))

@unsafe
def spiral_array_new_a0(+length: U32, +v: ((U32 & U32) & String)) -> IO(Chan(Array<((U32 & U32) & String)>) & U32):
  do IO<Chan(Array<((U32 & U32) & String)>) & U32>:
    +c : Chan(Array<((U32 & U32) & String)>) <- Chan.new(Array<((U32 & U32) & String)>, 1)
    _ : Result<&1, &1, Array<((U32 & U32) & String)>, Unit> <- Chan.send(Array<((U32 & U32) & String)>, c, spiral_array_fill_a0(spiral_array_depth(length), v))
    return (c, length)

@unsafe
def spiral_array_length_a0(+arr: Chan(Array<((U32 & U32) & String)>) & U32) -> U32:
  (c, +n) = arr
  n

@unsafe
def spiral_array_get_back_a0(+c: Chan(Array<((U32 & U32) & String)>), r: Array<((U32 & U32) & String)> & ((U32 & U32) & String)) -> IO(((U32 & U32) & String)):
  (a, +v) = r
  do IO<((U32 & U32) & String)>:
    _ : Result<&1, &1, Array<((U32 & U32) & String)>, Unit> <- Chan.send(Array<((U32 & U32) & String)>, c, a)
    return v

@unsafe
def spiral_array_get_taken_a0(+c: Chan(Array<((U32 & U32) & String)>), +i: U32, m: Maybe<&1, Array<((U32 & U32) & String)>>) -> IO(((U32 & U32) & String)):
  match m:
    case None{}:
      IO.die(((U32 & U32) & String), 3, "")
    case Some{a}:
      spiral_array_get_back_a0(c, spiral_array_peek_at_a0(i, Array.size(((U32 & U32) & String), a)))

@unsafe
def spiral_array_get_checked_a0(+c: Chan(Array<((U32 & U32) & String)>), +i: U32, inside: Bool) -> IO(((U32 & U32) & String)):
  match inside:
    case True{}:
      do IO<((U32 & U32) & String)>:
        m : Maybe<&1, Array<((U32 & U32) & String)>> <- Chan.recv(Array<((U32 & U32) & String)>, c)
        spiral_array_get_taken_a0(c, i, m)
    case False{}:
      IO.die(((U32 & U32) & String), 3, "")

@unsafe
def spiral_array_get_a0(+arr: Chan(Array<((U32 & U32) & String)>) & U32, +i: U32) -> IO(((U32 & U32) & String)):
  (+c, +n) = arr
  spiral_array_get_checked_a0(c, i, U32.is_lt(i, n))

@unsafe
def spiral_array_set_back_a0(+c: Chan(Array<((U32 & U32) & String)>), r: Array<((U32 & U32) & String)> & ((U32 & U32) & String)) -> IO(Unit):
  (a, old) = r
  do IO<Unit>:
    _ : Result<&1, &1, Array<((U32 & U32) & String)>, Unit> <- Chan.send(Array<((U32 & U32) & String)>, c, a)
    return Unit{}

@unsafe
def spiral_array_set_taken_a0(+c: Chan(Array<((U32 & U32) & String)>), +i: U32, +v: ((U32 & U32) & String), m: Maybe<&1, Array<((U32 & U32) & String)>>) -> IO(Unit):
  match m:
    case None{}:
      IO.die(Unit, 3, "")
    case Some{a}:
      spiral_array_set_back_a0(c, Array.swap(((U32 & U32) & String), a, i, v))

@unsafe
def spiral_array_set_checked_a0(+c: Chan(Array<((U32 & U32) & String)>), +i: U32, +v: ((U32 & U32) & String), inside: Bool) -> IO(Unit):
  match inside:
    case True{}:
      do IO<Unit>:
        m : Maybe<&1, Array<((U32 & U32) & String)>> <- Chan.recv(Array<((U32 & U32) & String)>, c)
        spiral_array_set_taken_a0(c, i, v, m)
    case False{}:
      IO.die(Unit, 3, "")

@unsafe
def spiral_array_set_a0(+arr: Chan(Array<((U32 & U32) & String)>) & U32, +i: U32, +v: ((U32 & U32) & String)) -> IO(Unit):
  (+c, +n) = arr
  spiral_array_set_checked_a0(c, i, v, U32.is_lt(i, n))

@unsafe
def spiral_main_set1_put(+c: (Chan(Array<((U32 & U32) & String)>) & U32), +p: (U32 & U32) & String, +n: (U32 & U32) & String) -> IO(Unit):
  (+w0, +w1) = p
  (+x0, +x1) = n
  spiral_array_set_a0(c, {0 : U32}, (x0, x1))

@unsafe
def spiral_main_set1(+c: (Chan(Array<((U32 & U32) & String)>) & U32), +n: (U32 & U32) & String) -> IO(Unit):
  do IO<Unit>:
    +p : (U32 & U32) & String <- spiral_array_get_a0(c, {0 : U32})
    spiral_main_set1_put(c, p, n)

@unsafe
def spiral_main_k2_if3(+c: Bool, +v6: String) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v8 : Bool <- IO.pure(Bool, String.eq(v6, "hi"))
        return v8
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_k2_if4(+c: Bool) -> IO(U32):
  match c:
    case True{}:
      do IO<U32>:
        return {0 : U32}
    case False{}:
      do IO<U32>:
        return {1 : U32}

@unsafe
def spiral_main_k2(+p: (U32 & U32) & String, +v0: (U32 & U32), +v1: String, +v2: (Chan(Array<((U32 & U32) & String)>) & U32), +v3: (U32 & U32), +v4: String) -> IO(U32):
  (+v5, +v6) = p
  do IO<U32>:
    +v7 : Bool <- IO.pure(Bool, w64_equal(v5, ({1 : U32}, {705032704 : U32})))
    +v9 : Bool <- spiral_main_k2_if3(v7, v6)
    spiral_main_k2_if4(v9)

@unsafe
def spiral_main() -> IO(U32):
  do IO<U32>:
    +v0 : (U32 & U32) <- IO.pure((U32 & U32), ({0 : U32}, {3 : U32}))
    +v1 : String <- IO.pure(String, "no")
    +v2 : (Chan(Array<((U32 & U32) & String)>) & U32) <- spiral_array_new_a0({1 : U32}, (v0, v1))
    +v3 : (U32 & U32) <- IO.pure((U32 & U32), ({1 : U32}, {705032704 : U32}))
    +v4 : String <- IO.pure(String, "hi")
    spiral_main_set1(v2, (v3, v4))
    +p : (U32 & U32) & String <- spiral_array_get_a0(v2, {0 : U32})
    spiral_main_k2(p, v0, v1, v2, v3, v4)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
