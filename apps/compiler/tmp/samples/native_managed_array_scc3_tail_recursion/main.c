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
void method0(Array0 * v0){
    
    
    int32_t v1;
    v1 = 4l;
    
    
    
    DynamicArrayReserve0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
int32_t method2(int32_t v0, Array0 * v1);
int32_t method4(int32_t v0, Array0 * v1){
    
    
    int32_t v2;
    v2 = v0 - 1l;
    
    
    bool v3;
    v3 = v2 == 0l;
    
    
    if (v3){
        
        
        int32_t v4;
        v4 = v1->ptr[0l];
        
        ArrayDecref0(v1);
        return v4;
    } else {
        
        
        return method2(v2, v1);
    }
}
int32_t method3(int32_t v0, Array0 * v1){
    
    
    int32_t v2;
    v2 = v0 - 1l;
    
    
    bool v3;
    v3 = v2 == 0l;
    
    
    if (v3){
        
        ArrayDecref0(v1);
        return 99l;
    } else {
        
        
        return method4(v2, v1);
    }
}
int32_t method2(int32_t v0, Array0 * v1){
    
    
    int32_t v2;
    v2 = v0 - 1l;
    
    
    bool v3;
    v3 = v2 == 0l;
    
    
    if (v3){
        
        ArrayDecref0(v1);
        return 99l;
    } else {
        
        
        return method3(v2, v1);
    }
}
int32_t method1(Array0 * v0){
    
    
    int32_t v1;
    v1 = 1000002l;
    
    
    bool v2;
    v2 = v1 == 0l;
    
    
    if (v2){
        
        
        int32_t v3;
        v3 = v0->ptr[0l];
        
        ArrayDecref0(v0);
        return v3;
    } else {
        
        
        return method2(v1, v0);
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 1l;
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, false);
    
    
    
    AssignArray0(&(v1->ptr[0l]), 7l);
    v1->refc++;
    
    
    method0(v1);
    v1->refc++;
    
    int32_t v2;
    v2 = method1(v1);
    
    
    
    AssignArray0(&(v1->ptr[0l]), 17l);
    
    
    bool v3;
    v3 = v2 == 7l;
    
    
    if (v3){
        
        
        int32_t v4;
        v4 = v1->ptr[0l];
        
        ArrayDecref0(v1);
        bool v5;
        v5 = v4 == 17l;
        
        
        if (v5){
            
            
            return 0l;
        } else {
            
            
            return 2l;
        }
    } else {
        
        ArrayDecref0(v1);
        return 1l;
    }
}
