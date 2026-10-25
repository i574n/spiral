#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int32_t v0;
    bool v1;
} Tuple0;
typedef struct {
    int refc;
    uint32_t len;
    Tuple0 ptr[];
} Array0;
static inline Tuple0 TupleCreate0(int32_t v0, bool v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
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
    return x;
}
static inline void AssignArray0(Tuple0 * a, Tuple0 b){
    *a = b;
}
int32_t main(){
    int32_t v0 = 3l;
    Array0 * v1 = ArrayCreate0(v0, true);
    int32_t v2 = 4l;
    AssignArray0(&(v1->ptr[0l]), TupleCreate0(v2, true));
    AssignArray0(&(v1->ptr[1l]), TupleCreate0(7l, false));
    AssignArray0(&(v1->ptr[2l]), TupleCreate0(9l, true));
    int32_t v3; bool v4;
    Tuple0 tmp0 = v1->ptr[0l];
    v3 = tmp0.v0; v4 = tmp0.v1;
    int32_t v5; bool v6;
    Tuple0 tmp1 = v1->ptr[1l];
    v5 = tmp1.v0; v6 = tmp1.v1;
    int32_t v7 = 2l;
    int32_t v8; bool v9;
    Tuple0 tmp2 = v1->ptr[v7];
    v8 = tmp2.v0; v9 = tmp2.v1;
    ArrayDecref0(v1);
    int32_t v10;
    if (v4){
        v10 = 1l;
    } else {
        v10 = 0l;
    }
    int32_t v11;
    if (v6){
        v11 = 10l;
    } else {
        v11 = 0l;
    }
    int32_t v12;
    if (v9){
        v12 = 100l;
    } else {
        v12 = 0l;
    }
    int32_t v13 = v3 + v5;
    int32_t v14 = v13 + v8;
    int32_t v15 = v14 + v10;
    int32_t v16 = v15 + v11;
    int32_t v17 = v16 + v12;
    return v17;
}
