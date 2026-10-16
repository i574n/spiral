OPENQASM 3.0;
def spiral_main() -> int[32] {
    float[32] v0 = 0.0;
    v0 = 144.0;
    float[64] v1 = 0.0;
    v1 = 81.0;
    float[32] v2 = 0.0;
    v2 = sqrt(v0);
    float[64] v3 = 0.0;
    v3 = sqrt(v1);
    bool v4 = false;
    v4 = (v2 == 12.0);
    bool v6 = false;
    if (v4) {
        bool v5 = false;
        v5 = (v3 == 9.0);
        v6 = v5;
    } else {
        v6 = false;
    }
    if (v6) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
