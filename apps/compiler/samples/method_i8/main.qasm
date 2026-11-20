OPENQASM 3.0;
def sp_method0(int[8] p0) -> int[8] {
    int[8] v0 = p0;
    bool v1 = false;
    v1 = (v0 == 0);
    if (v1) {
        return 1;
    } else {
        return v0;
    }
}
def spiral_main() -> int[32] {
    int[8] v0 = 0;
    v0 = 100;
    int[8] v1 = 0;
    v1 = sp_method0(v0);
    bool v2 = false;
    v2 = (v1 == 100);
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
