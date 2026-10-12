struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
fn sp_method0(p0: i32) -> bool {
    var v0: i32 = p0;
    var v1: bool = false;
    v1 = (v0 < 10i);
    return v1;
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 0i;
    var v1: i32 = 0i;
    v1 = 0i;
    loop {
        if (!(sp_method0(v0))) { break; }
        var v3: i32 = 0i;
        v3 = (v1 + v0);
        v1 = v3;
        var v4: i32 = 0i;
        v4 = (v0 + 1i);
        v0 = v4;
    }
    var v5: i32 = 0i;
    v5 = (v1 - 45i);
    return v5;
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
