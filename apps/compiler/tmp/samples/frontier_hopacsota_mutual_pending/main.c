#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
bool is_even0(int32_t v0);
bool is_odd1(int32_t v0){
    
    
    bool v1;
    v1 = v0 == 0l;
    
    
    if (v1){
        
        
        return false;
    } else {
        
        
        int32_t v2;
        v2 = v0 - 1l;
        
        
        return is_even0(v2);
    }
}
bool is_even0(int32_t v0){
    
    
    bool v1;
    v1 = v0 == 0l;
    
    
    if (v1){
        
        
        return true;
    } else {
        
        
        int32_t v2;
        v2 = v0 - 1l;
        
        
        return is_odd1(v2);
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 10l;
    
    
    bool v1;
    v1 = is_even0(v0);
    
    
    if (v1){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
