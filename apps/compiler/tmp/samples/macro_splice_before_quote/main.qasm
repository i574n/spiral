OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 7;
    int[32] v1 = 0;
    v1 = 5;
    int[32] v2 = 0;
    v2 = v1 * 2;
    int[32] v3 = 0;
    v3 = v0;
    int[32] v4 = 0;
    v4 = (v2 + v3);
    return v4;
}
output int[32] spiral_io;
spiral_io = spiral_main();
