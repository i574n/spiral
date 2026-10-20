OPENQASM 3.0;
def spiral_main() -> int[32] {
    float[32] v0 = 0.0;
    v0 = -1.5;
    float[32] v1 = 0.0;
    v1 = 2.0;
    float[32] v2 = 0.0;
    v2 = (v0 / v1);
    float[32] v3 = 0.0;
    v3 = -0.75;
    float[32] v4 = 0.0;
    v4 = (v0 * v1);
    float[32] v5 = 0.0;
    v5 = (v4 + 0.5);
    float[32] v6 = 0.0;
    v6 = -2.5;
    bool v7 = false;
    v7 = (v2 == v3);
    if (v7) {
        bool v8 = false;
        v8 = (v5 == v6);
        if (v8) {
            return 0;
        } else {
            return 2;
        }
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
