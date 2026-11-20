#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    uint32_t v0 = 65536ul;
    uint32_t v1 = 65536ul;
    uint32_t v2 = 4294967295ul;
    uint32_t v3 = 3ul;
    uint32_t v4 = v0 * v1;
    uint32_t v5 = v2 * v3;
    bool v6 = v4 == 0ul;
    bool v8;
    if (v6){
        bool v7 = v5 == 4294967293ul;
        v8 = v7;
    } else {
        v8 = false;
    }
    if (v8){
        return 0l;
    } else {
        return 1l;
    }
}
