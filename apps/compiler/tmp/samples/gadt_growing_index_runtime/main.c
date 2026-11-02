#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
static void UHDecref0(UH0 * x);
typedef struct UH3 UH3;
static void UHDecref3(UH3 * x);
typedef struct UH5 UH5;
static void UHDecref5(UH5 * x);
typedef struct UH7 UH7;
static void UHDecref7(UH7 * x);
typedef struct UH9 UH9;
static void UHDecref9(UH9 * x);
typedef struct UH8 UH8;
static void UHDecref8(UH8 * x);
typedef struct UH6 UH6;
static void UHDecref6(UH6 * x);
typedef struct UH4 UH4;
static void UHDecref4(UH4 * x);
typedef struct UH2 UH2;
static void UHDecref2(UH2 * x);
typedef struct UH1 UH1;
static void UHDecref1(UH1 * x);
typedef struct UH10 UH10;
static void UHDecref10(UH10 * x);
struct UH0 {
    int refc;
    int tag;
    union {
    };
};
struct UH3 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v0;
        } case1; // VS
    };
};
struct UH5 {
    int refc;
    int tag;
    union {
        struct {
            UH3 * v0;
        } case1; // VS
    };
};
struct UH7 {
    int refc;
    int tag;
    union {
        struct {
            UH5 * v0;
        } case1; // VS
    };
};
struct UH9 {
    int refc;
    int tag;
    union {
        struct {
            UH9 * v0;
        } case1; // VS
    };
};
struct UH8 {
    int refc;
    int tag;
    union {
        struct {
            UH9 * v0;
        } case0; // Var
        struct {
            UH8 * v0;
        } case1; // Lam
        struct {
            UH8 * v0;
            UH8 * v1;
        } case2; // App
    };
};
struct UH6 {
    int refc;
    int tag;
    union {
        struct {
            UH7 * v0;
        } case0; // Var
        struct {
            UH8 * v0;
        } case1; // Lam
        struct {
            UH6 * v0;
            UH6 * v1;
        } case2; // App
    };
};
struct UH4 {
    int refc;
    int tag;
    union {
        struct {
            UH5 * v0;
        } case0; // Var
        struct {
            UH6 * v0;
        } case1; // Lam
        struct {
            UH4 * v0;
            UH4 * v1;
        } case2; // App
    };
};
struct UH2 {
    int refc;
    int tag;
    union {
        struct {
            UH3 * v0;
        } case0; // Var
        struct {
            UH4 * v0;
        } case1; // Lam
        struct {
            UH2 * v0;
            UH2 * v1;
        } case2; // App
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
            UH2 * v0;
        } case1; // Lam
        struct {
            UH1 * v0;
            UH1 * v1;
        } case2; // App
    };
};
struct UH10 {
    int refc;
    int tag;
    union {
        struct {
            UH1 * v0;
        } case1; // Lam
        struct {
            UH10 * v0;
            UH10 * v1;
        } case2; // App
    };
};
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
    }
}
static void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_VZ() { // VZ
    static UH0 x = { .refc = 1073741823, .tag = 0 };
    return &x;
}
static inline void UHDecrefBody3(UH3 * x){
    switch (x->tag) {
        case 1: {
            UHDecref0(x->case1.v0);
            break;
        }
    }
}
static void UHDecref3(UH3 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody3(x); free(x); }
}
UH3 * UH3_VZ() { // VZ
    static UH3 x = { .refc = 1073741823, .tag = 0 };
    return &x;
}
UH3 * UH3_VS(UH0 * v0) { // VS
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
static inline void UHDecrefBody5(UH5 * x){
    switch (x->tag) {
        case 1: {
            UHDecref3(x->case1.v0);
            break;
        }
    }
}
static void UHDecref5(UH5 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody5(x); free(x); }
}
UH5 * UH5_VZ() { // VZ
    static UH5 x = { .refc = 1073741823, .tag = 0 };
    return &x;
}
UH5 * UH5_VS(UH3 * v0) { // VS
    UH5 * x = malloc(sizeof(UH5));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
static inline void UHDecrefBody7(UH7 * x){
    switch (x->tag) {
        case 1: {
            UHDecref5(x->case1.v0);
            break;
        }
    }
}
static void UHDecref7(UH7 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody7(x); free(x); }
}
UH7 * UH7_VZ() { // VZ
    static UH7 x = { .refc = 1073741823, .tag = 0 };
    return &x;
}
UH7 * UH7_VS(UH5 * v0) { // VS
    UH7 * x = malloc(sizeof(UH7));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
static inline void UHDecrefBody9(UH9 * x){
    switch (x->tag) {
        case 1: {
            UHDecref9(x->case1.v0);
            break;
        }
    }
}
static void UHDecref9(UH9 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH9 * next = NULL;
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
UH9 * UH9_VZ() { // VZ
    static UH9 x = { .refc = 1073741823, .tag = 0 };
    return &x;
}
UH9 * UH9_VS(UH9 * v0) { // VS
    UH9 * x = malloc(sizeof(UH9));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
static inline void UHDecrefBody8(UH8 * x){
    switch (x->tag) {
        case 0: {
            UHDecref9(x->case0.v0);
            break;
        }
        case 1: {
            UHDecref8(x->case1.v0);
            break;
        }
        case 2: {
            UHDecref8(x->case2.v0); UHDecref8(x->case2.v1);
            break;
        }
    }
}
static void UHDecref8(UH8 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH8 * next = NULL;
        switch (x->tag) {
            case 0: {
                UHDecref9(x->case0.v0);
                break;
            }
            case 1: {
                next = x->case1.v0;
                break;
            }
            case 2: {
                UHDecref8(x->case2.v0);
                next = x->case2.v1;
                break;
            }
        }
        free(x);
        x = next;
    }
}
UH8 * UH8_Var(UH9 * v0) { // Var
    UH8 * x = malloc(sizeof(UH8));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0;
    return x;
}
UH8 * UH8_Lam(UH8 * v0) { // Lam
    UH8 * x = malloc(sizeof(UH8));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
UH8 * UH8_App(UH8 * v0, UH8 * v1) { // App
    UH8 * x = malloc(sizeof(UH8));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0; x->case2.v1 = v1;
    return x;
}
static inline void UHDecrefBody6(UH6 * x){
    switch (x->tag) {
        case 0: {
            UHDecref7(x->case0.v0);
            break;
        }
        case 1: {
            UHDecref8(x->case1.v0);
            break;
        }
        case 2: {
            UHDecref6(x->case2.v0); UHDecref6(x->case2.v1);
            break;
        }
    }
}
static void UHDecref6(UH6 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH6 * next = NULL;
        switch (x->tag) {
            case 0: {
                UHDecref7(x->case0.v0);
                break;
            }
            case 1: {
                UHDecref8(x->case1.v0);
                break;
            }
            case 2: {
                UHDecref6(x->case2.v0);
                next = x->case2.v1;
                break;
            }
        }
        free(x);
        x = next;
    }
}
UH6 * UH6_Var(UH7 * v0) { // Var
    UH6 * x = malloc(sizeof(UH6));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0;
    return x;
}
UH6 * UH6_Lam(UH8 * v0) { // Lam
    UH6 * x = malloc(sizeof(UH6));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
UH6 * UH6_App(UH6 * v0, UH6 * v1) { // App
    UH6 * x = malloc(sizeof(UH6));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0; x->case2.v1 = v1;
    return x;
}
static inline void UHDecrefBody4(UH4 * x){
    switch (x->tag) {
        case 0: {
            UHDecref5(x->case0.v0);
            break;
        }
        case 1: {
            UHDecref6(x->case1.v0);
            break;
        }
        case 2: {
            UHDecref4(x->case2.v0); UHDecref4(x->case2.v1);
            break;
        }
    }
}
static void UHDecref4(UH4 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH4 * next = NULL;
        switch (x->tag) {
            case 0: {
                UHDecref5(x->case0.v0);
                break;
            }
            case 1: {
                UHDecref6(x->case1.v0);
                break;
            }
            case 2: {
                UHDecref4(x->case2.v0);
                next = x->case2.v1;
                break;
            }
        }
        free(x);
        x = next;
    }
}
UH4 * UH4_Var(UH5 * v0) { // Var
    UH4 * x = malloc(sizeof(UH4));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0;
    return x;
}
UH4 * UH4_Lam(UH6 * v0) { // Lam
    UH4 * x = malloc(sizeof(UH4));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
UH4 * UH4_App(UH4 * v0, UH4 * v1) { // App
    UH4 * x = malloc(sizeof(UH4));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0; x->case2.v1 = v1;
    return x;
}
static inline void UHDecrefBody2(UH2 * x){
    switch (x->tag) {
        case 0: {
            UHDecref3(x->case0.v0);
            break;
        }
        case 1: {
            UHDecref4(x->case1.v0);
            break;
        }
        case 2: {
            UHDecref2(x->case2.v0); UHDecref2(x->case2.v1);
            break;
        }
    }
}
static void UHDecref2(UH2 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH2 * next = NULL;
        switch (x->tag) {
            case 0: {
                UHDecref3(x->case0.v0);
                break;
            }
            case 1: {
                UHDecref4(x->case1.v0);
                break;
            }
            case 2: {
                UHDecref2(x->case2.v0);
                next = x->case2.v1;
                break;
            }
        }
        free(x);
        x = next;
    }
}
UH2 * UH2_Var(UH3 * v0) { // Var
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0;
    return x;
}
UH2 * UH2_Lam(UH4 * v0) { // Lam
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
UH2 * UH2_App(UH2 * v0, UH2 * v1) { // App
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0; x->case2.v1 = v1;
    return x;
}
static inline void UHDecrefBody1(UH1 * x){
    switch (x->tag) {
        case 0: {
            UHDecref0(x->case0.v0);
            break;
        }
        case 1: {
            UHDecref2(x->case1.v0);
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
                UHDecref2(x->case1.v0);
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
UH1 * UH1_Lam(UH2 * v0) { // Lam
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
static inline void UHDecrefBody10(UH10 * x){
    switch (x->tag) {
        case 1: {
            UHDecref1(x->case1.v0);
            break;
        }
        case 2: {
            UHDecref10(x->case2.v0); UHDecref10(x->case2.v1);
            break;
        }
    }
}
static void UHDecref10(UH10 * x){
    while (x != NULL && --(x->refc) == 0) {
        UH10 * next = NULL;
        switch (x->tag) {
            case 1: {
                UHDecref1(x->case1.v0);
                break;
            }
            case 2: {
                UHDecref10(x->case2.v0);
                next = x->case2.v1;
                break;
            }
        }
        free(x);
        x = next;
    }
}
UH10 * UH10_Lam(UH1 * v0) { // Lam
    UH10 * x = malloc(sizeof(UH10));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
UH10 * UH10_App(UH10 * v0, UH10 * v1) { // App
    UH10 * x = malloc(sizeof(UH10));
    x->tag = 2;
    x->refc = 1;
    x->case2.v0 = v0; x->case2.v1 = v1;
    return x;
}
static int32_t size6(UH8 * v0);
static int32_t size7(UH8 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH8 * v5 = v0->case2.v0; UH8 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref8(v0);
            int32_t v7 = size6(v5);
            UHDecref8(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size6(v6);
            UHDecref8(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH8 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref8(v0);
            int32_t v3 = size7(v2);
            UHDecref8(v2);
            int32_t v4 = 1l + v3;
            return v4;
            break;
        }
        default: { // Var
            UHDecref8(v0);
            return 1l;
            break;
        }
    }
}
static int32_t size6(UH8 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH8 * v5 = v0->case2.v0; UH8 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref8(v0);
            int32_t v7 = size6(v5);
            UHDecref8(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size6(v6);
            UHDecref8(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH8 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref8(v0);
            int32_t v3 = size7(v2);
            UHDecref8(v2);
            int32_t v4 = 1l + v3;
            return v4;
            break;
        }
        default: { // Var
            UHDecref8(v0);
            return 1l;
            break;
        }
    }
}
static int32_t size5(UH8 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH8 * v5 = v0->case2.v0; UH8 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref8(v0);
            int32_t v7 = size6(v5);
            UHDecref8(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size6(v6);
            UHDecref8(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH8 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref8(v0);
            int32_t v3 = size7(v2);
            UHDecref8(v2);
            int32_t v4 = 1l + v3;
            return v4;
            break;
        }
        default: { // Var
            UHDecref8(v0);
            return 1l;
            break;
        }
    }
}
static int32_t size4(UH6 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH6 * v5 = v0->case2.v0; UH6 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref6(v0);
            int32_t v7 = size4(v5);
            UHDecref6(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size4(v6);
            UHDecref6(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH8 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref6(v0);
            int32_t v3 = size5(v2);
            UHDecref8(v2);
            int32_t v4 = 1l + v3;
            return v4;
            break;
        }
        default: { // Var
            UHDecref6(v0);
            return 1l;
            break;
        }
    }
}
static int32_t size3(UH4 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH4 * v5 = v0->case2.v0; UH4 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref4(v0);
            int32_t v7 = size3(v5);
            UHDecref4(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size3(v6);
            UHDecref4(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH6 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref4(v0);
            int32_t v3 = size4(v2);
            UHDecref6(v2);
            int32_t v4 = 1l + v3;
            return v4;
            break;
        }
        default: { // Var
            UHDecref4(v0);
            return 1l;
            break;
        }
    }
}
static int32_t size2(UH2 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH2 * v5 = v0->case2.v0; UH2 * v6 = v0->case2.v1;
            (v5)->refc += 2; (v6)->refc++;
            UHDecref2(v0);
            int32_t v7 = size2(v5);
            UHDecref2(v5);
            int32_t v8 = 1l + v7;
            (v6)->refc++;
            int32_t v9 = size2(v6);
            UHDecref2(v6);
            int32_t v10 = v8 + v9;
            return v10;
            break;
        }
        case 1: { // Lam
            UH4 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref2(v0);
            int32_t v3 = size3(v2);
            UHDecref4(v2);
            int32_t v4 = 1l + v3;
            return v4;
            break;
        }
        default: { // Var
            UHDecref2(v0);
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
            UH2 * v2 = v0->case1.v0;
            (v2)->refc += 2;
            UHDecref1(v0);
            int32_t v3 = size2(v2);
            UHDecref2(v2);
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
static int32_t size0(UH10 * v0){
    switch (v0->tag) {
        case 2: { // App
            UH10 * v4 = v0->case2.v0; UH10 * v5 = v0->case2.v1;
            (v4)->refc += 2; (v5)->refc++;
            UHDecref10(v0);
            int32_t v6 = size0(v4);
            UHDecref10(v4);
            int32_t v7 = 1l + v6;
            (v5)->refc++;
            int32_t v8 = size0(v5);
            UHDecref10(v5);
            int32_t v9 = v7 + v8;
            return v9;
            break;
        }
        default: { // Lam
            UH1 * v1 = v0->case1.v0;
            (v1)->refc += 2;
            UHDecref10(v0);
            int32_t v2 = size1(v1);
            UHDecref1(v1);
            int32_t v3 = 1l + v2;
            return v3;
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
    UH3 * v3 = UH3_VS(v2);
    (v3)->refc++;
    UHDecref0(v2);
    UH2 * v4 = UH2_Var(v3);
    (v4)->refc++;
    UHDecref3(v3);
    UH1 * v5 = UH1_Lam(v4);
    (v1)->refc++; (v5)->refc++;
    UHDecref2(v4);
    UH1 * v6 = UH1_App(v1, v5);
    (v6)->refc++;
    UHDecref1(v1); UHDecref1(v5);
    UH10 * v7 = UH10_Lam(v6);
    UHDecref1(v6);
    return size0(v7);
}
