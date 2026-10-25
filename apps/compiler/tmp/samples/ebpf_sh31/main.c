#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    uint32_t v0;
    v0 = 1ul;
    
    
    int32_t v1;
    v1 = 0l;
    
    
    int32_t v2;
    v2 = 31l;
    
    
    uint32_t v3;
    v3 = v0 << v2;
    
    
    uint32_t v4;
    v4 = v3 >> v2;
    
    
    uint32_t v5;
    v5 = v0 << v1;
    
    
    bool v6;
    v6 = v3 == 2147483648ul;
    
    
    bool v8;
    if (v6){
        
        
        bool v7;
        v7 = v4 == 1ul;
        
        
        v8 = v7;
    } else {
        
        
        v8 = false;
    }
    
    
    bool v10;
    if (v8){
        
        
        bool v9;
        v9 = v5 == 1ul;
        
        
        v10 = v9;
    } else {
        
        
        v10 = false;
    }
    
    
    if (v10){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
