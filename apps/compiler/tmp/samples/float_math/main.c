#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
float method0(float v0, float v1){
    
    
    float v2;
    v2 = v0 * v1;
    
    
    float v3;
    v3 = v2 + 0.5f;
    
    
    return v3;
}
int32_t main(){
    
    
    float v0;
    v0 = 1.5f;
    
    
    float v1;
    v1 = 2.0f;
    
    
    float v2;
    v2 = method0(v0, v1);
    
    
    bool v3;
    v3 = v2 >= 3.5f;
    
    
    if (v3){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
