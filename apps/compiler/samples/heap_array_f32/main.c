#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    float ptr[];
} Array0;
typedef struct {
    int refc;
    Array0 * v0;
    int32_t v1;
} Heap0;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(float) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, float * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(float) * len);
    return x;
}
static inline void AssignArray0(float * a, float b){
    *a = b;
}
static inline void HeapDecrefBody0(Heap0 * x){
    ArrayDecref0(x->v0);
}
static void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
static Heap0 * HeapCreate0(Array0 * v0, int32_t v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
int32_t main(){
    Array0 * v0 = ArrayCreate0(1l, true);
    float v1 = 1.5f;
    AssignArray0(&(v0->ptr[0l]), v1);
    int32_t v2 = 7l;
    (v0)->refc++;
    Heap0 * v3 = HeapCreate0(v0, v2);
    ArrayDecref0(v0);
    Array0 * v4; int32_t v5;
    v4 = v3->v0; v5 = v3->v1;
    (v4)->refc++;
    HeapDecref0(v3);
    float v6 = v4->ptr[0l];
    ArrayDecref0(v4);
    bool v7 = v6 == 1.5f;
    bool v9;
    if (v7){
        bool v8 = v5 == 7l;
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
