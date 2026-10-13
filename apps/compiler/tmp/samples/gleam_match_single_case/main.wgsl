struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
struct SpiralUnion0 {
  tag: u32,
  c0f0: i32,
  c0f1: i32,
  c0f2: i32,
}
fn sp_walk_0(p0: i32) -> i32 {
    var v0: i32 = p0;
    var v1: bool = false;
    v1 = (v0 > 2i);
    var v6: SpiralUnion0 = SpiralUnion0();
    if (v1) {
        var v2: i32 = 0i;
        v2 = (v0 + 1i);
        var v3: i32 = 0i;
        v3 = (v0 + 2i);
        v6 = SpiralUnion0(0u, v0, v2, v3);
    } else {
        v6 = SpiralUnion0(0u, 0i, 1i, 2i);
    }
    var v7: i32 = v6.c0f0;
    var v8: i32 = v6.c0f1;
    var v9: i32 = v6.c0f2;
    var v10: i32 = 0i;
    v10 = (v8 * v9);
    return (v7 + v10);
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 5i;
    var v1: i32 = 0i;
    v1 = sp_walk_0(v0);
    var v2: i32 = 0i;
    v2 = (v0 - 4i);
    var v3: i32 = 0i;
    v3 = sp_walk_0(v2);
    return (v1 + v3);
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
