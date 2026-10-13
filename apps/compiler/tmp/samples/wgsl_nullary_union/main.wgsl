struct SpiralIo {
  code: i32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}
@group(0) @binding(0) var<storage, read_write> spiral_io: SpiralIo;
fn spiral_main() -> i32 {
    var v0: u32 = 0u;
    v0 = 0u;
    var v8: u32 = 0u;
    if (v0 == 0u) {
        v8 = 1u;
    } else if (v0 == 1u) {
        v8 = 2u;
    } else if (v0 == 2u) {
        v8 = 3u;
    } else {
        v8 = 0u;
    }
    var v16: u32 = 0u;
    if (v8 == 0u) {
        v16 = 1u;
    } else if (v8 == 1u) {
        v16 = 2u;
    } else if (v8 == 2u) {
        v16 = 3u;
    } else {
        v16 = 0u;
    }
    var v17: u32 = 0u;
    v17 = 2u;
    var v18: bool = false;
    if (v16 == 0u && v17 == 0u) {
        v18 = true;
    } else if (v16 == 1u && v17 == 1u) {
        v18 = true;
    } else if (v16 == 2u && v17 == 2u) {
        v18 = true;
    } else if (v16 == 3u && v17 == 3u) {
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
    var v21: i32 = 0i;
    if (v0 == 0u) {
        v21 = 1i;
    } else if (v0 == 1u) {
        v21 = 2i;
    } else {
        v21 = 7i;
    }
    var v23: i32 = 0i;
    if (v8 == 0u) {
        v23 = 1i;
    } else if (v8 == 1u) {
        v23 = 2i;
    } else {
        v23 = 7i;
    }
    var v24: i32 = 0i;
    v24 = (v23 * 3i);
    var v25: i32 = 0i;
    v25 = (v21 + v24);
    var v27: i32 = 0i;
    if (v16 == 0u) {
        v27 = 1i;
    } else if (v16 == 1u) {
        v27 = 2i;
    } else {
        v27 = 7i;
    }
    var v28: i32 = 0i;
    v28 = (v27 * 9i);
    var v29: i32 = 0i;
    v29 = (v25 + v28);
    var v30: i32 = 0i;
    v30 = (v29 + v19);
    return v30;
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
