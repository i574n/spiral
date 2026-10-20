OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = -1;
    int[32] v1 = 0;
    v1 = -8;
    int[32] v2 = 0;
    v2 = (~(v0));
    int[32] v3 = 0;
    v3 = (~(v1));
    bool v4 = false;
    v4 = (v2 == 0);
    bool v6 = false;
    if (v4) {
        bool v5 = false;
        v5 = (v3 == 7);
        v6 = v5;
    } else {
        v6 = false;
    }
    if (v6) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
