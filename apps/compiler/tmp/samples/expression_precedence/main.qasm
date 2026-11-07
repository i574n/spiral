OPENQASM 3.0;
def sp_method0(int[32] p0, int[32] p1) -> bool {
    int[32] v0 = p0;
    int[32] v1 = p1;
    int[32] v2 = 0;
    v2 = -v0;
    bool v3 = false;
    v3 = (v2 <= 0);
    if (v3) {
        int[32] v4 = 0;
        v4 = (v1 * 2);
        int[32] v5 = 0;
        v5 = (v0 + v4);
        bool v6 = false;
        v6 = (v5 >= 9);
        if (v6) {
            return true;
        } else {
            bool v7 = false;
            v7 = (v1 == 0);
            return v7;
        }
    } else {
        return false;
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 3;
    int[32] v1 = 0;
    v1 = 3;
    bool v2 = false;
    v2 = sp_method0(v0, v1);
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
