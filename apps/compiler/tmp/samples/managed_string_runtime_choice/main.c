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
String * choose0(bool v0){
    
    
    if (v0){
        
        
        String * v1;
        v1 = StringLit(6, "alpha");
        
        
        return v1;
    } else {
        
        
        String * v2;
        v2 = StringLit(5, "beta");
        
        
        return v2;
    }
}
int32_t measure1(String * v0){
    
    
    int32_t v1;
    v1 = v0->len-1;
    
    StringDecref(v0);
    return v1;
}
int32_t main(){
    
    
    bool v0;
    v0 = true;
    
    
    String * v1;
    v1 = choose0(v0);
    
    
    bool v2;
    v2 = false;
    
    
    String * v3;
    v3 = choose0(v2);
    v1->refc++;
    
    int32_t v4;
    v4 = measure1(v1);
    v1->refc++;
    
    int32_t v5;
    v5 = measure1(v1);
    
    StringDecref(v1);
    int32_t v6;
    v6 = v4 + v5 ;
    v3->refc++;
    
    int32_t v7;
    v7 = measure1(v3);
    
    StringDecref(v3);
    int32_t v8;
    v8 = v6 + v7 ;
    
    
    int32_t v9;
    v9 = v8 - 14l ;
    
    
    return v9;
}
