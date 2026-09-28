#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t fib0(int32_t v0){
    bool v1;
    v1 = v0 <= 1l;
    if (v1){
        return v0;
    } else {
        int32_t v2;
        v2 = v0 - 1l;
        int32_t v3;
        v3 = fib0(v2);
        int32_t v4;
        v4 = v0 - 2l;
        int32_t v5;
        v5 = fib0(v4);
        int32_t v6;
        v6 = v3 + v5;
        return v6;
    }
}
int32_t main(){
    int32_t v0;
    v0 = 10l;
    int32_t v1;
    v1 = fib0(v0);
    int32_t v2;
    v2 = v1 - 55l;
    return v2;
}
