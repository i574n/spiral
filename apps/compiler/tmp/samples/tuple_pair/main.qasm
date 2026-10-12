OPENQASM 3.0;
def sp_method0(int[32] p0, int[32] p1) -> (int[32], int[32]) {
    int[32] v0 = p0;
    int[32] v1 = p1;
    return v0, v1;
}
def sp_method1(int[32] p0, int[32] p1) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = p1;
    int[32] v2 = 0;
    v2 = (v0 + v1);
    return v2;
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 20;
    int[32] v1 = 0;
    v1 = 22;
    int[32] v2 = 0;
    int[32] v3 = 0;
    v2, v3 = sp_method0(v0, v1);
    int[32] v4 = 0;
    v4 = sp_method1(v2, v3);
    int[32] v5 = 0;
    v5 = (v4 - 42);
    return v5;
}
output int[32] spiral_io;
spiral_io = spiral_main();
