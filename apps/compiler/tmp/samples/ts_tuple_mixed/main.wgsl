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
  v0: bool,
  v1: f32,
  v2: i32,
}
fn sp_method0(p0: f32) -> SpiralTuple0 {
    var v0: f32 = p0;
    var v1: bool = false;
    v1 = (v0 >= 3.5f);
    return SpiralTuple0(v1, v0, 7i);
}
fn sp_method1(p0: bool, p1: f32, p2: i32) -> i32 {
    var v0: bool = p0;
    var v1: f32 = p1;
    var v2: i32 = p2;
    if (v0) {
        var v3: bool = false;
        v3 = (v1 >= 3.5f);
        if (v3) {
            return (v2 - 7i);
        } else {
            return 1i;
        }
    } else {
        return 2i;
    }
}
fn spiral_main() -> i32 {
    var v0: f32 = 0.0f;
    v0 = 4.0f;
    var v1: bool = false;
    var v2: f32 = 0.0f;
    var v3: i32 = 0i;
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
