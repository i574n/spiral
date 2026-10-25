#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t method0(int32_t v0, int32_t v1, int32_t v2){
    
    
    int32_t v3;
    v3 = v0 * v1;
    
    
    int32_t v4;
    v4 = v3 + v2;
    
    
    int32_t v5;
    v5 = v4 - 42l;
    
    
    return v5;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 5l;
    
    
    int32_t v1;
    v1 = 8l;
    
    
    int32_t v2;
    v2 = 2l;
    
    
    return method0(v0, v1, v2);
}
