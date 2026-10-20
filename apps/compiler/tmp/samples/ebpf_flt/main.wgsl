struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
fn spiral_main() -> i32 {
    var v0: f32 = 0.0f;
    v0 = -2.0f;
    var v1: f32 = 0.0f;
    v1 = -1.0f;
    var v2: f32 = 0.0f;
    v2 = 0.0f;
    var v3: bool = false;
    v3 = (v0 < v1);
    var v5: bool = false;
    if (v3) {
        var v4: bool = false;
        v4 = (v1 < v2);
        v5 = v4;
    } else {
        v5 = false;
    }
    var v8: bool = false;
    if (v5) {
        var v6: bool = false;
        v6 = (v0 > v1);
        var v7: bool = false;
        v7 = (v6 == false);
        v8 = v7;
    } else {
        v8 = false;
    }
    var v11: bool = false;
    if (v8) {
        var v9: bool = false;
        v9 = (v0 >= v1);
        var v10: bool = false;
        v10 = (v9 == false);
        v11 = v10;
    } else {
        v11 = false;
    }
    var v13: bool = false;
    if (v11) {
        var v12: bool = false;
        v12 = (v1 <= v2);
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
