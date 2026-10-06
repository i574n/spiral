#include "main.hpp"
int sum_0(sptr<Union0> v0){
    switch (v0.base->tag) {
        case 1: { // Cons
            int v1 = v0.base->case1.v0; sptr<Union0> v2 = v0.base->case1.v1;
            int v3;
            v3 = sum_0(v2);
            int v4;
            v4 = v1 + v3;
            return v4;
            break;
        }
        case 0: { // Nil
            return 0;
            break;
        }
        default: {
            assert("Invalid tag." && false);
            exit(-1);
        }
    }
}
int main() {
    int v0;
    v0 = 1;
    int v1;
    v1 = 2;
    int v2;
    v2 = 3;
    sptr<Union0> v3;
    v3 = sptr<Union0>{new Union0{Union0_0{}}};
    sptr<Union0> v4;
    v4 = sptr<Union0>{new Union0{Union0_1{v2, v3}}};
    sptr<Union0> v5;
    v5 = sptr<Union0>{new Union0{Union0_1{v1, v4}}};
    sptr<Union0> v6;
    v6 = sptr<Union0>{new Union0{Union0_1{v0, v5}}};
    int v7;
    v7 = sum_0(v6);
    int v8;
    v8 = v7 - 6;
    return v8;
}
