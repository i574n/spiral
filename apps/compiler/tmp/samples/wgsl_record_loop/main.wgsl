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
}
fn sp_loop_0(p0: i32, p1: i32, p2: i32, p3: i32) -> SpiralTuple0 {
    var v0: i32 = p0;
    var v1: i32 = p1;
    var v2: i32 = p2;
    var v3: i32 = p3;
    loop {
        var v4: bool = false;
        v4 = (v1 >= v0);
        if (v4) {
            return SpiralTuple0(v2, v3);
        } else {
            var v5: i32 = 0i;
            v5 = (v1 + 1i);
            var v6: i32 = 0i;
            v6 = (v2 + 1i);
            v1 = v5;
            v2 = v6;
            continue;
        }
    }
    return SpiralTuple0(0i, 0i);
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 5i;
    var v1: i32 = 0i;
    v1 = 0i;
    var v2: i32 = 0i;
    v2 = 1i;
    var v3: i32 = 0i;
    v3 = 2i;
    var v4: i32 = 0i;
    var v5: i32 = 0i;
    let spiral_tuple1 = sp_loop_0(v0, v1, v2, v3);
    v4 = spiral_tuple1.v0;
    v5 = spiral_tuple1.v1;
    return (v4 + v5);
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
