OPENQASM 3.0;
def sp_method0(uint[32] p0) -> bool {
    uint[32] v0 = p0;
    uint[32] v1 = 0;
    v1 = (v0 + 5);
    uint[32] v2 = 0;
    v2 = (v1 % 4);
    bool v3 = false;
    v3 = (v2 == 0);
    return v3;
}
def spiral_main() -> int[32] {
    uint[32] v0 = 0;
    v0 = 7;
    bool v1 = false;
    v1 = sp_method0(v0);
    if (v1) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
