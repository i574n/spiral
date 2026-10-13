struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 6i;
    var v1: i32 = 0i;
    v1 = 7i;
    return (v0 + v1);
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
