#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t main(){
    
    
    float v0;
    v0 = 144.0f;
    
    
    double v1;
    v1 = 81.0;
    
    
    float v2;
    v2 = sqrtf(v0);
    
    
    double v3;
    v3 = sqrt(v1);
    
    
    bool v4;
    v4 = v2 == 12.0f;
    
    
    bool v6;
    if (v4){
        
        
        bool v5;
        v5 = v3 == 9.0;
        
        
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
