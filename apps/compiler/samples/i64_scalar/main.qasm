OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[64] v0 = 0;
    v0 = 5000000000;
    int[64] v1 = 0;
    v1 = -4;
    int[64] v2 = 0;
    v2 = (v0 / v1);
    int[64] v3 = 0;
    v3 = 1000000;
    int[64] v4 = 0;
    v4 = (v3 * v3);
    int[64] v5 = 0;
    v5 = -8;
    int[64] v6 = 0;
    v6 = (v5 >> 1);
    int[32] v7 = 0;
    v7 = 7;
    int[64] v8 = 0;
    v8 = v7;
    int[64] v9 = 0;
    v9 = 9;
    int[32] v10 = 0;
    v10 = v9;
    uint[64] v11 = 0;
    v11 = 4294967296;
    uint[64] v12 = 0;
    v12 = (v11 + 1);
    uint[64] v13 = 0;
    v13 = (v11 >> 1);
    uint[64] v14 = 0;
    v14 = v7;
    bool v15 = false;
    v15 = (v2 == -1250000000);
    bool v17 = false;
    if (v15) {
        bool v16 = false;
        v16 = (v4 == 1000000000000);
        v17 = v16;
    } else {
        v17 = false;
    }
    bool v19 = false;
    if (v17) {
        bool v18 = false;
        v18 = (v6 == -4);
        v19 = v18;
    } else {
        v19 = false;
    }
    bool v21 = false;
    if (v19) {
        bool v20 = false;
        v20 = (v8 == 7);
        v21 = v20;
    } else {
        v21 = false;
    }
    bool v23 = false;
    if (v21) {
        bool v22 = false;
        v22 = (v10 == 9);
        v23 = v22;
    } else {
        v23 = false;
    }
    bool v25 = false;
    if (v23) {
        bool v24 = false;
        v24 = (v12 == 4294967297);
        v25 = v24;
    } else {
        v25 = false;
    }
    bool v27 = false;
    if (v25) {
        bool v26 = false;
        v26 = (v13 == 2147483648);
        v27 = v26;
    } else {
        v27 = false;
    }
    bool v29 = false;
    if (v27) {
        bool v28 = false;
        v28 = (v14 == 7);
        v29 = v28;
    } else {
        v29 = false;
    }
    if (v29) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
