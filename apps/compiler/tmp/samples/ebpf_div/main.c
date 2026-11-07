#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    int32_t v0 = 7l;
    int32_t v1 = -2l;
    int32_t v2 = -7l;
    uint32_t v3 = 100ul;
    uint32_t v4 = 7ul;
    int32_t v5 = v0 / v1;
    int32_t v6 = v0 % v1;
    int32_t v7 = v2 / v1;
    int32_t v8 = v2 % v1;
    uint32_t v9 = v3 / v4;
    uint32_t v10 = v3 % v4;
    bool v11 = v5 == -3l;
    bool v13;
    if (v11){
        bool v12 = v6 == 1l;
        v13 = v12;
    } else {
        v13 = false;
    }
    bool v15;
    if (v13){
        bool v14 = v7 == 3l;
        v15 = v14;
    } else {
        v15 = false;
    }
    bool v17;
    if (v15){
        bool v16 = v8 == -1l;
        v17 = v16;
    } else {
        v17 = false;
    }
    bool v19;
    if (v17){
        bool v18 = v9 == 14ul;
        v19 = v18;
    } else {
        v19 = false;
    }
    bool v21;
    if (v19){
        bool v20 = v10 == 2ul;
        v21 = v20;
    } else {
        v21 = false;
    }
    if (v21){
        return 0l;
    } else {
        return 1l;
    }
}
