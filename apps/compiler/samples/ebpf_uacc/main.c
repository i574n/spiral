#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
static uint32_t method1(int32_t v0, uint32_t v1){
    while (1) {
        int32_t v2 = v0 - 1l;
        uint32_t v3 = v1 + 3000000000ul;
        bool v4 = v2 == 0l;
        if (v4){
            return v3;
        } else {
            {
                int32_t tmp0 = v2;
                uint32_t tmp1 = v3;
                v0 = tmp0;
                v1 = tmp1;
            }
            continue;
        }
    }
}
static uint32_t method0(int32_t v0, uint32_t v1){
    bool v2 = v0 == 0l;
    if (v2){
        return v1;
    } else {
        return method1(v0, v1);
    }
}
int32_t main(){
    int32_t v0 = 2l;
    uint32_t v1 = 0ul;
    uint32_t v2 = method0(v0, v1);
    bool v3 = v2 == 1705032704ul;
    if (v3){
        return 0l;
    } else {
        return 1l;
    }
}
