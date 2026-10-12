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
typedef struct {
    Fun0 * v0;
    Fun0 * v1;
} Tuple0;
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    int32_t (*fptr)(Closure0 *, int32_t);
    int32_t v0;
};
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*decref_fptr)(Closure1 *);
    int32_t (*fptr)(Closure1 *, int32_t);
    int32_t v0;
};
static inline Tuple0 TupleCreate0(Fun0 * v0, Fun0 * v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
int32_t left_c0(Closure0 * x, int32_t v1){
    int32_t v0 = x->v0;
    
    ClosureDecref0(x);
    
    
    bool v2;
    v2 = v0 == 0l;
    
    
    if (v2){
        
        
        return 0l;
    } else {
        
        
        int32_t v3;
        v3 = v1 + v0;
        
        
        return v3;
    }
}
Fun0 * ClosureCreate0(int32_t v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = left_c0;
    x->v0 = v0;
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody1(Closure1 * x){
    (void)x;
}
void ClosureDecref1(Closure1 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
int32_t right_c1(Closure1 * x, int32_t v1){
    int32_t v0 = x->v0;
    
    ClosureDecref1(x);
    
    
    bool v2;
    v2 = v0 == 0l;
    
    
    if (v2){
        
        
        return 0l;
    } else {
        
        
        int32_t v3;
        v3 = v1 + v0;
        
        
        return v3;
    }
}
Fun0 * ClosureCreate1(int32_t v0){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 1;
    x->decref_fptr = ClosureDecref1;
    x->fptr = right_c1;
    x->v0 = v0;
    return (Fun0 *) x;
}
Tuple0 method0(int32_t v0, int32_t v1){
    
    
    Fun0 * v2;
    v2 = ClosureCreate0(v0);
    
    
    Fun0 * v3;
    v3 = ClosureCreate1(v1);
    
    
    return TupleCreate0(v2, v3);
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    int32_t v1;
    v1 = 4l;
    
    
    Fun0 * v2; Fun0 * v3;
    Tuple0 tmp0 = method0(v0, v1);
    v2 = tmp0.v0; v3 = tmp0.v1;
    (v2)->refc++;
    
    int32_t v4;
    v4 = v2->fptr(v2, 0l);
    (v3)->refc++;
    (v2)->decref_fptr(v2);
    int32_t v5;
    v5 = v3->fptr(v3, 0l);
    
    (v3)->decref_fptr(v3);
    int32_t v6;
    v6 = v4 + v5;
    
    
    bool v7;
    v7 = v6 == 7l;
    
    
    if (v7){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
