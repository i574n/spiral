#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    char v0;
    v0 = 'A';
    
    
    char v1;
    v1 = 'B';
    
    
    bool v2;
    v2 = v0 == 'A';
    
    
    if (v2){
        
        
        bool v3;
        v3 = v1 == 'B';
        
        
        if (v3){
            
            
            bool v4;
            v4 = v0 == v1;
            
            
            if (v4){
                
                
                return 2l;
            } else {
                
                
                return 0l;
            }
        } else {
            
            
            return 3l;
        }
    } else {
        
        
        return 1l;
    }
}
