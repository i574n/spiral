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
    String * v1;
    int32_t v0;
} Tuple0;
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
static inline Tuple0 TupleCreate0(int32_t v0, String * v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static Tuple0 method0(int32_t v0, String * v1){
    bool v2 = v0 == 0l;
    if (v2){
        StringDecref(v1);
        String * v3 = StringLit(3, "no");
        return TupleCreate0(0l, v3);
    } else {
        return TupleCreate0(v0, v1);
    }
}
int32_t main(){
    int32_t v0 = 7l;
    String * v1 = StringLit(3, "hi");
    (v1)->refc++;
    int32_t v2; String * v3;
    Tuple0 tmp0 = method0(v0, v1);
    v2 = tmp0.v0; v3 = tmp0.v1;
    StringDecref(v1);
    bool v4 = v2 == 7l;
    bool v6;
    if (v4){
        bool v5 = strcmp(v3->ptr, "hi") == 0;
        v6 = v5;
    } else {
        v6 = false;
    }
    StringDecref(v3);
    if (v6){
        return 0l;
    } else {
        return 1l;
    }
}
