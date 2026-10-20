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
    var v0: u32 = 0u;
    v0 = 4294967295u;
    var v1: u32 = 0u;
    v1 = 15u;
    var v2: u32 = 0u;
    v2 = (v0 & v1);
    var v3: u32 = 0u;
    v3 = (v0 | v1);
    var v4: u32 = 0u;
    v4 = (v0 ^ v1);
    var v5: u32 = 0u;
    v5 = (~v1);
    var v6: bool = false;
    v6 = (v2 == 15u);
    var v8: bool = false;
    if (v6) {
        var v7: bool = false;
        v7 = (v3 == v0);
        v8 = v7;
    } else {
        v8 = false;
    }
    var v10: bool = false;
    if (v8) {
        var v9: bool = false;
        v9 = (v4 == v5);
        v10 = v9;
    } else {
        v10 = false;
    }
    var v12: bool = false;
    if (v10) {
        var v11: bool = false;
        v11 = (v5 == 4294967280u);
        v12 = v11;
    } else {
        v12 = false;
    }
    if (v12) {
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
