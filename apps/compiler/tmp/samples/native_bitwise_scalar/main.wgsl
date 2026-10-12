struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 43i;
    var v1: i32 = 0i;
    v1 = 15i;
    var v2: i32 = 0i;
    v2 = 2i;
    var v3: i32 = 0i;
    v3 = 5i;
    var v4: i32 = 0i;
    v4 = (v0 & v1);
    var v5: i32 = 0i;
    v5 = (v0 | v1);
    var v6: i32 = 0i;
    v6 = (v0 ^ v1);
    var v7: i32 = 0i;
    v7 = (~v0);
    var v8: i32 = 0i;
    v8 = (v7 & 255i);
    var v9: i32 = 0i;
    v9 = (1i << bitcast<u32>(v3));
    var v10: i32 = 0i;
    v10 = (168i >> bitcast<u32>(v2));
    var v11: i32 = 0i;
    v11 = (v4 - 11i);
    var v12: i32 = 0i;
    v12 = (v10 + v11);
    var v13: i32 = 0i;
    v13 = (v5 - 47i);
    var v14: i32 = 0i;
    v14 = (v12 + v13);
    var v15: i32 = 0i;
    v15 = (v6 - 36i);
    var v16: i32 = 0i;
    v16 = (v14 + v15);
    var v17: i32 = 0i;
    v17 = (v8 - 212i);
    var v18: i32 = 0i;
    v18 = (v16 + v17);
    var v19: i32 = 0i;
    v19 = (v9 - 32i);
    var v20: i32 = 0i;
    v20 = (v18 + v19);
    return v20;
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
