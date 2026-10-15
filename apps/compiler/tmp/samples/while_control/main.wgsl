struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
fn sp_method0() -> bool {
    return true;
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 0i;
    var v1: i32 = 0i;
    v1 = 0i;
    loop {
        if (!(sp_method0())) { break; }
        var v3: i32 = 0i;
        v3 = (v0 + 1i);
        v0 = v3;
        var v4: bool = false;
        v4 = (v0 < 3i);
        if (v4) {
            continue;
        } else {
            var v5: bool = false;
            v5 = (v0 >= 6i);
            if (v5) {
                break;
            } else {
                var v6: i32 = 0i;
                v6 = (v1 + v0);
                v1 = v6;
            }
        }
    }
    return (v1 - 12i);
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
