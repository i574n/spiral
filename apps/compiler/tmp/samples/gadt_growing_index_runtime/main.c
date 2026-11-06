#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
static void UHDecref0(UH0 * x);
typedef struct UH1 UH1;
static void UHDecref1(UH1 * x);
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v0;
        } case1; // VS
    };
};
struct UH1 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v0;
        } case0; // Var
        struct {
            UH1 * v0;
        } case1; // Lam
        struct {
            UH1 * v0;
            UH1 * v1;
        } case2; // App
    };
};
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 1: {
            UHDecref0(x->case1.v0);
            break;
        }
    }
}
static void UHDecref0(UH0 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH0 * next = NULL;
        switch (x->tag) {
            case 1: {
                next = x->case1.v0;
                break;
            }
        }
        free(x);
        x = next;
    }
}
UH0 * UH0_VZ() { // VZ
    static UH0 x = { .refc = 1073741823, .tag = 0 };
    return &x;
}
UH0 * UH0_VS(UH0 * v0) { // VS
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
static inline void UHDecrefBody1(UH1 * x){
    switch (x->tag) {
        case 0: {
            UHDecref0(x->case0.v0);
            break;
        }
        case 1: {
            UHDecref1(x->case1.v0);
            break;
        }
        case 2: {
            UHDecref1(x->case2.v0); UHDecref1(x->case2.v1);
            break;
        }
    }
}
static void UHDecref1(UH1 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH1 * next = NULL;
        switch (x->tag) {
            case 0: {
                UHDecref0(x->case0.v0);
                break;
            }
            case 1: {
                next = x->case1.v0;
                break;
            }
            case 2: {
                UHDecref1(x->case2.v0);
                next = x->case2.v1;
                break;
            }
        }
        free(x);
        x = next;
    }
}
UH1 * UH1_Var(UH0 * v0) { // Var
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0;
    return x;
}
UH1 * UH1_Lam(UH1 * v0) { // Lam
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
UH1 * UH1_App(UH1 * v0, UH1 * v1) { // App
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0; x->case2.v1 = v1;
    return x;
}
static int32_t size2(UH1 * v0);
static int32_t size3(UH1 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH1 * v5 = v0->case2.v0; UH1 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref1(v0);
            int32_t v7 = size3(v5);
            UHDecref1(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size3(v6);
            UHDecref1(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH1 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref1(v0);
            int32_t v3 = size2(v2);
            UHDecref1(v2);
            int32_t v4 = 1l + v3;
            return v4;
            break;
        }
        default: { // Var
            UHDecref1(v0);
            return 1l;
            break;
        }
    }
}
static int32_t size2(UH1 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH1 * v5 = v0->case2.v0; UH1 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref1(v0);
            int32_t v7 = size3(v5);
            UHDecref1(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size3(v6);
            UHDecref1(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH1 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref1(v0);
            int32_t v3 = size2(v2);
            UHDecref1(v2);
            int32_t v4 = 1l + v3;
            return v4;
            break;
        }
        default: { // Var
            UHDecref1(v0);
            return 1l;
            break;
        }
    }
}
static int32_t size1(UH1 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH1 * v5 = v0->case2.v0; UH1 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref1(v0);
            int32_t v7 = size1(v5);
            UHDecref1(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size1(v6);
            UHDecref1(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH1 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref1(v0);
            int32_t v3 = size2(v2);
            UHDecref1(v2);
            int32_t v4 = 1l + v3;
            return v4;
            break;
        }
        default: { // Var
            UHDecref1(v0);
            return 1l;
            break;
        }
    }
}
static int32_t size0(UH1 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH1 * v5 = v0->case2.v0; UH1 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref1(v0);
            int32_t v7 = size1(v5);
            UHDecref1(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size1(v6);
            UHDecref1(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH1 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref1(v0);
            int32_t v3 = size2(v2);
            UHDecref1(v2);
            int32_t v4 = 1l + v3;
            return v4;
            break;
        }
        default: { // Var
            UHDecref1(v0);
            return 1l;
            break;
        }
    }
}
int32_t main(){
    UH0 * v0 = UH0_VZ();
    (v0)->refc++;
    UH1 * v1 = UH1_Var(v0);
    UHDecref0(v0);
    UH0 * v2 = UH0_VZ();
    (v2)->refc++;
    UH0 * v3 = UH0_VS(v2);
    (v3)->refc++;
    UHDecref0(v2);
    UH1 * v4 = UH1_Var(v3);
    (v4)->refc++;
    UHDecref0(v3);
    UH1 * v5 = UH1_Lam(v4);
    (v1)->refc++; (v5)->refc++;
    UHDecref1(v4);
    UH1 * v6 = UH1_App(v1, v5);
    (v6)->refc++;
    UHDecref1(v1); UHDecref1(v5);
    UH1 * v7 = UH1_Lam(v6);
    UHDecref1(v6);
    return size0(v7);
}
