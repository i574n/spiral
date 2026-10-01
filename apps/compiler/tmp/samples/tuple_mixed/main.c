#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    float v1;
    int32_t v2;
    bool v0;
} Tuple0;
static inline Tuple0 TupleCreate0(bool v0, float v1, int32_t v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple0 method0(float v0){
    
    
    bool v1;
    v1 = v0 >= 3.5f;
    
    
    return TupleCreate0(v1, v0, 7l);
}
int32_t method1(int32_t v0, float v1, bool v2){
    
    
    if (v2){
        
        
        bool v3;
        v3 = v1 >= 3.5f;
        
        
        if (v3){
            
            
            int32_t v4;
            v4 = v0 - 7l;
            
            
            return v4;
        } else {
            
            
            return 1l;
        }
    } else {
        
        
        return 2l;
    }
}
int32_t main(){
    
    
    float v0;
    v0 = 4.0f;
    
    
    bool v1; float v2; int32_t v3;
    Tuple0 tmp0 = method0(v0);
    v1 = tmp0.v0; v2 = tmp0.v1; v3 = tmp0.v2;
    
    
    return method1(v3, v2, v1);
}
