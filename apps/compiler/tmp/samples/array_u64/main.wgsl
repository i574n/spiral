struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
@group(0) @binding(1) var<storage, read_write> spiral_heap: array<u32>;
var<private> spiral_heap_top: u32 = 0u;
fn spiral_array_create(length: i32, stride: u32) -> u32 {
  let base = spiral_heap_top;
  spiral_heap[base] = bitcast<u32>(length);
  spiral_heap_top = base + 1u + bitcast<u32>(length) * stride;
  return base;
}
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
    var v0: u32 = 0u;
    v0 = spiral_array_create(1i, 2u);
    var v1: vec2<u32> = vec2<u32>(0u, 0u);
    v1 = vec2<u32>(1u, 1u);
    spiral_heap[v0 + 1u + bitcast<u32>(0i) * 2u + 0u] = v1.x; spiral_heap[v0 + 1u + bitcast<u32>(0i) * 2u + 1u] = v1.y;
    var v2: vec2<u32> = vec2<u32>(0u, 0u);
    v2 = vec2<u32>(spiral_heap[v0 + 1u + bitcast<u32>(0i) * 2u + 0u], spiral_heap[v0 + 1u + bitcast<u32>(0i) * 2u + 1u]);
    var v3: bool = false;
    v3 = all(v2 == vec2<u32>(1u, 1u));
    if (v3) {
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
  let heap_words = select(arrayLength(&spiral_heap) / lane_count, spiral_io.heap_words_per_lane, spiral_io.heap_words_per_lane > 0u);
  spiral_heap_top = invocation.x * heap_words;
  let result = spiral_main();
  spiral_results[spiral_lane] = result;
  if (spiral_lane == 0u) { spiral_io.code = result; }
}
