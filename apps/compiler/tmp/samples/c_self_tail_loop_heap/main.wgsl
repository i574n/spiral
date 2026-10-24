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
fn sp_loop_0(p0: i32, p1: u32, p2: i32, p3: i32, p4: i32) -> i32 {
    var v0: i32 = p0;
    var v1: u32 = p1;
    var v2: i32 = p2;
    var v3: i32 = p3;
    var v4: i32 = p4;
    loop {
        var v5: bool = false;
        v5 = (v3 >= v0);
        if (v5) {
            return v4;
        } else {
            var v6: i32 = 0i;
            v6 = (v3 % 4i);
            var v7: i32 = 0i;
            v7 = bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(v6) * 1u + 0u]);
            var v8: i32 = 0i;
            v8 = (v3 + 1i);
            var v9: i32 = 0i;
            v9 = (v4 * 7i);
            var v10: i32 = 0i;
            v10 = (v9 + v7);
            var v11: i32 = 0i;
            v11 = (v10 + v2);
            var v12: i32 = 0i;
            v12 = (v11 % 9973i);
            v3 = v8;
            v4 = v12;
            continue;
        }
    }
    return 0i;
}
fn spiral_main() -> i32 {
    var v0: u32 = 0u;
    v0 = spiral_array_create(4i, 1u);
    spiral_heap[v0 + 1u + bitcast<u32>(0i) * 1u + 0u] = bitcast<u32>(1i);
    spiral_heap[v0 + 1u + bitcast<u32>(1i) * 1u + 0u] = bitcast<u32>(2i);
    spiral_heap[v0 + 1u + bitcast<u32>(2i) * 1u + 0u] = bitcast<u32>(3i);
    spiral_heap[v0 + 1u + bitcast<u32>(3i) * 1u + 0u] = bitcast<u32>(4i);
    var v1: i32 = 0i;
    v1 = 0i;
    var v2: i32 = 0i;
    v2 = 1000000i;
    var v3: i32 = 0i;
    v3 = 0i;
    var v4: i32 = 0i;
    v4 = 0i;
    var v5: i32 = 0i;
    v5 = sp_loop_0(v2, v0, v1, v3, v4);
    return (v5 % 256i);
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
