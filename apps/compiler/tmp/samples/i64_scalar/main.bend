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
def spiral_main_if1(+c: Bool, +v0: (U32 & U32), +v1: (U32 & U32), +v2: (U32 & U32), +v3: (U32 & U32), +v4: (U32 & U32), +v5: (U32 & U32), +v6: (U32 & U32), +v7: U32, +v8: (U32 & U32), +v9: (U32 & U32), +v10: U32, +v11: (U32 & U32), +v12: (U32 & U32), +v13: (U32 & U32), +v14: (U32 & U32), +v15: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v16 : Bool <- IO.pure(Bool, w64_equal(v4, ({232 : U32}, {3567587328 : U32})))
        return v16
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if2(+c: Bool, +v0: (U32 & U32), +v1: (U32 & U32), +v2: (U32 & U32), +v3: (U32 & U32), +v4: (U32 & U32), +v5: (U32 & U32), +v6: (U32 & U32), +v7: U32, +v8: (U32 & U32), +v9: (U32 & U32), +v10: U32, +v11: (U32 & U32), +v12: (U32 & U32), +v13: (U32 & U32), +v14: (U32 & U32), +v15: Bool, +v17: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v18 : Bool <- IO.pure(Bool, w64_equal(v6, ({4294967295 : U32}, {4294967292 : U32})))
        return v18
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if3(+c: Bool, +v0: (U32 & U32), +v1: (U32 & U32), +v2: (U32 & U32), +v3: (U32 & U32), +v4: (U32 & U32), +v5: (U32 & U32), +v6: (U32 & U32), +v7: U32, +v8: (U32 & U32), +v9: (U32 & U32), +v10: U32, +v11: (U32 & U32), +v12: (U32 & U32), +v13: (U32 & U32), +v14: (U32 & U32), +v15: Bool, +v17: Bool, +v19: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v20 : Bool <- IO.pure(Bool, w64_equal(v8, ({0 : U32}, {7 : U32})))
        return v20
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if4(+c: Bool, +v0: (U32 & U32), +v1: (U32 & U32), +v2: (U32 & U32), +v3: (U32 & U32), +v4: (U32 & U32), +v5: (U32 & U32), +v6: (U32 & U32), +v7: U32, +v8: (U32 & U32), +v9: (U32 & U32), +v10: U32, +v11: (U32 & U32), +v12: (U32 & U32), +v13: (U32 & U32), +v14: (U32 & U32), +v15: Bool, +v17: Bool, +v19: Bool, +v21: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v22 : Bool <- IO.pure(Bool, U32.is_eq(v10, {9 : U32}))
        return v22
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if5(+c: Bool, +v0: (U32 & U32), +v1: (U32 & U32), +v2: (U32 & U32), +v3: (U32 & U32), +v4: (U32 & U32), +v5: (U32 & U32), +v6: (U32 & U32), +v7: U32, +v8: (U32 & U32), +v9: (U32 & U32), +v10: U32, +v11: (U32 & U32), +v12: (U32 & U32), +v13: (U32 & U32), +v14: (U32 & U32), +v15: Bool, +v17: Bool, +v19: Bool, +v21: Bool, +v23: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v24 : Bool <- IO.pure(Bool, w64_equal(v12, ({1 : U32}, {1 : U32})))
        return v24
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if6(+c: Bool, +v0: (U32 & U32), +v1: (U32 & U32), +v2: (U32 & U32), +v3: (U32 & U32), +v4: (U32 & U32), +v5: (U32 & U32), +v6: (U32 & U32), +v7: U32, +v8: (U32 & U32), +v9: (U32 & U32), +v10: U32, +v11: (U32 & U32), +v12: (U32 & U32), +v13: (U32 & U32), +v14: (U32 & U32), +v15: Bool, +v17: Bool, +v19: Bool, +v21: Bool, +v23: Bool, +v25: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v26 : Bool <- IO.pure(Bool, w64_equal(v13, ({0 : U32}, {2147483648 : U32})))
        return v26
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if7(+c: Bool, +v0: (U32 & U32), +v1: (U32 & U32), +v2: (U32 & U32), +v3: (U32 & U32), +v4: (U32 & U32), +v5: (U32 & U32), +v6: (U32 & U32), +v7: U32, +v8: (U32 & U32), +v9: (U32 & U32), +v10: U32, +v11: (U32 & U32), +v12: (U32 & U32), +v13: (U32 & U32), +v14: (U32 & U32), +v15: Bool, +v17: Bool, +v19: Bool, +v21: Bool, +v23: Bool, +v25: Bool, +v27: Bool) -> IO(Bool):
  match c:
    case True{}:
      do IO<Bool>:
        +v28 : Bool <- IO.pure(Bool, w64_equal(v14, ({0 : U32}, {7 : U32})))
        return v28
    case False{}:
      do IO<Bool>:
        return False{}

@unsafe
def spiral_main_if8(+c: Bool, +v0: (U32 & U32), +v1: (U32 & U32), +v2: (U32 & U32), +v3: (U32 & U32), +v4: (U32 & U32), +v5: (U32 & U32), +v6: (U32 & U32), +v7: U32, +v8: (U32 & U32), +v9: (U32 & U32), +v10: U32, +v11: (U32 & U32), +v12: (U32 & U32), +v13: (U32 & U32), +v14: (U32 & U32), +v15: Bool, +v17: Bool, +v19: Bool, +v21: Bool, +v23: Bool, +v25: Bool, +v27: Bool, +v29: Bool) -> IO(U32):
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
    +v0 : (U32 & U32) <- IO.pure((U32 & U32), ({1 : U32}, {705032704 : U32}))
    +v1 : (U32 & U32) <- IO.pure((U32 & U32), ({4294967295 : U32}, {4294967292 : U32}))
    +v2 : (U32 & U32) <- IO.pure((U32 & U32), w64_sdiv(v0, v1))
    +v3 : (U32 & U32) <- IO.pure((U32 & U32), ({0 : U32}, {1000000 : U32}))
    +v4 : (U32 & U32) <- IO.pure((U32 & U32), w64_mul(v3, v3))
    +v5 : (U32 & U32) <- IO.pure((U32 & U32), ({4294967295 : U32}, {4294967288 : U32}))
    +v6 : (U32 & U32) <- IO.pure((U32 & U32), w64_ashr(v5, {1 : U32}))
    +v7 : U32 <- IO.pure(U32, {7 : U32})
    +v8 : (U32 & U32) <- IO.pure((U32 & U32), w64_of_i32(v7))
    +v9 : (U32 & U32) <- IO.pure((U32 & U32), ({0 : U32}, {9 : U32}))
    +v10 : U32 <- IO.pure(U32, w64_lo(v9))
    +v11 : (U32 & U32) <- IO.pure((U32 & U32), ({1 : U32}, {0 : U32}))
    +v12 : (U32 & U32) <- IO.pure((U32 & U32), w64_add(v11, ({0 : U32}, {1 : U32})))
    +v13 : (U32 & U32) <- IO.pure((U32 & U32), w64_lshr(v11, {1 : U32}))
    +v14 : (U32 & U32) <- IO.pure((U32 & U32), w64_of_i32(v7))
    +v15 : Bool <- IO.pure(Bool, w64_equal(v2, ({4294967295 : U32}, {3044967296 : U32})))
    +v17 : Bool <- spiral_main_if1(v15, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15)
    +v19 : Bool <- spiral_main_if2(v17, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17)
    +v21 : Bool <- spiral_main_if3(v19, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v19)
    +v23 : Bool <- spiral_main_if4(v21, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v19, v21)
    +v25 : Bool <- spiral_main_if5(v23, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v19, v21, v23)
    +v27 : Bool <- spiral_main_if6(v25, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v19, v21, v23, v25)
    +v29 : Bool <- spiral_main_if7(v27, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v19, v21, v23, v25, v27)
    spiral_main_if8(v29, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v19, v21, v23, v25, v27, v29)

@unsafe
def main() -> IO(Unit):
  do IO<Unit>:
    +code : U32 <- spiral_main()
    IO.die(Unit, code, "")
