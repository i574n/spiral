#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct {
    int tag;
    union {
        struct {
            int64_t v0;
            String * v1;
        } case1; // Both
    };
} US0;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref0(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v1)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            StringDecref(x->case1.v1);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_None() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Both(int64_t v0, String * v1) { // Both
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static int32_t score0(US0 v0){
    switch (v0.tag) {
        case 1: { // Both
            int64_t v1 = v0.case1.v0; String * v2 = v0.case1.v1;
            (v2)->refc++;
            USDecref0(&(v0));
            bool v3 = v1 == 5000000000ll;
            bool v5;
            if (v3){
                bool v4 = strcmp(v2->ptr, "hi") == 0;
                v5 = v4;
            } else {
                v5 = false;
            }
            StringDecref(v2);
            if (v5){
                return 0l;
            } else {
                return 1l;
            }
            break;
        }
        default: { // None
            USDecref0(&(v0));
            return 1l;
            break;
        }
    }
}
int32_t main(){
    int64_t v0 = 5000000000ll;
    String * v1 = StringLit(3, "hi");
    bool v2 = true;
    US0 v5;
    if (v2){
        (v1)->refc++;
        v5 = US0_Both(v0, v1);
    } else {
        v5 = US0_None();
    }
    StringDecref(v1);
    return score0(v5);
}
