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
    v1 = 2i;
    var v2: u32 = 0u;
    v2 = 4294967295u;
    var v3: i32 = 0i;
    v3 = (-v0);
    var v4: i32 = 0i;
    v4 = -3i;
    var v5: i32 = 0i;
    v5 = -12i;
    var v6: i32 = 0i;
    v6 = -4i;
    var v7: i32 = 0i;
    v7 = -1i;
    var v8: i32 = 0i;
    v8 = (v3 / v1);
    var v9: bool = false;
    v9 = (v8 == v4);
    if (v9) {
        var v10: i32 = 0i;
        v10 = (v3 % v1);
        var v11: bool = false;
        v11 = (v10 == v7);
        if (v11) {
            var v12: i32 = 0i;
            v12 = (v3 >> bitcast<u32>(1i));
            var v13: bool = false;
            v13 = (v12 == v6);
            if (v13) {
                var v14: i32 = 0i;
                v14 = (v4 << bitcast<u32>(2i));
                var v15: bool = false;
                v15 = (v14 == v5);
                if (v15) {
                    var v16: u32 = 0u;
                    v16 = (v2 + 1u);
                    var v17: bool = false;
                    v17 = (v16 == 0u);
                    if (v17) {
                        var v18: u32 = 0u;
                        v18 = (v2 * v2);
                        var v19: bool = false;
                        v19 = (v18 == 1u);
                        if (v19) {
                            var v20: u32 = 0u;
                            v20 = (v2 >> bitcast<u32>(28i));
                            var v21: bool = false;
                            v21 = (v20 == 15u);
                            if (v21) {
                                return 0i;
                            } else {
                                return 7i;
                            }
                        } else {
                            return 6i;
                        }
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
