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
            int32_t v0;
        } case0; // One
        struct {
            String * v1;
            int32_t v0;
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
US0 US0_One(int32_t v0) { // One
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Both(int32_t v0, String * v1) { // Both
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static US0 method0(int32_t v0, String * v1){
    bool v2 = v0 == 0l;
    if (v2){
        StringDecref(v1);
        return US0_One(0l);
    } else {
        return US0_Both(v0, v1);
    }
}
int32_t main(){
    int32_t v0 = 3l;
    String * v1 = StringLit(3, "hi");
    (v1)->refc++;
    US0 v2 = method0(v0, v1);
    StringDecref(v1);
    switch (v2.tag) {
        case 1: { // Both
            int32_t v4 = v2.case1.v0; String * v5 = v2.case1.v1;
            (v5)->refc++;
            USDecref0(&(v2));
            bool v6 = v4 == 3l;
            bool v8;
            if (v6){
                bool v7 = strcmp(v5->ptr, "hi") == 0;
                v8 = v7;
            } else {
                v8 = false;
            }
            StringDecref(v5);
            if (v8){
                return 0l;
            } else {
                return 1l;
            }
            break;
        }
        default: { // One
            USDecref0(&(v2));
            return 1l;
            break;
        }
    }
}
