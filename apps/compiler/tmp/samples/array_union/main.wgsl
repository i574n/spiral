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
  c1f0: i32,
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 2i;
    var v1: u32 = 0u;
    v1 = spiral_array_create(v0, 2u);
    var v2: i32 = 0i;
    v2 = 7i;
    var v3: SpiralUnion0 = SpiralUnion0();
    v3 = SpiralUnion0(1u, v2);
    spiral_heap[v1 + 1u + bitcast<u32>(0i) * 2u + 0u] = v3.tag; spiral_heap[v1 + 1u + bitcast<u32>(0i) * 2u + 1u] = bitcast<u32>(v3.c1f0);
    var v4: SpiralUnion0 = SpiralUnion0();
    v4 = SpiralUnion0(0u, 0i);
    spiral_heap[v1 + 1u + bitcast<u32>(1i) * 2u + 0u] = v4.tag; spiral_heap[v1 + 1u + bitcast<u32>(1i) * 2u + 1u] = bitcast<u32>(v4.c1f0);
    var v5: SpiralUnion0 = SpiralUnion0();
    v5 = SpiralUnion0(spiral_heap[v1 + 1u + bitcast<u32>(0i) * 2u + 0u], bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(0i) * 2u + 1u]));
    if (v5.tag == 0u) {
        return 1i;
    } else {
        var v6: i32 = v5.c1f0;
        var v7: SpiralUnion0 = SpiralUnion0();
        v7 = SpiralUnion0(spiral_heap[v1 + 1u + bitcast<u32>(1i) * 2u + 0u], bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(1i) * 2u + 1u]));
        if (v7.tag == 0u) {
            var v8: bool = false;
            v8 = (v6 == 7i);
            if (v8) {
                return 0i;
            } else {
                return 1i;
            }
        } else {
            var v10: i32 = v7.c1f0;
            return 1i;
        }
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
