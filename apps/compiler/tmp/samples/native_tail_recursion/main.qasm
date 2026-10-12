OPENQASM 3.0;
def sp_method1(int[32] p0) -> int[32] {
    int[32] v0 = p0;
    while (true) {
        int[32] v1 = 0;
        v1 = (v0 - 1);
        bool v2 = false;
        v2 = (v1 == 0);
        if (v2) {
            return 0;
        } else {
            int[32] t243_1 = v1;
            v0 = t243_1;
            continue;
        }
    }
    return 0;
}
def sp_method0(int[32] p0) -> int[32] {
    int[32] v0 = p0;
    bool v1 = false;
    v1 = (v0 == 0);
    if (v1) {
        return 0;
    } else {
        return sp_method1(v0);
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 1000000;
    return sp_method0(v0);
}
output int[32] spiral_io;
spiral_io = spiral_main();
