#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t method2(){
    
    
    return 14l;
}
int32_t method1(){
    
    
    int32_t v0;
    v0 = method2();
    
    
    int32_t v1;
    v1 = 14l + v0;
    
    
    return v1;
}
int32_t method0(){
    
    
    int32_t v0;
    v0 = method1();
    
    
    int32_t v1;
    v1 = 14l + v0;
    
    
    return v1;
}
int32_t main(){
    
    
    return method0();
}
