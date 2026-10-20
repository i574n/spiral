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
    var v0: i32 = 0i;
    v0 = -8i;
    var v1: i32 = 0i;
    v1 = 3i;
    var v2: i32 = 0i;
    v2 = 1i;
    var v3: u32 = 0u;
    v3 = 4294967295u;
    var v4: i32 = 0i;
    v4 = 4i;
    var v5: i32 = 0i;
    v5 = (v0 >> bitcast<u32>(v2));
    var v6: i32 = 0i;
    v6 = (v1 << bitcast<u32>(v2));
    var v7: u32 = 0u;
    v7 = (v3 >> bitcast<u32>(v4));
    var v8: u32 = 0u;
    v8 = (v3 << bitcast<u32>(v2));
    var v9: bool = false;
    v9 = (v5 == -4i);
    if (v9) {
        var v10: bool = false;
        v10 = (v6 == 6i);
        if (v10) {
            var v11: bool = false;
            v11 = (v7 == 268435455u);
            if (v11) {
                var v12: bool = false;
                v12 = (v8 == 4294967294u);
                if (v12) {
                    return 0i;
                } else {
                    return 4i;
                }
            } else {
                return 3i;
            }
        } else {
            return 2i;
        }
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
