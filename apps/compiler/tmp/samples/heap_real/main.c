#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    double v0;
} Heap0;
static inline void HeapDecrefBody0(Heap0 * x){
    (void)x;
}
static void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
static Heap0 * HeapCreate0(double v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
int32_t main(){
    double v0 = 1.5;
    Heap0 * v1 = HeapCreate0(v0);
    double v2 = v1->v0;
    HeapDecref0(v1);
    bool v3 = v2 == 1.5;
    if (v3){
        return 0l;
    } else {
        return 1l;
    }
}
