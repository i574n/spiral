#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    uint32_t v0 = 4294967295ul;
    uint32_t v1 = 15ul;
    uint32_t v2 = v0 & v1;
    uint32_t v3 = v0 | v1;
    uint32_t v4 = v0 ^ v1;
    uint32_t v5 = ~v1;
    bool v6 = v2 == 15ul;
    bool v8;
    if (v6){
        bool v7 = v3 == v0;
        v8 = v7;
    } else {
        v8 = false;
    }
    bool v10;
    if (v8){
        bool v9 = v4 == v5;
        v10 = v9;
    } else {
        v10 = false;
    }
    bool v12;
    if (v10){
        bool v11 = v5 == 4294967280ul;
        v12 = v11;
    } else {
        v12 = false;
    }
    if (v12){
        return 0l;
    } else {
        return 1l;
    }
}
