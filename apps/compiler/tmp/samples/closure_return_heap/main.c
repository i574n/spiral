#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
} Heap0;
typedef struct Fun1 Fun1;
struct Fun1{
    int refc;
    void (*decref_fptr)(Fun1 *);
    int32_t (*fptr)(Fun1 *, int32_t);
};
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Fun1 * (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure1 Closure1;
struct Closure1 {
    Fun1 base;
    Heap0 * v0;
    int32_t v1;
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
    Heap0 * v0;
};
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
static inline void ClosureDecrefBody1(Closure1 * x){
    HeapDecref0(x->v0);
}
static void ClosureDecref1(Fun1 * self){
    Closure1 * x = (Closure1 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
static int32_t g_c1(Fun1 * self, int32_t v2){
    Closure1 * x = (Closure1 *) self;
    Heap0 * v0 = x->v0; int32_t v1 = x->v1;
    (v0)->refc++;
    ClosureDecref1(self);
    (void)v2;
    int32_t v3 = v0->v0;
    HeapDecref0(v0);
    bool v4 = v1 == 0l;
    if (v4){
        return 0l;
    } else {
        return v3;
    }
}
static Fun1 * ClosureCreate1(Heap0 * v0, int32_t v1){
    Closure1 * x = malloc(sizeof(Closure1));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref1;
    x->base.fptr = g_c1;
    x->v0 = v0; x->v1 = v1;
    return &x->base;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    HeapDecref0(x->v0);
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static Fun1 * f_c0(Fun0 * self, int32_t v1){
    Closure0 * x = (Closure0 *) self;
    Heap0 * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref0(self);
    return ClosureCreate1(v0, v1);
}
static Fun0 * ClosureCreate0(Heap0 * v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0;
    return &x->base;
}
int32_t main(){
    int32_t v0 = 7l;
    Heap0 * v1 = HeapCreate0(v0);
    (v1)->refc++;
    Fun0 * v2 = ClosureCreate0(v1);
    (v2)->refc++;
    HeapDecref0(v1);
    Fun1 * v3 = v2->fptr(v2, 1l);
    (v3)->refc++;
    (v2)->decref_fptr(v2);
    int32_t v4 = v3->fptr(v3, 0l);
    (v3)->decref_fptr(v3);
    bool v5 = v4 == 7l;
    if (v5){
        return 0l;
    } else {
        return 1l;
    }
}
