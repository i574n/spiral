#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    int32_t v1;
    v1 = 1l;
    
    
    int32_t v2;
    v2 = v0 << v1;
    
    
    int32_t v3;
    v3 = 0l;
    
    
    int32_t v5;
    v5 = 11l;
    
    
    bool v7;
    v7 = v2 == 6l;
    
    
    bool v9;
    if (v7){
        
        
        bool v8;
        v8 = v3 == 0l;
        
        
        v9 = v8;
    } else {
        
        
        v9 = false;
    }
    
    
    bool v11;
    if (v9){
        
        
        bool v10;
        v10 = v5 == 11l;
        
        
        v11 = v10;
    } else {
        
        
        v11 = false;
    }
    
    
    if (v11){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
