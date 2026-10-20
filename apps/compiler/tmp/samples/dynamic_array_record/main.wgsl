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
struct SpiralTuple0 {
  v0: u32,
  v1: i32,
}
fn sp_method0() -> SpiralTuple0 {
    var v0: i32 = 0i;
    v0 = 2i;
    var v1: u32 = 0u;
    v1 = spiral_array_create(v0, 1u);
    spiral_heap[v1 + 1u + bitcast<u32>(0i) * 1u + 0u] = bitcast<u32>(4i);
    spiral_heap[v1 + 1u + bitcast<u32>(1i) * 1u + 0u] = bitcast<u32>(5i);
    return SpiralTuple0(v1, 1i);
}
fn sp_method1(p0: u32, p1: i32) -> i32 {
    var v0: u32 = p0;
    var v1: i32 = p1;
    var v2: i32 = 0i;
    v2 = bitcast<i32>(spiral_heap[v0 + 1u + bitcast<u32>(0i) * 1u + 0u]);
    var v3: i32 = 0i;
    v3 = bitcast<i32>(spiral_heap[v0 + 1u + bitcast<u32>(1i) * 1u + 0u]);
    var v4: i32 = 0i;
    v4 = (v2 + v3);
    var v5: i32 = 0i;
    v5 = (v4 + v1);
    return (v5 - 10i);
}
fn spiral_main() -> i32 {
    var v0: u32 = 0u;
    var v1: i32 = 0i;
    let spiral_tuple1 = sp_method0();
    v0 = spiral_tuple1.v0;
    v1 = spiral_tuple1.v1;
    return sp_method1(v0, v1);
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
