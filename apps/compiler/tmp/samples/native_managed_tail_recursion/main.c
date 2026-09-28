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
String * method1(int32_t v0, String * v1){
    
    
    int32_t v2;
    v2 = v0 - 1l;
    
    
    bool v3;
    v3 = v2 == 0l;
    
    
    if (v3){
        
        
        return v1;
    } else {
        
        StringDecref(v1);
        int32_t v4;
        v4 = v2 % 2l;
        
        
        bool v5;
        v5 = v4 == 0l;
        
        
        String * v8;
        if (v5){
            
            
            String * v6;
            v6 = StringLit(3, "ok");
            
            
            v8 = v6;
        } else {
            
            
            String * v7;
            v7 = StringLit(3, "go");
            
            
            v8 = v7;
        }
        
        
        return method1(v2, v8);
    }
}
String * method0(){
    
    
    int32_t v0;
    v0 = 1000000l;
    
    
    bool v1;
    v1 = v0 == 0l;
    
    
    if (v1){
        
        
        String * v2;
        v2 = StringLit(5, "seed");
        
        
        return v2;
    } else {
        
        
        int32_t v3;
        v3 = v0 % 2l;
        
        
        bool v4;
        v4 = v3 == 0l;
        
        
        String * v7;
        if (v4){
            
            
            String * v5;
            v5 = StringLit(3, "ok");
            
            
            v7 = v5;
        } else {
            
            
            String * v6;
            v6 = StringLit(3, "go");
            
            
            v7 = v6;
        }
        
        
        return method1(v0, v7);
    }
}
int32_t main(){
    
    
    String * v0;
    v0 = method0();
    
    
    int32_t v1;
    v1 = v0->len-1;
    
    StringDecref(v0);
    bool v2;
    v2 = v1 == 2l;
    
    
    if (v2){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
