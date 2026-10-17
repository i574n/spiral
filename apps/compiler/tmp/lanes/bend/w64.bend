import Base

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

def check(+ok: Bool, +code: U32) -> U32:
  match ok:
    case True{}:
      {0 : U32}
    case False{}:
      code

def main() -> IO(Unit):
  do IO<Unit>:
    +a : U32 <- IO.pure(U32, check(w64_eq(w64_add((0, 4294967295), (0, 1)), 1, 0), 11))
    +b : U32 <- IO.pure(U32, check(w64_eq(w64_mul32(4294967295, 4294967295), 4294967294, 1), 12))
    +c : U32 <- IO.pure(U32, check(w64_eq(w64_mul((0, 1103515245), (0, 42)), 10, 3397967330), 13))
    +d : U32 <- IO.pure(U32, check(w64_eq(w64_mul((305419896, 2596069104), (2271560481, 4275878552)), 3027559546, 3495870080), 14))
    IO.die(Unit, U32.add(U32.add(a, b), U32.add(c, d)), "")