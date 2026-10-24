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
    v0 = 100i;
    var v1: i32 = 0i;
    v1 = (((v0 + v0) << 24u) >> 24u);
    var v2: u32 = 0u;
    v2 = 200u;
    var v3: u32 = 0u;
    v3 = 100u;
    var v4: u32 = 0u;
    v4 = ((v2 + v3) & 0xFFu);
    var v5: i32 = 0i;
    v5 = -8i;
    var v6: i32 = 0i;
    v6 = (v5 >> bitcast<u32>(1i));
    var v7: u32 = 0u;
    v7 = (v2 >> bitcast<u32>(1i));
    var v8: i32 = 0i;
    v8 = 20000i;
    var v9: i32 = 0i;
    v9 = (((v8 + v8) << 16u) >> 16u);
    var v10: u32 = 0u;
    v10 = 40000u;
    var v11: u32 = 0u;
    v11 = ((v10 + v10) & 0xFFFFu);
    var v12: i32 = 0i;
    v12 = 7i;
    var v13: i32 = 0i;
    v13 = ((v12 << 24u) >> 24u);
    var v14: i32 = 0i;
    v14 = 9i;
    var v15: i32 = 0i;
    v15 = v14;
    var v16: bool = false;
    v16 = (v1 == -56i);
    var v18: bool = false;
    if (v16) {
        var v17: bool = false;
        v17 = (v4 == 44u);
        v18 = v17;
    } else {
        v18 = false;
    }
    var v20: bool = false;
    if (v18) {
        var v19: bool = false;
        v19 = (v6 == -4i);
        v20 = v19;
    } else {
        v20 = false;
    }
    var v22: bool = false;
    if (v20) {
        var v21: bool = false;
        v21 = (v7 == 100u);
        v22 = v21;
    } else {
        v22 = false;
    }
    var v24: bool = false;
    if (v22) {
        var v23: bool = false;
        v23 = (v9 == -25536i);
        v24 = v23;
    } else {
        v24 = false;
    }
    var v26: bool = false;
    if (v24) {
        var v25: bool = false;
        v25 = (v11 == 14464u);
        v26 = v25;
    } else {
        v26 = false;
    }
    var v28: bool = false;
    if (v26) {
        var v27: bool = false;
        v27 = (v13 == 7i);
        v28 = v27;
    } else {
        v28 = false;
    }
    var v30: bool = false;
    if (v28) {
        var v29: bool = false;
        v29 = (v15 == 9i);
        v30 = v29;
    } else {
        v30 = false;
    }
    if (v30) {
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
