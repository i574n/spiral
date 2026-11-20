OPENQASM 3.0;
def sp_method0(int[32] p0) -> (int[32], int[32], int[32], int[32]) {
    int[32] v0 = p0;
    int[32] v1 = 0;
    v1 = (v0 + 1);
    int[32] v2 = 0;
    v2 = (v0 + 2);
    int[32] v3 = 0;
    v3 = (v0 + 3);
    return v0, v1, v2, v3;
}
def sp_method1(int[32] p0, int[32] p1, int[32] p2, int[32] p3) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = p1;
    int[32] v2 = p2;
    int[32] v3 = p3;
    int[32] v4 = 0;
    v4 = (v0 + v1);
    int[32] v5 = 0;
    v5 = (v4 + v2);
    int[32] v6 = 0;
    v6 = (v5 + v3);
    int[32] v7 = 0;
    v7 = (v6 - 10);
    return v7;
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 1;
    int[32] v1 = 0;
    int[32] v2 = 0;
    int[32] v3 = 0;
    int[32] v4 = 0;
    v1, v2, v3, v4 = sp_method0(v0);
    return sp_method1(v1, v2, v3, v4);
}
output int[32] spiral_io;
spiral_io = spiral_main();
