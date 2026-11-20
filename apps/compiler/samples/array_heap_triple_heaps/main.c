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
    Heap0 * v2;
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
    HeapDecref0(x->v0); HeapDecref0(x->v1); HeapDecref0(x->v2);
}
static void HeapDecref1(Heap1 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody1(x); free(x); }
}
static Heap1 * HeapCreate1(Heap0 * v0, Heap0 * v1, Heap0 * v2){
    Heap1 * x = malloc(sizeof(Heap1));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1; x->v2 = v2;
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
    int32_t v3 = 4l;
    String * v4 = StringLit(3, "yo");
    (v4)->refc++;
    Heap0 * v5 = HeapCreate0(v3, v4);
    StringDecref(v4);
    int32_t v6 = 9l;
    String * v7 = StringLit(3, "ok");
    (v7)->refc++;
    Heap0 * v8 = HeapCreate0(v6, v7);
    (v2)->refc++; (v5)->refc++; (v8)->refc++;
    StringDecref(v7);
    Heap1 * v9 = HeapCreate1(v2, v5, v8);
    HeapDecref0(v2); HeapDecref0(v5); HeapDecref0(v8);
    Array1 * v10 = ArrayCreate1(1l, true);
    AssignArray0(&(v10->ptr[0l]), v9);
    HeapDecref1(v9);
    Heap1 * v11 = v10->ptr[0l];
    (v11)->refc++;
    ArrayDecref1(v10);
    Heap0 * v12; Heap0 * v13; Heap0 * v14;
    v12 = v11->v0; v13 = v11->v1; v14 = v11->v2;
    (v12)->refc++; (v13)->refc++; (v14)->refc++;
    HeapDecref1(v11);
    int32_t v15; String * v16;
    v15 = v12->v0; v16 = v12->v1;
    (v16)->refc++;
    HeapDecref0(v12);
    int32_t v17; String * v18;
    v17 = v13->v0; v18 = v13->v1;
    (v18)->refc++;
    HeapDecref0(v13);
    int32_t v19; String * v20;
    v19 = v14->v0; v20 = v14->v1;
    (v20)->refc++;
    HeapDecref0(v14);
    bool v21 = v15 == 7l;
    bool v23;
    if (v21){
        bool v22 = strcmp(v16->ptr, "hi") == 0;
        v23 = v22;
    } else {
        v23 = false;
    }
    StringDecref(v16);
    bool v25;
    if (v23){
        bool v24 = v17 == 4l;
        v25 = v24;
    } else {
        v25 = false;
    }
    bool v27;
    if (v25){
        bool v26 = strcmp(v18->ptr, "yo") == 0;
        v27 = v26;
    } else {
        v27 = false;
    }
    StringDecref(v18);
    bool v29;
    if (v27){
        bool v28 = v19 == 9l;
        v29 = v28;
    } else {
        v29 = false;
    }
    bool v31;
    if (v29){
        bool v30 = strcmp(v20->ptr, "ok") == 0;
        v31 = v30;
    } else {
        v31 = false;
    }
    StringDecref(v20);
    if (v31){
        return 0l;
    } else {
        return 1l;
    }
}
