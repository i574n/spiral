#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    float v0;
    int32_t v1;
} Heap0;
static inline void HeapDecrefBody0(Heap0 * x){
    (void)x;
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(float v0, int32_t v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
int32_t main(){
    
    
    float v0;
    v0 = 1.5f;
    
    
    int32_t v1;
    v1 = 7l;
    
    
    Heap0 * v2;
    v2 = HeapCreate0(v0, v1);
    
    
    float v3; int32_t v4;
    v3 = v2->v0; v4 = v2->v1;
    
    HeapDecref0(v2);
    bool v5;
    v5 = v3 == 1.5f;
    
    
    bool v7;
    if (v5){
        
        
        bool v6;
        v6 = v4 == 7l;
        
        
        v7 = v6;
    } else {
        
        
        v7 = false;
    }
    
    
    if (v7){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
