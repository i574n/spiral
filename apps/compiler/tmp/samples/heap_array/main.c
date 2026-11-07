#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
typedef struct {
    int refc;
    Array0 * v0;
} Heap0;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(int32_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, int32_t * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    return x;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    *a = b;
}
static inline void HeapDecrefBody0(Heap0 * x){
    ArrayDecref0(x->v0);
}
static void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
static Heap0 * HeapCreate0(Array0 * v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
int32_t main(){
    int32_t v0 = 2l;
    Array0 * v1 = ArrayCreate0(v0, true);
    int32_t v2 = 7l;
    AssignArray0(&(v1->ptr[0l]), v2);
    (v1)->refc++;
    Heap0 * v3 = HeapCreate0(v1);
    ArrayDecref0(v1);
    Array0 * v4 = v3->v0;
    (v4)->refc++;
    HeapDecref0(v3);
    int32_t v5 = v4->ptr[0l];
    ArrayDecref0(v4);
    bool v6 = v5 == 7l;
    if (v6){
        return 0l;
    } else {
        return 1l;
    }
}
