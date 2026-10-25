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
        } case0; // One
        struct {
            int32_t v0;
            int32_t v1;
        } case1; // Both
    };
} US0;
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
US0 US0_One(int32_t v0) { // One
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Both(int32_t v0, int32_t v1) { // Both
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static int32_t sum0(US0 v0){
    switch (v0.tag) {
        case 1: { // Both
            int32_t v2 = v0.case1.v0; int32_t v3 = v0.case1.v1;
            int32_t v4 = v2 * 10l;
            int32_t v5 = v4 + v3;
            return v5;
            break;
        }
        default: { // One
            int32_t v1 = v0.case0.v0;
            return v1;
            break;
        }
    }
}
int32_t main(){
    bool v0 = true;
    US0 v3;
    if (v0){
        v3 = US0_Both(3l, 4l);
    } else {
        v3 = US0_One(1l);
    }
    US0 v6;
    if (v0){
        v6 = US0_One(5l);
    } else {
        v6 = US0_Both(1l, 1l);
    }
    int32_t v7 = sum0(v3);
    bool v8 = v7 == 34l;
    bool v11;
    if (v8){
        int32_t v9 = sum0(v6);
        bool v10 = v9 == 5l;
        v11 = v10;
    } else {
        v11 = false;
    }
    if (v11){
        return 0l;
    } else {
        return 1l;
    }
}
