#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct {
    int refc;
    String * v1;
    int32_t v0;
} Heap0;
typedef struct {
    int refc;
    Heap0 * v0;
    int32_t v1;
} Heap1;
typedef struct {
    int refc;
    uint32_t len;
    Heap1 * ptr[];
} Array1;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref0(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
static inline void HeapDecrefBody0(Heap0 * x){
    StringDecref(x->v1);
}
static void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
static Heap0 * HeapCreate0(int32_t v0, String * v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void HeapDecrefBody1(Heap1 * x){
    HeapDecref0(x->v0);
}
static void HeapDecref1(Heap1 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody1(x); free(x); }
}
static Heap1 * HeapCreate1(Heap0 * v0, int32_t v1){
    Heap1 * x = malloc(sizeof(Heap1));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void ArrayDecrefBody1(Array1 * x){
    uint32_t len = x->len;
    Heap1 * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        Heap1 * v = ptr[i];
        HeapDecref1(v);
    }
}
static void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
static Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(Heap1 *) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array1 * ArrayLit1(uint32_t len, Heap1 * * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(Heap1 *) * len);
        for (uint32_t i=0; i < len; i++){
            Heap1 * v = ptr[i];
            (v)->refc++;
        }
    return x;
}
static inline void AssignArray0(Heap1 * * a, Heap1 * b){
    (b)->refc++;
    HeapDecref1(*a);
    *a = b;
}
int32_t main(){
    int32_t v0 = 7l;
    String * v1 = StringLit(3, "hi");
    (v1)->refc++;
    Heap0 * v2 = HeapCreate0(v0, v1);
    StringDecref(v1);
    int32_t v3 = 1l;
    (v2)->refc++;
    Heap1 * v4 = HeapCreate1(v2, v3);
    HeapDecref0(v2);
    Array1 * v5 = ArrayCreate1(1l, true);
    AssignArray0(&(v5->ptr[0l]), v4);
    HeapDecref1(v4);
    Heap1 * v6 = v5->ptr[0l];
    (v6)->refc++;
    ArrayDecref1(v5);
    Heap0 * v7; int32_t v8;
    v7 = v6->v0; v8 = v6->v1;
    (v7)->refc++;
    HeapDecref1(v6);
    int32_t v9; String * v10;
    v9 = v7->v0; v10 = v7->v1;
    (v10)->refc++;
    HeapDecref0(v7);
    bool v11 = v9 == 7l;
    bool v13;
    if (v11){
        bool v12 = strcmp(v10->ptr, "hi") == 0;
        v13 = v12;
    } else {
        v13 = false;
    }
    StringDecref(v10);
    bool v15;
    if (v13){
        bool v14 = v8 == 1l;
        v15 = v14;
    } else {
        v15 = false;
    }
    if (v15){
        return 0l;
    } else {
        return 1l;
    }
}
