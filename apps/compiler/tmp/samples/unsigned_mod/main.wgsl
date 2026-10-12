struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
fn sp_method0(p0: u32) -> bool {
    var v0: u32 = p0;
    var v1: u32 = 0u;
    v1 = (v0 + 5u);
    var v2: u32 = 0u;
    v2 = (v1 % 4u);
    var v3: bool = false;
    v3 = (v2 == 0u);
    return v3;
}
fn spiral_main() -> i32 {
    var v0: u32 = 0u;
    v0 = 7u;
    var v1: bool = false;
    v1 = sp_method0(v0);
    if (v1) {
        return 0i;
    } else {
        return 1i;
    }
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
