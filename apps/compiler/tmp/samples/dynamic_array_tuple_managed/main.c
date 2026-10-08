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
    Array0 * v1;
} Tuple0;
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
    v1 = 3l;
    
    
    
    DynamicArrayReserve0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
int32_t method1(Array0 * v0){
    
    
    int32_t v1;
    v1 = DynamicArrayRefCount0(v0);
    
    ArrayDecref0(v0);
    return v1;
}
static inline Tuple0 TupleCreate0(Array0 * v0, Array0 * v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 method2(Array0 * v0){
    v0->refc++;
    
    return TupleCreate0(v0, v0);
}
int32_t method5(Array0 * v0, Array0 * v1){
    
    
    int32_t v2;
    v2 = DynamicArrayRefCount0(v0);
    
    
    int32_t v3;
    v3 = v1->ptr[0l];
    
    ArrayDecref0(v1);
    int32_t v4;
    v4 = v2 + v3;
    
    
    int32_t v5;
    v5 = v0->ptr[0l];
    
    ArrayDecref0(v0);
    int32_t v6;
    v6 = v4 + v5;
    
    
    return v6;
}
int32_t method4(Array0 * v0, Array0 * v1){
    
    
    int32_t v2;
    v2 = DynamicArrayCapacity0(v1);
    v0->refc++; v1->refc++;
    
    int32_t v3;
    v3 = method5(v0, v1);
    
    ArrayDecref0(v0); ArrayDecref0(v1);
    int32_t v4;
    v4 = v2 + v3;
    
    
    return v4;
}
int32_t method3(Array0 * v0, Array0 * v1){
    
    
    return method4(v1, v0);
}
int32_t method6(Array0 * v0){
    
    
    int32_t v1;
    v1 = DynamicArrayRefCount0(v0);
    
    ArrayDecref0(v0);
    return v1;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 1l;
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, false);
    
    
    
    AssignArray0(&(v1->ptr[0l]), 7l);
    v1->refc++;
    
    
    method0(v1);
    v1->refc++;
    
    int32_t v2;
    v2 = method1(v1);
    v1->refc++;
    
    Array0 * v3; Array0 * v4;
    Tuple0 tmp0 = method2(v1);
    v3 = tmp0.v0; v4 = tmp0.v1;
    v3->refc++; v4->refc++;
    
    int32_t v5;
    v5 = method3(v3, v4);
    v1->refc++;
    ArrayDecref0(v3); ArrayDecref0(v4);
    int32_t v6;
    v6 = method6(v1);
    
    ArrayDecref0(v1);
    int32_t v7;
    v7 = v5 + v2;
    
    
    int32_t v8;
    v8 = v7 + v6;
    
    
    int32_t v9;
    v9 = v8 - 29l;
    
    
    return v9;
}
