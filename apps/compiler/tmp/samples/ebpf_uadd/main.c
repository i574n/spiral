#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    uint32_t v0 = 2147483647ul;
    uint32_t v1 = 2ul;
    uint32_t v2 = 1ul;
    uint32_t v3 = v0 + v1;
    uint32_t v4 = v0 + v2;
    bool v5 = v3 == 2147483649ul;
    bool v7;
    if (v5){
        bool v6 = v4 == 2147483648ul;
        v7 = v6;
    } else {
        v7 = false;
    }
    if (v7){
        return 0l;
    } else {
        return 1l;
    }
}
