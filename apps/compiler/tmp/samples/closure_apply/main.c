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
};
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
int32_t f_c0(Fun0 * self, int32_t v0){
    
    
    ClosureDecref0(self);
    
    
    int32_t v1;
    v1 = v0 + 1l;
    
    
    return v1;
}
Fun0 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    
    return &x->base;
}
int32_t main(){
    
    
    Fun0 * v0;
    v0 = ClosureCreate0();
    (v0)->refc++;
    
    int32_t v1;
    v1 = v0->fptr(v0, 6l);
    
    (v0)->decref_fptr(v0);
    bool v2;
    v2 = v1 == 7l;
    
    
    if (v2){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
