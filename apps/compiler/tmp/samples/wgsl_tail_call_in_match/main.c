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
        } case0; // Done
        struct {
            int32_t v0;
        } case1; // More
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
US0 US0_Done(int32_t v0) { // Done
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_More(int32_t v0) { // More
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static int32_t layers0(int32_t v0){
    while (1) {
        bool v1 = v0 >= 5l;
        US0 v4;
        if (v1){
            v4 = US0_Done(v0);
        } else {
            v4 = US0_More(v0);
        }
        switch (v4.tag) {
            case 0: { // Done
                int32_t v8 = v4.case0.v0;
                int32_t v9 = v8 * 2l;
                return v9;
                break;
            }
            default: { // More
                int32_t v5 = v4.case1.v0;
                int32_t v6 = v5 + 1l;
                {
                    int32_t tmp0 = v6;
                    v0 = tmp0;
                }
                continue;
                break;
            }
        }
    }
}
int32_t main(){
    int32_t v0 = 0l;
    return layers0(v0);
}
