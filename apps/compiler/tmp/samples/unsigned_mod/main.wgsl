struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
fn sp_method0(p0: u32) -> bool {
    var v0: u32 = p0;
    var v1: u32 = 0u;
    v1 = (v0 + 5u);
    var v2: u32 = 0u;
    v2 = (v1 % 4u);
    return (v2 == 0u);
}
fn spiral_main() -> i32 {
    var v0: u32 = 0u;
    v0 = 7u;
    var v1: bool = false;
    v1 = sp_method0(v0);
    if (v1) {
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
