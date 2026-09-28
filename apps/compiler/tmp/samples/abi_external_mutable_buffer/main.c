#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    uint8_t ptr[];
} Array0;
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(uint8_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, uint8_t * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(uint8_t) * len);
    return x;
}
static inline void AssignArray0(uint8_t * a, uint8_t b){
    
    
    *a = b;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 4l;
    
    
    Array0 * v1;
    v1 = ArrayCreate0(v0, false);
    
    
    
    AssignArray0(&(v1->ptr[0l]), 0u);
    
    
    
    AssignArray0(&(v1->ptr[1l]), 0u);
    
    
    
    AssignArray0(&(v1->ptr[2l]), 0u);
    
    
    
    AssignArray0(&(v1->ptr[3l]), 0u);
    
    
    int32_t v2;
    v2 = 65l;
    
    
    int32_t v3;
    v3 = 3l;
    
    
    int32_t v4;
    v4 = spiral_abi_libc_memset(v1,v2,v3);
    
    
    bool v5;
    v5 = v4 == 3l ;
    
    
    if (v5){
        
        
        uint8_t v6;
        v6 = v1->ptr[0l];
        
        
        bool v7;
        v7 = v6 == 65u ;
        
        
        if (v7){
            
            
            uint8_t v8;
            v8 = v1->ptr[1l];
            
            
            bool v9;
            v9 = v8 == 65u ;
            
            
            if (v9){
                
                
                uint8_t v10;
                v10 = v1->ptr[2l];
                
                
                bool v11;
                v11 = v10 == 65u ;
                
                
                if (v11){
                    
                    
                    uint8_t v12;
                    v12 = v1->ptr[3l];
                    
                    ArrayDecref0(v1);
                    bool v13;
                    v13 = v12 == 0u ;
                    
                    
                    if (v13){
                        
                        
                        return 0l;
                    } else {
                        
                        
                        return 4l;
                    }
                } else {
                    
                    ArrayDecref0(v1);
                    return 3l;
                }
            } else {
                
                ArrayDecref0(v1);
                return 2l;
            }
        } else {
            
            ArrayDecref0(v1);
            return 1l;
        }
    } else {
        
        ArrayDecref0(v1);
        return 5l;
    }
}
