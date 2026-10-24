struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
fn sp_count_down_0(p0: i32, p1: i32) -> i32 {
    var v0: i32 = p0;
    var v1: i32 = p1;
    loop {
        var v2: bool = false;
        v2 = (0i < v0);
        if (v2) {
            var v3: i32 = 0i;
            v3 = (v0 - 1i);
            var v4: i32 = 0i;
            v4 = (v1 + 1i);
            v0 = v3;
            v1 = v4;
            continue;
        } else {
            return v1;
        }
    }
    return 0i;
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 5000i;
    var v1: i32 = 0i;
    v1 = 0i;
    var v2: i32 = 0i;
    v2 = sp_count_down_0(v0, v1);
    var v3: bool = false;
    v3 = (v2 == 5000i);
    if (v3) {
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
