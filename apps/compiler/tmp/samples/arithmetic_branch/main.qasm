OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 6;
    int[32] v1 = 0;
    v1 = 7;
    int[32] v2 = 0;
    v2 = (v0 * v1);
    bool v3 = false;
    v3 = (v2 == 42);
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
