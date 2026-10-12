#include "main.hpp"
int count_down_0(int v0, int v1){
    bool v2;
    v2 = 0 < v0;
    if (v2){
        int v3;
        v3 = v0 - 1;
        int v4;
        v4 = v1 + 1;
        return count_down_0(v3, v4);
    } else {
        return v1;
    }
}
int main() {
    int v0;
    v0 = 5000;
    int v1;
    v1 = 0;
    int v2;
    v2 = count_down_0(v0, v1);
    bool v3;
    v3 = v2 == 5000;
    if (v3){
        return 0;
    } else {
        return 1;
    }
}
