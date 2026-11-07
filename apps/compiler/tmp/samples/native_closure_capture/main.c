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
    int32_t v1;
};
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static int32_t f_c0(Fun0 * self, int32_t v2){
    Closure0 * x = (Closure0 *) self;
    int32_t v0 = x->v0; int32_t v1 = x->v1;
    ClosureDecref0(self);
    int32_t v3 = v0 + v1;
    int32_t v4 = v3 + v2;
    return v4;
}
static Fun0 * ClosureCreate0(int32_t v0, int32_t v1){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0; x->v1 = v1;
    return &x->base;
}
int32_t main(){
    int32_t v0 = 1l;
    int32_t v1 = 2l;
    Fun0 * v2 = ClosureCreate0(v0, v1);
    return v2->fptr(v2, 39l);
}
