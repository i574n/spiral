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
    int tag;
    union {
        struct {
            String * v0;
        } case1; // Just
    };
} US0;
typedef struct {
    String * v0;
    US0 v1;
    bool v2;
} Tuple0;
typedef struct {
    int refc;
    uint32_t len;
    Tuple0 ptr[];
} Array0;
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
            StringDecref(x->case1.v0);
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_Nothing() { // Nothing
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Just(String * v0) { // Just
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline Tuple0 TupleCreate0(String * v0, US0 v1, bool v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
static inline void ArrayDecrefBody0(Array0 * x){
    uint32_t len = x->len;
    Tuple0 * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        Tuple0 v = ptr[i];
        StringDecref(v.v0); USDecref0(&(v.v1));
    }
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(Tuple0) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, Tuple0 * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(Tuple0) * len);
        for (uint32_t i=0; i < len; i++){
            Tuple0 v = ptr[i];
            (v.v0)->refc++; USIncref0(&(v.v1));
        }
    return x;
}
static inline void AssignArray0(Tuple0 * a, Tuple0 b){
    (b.v0)->refc++; USIncref0(&(b.v1));
    StringDecref(a->v0); USDecref0(&(a->v1));
    *a = b;
}
int32_t main(){
    int32_t v0 = 2l;
    Array0 * v1 = ArrayCreate0(v0, true);
    String * v2 = StringLit(2, "a");
    String * v3 = StringLit(2, "x");
    (v3)->refc++;
    US0 v4 = US0_Just(v3);
    StringDecref(v3);
    AssignArray0(&(v1->ptr[0l]), TupleCreate0(v2, v4, true));
    StringDecref(v2); USDecref0(&(v4));
    String * v5 = StringLit(2, "b");
    US0 v6 = US0_Nothing();
    AssignArray0(&(v1->ptr[1l]), TupleCreate0(v5, v6, false));
    StringDecref(v5); USDecref0(&(v6));
    String * v7; US0 v8; bool v9;
    Tuple0 tmp0 = v1->ptr[0l];
    v7 = tmp0.v0; v8 = tmp0.v1; v9 = tmp0.v2;
    USIncref0(&(v8));
    ArrayDecref0(v1);
    switch (v8.tag) {
        case 1: { // Just
            String * v10 = v8.case1.v0;
            (v10)->refc++;
            USDecref0(&(v8));
            bool v11 = strcmp(v10->ptr, "x") == 0;
            StringDecref(v10);
            if (v11){
                return 7l;
            } else {
                return 1l;
            }
            break;
        }
        default: { // Nothing
            USDecref0(&(v8));
            return 2l;
            break;
        }
    }
}
