OPENQASM 3.0;
def sp_method2(int[32] p0, int[32] p1, int[32] p2) -> (int[32], int[32]) {
    int[32] v0 = p0;
    int[32] v1 = p1;
    int[32] v2 = p2;
    while (true) {
        int[32] v3 = 0;
        v3 = (v0 - 1);
        int[32] v4 = 0;
        v4 = (v1 + 1);
        int[32] v5 = 0;
        v5 = (v2 + 2);
        bool v6 = false;
        v6 = (v3 == 0);
        if (v6) {
            return v4, v5;
        } else {
            int[32] t425_3 = v3;
            int[32] t459_4 = v4;
            int[32] t493_5 = v5;
            v0 = t425_3;
            v1 = t459_4;
            v2 = t493_5;
            continue;
        }
    }
    return 0, 0;
}
def sp_method1(int[32] p0) -> (int[32], int[32]) {
    int[32] v0 = p0;
    int[32] v1 = 0;
    v1 = 0;
    int[32] v2 = 0;
    v2 = 0;
    bool v3 = false;
    v3 = (v0 == 0);
    if (v3) {
        return v1, v2;
    } else {
        return sp_method2(v0, v1, v2);
    }
}
def sp_method0(int[32] p0) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = 0;
    int[32] v2 = 0;
    v1, v2 = sp_method1(v0);
    bool v3 = false;
    v3 = (v1 == 4);
    bool v5 = false;
    if (v3) {
        bool v4 = false;
        v4 = (v2 == 8);
        v5 = v4;
    } else {
        v5 = false;
    }
    if (v5) {
        return 0;
    } else {
        return 1;
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 4;
    return sp_method0(v0);
}
output int[32] spiral_io;
spiral_io = spiral_main();
