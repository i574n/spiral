OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[8] v0 = 0;
    v0 = 100;
    int[8] v1 = 0;
    v1 = 3;
    int[8] v2 = 0;
    v2 = (v0 * v1);
    int[8] v3 = 0;
    v3 = -8;
    int[8] v4 = 0;
    v4 = 2;
    int[8] v5 = 0;
    v5 = (v3 / v4);
    int[8] v6 = 0;
    v6 = (v3 % v1);
    int[8] v7 = 0;
    v7 = (-(v1));
    int[8] v8 = 0;
    v8 = (v0 << 1);
    uint[8] v9 = 0;
    v9 = 200;
    uint[8] v10 = 0;
    v10 = 3;
    uint[8] v11 = 0;
    v11 = (v9 / v10);
    uint[8] v12 = 0;
    v12 = (v9 % v10);
    uint[8] v13 = 0;
    v13 = 15;
    uint[8] v14 = 0;
    v14 = (v9 & v13);
    uint[8] v15 = 0;
    v15 = (v9 | v13);
    uint[8] v16 = 0;
    v16 = (v9 ^ v13);
    uint[8] v17 = 0;
    v17 = (~(v13));
    int[16] v18 = 0;
    v18 = 20000;
    int[16] v19 = 0;
    v19 = 7;
    int[16] v20 = 0;
    v20 = (v18 / v19);
    int[16] v21 = 0;
    v21 = (v18 % v19);
    int[16] v22 = 0;
    v22 = (-(v18));
    uint[16] v23 = 0;
    v23 = 40000;
    uint[16] v24 = 0;
    v24 = (v23 << 1);
    bool v25 = false;
    v25 = (v2 == 44);
    bool v27 = false;
    if (v25) {
        bool v26 = false;
        v26 = (v5 == -4);
        v27 = v26;
    } else {
        v27 = false;
    }
    bool v29 = false;
    if (v27) {
        bool v28 = false;
        v28 = (v6 == -2);
        v29 = v28;
    } else {
        v29 = false;
    }
    bool v31 = false;
    if (v29) {
        bool v30 = false;
        v30 = (v7 == -3);
        v31 = v30;
    } else {
        v31 = false;
    }
    bool v33 = false;
    if (v31) {
        bool v32 = false;
        v32 = (v8 == -56);
        v33 = v32;
    } else {
        v33 = false;
    }
    bool v35 = false;
    if (v33) {
        bool v34 = false;
        v34 = (v11 == 66);
        v35 = v34;
    } else {
        v35 = false;
    }
    bool v37 = false;
    if (v35) {
        bool v36 = false;
        v36 = (v12 == 2);
        v37 = v36;
    } else {
        v37 = false;
    }
    bool v39 = false;
    if (v37) {
        bool v38 = false;
        v38 = (v14 == 8);
        v39 = v38;
    } else {
        v39 = false;
    }
    bool v41 = false;
    if (v39) {
        bool v40 = false;
        v40 = (v15 == 207);
        v41 = v40;
    } else {
        v41 = false;
    }
    bool v43 = false;
    if (v41) {
        bool v42 = false;
        v42 = (v16 == 199);
        v43 = v42;
    } else {
        v43 = false;
    }
    bool v45 = false;
    if (v43) {
        bool v44 = false;
        v44 = (v17 == 240);
        v45 = v44;
    } else {
        v45 = false;
    }
    bool v47 = false;
    if (v45) {
        bool v46 = false;
        v46 = (v20 == 2857);
        v47 = v46;
    } else {
        v47 = false;
    }
    bool v49 = false;
    if (v47) {
        bool v48 = false;
        v48 = (v21 == 1);
        v49 = v48;
    } else {
        v49 = false;
    }
    bool v51 = false;
    if (v49) {
        bool v50 = false;
        v50 = (v22 == -20000);
        v51 = v50;
    } else {
        v51 = false;
    }
    bool v53 = false;
    if (v51) {
        bool v52 = false;
        v52 = (v24 == 14464);
        v53 = v52;
    } else {
        v53 = false;
    }
    if (v53) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
