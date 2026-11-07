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
    int tag;
    union {
        struct {
            Heap3 * v0;
        } case1; // Box
    };
} US1;
typedef struct {
    int refc;
    US1 v0;
} Heap4;
typedef struct {
    int refc;
    Heap4 * v0;
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
static inline void USIncrefBody1(US1 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody1(US1 * x){
    switch (x->tag) {
        case 1: {
            HeapDecref3(x->case1.v0);
            break;
        }
    }
}
void USIncref1(US1 * x){ USIncrefBody1(x); }
void USDecref1(US1 * x){ USDecrefBody1(x); }
US1 US1_Absent() { // Absent
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_Box(Heap3 * v0) { // Box
    US1 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline void HeapDecrefBody4(Heap4 * x){
    USDecref1(&(x->v0));
}
static void HeapDecref4(Heap4 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody4(x); free(x); }
}
static Heap4 * HeapCreate4(US1 v0){
    Heap4 * x = malloc(sizeof(Heap4));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void MutDecrefBody0(Mut0 * x){
    HeapDecref4(x->v0);
}
static void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
static Mut0 * MutCreate0(Heap4 * v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
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
static inline void AssignMut0(Heap4 * * a0, Heap4 * b0){
    (b0)->refc++;
    HeapDecref4(*a0);
    *a0 = b0;
}
static int32_t score0(US1 v0){
    switch (v0.tag) {
        case 0: { // Absent
            USDecref1(&(v0));
            return 1l;
            break;
        }
        default: { // Box
            Heap3 * v1 = v0.case1.v0;
            (v1)->refc++;
            USDecref1(&(v0));
            US0 v2 = v1->v0;
            USIncref0(&(v2));
            HeapDecref3(v1);
            switch (v2.tag) {
                case 1: { // Held
                    Heap2 * v3 = v2.case1.v0;
                    (v3)->refc++;
                    USDecref0(&(v2));
                    Heap1 * v4; int32_t v5;
                    v4 = v3->v0; v5 = v3->v1;
                    (v4)->refc++;
                    HeapDecref2(v3);
                    Heap0 * v6; Heap0 * v7;
                    v6 = v4->v0; v7 = v4->v1;
                    (v6)->refc++; (v7)->refc++;
                    HeapDecref1(v4);
                    int32_t v8; String * v9;
                    v8 = v6->v0; v9 = v6->v1;
                    (v9)->refc++;
                    HeapDecref0(v6);
                    int32_t v10; String * v11;
                    v10 = v7->v0; v11 = v7->v1;
                    (v11)->refc++;
                    HeapDecref0(v7);
                    bool v12 = v8 == 7l;
                    bool v14;
                    if (v12){
                        bool v13 = strcmp(v9->ptr, "hi") == 0;
                        v14 = v13;
                    } else {
                        v14 = false;
                    }
                    StringDecref(v9);
                    bool v16;
                    if (v14){
                        bool v15 = v10 == 4l;
                        v16 = v15;
                    } else {
                        v16 = false;
                    }
                    bool v18;
                    if (v16){
                        bool v17 = strcmp(v11->ptr, "yo") == 0;
                        v18 = v17;
                    } else {
                        v18 = false;
                    }
                    StringDecref(v11);
                    bool v20;
                    if (v18){
                        bool v19 = v5 == 2l;
                        v20 = v19;
                    } else {
                        v20 = false;
                    }
                    if (v20){
                        return 0l;
                    } else {
                        return 1l;
                    }
                    break;
                }
                default: { // None
                    USDecref0(&(v2));
                    return 1l;
                    break;
                }
            }
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
    USDecref0(&(v12));
    bool v14 = true;
    US1 v17;
    if (v14){
        (v13)->refc++;
        v17 = US1_Box(v13);
    } else {
        v17 = US1_Absent();
    }
    USIncref1(&(v17));
    HeapDecref3(v13);
    Heap4 * v18 = HeapCreate4(v17);
    (v18)->refc++;
    USDecref1(&(v17));
    Mut0 * v19 = MutCreate0(v18);
    HeapDecref4(v18);
    Array1 * v20 = ArrayCreate1(1l, true);
    AssignArray0(&(v20->ptr[0l]), v19);
    MutDecref0(v19);
    int32_t v21 = 7l;
    String * v22 = StringLit(3, "hi");
    (v22)->refc++;
    Heap0 * v23 = HeapCreate0(v21, v22);
    StringDecref(v22);
    int32_t v24 = 4l;
    String * v25 = StringLit(3, "yo");
    (v25)->refc++;
    Heap0 * v26 = HeapCreate0(v24, v25);
    (v23)->refc++; (v26)->refc++;
    StringDecref(v25);
    Heap1 * v27 = HeapCreate1(v23, v26);
    HeapDecref0(v23); HeapDecref0(v26);
    int32_t v28 = 2l;
    (v27)->refc++;
    Heap2 * v29 = HeapCreate2(v27, v28);
    HeapDecref1(v27);
    bool v30 = true;
    US0 v33;
    if (v30){
        (v29)->refc++;
        v33 = US0_Held(v29);
    } else {
        v33 = US0_None();
    }
    USIncref0(&(v33));
    HeapDecref2(v29);
    Heap3 * v34 = HeapCreate3(v33);
    USDecref0(&(v33));
    bool v35 = true;
    US1 v38;
    if (v35){
        (v34)->refc++;
        v38 = US1_Box(v34);
    } else {
        v38 = US1_Absent();
    }
    USIncref1(&(v38));
    HeapDecref3(v34);
    Heap4 * v39 = HeapCreate4(v38);
    USDecref1(&(v38));
    Mut0 * v40 = v20->ptr[0l];
    (v40)->refc++;
    ArrayDecref1(v20);
    AssignMut0(&(v40->v0), v39);
    HeapDecref4(v39);
    Heap4 * v41 = v40->v0;
    (v41)->refc++;
    MutDecref0(v40);
    US1 v42 = v41->v0;
    USIncref1(&(v42));
    HeapDecref4(v41);
    return score0(v42);
}
