#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
} Heap0;
typedef struct {
    int refc;
    uint32_t len;
    Heap0 * ptr[];
} Array0;
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
static inline void ArrayDecrefBody0(Array0 * x){
    uint32_t len = x->len;
    Heap0 * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        Heap0 * v = ptr[i];
        HeapDecref0(v);
    }
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(Heap0 *) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, Heap0 * * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(Heap0 *) * len);
        for (uint32_t i=0; i < len; i++){
            Heap0 * v = ptr[i];
            (v)->refc++;
        }
    return x;
}
static inline void AssignArray0(Heap0 * * a, Heap0 * b){
    (b)->refc++;
    HeapDecref0(*a);
    *a = b;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 2l;
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, true);
    
    
    int32_t v2;
    v2 = 4l;
    
    
    int32_t v3;
    v3 = 6l;
    
    
    Heap0 * v4;
    v4 = HeapCreate0(v2);
    
    
    
    AssignArray0(&(v1->ptr[0l]), v4);
    
    HeapDecref0(v4);
    Heap0 * v5;
    v5 = HeapCreate0(v3);
    
    
    
    AssignArray0(&(v1->ptr[1l]), v5);
    
    HeapDecref0(v5);
    Heap0 * v6;
    v6 = v1->ptr[0l];
    (v6)->refc++;
    
    int32_t v7;
    v7 = v6->v0;
    
    HeapDecref0(v6);
    Heap0 * v8;
    v8 = v1->ptr[1l];
    (v8)->refc++;
    ArrayDecref0(v1);
    int32_t v9;
    v9 = v8->v0;
    
    HeapDecref0(v8);
    int32_t v10;
    v10 = v7 + v9;
    
    
    bool v11;
    v11 = v10 == 10l;
    
    
    if (v11){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
