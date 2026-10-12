struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
struct SpiralTuple0 {
  v0: i32,
  v1: i32,
  v2: i32,
  v3: i32,
}
fn sp_method0(p0: i32) -> SpiralTuple0 {
    var v0: i32 = p0;
    var v1: i32 = 0i;
    v1 = (v0 + 1i);
    var v2: i32 = 0i;
    v2 = (v0 + 2i);
    var v3: i32 = 0i;
    v3 = (v0 + 3i);
    return SpiralTuple0(v0, v1, v2, v3);
}
fn sp_method1(p0: i32, p1: i32, p2: i32, p3: i32) -> i32 {
    var v0: i32 = p0;
    var v1: i32 = p1;
    var v2: i32 = p2;
    var v3: i32 = p3;
    var v4: i32 = 0i;
    v4 = (v0 + v1);
    var v5: i32 = 0i;
    v5 = (v4 + v2);
    var v6: i32 = 0i;
    v6 = (v5 + v3);
    var v7: i32 = 0i;
    v7 = (v6 - 10i);
    return v7;
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 1i;
    var v1: i32 = 0i;
    var v2: i32 = 0i;
    var v3: i32 = 0i;
    var v4: i32 = 0i;
    let spiral_tuple1 = sp_method0(v0);
    v1 = spiral_tuple1.v0;
    v2 = spiral_tuple1.v1;
    v3 = spiral_tuple1.v2;
    v4 = spiral_tuple1.v3;
    return sp_method1(v1, v2, v3, v4);
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
