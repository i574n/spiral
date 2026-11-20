#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
} Heap0;
typedef struct {
    int tag;
    union {
        struct {
            Heap0 * v0;
            int32_t v1;
        } case1; // Held
    };
} US0;
static inline void HeapDecrefBody0(Heap0 * x){
    (void)x;
}
static void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
static Heap0 * HeapCreate0(int32_t v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
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
            HeapDecref0(x->case1.v0);
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
US0 US0_Held(Heap0 * v0, int32_t v1) { // Held
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static int32_t score0(US0 v0){
    switch (v0.tag) {
        case 1: { // Held
            Heap0 * v1 = v0.case1.v0; int32_t v2 = v0.case1.v1;
            (v1)->refc++;
            USDecref0(&(v0));
            int32_t v3 = v1->v0;
            HeapDecref0(v1);
            int32_t v4 = v3 + v2;
            bool v5 = v4 == 7l;
            if (v5){
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
    int32_t v0 = 3l;
    int32_t v1 = 4l;
    Heap0 * v2 = HeapCreate0(v0);
    bool v3 = true;
    US0 v6;
    if (v3){
        (v2)->refc++;
        v6 = US0_Held(v2, v1);
    } else {
        v6 = US0_None();
    }
    HeapDecref0(v2);
    return score0(v6);
}
