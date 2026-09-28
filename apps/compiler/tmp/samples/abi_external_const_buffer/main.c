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
    
    
    Array0 * v2;
    v2 = ArrayCreate0(v0, false);
    
    
    
    AssignArray0(&(v1->ptr[0l]), 65u);
    
    
    
    AssignArray0(&(v1->ptr[1l]), 66u);
    
    
    
    AssignArray0(&(v1->ptr[2l]), 67u);
    
    
    
    AssignArray0(&(v1->ptr[3l]), 68u);
    
    
    
    AssignArray0(&(v2->ptr[0l]), 65u);
    
    
    
    AssignArray0(&(v2->ptr[1l]), 66u);
    
    
    
    AssignArray0(&(v2->ptr[2l]), 67u);
    
    
    
    AssignArray0(&(v2->ptr[3l]), 69u);
    
    
    int32_t v3;
    v3 = 3l;
    
    
    int32_t v4;
    v4 = 4l;
    
    
    int32_t v5;
    v5 = spiral_abi_libc_memcmp(v1,v2,v3);
    
    
    int32_t v6;
    v6 = spiral_abi_libc_memcmp(v1,v2,v4);
    
    
    bool v7;
    v7 = v5 == 0l;
    
    
    if (v7){
        
        
        bool v8;
        v8 = v6 == 0l;
        
        
        if (v8){
            
            ArrayDecref0(v1); ArrayDecref0(v2);
            return 2l;
        } else {
            
            
            uint8_t v9;
            v9 = v1->ptr[3l];
            
            ArrayDecref0(v1);
            bool v10;
            v10 = v9 == 68u;
            
            
            if (v10){
                
                
                uint8_t v11;
                v11 = v2->ptr[3l];
                
                ArrayDecref0(v2);
                bool v12;
                v12 = v11 == 69u;
                
                
                if (v12){
                    
                    
                    return 0l;
                } else {
                    
                    
                    return 4l;
                }
            } else {
                
                ArrayDecref0(v2);
                return 3l;
            }
        }
    } else {
        
        ArrayDecref0(v1); ArrayDecref0(v2);
        return 1l;
    }
}
