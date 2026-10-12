struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
fn sp_count_down_0(p0: i32, p1: i32) -> i32 {
    var v0: i32 = p0;
    var v1: i32 = p1;
    loop {
        var v2: bool = false;
        v2 = (0i < v0);
        if (v2) {
            var v3: i32 = 0i;
            v3 = (v0 - 1i);
            var v4: i32 = 0i;
            v4 = (v1 + 1i);
            let spiral_t1: i32 = v3;
            let spiral_t2: i32 = v4;
            v0 = spiral_t1;
            v1 = spiral_t2;
            continue;
        } else {
            return v1;
        }
    }
    return 0i;
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 5000i;
    var v1: i32 = 0i;
    v1 = 0i;
    var v2: i32 = 0i;
    v2 = sp_count_down_0(v0, v1);
    var v3: bool = false;
    v3 = (v2 == 5000i);
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
