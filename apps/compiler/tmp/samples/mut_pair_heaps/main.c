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
static inline void MutDecrefBody0(Mut0 * x){
    HeapDecref0(x->v0); HeapDecref0(x->v1);
}
static void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
static Mut0 * MutCreate0(Heap0 * v0, Heap0 * v1){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void AssignMut0(Heap0 * * a0, Heap0 * b0, Heap0 * * a1, Heap0 * b1){
    (b0)->refc++; (b1)->refc++;
    HeapDecref0(*a0); HeapDecref0(*a1);
    *a0 = b0; *a1 = b1;
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
    Mut0 * v6 = MutCreate0(v2, v5);
    HeapDecref0(v2); HeapDecref0(v5);
    int32_t v7 = 7l;
    String * v8 = StringLit(3, "hi");
    (v8)->refc++;
    Heap0 * v9 = HeapCreate0(v7, v8);
    StringDecref(v8);
    int32_t v10 = 4l;
    String * v11 = StringLit(3, "yo");
    (v11)->refc++;
    Heap0 * v12 = HeapCreate0(v10, v11);
    StringDecref(v11);
    AssignMut0(&(v6->v0), v9, &(v6->v1), v12);
    HeapDecref0(v9); HeapDecref0(v12);
    Heap0 * v13; Heap0 * v14;
    v13 = v6->v0; v14 = v6->v1;
    (v13)->refc++; (v14)->refc++;
    MutDecref0(v6);
    int32_t v15; String * v16;
    v15 = v13->v0; v16 = v13->v1;
    (v16)->refc++;
    HeapDecref0(v13);
    int32_t v17; String * v18;
    v17 = v14->v0; v18 = v14->v1;
    (v18)->refc++;
    HeapDecref0(v14);
    bool v19 = v15 == 7l;
    bool v21;
    if (v19){
        bool v20 = strcmp(v16->ptr, "hi") == 0;
        v21 = v20;
    } else {
        v21 = false;
    }
    StringDecref(v16);
    bool v23;
    if (v21){
        bool v22 = v17 == 4l;
        v23 = v22;
    } else {
        v23 = false;
    }
    bool v25;
    if (v23){
        bool v24 = strcmp(v18->ptr, "yo") == 0;
        v25 = v24;
    } else {
        v25 = false;
    }
    StringDecref(v18);
    if (v25){
        return 0l;
    } else {
        return 1l;
    }
}
