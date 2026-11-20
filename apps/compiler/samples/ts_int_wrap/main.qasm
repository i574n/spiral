OPENQASM 3.0;
def spiral_main() -> int[32] {
    uint[8] v0 = 0;
    v0 = 250;
    uint[8] v1 = 0;
    v1 = 10;
    uint[32] v2 = 0;
    v2 = 4294967295;
    uint[64] v3 = 0;
    v3 = 18446744073709551615;
    int[8] v4 = 0;
    v4 = 127;
    int[8] v5 = 0;
    v5 = 1;
    int[32] v6 = 0;
    v6 = 7;
    int[32] v7 = 0;
    v7 = 2;
    int[64] v8 = 0;
    v8 = 9223372036854775807;
    int[32] v9 = 0;
    v9 = (-(v6));
    int[64] v10 = 0;
    v10 = (-(v8));
    uint[8] v11 = 0;
    v11 = (v0 + v1);
    bool v12 = false;
    v12 = (v11 == 4);
    if (v12) {
        uint[32] v13 = 0;
        v13 = (v2 + 1);
        bool v14 = false;
        v14 = (v13 == 0);
        if (v14) {
            uint[32] v15 = 0;
            v15 = (v2 * v2);
            bool v16 = false;
            v16 = (v15 == 1);
            if (v16) {
                uint[64] v17 = 0;
                v17 = (v3 + 1);
                bool v18 = false;
                v18 = (v17 == 0);
                if (v18) {
                    uint[64] v19 = 0;
                    v19 = (v3 * v3);
                    bool v20 = false;
                    v20 = (v19 == 1);
                    if (v20) {
                        uint[64] v21 = 0;
                        v21 = (v3 / 3);
                        bool v22 = false;
                        v22 = (v21 == 6148914691236517205);
                        if (v22) {
                            int[8] v23 = 0;
                            v23 = (v4 + v5);
                            bool v24 = false;
                            v24 = (v23 < 0);
                            if (v24) {
                                int[32] v25 = 0;
                                v25 = (v9 / v7);
                                bool v26 = false;
                                v26 = (v25 == -3);
                                if (v26) {
                                    int[32] v27 = 0;
                                    v27 = (v9 % v7);
                                    bool v28 = false;
                                    v28 = (v27 == -1);
                                    if (v28) {
                                        int[64] v29 = 0;
                                        v29 = (v10 % 10);
                                        bool v30 = false;
                                        v30 = (v29 == -7);
                                        if (v30) {
                                            uint[32] v31 = 0;
                                            v31 = (v2 >> 28);
                                            bool v32 = false;
                                            v32 = (v31 == 15);
                                            if (v32) {
                                                int[32] v33 = 0;
                                                v33 = (v9 >> 1);
                                                bool v34 = false;
                                                v34 = (v33 == -4);
                                                if (v34) {
                                                    return 0;
                                                } else {
                                                    return 12;
                                                }
                                            } else {
                                                return 11;
                                            }
                                        } else {
                                            return 10;
                                        }
                                    } else {
                                        return 9;
                                    }
                                } else {
                                    return 8;
                                }
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
