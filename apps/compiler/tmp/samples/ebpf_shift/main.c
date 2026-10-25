#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    int32_t v0;
    v0 = -8l;
    
    
    int32_t v1;
    v1 = 3l;
    
    
    int32_t v2;
    v2 = 1l;
    
    
    uint32_t v3;
    v3 = 4294967295ul;
    
    
    int32_t v4;
    v4 = 4l;
    
    
    int32_t v5;
    v5 = v0 >> v2;
    
    
    int32_t v6;
    v6 = v1 << v2;
    
    
    uint32_t v7;
    v7 = v3 >> v4;
    
    
    uint32_t v8;
    v8 = v3 << v2;
    
    
    bool v9;
    v9 = v5 == -4l;
    
    
    if (v9){
        
        
        bool v10;
        v10 = v6 == 6l;
        
        
        if (v10){
            
            
            bool v11;
            v11 = v7 == 268435455ul;
            
            
            if (v11){
                
                
                bool v12;
                v12 = v8 == 4294967294ul;
                
                
                if (v12){
                    
                    
                    return 0l;
                } else {
                    
                    
                    return 4l;
                }
            } else {
                
                
                return 3l;
            }
        } else {
            
            
            return 2l;
        }
    } else {
        
        
        return 1l;
    }
}
