#include <stdbool.h>
#include <stdint.h>
#include <stdlib.h>
#include <string.h>

typedef struct { int refc; uint32_t len; int32_t ptr[]; } Array0;
static inline void ArrayDecrefBody0(Array0 * x){ (void)x; }
void ArrayDecref0(Array0 * x){ if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); } }
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){ uint32_t size = sizeof(Array0) + sizeof(int32_t) * len; Array0 * x = malloc(size); if (init_at_zero) { memset(x,0,size); } x->refc = 1; x->len = len; return x; }
static inline void AssignArray0(int32_t * a, int32_t b){ *a = b; }

typedef struct { int refc; uint32_t len; bool ptr[]; } Array1;
static inline void ArrayDecrefBody1(Array1 * x){ (void)x; }
void ArrayDecref1(Array1 * x){ if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); } }
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){ uint32_t size = sizeof(Array1) + sizeof(bool) * len; Array1 * x = malloc(size); if (init_at_zero) { memset(x,0,size); } x->refc = 1; x->len = len; return x; }
static inline void AssignArray1(bool * a, bool b){ *a = b; }

int32_t first0(int32_t index){
    Array0 * v0;
    v0 = ArrayCreate0(2l, false);
    AssignArray0(&(v0->ptr[0l]), 40l);
    AssignArray0(&(v0->ptr[1l]), 10l);
    int32_t result = v0->ptr[index];
    ArrayDecref0(v0);
    return result;
}

int32_t second0(int32_t index){
    Array1 * v1;
    v1 = ArrayCreate1(2l, false);
    AssignArray1(&(v1->ptr[0l]), false);
    AssignArray1(&(v1->ptr[1l]), true);
    int32_t result = v1->ptr[index] ? 2l : 0l;
    ArrayDecref1(v1);
    return result;
}

int32_t main(){ return first0(0l) + second0(1l); }
