#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH1 UH1;
static void UHDecref1(UH1 * x);
typedef struct UH0 UH0;
static void UHDecref0(UH0 * x);
struct UH1 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v0;
        } case1; // NotNo
    };
};
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            UH1 * v0;
        } case3; // NotYes
    };
};
static inline void UHDecrefBody1(UH1 * x){
    switch (x->tag) {
        case 1: {
            UHDecref0(x->case1.v0);
            break;
        }
    }
}
static void UHDecref1(UH1 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody1(x); free(x); }
}
UH1 * UH1_Eps() { // Eps
    static UH1 x = { .refc = 1073741823, .tag = 0 };
    return &x;
}
UH1 * UH1_NotNo(UH0 * v0) { // NotNo
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 3: {
            UHDecref1(x->case3.v0);
            break;
        }
    }
}
static void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_Never() { // Never
    static UH0 x = { .refc = 1073741823, .tag = 2 };
    return &x;
}
UH0 * UH0_NotYes(UH1 * v0) { // NotYes
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 3;
    x->refc = 1;
    x->case3.v0 = v0;
    return x;
}
static int32_t yes_depth0(UH1 * v0);
static int32_t no_depth1(UH0 * v0){
    switch (v0->tag) {
        case 2: { // Never
            UHDecref0(v0);
            return 2l;
            break;
        }
        default: { // NotYes
            UH1 * v1 = v0->case3.v0;
            (v1)->refc += 2;
            UHDecref0(v0);
            int32_t v2 = yes_depth0(v1);
            UHDecref1(v1);
            int32_t v3 = 1l + v2;
            return v3;
            break;
        }
    }
}
static int32_t yes_depth0(UH1 * v0){
    switch (v0->tag) {
        case 0: { // Eps
            UHDecref1(v0);
            return 1l;
            break;
        }
        default: { // NotNo
            UH0 * v1 = v0->case1.v0;
            (v1)->refc += 2;
            UHDecref1(v0);
            int32_t v2 = no_depth1(v1);
            UHDecref0(v1);
            int32_t v3 = 1l + v2;
            return v3;
            break;
        }
    }
}
int32_t main(){
    UH0 * v0 = UH0_Never();
    (v0)->refc++;
    UH1 * v1 = UH1_NotNo(v0);
    (v1)->refc++;
    UHDecref0(v0);
    UH0 * v2 = UH0_NotYes(v1);
    (v2)->refc++;
    UHDecref1(v1);
    UH1 * v3 = UH1_NotNo(v2);
    UHDecref0(v2);
    return yes_depth0(v3);
}
