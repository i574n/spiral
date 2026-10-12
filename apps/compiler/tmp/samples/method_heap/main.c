#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
} Heap0;
static inline void HeapDecrefBody0(Heap0 * x){
    (void)x;
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(int32_t v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
Heap0 * method0(Heap0 * v0){
    
    
    return v0;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 7l;
    
    
    Heap0 * v1;
    v1 = HeapCreate0(v0);
    (v1)->refc++;
    
    Heap0 * v2;
    v2 = method0(v1);
    
    HeapDecref0(v1);
    int32_t v3;
    v3 = v2->v0;
    
    HeapDecref0(v2);
    bool v4;
    v4 = v3 == 7l;
    
    
    if (v4){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
