OPENQASM 3.0;
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 65;
    int[32] v1 = 0;
    v1 = 66;
    bool v2 = false;
    v2 = (v0 == 65);
    if (v2) {
        bool v3 = false;
        v3 = (v1 == 66);
        if (v3) {
            bool v4 = false;
            v4 = (v0 == v1);
            if (v4) {
                return 2;
            } else {
                return 0;
            }
        } else {
            return 3;
        }
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
