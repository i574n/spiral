OPENQASM 3.0;
def spiral_main() -> int[32] {
    float[32] v0 = 0.0;
    v0 = 1.5;
    float[32] v1 = 0.0;
    v1 = -2.0;
    float[32] v2 = 0.0;
    v2 = -0.5;
    float[32] v3 = 0.0;
    v3 = (v0 / v1);
    float[32] v4 = 0.0;
    v4 = (v2 / v1);
    bool v5 = false;
    v5 = (v3 == -0.75);
    bool v7 = false;
    if (v5) {
        bool v6 = false;
        v6 = (v4 == 0.25);
        v7 = v6;
    } else {
        v7 = false;
    }
    if (v7) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
