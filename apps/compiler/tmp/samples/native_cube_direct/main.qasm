OPENQASM 3.0;
def sp_method2() -> int[32] {
    return 14;
}
def sp_method1() -> int[32] {
    int[32] v0 = 0;
    v0 = sp_method2();
    int[32] v1 = 0;
    v1 = (14 + v0);
    return v1;
}
def sp_method0() -> int[32] {
    int[32] v0 = 0;
    v0 = sp_method1();
    int[32] v1 = 0;
    v1 = (14 + v0);
    return v1;
}
def spiral_main() -> int[32] {
    return sp_method0();
}
output int[32] spiral_io;
spiral_io = spiral_main();
