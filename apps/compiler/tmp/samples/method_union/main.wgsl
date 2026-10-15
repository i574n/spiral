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
  c1f0: i32,
}
fn sp_method0(p0: i32) -> SpiralUnion0 {
    var v0: i32 = p0;
    var v1: bool = false;
    v1 = (v0 == 0i);
    if (v1) {
        return SpiralUnion0(0u, 0i);
    } else {
        return SpiralUnion0(1u, v0);
    }
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 7i;
    var v1: SpiralUnion0 = SpiralUnion0();
    v1 = sp_method0(v0);
    if (v1.tag == 0u) {
        return 1i;
    } else {
        var v2: i32 = v1.c1f0;
        var v3: bool = false;
        v3 = (v2 == 7i);
        if (v3) {
            return 0i;
        } else {
            return 1i;
        }
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
