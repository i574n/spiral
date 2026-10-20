OPENQASM 3.0;
def sp_count_0(int[32] p0) -> int[32] {
    int[32] v0 = p0;
    while (true) {
        bool v1 = false;
        v1 = (v0 <= 0);
        if (v1) {
            return 0;
        } else {
            int[32] v2 = 0;
            v2 = (v0 - 1);
            int[32] t251_2 = v2;
            v0 = t251_2;
            continue;
        }
    }
    return 0;
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 5;
    return sp_count_0(v0);
}
output int[32] spiral_io;
spiral_io = spiral_main();
