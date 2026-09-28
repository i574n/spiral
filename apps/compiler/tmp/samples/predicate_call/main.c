#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
bool is_answer1(int32_t v0){
    
    
    bool v1;
    v1 = v0 == 42l ;
    
    
    return v1;
}
bool method0(int32_t v0){
    
    
    return is_answer1(v0);
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 42l;
    
    
    bool v1;
    v1 = method0(v0);
    
    
    if (v1){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
