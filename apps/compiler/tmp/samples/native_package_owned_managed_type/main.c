#include <stdbool.h>
#include <stdint.h>
#include <stdlib.h>
#include <string.h>

typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;

typedef struct {
    String * v0;
    int32_t v1;
} Tuple0;

static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    ArrayDecref0(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
static inline Tuple0 TupleCreate0(String * v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0;
    x.v1 = v1;
    return x;
}
int32_t method0(Tuple0 v0){
    String * v1;
    v1 = v0.v0;
    int32_t v2;
    v2 = v1->len - 1;
    int32_t v3;
    v3 = v2 + v0.v1;
    StringDecref(v1);
    return v3;
}
int32_t main(){
    String * v0;
    v0 = StringLit(4u, "abc");
    v0->refc++;
    Tuple0 v1;
    v1 = TupleCreate0(v0, 39l);
    StringDecref(v0);
    return method0(v1);
}
