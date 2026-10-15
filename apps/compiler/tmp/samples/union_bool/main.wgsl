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
  c0f0: bool,
  c1f0: i32,
}
fn sp_score_0(p0: SpiralUnion0) -> i32 {
    var v0: SpiralUnion0 = p0;
    if (v0.tag == 0u) {
        var v1: bool = v0.c0f0;
        if (v1) {
            return 1i;
        } else {
            return 2i;
        }
    } else {
        var v3: i32 = v0.c1f0;
        return v3;
    }
}
fn spiral_main() -> i32 {
    var v0: bool = false;
    v0 = true;
    var v3: SpiralUnion0 = SpiralUnion0();
    if (v0) {
        v3 = SpiralUnion0(1u, false, 7i);
    } else {
        v3 = SpiralUnion0(0u, false, 0i);
    }
    var v6: SpiralUnion0 = SpiralUnion0();
    if (v0) {
        v6 = SpiralUnion0(0u, true, 0i);
    } else {
        v6 = SpiralUnion0(1u, false, 1i);
    }
    var v7: i32 = 0i;
    v7 = sp_score_0(v3);
    var v8: bool = false;
    v8 = (v7 == 7i);
    var v11: bool = false;
    if (v8) {
        var v9: i32 = 0i;
        v9 = sp_score_0(v6);
        var v10: bool = false;
        v10 = (v9 == 1i);
        v11 = v10;
    } else {
        v11 = false;
    }
    if (v11) {
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
