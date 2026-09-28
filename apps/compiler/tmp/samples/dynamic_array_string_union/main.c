#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array1;
typedef Array1 String;
typedef struct {
    int refc;
    uint32_t len;
    String * ptr[];
} Array0;
typedef struct {
    int tag;
    union {
        struct {
            Array0 * v0;
        } case1; // Values
    };
} US0;
static inline void ArrayDecrefBody1(Array1 * x){
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(char) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, char * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref1(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit1(len, ptr);
}
static inline void ArrayDecrefBody0(Array0 * x){
    uint32_t len = x->len;
    String * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        String * v = ptr[i];
        StringDecref(v);
    }
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(String *) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, String * * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(String *) * len);
        for (uint32_t i=0; i < len; i++){
            String * v = ptr[i];
            v->refc++;
        }
    return x;
}
void method0(Array0 * v0){
    int32_t v1;
    v1 = 1l;
    DynamicArrayResize0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
static inline void AssignArray0(String * * a, String * b){
    b->refc++;
    StringDecref(*a);
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
void method2(Array0 * v0){
    int32_t v1;
    v1 = 8l;
    DynamicArrayReserve0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
void method3(Array0 * v0){
    int32_t v1;
    v1 = 3l;
    DynamicArrayResize0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
void method4(Array0 * v0){
    int32_t v1;
    v1 = 2l;
    DynamicArrayResize0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
int32_t method5(Array0 * v0){
    int32_t v1;
    v1 = DynamicArrayCapacity0(v0);
    ArrayDecref0(v0);
    return v1;
}
int32_t mutate1(US0 v0){
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
            method2(v1);
            v1->refc++;
            method3(v1);
            String * v2;
            v2 = StringLit(4, "cde");
            AssignArray0(&(v1->ptr[1l]), v2);
            StringDecref(v2);
            String * v3;
            v3 = StringLit(2, "f");
            AssignArray0(&(v1->ptr[2l]), v3);
            v1->refc++;
            StringDecref(v3);
            method4(v1);
            return method5(v1);
            break;
        }
    }
}
int32_t observe6(US0 v0){
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
            String * v3;
            v3 = v1->ptr[0l];
            v3->refc++;
            int32_t v4;
            v4 = v3->len-1;
            StringDecref(v3);
            int32_t v5;
            v5 = v2 + v4 ;
            String * v6;
            v6 = v1->ptr[1l];
            v6->refc++;
            ArrayDecref0(v1);
            int32_t v7;
            v7 = v6->len-1;
            StringDecref(v6);
            int32_t v8;
            v8 = v5 + v7 ;
            return v8;
            break;
        }
    }
}
void method7(Array0 * v0){
    int32_t v1;
    v1 = 0l;
    DynamicArrayResize0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
void method8(Array0 * v0){
    int32_t v1;
    v1 = 1l;
    DynamicArrayResize0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayCreate0(4l, true);
    v0->refc++;
    method0(v0);
    String * v1;
    v1 = StringLit(3, "ab");
    AssignArray0(&(v0->ptr[0l]), v1);
    v0->refc++;
    StringDecref(v1);
    US0 v2;
    v2 = US0_1(v0);
    USIncref0(&(v2));
    int32_t v3;
    v3 = mutate1(v2);
    v0->refc++;
    USDecref0(&(v2));
    US0 v4;
    v4 = US0_1(v0);
    USIncref0(&(v4));
    int32_t v5;
    v5 = observe6(v4);
    v0->refc++;
    USDecref0(&(v4));
    method7(v0);
    v0->refc++;
    method8(v0);
    int32_t v6;
    v6 = v5 + v3 ;
    int32_t v7;
    v7 = v0->len;
    ArrayDecref0(v0);
    int32_t v8;
    v8 = v6 + v7 ;
    int32_t v9;
    v9 = v8 - 16l ;
    return v9;
}
