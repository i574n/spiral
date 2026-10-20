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
    var v0: i32 = 0i;
    v0 = 3i;
    var v1: i32 = 0i;
    v1 = -2i;
    var v2: u32 = 0u;
    v2 = 7u;
    var v3: f32 = 0.0f;
    v3 = 2.9f;
    var v4: f32 = 0.0f;
    v4 = f32(v0);
    var v5: f32 = 0.0f;
    v5 = f32(v1);
    var v6: f32 = 0.0f;
    v6 = f32(v2);
    var v7: u32 = 0u;
    v7 = u32(v3);
    var v8: bool = false;
    v8 = (v4 == 3.0f);
    var v10: bool = false;
    if (v8) {
        var v9: bool = false;
        v9 = (v5 == -2.0f);
        v10 = v9;
    } else {
        v10 = false;
    }
    var v12: bool = false;
    if (v10) {
        var v11: bool = false;
        v11 = (v6 == 7.0f);
        v12 = v11;
    } else {
        v12 = false;
    }
    var v14: bool = false;
    if (v12) {
        var v13: bool = false;
        v13 = (v7 == 2u);
        v14 = v13;
    } else {
        v14 = false;
    }
    if (v14) {
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
