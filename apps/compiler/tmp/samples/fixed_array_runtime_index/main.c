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
    v0 = ArrayCreate0(4l, false);
    
    
    
    AssignArray0(&(v0->ptr[0l]), 2l);
    
    
    
    AssignArray0(&(v0->ptr[1l]), 3l);
    
    
    
    AssignArray0(&(v0->ptr[2l]), 5l);
    
    
    
    AssignArray0(&(v0->ptr[3l]), 7l);
    
    
    int32_t v1;
    v1 = 2l;
    
    
    int32_t v2;
    v2 = v0->ptr[v1];
    
    ArrayDecref0(v0);
    int32_t v3;
    v3 = v2 - 5l ;
    
    
    return v3;
}
