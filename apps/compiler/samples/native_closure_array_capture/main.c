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
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    int32_t (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
    Array0 * v0;
};
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
static inline void ClosureDecrefBody0(Closure0 * x){
    ArrayDecref0(x->v0);
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static int32_t f_c0(Fun0 * self, int32_t v1){
    Closure0 * x = (Closure0 *) self;
    Array0 * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref0(self);
    int32_t v2 = v0->len;
    ArrayDecref0(v0);
    int32_t v3 = v2 + v1;
    return v3;
}
static Fun0 * ClosureCreate0(Array0 * v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0;
    return &x->base;
}
int32_t main(){
    Array0 * v0 = ArrayCreate0(2l, true);
    (v0)->refc++;
    Fun0 * v1 = ClosureCreate0(v0);
    ArrayDecref0(v0);
    return v1->fptr(v1, 40l);
}
