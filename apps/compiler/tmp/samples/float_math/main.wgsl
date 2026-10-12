struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
fn sp_method0(p0: f32, p1: f32) -> f32 {
    var v0: f32 = p0;
    var v1: f32 = p1;
    var v2: f32 = 0.0f;
    v2 = (v0 * v1);
    var v3: f32 = 0.0f;
    v3 = (v2 + 0.5f);
    return v3;
}
fn spiral_main() -> i32 {
    var v0: f32 = 0.0f;
    v0 = 1.5f;
    var v1: f32 = 0.0f;
    v1 = 2.0f;
    var v2: f32 = 0.0f;
    v2 = sp_method0(v0, v1);
    var v3: bool = false;
    v3 = (v2 >= 3.5f);
    if (v3) {
        return 0i;
    } else {
        return 1i;
    }
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
