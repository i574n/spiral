#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    char v0;
    v0 = 'x';
    
    
    bool v1;
    v1 = v0 == ' ';
    
    
    bool v3;
    if (v1){
        
        
        v3 = true;
    } else {
        
        
        bool v2;
        v2 = v0 == '/';
        
        
        v3 = v2;
    }
    
    
    if (v3){
        
        
        return 1l;
    } else {
        
        
        return 0l;
    }
}
