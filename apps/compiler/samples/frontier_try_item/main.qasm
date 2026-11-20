OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v1 = 0;
    v1 = 42;
    int[32] v3 = 0;
    v3 = (v1 - 42);
    return v3;
}
output int[32] spiral_io;
spiral_io = spiral_main();
