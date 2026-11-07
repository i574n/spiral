OPENQASM 3.0;
def sp_is_odd_1(int[32] p0) -> bool {
    int[32] v0 = p0;
    bool v1 = false;
    v1 = (v0 == 0);
    if (v1) {
        return false;
    } else {
        int[32] v2 = 0;
        v2 = (v0 - 1);
        return sp_is_even_0(v2);
    }
}
def sp_is_even_0(int[32] p0) -> bool {
    int[32] v0 = p0;
    bool v1 = false;
    v1 = (v0 == 0);
    if (v1) {
        return true;
    } else {
        int[32] v2 = 0;
        v2 = (v0 - 1);
        return sp_is_odd_1(v2);
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 10;
    bool v1 = false;
    v1 = sp_is_even_0(v0);
    if (v1) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
