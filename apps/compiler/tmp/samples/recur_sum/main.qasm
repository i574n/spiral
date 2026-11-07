OPENQASM 3.0;
def sp_sum_0(int[32] p0) -> int[32] {
    int[32] v0 = p0;
    bool v1 = false;
    v1 = (v0 < 1);
    if (v1) {
        return 0;
    } else {
        int[32] v2 = 0;
        v2 = (v0 - 1);
        int[32] v3 = 0;
        v3 = sp_sum_0(v2);
        int[32] v4 = 0;
        v4 = (v0 + v3);
        return v4;
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 4;
    int[32] v1 = 0;
    v1 = sp_sum_0(v0);
    bool v2 = false;
    v2 = (v1 == 10);
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
