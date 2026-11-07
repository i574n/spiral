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
    int refc;
    Array0 * v0;
    bool v1;
} Heap0;
static inline void ArrayDecrefBody1(Array1 * x){
    (void)x;
}
static void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
static Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(char) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array1 * ArrayLit1(uint32_t len, char * ptr){
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
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(String *) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, String * * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(String *) * len);
        for (uint32_t i=0; i < len; i++){
            String * v = ptr[i];
            (v)->refc++;
        }
    return x;
}
static inline void AssignArray0(String * * a, String * b){
    (b)->refc++;
    StringDecref(*a);
    *a = b;
}
static inline void HeapDecrefBody0(Heap0 * x){
    ArrayDecref0(x->v0);
}
static void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
static Heap0 * HeapCreate0(Array0 * v0, bool v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
int32_t main(){
    Array0 * v0 = ArrayCreate0(1l, true);
    String * v1 = StringLit(3, "hi");
    AssignArray0(&(v0->ptr[0l]), v1);
    StringDecref(v1);
    bool v2 = true;
    (v0)->refc++;
    Heap0 * v3 = HeapCreate0(v0, v2);
    ArrayDecref0(v0);
    Array0 * v4; bool v5;
    v4 = v3->v0; v5 = v3->v1;
    (v4)->refc++;
    HeapDecref0(v3);
    String * v6 = v4->ptr[0l];
    (v6)->refc++;
    ArrayDecref0(v4);
    bool v7 = strcmp(v6->ptr, "hi") == 0;
    StringDecref(v6);
    bool v8 = v7 && v5;
    if (v8){
        return 0l;
    } else {
        return 1l;
    }
}
