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
fn spiral_main() -> i32 {
    var v0: bool = false;
    v0 = true;
    var v5: u32 = 0u;
    if (v0) {
        var v1: u32 = 0u;
        let spiral_t1 = spiral_array_create(1i, 1u);
        spiral_heap[spiral_t1 + 1u + 0u] = 1u;
        v1 = spiral_t1;
        var v2: u32 = 0u;
        let spiral_t2 = spiral_array_create(1i, 2u);
        spiral_heap[spiral_t2 + 1u + 0u] = 0u;
        spiral_heap[spiral_t2 + 1u + 1u] = v1;
        v2 = spiral_t2;
        let spiral_t3 = spiral_array_create(1i, 2u);
        spiral_heap[spiral_t3 + 1u + 0u] = 0u;
        spiral_heap[spiral_t3 + 1u + 1u] = v2;
        v5 = spiral_t3;
    } else {
        let spiral_t4 = spiral_array_create(1i, 1u);
        spiral_heap[spiral_t4 + 1u + 0u] = 1u;
        v5 = spiral_t4;
    }
    if (spiral_heap[v5 + 1u + 0u] == 0u) {
        var v6: u32 = spiral_heap[v5 + 1u + 1u];
        return 0i;
    } else {
        return 0i;
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
  spiral_heap_end = spiral_heap_top + heap_words;
  let result = spiral_main();
  spiral_results[spiral_lane] = result;
  if (spiral_lane == 0u) { spiral_io.code = result; }
}
