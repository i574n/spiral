OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = (-2147483648);
    uint[32] v1 = 0;
    v1 = 4294967295;
    int[32] v2 = 0;
    v2 = -1;
    float[32] v3 = 0.0;
    v3 = 0.0;
    float[32] v4 = 0.0;
    v4 = 1.9;
    float[32] v5 = 0.0;
    v5 = 2.9;
    uint[32] v6 = 0;
    v6 = 4294967294;
    uint[32] v7 = 0;
    v7 = 5;
    uint[32] v8 = 0;
    v8 = 0;
    float[32] v9 = 0.0;
    v9 = (v3 - v4);
    uint[32] v10 = 0;
    v10 = v0;
    int[32] v11 = 0;
    v11 = v10;
    int[32] v12 = 0;
    v12 = v1;
    uint[32] v13 = 0;
    v13 = v2;
    int[32] v14 = 0;
    v14 = int[32](v9);
    int[32] v15 = 0;
    v15 = int[32](v5);
    uint[32] v16 = 0;
    v16 = (v10 / 2);
    uint[32] v17 = 0;
    v17 = (v6 / 2);
    uint[32] v18 = 0;
    v18 = (v7 % 3);
    uint[32] v19 = 0;
    v19 = (~(v8));
    uint[32] v20 = 0;
    v20 = (v1 >> 31);
    bool v21 = false;
    v21 = (v0 < -1);
    bool v23 = false;
    if (v21) {
        bool v22 = false;
        v22 = (v0 <= v0);
        v23 = v22;
    } else {
        v23 = false;
    }
    bool v26 = false;
    if (v23) {
        bool v24 = false;
        v24 = (v0 > 0);
        bool v25 = false;
        v25 = (v24 == false);
        v26 = v25;
    } else {
        v26 = false;
    }
    if (v26) {
        bool v27 = false;
        v27 = (v10 > 1);
        bool v29 = false;
        if (v27) {
            bool v28 = false;
            v28 = (v11 == v0);
            v29 = v28;
        } else {
            v29 = false;
        }
        bool v31 = false;
        if (v29) {
            bool v30 = false;
            v30 = (v12 == v2);
            v31 = v30;
        } else {
            v31 = false;
        }
        bool v33 = false;
        if (v31) {
            bool v32 = false;
            v32 = (v13 == v1);
            v33 = v32;
        } else {
            v33 = false;
        }
        if (v33) {
            bool v34 = false;
            v34 = (v14 == v2);
            bool v36 = false;
            if (v34) {
                bool v35 = false;
                v35 = (v15 == 2);
                v36 = v35;
            } else {
                v36 = false;
            }
            if (v36) {
                bool v37 = false;
                v37 = (v16 == 1073741824);
                bool v39 = false;
                if (v37) {
                    bool v38 = false;
                    v38 = (v17 == 2147483647);
                    v39 = v38;
                } else {
                    v39 = false;
                }
                bool v41 = false;
                if (v39) {
                    bool v40 = false;
                    v40 = (v18 == 2);
                    v41 = v40;
                } else {
                    v41 = false;
                }
                if (v41) {
                    bool v42 = false;
                    v42 = (v19 == v1);
                    bool v44 = false;
                    if (v42) {
                        bool v43 = false;
                        v43 = (v20 == 1);
                        v44 = v43;
                    } else {
                        v44 = false;
                    }
                    if (v44) {
                        return 0;
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
