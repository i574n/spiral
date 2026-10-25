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
        } case1; // Some
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
US0 US0_None() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Some(int32_t v0) { // Some
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static US0 method0(int32_t v0){
    bool v1 = v0 == 0l;
    if (v1){
        return US0_None();
    } else {
        return US0_Some(v0);
    }
}
int32_t main(){
    int32_t v0 = 7l;
    US0 v1 = method0(v0);
    switch (v1.tag) {
        case 0: { // None
            return 1l;
            break;
        }
        default: { // Some
            int32_t v2 = v1.case1.v0;
            bool v3 = v2 == 7l;
            if (v3){
                return 0l;
            } else {
                return 1l;
            }
            break;
        }
    }
}
