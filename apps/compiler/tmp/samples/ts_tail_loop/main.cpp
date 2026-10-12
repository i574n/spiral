#include "main.hpp"
int method_1(int v0, int v1){
    int v2;
    v2 = v0 - 1;
    int v3;
    v3 = v1 + v0;
    bool v4;
    v4 = v2 == 0;
    if (v4){
        return v3;
    } else {
        return method_1(v2, v3);
    }
}
int method_0(int v0){
    int v1;
    v1 = 0;
    bool v2;
    v2 = v0 == 0;
    int v4;
    if (v2){
        v4 = v1;
    } else {
        v4 = method_1(v0, v1);
    }
    int v5;
    v5 = v4 - 55;
    return v5;
}
int main() {
    int v0;
    v0 = 10;
    return method_0(v0);
}
