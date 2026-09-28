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
void method1(Array0 * v0){
    int32_t v1;
    v1 = 8l;
    DynamicArrayReserve0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
void method2(Array0 * v0){
    int32_t v1;
    v1 = 3l;
    DynamicArrayResize0(v0,v1);
    ArrayDecref0(v0);
    return ;
}
int32_t method3(Array0 * v0){
    int32_t v1;
    v1 = DynamicArrayRefCount0(v0);
    ArrayDecref0(v0);
    return v1;
}
int32_t method4(Array0 * v0){
    int32_t v1;
    v1 = DynamicArrayCapacity0(v0);
    ArrayDecref0(v0);
    return v1;
}
void method5(Array0 * v0){
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
    method1(v0);
    v0->refc++;
    method2(v0);
    String * v2;
    v2 = StringLit(4, "cde");
    AssignArray0(&(v0->ptr[1l]), v2);
    StringDecref(v2);
    String * v3;
    v3 = StringLit(2, "f");
    AssignArray0(&(v0->ptr[2l]), v3);
    StringDecref(v3);
    String * v4;
    v4 = v0->ptr[0l];
    v4->refc++;
    String * v5;
    v5 = v0->ptr[1l];
    v5->refc++;
    String * v6;
    v6 = v0->ptr[2l];
    v0->refc++; v6->refc++;
    int32_t v7;
    v7 = method3(v0);
    v0->refc++;
    int32_t v8;
    v8 = method4(v0);
    v0->refc++;
    method5(v0);
    int32_t v9;
    v9 = v4->len-1;
    StringDecref(v4);
    int32_t v10;
    v10 = v5->len-1;
    StringDecref(v5);
    int32_t v11;
    v11 = v9 + v10 ;
    int32_t v12;
    v12 = v6->len-1;
    StringDecref(v6);
    int32_t v13;
    v13 = v11 + v12 ;
    int32_t v14;
    v14 = v13 + v7 ;
    int32_t v15;
    v15 = v14 + v8 ;
    int32_t v16;
    v16 = v0->len;
    ArrayDecref0(v0);
    int32_t v17;
    v17 = v15 + v16 ;
    int32_t v18;
    v18 = v17 - 17l ;
    return v18;
}
