OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 7;
    int[32] v1 = 0;
    v1 = -2;
    int[32] v2 = 0;
    v2 = -7;
    uint[32] v3 = 0;
    v3 = 100;
    uint[32] v4 = 0;
    v4 = 7;
    int[32] v5 = 0;
    v5 = (v0 / v1);
    int[32] v6 = 0;
    v6 = (v0 % v1);
    int[32] v7 = 0;
    v7 = (v2 / v1);
    int[32] v8 = 0;
    v8 = (v2 % v1);
    uint[32] v9 = 0;
    v9 = (v3 / v4);
    uint[32] v10 = 0;
    v10 = (v3 % v4);
    bool v11 = false;
    v11 = (v5 == -3);
    bool v13 = false;
    if (v11) {
        bool v12 = false;
        v12 = (v6 == 1);
        v13 = v12;
    } else {
        v13 = false;
    }
    bool v15 = false;
    if (v13) {
        bool v14 = false;
        v14 = (v7 == 3);
        v15 = v14;
    } else {
        v15 = false;
    }
    bool v17 = false;
    if (v15) {
        bool v16 = false;
        v16 = (v8 == -1);
        v17 = v16;
    } else {
        v17 = false;
    }
    bool v19 = false;
    if (v17) {
        bool v18 = false;
        v18 = (v9 == 14);
        v19 = v18;
    } else {
        v19 = false;
    }
    bool v21 = false;
    if (v19) {
        bool v20 = false;
        v20 = (v10 == 2);
        v21 = v20;
    } else {
        v21 = false;
    }
    if (v21) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
