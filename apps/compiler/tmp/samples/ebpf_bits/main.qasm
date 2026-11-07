OPENQASM 3.0;
def spiral_main() -> int[32] {
    uint[32] v0 = 0;
    v0 = 4294967295;
    uint[32] v1 = 0;
    v1 = 15;
    uint[32] v2 = 0;
    v2 = (v0 & v1);
    uint[32] v3 = 0;
    v3 = (v0 | v1);
    uint[32] v4 = 0;
    v4 = (v0 ^ v1);
    uint[32] v5 = 0;
    v5 = (~(v1));
    bool v6 = false;
    v6 = (v2 == 15);
    bool v8 = false;
    if (v6) {
        bool v7 = false;
        v7 = (v3 == v0);
        v8 = v7;
    } else {
        v8 = false;
    }
    bool v10 = false;
    if (v8) {
        bool v9 = false;
        v9 = (v4 == v5);
        v10 = v9;
    } else {
        v10 = false;
    }
    bool v12 = false;
    if (v10) {
        bool v11 = false;
        v11 = (v5 == 4294967280);
        v12 = v11;
    } else {
        v12 = false;
    }
    if (v12) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
