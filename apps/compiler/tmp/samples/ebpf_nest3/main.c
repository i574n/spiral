#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int32_t v0;
    uint32_t v1;
    float v2;
} Tuple0;
static inline Tuple0 TupleCreate0(int32_t v0, uint32_t v1, float v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
static Tuple0 method1(int32_t v0, uint32_t v1, float v2){
    return TupleCreate0(v0, v1, v2);
}
static int32_t method0(int32_t v0, uint32_t v1, float v2){
    int32_t v3; uint32_t v4; float v5;
    Tuple0 tmp0 = method1(v0, v1, v2);
    v3 = tmp0.v0; v4 = tmp0.v1; v5 = tmp0.v2;
    bool v6 = v3 == 2l;
    bool v8;
    if (v6){
        bool v7 = v4 == 3ul;
        v8 = v7;
    } else {
        v8 = false;
    }
    bool v10;
    if (v8){
        bool v9 = v5 == 1.5f;
        v10 = v9;
    } else {
        v10 = false;
    }
    if (v10){
        return 0l;
    } else {
        return 1l;
    }
}
int32_t main(){
    int32_t v0 = 2l;
    uint32_t v1 = 3ul;
    float v2 = 1.5f;
    return method0(v0, v1, v2);
}
