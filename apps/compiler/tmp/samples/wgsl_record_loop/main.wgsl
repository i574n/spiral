struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
struct SpiralTuple0 {
  v0: i32,
  v1: i32,
}
fn sp_loop_0(p0: i32, p1: i32, p2: i32, p3: i32) -> SpiralTuple0 {
    var v0: i32 = p0;
    var v1: i32 = p1;
    var v2: i32 = p2;
    var v3: i32 = p3;
    loop {
        var v4: bool = false;
        v4 = (v1 >= v0);
        if (v4) {
            return SpiralTuple0(v2, v3);
        } else {
            var v5: i32 = 0i;
            v5 = (v1 + 1i);
            var v6: i32 = 0i;
            v6 = (v2 + 1i);
            let spiral_t1: i32 = v0;
            let spiral_t2: i32 = v5;
            let spiral_t3: i32 = v6;
            let spiral_t4: i32 = v3;
            v0 = spiral_t1;
            v1 = spiral_t2;
            v2 = spiral_t3;
            v3 = spiral_t4;
            continue;
        }
    }
    return SpiralTuple0(0i, 0i);
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 5i;
    var v1: i32 = 0i;
    v1 = 0i;
    var v2: i32 = 0i;
    v2 = 1i;
    var v3: i32 = 0i;
    v3 = 2i;
    var v4: i32 = 0i;
    var v5: i32 = 0i;
    let spiral_tuple5 = sp_loop_0(v0, v1, v2, v3);
    v4 = spiral_tuple5.v0;
    v5 = spiral_tuple5.v1;
    return (v4 + v5);
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
