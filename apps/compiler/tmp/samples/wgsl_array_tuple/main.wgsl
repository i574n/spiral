struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
@group(0) @binding(1) var<storage, read_write> spiral_heap: array<u32>;
var<private> spiral_heap_top: u32 = 0u;
fn spiral_array_create(length: i32, stride: u32) -> u32 {
  let base = spiral_heap_top;
  spiral_heap[base] = bitcast<u32>(length);
  spiral_heap_top = base + 1u + bitcast<u32>(length) * stride;
  return base;
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 3i;
    var v1: u32 = 0u;
    v1 = spiral_array_create(v0, 2u);
    var v2: i32 = 0i;
    v2 = 4i;
    spiral_heap[v1 + 1u + bitcast<u32>(0i) * 2u + 0u] = bitcast<u32>(v2); spiral_heap[v1 + 1u + bitcast<u32>(0i) * 2u + 1u] = select(0u, 1u, true);
    spiral_heap[v1 + 1u + bitcast<u32>(1i) * 2u + 0u] = bitcast<u32>(7i); spiral_heap[v1 + 1u + bitcast<u32>(1i) * 2u + 1u] = select(0u, 1u, false);
    spiral_heap[v1 + 1u + bitcast<u32>(2i) * 2u + 0u] = bitcast<u32>(9i); spiral_heap[v1 + 1u + bitcast<u32>(2i) * 2u + 1u] = select(0u, 1u, true);
    var v3: i32 = 0i;
    var v4: bool = false;
    v3 = bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(0i) * 2u + 0u]);
    v4 = (spiral_heap[v1 + 1u + bitcast<u32>(0i) * 2u + 1u] != 0u);
    var v5: i32 = 0i;
    var v6: bool = false;
    v5 = bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(1i) * 2u + 0u]);
    v6 = (spiral_heap[v1 + 1u + bitcast<u32>(1i) * 2u + 1u] != 0u);
    var v7: i32 = 0i;
    v7 = 2i;
    var v8: i32 = 0i;
    var v9: bool = false;
    v8 = bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(v7) * 2u + 0u]);
    v9 = (spiral_heap[v1 + 1u + bitcast<u32>(v7) * 2u + 1u] != 0u);
    var v10: i32 = 0i;
    if (v4) {
        v10 = 1i;
    } else {
        v10 = 0i;
    }
    var v11: i32 = 0i;
    if (v6) {
        v11 = 10i;
    } else {
        v11 = 0i;
    }
    var v12: i32 = 0i;
    if (v9) {
        v12 = 100i;
    } else {
        v12 = 0i;
    }
    var v13: i32 = 0i;
    v13 = (v3 + v5);
    var v14: i32 = 0i;
    v14 = (v13 + v8);
    var v15: i32 = 0i;
    v15 = (v14 + v10);
    var v16: i32 = 0i;
    v16 = (v15 + v11);
    return (v16 + v12);
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
