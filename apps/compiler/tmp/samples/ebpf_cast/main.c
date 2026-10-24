#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    int32_t v0 = 3l;
    int32_t v1 = -2l;
    uint32_t v2 = 7ul;
    float v3 = 2.9f;
    float v4 = (float)v0;
    float v5 = (float)v1;
    float v6 = (float)v2;
    uint32_t v7 = (uint32_t)v3;
    bool v8 = v4 == 3.0f;
    bool v10;
    if (v8){
        bool v9 = v5 == -2.0f;
        v10 = v9;
    } else {
        v10 = false;
    }
    bool v12;
    if (v10){
        bool v11 = v6 == 7.0f;
        v12 = v11;
    } else {
        v12 = false;
    }
    bool v14;
    if (v12){
        bool v13 = v7 == 2ul;
        v14 = v13;
    } else {
        v14 = false;
    }
    if (v14){
        return 0l;
    } else {
        return 1l;
    }
}
