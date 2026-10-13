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
    var v0: u32 = 0u;
    v0 = spiral_array_create(4i, 1u);
    spiral_heap[v0 + 1u + bitcast<u32>(0i) * 1u + 0u] = bitcast<u32>(2i);
    spiral_heap[v0 + 1u + bitcast<u32>(1i) * 1u + 0u] = bitcast<u32>(3i);
    spiral_heap[v0 + 1u + bitcast<u32>(2i) * 1u + 0u] = bitcast<u32>(5i);
    spiral_heap[v0 + 1u + bitcast<u32>(3i) * 1u + 0u] = bitcast<u32>(7i);
    var v1: i32 = 0i;
    v1 = 2i;
    var v2: i32 = 0i;
    v2 = bitcast<i32>(spiral_heap[v0 + 1u + bitcast<u32>(v1) * 1u + 0u]);
    return (v2 - 5i);
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
