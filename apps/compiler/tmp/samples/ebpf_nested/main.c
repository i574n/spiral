#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
bool method_while0(int32_t v0){
    
    
    bool v1;
    v1 = v0 < 3l;
    
    
    return v1;
}
int32_t method1(int32_t v0, int32_t v1, int32_t v2){
    
    
    int32_t v3;
    v3 = v0 - 1l;
    
    
    int32_t v4;
    v4 = v1 + v2;
    
    
    bool v5;
    v5 = v3 == 0l;
    
    
    if (v5){
        
        
        return v4;
    } else {
        
        
        int32_t v6;
        v6 = 0l;
        
        
        int32_t v7;
        v7 = 0l;
        
        
        
        while (method_while0(v6)){
            
            
            int32_t v9;
            v9 = v7 + 1l;
            
            
            
            v7 = v9;
            
            
            int32_t v10;
            v10 = v6 + 1l;
            
            
            
            v6 = v10;
            
            
            
        }
        
        
        return method1(v3, v4, v7);
    }
}
int32_t method0(){
    
    
    int32_t v0;
    v0 = 5l;
    
    
    int32_t v1;
    v1 = 0l;
    
    
    bool v2;
    v2 = v0 == 0l;
    
    
    int32_t v9;
    if (v2){
        
        
        v9 = v1;
    } else {
        
        
        int32_t v3;
        v3 = 0l;
        
        
        int32_t v4;
        v4 = 0l;
        
        
        
        while (method_while0(v3)){
            
            
            int32_t v6;
            v6 = v4 + 1l;
            
            
            
            v4 = v6;
            
            
            int32_t v7;
            v7 = v3 + 1l;
            
            
            
            v3 = v7;
            
            
            
        }
        
        
        v9 = method1(v0, v1, v4);
    }
    
    
    int32_t v10;
    v10 = v9 - 15l;
    
    
    return v10;
}
int32_t main(){
    
    
    return method0();
}
