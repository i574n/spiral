OPENQASM 3.0;
def sp_method1(int[32] p0, int[32] p1) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = p1;
    while (true) {
        int[32] v2 = 0;
        v2 = (v0 - 1);
        int[32] v3 = 0;
        v3 = (v1 + v0);
        bool v4 = false;
        v4 = (v2 == 0);
        if (v4) {
            return v3;
        } else {
            v0 = v2;
            v1 = v3;
            continue;
        }
    }
    return 0;
}
def sp_method0(int[32] p0) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = 0;
    v1 = 0;
    bool v2 = false;
    v2 = (v0 == 0);
    int[32] v4 = 0;
    if (v2) {
        v4 = v1;
    } else {
        v4 = sp_method1(v0, v1);
    }
    int[32] v5 = 0;
    v5 = (v4 - 55);
    return v5;
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 10;
    return sp_method0(v0);
}
output int[32] spiral_io;
spiral_io = spiral_main();
