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
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    UH0 * (*fptr)(Fun0 *, UH0 *);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    Fun0 base;
};
typedef struct Fun1 Fun1;
struct Fun1{
    int refc;
    void (*decref_fptr)(Fun1 *);
    UH0 * (*fptr)(Fun1 *, UH0 *);
};
typedef struct Closure1 Closure1;
struct Closure1 {
    Fun1 base;
    Fun0 * v0;
};
typedef struct Fun2 Fun2;
struct Fun2{
    int refc;
    void (*decref_fptr)(Fun2 *);
    UH0 * (*fptr)(Fun2 *, UH0 *);
};
typedef struct Closure2 Closure2;
struct Closure2 {
    Fun2 base;
    Fun1 * v0;
};
typedef struct Closure3 Closure3;
struct Closure3 {
    Fun2 base;
    Fun2 * v0;
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
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
static void ClosureDecref0(Fun0 * self){
    Closure0 * x = (Closure0 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
static UH0 * closure0(Fun0 * self, UH0 * v0){
    ClosureDecref0(self);
    return UH0_VS(v0);
}
static Fun0 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref0;
    x->base.fptr = closure0;
    return &x->base;
}
static inline void ClosureDecrefBody1(Closure1 * x){
    (x->v0)->decref_fptr(x->v0);
}
static void ClosureDecref1(Fun1 * self){
    Closure1 * x = (Closure1 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
static UH0 * closure1(Fun1 * self, UH0 * v1){
    Closure1 * x = (Closure1 *) self;
    Fun0 * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref1(self);
    switch (v1->tag) {
        case 1: { // VS
            UH0 * v3 = v1->case1.v0;
            (v0)->refc++; (v3)->refc += 2;
            UHDecref0(v1);
            UH0 * v4 = v0->fptr(v0, v3);
            (v0)->decref_fptr(v0); UHDecref0(v3);
            return UH0_VS(v4);
            break;
        }
        default: { // VZ
            (v0)->decref_fptr(v0); UHDecref0(v1);
            return UH0_VZ();
            break;
        }
    }
}
static Fun1 * ClosureCreate1(Fun0 * v0){
    Closure1 * x = malloc(sizeof(Closure1));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref1;
    x->base.fptr = closure1;
    x->v0 = v0;
    return &x->base;
}
static inline void ClosureDecrefBody2(Closure2 * x){
    (x->v0)->decref_fptr(x->v0);
}
static void ClosureDecref2(Fun2 * self){
    Closure2 * x = (Closure2 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody2(x); free(x); }
}
static UH0 * closure2(Fun2 * self, UH0 * v1){
    Closure2 * x = (Closure2 *) self;
    Fun1 * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref2(self);
    switch (v1->tag) {
        case 1: { // VS
            UH0 * v3 = v1->case1.v0;
            (v0)->refc++; (v3)->refc += 2;
            UHDecref0(v1);
            UH0 * v4 = v0->fptr(v0, v3);
            (v0)->decref_fptr(v0); UHDecref0(v3);
            return UH0_VS(v4);
            break;
        }
        default: { // VZ
            (v0)->decref_fptr(v0); UHDecref0(v1);
            return UH0_VZ();
            break;
        }
    }
}
static Fun2 * ClosureCreate2(Fun1 * v0){
    Closure2 * x = malloc(sizeof(Closure2));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref2;
    x->base.fptr = closure2;
    x->v0 = v0;
    return &x->base;
}
static inline void ClosureDecrefBody3(Closure3 * x){
    (x->v0)->decref_fptr(x->v0);
}
static void ClosureDecref3(Fun2 * self){
    Closure3 * x = (Closure3 *) self;
    if (x != NULL && --(x->base.refc) == 0) { ClosureDecrefBody3(x); free(x); }
}
static UH0 * closure3(Fun2 * self, UH0 * v1){
    Closure3 * x = (Closure3 *) self;
    Fun2 * v0 = x->v0;
    (v0)->refc++;
    ClosureDecref3(self);
    switch (v1->tag) {
        case 1: { // VS
            UH0 * v3 = v1->case1.v0;
            (v0)->refc++; (v3)->refc += 2;
            UHDecref0(v1);
            UH0 * v4 = v0->fptr(v0, v3);
            (v0)->decref_fptr(v0); UHDecref0(v3);
            return UH0_VS(v4);
            break;
        }
        default: { // VZ
            (v0)->decref_fptr(v0); UHDecref0(v1);
            return UH0_VZ();
            break;
        }
    }
}
static Fun2 * ClosureCreate3(Fun2 * v0){
    Closure3 * x = malloc(sizeof(Closure3));
    x->base.refc = 1;
    x->base.decref_fptr = ClosureDecref3;
    x->base.fptr = closure3;
    x->v0 = v0;
    return &x->base;
}
static UH1 * rename4(Fun2 * v0, UH1 * v1);
static UH1 * rename5(Fun2 * v0, UH1 * v1){
    switch (v1->tag) {
        case 2: { // App
            UH1 * v9 = v1->case2.v0; UH1 * v10 = v1->case2.v1;
            (v0)->refc++; (v9)->refc += 2; (v10)->refc++;
            UHDecref1(v1);
            UH1 * v11 = rename5(v0, v9);
            (v0)->refc++; (v10)->refc++;
            UHDecref1(v9);
            UH1 * v12 = rename5(v0, v10);
            (v0)->decref_fptr(v0); UHDecref1(v10);
            return UH1_App(v11, v12);
            break;
        }
        case 1: { // Lam
            UH1 * v5 = v1->case1.v0;
            (v0)->refc++; (v5)->refc++;
            UHDecref1(v1);
            Fun2 * v6 = ClosureCreate3(v0);
            (v5)->refc++; (v6)->refc++;
            (v0)->decref_fptr(v0);
            UH1 * v7 = rename4(v6, v5);
            UHDecref1(v5); (v6)->decref_fptr(v6);
            return UH1_Lam(v7);
            break;
        }
        default: { // Var
            UH0 * v2 = v1->case0.v0;
            (v0)->refc++; (v2)->refc += 2;
            UHDecref1(v1);
            UH0 * v3 = v0->fptr(v0, v2);
            (v0)->decref_fptr(v0); UHDecref0(v2);
            return UH1_Var(v3);
            break;
        }
    }
}
static UH1 * rename4(Fun2 * v0, UH1 * v1){
    switch (v1->tag) {
        case 2: { // App
            UH1 * v9 = v1->case2.v0; UH1 * v10 = v1->case2.v1;
            (v0)->refc++; (v9)->refc += 2; (v10)->refc++;
            UHDecref1(v1);
            UH1 * v11 = rename5(v0, v9);
            (v0)->refc++; (v10)->refc++;
            UHDecref1(v9);
            UH1 * v12 = rename5(v0, v10);
            (v0)->decref_fptr(v0); UHDecref1(v10);
            return UH1_App(v11, v12);
            break;
        }
        case 1: { // Lam
            UH1 * v5 = v1->case1.v0;
            (v0)->refc++; (v5)->refc++;
            UHDecref1(v1);
            Fun2 * v6 = ClosureCreate3(v0);
            (v5)->refc++; (v6)->refc++;
            (v0)->decref_fptr(v0);
            UH1 * v7 = rename4(v6, v5);
            UHDecref1(v5); (v6)->decref_fptr(v6);
            return UH1_Lam(v7);
            break;
        }
        default: { // Var
            UH0 * v2 = v1->case0.v0;
            (v0)->refc++; (v2)->refc += 2;
            UHDecref1(v1);
            UH0 * v3 = v0->fptr(v0, v2);
            (v0)->decref_fptr(v0); UHDecref0(v2);
            return UH1_Var(v3);
            break;
        }
    }
}
static UH1 * rename3(Fun1 * v0, UH1 * v1){
    switch (v1->tag) {
        case 2: { // App
            UH1 * v9 = v1->case2.v0; UH1 * v10 = v1->case2.v1;
            (v0)->refc++; (v9)->refc += 2; (v10)->refc++;
            UHDecref1(v1);
            UH1 * v11 = rename3(v0, v9);
            (v0)->refc++; (v10)->refc++;
            UHDecref1(v9);
            UH1 * v12 = rename3(v0, v10);
            (v0)->decref_fptr(v0); UHDecref1(v10);
            return UH1_App(v11, v12);
            break;
        }
        case 1: { // Lam
            UH1 * v5 = v1->case1.v0;
            (v0)->refc++; (v5)->refc++;
            UHDecref1(v1);
            Fun2 * v6 = ClosureCreate2(v0);
            (v5)->refc++; (v6)->refc++;
            (v0)->decref_fptr(v0);
            UH1 * v7 = rename4(v6, v5);
            UHDecref1(v5); (v6)->decref_fptr(v6);
            return UH1_Lam(v7);
            break;
        }
        default: { // Var
            UH0 * v2 = v1->case0.v0;
            (v0)->refc++; (v2)->refc += 2;
            UHDecref1(v1);
            UH0 * v3 = v0->fptr(v0, v2);
            (v0)->decref_fptr(v0); UHDecref0(v2);
            return UH1_Var(v3);
            break;
        }
    }
}
static UH1 * rename2(Fun1 * v0, UH1 * v1){
    switch (v1->tag) {
        case 2: { // App
            UH1 * v9 = v1->case2.v0; UH1 * v10 = v1->case2.v1;
            (v0)->refc++; (v9)->refc += 2; (v10)->refc++;
            UHDecref1(v1);
            UH1 * v11 = rename3(v0, v9);
            (v0)->refc++; (v10)->refc++;
            UHDecref1(v9);
            UH1 * v12 = rename3(v0, v10);
            (v0)->decref_fptr(v0); UHDecref1(v10);
            return UH1_App(v11, v12);
            break;
        }
        case 1: { // Lam
            UH1 * v5 = v1->case1.v0;
            (v0)->refc++; (v5)->refc++;
            UHDecref1(v1);
            Fun2 * v6 = ClosureCreate2(v0);
            (v5)->refc++; (v6)->refc++;
            (v0)->decref_fptr(v0);
            UH1 * v7 = rename4(v6, v5);
            UHDecref1(v5); (v6)->decref_fptr(v6);
            return UH1_Lam(v7);
            break;
        }
        default: { // Var
            UH0 * v2 = v1->case0.v0;
            (v0)->refc++; (v2)->refc += 2;
            UHDecref1(v1);
            UH0 * v3 = v0->fptr(v0, v2);
            (v0)->decref_fptr(v0); UHDecref0(v2);
            return UH1_Var(v3);
            break;
        }
    }
}
static UH1 * rename1(Fun0 * v0, UH1 * v1){
    switch (v1->tag) {
        case 2: { // App
            UH1 * v9 = v1->case2.v0; UH1 * v10 = v1->case2.v1;
            (v0)->refc++; (v9)->refc += 2; (v10)->refc++;
            UHDecref1(v1);
            UH1 * v11 = rename1(v0, v9);
            (v0)->refc++; (v10)->refc++;
            UHDecref1(v9);
            UH1 * v12 = rename1(v0, v10);
            (v0)->decref_fptr(v0); UHDecref1(v10);
            return UH1_App(v11, v12);
            break;
        }
        case 1: { // Lam
            UH1 * v5 = v1->case1.v0;
            (v0)->refc++; (v5)->refc++;
            UHDecref1(v1);
            Fun1 * v6 = ClosureCreate1(v0);
            (v5)->refc++; (v6)->refc++;
            (v0)->decref_fptr(v0);
            UH1 * v7 = rename2(v6, v5);
            UHDecref1(v5); (v6)->decref_fptr(v6);
            return UH1_Lam(v7);
            break;
        }
        default: { // Var
            UH0 * v2 = v1->case0.v0;
            (v0)->refc++; (v2)->refc += 2;
            UHDecref1(v1);
            UH0 * v3 = v0->fptr(v0, v2);
            (v0)->decref_fptr(v0); UHDecref0(v2);
            return UH1_Var(v3);
            break;
        }
    }
}
static UH1 * rename0(Fun0 * v0, UH1 * v1){
    switch (v1->tag) {
        case 2: { // App
            UH1 * v9 = v1->case2.v0; UH1 * v10 = v1->case2.v1;
            (v0)->refc++; (v9)->refc += 2; (v10)->refc++;
            UHDecref1(v1);
            UH1 * v11 = rename1(v0, v9);
            (v0)->refc++; (v10)->refc++;
            UHDecref1(v9);
            UH1 * v12 = rename1(v0, v10);
            (v0)->decref_fptr(v0); UHDecref1(v10);
            return UH1_App(v11, v12);
            break;
        }
        case 1: { // Lam
            UH1 * v5 = v1->case1.v0;
            (v0)->refc++; (v5)->refc++;
            UHDecref1(v1);
            Fun1 * v6 = ClosureCreate1(v0);
            (v5)->refc++; (v6)->refc++;
            (v0)->decref_fptr(v0);
            UH1 * v7 = rename2(v6, v5);
            UHDecref1(v5); (v6)->decref_fptr(v6);
            return UH1_Lam(v7);
            break;
        }
        default: { // Var
            UH0 * v2 = v1->case0.v0;
            (v0)->refc++; (v2)->refc += 2;
            UHDecref1(v1);
            UH0 * v3 = v0->fptr(v0, v2);
            (v0)->decref_fptr(v0); UHDecref0(v2);
            return UH1_Var(v3);
            break;
        }
    }
}
static int32_t size8(UH1 * v0);
static int32_t size9(UH1 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH1 * v5 = v0->case2.v0; UH1 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref1(v0);
            int32_t v7 = size9(v5);
            UHDecref1(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size9(v6);
            UHDecref1(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH1 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref1(v0);
            int32_t v3 = size8(v2);
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
static int32_t size8(UH1 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH1 * v5 = v0->case2.v0; UH1 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref1(v0);
            int32_t v7 = size9(v5);
            UHDecref1(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size9(v6);
            UHDecref1(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH1 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref1(v0);
            int32_t v3 = size8(v2);
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
static int32_t size7(UH1 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH1 * v5 = v0->case2.v0; UH1 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref1(v0);
            int32_t v7 = size7(v5);
            UHDecref1(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size7(v6);
            UHDecref1(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH1 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref1(v0);
            int32_t v3 = size8(v2);
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
static int32_t size6(UH1 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH1 * v5 = v0->case2.v0; UH1 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref1(v0);
            int32_t v7 = size7(v5);
            UHDecref1(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size7(v6);
            UHDecref1(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH1 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref1(v0);
            int32_t v3 = size8(v2);
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
    Fun0 * v8 = ClosureCreate0();
    (v7)->refc++; (v8)->refc++;
    UH1 * v9 = rename0(v8, v7);
    UHDecref1(v7); (v8)->decref_fptr(v8);
    return size6(v9);
}
