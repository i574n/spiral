OPENQASM 3.0;
def sp_method0(float[32] p0, float[32] p1) -> float[32] {
    float[32] v0 = p0;
    float[32] v1 = p1;
    float[32] v2 = 0.0;
    v2 = (v0 * v1);
    float[32] v3 = 0.0;
    v3 = (v2 + 0.5);
    return v3;
}
def spiral_main() -> int[32] {
    float[32] v0 = 0.0;
    v0 = 1.5;
    float[32] v1 = 0.0;
    v1 = 2.0;
    float[32] v2 = 0.0;
    v2 = sp_method0(v0, v1);
    bool v3 = false;
    v3 = (v2 >= 3.5);
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
