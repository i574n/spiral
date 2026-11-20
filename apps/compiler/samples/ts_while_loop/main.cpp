#include "main.hpp"
inline bool while_method_0(int v0){
    bool v1;
    v1 = v0 < 10;
    return v1;
}
int main() {
    int v0;
    v0 = 0;
    int v1;
    v1 = 0;
    while (while_method_0(v0)){
        int v3;
        v3 = v1 + v0;
        v1 = v3;
        int v4;
        v4 = v0 + 1;
        v0 = v4;
    }
    int v5;
    v5 = v1 - 45;
    return v5;
}
