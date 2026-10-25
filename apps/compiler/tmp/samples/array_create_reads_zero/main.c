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
int32_t main(){
    
    
    Array0 * v0;
    v0 = ArrayCreate0(4l, true);
    
    
    
    AssignArray0(&(v0->ptr[0l]), 7l);
    
    
    
    AssignArray0(&(v0->ptr[1l]), 7l);
    
    
    
    AssignArray0(&(v0->ptr[2l]), 7l);
    
    
    
    AssignArray0(&(v0->ptr[3l]), 7l);
    
    
    int32_t v1;
    v1 = v0->ptr[3l];
    
    ArrayDecref0(v0);
    Array0 * v2;
    v2 = ArrayCreate0(4l, true);
    
    
    
    AssignArray0(&(v2->ptr[0l]), 5l);
    
    
    int32_t v3;
    v3 = v2->ptr[3l];
    
    
    int32_t v4;
    v4 = v2->ptr[0l];
    
    ArrayDecref0(v2);
    int32_t v5;
    v5 = v3 * 100l;
    
    
    int32_t v6;
    v6 = v5 + v4;
    
    
    int32_t v7;
    v7 = v1 - 7l;
    
    
    int32_t v8;
    v8 = v6 + v7;
    
    
    return v8;
}
