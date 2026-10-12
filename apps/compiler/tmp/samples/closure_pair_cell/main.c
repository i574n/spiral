#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
} Heap0;
typedef struct {
    Heap0 * v0;
    int32_t v1;
} Tuple0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Tuple0 (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Tuple0 (*fptr)(Closure0 *, int32_t);
    Heap0 * v1;
    int32_t v0;
};
static inline void HeapDecrefBody0(Heap0 * x){
    (void)x;
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(int32_t v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline Tuple0 TupleCreate0(Heap0 * v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    HeapDecref0(x->v1);
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Tuple0 f_c0(Closure0 * x, int32_t v2){
    int32_t v0 = x->v0; Heap0 * v1 = x->v1;
    (v1)->refc++;
    ClosureDecref0(x);
    
    
    bool v3;
    v3 = v2 == 0l;
    
    
    if (v3){
        
        
        return TupleCreate0(v1, 0l);
    } else {
        
        
        return TupleCreate0(v1, v0);
    }
}
Fun0 * ClosureCreate0(int32_t v0, Heap0 * v1){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = f_c0;
    x->v0 = v0; x->v1 = v1;
    return (Fun0 *) x;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    int32_t v1;
    v1 = 4l;
    
    
    Heap0 * v2;
    v2 = HeapCreate0(v0);
    (v2)->refc++;
    
    Fun0 * v3;
    v3 = ClosureCreate0(v1, v2);
    (v3)->refc++;
    HeapDecref0(v2);
    Heap0 * v4; int32_t v5;
    Tuple0 tmp0 = v3->fptr(v3, 1l);
    v4 = tmp0.v0; v5 = tmp0.v1;
    
    (v3)->decref_fptr(v3);
    int32_t v6;
    v6 = v4->v0;
    
    HeapDecref0(v4);
    int32_t v7;
    v7 = v6 + v5;
    
    
    bool v8;
    v8 = v7 == 7l;
    
    
    if (v8){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
