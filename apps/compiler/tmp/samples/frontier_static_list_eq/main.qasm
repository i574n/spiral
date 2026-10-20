OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 120;
    bool v1 = false;
    v1 = (v0 == 32);
    bool v3 = false;
    if (v1) {
        v3 = true;
    } else {
        bool v2 = false;
        v2 = (v0 == 47);
        v3 = v2;
    }
    if (v3) {
        return 1;
    } else {
        return 0;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
