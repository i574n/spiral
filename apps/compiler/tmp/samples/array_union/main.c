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
typedef struct {
    int refc;
    uint32_t len;
    US0 ptr[];
} Array0;
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
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(US0) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, US0 * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(US0) * len);
    return x;
}
static inline void AssignArray0(US0 * a, US0 b){
    *a = b;
}
int32_t main(){
    int32_t v0 = 2l;
    Array0 * v1 = ArrayCreate0(v0, true);
    int32_t v2 = 7l;
    US0 v3 = US0_Some(v2);
    AssignArray0(&(v1->ptr[0l]), v3);
    US0 v4 = US0_None();
    AssignArray0(&(v1->ptr[1l]), v4);
    US0 v5 = v1->ptr[0l];
    switch (v5.tag) {
        case 0: { // None
            ArrayDecref0(v1);
            return 1l;
            break;
        }
        default: { // Some
            int32_t v6 = v5.case1.v0;
            US0 v7 = v1->ptr[1l];
            ArrayDecref0(v1);
            switch (v7.tag) {
                case 0: { // None
                    bool v8 = v6 == 7l;
                    if (v8){
                        return 0l;
                    } else {
                        return 1l;
                    }
                    break;
                }
                default: { // Some
                    return 1l;
                    break;
                }
            }
            break;
        }
    }
}
