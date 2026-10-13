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
  c2f0: i32,
}
fn sp_pick_0(p0: i32) -> SpiralUnion0 {
    var v0: i32 = p0;
    var v1: bool = false;
    v1 = (v0 == 0i);
    if (v1) {
        return SpiralUnion0(0u, 5i, 0i, 0i);
    } else {
        var v3: bool = false;
        v3 = (v0 == 1i);
        if (v3) {
            return SpiralUnion0(1u, 0i, 4i, 0i);
        } else {
            var v5: bool = false;
            v5 = (v0 == 2i);
            if (v5) {
                return SpiralUnion0(2u, 0i, 0i, 7i);
            } else {
                return SpiralUnion0(3u, 0i, 0i, 0i);
            }
        }
    }
}
fn sp_measure_1(p0: SpiralUnion0, p1: i32) -> i32 {
    var v0: SpiralUnion0 = p0;
    var v1: i32 = p1;
    if (v0.tag == 0u) {
        var v2: i32 = v0.c0f0;
        var v3: i32 = 0i;
        v3 = (v2 * 3i);
        return v3;
    } else {
        var v4: i32 = 0i;
        v4 = (v1 * v1);
        var v5: bool = false;
        v5 = (v4 > 3i);
        if (v0.tag == 1u) {
            var v6: i32 = v0.c1f0;
            if (v5) {
                var v7: i32 = 0i;
                v7 = (v6 * v6);
                return v7;
            } else {
                return v6;
            }
        } else if (v0.tag == 2u) {
            var v9: i32 = v0.c2f0;
            if (v5) {
                var v10: i32 = 0i;
                v10 = (v9 * 2i);
                return v10;
            } else {
                return v9;
            }
        } else {
            return v4;
        }
    }
}
fn sp_measure_tri_2(p0: SpiralUnion0, p1: i32) -> i32 {
    var v0: SpiralUnion0 = p0;
    var v1: i32 = p1;
    if (v0.tag == 0u) {
        var v2: i32 = v0.c0f0;
        return v2;
    } else if (v0.tag == 1u) {
        var v3: i32 = v0.c1f0;
        return v3;
    } else if (v0.tag == 3u) {
        return 0i;
    } else {
        var v4: i32 = 0i;
        v4 = (v1 + 2i);
        var v5: i32 = v0.c2f0;
        var v6: i32 = 0i;
        v6 = (v5 * v4);
        return v6;
    }
}
fn spiral_main() -> i32 {
    var v0: i32 = 0i;
    v0 = 0i;
    var v1: SpiralUnion0 = SpiralUnion0();
    v1 = sp_pick_0(v0);
    var v2: i32 = 0i;
    v2 = sp_measure_1(v1, v0);
    var v3: i32 = 0i;
    v3 = (v0 + 1i);
    var v4: SpiralUnion0 = SpiralUnion0();
    v4 = sp_pick_0(v3);
    var v5: i32 = 0i;
    v5 = sp_measure_1(v4, v3);
    var v6: i32 = 0i;
    v6 = (v2 + v5);
    var v7: i32 = 0i;
    v7 = (v0 + 2i);
    var v8: SpiralUnion0 = SpiralUnion0();
    v8 = sp_pick_0(v7);
    var v9: i32 = 0i;
    v9 = sp_measure_1(v8, v7);
    var v10: i32 = 0i;
    v10 = (v6 + v9);
    var v11: i32 = 0i;
    v11 = (v0 + 3i);
    var v12: SpiralUnion0 = SpiralUnion0();
    v12 = sp_pick_0(v11);
    var v13: i32 = 0i;
    v13 = sp_measure_1(v12, v11);
    var v14: i32 = 0i;
    v14 = (v10 + v13);
    var v15: SpiralUnion0 = SpiralUnion0();
    v15 = sp_pick_0(v7);
    var v16: i32 = 0i;
    v16 = sp_measure_tri_2(v15, v0);
    var v17: i32 = 0i;
    v17 = (v14 + v16);
    var v18: SpiralUnion0 = SpiralUnion0();
    v18 = sp_pick_0(v0);
    var v19: i32 = 0i;
    v19 = sp_measure_tri_2(v18, v0);
    var v20: i32 = 0i;
    v20 = (v17 + v19);
    return v20;
}
@compute @workgroup_size(1)
fn main() {
  spiral_io.code = spiral_main();
}
