OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 7;
    int[32] v1 = 0;
    v1 = (v0 * 2);
    bool v2 = false;
    v2 = (v1 != 14);
    if (v2) {
        return 1;
    } else {
        return 0;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
