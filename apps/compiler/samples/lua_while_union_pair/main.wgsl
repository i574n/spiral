struct SpiralIo {
  code: i32,
  lanes: u32,
  heap_words_per_lane: u32,
  lane_base: u32,
  heap_overflow: atomic<u32>,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(2) var<storage, read_write> spiral_results: array<i32>;
var<private> spiral_lane: u32 = 0u;
@group(0) @binding(1) var<storage, read_write> spiral_heap: array<u32>;
var<private> spiral_heap_top: u32 = 0u;
var<private> spiral_heap_end: u32 = 0u;
fn spiral_array_create(length: i32, stride: u32) -> u32 {
  let base = spiral_heap_top;
  let next = base + 1u + bitcast<u32>(length) * stride;
  if (next > spiral_heap_end || next < base) { atomicAdd(&spiral_io.heap_overflow, 1u); }
  if (base < spiral_heap_end) { spiral_heap[base] = bitcast<u32>(length); }
  spiral_heap_top = next;
  return base;
}
fn sp_method0(p0: u32) -> bool {
    var v0: u32 = p0;
    var v1: i32 = 0i;
    v1 = bitcast<i32>(spiral_heap[v0 + 1u + 0u]);
    return (v1 < 3i);
}
fn sp_method1(p0: u32) -> bool {
    var v0: u32 = p0;
    var v1: i32 = 0i;
    v1 = bitcast<i32>(spiral_heap[v0 + 1u + 0u]);
    return (v1 < 4i);
}
fn spiral_main() -> i32 {
    var v0: u32 = 0u;
    v0 = spiral_array_create(3i, 1u);
    var v1: u32 = 0u;
    let spiral_t1 = spiral_array_create(1i, 1u);
    spiral_heap[spiral_t1 + 1u + 0u] = bitcast<u32>(0i);
    v1 = spiral_t1;
    loop {
        if (!(sp_method0(v1))) { break; }
        var v3: i32 = 0i;
        v3 = bitcast<i32>(spiral_heap[v1 + 1u + 0u]);
        var v4: i32 = 0i;
        v4 = (v3 * 5i);
        spiral_heap[v0 + 1u + bitcast<u32>(v3) * 1u + 0u] = bitcast<u32>(v4);
        var v5: i32 = 0i;
        v5 = (v3 + 1i);
        spiral_heap[v1 + 1u + 0u] = bitcast<u32>(v5);
    }
    var v6: u32 = 0u;
    let spiral_t2 = spiral_array_create(1i, 1u);
    spiral_heap[spiral_t2 + 1u + 0u] = bitcast<u32>(0i);
    v6 = spiral_t2;
    var v7: u32 = 0u;
    let spiral_t3 = spiral_array_create(1i, 1u);
    spiral_heap[spiral_t3 + 1u + 0u] = bitcast<u32>(0i);
    v7 = spiral_t3;
    var v8: u32 = 0u;
    let spiral_t4 = spiral_array_create(1i, 1u);
    spiral_heap[spiral_t4 + 1u + 0u] = 0u;
    v8 = spiral_t4;
    var v9: u32 = 0u;
    let spiral_t5 = spiral_array_create(1i, 1u);
    spiral_heap[spiral_t5 + 1u + 0u] = v8;
    v9 = spiral_t5;
    loop {
        if (!(sp_method1(v6))) { break; }
        var v11: i32 = 0i;
        v11 = bitcast<i32>(spiral_heap[v6 + 1u + 0u]);
        var v12: i32 = 0i;
        v12 = (v11 % 2i);
        var v13: bool = false;
        v13 = (v12 == 1i);
        if (v13) {
            var v14: i32 = 0i;
            v14 = bitcast<i32>(spiral_heap[v7 + 1u + 0u]);
            var v15: i32 = 0i;
            v15 = (v14 + 1i);
            spiral_heap[v7 + 1u + 0u] = bitcast<u32>(v15);
        } else {
        }
        var v16: u32 = 0u;
        v16 = spiral_heap[v9 + 1u + 0u];
        var v17: u32 = 0u;
        let spiral_t6 = spiral_array_create(1i, 3u);
        spiral_heap[spiral_t6 + 1u + 0u] = 1u;
        spiral_heap[spiral_t6 + 1u + 1u] = bitcast<u32>(v11); spiral_heap[spiral_t6 + 1u + 2u] = v16;
        v17 = spiral_t6;
        spiral_heap[v9 + 1u + 0u] = v17;
        var v18: i32 = 0i;
        v18 = (v11 + 1i);
        spiral_heap[v6 + 1u + 0u] = bitcast<u32>(v18);
    }
    var v19: u32 = 0u;
    v19 = spiral_heap[v9 + 1u + 0u];
    var v38: i32 = 0i;
    if (spiral_heap[v19 + 1u + 0u] == 1u) {
        var v20: i32 = bitcast<i32>(spiral_heap[v19 + 1u + 1u]);
        var v21: u32 = spiral_heap[v19 + 1u + 2u];
        if (spiral_heap[v21 + 1u + 0u] == 1u) {
            var v22: i32 = bitcast<i32>(spiral_heap[v21 + 1u + 1u]);
            var v23: u32 = spiral_heap[v21 + 1u + 2u];
            if (spiral_heap[v23 + 1u + 0u] == 1u) {
                var v24: i32 = bitcast<i32>(spiral_heap[v23 + 1u + 1u]);
                var v25: u32 = spiral_heap[v23 + 1u + 2u];
                if (spiral_heap[v25 + 1u + 0u] == 1u) {
                    var v26: i32 = bitcast<i32>(spiral_heap[v25 + 1u + 1u]);
                    var v27: u32 = spiral_heap[v25 + 1u + 2u];
                    if (spiral_heap[v27 + 1u + 0u] == 0u) {
                        var v28: i32 = 0i;
                        v28 = (v20 * 64i);
                        var v29: i32 = 0i;
                        v29 = (v22 * 16i);
                        var v30: i32 = 0i;
                        v30 = (v28 + v29);
                        var v31: i32 = 0i;
                        v31 = (v24 * 4i);
                        var v32: i32 = 0i;
                        v32 = (v30 + v31);
                        var v33: i32 = 0i;
                        v33 = (v32 + v26);
                        v38 = v33;
                    } else {
                        v38 = -1i;
                    }
                } else {
                    v38 = -1i;
                }
            } else {
                v38 = -1i;
            }
        } else {
            v38 = -1i;
        }
    } else {
        v38 = -1i;
    }
    var v39: i32 = 0i;
    v39 = bitcast<i32>(spiral_heap[v7 + 1u + 0u]);
    var v40: i32 = 0i;
    v40 = (v38 + v39);
    var v41: i32 = 0i;
    v41 = bitcast<i32>(spiral_heap[v0 + 1u + bitcast<u32>(2i) * 1u + 0u]);
    var v42: i32 = 0i;
    v42 = (v40 + v41);
    var v43: i32 = 0i;
    v43 = bitcast<i32>(spiral_heap[v0 + 1u + bitcast<u32>(1i) * 1u + 0u]);
    return (v42 - v43);
}
@compute @workgroup_size(64)
fn main(@builtin(global_invocation_id) invocation: vec3<u32>) {
  let lane_count = max(spiral_io.lanes, 1u);
  let lane = spiral_io.lane_base + invocation.x;
  if (lane >= lane_count) { return; }
  spiral_lane = lane;
  let heap_words = select(arrayLength(&spiral_heap) / lane_count, spiral_io.heap_words_per_lane, spiral_io.heap_words_per_lane > 0u);
  spiral_heap_top = invocation.x * heap_words;
  spiral_heap_end = spiral_heap_top + heap_words;
  let result = spiral_main();
  spiral_results[spiral_lane] = result;
  if (spiral_lane == 0u) { spiral_io.code = result; }
}
