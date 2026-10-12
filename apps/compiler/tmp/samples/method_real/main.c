#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
double method0(int32_t v0){
    
    
    bool v1;
    v1 = v0 == 0l;
    
    
    if (v1){
        
        
        return 0.0;
    } else {
        
        
        return 1.5;
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 7l;
    
    
    double v1;
    v1 = method0(v0);
    
    
    bool v2;
    v2 = v1 == 1.5;
    
    
    if (v2){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
