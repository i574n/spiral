struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
fn sp_score_0(p0: u32) -> i32 {
    var v0: u32 = p0;
    if (v0 == 0u) {
        return 1i;
    } else if (v0 == 1u) {
        return 2i;
    } else if (v0 == 2u) {
        return 3i;
    } else {
        return 4i;
    }
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 3i;
    var v1: bool = false;
    v1 = (v0 == 0i);
    var v10: u32 = 0u;
    if (v1) {
        v10 = 0u;
    } else {
        var v3: bool = false;
        v3 = (v0 == 1i);
        if (v3) {
            v10 = 1u;
        } else {
            var v5: bool = false;
            v5 = (v0 == 2i);
            if (v5) {
                v10 = 2u;
            } else {
                v10 = 3u;
            }
        }
    }
    var v11: i32 = 0i;
    v11 = sp_score_0(v10);
    return (v11 - 4i);
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
