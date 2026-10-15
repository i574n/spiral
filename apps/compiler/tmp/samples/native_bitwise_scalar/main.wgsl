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
    v0 = 43i;
    var v1: i32 = 0i;
    v1 = 15i;
    var v2: i32 = 0i;
    v2 = 2i;
    var v3: i32 = 0i;
    v3 = 5i;
    var v4: i32 = 0i;
    v4 = (v0 & v1);
    var v5: i32 = 0i;
    v5 = (v0 | v1);
    var v6: i32 = 0i;
    v6 = (v0 ^ v1);
    var v7: i32 = 0i;
    v7 = (~v0);
    var v8: i32 = 0i;
    v8 = (v7 & 255i);
    var v9: i32 = 0i;
    v9 = (1i << bitcast<u32>(v3));
    var v10: i32 = 0i;
    v10 = (168i >> bitcast<u32>(v2));
    var v11: i32 = 0i;
    v11 = (v4 - 11i);
    var v12: i32 = 0i;
    v12 = (v10 + v11);
    var v13: i32 = 0i;
    v13 = (v5 - 47i);
    var v14: i32 = 0i;
    v14 = (v12 + v13);
    var v15: i32 = 0i;
    v15 = (v6 - 36i);
    var v16: i32 = 0i;
    v16 = (v14 + v15);
    var v17: i32 = 0i;
    v17 = (v8 - 212i);
    var v18: i32 = 0i;
    v18 = (v16 + v17);
    var v19: i32 = 0i;
    v19 = (v9 - 32i);
    return (v18 + v19);
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
