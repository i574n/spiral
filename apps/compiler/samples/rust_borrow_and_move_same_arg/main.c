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
static String * pick0(String * v0, String * v1){
    int32_t v2 = v0->len-1;
    bool v3 = v2 > 2l;
    if (v3){
        return v1;
    } else {
        StringDecref(v1);
        String * v4 = StringLit(1, "");
        return v4;
    }
}
int32_t main(){
    String * v0 = StringLit(4, "abc");
    (v0)->refc++;
    String * v1 = pick0(v0, v0);
    StringDecref(v0);
    int32_t v2 = v1->len-1;
    StringDecref(v1);
    int32_t v3 = v2 - 3l;
    return v3;
}
