struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
fn sp_method1(p0: i32, p1: i32) -> i32 {
    var v0: i32 = p0;
    var v1: i32 = p1;
    loop {
        var v2: i32 = 0i;
        v2 = (v0 - 1i);
        var v3: i32 = 0i;
        v3 = (v1 + v0);
        var v4: bool = false;
        v4 = (v2 == 0i);
        if (v4) {
            return v3;
        } else {
            let spiral_t1: i32 = v2;
            let spiral_t2: i32 = v3;
            v0 = spiral_t1;
            v1 = spiral_t2;
            continue;
        }
    }
    return 0i;
}
fn sp_method0(p0: i32) -> i32 {
    var v0: i32 = p0;
    var v1: i32 = 0i;
    v1 = 0i;
    var v2: bool = false;
    v2 = (v0 == 0i);
    var v4: i32 = 0i;
    if (v2) {
        v4 = v1;
    } else {
        v4 = sp_method1(v0, v1);
    }
    var v5: i32 = 0i;
    v5 = (v4 - 55i);
    return v5;
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 10i;
    return sp_method0(v0);
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
