struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
fn sp_method0() -> bool {
    return true;
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 0i;
    var v1: i32 = 0i;
    v1 = 0i;
    loop {
        if (!(sp_method0())) { break; }
        var v3: i32 = 0i;
        v3 = (v0 + 1i);
        v0 = v3;
        var v4: bool = false;
        v4 = (v0 < 3i);
        if (v4) {
            continue;
        } else {
            var v5: bool = false;
            v5 = (v0 >= 6i);
            if (v5) {
                break;
            } else {
                var v6: i32 = 0i;
                v6 = (v1 + v0);
                v1 = v6;
            }
        }
    }
    return (v1 - 12i);
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
