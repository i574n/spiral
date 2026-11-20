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
typedef struct {
    int refc;
    uint32_t len;
    bool ptr[];
} Array1;
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
static inline void ArrayDecrefBody1(Array1 * x){
    (void)x;
}
static void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
static Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(bool) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array1 * ArrayLit1(uint32_t len, bool * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(bool) * len);
    return x;
}
static inline void AssignArray1(bool * a, bool b){
    *a = b;
}
int32_t main(){
    int32_t v0 = 5l;
    Array0 * v1 = ArrayCreate0(v0, true);
    AssignArray0(&(v1->ptr[0l]), 0l);
    AssignArray0(&(v1->ptr[1l]), 1l);
    AssignArray0(&(v1->ptr[2l]), 4l);
    int32_t v2 = 3l;
    AssignArray0(&(v1->ptr[v2]), 9l);
    int32_t v3 = v2 + 1l;
    AssignArray0(&(v1->ptr[v3]), 16l);
    Array1 * v4 = ArrayCreate1(3l, true);
    AssignArray1(&(v4->ptr[0l]), false);
    AssignArray1(&(v4->ptr[1l]), true);
    AssignArray1(&(v4->ptr[2l]), false);
    int32_t v5 = v1->ptr[1l];
    int32_t v6 = v1->ptr[2l];
    int32_t v7 = v5 + v6;
    int32_t v8 = v1->ptr[3l];
    int32_t v9 = v7 + v8;
    int32_t v10 = v1->ptr[4l];
    int32_t v11 = v9 + v10;
    bool v12 = v4->ptr[1l];
    int32_t v15;
    if (v12){
        bool v13 = v4->ptr[0l];
        if (v13){
            v15 = 0l;
        } else {
            v15 = 100l;
        }
    } else {
        v15 = 0l;
    }
    ArrayDecref1(v4);
    int32_t v16 = v11 + v15;
    int32_t v17 = v1->len;
    ArrayDecref0(v1);
    int32_t v18 = v16 + v17;
    return v18;
}
