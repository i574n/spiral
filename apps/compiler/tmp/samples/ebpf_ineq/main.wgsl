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
    v0 = -3i;
    var v1: i32 = 0i;
    v1 = -4i;
    var v2: i32 = 0i;
    v2 = -3i;
    var v3: u32 = 0u;
    v3 = 4294967295u;
    var v4: u32 = 0u;
    v4 = 0u;
    var v5: u32 = 0u;
    v5 = 4294967295u;
    var v6: f32 = 0.0f;
    v6 = -1.5f;
    var v7: f32 = 0.0f;
    v7 = -0.5f;
    var v8: f32 = 0.0f;
    v8 = -1.5f;
    var v9: bool = false;
    v9 = (v0 != v1);
    var v10: bool = false;
    v10 = (v0 != v2);
    var v11: bool = false;
    v11 = (v3 != v4);
    var v12: bool = false;
    v12 = (v3 != v5);
    var v13: bool = false;
    v13 = (v6 != v7);
    var v14: bool = false;
    v14 = (v6 != v8);
    var v15: bool = false;
    v15 = (v9 && v11);
    var v16: bool = false;
    v16 = (v15 && v13);
    if (v16) {
        if (v10) {
            return 1i;
        } else {
            if (v12) {
                return 2i;
            } else {
                if (v14) {
                    return 3i;
                } else {
                    return 0i;
                }
            }
        }
    } else {
        return 4i;
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
