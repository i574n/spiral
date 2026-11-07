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
    Heap0 * v1;
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
    HeapDecref0(x->v0); HeapDecref0(x->v1);
}
static void HeapDecref1(Heap1 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody1(x); free(x); }
}
static Heap1 * HeapCreate1(Heap0 * v0, Heap0 * v1){
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
    int32_t v0 = 1l;
    String * v1 = StringLit(3, "no");
    (v1)->refc++;
    Heap0 * v2 = HeapCreate0(v0, v1);
    StringDecref(v1);
    int32_t v3 = 2l;
    String * v4 = StringLit(3, "zz");
    (v4)->refc++;
    Heap0 * v5 = HeapCreate0(v3, v4);
    (v2)->refc++; (v5)->refc++;
    StringDecref(v4);
    Heap1 * v6 = HeapCreate1(v2, v5);
    HeapDecref0(v2); HeapDecref0(v5);
    int32_t v7 = 3l;
    (v6)->refc++;
    Heap2 * v8 = HeapCreate2(v6, v7);
    (v8)->refc++;
    HeapDecref1(v6);
    Mut0 * v9 = MutCreate0(v8);
    HeapDecref2(v8);
    int32_t v10 = 7l;
    String * v11 = StringLit(3, "hi");
    (v11)->refc++;
    Heap0 * v12 = HeapCreate0(v10, v11);
    StringDecref(v11);
    int32_t v13 = 4l;
    String * v14 = StringLit(3, "yo");
    (v14)->refc++;
    Heap0 * v15 = HeapCreate0(v13, v14);
    (v12)->refc++; (v15)->refc++;
    StringDecref(v14);
    Heap1 * v16 = HeapCreate1(v12, v15);
    HeapDecref0(v12); HeapDecref0(v15);
    int32_t v17 = 2l;
    (v16)->refc++;
    Heap2 * v18 = HeapCreate2(v16, v17);
    HeapDecref1(v16);
    AssignMut0(&(v9->v0), v18);
    HeapDecref2(v18);
    Heap2 * v19 = v9->v0;
    (v19)->refc++;
    MutDecref0(v9);
    Heap1 * v20; int32_t v21;
    v20 = v19->v0; v21 = v19->v1;
    (v20)->refc++;
    HeapDecref2(v19);
    Heap0 * v22; Heap0 * v23;
    v22 = v20->v0; v23 = v20->v1;
    (v22)->refc++; (v23)->refc++;
    HeapDecref1(v20);
    int32_t v24; String * v25;
    v24 = v22->v0; v25 = v22->v1;
    (v25)->refc++;
    HeapDecref0(v22);
    int32_t v26; String * v27;
    v26 = v23->v0; v27 = v23->v1;
    (v27)->refc++;
    HeapDecref0(v23);
    bool v28 = v24 == 7l;
    bool v30;
    if (v28){
        bool v29 = strcmp(v25->ptr, "hi") == 0;
        v30 = v29;
    } else {
        v30 = false;
    }
    StringDecref(v25);
    bool v32;
    if (v30){
        bool v31 = v26 == 4l;
        v32 = v31;
    } else {
        v32 = false;
    }
    bool v34;
    if (v32){
        bool v33 = strcmp(v27->ptr, "yo") == 0;
        v34 = v33;
    } else {
        v34 = false;
    }
    StringDecref(v27);
    bool v36;
    if (v34){
        bool v35 = v21 == 2l;
        v36 = v35;
    } else {
        v36 = false;
    }
    if (v36){
        return 0l;
    } else {
        return 1l;
    }
}
