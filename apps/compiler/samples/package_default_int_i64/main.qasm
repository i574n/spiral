OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[64] v0 = 0;
    v0 = 3000000000;
    bool v1 = false;
    v1 = (v0 > 2999999999);
    if (v1) {
        return 7;
    } else {
        return 0;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
