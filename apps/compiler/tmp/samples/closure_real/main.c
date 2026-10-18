#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    double (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
    double v0;
};
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
double f_c0(Fun0 * self, int32_t v1){
    Closure0 * x = (Closure0 *) self;
    double v0 = x->v0;
    
    ClosureDecref0(self);
    
    
    bool v2;
    v2 = v1 == 0l;
    
    
    if (v2){
        
        
        return 0.0;
    } else {
        
        
        return v0;
    }
}
Fun0 * ClosureCreate0(double v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0;
    return &x->base;
}
int32_t main(){
    
    
    double v0;
    v0 = 1.5;
    
    
    Fun0 * v1;
    v1 = ClosureCreate0(v0);
    (v1)->refc++;
    
    double v2;
    v2 = v1->fptr(v1, 1l);
    
    (v1)->decref_fptr(v1);
    bool v3;
    v3 = v2 == 1.5;
    
    
    if (v3){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
