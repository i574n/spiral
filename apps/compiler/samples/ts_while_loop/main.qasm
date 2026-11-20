OPENQASM 3.0;
def sp_method0(int[32] p0) -> bool {
    int[32] v0 = p0;
    bool v1 = false;
    v1 = (v0 < 10);
    return v1;
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 0;
    int[32] v1 = 0;
    v1 = 0;
    while (true) {
        if (!(sp_method0(v0))) {
            break;
        }
        int[32] v3 = 0;
        v3 = (v1 + v0);
        v1 = v3;
        int[32] v4 = 0;
        v4 = (v0 + 1);
        v0 = v4;
    }
    int[32] v5 = 0;
    v5 = (v1 - 45);
    return v5;
}
output int[32] spiral_io;
spiral_io = spiral_main();
