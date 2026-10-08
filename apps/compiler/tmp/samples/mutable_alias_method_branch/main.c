#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
} Mut0;
static inline void MutDecrefBody0(Mut0 * x){
    
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(int32_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void AssignMut0(int32_t * a0, int32_t b0){
    
    
    *a0 = b0;
}
void method0(Mut0 * v0){
    
    
    int32_t v1;
    v1 = v0->v0;
    
    
    int32_t v2;
    v2 = v1 + 5l;
    
    
    
    AssignMut0(&(v0->v0), v2);
    
    MutDecref0(v0);
    return ;
}
void method1(Mut0 * v0){
    
    MutDecref0(v0);
    return ;
}
void method2(Mut0 * v0){
    
    
    int32_t v1;
    v1 = v0->v0;
    
    
    int32_t v2;
    v2 = v1 + 7l;
    
    
    
    AssignMut0(&(v0->v0), v2);
    
    MutDecref0(v0);
    return ;
}
int32_t main(){
    
    
    Mut0 * v0;
    v0 = MutCreate0(0l);
    v0->refc++;
    
    
    method0(v0);
    v0->refc++;
    
    
    method1(v0);
    v0->refc++;
    
    
    method2(v0);
    
    
    int32_t v1;
    v1 = v0->v0;
    
    MutDecref0(v0);
    int32_t v2;
    v2 = v1 - 12l;
    
    
    return v2;
}
