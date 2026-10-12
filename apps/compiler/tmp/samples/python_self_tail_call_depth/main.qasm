OPENQASM 3.0;
def sp_count_down_0(int[32] p0, int[32] p1) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = p1;
    while (true) {
        bool v2 = false;
        v2 = (0 < v0);
        if (v2) {
            int[32] v3 = 0;
            v3 = (v0 - 1);
            int[32] v4 = 0;
            v4 = (v1 + 1);
            int[32] t305_3 = v3;
            int[32] t339_4 = v4;
            v0 = t305_3;
            v1 = t339_4;
            continue;
        } else {
            return v1;
        }
    }
    return 0;
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 5000;
    int[32] v1 = 0;
    v1 = 0;
    int[32] v2 = 0;
    v2 = sp_count_down_0(v0, v1);
    bool v3 = false;
    v3 = (v2 == 5000);
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
