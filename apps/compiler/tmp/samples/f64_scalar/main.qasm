OPENQASM 3.0;
def spiral_main() -> int[32] {
    float[64] v0 = 0.0;
    v0 = 1.5;
    float[64] v1 = 0.0;
    v1 = -2.0;
    float[64] v2 = 0.0;
    v2 = (v0 / v1);
    float[64] v3 = 0.0;
    v3 = 1000000.0;
    float[64] v4 = 0.0;
    v4 = (v3 * v3);
    float[64] v5 = 0.0;
    v5 = (v4 * v3);
    float[64] v6 = 0.0;
    v6 = (v5 * 10000.0);
    float[64] v7 = 0.0;
    v7 = (v6 * v6);
    int[32] v8 = 0;
    v8 = 3;
    float[64] v9 = 0.0;
    v9 = float[64](v8);
    float[64] v10 = 0.0;
    v10 = 2.9;
    float[64] v11 = 0.0;
    v11 = -1.9;
    int[32] v12 = 0;
    v12 = int[32](v10);
    int[32] v13 = 0;
    v13 = int[32](v11);
    float[32] v14 = 0.0;
    v14 = 1.5;
    float[64] v15 = 0.0;
    v15 = float[64](v14);
    bool v16 = false;
    v16 = (v2 == -0.75);
    bool v18 = false;
    if (v16) {
        bool v17 = false;
        v17 = (v7 > v6);
        v18 = v17;
    } else {
        v18 = false;
    }
    bool v21 = false;
    if (v18) {
        float[64] v19 = 0.0;
        v19 = (v7 * v6);
        bool v20 = false;
        v20 = (v7 < v19);
        v21 = v20;
    } else {
        v21 = false;
    }
    bool v23 = false;
    if (v21) {
        bool v22 = false;
        v22 = (v9 == 3.0);
        v23 = v22;
    } else {
        v23 = false;
    }
    bool v25 = false;
    if (v23) {
        bool v24 = false;
        v24 = (v12 == 2);
        v25 = v24;
    } else {
        v25 = false;
    }
    bool v27 = false;
    if (v25) {
        bool v26 = false;
        v26 = (v13 == -1);
        v27 = v26;
    } else {
        v27 = false;
    }
    bool v29 = false;
    if (v27) {
        bool v28 = false;
        v28 = (v15 == 1.5);
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
