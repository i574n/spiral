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
fn sp_fill_0(p0: i32, p1: u32, p2: i32) {
    var v0: i32 = p0;
    var v1: u32 = p1;
    var v2: i32 = p2;
    loop {
        var v3: bool = false;
        v3 = (v2 < v0);
        if (v3) {
            spiral_heap[v1 + 1u + bitcast<u32>(v2) * 1u + 0u] = bitcast<u32>(v2);
            var v4: i32 = 0i;
            v4 = (v2 + 1i);
            let spiral_t1: i32 = v0;
            let spiral_t2: u32 = v1;
            let spiral_t3: i32 = v4;
            v0 = spiral_t1;
            v1 = spiral_t2;
            v2 = spiral_t3;
            continue;
        } else {
            return;
        }
    }
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 6i;
    var v1: u32 = 0u;
    v1 = spiral_array_create(6i, 1u);
    var v2: i32 = 0i;
    v2 = 0i;
    sp_fill_0(v0, v1, v2);
    var v3: i32 = 0i;
    v3 = bitcast<i32>(spiral_heap[v1 + 1u + bitcast<u32>(5i) * 1u + 0u]);
    return (v3 + 2i);
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
