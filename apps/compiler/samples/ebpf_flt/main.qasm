OPENQASM 3.0;
def spiral_main() -> int[32] {
    float[32] v0 = 0.0;
    v0 = -2.0;
    float[32] v1 = 0.0;
    v1 = -1.0;
    float[32] v2 = 0.0;
    v2 = 0.0;
    bool v3 = false;
    v3 = (v0 < v1);
    bool v5 = false;
    if (v3) {
        bool v4 = false;
        v4 = (v1 < v2);
        v5 = v4;
    } else {
        v5 = false;
    }
    bool v8 = false;
    if (v5) {
        bool v6 = false;
        v6 = (v0 > v1);
        bool v7 = false;
        v7 = (v6 == false);
        v8 = v7;
    } else {
        v8 = false;
    }
    bool v11 = false;
    if (v8) {
        bool v9 = false;
        v9 = (v0 >= v1);
        bool v10 = false;
        v10 = (v9 == false);
        v11 = v10;
    } else {
        v11 = false;
    }
    bool v13 = false;
    if (v11) {
        bool v12 = false;
        v12 = (v1 <= v2);
        v13 = v12;
    } else {
        v13 = false;
    }
    if (v13) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
