OPENQASM 3.0;
def spiral_main() -> int[32] {
    float[32] v0 = 0.0;
    v0 = 2.0;
    float[32] v1 = 0.0;
    v1 = 3.0;
    float[64] v2 = 0.0;
    v2 = 2.0;
    float[64] v3 = 0.0;
    v3 = 3.0;
    float[32] v4 = 0.0;
    v4 = 3.1415927;
    float[64] v5 = 0.0;
    v5 = 3.141592653589793;
    float[32] v6 = 0.0;
    v6 = pow(v0, v1);
    bool v7 = false;
    v7 = (v6 == 8.0);
    bool v10 = false;
    if (v7) {
        float[64] v8 = 0.0;
        v8 = pow(v2, v3);
        bool v9 = false;
        v9 = (v8 == 8.0);
        v10 = v9;
    } else {
        v10 = false;
    }
    bool v12 = false;
    if (v10) {
        bool v11 = false;
        v11 = (v4 > 3.0);
        v12 = v11;
    } else {
        v12 = false;
    }
    bool v14 = false;
    if (v12) {
        bool v13 = false;
        v13 = (v4 < 4.0);
        v14 = v13;
    } else {
        v14 = false;
    }
    bool v16 = false;
    if (v14) {
        bool v15 = false;
        v15 = (v5 > 3.0);
        v16 = v15;
    } else {
        v16 = false;
    }
    bool v18 = false;
    if (v16) {
        bool v17 = false;
        v17 = (v5 < 4.0);
        v18 = v17;
    } else {
        v18 = false;
    }
    if (v18) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
