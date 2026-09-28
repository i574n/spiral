#include <stdbool.h>
#include <stdint.h>
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

typedef struct {
    int refc;
    uint32_t len;
    bool ptr[];
} Array1;

static inline void ArrayDecrefBody1(Array1 * x){
    (void)x;
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(bool) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static inline void AssignArray1(bool * a, bool b){
    *a = b;
}

int32_t method0(int32_t valueWriteIndex, int32_t flagWriteIndex, int32_t valueReadIndex, int32_t flagReadIndex){
    Array0 * v0;
    v0 = ArrayCreate0(2l, false);
    AssignArray0(&(v0->ptr[0l]), 10l);
    AssignArray0(&(v0->ptr[1l]), 20l);
    Array1 * v1;
    v1 = ArrayCreate1(2l, false);
    AssignArray1(&(v1->ptr[0l]), false);
    AssignArray1(&(v1->ptr[1l]), false);
    if (valueWriteIndex == 0l || valueWriteIndex == 2l) {
        AssignArray0(&(v0->ptr[valueWriteIndex]), 40l);
    } else {
        ArrayDecref1(v1);
        ArrayDecref0(v0);
        return -1l;
    }
    if (flagWriteIndex == 0l || flagWriteIndex == 1l) {
        AssignArray1(&(v1->ptr[flagWriteIndex]), true);
    } else {
        ArrayDecref1(v1);
        ArrayDecref0(v0);
        return -2l;
    }
    int32_t v2;
    if (v1->ptr[flagReadIndex]) {
        v2 = v0->ptr[valueReadIndex] + 2l;
    } else {
        v2 = v0->ptr[valueReadIndex];
    }
    ArrayDecref1(v1);
    ArrayDecref0(v0);
    return v2;
}

int32_t main(){
    return method0(0l, 1l, 0l, 1l);
}
