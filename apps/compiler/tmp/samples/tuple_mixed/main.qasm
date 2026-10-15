OPENQASM 3.0;
def sp_method0(float[32] p0) -> (bool, float[32], int[32]) {
    float[32] v0 = p0;
    bool v1 = false;
    v1 = (v0 >= 3.5);
    return v1, v0, 7;
}
def sp_method1(bool p0, float[32] p1, int[32] p2) -> int[32] {
    bool v0 = p0;
    float[32] v1 = p1;
    int[32] v2 = p2;
    if (v0) {
        bool v3 = false;
        v3 = (v1 >= 3.5);
        if (v3) {
            int[32] v4 = 0;
            v4 = (v2 - 7);
            return v4;
        } else {
            return 1;
        }
    } else {
        return 2;
    }
}
def spiral_main() -> int[32] {
    float[32] v0 = 0.0;
    v0 = 4.0;
    bool v1 = false;
    float[32] v2 = 0.0;
    int[32] v3 = 0;
    v1, v2, v3 = sp_method0(v0);
    return sp_method1(v1, v2, v3);
}
output int[32] spiral_io;
spiral_io = spiral_main();
