#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
static inline void ArrayDecrefBody0(Array0 * x){
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
int32_t method2(int32_t v0, String * v1){
    
    
    int32_t v2;
    v2 = v0 - 1l ;
    
    
    bool v3;
    v3 = v2 == 0l ;
    
    
    if (v3){
        
        
        bool v4;
        v4 = 7l == 7l ;
        
        
        if (v4){
            
            
            int32_t v5;
            v5 = v1->len-1;
            
            StringDecref(v1);
            return v5;
        } else {
            
            StringDecref(v1);
            return 99l;
        }
    } else {
        
        
        return method1(v2, v1);
    }
}
int32_t method1(int32_t v0, String * v1){
    
    
    int32_t v2;
    v2 = v0 - 1l ;
    
    
    bool v3;
    v3 = v2 == 0l ;
    
    
    if (v3){
        
        
        bool v4;
        v4 = 11l == 7l ;
        
        
        if (v4){
            
            
            int32_t v5;
            v5 = v1->len-1;
            
            StringDecref(v1);
            return v5;
        } else {
            
            StringDecref(v1);
            return 99l;
        }
    } else {
        
        
        return method2(v2, v1);
    }
}
int32_t method0(int32_t v0, String * v1){
    
    
    bool v2;
    v2 = v0 == 0l ;
    
    
    int32_t v7;
    if (v2){
        
        
        bool v3;
        v3 = 7l == 7l ;
        
        
        if (v3){
            
            
            int32_t v4;
            v4 = v1->len-1;
            
            
            v7 = v4;
        } else {
            
            
            v7 = 99l;
        }
    } else {
        v1->refc++;
        
        v7 = method1(v0, v1);
    }
    
    StringDecref(v1);
    int32_t v8;
    v8 = v7 - 2l ;
    
    
    return v8;
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 1000000l;
    
    
    int32_t v1;
    v1 = v0 % 2l ;
    
    
    bool v2;
    v2 = v1 == 0l ;
    
    
    String * v5;
    if (v2){
        
        
        String * v3;
        v3 = StringLit(3, "ok");
        
        
        v5 = v3;
    } else {
        
        
        String * v4;
        v4 = StringLit(3, "go");
        
        
        v5 = v4;
    }
    
    
    return method0(v0, v5);
}
