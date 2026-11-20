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
    int refc;
    Heap0 * v0;
} Heap1;
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
static inline void HeapDecrefBody1(Heap1 * x){
    HeapDecref0(x->v0);
}
static void HeapDecref1(Heap1 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody1(x); free(x); }
}
static Heap1 * HeapCreate1(Heap0 * v0){
    Heap1 * x = malloc(sizeof(Heap1));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
int32_t main(){
    int32_t v0 = 7l;
    Heap0 * v1 = HeapCreate0(v0);
    (v1)->refc++;
    Heap1 * v2 = HeapCreate1(v1);
    HeapDecref0(v1);
    Heap0 * v3 = v2->v0;
    (v3)->refc++;
    HeapDecref1(v2);
    int32_t v4 = v3->v0;
    HeapDecref0(v3);
    bool v5 = v4 == 7l;
    if (v5){
        return 0l;
    } else {
        return 1l;
    }
}
