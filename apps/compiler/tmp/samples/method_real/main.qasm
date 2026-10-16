OPENQASM 3.0;
def sp_method0(int[32] p0) -> float[64] {
    int[32] v0 = p0;
    bool v1 = false;
    v1 = (v0 == 0);
    if (v1) {
        return 0.0;
    } else {
        return 1.5;
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 7;
    float[64] v1 = 0.0;
    v1 = sp_method0(v0);
    bool v2 = false;
    v2 = (v1 == 1.5);
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
