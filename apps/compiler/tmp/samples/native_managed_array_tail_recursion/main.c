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
Array0 * method1(int32_t v0, Array0 * v1, Array0 * v2){
    
    
    int32_t v3;
    v3 = v0 - 1l;
    
    
    bool v4;
    v4 = v3 == 0l;
    
    
    if (v4){
        
        ArrayDecref0(v1);
        return v2;
    } else {
        
        
        return method1(v3, v2, v1);
    }
}
Array0 * method0(Array0 * v0, Array0 * v1){
    
    
    int32_t v2;
    v2 = 1000000l;
    
    
    bool v3;
    v3 = v2 == 0l;
    
    
    if (v3){
        
        ArrayDecref0(v1);
        return v0;
    } else {
        
        
        return method1(v2, v0, v1);
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 1l;
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, false);
    
    
    Array0 * v2;
    v2 = ArrayCreate0(v0, false);
    
    
    
    AssignArray0(&(v1->ptr[0l]), 7l);
    
    
    
    AssignArray0(&(v2->ptr[0l]), 11l);
    v1->refc++; v2->refc++;
    
    Array0 * v3;
    v3 = method0(v1, v2);
    
    
    
    AssignArray0(&(v3->ptr[0l]), 13l);
    
    ArrayDecref0(v3);
    int32_t v4;
    v4 = v1->ptr[0l];
    
    ArrayDecref0(v1);
    bool v5;
    v5 = v4 == 13l;
    
    
    if (v5){
        
        
        int32_t v6;
        v6 = v2->ptr[0l];
        
        ArrayDecref0(v2);
        bool v7;
        v7 = v6 == 11l;
        
        
        if (v7){
            
            
            return 0l;
        } else {
            
            
            return 2l;
        }
    } else {
        
        ArrayDecref0(v2);
        return 1l;
    }
}
