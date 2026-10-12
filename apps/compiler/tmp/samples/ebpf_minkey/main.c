#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    int32_t v1;
    v1 = 0l;
    
    
    int32_t v2;
    v2 = 3l;
    
    
    bool v3;
    v3 = v1 == 0l;
    
    
    bool v5;
    if (v3){
        
        
        bool v4;
        v4 = v2 == 3l;
        
        
        v5 = v4;
    } else {
        
        
        v5 = false;
    }
    
    
    if (v5){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
