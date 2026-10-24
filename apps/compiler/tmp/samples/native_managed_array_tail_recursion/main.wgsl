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
fn sp_method1(p0: i32, p1: u32, p2: u32) -> u32 {
    var v0: i32 = p0;
    var v1: u32 = p1;
    var v2: u32 = p2;
    loop {
        var v3: i32 = 0i;
        v3 = (v0 - 1i);
        var v4: bool = false;
        v4 = (v3 == 0i);
        if (v4) {
            return v2;
        } else {
            v0 = v3;
            let spiral_t1: u32 = v1;
            v1 = v2;
            v2 = spiral_t1;
            continue;
        }
    }
    return 0u;
}
fn sp_method0(p0: u32, p1: u32) -> u32 {
    var v0: u32 = p0;
    var v1: u32 = p1;
    var v2: i32 = 0i;
    v2 = 1000000i;
    var v3: bool = false;
    v3 = (v2 == 0i);
    if (v3) {
        return v0;
    } else {
        return sp_method1(v2, v0, v1);
    }
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 1i;
    var v1: u32 = 0u;
    v1 = spiral_array_create(v0, 1u);
    var v2: u32 = 0u;
    v2 = spiral_array_create(v0, 1u);
    spiral_heap[v1 + 1u + bitcast<u32>(0i) * 1u + 0u] = bitcast<u32>(7i);
    spiral_heap[v2 + 1u + bitcast<u32>(0i) * 1u + 0u] = bitcast<u32>(11i);
    var v3: u32 = 0u;
    v3 = sp_method0(v1, v2);
    spiral_heap[v3 + 1u + bitcast<u32>(0i) * 1u + 0u] = bitcast<u32>(13i);
    var v4: i32 = 0i;
    v4 = bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(0i) * 1u + 0u]);
    var v5: bool = false;
    v5 = (v4 == 13i);
    if (v5) {
        var v6: i32 = 0i;
        v6 = bitcast<i32>(spiral_heap[v2 + 1u + bitcast<u32>(0i) * 1u + 0u]);
        var v7: bool = false;
        v7 = (v6 == 11i);
        if (v7) {
            return 0i;
        } else {
            return 2i;
        }
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
