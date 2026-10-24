#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
} Mut0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Mut0 * (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
    Mut0 * v0;
};
static inline void MutDecrefBody0(Mut0 * x){
    (void)x;
}
static void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
static Mut0 * MutCreate0(int32_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    MutDecref0(x->v0);
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static Mut0 * f_c0(Fun0 * self, int32_t v1){
    Closure0 * x = (Closure0 *) self;
    Mut0 * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref0(self);
    (void)v1;
    return v0;
}
static Fun0 * ClosureCreate0(Mut0 * v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0;
    return &x->base;
}
static inline void AssignMut0(int32_t * a0, int32_t b0){
    *a0 = b0;
}
int32_t main(){
    Mut0 * v0 = MutCreate0(1l);
    (v0)->refc++;
    Fun0 * v1 = ClosureCreate0(v0);
    (v1)->refc++;
    MutDecref0(v0);
    Mut0 * v2 = v1->fptr(v1, 1l);
    (v1)->decref_fptr(v1);
    AssignMut0(&(v2->v0), 7l);
    int32_t v3 = v2->v0;
    MutDecref0(v2);
    bool v4 = v3 == 7l;
    if (v4){
        return 0l;
    } else {
        return 1l;
    }
}
