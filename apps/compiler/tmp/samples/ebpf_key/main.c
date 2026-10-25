#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    int32_t v0 = 3l;
    int32_t v1 = 1l;
    int32_t v2 = v0 << v1;
    int32_t v3 = 0l;
    int32_t v4 = 11l;
    bool v5 = v2 == 6l;
    bool v7;
    if (v5){
        bool v6 = v3 == 0l;
        v7 = v6;
    } else {
        v7 = false;
    }
    bool v9;
    if (v7){
        bool v8 = v4 == 11l;
        v9 = v8;
    } else {
        v9 = false;
    }
    if (v9){
        return 0l;
    } else {
        return 1l;
    }
}
