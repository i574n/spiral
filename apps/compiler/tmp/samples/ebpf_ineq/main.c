#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    int32_t v0;
    v0 = -3l;
    
    
    int32_t v1;
    v1 = -4l;
    
    
    int32_t v2;
    v2 = -3l;
    
    
    uint32_t v3;
    v3 = 4294967295ul;
    
    
    uint32_t v4;
    v4 = 0ul;
    
    
    uint32_t v5;
    v5 = 4294967295ul;
    
    
    float v6;
    v6 = -1.5f;
    
    
    float v7;
    v7 = -0.5f;
    
    
    float v8;
    v8 = -1.5f;
    
    
    bool v9;
    v9 = v0 != v1;
    
    
    bool v10;
    v10 = v0 != v2;
    
    
    bool v11;
    v11 = v3 != v4;
    
    
    bool v12;
    v12 = v3 != v5;
    
    
    bool v13;
    v13 = v6 != v7;
    
    
    bool v14;
    v14 = v6 != v8;
    
    
    bool v15;
    v15 = v9 && v11;
    
    
    bool v16;
    v16 = v15 && v13;
    
    
    if (v16){
        
        
        if (v10){
            
            
            return 1l;
        } else {
            
            
            if (v12){
                
                
                return 2l;
            } else {
                
                
                if (v14){
                    
                    
                    return 3l;
                } else {
                    
                    
                    return 0l;
                }
            }
        }
    } else {
        
        
        return 4l;
    }
}
