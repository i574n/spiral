struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
struct SpiralUnion0 {
  tag: u32,
  c0f0: i32,
  c1f0: i32,
}
fn sp_layers_0(p0: i32) -> i32 {
    var v0: i32 = p0;
    loop {
        var v1: bool = false;
        v1 = (v0 >= 5i);
        var v4: SpiralUnion0 = SpiralUnion0();
        if (v1) {
            v4 = SpiralUnion0(0u, v0, 0i);
        } else {
            v4 = SpiralUnion0(1u, 0i, v0);
        }
        if (v4.tag == 0u) {
            var v8: i32 = v4.c0f0;
            return (v8 * 2i);
        } else {
            var v5: i32 = v4.c1f0;
            var v6: i32 = 0i;
            v6 = (v5 + 1i);
            v0 = v6;
            continue;
        }
    }
    return 0i;
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 0i;
    return sp_layers_0(v0);
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
