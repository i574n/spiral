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
};
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
int32_t g_c0(Closure0 * x, int32_t v1){
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
    x->fptr = g_c0;
    x->v0 = v0;
    return (Fun0 *) x;
}
Fun0 * method0(int32_t v0){
    
    
    return ClosureCreate0(v0);
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 7l;
    
    
    Fun0 * v1;
    v1 = method0(v0);
    (v1)->refc++;
    
    int32_t v2;
    v2 = v1->fptr(v1, 0l);
    
    (v1)->decref_fptr(v1);
    bool v3;
    v3 = v2 == 7l;
    
    
    if (v3){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
