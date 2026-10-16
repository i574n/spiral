OPENQASM 3.0;
def sp_method0(int[32] p0) -> (float[64], float[64]) {
    int[32] v0 = p0;
    bool v1 = false;
    v1 = (v0 == 0);
    if (v1) {
        return 0.0, 0.0;
    } else {
        return 1.5, 2.5;
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 7;
    float[64] v1 = 0.0;
    float[64] v2 = 0.0;
    v1, v2 = sp_method0(v0);
    bool v3 = false;
    v3 = (v1 == 1.5);
    bool v5 = false;
    if (v3) {
        bool v4 = false;
        v4 = (v2 == 2.5);
        v5 = v4;
    } else {
        v5 = false;
    }
    if (v5) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
