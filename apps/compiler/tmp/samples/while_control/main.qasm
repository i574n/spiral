OPENQASM 3.0;
def sp_method0() -> bool {
    return true;
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 0;
    int[32] v1 = 0;
    v1 = 0;
    while (true) {
        if (!(sp_method0())) {
            break;
        }
        int[32] v3 = 0;
        v3 = (v0 + 1);
        v0 = v3;
        bool v4 = false;
        v4 = (v0 < 3);
        if (v4) {
            continue;
        } else {
            bool v5 = false;
            v5 = (v0 >= 6);
            if (v5) {
                break;
            } else {
                int[32] v6 = 0;
                v6 = (v1 + v0);
                v1 = v6;
            }
        }
    }
    int[32] v7 = 0;
    v7 = (v1 - 12);
    return v7;
}
output int[32] spiral_io;
spiral_io = spiral_main();
