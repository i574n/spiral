#include <stdbool.h>
#include <stdint.h>
#include <stdlib.h>
#include <string.h>

typedef struct {
    int refc;
    uint32_t len;
    int64_t ptr[];
} Array0;

static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(int64_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static inline void AssignArray0(int64_t * a, int64_t b){
    *a = b;
}

typedef struct {
    int refc;
    uint32_t len;
    double ptr[];
} Array1;

static inline void ArrayDecrefBody1(Array1 * x){
    (void)x;
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(double) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static inline void AssignArray1(double * a, double b){
    *a = b;
}

int32_t method0(int32_t integerWriteIndex, int32_t floatWriteIndex, int32_t integerReadIndex, int32_t floatReadIndex, int64_t integerBias, double floatBias){
    Array0 * v0;
    v0 = ArrayCreate0(2l, false);
    AssignArray0(&(v0->ptr[0l]), 10ll);
    AssignArray0(&(v0->ptr[1l]), 20ll);
    Array1 * v1;
    v1 = ArrayCreate1(2l, false);
    AssignArray1(&(v1->ptr[0l]), 1.5);
    AssignArray1(&(v1->ptr[1l]), 2.5);
    if (integerWriteIndex == 0l || integerWriteIndex == 1l) {
        AssignArray0(&(v0->ptr[integerWriteIndex]), v0->ptr[integerReadIndex] + integerBias);
    } else {
        ArrayDecref1(v1);
        ArrayDecref0(v0);
        return -1l;
    }
    if (floatWriteIndex == 0l || floatWriteIndex == 1l) {
        AssignArray1(&(v1->ptr[floatWriteIndex]), v1->ptr[floatReadIndex] + floatBias);
    } else {
        ArrayDecref1(v1);
        ArrayDecref0(v0);
        return -2l;
    }
    int32_t v2;
    if (v0->ptr[integerReadIndex] == 40ll && v1->ptr[floatWriteIndex] == 4.0) {
        v2 = 42l;
    } else {
        v2 = -3l;
    }
    ArrayDecref1(v1);
    ArrayDecref0(v0);
    return v2;
}

int32_t main(){
    return method0(0l, 1l, 0l, 0l, 30ll, 2.5);
}
