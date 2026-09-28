#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t method1(int32_t v0){
    int32_t v1;
    v1 = v0 - 1l;
    bool v2;
    v2 = v1 == 0l;
    if (v2){
        return 0l;
    } else {
        return method1(v1);
    }
}
int32_t method0(int32_t v0){
    bool v1;
    v1 = v0 == 0l;
    if (v1){
        return 0l;
    } else {
        return method1(v0);
    }
}
int32_t main(){
    int32_t v0;
    v0 = 1000000l;
    return method0(v0);
}
