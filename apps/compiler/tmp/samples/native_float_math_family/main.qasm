OPENQASM 3.0;
def spiral_main() -> int[32] {
    float[32] v0 = 0.0;
    v0 = 0.0;
    float[32] v1 = 0.0;
    v1 = 1.0;
    float[64] v2 = 0.0;
    v2 = 0.0;
    float[64] v3 = 0.0;
    v3 = 1.0;
    float[32] v4 = 0.0;
    v4 = log(v1);
    bool v5 = false;
    v5 = (v4 == v0);
    bool v8 = false;
    if (v5) {
        float[64] v6 = 0.0;
        v6 = log(v3);
        bool v7 = false;
        v7 = (v6 == v2);
        v8 = v7;
    } else {
        v8 = false;
    }
    bool v11 = false;
    if (v8) {
        float[32] v9 = 0.0;
        v9 = exp(v0);
        bool v10 = false;
        v10 = (v9 == v1);
        v11 = v10;
    } else {
        v11 = false;
    }
    bool v14 = false;
    if (v11) {
        float[64] v12 = 0.0;
        v12 = exp(v2);
        bool v13 = false;
        v13 = (v12 == v3);
        v14 = v13;
    } else {
        v14 = false;
    }
    bool v17 = false;
    if (v14) {
        float[32] v15 = 0.0;
        v15 = tanh(v0);
        bool v16 = false;
        v16 = (v15 == v0);
        v17 = v16;
    } else {
        v17 = false;
    }
    bool v20 = false;
    if (v17) {
        float[64] v18 = 0.0;
        v18 = tanh(v2);
        bool v19 = false;
        v19 = (v18 == v2);
        v20 = v19;
    } else {
        v20 = false;
    }
    bool v23 = false;
    if (v20) {
        float[32] v21 = 0.0;
        v21 = sin(v0);
        bool v22 = false;
        v22 = (v21 == v0);
        v23 = v22;
    } else {
        v23 = false;
    }
    bool v26 = false;
    if (v23) {
        float[64] v24 = 0.0;
        v24 = sin(v2);
        bool v25 = false;
        v25 = (v24 == v2);
        v26 = v25;
    } else {
        v26 = false;
    }
    bool v29 = false;
    if (v26) {
        float[32] v27 = 0.0;
        v27 = cos(v0);
        bool v28 = false;
        v28 = (v27 == v1);
        v29 = v28;
    } else {
        v29 = false;
    }
    bool v32 = false;
    if (v29) {
        float[64] v30 = 0.0;
        v30 = cos(v2);
        bool v31 = false;
        v31 = (v30 == v3);
        v32 = v31;
    } else {
        v32 = false;
    }
    if (v32) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
