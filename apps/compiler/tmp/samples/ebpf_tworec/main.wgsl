struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
fn sp_method1(p0: i32, p1: i32) -> i32 {
    var v0: i32 = p0;
    var v1: i32 = p1;
    loop {
        var v2: i32 = 0i;
        v2 = (v0 - 1i);
        var v3: i32 = 0i;
        v3 = (v1 + 3i);
        var v4: bool = false;
        v4 = (v2 == 0i);
        if (v4) {
            return v3;
        } else {
            v0 = v2;
            v1 = v3;
            continue;
        }
    }
    return 0i;
}
fn sp_method0(p0: i32) -> i32 {
    var v0: i32 = p0;
    var v1: i32 = 0i;
    v1 = 0i;
    var v2: bool = false;
    v2 = (v0 == 0i);
    if (v2) {
        return v1;
    } else {
        return sp_method1(v0, v1);
    }
}
fn sp_method3(p0: i32, p1: i32) -> i32 {
    var v0: i32 = p0;
    var v1: i32 = p1;
    loop {
        var v2: i32 = 0i;
        v2 = (v0 - 1i);
        var v3: i32 = 0i;
        v3 = (v1 - 2i);
        var v4: bool = false;
        v4 = (v2 == 0i);
        if (v4) {
            return v3;
        } else {
            v0 = v2;
            v1 = v3;
            continue;
        }
    }
    return 0i;
}
fn sp_method2(p0: i32) -> i32 {
    var v0: i32 = p0;
    var v1: i32 = 0i;
    v1 = 0i;
    var v2: bool = false;
    v2 = (v0 == 0i);
    if (v2) {
        return v1;
    } else {
        return sp_method3(v0, v1);
    }
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 4i;
    var v1: i32 = 0i;
    v1 = sp_method0(v0);
    var v2: i32 = 0i;
    v2 = sp_method2(v0);
    var v3: bool = false;
    v3 = (v1 == 12i);
    var v5: bool = false;
    if (v3) {
        var v4: bool = false;
        v4 = (v2 == -8i);
        v5 = v4;
    } else {
        v5 = false;
    }
    if (v5) {
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
