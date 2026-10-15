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
  c0f2: i32,
}
fn sp_walk_0(p0: i32) -> i32 {
    var v0: i32 = p0;
    var v1: bool = false;
    v1 = (v0 > 2i);
    var v6: SpiralUnion0 = SpiralUnion0();
    if (v1) {
        var v2: i32 = 0i;
        v2 = (v0 + 1i);
        var v3: i32 = 0i;
        v3 = (v0 + 2i);
        v6 = SpiralUnion0(0u, v0, v2, v3);
    } else {
        v6 = SpiralUnion0(0u, 0i, 1i, 2i);
    }
    var v7: i32 = v6.c0f0;
    var v8: i32 = v6.c0f1;
    var v9: i32 = v6.c0f2;
    var v10: i32 = 0i;
    v10 = (v8 * v9);
    return (v7 + v10);
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 5i;
    var v1: i32 = 0i;
    v1 = sp_walk_0(v0);
    var v2: i32 = 0i;
    v2 = (v0 - 4i);
    var v3: i32 = 0i;
    v3 = sp_walk_0(v2);
    return (v1 + v3);
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
