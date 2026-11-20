struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
  heap_overflow: atomic<u32>,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
@group(0) @binding(1) var<storage, read_write> spiral_heap: array<u32>;
var<private> spiral_heap_top: u32 = 0u;
var<private> spiral_heap_end: u32 = 0u;
fn spiral_array_create(length: i32, stride: u32) -> u32 {
  let base = spiral_heap_top;
  let next = base + 1u + bitcast<u32>(length) * stride;
  if (next > spiral_heap_end || next < base) { atomicAdd(&spiral_io.heap_overflow, 1u); }
  if (base < spiral_heap_end) { spiral_heap[base] = bitcast<u32>(length); }
  spiral_heap_top = next;
  return base;
}
fn sp_build_0(p0: i32, p1: u32) -> u32 {
    var v0: i32 = p0;
    var v1: u32 = p1;
    loop {
        var v2: bool = false;
        v2 = (v0 == 0i);
        if (v2) {
            return v1;
        } else {
            var v3: i32 = 0i;
            v3 = (v0 - 1i);
            var v4: u32 = 0u;
            let spiral_t2 = spiral_array_create(1i, 3u);
            spiral_heap[spiral_t2 + 1u + 0u] = 0u;
            spiral_heap[spiral_t2 + 1u + 1u] = bitcast<u32>(v0); spiral_heap[spiral_t2 + 1u + 2u] = v1;
            v4 = spiral_t2;
            v0 = v3;
            v1 = v4;
            continue;
        }
    }
    return 0u;
}
fn sp_sum_1(p0: u32, p1: i32) -> i32 {
    var v0: u32 = p0;
    var v1: i32 = p1;
    loop {
        if (spiral_heap[v0 + 1u + 0u] == 0u) {
            var v2: i32 = bitcast<i32>(spiral_heap[v0 + 1u + 1u]);
            var v3: u32 = spiral_heap[v0 + 1u + 2u];
            var v4: i32 = 0i;
            v4 = (v1 * 31i);
            var v5: i32 = 0i;
            v5 = (v4 + v2);
            var v6: i32 = 0i;
            v6 = (v5 % 9973i);
            v0 = v3;
            v1 = v6;
            continue;
        } else {
            return v1;
        }
    }
    return 0i;
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 1000000i;
    var v1: u32 = 0u;
    let spiral_t1 = spiral_array_create(1i, 1u);
    spiral_heap[spiral_t1 + 1u + 0u] = 1u;
    v1 = spiral_t1;
    var v2: u32 = 0u;
    v2 = sp_build_0(v0, v1);
    var v3: i32 = 0i;
    v3 = 0i;
    var v4: i32 = 0i;
    v4 = sp_sum_1(v2, v3);
    return (v4 % 256i);
}
@compute @workgroup_size(64)
fn main(@builtin(global_invocation_id) invocation: vec3<u32>) {
  let lane_count = max(spiral_io.lanes, 1u);
  let lane = spiral_io.lane_base + invocation.x;
  if (lane >= lane_count) { return; }
  spiral_lane = lane;
  let heap_words = select(arrayLength(&spiral_heap) / lane_count, spiral_io.heap_words_per_lane, spiral_io.heap_words_per_lane > 0u);
  spiral_heap_top = invocation.x * heap_words;
  spiral_heap_end = spiral_heap_top + heap_words;
  let result = spiral_main();
  spiral_results[spiral_lane] = result;
  if (spiral_lane == 0u) { spiral_io.code = result; }
}
