#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
bool method_while0(){
    
    
    return true;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 0l;
    
    
    int32_t v1;
    v1 = 0l;
    
    
    
    while (method_while0()){
        
        
        int32_t v2;
        v2 = v0 + 1l;
        
        
        
        v0 = v2;
        
        
        bool v3;
        v3 = v0 < 3l;
        
        
        if (v3){
            
            
            
            continue;
            
            
            
        } else {
            
            
            bool v4;
            v4 = v0 >= 6l;
            
            
            if (v4){
                
                
                
                break;
                
                
                
            } else {
                
                
                int32_t v5;
                v5 = v1 + v0;
                
                
                
                v1 = v5;
                
                
                
            }
        }
    }
    
    
    int32_t v6;
    v6 = v1 - 12l;
    
    
    return v6;
}
