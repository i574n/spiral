#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int32_t v0;
    int32_t v1;
    bool v2;
} Tuple0;
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1, bool v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple0 method0(int32_t v0){
    int32_t v1;
    v1 = v0 + 2l;
    bool v2;
    v2 = v0 > 0l;
    return TupleCreate0(v0, v1, v2);
}
int32_t method1(int32_t v0, int32_t v1, bool v2){
    if (v2){
        int32_t v3;
        v3 = v0 + v1;
        int32_t v4;
        v4 = v3 - 4l;
        return v4;
    } else {
        return 1l;
    }
}
int32_t main(){
    int32_t v0;
    v0 = 1l;
    int32_t v1; int32_t v2; bool v3;
    Tuple0 tmp0 = method0(v0);
    v1 = tmp0.v0; v2 = tmp0.v1; v3 = tmp0.v2;
    return method1(v1, v2, v3);
}
