#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
    int32_t v1;
} Heap0;
static inline void HeapDecrefBody0(Heap0 * x){
    (void)x;
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(int32_t v0, int32_t v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    int32_t v1;
    v1 = 4l;
    
    
    Heap0 * v2;
    v2 = HeapCreate0(v0, v1);
    
    
    int32_t v3; int32_t v4;
    v3 = v2->v0; v4 = v2->v1;
    
    HeapDecref0(v2);
    int32_t v5;
    v5 = v3 + v4;
    
    
    bool v6;
    v6 = v5 == 7l;
    
    
    if (v6){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
