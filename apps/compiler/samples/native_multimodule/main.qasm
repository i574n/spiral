OPENQASM 3.0;
def sp_method0(int[32] p0, int[32] p1, int[32] p2) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = p1;
    int[32] v2 = p2;
    int[32] v3 = 0;
    v3 = (v0 * v1);
    int[32] v4 = 0;
    v4 = (v3 + v2);
    int[32] v5 = 0;
    v5 = (v4 - 42);
    return v5;
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 5;
    int[32] v1 = 0;
    v1 = 8;
    int[32] v2 = 0;
    v2 = 2;
    return sp_method0(v0, v1, v2);
}
output int[32] spiral_io;
spiral_io = spiral_main();
