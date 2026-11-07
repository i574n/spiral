OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[8] v0 = 0;
    v0 = 100;
    int[8] v1 = 0;
    v1 = (v0 + v0);
    uint[8] v2 = 0;
    v2 = 200;
    uint[8] v3 = 0;
    v3 = 100;
    uint[8] v4 = 0;
    v4 = (v2 + v3);
    int[8] v5 = 0;
    v5 = -8;
    int[8] v6 = 0;
    v6 = (v5 >> 1);
    uint[8] v7 = 0;
    v7 = (v2 >> 1);
    int[16] v8 = 0;
    v8 = 20000;
    int[16] v9 = 0;
    v9 = (v8 + v8);
    uint[16] v10 = 0;
    v10 = 40000;
    uint[16] v11 = 0;
    v11 = (v10 + v10);
    int[32] v12 = 0;
    v12 = 7;
    int[8] v13 = 0;
    v13 = v12;
    int[8] v14 = 0;
    v14 = 9;
    int[32] v15 = 0;
    v15 = v14;
    bool v16 = false;
    v16 = (v1 == -56);
    bool v18 = false;
    if (v16) {
        bool v17 = false;
        v17 = (v4 == 44);
        v18 = v17;
    } else {
        v18 = false;
    }
    bool v20 = false;
    if (v18) {
        bool v19 = false;
        v19 = (v6 == -4);
        v20 = v19;
    } else {
        v20 = false;
    }
    bool v22 = false;
    if (v20) {
        bool v21 = false;
        v21 = (v7 == 100);
        v22 = v21;
    } else {
        v22 = false;
    }
    bool v24 = false;
    if (v22) {
        bool v23 = false;
        v23 = (v9 == -25536);
        v24 = v23;
    } else {
        v24 = false;
    }
    bool v26 = false;
    if (v24) {
        bool v25 = false;
        v25 = (v11 == 14464);
        v26 = v25;
    } else {
        v26 = false;
    }
    bool v28 = false;
    if (v26) {
        bool v27 = false;
        v27 = (v13 == 7);
        v28 = v27;
    } else {
        v28 = false;
    }
    bool v30 = false;
    if (v28) {
        bool v29 = false;
        v29 = (v15 == 9);
        v30 = v29;
    } else {
        v30 = false;
    }
    if (v30) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
