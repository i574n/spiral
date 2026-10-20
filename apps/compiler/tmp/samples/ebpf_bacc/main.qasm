OPENQASM 3.0;
def sp_method1(int[32] p0, bool p1) -> bool {
    int[32] v0 = p0;
    bool v1 = p1;
    while (true) {
        int[32] v2 = 0;
        v2 = (v0 - 1);
        bool v4 = false;
        if (v1) {
            bool v3 = false;
            v3 = (v0 > 0);
            v4 = v3;
        } else {
            v4 = false;
        }
        bool v5 = false;
        v5 = (v2 == 0);
        if (v5) {
            return v4;
        } else {
            int[32] t448_2 = v2;
            bool t482_4 = v4;
            v0 = t448_2;
            v1 = t482_4;
            continue;
        }
    }
    return false;
}
def sp_method0(int[32] p0) -> bool {
    int[32] v0 = p0;
    bool v1 = false;
    v1 = true;
    bool v2 = false;
    v2 = (v0 == 0);
    if (v2) {
        return v1;
    } else {
        return sp_method1(v0, v1);
    }
}
def sp_method2(int[32] p0) -> bool {
    int[32] v0 = p0;
    bool v1 = false;
    v1 = false;
    bool v2 = false;
    v2 = (v0 == 0);
    if (v2) {
        return v1;
    } else {
        return sp_method1(v0, v1);
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 3;
    bool v1 = false;
    v1 = sp_method0(v0);
    bool v2 = false;
    v2 = sp_method2(v0);
    if (v1) {
        if (v2) {
            return 1;
        } else {
            return 0;
        }
    } else {
        return 2;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
