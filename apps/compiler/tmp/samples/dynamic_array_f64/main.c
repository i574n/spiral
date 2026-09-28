#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    double ptr[];
} Array0;
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(double) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, double * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(double) * len);
    return x;
}
static inline void AssignArray0(double * a, double b){
    *a = b;
}
int32_t main(){
    int32_t v0;
    v0 = 2l;
    Array0 * v1;
    v1 = ArrayCreate0(v0, false);
    AssignArray0(&(v1->ptr[0l]), 1.5);
    AssignArray0(&(v1->ptr[1l]), 2.5);
    int32_t v2;
    v2 = 1l;
    double v3;
    v3 = v1->ptr[v2];
    ArrayDecref0(v1);
    bool v4;
    v4 = v3 >= 2.0;
    if (v4){
        return 0l;
    } else {
        return 1l;
    }
}
