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
    v0 = 120i;
    var v1: bool = false;
    v1 = (v0 == 32i);
    var v3: bool = false;
    if (v1) {
        v3 = true;
    } else {
        var v2: bool = false;
        v2 = (v0 == 47i);
        v3 = v2;
    }
    if (v3) {
        return 1i;
    } else {
        return 0i;
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
