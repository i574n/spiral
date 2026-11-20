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
    int32_t v0 = 7l;
    String * v1 = StringLit(3, "hi");
    (v1)->refc++;
    Heap0 * v2 = HeapCreate0(v0, v1);
    StringDecref(v1);
    int32_t v3 = 4l;
    String * v4 = StringLit(3, "yo");
    (v4)->refc++;
    Heap0 * v5 = HeapCreate0(v3, v4);
    (v2)->refc++; (v5)->refc++;
    StringDecref(v4);
    Heap1 * v6 = HeapCreate1(v2, v5);
    HeapDecref0(v2); HeapDecref0(v5);
    int32_t v7 = 2l;
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
    USDecref1(&(v17));
    US1 v19 = v18->v0;
    USIncref1(&(v19));
    HeapDecref4(v18);
    return score0(v19);
}
