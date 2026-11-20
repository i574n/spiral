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
int32_t main(){
    String * v0 = StringLit(6, "hello");
    printf("%s\n", (v0)->ptr);
    StringDecref(v0);
    int32_t v1 = 42l;
    printf("%d\n", v1);
    String * v2 = StringLit(2, "a");
    printf("%s", (v2)->ptr);
    StringDecref(v2);
    String * v3 = StringLit(2, "b");
    printf("%s", (v3)->ptr);
    StringDecref(v3);
    String * v4 = StringLit(1, "");
    printf("%s\n", (v4)->ptr);
    StringDecref(v4);
    int64_t v5 = -7ll;
    printf("%lld\n", (long long)(v5));
    return 0l;
}
