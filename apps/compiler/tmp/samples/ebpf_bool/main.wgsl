struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
fn sp_method0(p0: bool) -> i32 {
    var v0: bool = p0;
    if (v0) {
        return 1i;
    } else {
        return 3i;
    }
}
fn sp_method1(p0: bool, p1: bool) -> i32 {
    var v0: bool = p0;
    var v1: bool = p1;
    var v2: bool = false;
    v2 = (v0 && v1);
    if (v2) {
        return 1i;
    } else {
        var v3: bool = false;
        v3 = (v0 || v1);
        if (v3) {
            return 2i;
        } else {
            return 3i;
        }
    }
}
fn sp_method2(p0: bool) -> i32 {
    var v0: bool = p0;
    if (v0) {
        return 1i;
    } else {
        return 3i;
    }
}
fn spiral_main() -> i32 {
    var v0: bool = false;
    v0 = true;
    var v1: bool = false;
    v1 = false;
    var v2: i32 = 0i;
    v2 = sp_method0(v0);
    var v3: i32 = 0i;
    v3 = sp_method1(v0, v1);
    var v4: i32 = 0i;
    v4 = sp_method2(v1);
    var v5: bool = false;
    v5 = (v0 == v1);
    var v6: bool = false;
    v6 = (v5 == false);
    var v7: bool = false;
    v7 = (v2 == 1i);
    var v9: bool = false;
    if (v7) {
        var v8: bool = false;
        v8 = (v3 == 2i);
        v9 = v8;
    } else {
        v9 = false;
    }
    var v11: bool = false;
    if (v9) {
        var v10: bool = false;
        v10 = (v4 == 3i);
        v11 = v10;
    } else {
        v11 = false;
    }
    var v12: bool = false;
    v12 = (v11 && v6);
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
