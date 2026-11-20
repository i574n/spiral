OPENQASM 3.0;
def sp_fib_0(int[32] p0) -> int[32] {
    int[32] v0 = p0;
    bool v1 = false;
    v1 = (v0 <= 1);
    if (v1) {
        return v0;
    } else {
        int[32] v2 = 0;
        v2 = (v0 - 1);
        int[32] v3 = 0;
        v3 = sp_fib_0(v2);
        int[32] v4 = 0;
        v4 = (v0 - 2);
        int[32] v5 = 0;
        v5 = sp_fib_0(v4);
        int[32] v6 = 0;
        v6 = (v3 + v5);
        return v6;
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 10;
    int[32] v1 = 0;
    v1 = sp_fib_0(v0);
    int[32] v2 = 0;
    v2 = (v1 - 55);
    return v2;
}
output int[32] spiral_io;
spiral_io = spiral_main();
