OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 20;
    int[32] v1 = 0;
    v1 = 2;
    int[32] v2 = 0;
    v2 = (v0 * v1);
    int[32] v3 = 0;
    v3 = (v2 + 3);
    return v3;
}
output int[32] spiral_io;
spiral_io = spiral_main();
