#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
} Heap0;
typedef struct {
    Heap0 * v0;
    Heap0 * v1;
} Tuple0;
static inline void HeapDecrefBody0(Heap0 * x){
    (void)x;
}
static void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
static Heap0 * HeapCreate0(int32_t v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline Tuple0 TupleCreate0(Heap0 * v0, Heap0 * v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static Tuple0 method0(Heap0 * v0, Heap0 * v1){
    return TupleCreate0(v0, v1);
}
int32_t main(){
    int32_t v0 = 3l;
    int32_t v1 = 4l;
    Heap0 * v2 = HeapCreate0(v0);
    Heap0 * v3 = HeapCreate0(v1);
    (v2)->refc++; (v3)->refc++;
    Heap0 * v4; Heap0 * v5;
    Tuple0 tmp0 = method0(v2, v3);
    v4 = tmp0.v0; v5 = tmp0.v1;
    HeapDecref0(v2); HeapDecref0(v3);
    int32_t v6 = v4->v0;
    HeapDecref0(v4);
    int32_t v7 = v5->v0;
    HeapDecref0(v5);
    int32_t v8 = v6 + v7;
    bool v9 = v8 == 7l;
    if (v9){
        return 0l;
    } else {
        return 1l;
    }
}
