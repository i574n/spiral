#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int32_t v0;
    int32_t v1;
} Tuple0;
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 loop0(int32_t v0, int32_t v1, int32_t v2, int32_t v3){
    while (1) {
        
        
        bool v4;
        v4 = v1 >= v0;
        
        
        if (v4){
            
            
            return TupleCreate0(v2, v3);
        } else {
            
            
            int32_t v5;
            v5 = v1 + 1l;
            
            
            int32_t v6;
            v6 = v2 + 1l;
            
            
            {
                int32_t tmp0 = v0;
                int32_t tmp1 = v5;
                int32_t tmp2 = v6;
                int32_t tmp3 = v3;
                v0 = tmp0;
                v1 = tmp1;
                v2 = tmp2;
                v3 = tmp3;
            }
            continue;
        }
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 5l;
    
    
    int32_t v1;
    v1 = 0l;
    
    
    int32_t v2;
    v2 = 1l;
    
    
    int32_t v3;
    v3 = 2l;
    
    
    int32_t v4; int32_t v5;
    Tuple0 tmp4 = loop0(v0, v1, v2, v3);
    v4 = tmp4.v0; v5 = tmp4.v1;
    
    
    int32_t v6;
    v6 = v4 + v5;
    
    
    return v6;
}
