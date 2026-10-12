#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    int32_t v0;
    v0 = -1l;
    
    
    int32_t v1;
    v1 = -8l;
    
    
    int32_t v2;
    v2 = ~v0;
    
    
    int32_t v3;
    v3 = ~v1;
    
    
    bool v4;
    v4 = v2 == 0l;
    
    
    bool v6;
    if (v4){
        
        
        bool v5;
        v5 = v3 == 7l;
        
        
        v6 = v5;
    } else {
        
        
        v6 = false;
    }
    
    
    if (v6){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
