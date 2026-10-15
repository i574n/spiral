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
  c0f1: i32,
}
struct SpiralUnion1 {
  tag: u32,
  c1f0: i32,
}
struct SpiralUnion2 {
  tag: u32,
  c0f0: SpiralUnion0,
  c1f0: SpiralUnion1,
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 60i;
    var v1: bool = false;
    v1 = (v0 > 0i);
    var v6: SpiralUnion2 = SpiralUnion2();
    if (v1) {
        var v2: SpiralUnion0 = SpiralUnion0();
        v2 = SpiralUnion0(0u, v0, 100i);
        v6 = SpiralUnion2(0u, v2, SpiralUnion1());
    } else {
        var v4: SpiralUnion1 = SpiralUnion1();
        v4 = SpiralUnion1(1u, 100i);
        v6 = SpiralUnion2(1u, SpiralUnion0(), v4);
    }
    if (v6.tag == 0u) {
        var v7: SpiralUnion0 = v6.c0f0;
        var v8: i32 = v7.c0f0;
        var v9: i32 = v7.c0f1;
        var v10: bool = false;
        v10 = (v8 == 60i);
        if (v10) {
            return 0i;
        } else {
            return 1i;
        }
    } else {
        var v13: SpiralUnion1 = v6.c1f0;
        return 2i;
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
