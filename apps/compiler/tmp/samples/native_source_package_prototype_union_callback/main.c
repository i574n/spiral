#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case1; // Hit
        struct {
            bool v0;
        } case2; // Flag
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
    int refc;
    void (*decref_fptr)(Closure0 *);
    US0 (*fptr)(Closure0 *, int32_t);
    int32_t v0;
};
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_0() { // Idle
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(int32_t v0) { // Hit
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
US0 US0_2(bool v0) { // Flag
    US0 x;
    x.tag = 2;
    x.case2.v0 = v0;
    return x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
US0 ClosureMethod0(Closure0 * x, int32_t v1){
    int32_t v0 = x->v0;
    bool v2;
    v2 = v1 == v0 ;
    ClosureDecref0(x);
    return US0_2(v2);
}
Fun0 * ClosureCreate0(int32_t v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    x->v0 = v0;
    return (Fun0 *) x;
}
US0 method0(Fun0 * v0, int32_t v1){
    return v0->fptr(v0, v1);
}
int32_t main(){
    int32_t v0;
    v0 = 2l;
    Fun0 * v1;
    v1 = ClosureCreate0(v0);
    v1->refc++;
    US0 v2;
    v2 = method0(v1, v0);
    v1->decref_fptr(v1);
    int32_t v8;
    switch (v2.tag) {
        case 2: { // Flag
            bool v4 = v2.case2.v0;
            if (v4){
                v8 = 11l;
            } else {
                v8 = 5l;
            }
            break;
        }
        case 1: { // Hit
            int32_t v3 = v2.case1.v0;
            v8 = v3;
            break;
        }
        case 0: { // Idle
            v8 = 3l;
            break;
        }
    }
    USDecref0(&(v2));
    int32_t v9;
    v9 = v8 + 31l ;
    return v9;
}
