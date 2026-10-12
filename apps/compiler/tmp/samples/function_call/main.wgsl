struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
fn sp_method0(p0: i32, p1: i32) -> i32 {
    var v0: i32 = p0;
    var v1: i32 = p1;
    var v2: i32 = 0i;
    v2 = (v0 + v1);
    var v3: i32 = 0i;
    v3 = (v2 - 42i);
    return v3;
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 20i;
    var v1: i32 = 0i;
    v1 = 22i;
    return sp_method0(v0, v1);
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
