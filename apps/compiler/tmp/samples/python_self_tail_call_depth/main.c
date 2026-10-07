#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t count_down0(int32_t v0, int32_t v1){
    
    
    bool v2;
    v2 = 0l < v0;
    
    
    if (v2){
        
        
        int32_t v3;
        v3 = v0 - 1l;
        
        
        int32_t v4;
        v4 = v1 + 1l;
        
        
        return count_down0(v3, v4);
    } else {
        
        
        return v1;
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 5000l;
    
    
    int32_t v1;
    v1 = 0l;
    
    
    int32_t v2;
    v2 = count_down0(v0, v1);
    
    
    bool v3;
    v3 = v2 == 5000l;
    
    
    if (v3){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
