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
    v0 = 5i;
    var v1: u32 = 0u;
    v1 = spiral_array_create(v0, 1u);
    spiral_heap[v1 + 1u + bitcast<u32>(0i) * 1u + 0u] = bitcast<u32>(0i);
    spiral_heap[v1 + 1u + bitcast<u32>(1i) * 1u + 0u] = bitcast<u32>(1i);
    spiral_heap[v1 + 1u + bitcast<u32>(2i) * 1u + 0u] = bitcast<u32>(4i);
    var v2: i32 = 0i;
    v2 = 3i;
    spiral_heap[v1 + 1u + bitcast<u32>(v2) * 1u + 0u] = bitcast<u32>(9i);
    var v3: i32 = 0i;
    v3 = (v2 + 1i);
    spiral_heap[v1 + 1u + bitcast<u32>(v3) * 1u + 0u] = bitcast<u32>(16i);
    var v4: u32 = 0u;
    v4 = spiral_array_create(3i, 1u);
    spiral_heap[v4 + 1u + bitcast<u32>(0i) * 1u + 0u] = select(0u, 1u, false);
    spiral_heap[v4 + 1u + bitcast<u32>(1i) * 1u + 0u] = select(0u, 1u, true);
    spiral_heap[v4 + 1u + bitcast<u32>(2i) * 1u + 0u] = select(0u, 1u, false);
    var v5: i32 = 0i;
    v5 = bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(1i) * 1u + 0u]);
    var v6: i32 = 0i;
    v6 = bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(2i) * 1u + 0u]);
    var v7: i32 = 0i;
    v7 = (v5 + v6);
    var v8: i32 = 0i;
    v8 = bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(3i) * 1u + 0u]);
    var v9: i32 = 0i;
    v9 = (v7 + v8);
    var v10: i32 = 0i;
    v10 = bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(4i) * 1u + 0u]);
    var v11: i32 = 0i;
    v11 = (v9 + v10);
    var v12: bool = false;
    v12 = (spiral_heap[v4 + 1u + bitcast<u32>(1i) * 1u + 0u] != 0u);
    var v15: i32 = 0i;
    if (v12) {
        var v13: bool = false;
        v13 = (spiral_heap[v4 + 1u + bitcast<u32>(0i) * 1u + 0u] != 0u);
        if (v13) {
            v15 = 0i;
        } else {
            v15 = 100i;
        }
    } else {
        v15 = 0i;
    }
    var v16: i32 = 0i;
    v16 = (v11 + v15);
    var v17: i32 = 0i;
    v17 = bitcast<i32>(spiral_heap[v1]);
    return (v16 + v17);
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
