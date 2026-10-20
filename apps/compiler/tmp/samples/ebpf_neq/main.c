#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    int32_t v1;
    v1 = 4l;
    
    
    uint32_t v2;
    v2 = 1ul;
    
    
    uint32_t v3;
    v3 = 1ul;
    
    
    float v4;
    v4 = 1.5f;
    
    
    float v5;
    v5 = -v4;
    
    
    bool v6;
    v6 = v0 != v1;
    
    
    if (v6){
        
        
        bool v7;
        v7 = v2 != v3;
        
        
        if (v7){
            
            
            return 2l;
        } else {
            
            
            bool v8;
            v8 = v5 == -1.5f;
            
            
            if (v8){
                
                
                return 0l;
            } else {
                
                
                return 3l;
            }
        }
    } else {
        
        
        return 1l;
    }
}
