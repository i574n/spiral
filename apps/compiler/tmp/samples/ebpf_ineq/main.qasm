OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = -3;
    int[32] v1 = 0;
    v1 = -4;
    int[32] v2 = 0;
    v2 = -3;
    uint[32] v3 = 0;
    v3 = 4294967295;
    uint[32] v4 = 0;
    v4 = 0;
    uint[32] v5 = 0;
    v5 = 4294967295;
    float[32] v6 = 0.0;
    v6 = -1.5;
    float[32] v7 = 0.0;
    v7 = -0.5;
    float[32] v8 = 0.0;
    v8 = -1.5;
    bool v9 = false;
    v9 = (v0 != v1);
    bool v10 = false;
    v10 = (v0 != v2);
    bool v11 = false;
    v11 = (v3 != v4);
    bool v12 = false;
    v12 = (v3 != v5);
    bool v13 = false;
    v13 = (v6 != v7);
    bool v14 = false;
    v14 = (v6 != v8);
    bool v15 = false;
    v15 = (v9 && v11);
    bool v16 = false;
    v16 = (v15 && v13);
    if (v16) {
        if (v10) {
            return 1;
        } else {
            if (v12) {
                return 2;
            } else {
                if (v14) {
                    return 3;
                } else {
                    return 0;
                }
            }
        }
    } else {
        return 4;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
