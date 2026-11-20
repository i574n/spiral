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
    int tag;
    union {
        struct {
            Heap2 * v0;
        } case1; // Held
    };
} US0;
typedef struct {
    int refc;
    US0 v0;
} Heap3;
typedef struct {
    int refc;
    Heap3 * v0;
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
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            HeapDecref2(x->case1.v0);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_None() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Held(Heap2 * v0) { // Held
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline void HeapDecrefBody3(Heap3 * x){
    USDecref0(&(x->v0));
}
static void HeapDecref3(Heap3 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody3(x); free(x); }
}
static Heap3 * HeapCreate3(US0 v0){
    Heap3 * x = malloc(sizeof(Heap3));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void MutDecrefBody0(Mut0 * x){
    HeapDecref3(x->v0);
}
static void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
static Mut0 * MutCreate0(Heap3 * v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void AssignMut0(Heap3 * * a0, Heap3 * b0){
    (b0)->refc++;
    HeapDecref3(*a0);
    *a0 = b0;
}
static int32_t score0(US0 v0){
    switch (v0.tag) {
        case 1: { // Held
            Heap2 * v1 = v0.case1.v0;
            (v1)->refc++;
            USDecref0(&(v0));
            Heap1 * v2; int32_t v3;
            v2 = v1->v0; v3 = v1->v1;
            (v2)->refc++;
            HeapDecref2(v1);
            Heap0 * v4; Heap0 * v5;
            v4 = v2->v0; v5 = v2->v1;
            (v4)->refc++; (v5)->refc++;
            HeapDecref1(v2);
            int32_t v6; String * v7;
            v6 = v4->v0; v7 = v4->v1;
            (v7)->refc++;
            HeapDecref0(v4);
            int32_t v8; String * v9;
            v8 = v5->v0; v9 = v5->v1;
            (v9)->refc++;
            HeapDecref0(v5);
            bool v10 = v6 == 7l;
            bool v12;
            if (v10){
                bool v11 = strcmp(v7->ptr, "hi") == 0;
                v12 = v11;
            } else {
                v12 = false;
            }
            StringDecref(v7);
            bool v14;
            if (v12){
                bool v13 = v8 == 4l;
                v14 = v13;
            } else {
                v14 = false;
            }
            bool v16;
            if (v14){
                bool v15 = strcmp(v9->ptr, "yo") == 0;
                v16 = v15;
            } else {
                v16 = false;
            }
            StringDecref(v9);
            bool v18;
            if (v16){
                bool v17 = v3 == 2l;
                v18 = v17;
            } else {
                v18 = false;
            }
            if (v18){
                return 0l;
            } else {
                return 1l;
            }
            break;
        }
        default: { // None
            USDecref0(&(v0));
            return 1l;
            break;
        }
    }
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
    HeapDecref1(v6);
    bool v9 = true;
    US0 v12;
    if (v9){
        (v8)->refc++;
        v12 = US0_Held(v8);
    } else {
        v12 = US0_None();
    }
    USIncref0(&(v12));
    HeapDecref2(v8);
    Heap3 * v13 = HeapCreate3(v12);
    (v13)->refc++;
    USDecref0(&(v12));
    Mut0 * v14 = MutCreate0(v13);
    HeapDecref3(v13);
    int32_t v15 = 7l;
    String * v16 = StringLit(3, "hi");
    (v16)->refc++;
    Heap0 * v17 = HeapCreate0(v15, v16);
    StringDecref(v16);
    int32_t v18 = 4l;
    String * v19 = StringLit(3, "yo");
    (v19)->refc++;
    Heap0 * v20 = HeapCreate0(v18, v19);
    (v17)->refc++; (v20)->refc++;
    StringDecref(v19);
    Heap1 * v21 = HeapCreate1(v17, v20);
    HeapDecref0(v17); HeapDecref0(v20);
    int32_t v22 = 2l;
    (v21)->refc++;
    Heap2 * v23 = HeapCreate2(v21, v22);
    HeapDecref1(v21);
    bool v24 = true;
    US0 v27;
    if (v24){
        (v23)->refc++;
        v27 = US0_Held(v23);
    } else {
        v27 = US0_None();
    }
    USIncref0(&(v27));
    HeapDecref2(v23);
    Heap3 * v28 = HeapCreate3(v27);
    USDecref0(&(v27));
    AssignMut0(&(v14->v0), v28);
    HeapDecref3(v28);
    Heap3 * v29 = v14->v0;
    (v29)->refc++;
    MutDecref0(v14);
    US0 v30 = v29->v0;
    USIncref0(&(v30));
    HeapDecref3(v29);
    return score0(v30);
}
