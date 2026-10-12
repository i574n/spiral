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
    (void)x;
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
Mut0 * method0(Mut0 * v0){
    
    
    return v0;
}
static inline void AssignMut0(int32_t * a0, int32_t b0){
    
    
    *a0 = b0;
}
int32_t main(){
    
    
    Mut0 * v0;
    v0 = MutCreate0(1l);
    (v0)->refc++;
    
    Mut0 * v1;
    v1 = method0(v0);
    
    MutDecref0(v0);
    
    AssignMut0(&(v1->v0), 7l);
    
    
    int32_t v2;
    v2 = v1->v0;
    
    MutDecref0(v1);
    bool v3;
    v3 = v2 == 7l;
    
    
    if (v3){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
