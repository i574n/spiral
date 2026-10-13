struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
struct SpiralUnion0 {
  tag: u32,
  c0f0: i32,
  c1f0: i32,
  c1f1: i32,
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 2i;
    var v1: SpiralUnion0 = SpiralUnion0();
    v1 = SpiralUnion0(0u, v0, 0i, 0i);
    var v2: i32 = 0i;
    v2 = 3i;
    var v3: i32 = 0i;
    v3 = 4i;
    var v4: SpiralUnion0 = SpiralUnion0();
    v4 = SpiralUnion0(1u, 0i, v2, v3);
    var v5: SpiralUnion0 = SpiralUnion0();
    v5 = SpiralUnion0(2u, 0i, 0i, 0i);
    var v6: i32 = 0i;
    v6 = 2i;
    var v7: SpiralUnion0 = SpiralUnion0();
    v7 = SpiralUnion0(0u, v6, 0i, 0i);
    var v18: bool = false;
    if (v1.tag == 0u && v7.tag == 0u) {
        var v8: i32 = v1.c0f0;
        var v9: i32 = v7.c0f0;
        var v10: bool = false;
        v10 = (v8 == v9);
        v18 = v10;
    } else if (v1.tag == 1u && v7.tag == 1u) {
        var v11: i32 = v1.c1f0;
        var v12: i32 = v1.c1f1;
        var v13: i32 = v7.c1f0;
        var v14: i32 = v7.c1f1;
        var v15: bool = false;
        v15 = (v11 == v13);
        if (v15) {
            var v16: bool = false;
            v16 = (v12 == v14);
            v18 = v16;
        } else {
            v18 = false;
        }
    } else if (v1.tag == 2u && v7.tag == 2u) {
        v18 = true;
    } else {
        v18 = false;
    }
    var v19: i32 = 0i;
    if (v18) {
        v19 = 100i;
    } else {
        v19 = 0i;
    }
    var v28: i32 = 0i;
    if (v1.tag == 0u) {
        var v20: i32 = v1.c0f0;
        var v21: i32 = 0i;
        v21 = (3i * v20);
        var v22: i32 = 0i;
        v22 = (v21 * v20);
        v28 = v22;
    } else if (v1.tag == 1u) {
        var v23: i32 = v1.c1f0;
        var v24: i32 = v1.c1f1;
        var v25: i32 = 0i;
        v25 = (v23 * v24);
        v28 = v25;
    } else {
        v28 = 0i;
    }
    var v37: i32 = 0i;
    if (v4.tag == 0u) {
        var v29: i32 = v4.c0f0;
        var v30: i32 = 0i;
        v30 = (3i * v29);
        var v31: i32 = 0i;
        v31 = (v30 * v29);
        v37 = v31;
    } else if (v4.tag == 1u) {
        var v32: i32 = v4.c1f0;
        var v33: i32 = v4.c1f1;
        var v34: i32 = 0i;
        v34 = (v32 * v33);
        v37 = v34;
    } else {
        v37 = 0i;
    }
    var v38: i32 = 0i;
    v38 = (v28 + v37);
    var v47: i32 = 0i;
    if (v5.tag == 0u) {
        var v39: i32 = v5.c0f0;
        var v40: i32 = 0i;
        v40 = (3i * v39);
        var v41: i32 = 0i;
        v41 = (v40 * v39);
        v47 = v41;
    } else if (v5.tag == 1u) {
        var v42: i32 = v5.c1f0;
        var v43: i32 = v5.c1f1;
        var v44: i32 = 0i;
        v44 = (v42 * v43);
        v47 = v44;
    } else {
        v47 = 0i;
    }
    var v48: i32 = 0i;
    v48 = (v38 + v47);
    var v49: i32 = 0i;
    v49 = (v48 + v19);
    return v49;
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
