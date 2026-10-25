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
static void fill0(int32_t v0, Array0 * v1, int32_t v2){
    while (1) {
        bool v3 = v2 < v0;
        if (v3){
            AssignArray0(&(v1->ptr[v2]), v2);
            int32_t v4 = v2 + 1l;
            {
                int32_t tmp0 = v0;
                Array0 * tmp1 = v1;
                int32_t tmp2 = v4;
                v0 = tmp0;
                v1 = tmp1;
                v2 = tmp2;
            }
            continue;
        } else {
            ArrayDecref0(v1);
            return ;
        }
    }
}
int32_t main(){
    int32_t v0 = 6l;
    Array0 * v1 = ArrayCreate0(6l, true);
    int32_t v2 = 0l;
    (v1)->refc++;
    fill0(v0, v1, v2);
    int32_t v3 = v1->ptr[5l];
    ArrayDecref0(v1);
    int32_t v4 = v3 + 2l;
    return v4;
}
