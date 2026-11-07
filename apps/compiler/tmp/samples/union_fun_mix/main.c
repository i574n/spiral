#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    int32_t (*fptr)(Fun0 *, int32_t);
};
typedef struct {
    int tag;
    union {
        struct {
            Fun0 * v0;
            int32_t v1;
        } case1; // Call
    };
} US0;
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
    int32_t v0;
};
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
            (x->case1.v0)->decref_fptr(x->case1.v0);
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
US0 US0_Call(Fun0 * v0, int32_t v1) { // Call
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static int32_t add_c0(Fun0 * self, int32_t v1){
    Closure0 * x = (Closure0 *) self;
    int32_t v0 = x->v0;
    ClosureDecref0(self);
    int32_t v2 = v1 + v0;
    return v2;
}
static Fun0 * ClosureCreate0(int32_t v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = add_c0;
    x->v0 = v0;
    return &x->base;
}
static int32_t score0(US0 v0){
    switch (v0.tag) {
        case 1: { // Call
            Fun0 * v1 = v0.case1.v0; int32_t v2 = v0.case1.v1;
            (v1)->refc += 2;
            USDecref0(&(v0));
            int32_t v3 = v1->fptr(v1, 0l);
            (v1)->decref_fptr(v1);
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
    bool v2 = true;
    US0 v6;
    if (v2){
        Fun0 * v3 = ClosureCreate0(v0);
        v6 = US0_Call(v3, v1);
    } else {
        v6 = US0_None();
    }
    return score0(v6);
}
