struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
struct SpiralUnion0 {
  tag: u32,
  c0f0: i32,
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 3i;
    var v1: SpiralUnion0 = SpiralUnion0();
    v1 = SpiralUnion0(0u, v0);
    var v2: SpiralUnion0 = SpiralUnion0();
    v2 = SpiralUnion0(1u, 0i);
    var v5: i32 = 0i;
    if (v1.tag == 0u) {
        var v3: i32 = v1.c0f0;
        v5 = v3;
    } else {
        v5 = 40i;
    }
    var v8: i32 = 0i;
    if (v2.tag == 0u) {
        var v6: i32 = v2.c0f0;
        v8 = v6;
    } else {
        v8 = 40i;
    }
    return (v5 + v8);
}
@compute @workgroup_size(64)
fn main(@builtin(global_invocation_id) invocation: vec3<u32>) {
  let lane_count = max(spiral_io.lanes, 1u);
  let lane = spiral_io.lane_base + invocation.x;
  if (lane >= lane_count) { return; }
  spiral_lane = lane;
  let result = spiral_main();
  spiral_results[spiral_lane] = result;
  if (spiral_lane == 0u) { spiral_io.code = result; }
}
