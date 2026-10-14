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
Array0 * ArrayLit0(uint32_t len, int32_t * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    return x;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    
    
    *a = b;
}
int32_t loop0(int32_t v0, Array0 * v1, int32_t v2, int32_t v3, int32_t v4){
    while (1) {
        
        
        bool v5;
        v5 = v3 >= v0;
        
        
        if (v5){
            
            ArrayDecref0(v1);
            return v4;
        } else {
            
            
            int32_t v6;
            v6 = v3 % 4l;
            
            
            int32_t v7;
            v7 = v1->ptr[v6];
            
            
            int32_t v8;
            v8 = v3 + 1l;
            
            
            int32_t v9;
            v9 = v4 * 7l;
            
            
            int32_t v10;
            v10 = v9 + v7;
            
            
            int32_t v11;
            v11 = v10 + v2;
            
            
            int32_t v12;
            v12 = v11 % 9973l;
            
            
            {
                int32_t tmp0 = v0;
                Array0 * tmp1 = v1;
                int32_t tmp2 = v2;
                int32_t tmp3 = v8;
                int32_t tmp4 = v12;
                v0 = tmp0;
                v1 = tmp1;
                v2 = tmp2;
                v3 = tmp3;
                v4 = tmp4;
            }
            continue;
        }
    }
}
int32_t main(){
    
    
    Array0 * v0;
    v0 = ArrayCreate0(4l, true);
    
    
    
    AssignArray0(&(v0->ptr[0l]), 1l);
    
    
    
    AssignArray0(&(v0->ptr[1l]), 2l);
    
    
    
    AssignArray0(&(v0->ptr[2l]), 3l);
    
    
    
    AssignArray0(&(v0->ptr[3l]), 4l);
    
    
    int32_t v1;
    v1 = 0l;
    
    
    int32_t v2;
    v2 = 1000000l;
    
    
    int32_t v3;
    v3 = 0l;
    
    
    int32_t v4;
    v4 = 0l;
    (v0)->refc++;
    
    int32_t v5;
    v5 = loop0(v2, v0, v1, v3, v4);
    
    ArrayDecref0(v0);
    int32_t v6;
    v6 = v5 % 256l;
    
    
    return v6;
}
