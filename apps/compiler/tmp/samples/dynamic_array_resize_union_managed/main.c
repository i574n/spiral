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
void method1(Array0 * v0){
    
    
    int32_t v1;
    v1 = 8l;
    
    
    
    DynamicArrayReserve0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
void method2(Array0 * v0){
    
    
    int32_t v1;
    v1 = 5l;
    
    
    
    DynamicArrayResize0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
void method3(Array0 * v0){
    
    
    int32_t v1;
    v1 = 2l;
    
    
    
    DynamicArrayResize0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
int32_t method4(Array0 * v0){
    
    
    int32_t v1;
    v1 = DynamicArrayCapacity0(v0);
    
    ArrayDecref0(v0);
    return v1;
}
int32_t mutate0(US0 v0){
    
    
    switch (v0.tag) {
        case 0: { // Empty
            
            
            USDecref0(&(v0));
            return 90l;
            break;
        }
        case 1: { // Values
            Array0 * v1 = v0.case1.v0;
            v1->refc += 2;
            USDecref0(&(v0));
            
            method1(v1);
            v1->refc++;
            
            
            method2(v1);
            
            
            
            AssignArray0(&(v1->ptr[1l]), 11l);
            v1->refc++;
            
            
            method3(v1);
            
            
            return method4(v1);
            break;
        }
    }
}
int32_t observe5(US0 v0){
    
    
    switch (v0.tag) {
        case 0: { // Empty
            
            
            USDecref0(&(v0));
            return 91l;
            break;
        }
        case 1: { // Values
            Array0 * v1 = v0.case1.v0;
            v1->refc++;
            USDecref0(&(v0));
            int32_t v2;
            v2 = v1->len;
            
            
            int32_t v3;
            v3 = v1->ptr[0l];
            
            
            int32_t v4;
            v4 = v2 + v3;
            
            
            int32_t v5;
            v5 = v1->ptr[1l];
            
            ArrayDecref0(v1);
            int32_t v6;
            v6 = v4 + v5;
            
            
            return v6;
            break;
        }
    }
}
void method6(Array0 * v0){
    
    
    int32_t v1;
    v1 = 0l;
    
    
    
    DynamicArrayResize0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
void method7(Array0 * v0){
    
    
    int32_t v1;
    v1 = 2l;
    
    
    
    DynamicArrayResize0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
int32_t main(){
    
    
    Array0 * v0;
    v0 = ArrayCreate0(2l, false);
    
    
    
    AssignArray0(&(v0->ptr[0l]), 7l);
    
    
    
    AssignArray0(&(v0->ptr[1l]), 3l);
    v0->refc++;
    
    US0 v1;
    v1 = US0_1(v0);
    USIncref0(&(v1));
    
    int32_t v2;
    v2 = mutate0(v1);
    v0->refc++;
    USDecref0(&(v1));
    US0 v3;
    v3 = US0_1(v0);
    USIncref0(&(v3));
    
    int32_t v4;
    v4 = observe5(v3);
    v0->refc++;
    USDecref0(&(v3));
    
    method6(v0);
    v0->refc++;
    
    
    method7(v0);
    
    
    int32_t v5;
    v5 = DynamicArrayRefCount0(v0);
    
    
    int32_t v6;
    v6 = v4 + v2;
    
    
    int32_t v7;
    v7 = v0->len;
    
    
    int32_t v8;
    v8 = v6 + v7;
    
    
    int32_t v9;
    v9 = v0->ptr[0l];
    
    
    int32_t v10;
    v10 = v8 + v9;
    
    
    int32_t v11;
    v11 = v0->ptr[1l];
    
    ArrayDecref0(v0);
    int32_t v12;
    v12 = v10 + v11;
    
    
    int32_t v13;
    v13 = v12 + v5;
    
    
    int32_t v14;
    v14 = v13 - 31l;
    
    
    return v14;
}
