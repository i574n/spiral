#include "main.hpp"
int score_0(Union0 v0){
    switch (v0.tag) {
        case 0: { // Hit
            int v1 = v0.case0.v0;
            return v1;
            break;
        }
        case 1: { // Miss
            int v2 = v0.case1.v0;
            int v3;
            v3 = -v2;
            return v3;
            break;
        }
        default: {
            assert("Invalid tag." && false);
            exit(-1);
        }
    }
}
int main() {
    bool v0;
    v0 = true;
    Union0 v3;
    if (v0){
        v3 = Union0{Union0_0{7}};
    } else {
        v3 = Union0{Union0_1{3}};
    }
    int v4;
    v4 = score_0(v3);
    int v5;
    v5 = v4 - 7;
    return v5;
}
