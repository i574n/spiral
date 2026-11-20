#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
static void UHDecref0(UH0 * x);
typedef struct UH1 UH1;
static void UHDecref1(UH1 * x);
typedef struct UH2 UH2;
static void UHDecref2(UH2 * x);
struct UH0 {
    int refc;
    int tag;
    union {
    };
};
struct UH1 {
    int refc;
    int tag;
    union {
    };
};
struct UH2 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v0;
            UH1 * v1;
        } case1; // PayloadRowCons
    };
};
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
    }
}
static void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_PayloadZero() { // PayloadZero
    static UH0 x = { .refc = 1073741823, .tag = 0 };
    return &x;
}
static inline void UHDecrefBody1(UH1 * x){
    switch (x->tag) {
    }
}
static void UHDecref1(UH1 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody1(x); free(x); }
}
UH1 * UH1_PayloadRowNil() { // PayloadRowNil
    static UH1 x = { .refc = 1073741823, .tag = 0 };
    return &x;
}
static inline void UHDecrefBody2(UH2 * x){
    switch (x->tag) {
        case 1: {
            UHDecref0(x->case1.v0); UHDecref1(x->case1.v1);
            break;
        }
    }
}
static void UHDecref2(UH2 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody2(x); free(x); }
}
UH2 * UH2_PayloadRowCons(UH0 * v0, UH1 * v1) { // PayloadRowCons
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
int32_t main(){
    UH0 * v0 = UH0_PayloadZero();
    UH0 * v1 = UH0_PayloadZero();
    UH1 * v2 = UH1_PayloadRowNil();
    (v1)->refc++; (v2)->refc++;
    UH2 * v3 = UH2_PayloadRowCons(v1, v2);
    UHDecref0(v1); UHDecref1(v2);
    UH0 * v7;
    switch (v0->tag) {
        default: { // PayloadZero
            switch (v3->tag) {
                default: { // PayloadRowCons
                    UH0 * v4 = v3->case1.v0;
                    (v4)->refc++;
                    v7 = v4;
                    break;
                }
            }
            break;
        }
    }
    UHDecref0(v0); UHDecref2(v3);
    bool v8;
    switch (v7->tag) {
        default: { // PayloadZero
            v8 = true;
            break;
        }
    }
    UHDecref0(v7);
    if (v8){
        return 0l;
    } else {
        return 1l;
    }
}
