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
    int tag;
    union {
        struct {
            Array0 * v0;
        } case1; // Values
    };
} US0;
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
void method0(Array0 * v0){
    int32_t v1;
    v1 = 1l;
    DynamicArrayReserve0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
int32_t method1(Array0 * v0){
    int32_t v1;
    v1 = DynamicArrayCapacity0(v0);
    ArrayDecref0(v0);
    return v1;
}
void method2(Array0 * v0){
    int32_t v1;
    v1 = 2l;
    DynamicArrayReserve0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
int32_t method3(Array0 * v0){
    int32_t v1;
    v1 = DynamicArrayCapacity0(v0);
    ArrayDecref0(v0);
    return v1;
}
void method4(Array0 * v0){
    int32_t v1;
    v1 = 3l;
    DynamicArrayReserve0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
int32_t method5(Array0 * v0){
    int32_t v1;
    v1 = DynamicArrayCapacity0(v0);
    ArrayDecref0(v0);
    return v1;
}
void method6(Array0 * v0){
    int32_t v1;
    v1 = 5l;
    DynamicArrayReserve0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
int32_t method7(Array0 * v0){
    int32_t v1;
    v1 = DynamicArrayCapacity0(v0);
    ArrayDecref0(v0);
    return v1;
}
void method8(Array0 * v0){
    int32_t v1;
    v1 = 9l;
    DynamicArrayReserve0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
int32_t method9(Array0 * v0){
    int32_t v1;
    v1 = DynamicArrayCapacity0(v0);
    ArrayDecref0(v0);
    return v1;
}
int32_t method10(Array0 * v0){
    int32_t v1;
    v1 = DynamicArrayRefCount0(v0);
    ArrayDecref0(v0);
    return v1;
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            x->case1.v0->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            ArrayDecref0(x->case1.v0);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_0() { // Empty
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(Array0 * v0) { // Values
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t method13(Array0 * v0){
    int32_t v1;
    v1 = DynamicArrayRefCount0(v0);
    ArrayDecref0(v0);
    return v1;
}
int32_t method12(Array0 * v0){
    int32_t v1;
    v1 = DynamicArrayCapacity0(v0);
    v0->refc++;
    int32_t v2;
    v2 = method13(v0);
    ArrayDecref0(v0);
    int32_t v3;
    v3 = v1 + v2;
    return v3;
}
int32_t observe11(US0 v0){
    switch (v0.tag) {
        case 0: { // Empty
            USDecref0(&(v0));
            return 70l;
            break;
        }
        case 1: { // Values
            Array0 * v1 = v0.case1.v0;
            v1->refc++;
            USDecref0(&(v0));
            return method12(v1);
            break;
        }
    }
}
int32_t method14(Array0 * v0){
    int32_t v1;
    v1 = DynamicArrayRefCount0(v0);
    ArrayDecref0(v0);
    return v1;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayCreate0(0l, false);
    v0->refc++;
    method0(v0);
    v0->refc++;
    int32_t v1;
    v1 = method1(v0);
    v0->refc++;
    method2(v0);
    v0->refc++;
    int32_t v2;
    v2 = method3(v0);
    v0->refc++;
    method4(v0);
    v0->refc++;
    int32_t v3;
    v3 = method5(v0);
    v0->refc++;
    method6(v0);
    v0->refc++;
    int32_t v4;
    v4 = method7(v0);
    v0->refc++;
    method8(v0);
    v0->refc++;
    int32_t v5;
    v5 = method9(v0);
    v0->refc++;
    int32_t v6;
    v6 = method10(v0);
    v0->refc++;
    US0 v7;
    v7 = US0_1(v0);
    USIncref0(&(v7));
    int32_t v8;
    v8 = observe11(v7);
    v0->refc++;
    USDecref0(&(v7));
    int32_t v9;
    v9 = method14(v0);
    ArrayDecref0(v0);
    int32_t v10;
    v10 = v1 - 1l;
    int32_t v11;
    v11 = v2 - 2l;
    int32_t v12;
    v12 = v10 + v11;
    int32_t v13;
    v13 = v3 - 4l;
    int32_t v14;
    v14 = v12 + v13;
    int32_t v15;
    v15 = v4 - 8l;
    int32_t v16;
    v16 = v14 + v15;
    int32_t v17;
    v17 = v5 - 16l;
    int32_t v18;
    v18 = v16 + v17;
    int32_t v19;
    v19 = v6 - 2l;
    int32_t v20;
    v20 = v18 + v19;
    int32_t v21;
    v21 = v8 - 20l;
    int32_t v22;
    v22 = v20 + v21;
    int32_t v23;
    v23 = v9 - 2l;
    int32_t v24;
    v24 = v22 + v23;
    return v24;
}
