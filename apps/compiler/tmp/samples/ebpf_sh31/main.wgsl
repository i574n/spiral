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
    v0 = 1u;
    var v1: i32 = 0i;
    v1 = 0i;
    var v2: i32 = 0i;
    v2 = 31i;
    var v3: u32 = 0u;
    v3 = (v0 << bitcast<u32>(v2));
    var v4: u32 = 0u;
    v4 = (v3 >> bitcast<u32>(v2));
    var v5: u32 = 0u;
    v5 = (v0 << bitcast<u32>(v1));
    var v6: bool = false;
    v6 = (v3 == 2147483648u);
    var v8: bool = false;
    if (v6) {
        var v7: bool = false;
        v7 = (v4 == 1u);
        v8 = v7;
    } else {
        v8 = false;
    }
    var v10: bool = false;
    if (v8) {
        var v9: bool = false;
        v9 = (v5 == 1u);
        v10 = v9;
    } else {
        v10 = false;
    }
    if (v10) {
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
