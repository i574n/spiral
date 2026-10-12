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
}
fn sp_method0(p0: i32, p1: i32) -> SpiralTuple0 {
    var v0: i32 = p0;
    var v1: i32 = p1;
    return SpiralTuple0(v0, v1);
}
fn sp_method1(p0: i32, p1: i32) -> i32 {
    var v0: i32 = p0;
    var v1: i32 = p1;
    var v2: i32 = 0i;
    v2 = (v0 + v1);
    return v2;
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 20i;
    var v1: i32 = 0i;
    v1 = 22i;
    var v2: i32 = 0i;
    var v3: i32 = 0i;
    let spiral_tuple1 = sp_method0(v0, v1);
    v2 = spiral_tuple1.v0;
    v3 = spiral_tuple1.v1;
    var v4: i32 = 0i;
    v4 = sp_method1(v2, v3);
    var v5: i32 = 0i;
    v5 = (v4 - 42i);
    return v5;
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
