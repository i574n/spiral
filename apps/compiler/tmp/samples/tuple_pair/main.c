#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int32_t v0;
    int32_t v1;
} Tuple0;
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 method0(int32_t v0, int32_t v1){
    
    
    return TupleCreate0(v0, v1);
}
int32_t method1(int32_t v0, int32_t v1){
    
    
    int32_t v2;
    v2 = v0 + v1;
    
    
    return v2;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 20l;
    
    
    int32_t v1;
    v1 = 22l;
    
    
    int32_t v2; int32_t v3;
    Tuple0 tmp0 = method0(v0, v1);
    v2 = tmp0.v0; v3 = tmp0.v1;
    
    
    int32_t v4;
    v4 = method1(v2, v3);
    
    
    int32_t v5;
    v5 = v4 - 42l;
    
    
    return v5;
}
