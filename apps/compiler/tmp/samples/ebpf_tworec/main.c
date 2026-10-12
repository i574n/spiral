#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t method1(int32_t v0, int32_t v1){
    
    
    int32_t v2;
    v2 = v0 - 1l;
    
    
    int32_t v3;
    v3 = v1 + 3l;
    
    
    bool v4;
    v4 = v2 == 0l;
    
    
    if (v4){
        
        
        return v3;
    } else {
        
        
        return method1(v2, v3);
    }
}
int32_t method0(int32_t v0){
    
    
    int32_t v1;
    v1 = 0l;
    
    
    bool v2;
    v2 = v0 == 0l;
    
    
    if (v2){
        
        
        return v1;
    } else {
        
        
        return method1(v0, v1);
    }
}
int32_t method3(int32_t v0, int32_t v1){
    
    
    int32_t v2;
    v2 = v0 - 1l;
    
    
    int32_t v3;
    v3 = v1 - 2l;
    
    
    bool v4;
    v4 = v2 == 0l;
    
    
    if (v4){
        
        
        return v3;
    } else {
        
        
        return method3(v2, v3);
    }
}
int32_t method2(int32_t v0){
    
    
    int32_t v1;
    v1 = 0l;
    
    
    bool v2;
    v2 = v0 == 0l;
    
    
    if (v2){
        
        
        return v1;
    } else {
        
        
        return method3(v0, v1);
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 4l;
    
    
    int32_t v1;
    v1 = method0(v0);
    
    
    int32_t v2;
    v2 = method2(v0);
    
    
    bool v3;
    v3 = v1 == 12l;
    
    
    bool v5;
    if (v3){
        
        
        bool v4;
        v4 = v2 == -8l;
        
        
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
