#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
        struct {
            int8_t v0;
        } case1; // Held
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
US0 US0_Missing() { // Missing
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Held(int8_t v0) { // Held
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t main(){
    int8_t v0 = 100;
    bool v1 = true;
    US0 v4;
    if (v1){
        v4 = US0_Held(v0);
    } else {
        v4 = US0_Missing();
    }
    switch (v4.tag) {
        case 1: { // Held
            int8_t v5 = v4.case1.v0;
            bool v6 = v5 == 100;
            if (v6){
                return 0l;
            } else {
                return 1l;
            }
            break;
        }
        default: { // Missing
            return 1l;
            break;
        }
    }
}
