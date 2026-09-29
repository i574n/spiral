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
    int refc;
    void (*decref_fptr)(Closure0 *);
    int32_t (*fptr)(Closure0 *, int32_t);
    int32_t v0;
    int32_t v1;
};
static inline void ClosureDecrefBody0(Closure0 * x){
    
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
int32_t ClosureMethod0(Closure0 * x, int32_t v2){
    int32_t v0 = x->v0; int32_t v1 = x->v1;
    
    ClosureDecref0(x);
    
    
    int32_t v3;
    v3 = v0 + v1;
    
    
    int32_t v4;
    v4 = v3 + v2;
    
    
    return v4;
}
Fun0 * ClosureCreate0(int32_t v0, int32_t v1){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    x->v0 = v0; x->v1 = v1;
    return (Fun0 *) x;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 1l;
    
    
    int32_t v1;
    v1 = 2l;
    
    
    Fun0 * v2;
    v2 = ClosureCreate0(v0, v1);
    v2->refc++;
    
    int32_t v3;
    v3 = v2->fptr(v2, 10l);
    v2->refc++;
    
    int32_t v4;
    v4 = v2->fptr(v2, 20l);
    v2->refc++;
    
    int32_t v5;
    v5 = v2->fptr(v2, 3l);
    
    v2->decref_fptr(v2);
    int32_t v6;
    v6 = v3 + v4;
    
    
    int32_t v7;
    v7 = v6 + v5;
    
    
    return v7;
}
