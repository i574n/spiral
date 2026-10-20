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
    v0 = 7i;
    var v1: i32 = 0i;
    v1 = -2i;
    var v2: i32 = 0i;
    v2 = -7i;
    var v3: u32 = 0u;
    v3 = 100u;
    var v4: u32 = 0u;
    v4 = 7u;
    var v5: i32 = 0i;
    v5 = (v0 / v1);
    var v6: i32 = 0i;
    v6 = (v0 % v1);
    var v7: i32 = 0i;
    v7 = (v2 / v1);
    var v8: i32 = 0i;
    v8 = (v2 % v1);
    var v9: u32 = 0u;
    v9 = (v3 / v4);
    var v10: u32 = 0u;
    v10 = (v3 % v4);
    var v11: bool = false;
    v11 = (v5 == -3i);
    var v13: bool = false;
    if (v11) {
        var v12: bool = false;
        v12 = (v6 == 1i);
        v13 = v12;
    } else {
        v13 = false;
    }
    var v15: bool = false;
    if (v13) {
        var v14: bool = false;
        v14 = (v7 == 3i);
        v15 = v14;
    } else {
        v15 = false;
    }
    var v17: bool = false;
    if (v15) {
        var v16: bool = false;
        v16 = (v8 == -1i);
        v17 = v16;
    } else {
        v17 = false;
    }
    var v19: bool = false;
    if (v17) {
        var v18: bool = false;
        v18 = (v9 == 14u);
        v19 = v18;
    } else {
        v19 = false;
    }
    var v21: bool = false;
    if (v19) {
        var v20: bool = false;
        v20 = (v10 == 2u);
        v21 = v20;
    } else {
        v21 = false;
    }
    if (v21) {
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
