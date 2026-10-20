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
    var v0: f32 = 0.0f;
    v0 = 1.5f;
    var v1: f32 = 0.0f;
    v1 = -2.0f;
    var v2: f32 = 0.0f;
    v2 = -0.5f;
    var v3: f32 = 0.0f;
    v3 = (v0 / v1);
    var v4: f32 = 0.0f;
    v4 = (v2 / v1);
    var v5: bool = false;
    v5 = (v3 == -0.75f);
    var v7: bool = false;
    if (v5) {
        var v6: bool = false;
        v6 = (v4 == 0.25f);
        v7 = v6;
    } else {
        v7 = false;
    }
    if (v7) {
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
