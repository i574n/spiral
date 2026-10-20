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
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 2i;
    var v1: u32 = 0u;
    v1 = spiral_array_create(v0, 1u);
    var v2: u32 = 0u;
    v2 = spiral_array_create(v0, 1u);
    var v3: u32 = 0u;
    v3 = spiral_array_create(v0, 1u);
    spiral_heap[v2 + 1u + bitcast<u32>(0i) * 1u + 0u] = bitcast<u32>(3i);
    spiral_heap[v2 + 1u + bitcast<u32>(1i) * 1u + 0u] = bitcast<u32>(4i);
    spiral_heap[v3 + 1u + bitcast<u32>(0i) * 1u + 0u] = bitcast<u32>(5i);
    spiral_heap[v3 + 1u + bitcast<u32>(1i) * 1u + 0u] = bitcast<u32>(6i);
    spiral_heap[v1 + 1u + bitcast<u32>(0i) * 1u + 0u] = v2;
    spiral_heap[v1 + 1u + bitcast<u32>(1i) * 1u + 0u] = v3;
    var v4: u32 = 0u;
    v4 = spiral_heap[v1 + 1u + bitcast<u32>(0i) * 1u + 0u];
    var v5: u32 = 0u;
    v5 = spiral_heap[v1 + 1u + bitcast<u32>(1i) * 1u + 0u];
    var v6: i32 = 0i;
    v6 = bitcast<i32>(spiral_heap[v4 + 1u + bitcast<u32>(0i) * 1u + 0u]);
    var v7: i32 = 0i;
    v7 = bitcast<i32>(spiral_heap[v4 + 1u + bitcast<u32>(1i) * 1u + 0u]);
    var v8: i32 = 0i;
    v8 = (v6 + v7);
    var v9: i32 = 0i;
    v9 = bitcast<i32>(spiral_heap[v5 + 1u + bitcast<u32>(0i) * 1u + 0u]);
    var v10: i32 = 0i;
    v10 = (v8 + v9);
    var v11: i32 = 0i;
    v11 = bitcast<i32>(spiral_heap[v5 + 1u + bitcast<u32>(1i) * 1u + 0u]);
    var v12: i32 = 0i;
    v12 = (v10 + v11);
    return (v12 - 18i);
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
