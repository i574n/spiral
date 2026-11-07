OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 3;
    int[32] v1 = 0;
    v1 = 4;
    uint[32] v2 = 0;
    v2 = 1;
    uint[32] v3 = 0;
    v3 = 1;
    float[32] v4 = 0.0;
    v4 = 1.5;
    float[32] v5 = 0.0;
    v5 = (-(v4));
    bool v6 = false;
    v6 = (v0 != v1);
    if (v6) {
        bool v7 = false;
        v7 = (v2 != v3);
        if (v7) {
            return 2;
        } else {
            bool v8 = false;
            v8 = (v5 == -1.5);
            if (v8) {
                return 0;
            } else {
                return 3;
            }
        }
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
