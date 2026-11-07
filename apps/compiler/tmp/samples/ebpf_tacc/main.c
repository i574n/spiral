#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int32_t v0;
    int32_t v1;
} Tuple0;
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static Tuple0 method2(int32_t v0, int32_t v1, int32_t v2){
    while (1) {
        int32_t v3 = v0 - 1l;
        int32_t v4 = v1 + 1l;
        int32_t v5 = v2 + 2l;
        bool v6 = v3 == 0l;
        if (v6){
            return TupleCreate0(v4, v5);
        } else {
            {
                int32_t tmp0 = v3;
                int32_t tmp1 = v4;
                int32_t tmp2 = v5;
                v0 = tmp0;
                v1 = tmp1;
                v2 = tmp2;
            }
            continue;
        }
    }
}
static Tuple0 method1(int32_t v0){
    int32_t v1 = 0l;
    int32_t v2 = 0l;
    bool v3 = v0 == 0l;
    if (v3){
        return TupleCreate0(v1, v2);
    } else {
        return method2(v0, v1, v2);
    }
}
static int32_t method0(int32_t v0){
    int32_t v1; int32_t v2;
    Tuple0 tmp3 = method1(v0);
    v1 = tmp3.v0; v2 = tmp3.v1;
    bool v3 = v1 == 4l;
    bool v5;
    if (v3){
        bool v4 = v2 == 8l;
        v5 = v4;
    } else {
        v5 = false;
    }
    if (v5){
        return 0l;
    } else {
        return 1l;
    }
}
int32_t main(){
    int32_t v0 = 4l;
    return method0(v0);
}
