OPENQASM 3.0;
def sp_method0(int[32] p0, int[32] p1) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = p1;
    int[32] v2 = 0;
    v2 = (v0 + v1);
    int[32] v3 = 0;
    v3 = (v2 - 42);
    return v3;
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 20;
    int[32] v1 = 0;
    v1 = 22;
    return sp_method0(v0, v1);
}
output int[32] spiral_io;
spiral_io = spiral_main();
