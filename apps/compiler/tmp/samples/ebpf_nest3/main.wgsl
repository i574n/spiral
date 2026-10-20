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
  v1: u32,
  v2: f32,
}
fn sp_method1(p0: i32, p1: u32, p2: f32) -> SpiralTuple0 {
    var v0: i32 = p0;
    var v1: u32 = p1;
    var v2: f32 = p2;
    return SpiralTuple0(v0, v1, v2);
}
fn sp_method0(p0: i32, p1: u32, p2: f32) -> i32 {
    var v0: i32 = p0;
    var v1: u32 = p1;
    var v2: f32 = p2;
    var v3: i32 = 0i;
    var v4: u32 = 0u;
    var v5: f32 = 0.0f;
    let spiral_tuple1 = sp_method1(v0, v1, v2);
    v3 = spiral_tuple1.v0;
    v4 = spiral_tuple1.v1;
    v5 = spiral_tuple1.v2;
    var v6: bool = false;
    v6 = (v3 == 2i);
    var v8: bool = false;
    if (v6) {
        var v7: bool = false;
        v7 = (v4 == 3u);
        v8 = v7;
    } else {
        v8 = false;
    }
    var v10: bool = false;
    if (v8) {
        var v9: bool = false;
        v9 = (v5 == 1.5f);
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
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 2i;
    var v1: u32 = 0u;
    v1 = 3u;
    var v2: f32 = 0.0f;
    v2 = 1.5f;
    return sp_method0(v0, v1, v2);
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
