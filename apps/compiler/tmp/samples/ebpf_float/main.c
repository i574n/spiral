#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    float v0;
    v0 = -1.5f;
    
    
    float v1;
    v1 = 2.0f;
    
    
    float v2;
    v2 = v0 / v1;
    
    
    float v3;
    v3 = -0.75f;
    
    
    float v4;
    v4 = v0 * v1;
    
    
    float v5;
    v5 = v4 + 0.5f;
    
    
    float v6;
    v6 = -2.5f;
    
    
    bool v7;
    v7 = v2 == v3;
    
    
    if (v7){
        
        
        bool v8;
        v8 = v5 == v6;
        
        
        if (v8){
            
            
            return 0l;
        } else {
            
            
            return 2l;
        }
    } else {
        
        
        return 1l;
    }
}
