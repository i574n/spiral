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
  c1f0: i32,
}
struct SpiralUnion1 {
  tag: u32,
  c0f0: SpiralUnion0,
  c1f0: i32,
}
fn sp_score_inner_1(p0: SpiralUnion0) -> i32 {
    var v0: SpiralUnion0 = p0;
    if (v0.tag == 0u) {
        var v1: i32 = v0.c0f0;
        return v1;
    } else {
        var v2: i32 = v0.c1f0;
        return (-v2);
    }
}
fn sp_score_0(p0: SpiralUnion1) -> i32 {
    var v0: SpiralUnion1 = p0;
    if (v0.tag == 0u) {
        var v1: SpiralUnion0 = v0.c0f0;
        return sp_score_inner_1(v1);
    } else {
        var v3: i32 = v0.c1f0;
        return v3;
    }
}
fn spiral_main() -> i32 {
    var v0: bool = false;
    v0 = true;
    var v4: SpiralUnion1 = SpiralUnion1();
    if (v0) {
        var v1: SpiralUnion0 = SpiralUnion0();
        v1 = SpiralUnion0(0u, 7i, 0i);
        v4 = SpiralUnion1(0u, v1, 0i);
    } else {
        v4 = SpiralUnion1(1u, SpiralUnion0(), 1i);
    }
    var v8: SpiralUnion1 = SpiralUnion1();
    if (v0) {
        v8 = SpiralUnion1(1u, SpiralUnion0(), 4i);
    } else {
        var v6: SpiralUnion0 = SpiralUnion0();
        v6 = SpiralUnion0(1u, 0i, 2i);
        v8 = SpiralUnion1(0u, v6, 0i);
    }
    var v9: i32 = 0i;
    v9 = sp_score_0(v4);
    var v10: bool = false;
    v10 = (v9 == 7i);
    var v13: bool = false;
    if (v10) {
        var v11: i32 = 0i;
        v11 = sp_score_0(v8);
        var v12: bool = false;
        v12 = (v11 == 4i);
        v13 = v12;
    } else {
        v13 = false;
    }
    if (v13) {
        return 0i;
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
  let result = spiral_main();
  spiral_results[spiral_lane] = result;
  if (spiral_lane == 0u) { spiral_io.code = result; }
}
