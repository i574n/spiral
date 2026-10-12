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
    Tuple0 (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Tuple0 (*fptr)(Closure0 *, int32_t);
};
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1){
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
Tuple0 f_c0(Closure0 * x, int32_t v0){
    
    
    ClosureDecref0(x);
    
    
    int32_t v1;
    v1 = v0 + 1l;
    
    
    return TupleCreate0(v0, v1);
}
Fun0 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = f_c0;
    
    return (Fun0 *) x;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    Fun0 * v1;
    v1 = ClosureCreate0();
    (v1)->refc++;
    
    int32_t v2; int32_t v3;
    Tuple0 tmp0 = v1->fptr(v1, v0);
    v2 = tmp0.v0; v3 = tmp0.v1;
    
    (v1)->decref_fptr(v1);
    bool v4;
    v4 = v2 == 3l;
    
    
    bool v6;
    if (v4){
        
        
        bool v5;
        v5 = v3 == 4l;
        
        
        v6 = v5;
    } else {
        
        
        v6 = false;
    }
    
    
    if (v6){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
