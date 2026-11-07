#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
typedef struct {
    int tag;
    union {
        struct {
            Array0 * v0;
            int32_t v1;
        } case1; // Held
    };
} US0;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(int32_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, int32_t * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    return x;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    *a = b;
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
            ArrayDecref0(x->case1.v0);
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
US0 US0_Held(Array0 * v0, int32_t v1) { // Held
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static int32_t score0(US0 v0){
    switch (v0.tag) {
        case 1: { // Held
            Array0 * v1 = v0.case1.v0; int32_t v2 = v0.case1.v1;
            (v1)->refc++;
            USDecref0(&(v0));
            int32_t v3 = v1->ptr[0l];
            ArrayDecref0(v1);
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
    Array0 * v2 = ArrayCreate0(1l, true);
    AssignArray0(&(v2->ptr[0l]), v0);
    bool v3 = true;
    US0 v6;
    if (v3){
        (v2)->refc++;
        v6 = US0_Held(v2, v1);
    } else {
        v6 = US0_None();
    }
    ArrayDecref0(v2);
    return score0(v6);
}
