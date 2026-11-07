#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(int32_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, int32_t * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    return x;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    *a = b;
}
int32_t main(){
    int32_t v0 = 4l;
    Array0 * v1 = ArrayCreate0(v0, true);
    AssignArray0(&(v1->ptr[0l]), 10l);
    AssignArray0(&(v1->ptr[1l]), 20l);
    AssignArray0(&(v1->ptr[2l]), 30l);
    int32_t v2 = v1->ptr[0l];
    int32_t v3 = v1->ptr[1l];
    int32_t v4 = v2 + v3;
    AssignArray0(&(v1->ptr[3l]), v4);
    int32_t v5 = v1->ptr[2l];
    int32_t v6 = v1->ptr[3l];
    int32_t v7 = v5 + v6;
    int32_t v8 = v1->len;
    ArrayDecref0(v1);
    bool v9 = v8 == v0;
    bool v11;
    if (v9){
        bool v10 = v7 == 60l;
        v11 = v10;
    } else {
        v11 = false;
    }
    if (v11){
        return 0l;
    } else {
        return 1l;
    }
}
