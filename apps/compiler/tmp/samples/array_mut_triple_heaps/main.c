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
} Mut0;
typedef struct {
    int refc;
    uint32_t len;
    Mut0 * ptr[];
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
static inline void MutDecrefBody0(Mut0 * x){
    HeapDecref0(x->v0); HeapDecref0(x->v1); HeapDecref0(x->v2);
}
static void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
static Mut0 * MutCreate0(Heap0 * v0, Heap0 * v1, Heap0 * v2){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1; x->v2 = v2;
    return x;
}
static inline void ArrayDecrefBody1(Array1 * x){
    uint32_t len = x->len;
    Mut0 * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        Mut0 * v = ptr[i];
        MutDecref0(v);
    }
}
static void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
static Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(Mut0 *) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array1 * ArrayLit1(uint32_t len, Mut0 * * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(Mut0 *) * len);
        for (uint32_t i=0; i < len; i++){
            Mut0 * v = ptr[i];
            (v)->refc++;
        }
    return x;
}
static inline void AssignArray0(Mut0 * * a, Mut0 * b){
    (b)->refc++;
    MutDecref0(*a);
    *a = b;
}
static inline void AssignMut0(Heap0 * * a0, Heap0 * b0, Heap0 * * a1, Heap0 * b1, Heap0 * * a2, Heap0 * b2){
    (b0)->refc++; (b1)->refc++; (b2)->refc++;
    HeapDecref0(*a0); HeapDecref0(*a1); HeapDecref0(*a2);
    *a0 = b0; *a1 = b1; *a2 = b2;
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
    StringDecref(v4);
    int32_t v6 = 3l;
    String * v7 = StringLit(3, "aa");
    (v7)->refc++;
    Heap0 * v8 = HeapCreate0(v6, v7);
    (v2)->refc++; (v5)->refc++; (v8)->refc++;
    StringDecref(v7);
    Mut0 * v9 = MutCreate0(v2, v5, v8);
    HeapDecref0(v2); HeapDecref0(v5); HeapDecref0(v8);
    Array1 * v10 = ArrayCreate1(1l, true);
    AssignArray0(&(v10->ptr[0l]), v9);
    MutDecref0(v9);
    int32_t v11 = 7l;
    String * v12 = StringLit(3, "hi");
    (v12)->refc++;
    Heap0 * v13 = HeapCreate0(v11, v12);
    StringDecref(v12);
    int32_t v14 = 4l;
    String * v15 = StringLit(3, "yo");
    (v15)->refc++;
    Heap0 * v16 = HeapCreate0(v14, v15);
    StringDecref(v15);
    int32_t v17 = 9l;
    String * v18 = StringLit(3, "ok");
    (v18)->refc++;
    Heap0 * v19 = HeapCreate0(v17, v18);
    StringDecref(v18);
    Mut0 * v20 = v10->ptr[0l];
    (v20)->refc++;
    ArrayDecref1(v10);
    AssignMut0(&(v20->v0), v13, &(v20->v1), v16, &(v20->v2), v19);
    HeapDecref0(v13); HeapDecref0(v16); HeapDecref0(v19);
    Heap0 * v21; Heap0 * v22; Heap0 * v23;
    v21 = v20->v0; v22 = v20->v1; v23 = v20->v2;
    (v21)->refc++; (v22)->refc++; (v23)->refc++;
    MutDecref0(v20);
    int32_t v24; String * v25;
    v24 = v21->v0; v25 = v21->v1;
    (v25)->refc++;
    HeapDecref0(v21);
    int32_t v26; String * v27;
    v26 = v22->v0; v27 = v22->v1;
    (v27)->refc++;
    HeapDecref0(v22);
    int32_t v28; String * v29;
    v28 = v23->v0; v29 = v23->v1;
    (v29)->refc++;
    HeapDecref0(v23);
    bool v30 = v24 == 7l;
    bool v32;
    if (v30){
        bool v31 = strcmp(v25->ptr, "hi") == 0;
        v32 = v31;
    } else {
        v32 = false;
    }
    StringDecref(v25);
    bool v34;
    if (v32){
        bool v33 = v26 == 4l;
        v34 = v33;
    } else {
        v34 = false;
    }
    bool v36;
    if (v34){
        bool v35 = strcmp(v27->ptr, "yo") == 0;
        v36 = v35;
    } else {
        v36 = false;
    }
    StringDecref(v27);
    bool v38;
    if (v36){
        bool v37 = v28 == 9l;
        v38 = v37;
    } else {
        v38 = false;
    }
    bool v40;
    if (v38){
        bool v39 = strcmp(v29->ptr, "ok") == 0;
        v40 = v39;
    } else {
        v40 = false;
    }
    StringDecref(v29);
    if (v40){
        return 0l;
    } else {
        return 1l;
    }
}
