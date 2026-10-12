OPENQASM 3.0;
def sp_method1(int[32] p0, uint[32] p1, float[32] p2) -> (int[32], uint[32], float[32]) {
    int[32] v0 = p0;
    uint[32] v1 = p1;
    float[32] v2 = p2;
    return v0, v1, v2;
}
def sp_method0(int[32] p0, uint[32] p1, float[32] p2) -> int[32] {
    int[32] v0 = p0;
    uint[32] v1 = p1;
    float[32] v2 = p2;
    int[32] v3 = 0;
    uint[32] v4 = 0;
    float[32] v5 = 0.0;
    v3, v4, v5 = sp_method1(v0, v1, v2);
    bool v6 = false;
    v6 = (v3 == 2);
    bool v8 = false;
    if (v6) {
        bool v7 = false;
        v7 = (v4 == 3);
        v8 = v7;
    } else {
        v8 = false;
    }
    bool v10 = false;
    if (v8) {
        bool v9 = false;
        v9 = (v5 == 1.5);
        v10 = v9;
    } else {
        v10 = false;
    }
    if (v10) {
        return 0;
    } else {
        return 1;
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 2;
    uint[32] v1 = 0;
    v1 = 3;
    float[32] v2 = 0.0;
    v2 = 1.5;
    return sp_method0(v0, v1, v2);
}
output int[32] spiral_io;
spiral_io = spiral_main();
