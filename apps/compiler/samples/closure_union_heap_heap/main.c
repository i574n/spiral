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
    int tag;
    union {
        struct {
            Heap1 * v0;
        } case1; // Held
    };
} US0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    US0 (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
    Heap1 * v0;
};
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
            HeapDecref1(x->case1.v0);
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
US0 US0_Held(Heap1 * v0) { // Held
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    HeapDecref1(x->v0);
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static US0 f_c0(Fun0 * self, int32_t v1){
    Closure0 * x = (Closure0 *) self;
    Heap1 * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref0(self);
    bool v2 = v1 == 0l;
    if (v2){
        HeapDecref1(v0);
        return US0_None();
    } else {
        return US0_Held(v0);
    }
}
static Fun0 * ClosureCreate0(Heap1 * v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = f_c0;
    x->v0 = v0;
    return &x->base;
}
static int32_t score0(US0 v0){
    switch (v0.tag) {
        case 1: { // Held
            Heap1 * v1 = v0.case1.v0;
            (v1)->refc++;
            USDecref0(&(v0));
            Heap0 * v2; int32_t v3;
            v2 = v1->v0; v3 = v1->v1;
            (v2)->refc++;
            HeapDecref1(v1);
            int32_t v4; String * v5;
            v4 = v2->v0; v5 = v2->v1;
            (v5)->refc++;
            HeapDecref0(v2);
            bool v6 = v4 == 7l;
            bool v8;
            if (v6){
                bool v7 = strcmp(v5->ptr, "hi") == 0;
                v8 = v7;
            } else {
                v8 = false;
            }
            StringDecref(v5);
            bool v10;
            if (v8){
                bool v9 = v3 == 1l;
                v10 = v9;
            } else {
                v10 = false;
            }
            if (v10){
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
    int32_t v0 = 7l;
    String * v1 = StringLit(3, "hi");
    (v1)->refc++;
    Heap0 * v2 = HeapCreate0(v0, v1);
    StringDecref(v1);
    int32_t v3 = 1l;
    (v2)->refc++;
    Heap1 * v4 = HeapCreate1(v2, v3);
    (v4)->refc++;
    HeapDecref0(v2);
    Fun0 * v5 = ClosureCreate0(v4);
    (v5)->refc++;
    HeapDecref1(v4);
    US0 v6 = v5->fptr(v5, 1l);
    (v5)->decref_fptr(v5);
    return score0(v6);
}
