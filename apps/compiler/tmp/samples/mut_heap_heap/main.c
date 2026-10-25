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
    Heap1 * v0;
} Mut0;
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
static inline void MutDecrefBody0(Mut0 * x){
    HeapDecref1(x->v0);
}
static void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
static Mut0 * MutCreate0(Heap1 * v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void AssignMut0(Heap1 * * a0, Heap1 * b0){
    (b0)->refc++;
    HeapDecref1(*a0);
    *a0 = b0;
}
int32_t main(){
    int32_t v0 = 3l;
    String * v1 = StringLit(3, "no");
    (v1)->refc++;
    Heap0 * v2 = HeapCreate0(v0, v1);
    StringDecref(v1);
    int32_t v3 = 1l;
    (v2)->refc++;
    Heap1 * v4 = HeapCreate1(v2, v3);
    (v4)->refc++;
    HeapDecref0(v2);
    Mut0 * v5 = MutCreate0(v4);
    HeapDecref1(v4);
    int32_t v6 = 7l;
    String * v7 = StringLit(3, "hi");
    (v7)->refc++;
    Heap0 * v8 = HeapCreate0(v6, v7);
    StringDecref(v7);
    int32_t v9 = 4l;
    (v8)->refc++;
    Heap1 * v10 = HeapCreate1(v8, v9);
    HeapDecref0(v8);
    AssignMut0(&(v5->v0), v10);
    HeapDecref1(v10);
    Heap1 * v11 = v5->v0;
    (v11)->refc++;
    MutDecref0(v5);
    Heap0 * v12; int32_t v13;
    v12 = v11->v0; v13 = v11->v1;
    (v12)->refc++;
    HeapDecref1(v11);
    int32_t v14; String * v15;
    v14 = v12->v0; v15 = v12->v1;
    (v15)->refc++;
    HeapDecref0(v12);
    bool v16 = v14 == 7l;
    bool v18;
    if (v16){
        bool v17 = strcmp(v15->ptr, "hi") == 0;
        v18 = v17;
    } else {
        v18 = false;
    }
    StringDecref(v15);
    bool v20;
    if (v18){
        bool v19 = v13 == 4l;
        v20 = v19;
    } else {
        v20 = false;
    }
    if (v20){
        return 0l;
    } else {
        return 1l;
    }
}
