OPENQASM 3.0;
def spiral_main() -> int[32] {
    uint[32] v0 = 0;
    v0 = 65536;
    uint[32] v1 = 0;
    v1 = 65536;
    uint[32] v2 = 0;
    v2 = 4294967295;
    uint[32] v3 = 0;
    v3 = 3;
    uint[32] v4 = 0;
    v4 = (v0 * v1);
    uint[32] v5 = 0;
    v5 = (v2 * v3);
    bool v6 = false;
    v6 = (v4 == 0);
    bool v8 = false;
    if (v6) {
        bool v7 = false;
        v7 = (v5 == 4294967293);
        v8 = v7;
    } else {
        v8 = false;
    }
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
