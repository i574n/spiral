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
  c2f0: bool,
}
fn sp_score_0(p0: SpiralUnion0) -> i32 {
    var v0: SpiralUnion0 = p0;
    if (v0.tag == 0u) {
        return 3i;
    } else if (v0.tag == 1u) {
        var v1: i32 = v0.c1f0;
        return v1;
    } else {
        var v2: bool = v0.c2f0;
        if (v2) {
            return 11i;
        } else {
            return 5i;
        }
    }
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 2i;
    var v1: bool = false;
    v1 = (v0 == 0i);
    var v7: SpiralUnion0 = SpiralUnion0();
    if (v1) {
        v7 = SpiralUnion0(0u, 0i, false);
    } else {
        var v3: bool = false;
        v3 = (v0 == 1i);
        if (v3) {
            v7 = SpiralUnion0(1u, 7i, false);
        } else {
            v7 = SpiralUnion0(2u, 0i, true);
        }
    }
    var v8: i32 = 0i;
    v8 = sp_score_0(v7);
    return (v8 - 11i);
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
