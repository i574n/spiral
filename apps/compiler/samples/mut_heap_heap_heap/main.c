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
    int32_t v1;
} Heap2;
typedef struct {
    int refc;
    Heap2 * v0;
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
static inline void HeapDecrefBody2(Heap2 * x){
    HeapDecref1(x->v0);
}
static void HeapDecref2(Heap2 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody2(x); free(x); }
}
static Heap2 * HeapCreate2(Heap1 * v0, int32_t v1){
    Heap2 * x = malloc(sizeof(Heap2));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void MutDecrefBody0(Mut0 * x){
    HeapDecref2(x->v0);
}
static void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
static Mut0 * MutCreate0(Heap2 * v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void AssignMut0(Heap2 * * a0, Heap2 * b0){
    (b0)->refc++;
    HeapDecref2(*a0);
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
    HeapDecref0(v2);
    int32_t v5 = 2l;
    (v4)->refc++;
    Heap2 * v6 = HeapCreate2(v4, v5);
    (v6)->refc++;
    HeapDecref1(v4);
    Mut0 * v7 = MutCreate0(v6);
    HeapDecref2(v6);
    int32_t v8 = 7l;
    String * v9 = StringLit(3, "hi");
    (v9)->refc++;
    Heap0 * v10 = HeapCreate0(v8, v9);
    StringDecref(v9);
    int32_t v11 = 4l;
    (v10)->refc++;
    Heap1 * v12 = HeapCreate1(v10, v11);
    HeapDecref0(v10);
    int32_t v13 = 5l;
    (v12)->refc++;
    Heap2 * v14 = HeapCreate2(v12, v13);
    HeapDecref1(v12);
    AssignMut0(&(v7->v0), v14);
    HeapDecref2(v14);
    Heap2 * v15 = v7->v0;
    (v15)->refc++;
    MutDecref0(v7);
    Heap1 * v16; int32_t v17;
    v16 = v15->v0; v17 = v15->v1;
    (v16)->refc++;
    HeapDecref2(v15);
    Heap0 * v18; int32_t v19;
    v18 = v16->v0; v19 = v16->v1;
    (v18)->refc++;
    HeapDecref1(v16);
    int32_t v20; String * v21;
    v20 = v18->v0; v21 = v18->v1;
    (v21)->refc++;
    HeapDecref0(v18);
    bool v22 = v20 == 7l;
    bool v24;
    if (v22){
        bool v23 = strcmp(v21->ptr, "hi") == 0;
        v24 = v23;
    } else {
        v24 = false;
    }
    StringDecref(v21);
    bool v26;
    if (v24){
        bool v25 = v19 == 4l;
        v26 = v25;
    } else {
        v26 = false;
    }
    bool v28;
    if (v26){
        bool v27 = v17 == 5l;
        v28 = v27;
    } else {
        v28 = false;
    }
    if (v28){
        return 0l;
    } else {
        return 1l;
    }
}
