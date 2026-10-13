struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
struct SpiralTuple0 {
  v0: bool,
  v1: f32,
  v2: i32,
}
fn sp_method0(p0: f32) -> SpiralTuple0 {
    var v0: f32 = p0;
    var v1: bool = false;
    v1 = (v0 >= 3.5f);
    return SpiralTuple0(v1, v0, 7i);
}
fn sp_method1(p0: bool, p1: f32, p2: i32) -> i32 {
    var v0: bool = p0;
    var v1: f32 = p1;
    var v2: i32 = p2;
    if (v0) {
        var v3: bool = false;
        v3 = (v1 >= 3.5f);
        if (v3) {
            return (v2 - 7i);
        } else {
            return 1i;
        }
    } else {
        return 2i;
    }
}
fn spiral_main() -> i32 {
    var v0: f32 = 0.0f;
    v0 = 4.0f;
    var v1: bool = false;
    var v2: f32 = 0.0f;
    var v3: i32 = 0i;
    let spiral_tuple1 = sp_method0(v0);
    v1 = spiral_tuple1.v0;
    v2 = spiral_tuple1.v1;
    v3 = spiral_tuple1.v2;
    return sp_method1(v1, v2, v3);
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
