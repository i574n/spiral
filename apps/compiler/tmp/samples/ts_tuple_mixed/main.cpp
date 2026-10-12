#include "main.hpp"
Tuple0 method_0(float v0){
    bool v1;
    v1 = v0 >= 3.5f;
    return Tuple0{v1, v0, 7};
}
int method_1(bool v0, float v1, int v2){
    if (v0){
        bool v3;
        v3 = v1 >= 3.5f;
        if (v3){
            int v4;
            v4 = v2 - 7;
            return v4;
        } else {
            return 1;
        }
    } else {
        return 2;
    }
}
int main() {
    float v0;
    v0 = 4.0f;
    bool v1; float v2; int v3;
    Tuple0 tmp0 = method_0(v0);
    v1 = tmp0.v0; v2 = tmp0.v1; v3 = tmp0.v2;
    return method_1(v1, v2, v3);
}
