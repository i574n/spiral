#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int32_t v0;
    int32_t v1;
    int32_t v2;
} Tuple0;
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1, int32_t v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple0 method2(int32_t v0, int32_t v1, int32_t v2, int32_t v3){
    
    
    int32_t v4;
    v4 = v0 - 1l;
    
    
    int32_t v5;
    v5 = v1 + 1l;
    
    
    int32_t v6;
    v6 = v2 + 2l;
    
    
    int32_t v7;
    v7 = v3 + 3l;
    
    
    bool v8;
    v8 = v4 == 0l;
    
    
    if (v8){
        
        
        return TupleCreate0(v5, v6, v7);
    } else {
        
        
        return method2(v4, v5, v6, v7);
    }
}
Tuple0 method1(int32_t v0){
    
    
    int32_t v1;
    v1 = 0l;
    
    
    int32_t v2;
    v2 = 0l;
    
    
    int32_t v3;
    v3 = 0l;
    
    
    bool v4;
    v4 = v0 == 0l;
    
    
    if (v4){
        
        
        return TupleCreate0(v1, v2, v3);
    } else {
        
        
        return method2(v0, v1, v2, v3);
    }
}
int32_t method0(int32_t v0){
    
    
    int32_t v1; int32_t v2; int32_t v3;
    Tuple0 tmp0 = method1(v0);
    v1 = tmp0.v0; v2 = tmp0.v1; v3 = tmp0.v2;
    
    
    bool v4;
    v4 = v1 == 3l;
    
    
    bool v6;
    if (v4){
        
        
        bool v5;
        v5 = v2 == 6l;
        
        
        v6 = v5;
    } else {
        
        
        v6 = false;
    }
    
    
    bool v8;
    if (v6){
        
        
        bool v7;
        v7 = v3 == 9l;
        
        
        v8 = v7;
    } else {
        
        
        v8 = false;
    }
    
    
    if (v8){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 3l;
    
    
    return method0(v0);
}
