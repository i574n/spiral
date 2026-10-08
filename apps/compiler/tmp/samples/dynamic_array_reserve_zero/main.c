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
void method0(Array0 * v0){
    
    
    int32_t v1;
    v1 = 3l;
    
    
    
    DynamicArrayReserve0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
int32_t method1(Array0 * v0){
    
    
    int32_t v1;
    v1 = DynamicArrayCapacity0(v0);
    
    ArrayDecref0(v0);
    return v1;
}
void method2(Array0 * v0){
    
    
    int32_t v1;
    v1 = 2l;
    
    
    
    DynamicArrayReserve0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
int32_t method3(Array0 * v0){
    
    
    int32_t v1;
    v1 = DynamicArrayCapacity0(v0);
    
    ArrayDecref0(v0);
    return v1;
}
void method4(Array0 * v0){
    
    
    int32_t v1;
    v1 = 3l;
    
    
    
    DynamicArrayResize0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    
    
    *a = b;
}
void method5(Array0 * v0){
    
    
    int32_t v1;
    v1 = 0l;
    
    
    
    DynamicArrayResize0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
void method6(Array0 * v0){
    
    
    int32_t v1;
    v1 = 3l;
    
    
    
    DynamicArrayResize0(v0,v1);
    
    ArrayDecref0(v0);
    return ;
}
int32_t main(){
    
    
    Array0 * v0;
    v0 = ArrayCreate0(0l, false);
    v0->refc++;
    
    
    method0(v0);
    v0->refc++;
    
    int32_t v1;
    v1 = method1(v0);
    
    
    bool v2;
    v2 = v1 < 3l;
    
    
    if (v2){
        
        ArrayDecref0(v0);
        return 10l;
    } else {
        v0->refc++;
        
        
        method2(v0);
        v0->refc++;
        
        int32_t v3;
        v3 = method3(v0);
        
        
        bool v4;
        v4 = v3 == v1;
        
        
        if (v4){
            v0->refc++;
            
            
            method4(v0);
            
            
            
            AssignArray0(&(v0->ptr[0l]), 4l);
            
            
            
            AssignArray0(&(v0->ptr[1l]), 5l);
            
            
            
            AssignArray0(&(v0->ptr[2l]), 6l);
            v0->refc++;
            
            
            method5(v0);
            v0->refc++;
            
            
            method6(v0);
            
            
            int32_t v5;
            v5 = v0->len;
            
            
            int32_t v6;
            v6 = v0->ptr[0l];
            
            
            int32_t v7;
            v7 = v5 + v6;
            
            
            int32_t v8;
            v8 = v0->ptr[1l];
            
            
            int32_t v9;
            v9 = v7 + v8;
            
            
            int32_t v10;
            v10 = v0->ptr[2l];
            
            ArrayDecref0(v0);
            int32_t v11;
            v11 = v9 + v10;
            
            
            int32_t v12;
            v12 = v11 - 3l;
            
            
            return v12;
        } else {
            
            ArrayDecref0(v0);
            return 11l;
        }
    }
}
