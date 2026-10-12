struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
fn sp_method1(p0: i32) -> i32 {
    var v0: i32 = p0;
    loop {
        var v1: i32 = 0i;
        v1 = (v0 - 1i);
        var v2: bool = false;
        v2 = (v1 == 0i);
        if (v2) {
            return 0i;
        } else {
            let spiral_t1: i32 = v1;
            v0 = spiral_t1;
            continue;
        }
    }
    return 0i;
}
fn sp_method0(p0: i32) -> i32 {
    var v0: i32 = p0;
    var v1: bool = false;
    v1 = (v0 == 0i);
    if (v1) {
        return 0i;
    } else {
        return sp_method1(v0);
    }
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 1000000i;
    return sp_method0(v0);
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
