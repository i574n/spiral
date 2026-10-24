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
    v1 = 3i;
    var v2: i32 = 0i;
    v2 = (((v0 * v1) << 24u) >> 24u);
    var v3: i32 = 0i;
    v3 = -8i;
    var v4: i32 = 0i;
    v4 = 2i;
    var v5: i32 = 0i;
    v5 = (((v3 / v4) << 24u) >> 24u);
    var v6: i32 = 0i;
    v6 = (v3 % v1);
    var v7: i32 = 0i;
    v7 = (((-v1) << 24u) >> 24u);
    var v8: i32 = 0i;
    v8 = (((v0 << bitcast<u32>(1i)) << 24u) >> 24u);
    var v9: u32 = 0u;
    v9 = 200u;
    var v10: u32 = 0u;
    v10 = 3u;
    var v11: u32 = 0u;
    v11 = ((v9 / v10) & 0xFFu);
    var v12: u32 = 0u;
    v12 = (v9 % v10);
    var v13: u32 = 0u;
    v13 = 15u;
    var v14: u32 = 0u;
    v14 = (v9 & v13);
    var v15: u32 = 0u;
    v15 = (v9 | v13);
    var v16: u32 = 0u;
    v16 = (v9 ^ v13);
    var v17: u32 = 0u;
    v17 = ((~v13) & 0xFFu);
    var v18: i32 = 0i;
    v18 = 20000i;
    var v19: i32 = 0i;
    v19 = 7i;
    var v20: i32 = 0i;
    v20 = (((v18 / v19) << 16u) >> 16u);
    var v21: i32 = 0i;
    v21 = (v18 % v19);
    var v22: i32 = 0i;
    v22 = (((-v18) << 16u) >> 16u);
    var v23: u32 = 0u;
    v23 = 40000u;
    var v24: u32 = 0u;
    v24 = ((v23 << bitcast<u32>(1i)) & 0xFFFFu);
    var v25: bool = false;
    v25 = (v2 == 44i);
    var v27: bool = false;
    if (v25) {
        var v26: bool = false;
        v26 = (v5 == -4i);
        v27 = v26;
    } else {
        v27 = false;
    }
    var v29: bool = false;
    if (v27) {
        var v28: bool = false;
        v28 = (v6 == -2i);
        v29 = v28;
    } else {
        v29 = false;
    }
    var v31: bool = false;
    if (v29) {
        var v30: bool = false;
        v30 = (v7 == -3i);
        v31 = v30;
    } else {
        v31 = false;
    }
    var v33: bool = false;
    if (v31) {
        var v32: bool = false;
        v32 = (v8 == -56i);
        v33 = v32;
    } else {
        v33 = false;
    }
    var v35: bool = false;
    if (v33) {
        var v34: bool = false;
        v34 = (v11 == 66u);
        v35 = v34;
    } else {
        v35 = false;
    }
    var v37: bool = false;
    if (v35) {
        var v36: bool = false;
        v36 = (v12 == 2u);
        v37 = v36;
    } else {
        v37 = false;
    }
    var v39: bool = false;
    if (v37) {
        var v38: bool = false;
        v38 = (v14 == 8u);
        v39 = v38;
    } else {
        v39 = false;
    }
    var v41: bool = false;
    if (v39) {
        var v40: bool = false;
        v40 = (v15 == 207u);
        v41 = v40;
    } else {
        v41 = false;
    }
    var v43: bool = false;
    if (v41) {
        var v42: bool = false;
        v42 = (v16 == 199u);
        v43 = v42;
    } else {
        v43 = false;
    }
    var v45: bool = false;
    if (v43) {
        var v44: bool = false;
        v44 = (v17 == 240u);
        v45 = v44;
    } else {
        v45 = false;
    }
    var v47: bool = false;
    if (v45) {
        var v46: bool = false;
        v46 = (v20 == 2857i);
        v47 = v46;
    } else {
        v47 = false;
    }
    var v49: bool = false;
    if (v47) {
        var v48: bool = false;
        v48 = (v21 == 1i);
        v49 = v48;
    } else {
        v49 = false;
    }
    var v51: bool = false;
    if (v49) {
        var v50: bool = false;
        v50 = (v22 == -20000i);
        v51 = v50;
    } else {
        v51 = false;
    }
    var v53: bool = false;
    if (v51) {
        var v52: bool = false;
        v52 = (v24 == 14464u);
        v53 = v52;
    } else {
        v53 = false;
    }
    if (v53) {
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
