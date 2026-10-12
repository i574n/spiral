#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    bool v0;
    bool v1;
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
    bool v0;
};
static inline Tuple0 TupleCreate0(bool v0, bool v1){
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
Tuple0 f_c0(Closure0 * x, int32_t v1){
    bool v0 = x->v0;
    
    ClosureDecref0(x);
    
    
    bool v2;
    v2 = v1 == 0l;
    
    
    if (v2){
        
        
        return TupleCreate0(false, false);
    } else {
        
        
        return TupleCreate0(v0, true);
    }
}
Fun0 * ClosureCreate0(bool v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = f_c0;
    x->v0 = v0;
    return (Fun0 *) x;
}
int32_t main(){
    
    
    bool v0;
    v0 = true;
    
    
    Fun0 * v1;
    v1 = ClosureCreate0(v0);
    (v1)->refc++;
    
    bool v2; bool v3;
    Tuple0 tmp0 = v1->fptr(v1, 1l);
    v2 = tmp0.v0; v3 = tmp0.v1;
    
    (v1)->decref_fptr(v1);
    bool v4;
    v4 = v2 && v3;
    
    
    if (v4){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
