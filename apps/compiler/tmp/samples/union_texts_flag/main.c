#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array1;
typedef Array1 String;
typedef struct {
    int refc;
    uint32_t len;
    String * ptr[];
} Array0;
typedef struct {
    int tag;
    union {
        struct {
            Array0 * v0;
            bool v1;
        } case1; // Held
    };
} US0;
static inline void ArrayDecrefBody1(Array1 * x){
    (void)x;
}
static void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
static Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(char) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array1 * ArrayLit1(uint32_t len, char * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref1(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit1(len, ptr);
}
static inline void ArrayDecrefBody0(Array0 * x){
    uint32_t len = x->len;
    String * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        String * v = ptr[i];
        StringDecref(v);
    }
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(String *) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, String * * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(String *) * len);
        for (uint32_t i=0; i < len; i++){
            String * v = ptr[i];
            (v)->refc++;
        }
    return x;
}
static inline void AssignArray0(String * * a, String * b){
    (b)->refc++;
    StringDecref(*a);
    *a = b;
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            (x->case1.v0)->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 1: {
            ArrayDecref0(x->case1.v0);
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
US0 US0_Held(Array0 * v0, bool v1) { // Held
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
static int32_t score0(US0 v0){
    switch (v0.tag) {
        case 1: { // Held
            Array0 * v1 = v0.case1.v0; bool v2 = v0.case1.v1;
            (v1)->refc++;
            USDecref0(&(v0));
            String * v3 = v1->ptr[0l];
            (v3)->refc++;
            ArrayDecref0(v1);
            bool v4 = strcmp(v3->ptr, "hi") == 0;
            StringDecref(v3);
            bool v5 = v4 && v2;
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
    Array0 * v0 = ArrayCreate0(1l, true);
    String * v1 = StringLit(3, "hi");
    AssignArray0(&(v0->ptr[0l]), v1);
    StringDecref(v1);
    bool v2 = true;
    US0 v5;
    if (v2){
        (v0)->refc++;
        v5 = US0_Held(v0, v2);
    } else {
        v5 = US0_None();
    }
    ArrayDecref0(v0);
    return score0(v5);
}
