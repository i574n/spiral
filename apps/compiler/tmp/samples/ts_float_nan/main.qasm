OPENQASM 3.0;
def spiral_main() -> int[32] {
    float[32] v0 = 0.0;
    v0 = ((1e308 * 10.0) - (1e308 * 10.0));
    float[64] v1 = 0.0;
    v1 = ((1e308 * 10.0) - (1e308 * 10.0));
    float[32] v2 = 0.0;
    v2 = 1.0;
    float[64] v3 = 0.0;
    v3 = 1.0;
    bool v4 = false;
    v4 = (v0 != v0);
    bool v6 = false;
    if (v4) {
        bool v5 = false;
        v5 = (v1 != v1);
        v6 = v5;
    } else {
        v6 = false;
    }
    if (v6) {
        bool v7 = false;
        v7 = (v2 != v2);
        bool v9 = false;
        if (v7) {
            v9 = true;
        } else {
            bool v8 = false;
            v8 = (v3 != v3);
            v9 = v8;
        }
        if (v9) {
            return 2;
        } else {
            return 0;
        }
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
