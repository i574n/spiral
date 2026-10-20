OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 3;
    int[32] v1 = 0;
    v1 = -2;
    uint[32] v2 = 0;
    v2 = 7;
    float[32] v3 = 0.0;
    v3 = 2.9;
    float[32] v4 = 0.0;
    v4 = float[32](v0);
    float[32] v5 = 0.0;
    v5 = float[32](v1);
    float[32] v6 = 0.0;
    v6 = float[32](v2);
    uint[32] v7 = 0;
    v7 = uint[32](v3);
    bool v8 = false;
    v8 = (v4 == 3.0);
    bool v10 = false;
    if (v8) {
        bool v9 = false;
        v9 = (v5 == -2.0);
        v10 = v9;
    } else {
        v10 = false;
    }
    bool v12 = false;
    if (v10) {
        bool v11 = false;
        v11 = (v6 == 7.0);
        v12 = v11;
    } else {
        v12 = false;
    }
    bool v14 = false;
    if (v12) {
        bool v13 = false;
        v13 = (v7 == 2);
        v14 = v13;
    } else {
        v14 = false;
    }
    if (v14) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
