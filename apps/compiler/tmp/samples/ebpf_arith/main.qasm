OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 7;
    int[32] v1 = 0;
    v1 = 2;
    uint[32] v2 = 0;
    v2 = 4294967295;
    int[32] v3 = 0;
    v3 = (-(v0));
    int[32] v4 = 0;
    v4 = -3;
    int[32] v5 = 0;
    v5 = -12;
    int[32] v6 = 0;
    v6 = -4;
    int[32] v7 = 0;
    v7 = -1;
    int[32] v8 = 0;
    v8 = (v3 / v1);
    bool v9 = false;
    v9 = (v8 == v4);
    if (v9) {
        int[32] v10 = 0;
        v10 = (v3 % v1);
        bool v11 = false;
        v11 = (v10 == v7);
        if (v11) {
            int[32] v12 = 0;
            v12 = (v3 >> 1);
            bool v13 = false;
            v13 = (v12 == v6);
            if (v13) {
                int[32] v14 = 0;
                v14 = (v4 << 2);
                bool v15 = false;
                v15 = (v14 == v5);
                if (v15) {
                    uint[32] v16 = 0;
                    v16 = (v2 + 1);
                    bool v17 = false;
                    v17 = (v16 == 0);
                    if (v17) {
                        uint[32] v18 = 0;
                        v18 = (v2 * v2);
                        bool v19 = false;
                        v19 = (v18 == 1);
                        if (v19) {
                            uint[32] v20 = 0;
                            v20 = (v2 >> 28);
                            bool v21 = false;
                            v21 = (v20 == 15);
                            if (v21) {
                                return 0;
                            } else {
                                return 7;
                            }
                        } else {
                            return 6;
                        }
                    } else {
                        return 5;
                    }
                } else {
                    return 4;
                }
            } else {
                return 3;
            }
        } else {
            return 2;
        }
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
