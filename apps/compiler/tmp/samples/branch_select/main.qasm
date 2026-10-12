OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 5;
    bool v1 = false;
    v1 = (v0 == 5);
    if (v1) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
