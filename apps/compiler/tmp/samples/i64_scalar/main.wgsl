struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
struct SpiralW64DivMod {
  q: vec2<u32>,
  r: vec2<u32>,
}
fn spiral_w64_add(a: vec2<u32>, b: vec2<u32>) -> vec2<u32> {
  let lo = a.x + b.x;
  return vec2<u32>(lo, a.y + b.y + select(0u, 1u, lo < a.x));
}
fn spiral_w64_neg(a: vec2<u32>) -> vec2<u32> { return spiral_w64_add(~a, vec2<u32>(1u, 0u)); }
fn spiral_w64_sub(a: vec2<u32>, b: vec2<u32>) -> vec2<u32> { return spiral_w64_add(a, spiral_w64_neg(b)); }
fn spiral_w32_wide_mul(a: u32, b: u32) -> vec2<u32> {
  let a0 = a & 0xFFFFu;
  let a1 = a >> 16u;
  let b0 = b & 0xFFFFu;
  let b1 = b >> 16u;
  let p00 = a0 * b0;
  let p01 = a0 * b1;
  let p10 = a1 * b0;
  let mid = (p00 >> 16u) + (p01 & 0xFFFFu) + (p10 & 0xFFFFu);
  return vec2<u32>((p00 & 0xFFFFu) | (mid << 16u), a1 * b1 + (p01 >> 16u) + (p10 >> 16u) + (mid >> 16u));
}
fn spiral_w64_mul(a: vec2<u32>, b: vec2<u32>) -> vec2<u32> {
  let low = spiral_w32_wide_mul(a.x, b.x);
  return vec2<u32>(low.x, low.y + a.x * b.y + a.y * b.x);
}
fn spiral_u64_lt(a: vec2<u32>, b: vec2<u32>) -> bool { return a.y < b.y || (a.y == b.y && a.x < b.x); }
fn spiral_i64_lt(a: vec2<u32>, b: vec2<u32>) -> bool {
  let sa = bitcast<i32>(a.y);
  let sb = bitcast<i32>(b.y);
  return sa < sb || (sa == sb && a.x < b.x);
}
fn spiral_w64_shl(a: vec2<u32>, n: u32) -> vec2<u32> {
  let k = n & 63u;
  if (k == 0u) { return a; }
  if (k >= 32u) { return vec2<u32>(0u, a.x << (k - 32u)); }
  return vec2<u32>(a.x << k, (a.y << k) | (a.x >> (32u - k)));
}
fn spiral_u64_shr(a: vec2<u32>, n: u32) -> vec2<u32> {
  let k = n & 63u;
  if (k == 0u) { return a; }
  if (k >= 32u) { return vec2<u32>(a.y >> (k - 32u), 0u); }
  return vec2<u32>((a.x >> k) | (a.y << (32u - k)), a.y >> k);
}
fn spiral_i64_shr(a: vec2<u32>, n: u32) -> vec2<u32> {
  let k = n & 63u;
  let high = bitcast<i32>(a.y);
  if (k == 0u) { return a; }
  if (k >= 32u) { return vec2<u32>(bitcast<u32>(high >> (k - 32u)), select(0u, 0xFFFFFFFFu, high < 0i)); }
  return vec2<u32>((a.x >> k) | (a.y << (32u - k)), bitcast<u32>(high >> k));
}
fn spiral_u64_divmod(a: vec2<u32>, b: vec2<u32>) -> SpiralW64DivMod {
  var q = vec2<u32>(0u, 0u);
  var r = vec2<u32>(0u, 0u);
  for (var i = 63i; i >= 0i; i = i - 1i) {
    r = spiral_w64_shl(r, 1u);
    let word = select(a.x, a.y, i >= 32i);
    r.x = r.x | ((word >> (u32(i) & 31u)) & 1u);
    if (!spiral_u64_lt(r, b)) {
      r = spiral_w64_sub(r, b);
      if (i >= 32i) { q.y = q.y | (1u << (u32(i) - 32u)); } else { q.x = q.x | (1u << u32(i)); }
    }
  }
  return SpiralW64DivMod(q, r);
}
fn spiral_i64_negative(a: vec2<u32>) -> bool { return bitcast<i32>(a.y) < 0i; }
fn spiral_i64_magnitude(a: vec2<u32>) -> vec2<u32> { return select(a, spiral_w64_neg(a), spiral_i64_negative(a)); }
fn spiral_i64_div(a: vec2<u32>, b: vec2<u32>) -> vec2<u32> {
  let q = spiral_u64_divmod(spiral_i64_magnitude(a), spiral_i64_magnitude(b)).q;
  return select(q, spiral_w64_neg(q), spiral_i64_negative(a) != spiral_i64_negative(b));
}
fn spiral_i64_mod(a: vec2<u32>, b: vec2<u32>) -> vec2<u32> {
  let r = spiral_u64_divmod(spiral_i64_magnitude(a), spiral_i64_magnitude(b)).r;
  return select(r, spiral_w64_neg(r), spiral_i64_negative(a));
}
fn spiral_w64_of_f32(v: f32, is_signed: bool) -> vec2<u32> {
  let m = abs(trunc(v));
  let hi = floor(m / 4294967296.0f);
  let magnitude = vec2<u32>(u32(m - hi * 4294967296.0f), u32(hi));
  return select(magnitude, spiral_w64_neg(magnitude), is_signed && v < 0.0f);
}
fn spiral_f32_of_w64(a: vec2<u32>, is_signed: bool) -> f32 {
  let negative = is_signed && spiral_i64_negative(a);
  let m = select(a, spiral_w64_neg(a), negative);
  let v = f32(m.y) * 4294967296.0f + f32(m.x);
  return select(v, -v, negative);
}
fn spiral_main() -> i32 {
    var v0: vec2<u32> = vec2<u32>(0u, 0u);
    v0 = vec2<u32>(705032704u, 1u);
    var v1: vec2<u32> = vec2<u32>(0u, 0u);
    v1 = vec2<u32>(4294967292u, 4294967295u);
    var v2: vec2<u32> = vec2<u32>(0u, 0u);
    v2 = spiral_i64_div(v0, v1);
    var v3: vec2<u32> = vec2<u32>(0u, 0u);
    v3 = vec2<u32>(1000000u, 0u);
    var v4: vec2<u32> = vec2<u32>(0u, 0u);
    v4 = spiral_w64_mul(v3, v3);
    var v5: vec2<u32> = vec2<u32>(0u, 0u);
    v5 = vec2<u32>(4294967288u, 4294967295u);
    var v6: vec2<u32> = vec2<u32>(0u, 0u);
    v6 = spiral_i64_shr(v5, bitcast<u32>(1i));
    var v7: i32 = 0i;
    v7 = 7i;
    var v8: vec2<u32> = vec2<u32>(0u, 0u);
    v8 = vec2<u32>(bitcast<u32>(v7), select(0u, 0xFFFFFFFFu, v7 < 0i));
    var v9: vec2<u32> = vec2<u32>(0u, 0u);
    v9 = vec2<u32>(9u, 0u);
    var v10: i32 = 0i;
    v10 = bitcast<i32>(v9.x);
    var v11: vec2<u32> = vec2<u32>(0u, 0u);
    v11 = vec2<u32>(0u, 1u);
    var v12: vec2<u32> = vec2<u32>(0u, 0u);
    v12 = spiral_w64_add(v11, vec2<u32>(1u, 0u));
    var v13: vec2<u32> = vec2<u32>(0u, 0u);
    v13 = spiral_u64_shr(v11, bitcast<u32>(1i));
    var v14: vec2<u32> = vec2<u32>(0u, 0u);
    v14 = vec2<u32>(bitcast<u32>(v7), select(0u, 0xFFFFFFFFu, v7 < 0i));
    var v15: bool = false;
    v15 = all(v2 == vec2<u32>(3044967296u, 4294967295u));
    var v17: bool = false;
    if (v15) {
        var v16: bool = false;
        v16 = all(v4 == vec2<u32>(3567587328u, 232u));
        v17 = v16;
    } else {
        v17 = false;
    }
    var v19: bool = false;
    if (v17) {
        var v18: bool = false;
        v18 = all(v6 == vec2<u32>(4294967292u, 4294967295u));
        v19 = v18;
    } else {
        v19 = false;
    }
    var v21: bool = false;
    if (v19) {
        var v20: bool = false;
        v20 = all(v8 == vec2<u32>(7u, 0u));
        v21 = v20;
    } else {
        v21 = false;
    }
    var v23: bool = false;
    if (v21) {
        var v22: bool = false;
        v22 = (v10 == 9i);
        v23 = v22;
    } else {
        v23 = false;
    }
    var v25: bool = false;
    if (v23) {
        var v24: bool = false;
        v24 = all(v12 == vec2<u32>(1u, 1u));
        v25 = v24;
    } else {
        v25 = false;
    }
    var v27: bool = false;
    if (v25) {
        var v26: bool = false;
        v26 = all(v13 == vec2<u32>(2147483648u, 0u));
        v27 = v26;
    } else {
        v27 = false;
    }
    var v29: bool = false;
    if (v27) {
        var v28: bool = false;
        v28 = all(v14 == vec2<u32>(7u, 0u));
        v29 = v28;
    } else {
        v29 = false;
    }
    if (v29) {
        return 0i;
    } else {
        return 1i;
    }
}
@compute @workgroup_size(64)
fn main(@builtin(global_invocation_id) invocation: vec3<u32>) {
  let lane_count = max(spiral_io.lanes, 1u);
  let lane = spiral_io.lane_base + invocation.x;
  if (lane >= lane_count) { return; }
  spiral_lane = lane;
  let result = spiral_main();
  spiral_results[spiral_lane] = result;
  if (spiral_lane == 0u) { spiral_io.code = result; }
}
