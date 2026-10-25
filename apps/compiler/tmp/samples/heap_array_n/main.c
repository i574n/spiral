#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
typedef struct {
    int refc;
    Array0 * v0;
    int32_t v1;
} Heap0;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(int32_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, int32_t * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    return x;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    
    
    *a = b;
}
static inline void HeapDecrefBody0(Heap0 * x){
    ArrayDecref0(x->v0);
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(Array0 * v0, int32_t v1){
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
    
    
    Array0 * v2;
    v2 = ArrayCreate0(1l, true);
    
    
    
    AssignArray0(&(v2->ptr[0l]), v0);
    (v2)->refc++;
    
    Heap0 * v3;
    v3 = HeapCreate0(v2, v1);
    
    ArrayDecref0(v2);
    Array0 * v4; int32_t v5;
    v4 = v3->v0; v5 = v3->v1;
    (v4)->refc++;
    HeapDecref0(v3);
    int32_t v6;
    v6 = v4->ptr[0l];
    
    ArrayDecref0(v4);
    int32_t v7;
    v7 = v6 + v5;
    
    
    bool v8;
    v8 = v7 == 7l;
    
    
    if (v8){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
