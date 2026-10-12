#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct Fun2 Fun2;
struct Fun2{
    int refc;
    void (*decref_fptr)(Fun2 *);
    int32_t (*fptr)(Fun2 *, int32_t);
};
typedef struct Fun1 Fun1;
struct Fun1{
    int refc;
    void (*decref_fptr)(Fun1 *);
    Fun2 * (*fptr)(Fun1 *, int32_t);
};
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Fun1 * (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure2 Closure2;
struct Closure2 {
    int refc;
    void (*decref_fptr)(Closure2 *);
    int32_t (*fptr)(Closure2 *, int32_t);
    int32_t v0;
    int32_t v1;
};
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*decref_fptr)(Closure1 *);
    Fun2 * (*fptr)(Closure1 *, int32_t);
    int32_t v0;
    int32_t v1;
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Fun1 * (*fptr)(Closure0 *, int32_t);
    int32_t v0;
};
static inline void ClosureDecrefBody2(Closure2 * x){
    (void)x;
}
void ClosureDecref2(Closure2 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody2(x); free(x); }
}
int32_t h_c2(Closure2 * x, int32_t v2){
    int32_t v0 = x->v0; int32_t v1 = x->v1;
    
    ClosureDecref2(x);
    
    
    bool v3;
    v3 = v1 == 0l;
    
    
    if (v3){
        
        
        return 0l;
    } else {
        
        
        int32_t v4;
        v4 = v2 + v0;
        
        
        return v4;
    }
}
Fun2 * ClosureCreate2(int32_t v0, int32_t v1){
    Closure2 * x = malloc(sizeof(Closure2));
    x->refc = 1;
    x->decref_fptr = ClosureDecref2;
    x->fptr = h_c2;
    x->v0 = v0; x->v1 = v1;
    return (Fun2 *) x;
}
static inline void ClosureDecrefBody1(Closure1 * x){
    (void)x;
}
void ClosureDecref1(Closure1 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
Fun2 * g_c1(Closure1 * x, int32_t v2){
    int32_t v0 = x->v0; int32_t v1 = x->v1;
    
    ClosureDecref1(x);
    (void)v2;
    
    
    return ClosureCreate2(v0, v1);
}
Fun1 * ClosureCreate1(int32_t v0, int32_t v1){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 1;
    x->decref_fptr = ClosureDecref1;
    x->fptr = g_c1;
    x->v0 = v0; x->v1 = v1;
    return (Fun1 *) x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Fun1 * f_c0(Closure0 * x, int32_t v1){
    int32_t v0 = x->v0;
    
    ClosureDecref0(x);
    
    
    return ClosureCreate1(v0, v1);
}
Fun0 * ClosureCreate0(int32_t v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = f_c0;
    x->v0 = v0;
    return (Fun0 *) x;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 7l;
    
    
    Fun0 * v1;
    v1 = ClosureCreate0(v0);
    (v1)->refc++;
    
    Fun1 * v2;
    v2 = v1->fptr(v1, 1l);
    (v2)->refc++;
    (v1)->decref_fptr(v1);
    Fun2 * v3;
    v3 = v2->fptr(v2, 0l);
    (v3)->refc++;
    (v2)->decref_fptr(v2);
    int32_t v4;
    v4 = v3->fptr(v3, 0l);
    
    (v3)->decref_fptr(v3);
    bool v5;
    v5 = v4 == 7l;
    
    
    if (v5){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
