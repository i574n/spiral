OPENQASM 3.0;
def spiral_main() -> int[32] {
    float[32] v0 = 0.0;
    v0 = (1e308 * 10.0);
    float[64] v1 = 0.0;
    v1 = (1e308 * 10.0);
    float[32] v2 = 0.0;
    v2 = (-(v0));
    float[64] v3 = 0.0;
    v3 = (-(v1));
    float[32] v4 = 0.0;
    v4 = 1.0;
    float[64] v5 = 0.0;
    v5 = 1.0;
    bool v6 = false;
    v6 = (v4 != v4);
    bool v8 = false;
    if (v6) {
        v8 = true;
    } else {
        bool v7 = false;
        v7 = (v5 != v5);
        v8 = v7;
    }
    if (v8) {
        return 3;
    } else {
        bool v9 = false;
        v9 = (v0 > v4);
        bool v11 = false;
        if (v9) {
            bool v10 = false;
            v10 = (v1 > v5);
            v11 = v10;
        } else {
            v11 = false;
        }
        if (v11) {
            bool v12 = false;
            v12 = (v2 < 0.0);
            bool v14 = false;
            if (v12) {
                bool v13 = false;
                v13 = (v3 < 0.0);
                v14 = v13;
            } else {
                v14 = false;
            }
            if (v14) {
                return 0;
            } else {
                return 2;
            }
        } else {
            return 1;
        }
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
