#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct Fun1 Fun1;
struct Fun1{
    int refc;
    void (*decref_fptr)(Fun1 *);
    int32_t (*fptr)(Fun1 *, int32_t);
};
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Fun1 * (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*decref_fptr)(Closure1 *);
    int32_t (*fptr)(Closure1 *, int32_t);
    int32_t v0;
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Fun1 * (*fptr)(Closure0 *, int32_t);
};
static inline void ClosureDecrefBody1(Closure1 * x){
    (void)x;
}
void ClosureDecref1(Closure1 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
int32_t closure1(Closure1 * x, int32_t v1){
    int32_t v0 = x->v0;
    
    ClosureDecref1(x);
    
    
    int32_t v2;
    v2 = v0 * 10l;
    
    
    int32_t v3;
    v3 = v2 + v1;
    
    
    return v3;
}
Fun1 * ClosureCreate1(int32_t v0){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 1;
    x->decref_fptr = ClosureDecref1;
    x->fptr = closure1;
    x->v0 = v0;
    return (Fun1 *) x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Fun1 * f_c0(Closure0 * x, int32_t v0){
    
    
    ClosureDecref0(x);
    
    
    return ClosureCreate1(v0);
}
Fun0 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = f_c0;
    
    return (Fun0 *) x;
}
int32_t main(){
    
    
    Fun0 * v0;
    v0 = ClosureCreate0();
    (v0)->refc++;
    
    Fun1 * v1;
    v1 = v0->fptr(v0, 3l);
    (v1)->refc++;
    (v0)->decref_fptr(v0);
    int32_t v2;
    v2 = v1->fptr(v1, 4l);
    
    (v1)->decref_fptr(v1);
    bool v3;
    v3 = v2 == 34l;
    
    
    if (v3){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
