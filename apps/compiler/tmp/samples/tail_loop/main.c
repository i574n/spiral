#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t method1(int32_t v0, int32_t v1){
    int32_t v2;
    v2 = v0 - 1l ;
    int32_t v3;
    v3 = v1 + v0 ;
    bool v4;
    v4 = v2 == 0l ;
    if (v4){
        return v3;
    } else {
        return method1(v2, v3);
    }
}
int32_t method0(int32_t v0){
    int32_t v1;
    v1 = 0l;
    bool v2;
    v2 = v0 == 0l ;
    int32_t v4;
    if (v2){
        v4 = v1;
    } else {
        v4 = method1(v0, v1);
    }
    int32_t v5;
    v5 = v4 - 55l ;
    return v5;
}
int32_t main(){
    int32_t v0;
    v0 = 10l;
    return method0(v0);
}
