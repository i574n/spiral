#include <stdbool.h>
#include <stdint.h>
#include <stdlib.h>
#include <string.h>

typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;

typedef struct {
    Array0 * v0;
    int32_t v1;
} Tuple0;

static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(int32_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    *a = b;
}
static inline Tuple0 TupleCreate0(Array0 * v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0;
    x.v1 = v1;
    return x;
}
int32_t method0(Tuple0 v0){
    Array0 * v1;
    v1 = v0.v0;
    int32_t v2;
    v2 = v0.v1 + 3l;
    ArrayDecref0(v1);
    return v2;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayCreate0(1u, false);
    AssignArray0(&(v0->ptr[0l]), 7l);
    int32_t v2;
    v2 = DynamicArrayRefCount0(v0);
    v0->refc++;
    Tuple0 v1;
    v1 = TupleCreate0(v0, 38l + v2);
    ArrayDecref0(v0);
    return method0(v1);
}
