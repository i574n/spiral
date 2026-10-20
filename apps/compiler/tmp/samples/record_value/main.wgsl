struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
struct SpiralTuple0 {
  v0: i32,
  v1: i32,
  v2: bool,
}
fn sp_method0(p0: i32) -> SpiralTuple0 {
    var v0: i32 = p0;
    var v1: i32 = 0i;
    v1 = (v0 + 2i);
    var v2: bool = false;
    v2 = (v0 > 0i);
    return SpiralTuple0(v0, v1, v2);
}
fn sp_method1(p0: i32, p1: i32, p2: bool) -> i32 {
    var v0: i32 = p0;
    var v1: i32 = p1;
    var v2: bool = p2;
    if (v2) {
        var v3: i32 = 0i;
        v3 = (v0 + v1);
        return (v3 - 4i);
    } else {
        return 1i;
    }
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 1i;
    var v1: i32 = 0i;
    var v2: i32 = 0i;
    var v3: bool = false;
    let spiral_tuple1 = sp_method0(v0);
    v1 = spiral_tuple1.v0;
    v2 = spiral_tuple1.v1;
    v3 = spiral_tuple1.v2;
    return sp_method1(v1, v2, v3);
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
