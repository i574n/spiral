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
    Array0 * v0;
    Array0 * v1;
} Tuple0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Tuple0 (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
    int32_t v0;
    int32_t v1;
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
static inline Tuple0 TupleCreate0(Array0 * v0, Array0 * v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    *a = b;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static Tuple0 f_c0(Fun0 * self, int32_t v2){
    Closure0 * x = (Closure0 *) self;
    int32_t v0 = x->v0; int32_t v1 = x->v1;
    ClosureDecref0(self);
    Array0 * v3 = ArrayCreate0(1l, true);
    Array0 * v4 = ArrayCreate0(1l, true);
    bool v5 = v2 == 0l;
    if (v5){
        AssignArray0(&(v3->ptr[0l]), 0l);
        AssignArray0(&(v4->ptr[0l]), 0l);
        return TupleCreate0(v3, v4);
    } else {
        AssignArray0(&(v3->ptr[0l]), v0);
        AssignArray0(&(v4->ptr[0l]), v1);
        return TupleCreate0(v3, v4);
    }
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
    int32_t v0 = 3l;
    int32_t v1 = 4l;
    Fun0 * v2 = ClosureCreate0(v0, v1);
    (v2)->refc++;
    Array0 * v3; Array0 * v4;
    Tuple0 tmp0 = v2->fptr(v2, 1l);
    v3 = tmp0.v0; v4 = tmp0.v1;
    (v2)->decref_fptr(v2);
    int32_t v5 = v3->ptr[0l];
    ArrayDecref0(v3);
    int32_t v6 = v4->ptr[0l];
    ArrayDecref0(v4);
    int32_t v7 = v5 + v6;
    bool v8 = v7 == 7l;
    if (v8){
        return 0l;
    } else {
        return 1l;
    }
}
