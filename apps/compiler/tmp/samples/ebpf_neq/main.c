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
    v6 = v0 == v1;
    
    
    bool v7;
    v7 = v6 != true;
    
    
    if (v7){
        
        
        bool v8;
        v8 = v2 == v3;
        
        
        bool v9;
        v9 = v8 != true;
        
        
        if (v9){
            
            
            return 2l;
        } else {
            
            
            bool v10;
            v10 = v5 == -1.5f;
            
            
            if (v10){
                
                
                return 0l;
            } else {
                
                
                return 3l;
            }
        }
    } else {
        
        
        return 1l;
    }
}
