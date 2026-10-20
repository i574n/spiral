OPENQASM 3.0;
def sp_method1(int[32] p0, int[32] p1) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = p1;
    while (true) {
        int[32] v2 = 0;
        v2 = (v0 - 1);
        int[32] v3 = 0;
        v3 = (v1 + 3);
        bool v4 = false;
        v4 = (v2 == 0);
        if (v4) {
            return v3;
        } else {
            int[32] t327_2 = v2;
            int[32] t361_3 = v3;
            v0 = t327_2;
            v1 = t361_3;
            continue;
        }
    }
    return 0;
}
def sp_method0(int[32] p0) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = 0;
    v1 = 0;
    bool v2 = false;
    v2 = (v0 == 0);
    if (v2) {
        return v1;
    } else {
        return sp_method1(v0, v1);
    }
}
def sp_method3(int[32] p0, int[32] p1) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = p1;
    while (true) {
        int[32] v2 = 0;
        v2 = (v0 - 1);
        int[32] v3 = 0;
        v3 = (v1 - 2);
        bool v4 = false;
        v4 = (v2 == 0);
        if (v4) {
            return v3;
        } else {
            int[32] t327_2 = v2;
            int[32] t361_3 = v3;
            v0 = t327_2;
            v1 = t361_3;
            continue;
        }
    }
    return 0;
}
def sp_method2(int[32] p0) -> int[32] {
    int[32] v0 = p0;
    int[32] v1 = 0;
    v1 = 0;
    bool v2 = false;
    v2 = (v0 == 0);
    if (v2) {
        return v1;
    } else {
        return sp_method3(v0, v1);
    }
}
def spiral_main() -> int[32] {
    int[32] v0 = 0;
    v0 = 4;
    int[32] v1 = 0;
    v1 = sp_method0(v0);
    int[32] v2 = 0;
    v2 = sp_method2(v0);
    bool v3 = false;
    v3 = (v1 == 12);
    bool v5 = false;
    if (v3) {
        bool v4 = false;
        v4 = (v2 == -8);
        v5 = v4;
    } else {
        v5 = false;
    }
    if (v5) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
