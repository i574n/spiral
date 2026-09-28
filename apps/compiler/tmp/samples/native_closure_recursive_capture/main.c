#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v1;
            UH0 * v2;
            int32_t v0;
        } case1; // Node
    };
};
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    int32_t (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    int32_t (*fptr)(Closure0 *, int32_t);
    UH0 * v0;
};
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 1: {
            UHDecref0(x->case1.v1); UHDecref0(x->case1.v2);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_0() { // Leaf
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH0 * UH0_1(int32_t v0, UH0 * v1, UH0 * v2) { // Node
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1; x->case1.v2 = v2;
    return x;
}
int32_t sum0(UH0 * v0){
    switch (v0->tag) {
        case 0: { // Leaf
            UHDecref0(v0);
            return 0l;
            break;
        }
        case 1: { // Node
            int32_t v1 = v0->case1.v0; UH0 * v2 = v0->case1.v1; UH0 * v3 = v0->case1.v2;
            v2->refc += 2; v3->refc++;
            UHDecref0(v0);
            int32_t v4;
            v4 = sum0(v2);
            v3->refc++;
            UHDecref0(v2);
            int32_t v5;
            v5 = sum0(v3);
            UHDecref0(v3);
            int32_t v6;
            v6 = v4 + v5;
            int32_t v7;
            v7 = v1 + v6;
            return v7;
            break;
        }
    }
}
static inline void ClosureDecrefBody0(Closure0 * x){
    UHDecref0(x->v0);
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
int32_t ClosureMethod0(Closure0 * x, int32_t v1){
    UH0 * v0 = x->v0;
    v0->refc++;
    int32_t v2;
    v2 = sum0(v0);
    int32_t v3;
    v3 = v2 + v1;
    ClosureDecref0(x);
    return v3;
}
Fun0 * ClosureCreate0(UH0 * v0){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    x->v0 = v0;
    return (Fun0 *) x;
}
int32_t main(){
    UH0 * v0;
    v0 = UH0_0();
    int32_t v1;
    v1 = 2l;
    v0->refc += 2;
    UH0 * v2;
    v2 = UH0_1(v1, v0, v0);
    v2->refc++;
    UHDecref0(v0);
    Fun0 * v3;
    v3 = ClosureCreate0(v2);
    v3->refc++;
    UHDecref0(v2);
    int32_t v4;
    v4 = v3->fptr(v3, 19l);
    v3->refc++;
    int32_t v5;
    v5 = v3->fptr(v3, 19l);
    v3->decref_fptr(v3);
    int32_t v6;
    v6 = v4 + v5;
    return v6;
}
