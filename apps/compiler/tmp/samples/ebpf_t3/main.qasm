OPENQASM 3.0;
def sp_method2(int[32] p0, int[32] p1, int[32] p2, int[32] p3) -> (int[32], int[32], int[32]) {
    int[32] v0 = p0;
    int[32] v1 = p1;
    int[32] v2 = p2;
    int[32] v3 = p3;
    while (true) {
        int[32] v4 = 0;
        v4 = (v0 - 1);
        int[32] v5 = 0;
        v5 = (v1 + 1);
        int[32] v6 = 0;
        v6 = (v2 + 2);
        int[32] v7 = 0;
        v7 = (v3 + 3);
        bool v8 = false;
        v8 = (v4 == 0);
        if (v8) {
            return v5, v6, v7;
        } else {
            v0 = v4;
            v1 = v5;
            v2 = v6;
            v3 = v7;
            continue;
        }
    }
    return 0, 0, 0;
}
def sp_method1(int[32] p0) -> (int[32], int[32], int[32]) {
    int[32] v0 = p0;
    int[32] v1 = 0;
    v1 = 0;
    int[32] v2 = 0;
    v2 = 0;
    int[32] v3 = 0;
    v3 = 0;
    bool v4 = false;
    v4 = (v0 == 0);
    if (v4) {
        return v1, v2, v3;
    } else {
        return sp_method2(v0, v1, v2, v3);
    }
}
def sp_method0(int[32] p0) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = 0;
    int[32] v2 = 0;
    int[32] v3 = 0;
    v1, v2, v3 = sp_method1(v0);
    bool v4 = false;
    v4 = (v1 == 3);
    bool v6 = false;
    if (v4) {
        bool v5 = false;
        v5 = (v2 == 6);
        v6 = v5;
    } else {
        v6 = false;
    }
    bool v8 = false;
    if (v6) {
        bool v7 = false;
        v7 = (v3 == 9);
        v8 = v7;
    } else {
        v8 = false;
    }
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 3;
    return sp_method0(v0);
}
output int[32] spiral_io;
spiral_io = spiral_main();
