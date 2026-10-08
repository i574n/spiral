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
void method0(Array0 * v0){
    
    
    int32_t v1;
    v1 = 2l;
    
    
    
    DynamicArrayResize0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
void method1(Array0 * v0){
    
    
    int32_t v1;
    v1 = 4l;
    
    
    
    DynamicArrayResize0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
int32_t method2(Array0 * v0){
    
    
    int32_t v1;
    v1 = DynamicArrayCapacity0(v0);
    
    ArrayDecref0(v0);
    int32_t v2;
    v2 = v1 - 15l;
    
    
    return v2;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 4l;
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, false);
    
    
    
    AssignArray0(&(v1->ptr[0l]), 1l);
    
    
    
    AssignArray0(&(v1->ptr[1l]), 2l);
    
    
    
    AssignArray0(&(v1->ptr[2l]), 3l);
    
    
    
    AssignArray0(&(v1->ptr[3l]), 4l);
    v1->refc++;
    
    
    method0(v1);
    v1->refc++;
    
    
    method1(v1);
    
    
    
    AssignArray0(&(v1->ptr[3l]), 7l);
    
    
    int32_t v2;
    v2 = v1->len;
    
    
    int32_t v3;
    v3 = v1->ptr[3l];
    
    
    int32_t v4;
    v4 = v2 + v3;
    v1->refc++;
    
    int32_t v5;
    v5 = method2(v1);
    
    ArrayDecref0(v1);
    int32_t v6;
    v6 = v4 + v5;
    
    
    return v6;
}
