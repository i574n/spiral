OPENQASM 3.0;
def sp_is_answer_1(int[32] p0) -> bool {
    int[32] v0 = p0;
    bool v1 = false;
    v1 = (v0 == 42);
    return v1;
}
def sp_method0(int[32] p0) -> bool {
    int[32] v0 = p0;
    return sp_is_answer_1(v0);
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 42;
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
