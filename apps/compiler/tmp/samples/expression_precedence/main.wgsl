struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
fn sp_method0(p0: i32, p1: i32) -> bool {
    var v0: i32 = p0;
    var v1: i32 = p1;
    var v2: i32 = 0i;
    v2 = -v0 ;
    var v3: bool = false;
    v3 = (v2 <= 0i);
    if (v3) {
        var v4: i32 = 0i;
        v4 = (v1 * 2i);
        var v5: i32 = 0i;
        v5 = (v0 + v4);
        var v6: bool = false;
        v6 = (v5 >= 9i);
        if (v6) {
            return true;
        } else {
            return (v1 == 0i);
        }
    } else {
        return false;
    }
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 3i;
    var v1: i32 = 0i;
    v1 = 3i;
    var v2: bool = false;
    v2 = sp_method0(v0, v1);
    if (v2) {
        return 0i;
    } else {
        return 1i;
    }
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
