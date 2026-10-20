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
struct SpiralUnion0 {
  tag: u32,
  c1f0: u32,
}
fn sp_score_0(p0: SpiralUnion0) -> i32 {
    var v0: SpiralUnion0 = p0;
    if (v0.tag == 0u) {
        return 0i;
    } else {
        var v1: u32 = v0.c1f0;
        var v2: i32 = 0i;
        v2 = bitcast<i32>(spiral_heap[v1]);
        var v3: i32 = 0i;
        v3 = bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(0i) * 1u + 0u]);
        var v4: i32 = 0i;
        v4 = (v2 + v3);
        var v5: i32 = 0i;
        v5 = bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(1i) * 1u + 0u]);
        return (v4 + v5);
    }
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 2i;
    var v1: u32 = 0u;
    v1 = spiral_array_create(v0, 1u);
    spiral_heap[v1 + 1u + bitcast<u32>(0i) * 1u + 0u] = bitcast<u32>(4i);
    spiral_heap[v1 + 1u + bitcast<u32>(1i) * 1u + 0u] = bitcast<u32>(5i);
    var v2: SpiralUnion0 = SpiralUnion0();
    v2 = SpiralUnion0(1u, v1);
    var v3: i32 = 0i;
    v3 = sp_score_0(v2);
    return (v3 - 11i);
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
