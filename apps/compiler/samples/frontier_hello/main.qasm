OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 42;
    int[32] v1 = 0;
    v1 = (v0 - 42);
    return v1;
}
output int[32] spiral_io;
spiral_io = spiral_main();
