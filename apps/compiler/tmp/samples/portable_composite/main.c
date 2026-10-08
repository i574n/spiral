#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int32_t v0;
    int32_t v1;
    bool v2;
} Tuple0;
typedef struct {
    float v1;
    int32_t v2;
    bool v0;
} Tuple1;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1, bool v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple0 method1(int32_t v0){
    
    
    int32_t v1;
    v1 = v0 + 2l;
    
    
    bool v2;
    v2 = v0 > 0l;
    
    
    return TupleCreate0(v0, v1, v2);
}
int32_t method2(int32_t v0, int32_t v1, bool v2){
    
    
    if (v2){
        
        
        int32_t v3;
        v3 = v0 + v1;
        
        
        int32_t v4;
        v4 = v3 - 4l;
        
        
        return v4;
    } else {
        
        
        return 1l;
    }
}
static inline Tuple1 TupleCreate1(bool v0, float v1, int32_t v2){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple1 method4(float v0){
    
    
    bool v1;
    v1 = v0 >= 3.5f;
    
    
    return TupleCreate1(v1, v0, 7l);
}
int32_t method5(bool v0, float v1, int32_t v2){
    
    
    if (v0){
        
        
        bool v3;
        v3 = v1 >= 3.5f;
        
        
        if (v3){
            
            
            int32_t v4;
            v4 = v2 - 7l;
            
            
            return v4;
        } else {
            
            
            return 1l;
        }
    } else {
        
        
        return 2l;
    }
}
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref0(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
bool method7(String * v0){
    
    StringDecref(v0);
    return true;
}
bool method9(uint32_t v0){
    
    
    uint32_t v1;
    v1 = v0 + 5ul;
    
    
    uint32_t v2;
    v2 = v1 % 4ul;
    
    
    bool v3;
    v3 = v2 == 0ul;
    
    
    return v3;
}
int32_t method11(int32_t v0, int32_t v1){
    
    
    int32_t v2;
    v2 = v0 * v1;
    
    
    int32_t v3;
    v3 = v2 + 5l;
    
    
    int32_t v4;
    v4 = v3 / 3l;
    
    
    return v4;
}
int32_t method10(int32_t v0){
    
    
    int32_t v1;
    v1 = 4l;
    
    
    int32_t v2;
    v2 = 4l;
    
    
    int32_t v3;
    v3 = method11(v1, v2);
    
    
    int32_t v4;
    v4 = v0 + v3;
    
    
    int32_t v5;
    v5 = v4 - 7l;
    
    
    return v5;
}
int32_t method8(int32_t v0){
    
    
    uint32_t v1;
    v1 = 7ul;
    
    
    bool v2;
    v2 = method9(v1);
    
    
    if (v2){
        
        
        return method10(v0);
    } else {
        
        
        return 1l;
    }
}
int32_t method6(int32_t v0){
    
    
    String * v1;
    v1 = StringLit(7, "spiral");
    v1->refc++;
    
    bool v2;
    v2 = method7(v1);
    
    StringDecref(v1);
    if (v2){
        
        
        return method8(v0);
    } else {
        
        
        return 1l;
    }
}
int32_t method3(int32_t v0){
    
    
    float v1;
    v1 = 4.0f;
    
    
    bool v2; float v3; int32_t v4;
    Tuple1 tmp1 = method4(v1);
    v2 = tmp1.v0; v3 = tmp1.v1; v4 = tmp1.v2;
    
    
    int32_t v5;
    v5 = method5(v2, v3, v4);
    
    
    int32_t v6;
    v6 = v0 + v5;
    
    
    return method6(v6);
}
int32_t method0(int32_t v0){
    
    
    int32_t v1;
    v1 = 1l;
    
    
    int32_t v2; int32_t v3; bool v4;
    Tuple0 tmp0 = method1(v1);
    v2 = tmp0.v0; v3 = tmp0.v1; v4 = tmp0.v2;
    
    
    int32_t v5;
    v5 = method2(v2, v3, v4);
    
    
    int32_t v6;
    v6 = v0 + v5;
    
    
    return method3(v6);
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 0l;
    
    
    return method0(v0);
}
