#include "main.hpp"
Union1 decide_a_0(Union0 v0){
    switch (v0.tag) {
        case 0: { // RawA
            int v1 = v0.case0.v0;
            return Union1{Union1_DecidedA{v1, true}};
            break;
        }
        default: {
            assert("Invalid tag." && false);
            exit(-1);
        }
    }
}
Union3 decide_b_1(Union2 v0){
    switch (v0.tag) {
        case 1: { // RawB
            int v1 = v0.case1.v0;
            return Union3{Union3_DecidedB{true, v1}};
            break;
        }
        default: {
            assert("Invalid tag." && false);
            exit(-1);
        }
    }
}
Union5 decide_c_2(Union4 v0){
    switch (v0.tag) {
        case 0: { // RawC
            int v1 = v0.case0.v0;
            return Union5{Union5_DecidedC{v1, true}};
            break;
        }
        default: {
            assert("Invalid tag." && false);
            exit(-1);
        }
    }
}
Union6 finalize_c_3(Union5 v0){
    switch (v0.tag) {
        case 1: { // DecidedC
            int v1 = v0.case1.v0; bool v2 = v0.case1.v1;
            return Union6{Union6_FinalC{v2}};
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
    v0 = 7;
    Union0 v1;
    v1 = Union0{Union0_RawA{v0}};
    Union1 v2;
    v2 = decide_a_0(v1);
    int v3;
    v3 = 9;
    Union2 v4;
    v4 = Union2{Union2_RawB{v3}};
    Union3 v5;
    v5 = decide_b_1(v4);
    int v6;
    v6 = 11;
    Union4 v7;
    v7 = Union4{Union4_RawC{v6}};
    Union5 v8;
    v8 = decide_c_2(v7);
    Union6 v9;
    v9 = finalize_c_3(v8);
    bool v12;
    switch (v2.tag) {
        case 1: { // DecidedA
            int v10 = v2.case1.v0; bool v11 = v2.case1.v1;
            v12 = v11;
            break;
        }
        default: {
            assert("Invalid tag." && false);
            exit(-1);
        }
    }
    bool v15;
    switch (v5.tag) {
        case 0: { // DecidedB
            bool v13 = v5.case0.v0; int v14 = v5.case0.v1;
            v15 = v13;
            break;
        }
        default: {
            assert("Invalid tag." && false);
            exit(-1);
        }
    }
    bool v17;
    switch (v9.tag) {
        case 2: { // FinalC
            bool v16 = v9.case2.v0;
            v17 = v16;
            break;
        }
        default: {
            assert("Invalid tag." && false);
            exit(-1);
        }
    }
    bool v18;
    v18 = v12 && v15;
    bool v19;
    v19 = v18 && v17;
    if (v19){
        return 0;
    } else {
        return 1;
    }
}
