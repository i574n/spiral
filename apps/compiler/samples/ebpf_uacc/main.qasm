OPENQASM 3.0;
def sp_method1(int[32] p0, uint[32] p1) -> uint[32] {
    int[32] v0 = p0;
    uint[32] v1 = p1;
    while (true) {
        int[32] v2 = 0;
        v2 = (v0 - 1);
        uint[32] v3 = 0;
        v3 = (v1 + 3000000000);
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
def sp_method0(int[32] p0, uint[32] p1) -> uint[32] {
    int[32] v0 = p0;
    uint[32] v1 = p1;
    bool v2 = false;
    v2 = (v0 == 0);
    if (v2) {
        return v1;
    } else {
        return sp_method1(v0, v1);
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 2;
    uint[32] v1 = 0;
    v1 = 0;
    uint[32] v2 = 0;
    v2 = sp_method0(v0, v1);
    bool v3 = false;
    v3 = (v2 == 1705032704);
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
