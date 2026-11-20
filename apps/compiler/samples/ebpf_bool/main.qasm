OPENQASM 3.0;
def sp_method0(bool p0) -> int[32] {
    bool v0 = p0;
    if (v0) {
        return 1;
    } else {
        return 3;
    }
}
def sp_method1(bool p0, bool p1) -> int[32] {
    bool v0 = p0;
    bool v1 = p1;
    bool v2 = false;
    v2 = (v0 && v1);
    if (v2) {
        return 1;
    } else {
        bool v3 = false;
        v3 = (v0 || v1);
        if (v3) {
            return 2;
        } else {
            return 3;
        }
    }
}
def sp_method2(bool p0) -> int[32] {
    bool v0 = p0;
    if (v0) {
        return 1;
    } else {
        return 3;
    }
}
def spiral_main() -> int[32] {
    bool v0 = false;
    v0 = true;
    bool v1 = false;
    v1 = false;
    int[32] v2 = 0;
    v2 = sp_method0(v0);
    int[32] v3 = 0;
    v3 = sp_method1(v0, v1);
    int[32] v4 = 0;
    v4 = sp_method2(v1);
    bool v5 = false;
    v5 = (v0 == v1);
    bool v6 = false;
    v6 = (v5 == false);
    bool v7 = false;
    v7 = (v2 == 1);
    bool v9 = false;
    if (v7) {
        bool v8 = false;
        v8 = (v3 == 2);
        v9 = v8;
    } else {
        v9 = false;
    }
    bool v11 = false;
    if (v9) {
        bool v10 = false;
        v10 = (v4 == 3);
        v11 = v10;
    } else {
        v11 = false;
    }
    bool v12 = false;
    v12 = (v11 && v6);
    if (v12) {
        return 0;
    } else {
        return 1;
    }
}
output int[32] spiral_io;
spiral_io = spiral_main();
