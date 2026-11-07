#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    int32_t (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
    int32_t v0;
};
typedef struct Closure1 Closure1;
struct Closure1 {
    Fun0 base;
    int32_t v0;
};
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static int32_t a_c0(Fun0 * self, int32_t v1){
    Closure0 * x = (Closure0 *) self;
    int32_t v0 = x->v0;
    ClosureDecref0(self);
    int32_t v2 = v1 + v0;
    return v2;
}
static Fun0 * ClosureCreate0(int32_t v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = a_c0;
    x->v0 = v0;
    return &x->base;
}
static inline void ClosureDecrefBody1(Closure1 * x){
    (void)x;
}
static void ClosureDecref1(Fun0 * self){
    Closure1 * x = (Closure1 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
static int32_t b_c1(Fun0 * self, int32_t v1){
    Closure1 * x = (Closure1 *) self;
    int32_t v0 = x->v0;
    ClosureDecref1(self);
    int32_t v2 = v1 + v0;
    return v2;
}
static Fun0 * ClosureCreate1(int32_t v0){
    Closure1 * x = malloc(sizeof(Closure1));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref1;
    x->base.fptr = b_c1;
    x->v0 = v0;
    return &x->base;
}
static int32_t method0(Fun0 * v0){
    return v0->fptr(v0, 40l);
}
int32_t main(){
    int32_t v0 = 2l;
    int32_t v1 = 3l;
    bool v2 = true;
    Fun0 * v5;
    if (v2){
        v5 = ClosureCreate0(v0);
    } else {
        v5 = ClosureCreate1(v1);
    }
    return method0(v5);
}
