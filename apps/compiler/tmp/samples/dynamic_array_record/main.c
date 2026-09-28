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
    Array0 * v0;
    int32_t v1;
} Tuple0;
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
static inline Tuple0 TupleCreate0(Array0 * v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    
    
    *a = b;
}
Tuple0 method0(){
    
    
    int32_t v0;
    v0 = 2l;
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, false);
    
    
    
    AssignArray0(&(v1->ptr[0l]), 4l);
    
    
    
    AssignArray0(&(v1->ptr[1l]), 5l);
    
    
    return TupleCreate0(v1, 1l);
}
int32_t method1(Array0 * v0, int32_t v1){
    
    
    int32_t v2;
    v2 = v0->ptr[0l];
    
    
    int32_t v3;
    v3 = v0->ptr[1l];
    
    ArrayDecref0(v0);
    int32_t v4;
    v4 = v2 + v3;
    
    
    int32_t v5;
    v5 = v4 + v1;
    
    
    int32_t v6;
    v6 = v5 - 10l;
    
    
    return v6;
}
int32_t main(){
    
    
    Array0 * v0; int32_t v1;
    Tuple0 tmp0 = method0();
    v0 = tmp0.v0; v1 = tmp0.v1;
    
    
    return method1(v0, v1);
}
