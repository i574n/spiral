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
        } case0; // RawA
    };
} US0;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
            bool v1;
        } case1; // DecidedA
    };
} US1;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case1; // RawB
    };
} US2;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v1;
            bool v0;
        } case0; // DecidedB
    };
} US3;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case0; // RawC
    };
} US4;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
            bool v1;
        } case1; // DecidedC
    };
} US5;
typedef struct {
    int tag;
    union {
        struct {
            bool v0;
        } case2; // FinalC
    };
} US6;
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
US0 US0_RawA(int32_t v0) { // RawA
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
static inline void USIncrefBody1(US1 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody1(US1 * x){
    switch (x->tag) {
    }
}
void USIncref1(US1 * x){ USIncrefBody1(x); }
void USDecref1(US1 * x){ USDecrefBody1(x); }
US1 US1_DecidedA(int32_t v0, bool v1) { // DecidedA
    US1 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static US1 decide_a0(US0 v0){
    switch (v0.tag) {
        default: { // RawA
            int32_t v1 = v0.case0.v0;
            return US1_DecidedA(v1, true);
            break;
        }
    }
}
static inline void USIncrefBody2(US2 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody2(US2 * x){
    switch (x->tag) {
    }
}
void USIncref2(US2 * x){ USIncrefBody2(x); }
void USDecref2(US2 * x){ USDecrefBody2(x); }
US2 US2_RawB(int32_t v0) { // RawB
    US2 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline void USIncrefBody3(US3 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody3(US3 * x){
    switch (x->tag) {
    }
}
void USIncref3(US3 * x){ USIncrefBody3(x); }
void USDecref3(US3 * x){ USDecrefBody3(x); }
US3 US3_DecidedB(bool v0, int32_t v1) { // DecidedB
    US3 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1;
    return x;
}
static US3 decide_b1(US2 v0){
    switch (v0.tag) {
        default: { // RawB
            int32_t v1 = v0.case1.v0;
            return US3_DecidedB(true, v1);
            break;
        }
    }
}
static inline void USIncrefBody4(US4 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody4(US4 * x){
    switch (x->tag) {
    }
}
void USIncref4(US4 * x){ USIncrefBody4(x); }
void USDecref4(US4 * x){ USDecrefBody4(x); }
US4 US4_RawC(int32_t v0) { // RawC
    US4 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
static inline void USIncrefBody5(US5 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody5(US5 * x){
    switch (x->tag) {
    }
}
void USIncref5(US5 * x){ USIncrefBody5(x); }
void USDecref5(US5 * x){ USDecrefBody5(x); }
US5 US5_DecidedC(int32_t v0, bool v1) { // DecidedC
    US5 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static US5 decide_c2(US4 v0){
    switch (v0.tag) {
        default: { // RawC
            int32_t v1 = v0.case0.v0;
            return US5_DecidedC(v1, true);
            break;
        }
    }
}
static inline void USIncrefBody6(US6 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody6(US6 * x){
    switch (x->tag) {
    }
}
void USIncref6(US6 * x){ USIncrefBody6(x); }
void USDecref6(US6 * x){ USDecrefBody6(x); }
US6 US6_FinalC(bool v0) { // FinalC
    US6 x;
    x.tag = 2;
    x.case2.v0 = v0;
    return x;
}
static US6 finalize_c3(US5 v0){
    switch (v0.tag) {
        default: { // DecidedC
            bool v2 = v0.case1.v1;
            return US6_FinalC(v2);
            break;
        }
    }
}
int32_t main(){
    int32_t v0 = 7l;
    US0 v1 = US0_RawA(v0);
    US1 v2 = decide_a0(v1);
    int32_t v3 = 9l;
    US2 v4 = US2_RawB(v3);
    US3 v5 = decide_b1(v4);
    int32_t v6 = 11l;
    US4 v7 = US4_RawC(v6);
    US5 v8 = decide_c2(v7);
    US6 v9 = finalize_c3(v8);
    bool v12;
    switch (v2.tag) {
        default: { // DecidedA
            bool v11 = v2.case1.v1;
            v12 = v11;
            break;
        }
    }
    bool v15;
    switch (v5.tag) {
        default: { // DecidedB
            bool v13 = v5.case0.v0;
            v15 = v13;
            break;
        }
    }
    bool v17;
    switch (v9.tag) {
        default: { // FinalC
            bool v16 = v9.case2.v0;
            v17 = v16;
            break;
        }
    }
    bool v18 = v12 && v15;
    bool v19 = v18 && v17;
    if (v19){
        return 0l;
    } else {
        return 1l;
    }
}
