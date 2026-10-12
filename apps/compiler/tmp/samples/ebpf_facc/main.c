#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
float method1(int32_t v0, float v1){
    
    
    int32_t v2;
    v2 = v0 - 1l;
    
    
    float v3;
    v3 = v1 + 1.5f;
    
    
    bool v4;
    v4 = v2 == 0l;
    
    
    if (v4){
        
        
        return v3;
    } else {
        
        
        return method1(v2, v3);
    }
}
float method0(int32_t v0, float v1){
    
    
    bool v2;
    v2 = v0 == 0l;
    
    
    if (v2){
        
        
        return v1;
    } else {
        
        
        return method1(v0, v1);
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 4l;
    
    
    float v1;
    v1 = 0.0f;
    
    
    float v2;
    v2 = method0(v0, v1);
    
    
    bool v3;
    v3 = v2 == 6.0f;
    
    
    if (v3){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
