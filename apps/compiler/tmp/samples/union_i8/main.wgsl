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
  c1f0: i32,
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 100i;
    var v1: bool = false;
    v1 = true;
    var v4: SpiralUnion0 = SpiralUnion0();
    if (v1) {
        v4 = SpiralUnion0(1u, v0);
    } else {
        v4 = SpiralUnion0(0u, 0i);
    }
    if (v4.tag == 0u) {
        return 1i;
    } else {
        var v5: i32 = v4.c1f0;
        var v6: bool = false;
        v6 = (v5 == 100i);
        if (v6) {
            return 0i;
        } else {
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
  let result = spiral_main();
  spiral_results[spiral_lane] = result;
  if (spiral_lane == 0u) { spiral_io.code = result; }
}
