#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array1;
typedef struct {
    int refc;
    uint32_t len;
    Array1 * ptr[];
} Array0;
static inline void ArrayDecrefBody1(Array1 * x){
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(int32_t) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, int32_t * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    return x;
}
static inline void ArrayDecrefBody0(Array0 * x){
    uint32_t len = x->len;
    Array1 * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        Array1 * v = ptr[i];
        ArrayDecref1(v);
    }
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(Array1 *) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, Array1 * * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(Array1 *) * len);
        for (uint32_t i=0; i < len; i++){
            Array1 * v = ptr[i];
            v->refc++;
        }
    return x;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    
    
    *a = b;
}
static inline void AssignArray1(Array1 * * a, Array1 * b){
    b->refc++;
    ArrayDecref1(*a);
    *a = b;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 2l;
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, true);
    
    
    Array1 * v2;
    v2 = ArrayCreate1(v0, false);
    
    
    Array1 * v3;
    v3 = ArrayCreate1(v0, false);
    
    
    
    AssignArray0(&(v2->ptr[0l]), 3l);
    
    
    
    AssignArray0(&(v2->ptr[1l]), 4l);
    
    
    
    AssignArray0(&(v3->ptr[0l]), 5l);
    
    
    
    AssignArray0(&(v3->ptr[1l]), 6l);
    
    
    
    AssignArray1(&(v1->ptr[0l]), v2);
    
    ArrayDecref1(v2);
    
    AssignArray1(&(v1->ptr[1l]), v3);
    
    ArrayDecref1(v3);
    Array1 * v5;
    v5 = v1->ptr[0l];
    v5->refc++;
    
    Array1 * v6;
    v6 = v1->ptr[1l];
    v6->refc++;
    ArrayDecref0(v1);
    int32_t v7;
    v7 = v5->ptr[0l];
    
    
    int32_t v8;
    v8 = v5->ptr[1l];
    
    ArrayDecref1(v5);
    int32_t v9;
    v9 = v7 + v8;
    
    
    int32_t v10;
    v10 = v6->ptr[0l];
    
    
    int32_t v11;
    v11 = v9 + v10;
    
    
    int32_t v12;
    v12 = v6->ptr[1l];
    
    ArrayDecref1(v6);
    int32_t v13;
    v13 = v11 + v12;
    
    
    int32_t v14;
    v14 = v13 - 18l;
    
    
    return v14;
}
