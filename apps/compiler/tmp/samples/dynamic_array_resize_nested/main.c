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
    uint32_t len;
    Array0 * ptr[];
} Array1;
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
static inline void ArrayDecrefBody1(Array1 * x){
    uint32_t len = x->len;
    Array0 * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        Array0 * v = ptr[i];
        ArrayDecref0(v);
    }
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(Array0 *) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, Array0 * * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(Array0 *) * len);
        for (uint32_t i=0; i < len; i++){
            Array0 * v = ptr[i];
            v->refc++;
        }
    return x;
}
static inline void AssignArray1(Array0 * * a, Array0 * b){
    b->refc++;
    ArrayDecref0(*a);
    *a = b;
}
void method0(Array1 * v0){
    
    
    int32_t v1;
    v1 = 0l;
    
    
    
    DynamicArrayResize0(v0,v1);
    
    ArrayDecref1(v0);
    return ;
}
void method1(Array1 * v0){
    
    
    int32_t v1;
    v1 = 1l;
    
    
    
    DynamicArrayResize0(v0,v1);
    
    ArrayDecref1(v0);
    return ;
}
void method2(Array0 * v0){
    
    
    int32_t v1;
    v1 = 0l;
    
    
    
    DynamicArrayResize1(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
void method3(Array0 * v0){
    
    
    int32_t v1;
    v1 = 1l;
    
    
    
    DynamicArrayResize1(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
int32_t method5(Array0 * v0){
    
    
    int32_t v1;
    v1 = DynamicArrayCapacity1(v0);
    
    ArrayDecref0(v0);
    return v1;
}
int32_t method4(Array0 * v0, Array1 * v1){
    
    
    int32_t v2;
    v2 = DynamicArrayCapacity0(v1);
    v0->refc++;
    ArrayDecref1(v1);
    int32_t v3;
    v3 = method5(v0);
    
    ArrayDecref0(v0);
    int32_t v4;
    v4 = v2 + v3 ;
    
    
    return v4;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 1l;
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, false);
    
    
    
    AssignArray0(&(v1->ptr[0l]), 7l);
    
    
    Array1 * v2;
    v2 = ArrayCreate1(v0, true);
    
    
    
    AssignArray1(&(v2->ptr[0l]), v1);
    
    
    Array0 * v3;
    v3 = v2->ptr[0l];
    v2->refc++; v3->refc++;
    
    
    method0(v2);
    v2->refc++;
    
    
    method1(v2);
    
    
    
    AssignArray1(&(v2->ptr[0l]), v3);
    v1->refc++;
    
    
    method2(v1);
    v3->refc++;
    
    
    method3(v3);
    
    ArrayDecref0(v3);
    
    AssignArray0(&(v1->ptr[0l]), 9l);
    
    
    Array0 * v4;
    v4 = v2->ptr[0l];
    v4->refc++;
    
    int32_t v5;
    v5 = v4->ptr[0l];
    
    
    int32_t v6;
    v6 = v4->len;
    
    ArrayDecref0(v4);
    int32_t v7;
    v7 = v5 + v6 ;
    
    
    int32_t v8;
    v8 = v2->len;
    
    
    int32_t v9;
    v9 = v7 + v8 ;
    v1->refc++; v2->refc++;
    
    int32_t v10;
    v10 = method4(v1, v2);
    
    ArrayDecref0(v1); ArrayDecref1(v2);
    int32_t v11;
    v11 = v9 + v10 ;
    
    
    int32_t v12;
    v12 = v11 - 13l ;
    
    
    return v12;
}
