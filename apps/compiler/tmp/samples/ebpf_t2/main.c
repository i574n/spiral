#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int32_t v0;
    int32_t v1;
} Tuple0;
typedef struct {
    int32_t v0;
    int32_t v1;
    int32_t v2;
} Tuple1;
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static Tuple0 method1(int32_t v0, int32_t v1){
    return TupleCreate0(v0, v1);
}
static int32_t method0(int32_t v0, int32_t v1){
    int32_t v2; int32_t v3;
    Tuple0 tmp0 = method1(v0, v1);
    v2 = tmp0.v0; v3 = tmp0.v1;
    int32_t v4 = v2 + v3;
    return v4;
}
static inline Tuple1 TupleCreate1(int32_t v0, int32_t v1, int32_t v2){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
static Tuple1 method3(int32_t v0, int32_t v1, int32_t v2){
    return TupleCreate1(v0, v1, v2);
}
static int32_t method2(int32_t v0, int32_t v1, int32_t v2){
    int32_t v3; int32_t v4; int32_t v5;
    Tuple1 tmp1 = method3(v0, v1, v2);
    v3 = tmp1.v0; v4 = tmp1.v1; v5 = tmp1.v2;
    int32_t v6 = v3 + v4;
    int32_t v7 = v6 + v5;
    return v7;
}
int32_t main(){
    int32_t v0 = 1l;
    int32_t v1 = 2l;
    int32_t v2 = 3l;
    int32_t v3 = method0(v0, v1);
    int32_t v4 = method2(v0, v1, v2);
    int32_t v5 = v3 + v4;
    int32_t v6 = v5 - 9l;
    return v6;
}
