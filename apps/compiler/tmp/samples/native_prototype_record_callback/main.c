#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int32_t v0;
    int32_t v1;
} Tuple0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Tuple0 (*fptr)(Fun0 *, int32_t, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Tuple0 (*fptr)(Closure0 *, int32_t, int32_t);
    int32_t v0;
};
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Tuple0 ClosureMethod0(Closure0 * x, int32_t v1, int32_t v2){
    int32_t v0 = x->v0;
    ClosureDecref0(x);
    
    
    int32_t v3;
    v3 = v1 - 8l;
    
    
    int32_t v4;
    v4 = v3 + v0;
    
    
    int32_t v5;
    v5 = v2 - 18l;
    
    
    return TupleCreate0(v4, v5);
}
Fun0 * ClosureCreate0(int32_t v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    x->v0 = v0;
    return (Fun0 *) x;
}
Tuple0 method0(Fun0 * v0){
    
    
    return v0->fptr(v0, 10l, 20l);
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 1l;
    
    
    Fun0 * v1;
    v1 = ClosureCreate0(v0);
    v1->refc++;
    
    int32_t v2; int32_t v3;
    Tuple0 tmp0 = method0(v1);
    v2 = tmp0.v0; v3 = tmp0.v1;
    
    v1->decref_fptr(v1);
    int32_t v4;
    v4 = 10l + v2;
    
    
    int32_t v5;
    v5 = 20l + v3;
    
    
    int32_t v6;
    v6 = v4 + v5;
    
    
    int32_t v7;
    v7 = v6 + 7l;
    
    
    return v7;
}
