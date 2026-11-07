OPENQASM 3.0;
def sp_f_0(int[32] p0) -> int[32] {
    int[32] v0 = p0;
    bool v1 = false;
    v1 = (v0 == 1);
    if (v1) {
        return 0;
    } else {
        return 1;
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 1;
    return sp_f_0(v0);
}
output int[32] spiral_io;
spiral_io = spiral_main();
