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
    v0 = bitcast<i32>(0x80000000u);
    var v1: u32 = 0u;
    v1 = 4294967295u;
    var v2: i32 = 0i;
    v2 = -1i;
    var v3: f32 = 0.0f;
    v3 = 0.0f;
    var v4: f32 = 0.0f;
    v4 = 1.9f;
    var v5: f32 = 0.0f;
    v5 = 2.9f;
    var v6: u32 = 0u;
    v6 = 4294967294u;
    var v7: u32 = 0u;
    v7 = 5u;
    var v8: u32 = 0u;
    v8 = 0u;
    var v9: f32 = 0.0f;
    v9 = (v3 - v4);
    var v10: u32 = 0u;
    v10 = bitcast<u32>(v0);
    var v11: i32 = 0i;
    v11 = bitcast<i32>(v10);
    var v12: i32 = 0i;
    v12 = bitcast<i32>(v1);
    var v13: u32 = 0u;
    v13 = bitcast<u32>(v2);
    var v14: i32 = 0i;
    v14 = i32(v9);
    var v15: i32 = 0i;
    v15 = i32(v5);
    var v16: u32 = 0u;
    v16 = (v10 / 2u);
    var v17: u32 = 0u;
    v17 = (v6 / 2u);
    var v18: u32 = 0u;
    v18 = (v7 % 3u);
    var v19: u32 = 0u;
    v19 = (~v8);
    var v20: u32 = 0u;
    v20 = (v1 >> bitcast<u32>(31i));
    var v21: bool = false;
    v21 = (v0 < -1i);
    var v23: bool = false;
    if (v21) {
        var v22: bool = false;
        v22 = (v0 <= v0);
        v23 = v22;
    } else {
        v23 = false;
    }
    var v26: bool = false;
    if (v23) {
        var v24: bool = false;
        v24 = (v0 > 0i);
        var v25: bool = false;
        v25 = (v24 == false);
        v26 = v25;
    } else {
        v26 = false;
    }
    if (v26) {
        var v27: bool = false;
        v27 = (v10 > 1u);
        var v29: bool = false;
        if (v27) {
            var v28: bool = false;
            v28 = (v11 == v0);
            v29 = v28;
        } else {
            v29 = false;
        }
        var v31: bool = false;
        if (v29) {
            var v30: bool = false;
            v30 = (v12 == v2);
            v31 = v30;
        } else {
            v31 = false;
        }
        var v33: bool = false;
        if (v31) {
            var v32: bool = false;
            v32 = (v13 == v1);
            v33 = v32;
        } else {
            v33 = false;
        }
        if (v33) {
            var v34: bool = false;
            v34 = (v14 == v2);
            var v36: bool = false;
            if (v34) {
                var v35: bool = false;
                v35 = (v15 == 2i);
                v36 = v35;
            } else {
                v36 = false;
            }
            if (v36) {
                var v37: bool = false;
                v37 = (v16 == 1073741824u);
                var v39: bool = false;
                if (v37) {
                    var v38: bool = false;
                    v38 = (v17 == 2147483647u);
                    v39 = v38;
                } else {
                    v39 = false;
                }
                var v41: bool = false;
                if (v39) {
                    var v40: bool = false;
                    v40 = (v18 == 2u);
                    v41 = v40;
                } else {
                    v41 = false;
                }
                if (v41) {
                    var v42: bool = false;
                    v42 = (v19 == v1);
                    var v44: bool = false;
                    if (v42) {
                        var v43: bool = false;
                        v43 = (v20 == 1u);
                        v44 = v43;
                    } else {
                        v44 = false;
                    }
                    if (v44) {
                        return 0i;
                    } else {
                        return 5i;
                    }
                } else {
                    return 4i;
                }
            } else {
                return 3i;
            }
        } else {
            return 2i;
        }
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
