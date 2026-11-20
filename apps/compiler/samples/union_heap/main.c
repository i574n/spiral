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
        } case1; // Box
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
US0 US0_Missing() { // Missing
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Box(Heap0 * v0) { // Box
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t main(){
    int32_t v0 = 7l;
    Heap0 * v1 = HeapCreate0(v0);
    bool v2 = true;
    US0 v5;
    if (v2){
        (v1)->refc++;
        v5 = US0_Box(v1);
    } else {
        v5 = US0_Missing();
    }
    HeapDecref0(v1);
    switch (v5.tag) {
        case 1: { // Box
            Heap0 * v6 = v5.case1.v0;
            (v6)->refc++;
            USDecref0(&(v5));
            int32_t v7 = v6->v0;
            HeapDecref0(v6);
            bool v8 = v7 == 7l;
            if (v8){
                return 0l;
            } else {
                return 1l;
            }
            break;
        }
        default: { // Missing
            USDecref0(&(v5));
            return 1l;
            break;
        }
    }
}
