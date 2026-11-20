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
typedef struct {
    int refc;
    uint32_t len;
    Fun0 * ptr[];
} Array0;
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static int32_t f_c0(Fun0 * self, int32_t v1){
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
    x->base.fptr = f_c0;
    x->v0 = v0;
    return &x->base;
}
static inline void ArrayDecrefBody0(Array0 * x){
    uint32_t len = x->len;
    Fun0 * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        Fun0 * v = ptr[i];
        (v)->decref_fptr(v);
    }
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(Fun0 *) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, Fun0 * * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(Fun0 *) * len);
        for (uint32_t i=0; i < len; i++){
            Fun0 * v = ptr[i];
            (v)->refc++;
        }
    return x;
}
static inline void AssignArray0(Fun0 * * a, Fun0 * b){
    (b)->refc++;
    if (*a) { (*a)->decref_fptr(*a); }
    *a = b;
}
int32_t main(){
    int32_t v0 = 3l;
    Fun0 * v1 = ClosureCreate0(v0);
    int32_t v2 = 1l;
    Array0 * v3 = ArrayCreate0(v2, true);
    AssignArray0(&(v3->ptr[0l]), v1);
    (v1)->decref_fptr(v1);
    Fun0 * v4 = v3->ptr[0l];
    (v4)->refc += 2;
    ArrayDecref0(v3);
    int32_t v5 = v4->fptr(v4, 4l);
    (v4)->decref_fptr(v4);
    bool v6 = v5 == 7l;
    if (v6){
        return 0l;
    } else {
        return 1l;
    }
}
