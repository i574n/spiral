#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t sum0(int32_t v0){
    
    
    bool v1;
    v1 = v0 < 1l;
    
    
    if (v1){
        
        
        return 0l;
    } else {
        
        
        int32_t v2;
        v2 = v0 - 1l;
        
        
        int32_t v3;
        v3 = sum0(v2);
        
        
        int32_t v4;
        v4 = v0 + v3;
        
        
        return v4;
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 4l;
    
    
    int32_t v1;
    v1 = sum0(v0);
    
    
    bool v2;
    v2 = v1 == 10l;
    
    
    if (v2){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
