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
    Fun0 * v0;
} Heap0;
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
int32_t f_c0(Fun0 * self, int32_t v1){
    Closure0 * x = (Closure0 *) self;
    int32_t v0 = x->v0;
    
    ClosureDecref0(self);
    
    
    int32_t v2;
    v2 = v1 + v0;
    
    
    return v2;
}
Fun0 * ClosureCreate0(int32_t v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0;
    return &x->base;
}
static inline void HeapDecrefBody0(Heap0 * x){
    (x->v0)->decref_fptr(x->v0);
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(Fun0 * v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    Fun0 * v1;
    v1 = ClosureCreate0(v0);
    (v1)->refc++;
    
    Heap0 * v2;
    v2 = HeapCreate0(v1);
    
    (v1)->decref_fptr(v1);
    Fun0 * v3;
    v3 = v2->v0;
    (v3)->refc += 2;
    HeapDecref0(v2);
    int32_t v4;
    v4 = v3->fptr(v3, 4l);
    
    (v3)->decref_fptr(v3);
    bool v5;
    v5 = v4 == 7l;
    
    
    if (v5){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
